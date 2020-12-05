using ComClassLib.DB;
using ComClassLib.FileOp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;

namespace ProjectDropper.core {
    /// <summary>
    /// 完成对数据库文件的操作
    /// </summary>
    public class DBFileOp {

        const int offsetDB = 1000;
        public enum DbName {
            LoginDb,    //登录数据库
            IndexDb,    //索引数据库
            CurrDb,     //当前分库图像数据库
            TmpDbA,     //临时数据库A
            TmpDbB      //临时数据库A
        }

        private string pathA, pathB, workPath;//监听2个文件路径
        private SqliteHelper CurrMainDB, CurrSecondDB, IndexDB;
        private List<string> lsProcessedFilesA, lsProcessedFilesB;
        private Thread currTh;
        public bool IsStop;
        /// <summary>
        /// 索引库文件路径（包含文件名）
        /// </summary>
        public string IndexDBFullName {
            get; set;
        }
        public DBFileOp(string _pathA, string _pathB, string _workPath) {
            pathA = _pathA; pathB = _pathB; workPath = _workPath;
            lsProcessedFilesA = new List<string>();
            lsProcessedFilesB = new List<string>();
            IndexDBFullName = Path.Combine(workPath, DbName.IndexDb.ToString() + ".db");
            CreateIndexDB();//判断并创建索引库
            IndexDB = SqliteHelper.GetSqlite(DbName.IndexDb.ToString());
            IsStop = false;
            currTh = new Thread(MonitorDir);
        }
        /// <summary>
        /// 读取索引数据库 查看已经处理过的文件
        /// </summary>
        private void IniProcessedFiles() {
            string strSQL = "select distict dbIndexA from indexTB";
            DataTable dt = IndexDB.ExecuteDataTable(strSQL, null);
            foreach (DataRow row in dt.Rows) {
                lsProcessedFilesA.Add(row[0].ToString());
            }
            strSQL = "select distict dbIndexB from indexTB";
            dt = IndexDB.ExecuteDataTable(strSQL, null);
            foreach (DataRow row in dt.Rows) {
                lsProcessedFilesB.Add(row[0].ToString());
            }

        }
        /// <summary>
        /// 判断索引数据库是否存在，不存在创建
        /// </summary>
        private void CreateIndexDB() {
            if (!System.IO.File.Exists(IndexDBFullName)) {
                FileHelper.CreateDir(Path.GetDirectoryName(IndexDBFullName));
            }
            IndexDB = SqliteHelper.GenerateSqlite(DbName.IndexDb.ToString(), IndexDBFullName);
            if (!IndexDB.IsTableExist("indexTB")) {
                //线路信息表
                string strCreateStationTB = "CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY,sName varchar(50),sType tinyint,taskDate DATE );";
                //创建索引表
                string strCreateIndexTB = "CREATE TABLE indexTB([timestamp] INT64 PRIMARY KEY,[poleNum] VARCHAR(50), [KMValue] INTEGER, " +
                    "[timestampA] INT64 NOT NULL, [dbIndexA] VARCHAR(1024) NOT NULL,[timestampB] INT64 ,[dbIndexB] VARCHAR(1024));";
                try {
                    IndexDB = SqliteHelper.GenerateSqlite(DbName.IndexDb.ToString(), IndexDBFullName);
                    IndexDB.ExecuteNonQuery(strCreateStationTB);
                    IndexDB.ExecuteNonQuery(strCreateIndexTB);
                } catch {
                    if (IndexDB != null) {
                        IndexDB.CloseDb();
                        IndexDB = null;
                    }
                }
            }
        }
        /// <summary>
        /// 对主图像进行索引-- 将值查询插入即可
        /// </summary>
        private void IndexMainDB() {
            //CREATE TABLE GWVIDEO(time_stamp INT64 primary key,file_time INT64,file_index int,frame_index int,camera_us INT64, frame_no int,info TEXT,jpeg BLOB);
            string strSQL = "select file_time from GWVIDEO";

            IndexDB.OpenDb();
            IndexDB.BeginTransaction();
            try {

                DataTable dtA = CurrMainDB.ExecuteDataTable(strSQL);
                string dbFileName = Path.GetFileName(CurrMainDB.DbFullName);
                CurrMainDB.CloseDb();
                for (int i = 0; i < dtA.Rows.Count; ++i) {
                    string timestamp = dtA.Rows[i][0].ToString();
                    string insertSQL = $"insert into indexTB(timestamp,timestampA,dbIndexA) values({timestamp},{timestamp},'{dbFileName}')";
                    IndexDB.ExecuteNonQuery(insertSQL);
                }
                IndexDB.Commit();
            } catch(Exception ex) {
                IndexDB.Rollback();
            } finally {
                IndexDB.CloseDb();

            }
        }

        /// <summary>
        /// 对次图像库进行索引-- 比较麻烦，需要查询匹对 再插入
        /// </summary>
        private void IndexSecondDB() {
            //CREATE TABLE GWVIDEO(time_stamp INT64 primary key,file_time INT64,file_index int,frame_index int,camera_us INT64, frame_no int,info TEXT,jpeg BLOB);
            string strSQL = "select file_time from GWVIDEO";

            IndexDB.OpenDb();
            IndexDB.BeginTransaction();
            try {
                DataTable dtB = CurrSecondDB.ExecuteDataTable(strSQL);
                string dbFileName = Path.GetFileName(CurrSecondDB.DbFullName);
                CurrSecondDB.CloseDb();
                for (int i = 0; i < dtB.Rows.Count; ++i) {

                    Int64 timestampB = Convert.ToInt64(dtB.Rows[i][0]);
                    //查找匹配
                    string strQuery = $"select timestamp from indexTB where timestamp>{timestampB - offsetDB} and timestamp<{timestampB + offsetDB}";
                    DataRow dr = IndexDB.ExecuteDataRow(strQuery, null);
                    if (dr == null)
                        continue;
                    string timestamp = dr[0].ToString();
                    if (string.IsNullOrEmpty(timestamp)) {
                        continue;
                    }
                    //insert into indexTB(timestamp,timestampB,dbIndexB) values(132516246871483945,132516246871483945,'2020_12_05_14_51_26_2020_12_05_14_51_25_[西环线-向塘站-乐化普速场_上行]_视频_000.db')
                    string update = $"update indexTb set timestampB={timestampB} ,dbIndexB='{dbFileName}' where timestamp={timestamp} ";
                   // string insertSQL = $"insert into indexTB(timestamp,timestampB,dbIndexB) values({timestamp},{timestampB},)";
                    IndexDB.ExecuteNonQuery(update);
                }
                IndexDB.Commit();
            } catch {
                IndexDB.Rollback();
            } finally {
                IndexDB.CloseDb();
            }

        }

        /// <summary>
        /// 开始数据处理
        /// </summary>
        public void StartProcessDB() {
            if (!currTh.IsAlive) {
                IsStop = false;
                currTh.Start();
            }
        }
        public void StopProcessDB() {
            IsStop = true;
        }
        public void MonitorDir() {
            while (!IsStop) {
                List<FileInfo> lstNoneProcessedFiles = new List<FileInfo>();
                //主目录监控：1.每10秒读取指定文件夹 将没有处理的数据文件加载到列表中
                FileHelper.GetFiles(pathA, ".db", ref lstNoneProcessedFiles, false);
                //进行处理 2.处理主数据库文件
                string destDirA = Path.Combine(workPath, "V1");

                foreach (FileInfo fileA in lstNoneProcessedFiles) {
                    //1.判断占用情况 
                    if (FileHelper.IsFileInUse(fileA.FullName)) {
                        continue;
                    }
                    string fileName = fileA.Name;

                    if (fileName.Contains("sm")) {//缩略图文件直接拷贝
                        FileHelper.FileCopy(fileA.FullName, Path.Combine(destDirA, fileName), true);
                        continue;
                    }
                    if (lsProcessedFilesA.Contains(fileName)) { //已经处理过了
                        continue;
                    }

                    ProcessDB(fileA, 1);
                    lsProcessedFilesA.Add(fileName);
                }

                //进行处理 3.处理次数据库文件
                string destDirB = Path.Combine(workPath, "V2");
                foreach (FileInfo fileB in lstNoneProcessedFiles) {
                    //1.判断占用情况 
                    if (FileHelper.IsFileInUse(fileB.FullName)) {
                        continue;
                    }
                    string fileName = fileB.Name;
                    if (fileName.Contains("sm")) {//缩略图文件直接拷贝
                        FileHelper.FileCopy(fileB.FullName, Path.Combine(destDirB, fileName), true);
                        continue;
                    }
                    if (lsProcessedFilesB.Contains(fileName)) { //已经处理过了
                        continue;
                    }
                    ProcessDB(fileB, 2);
                    lsProcessedFilesB.Add(fileName);
                }

                //休息10秒 继续
                // Thread.Sleep(10000);
            }
        }
        /// <summary>
        /// 处理数据文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool ProcessDB(FileInfo file, int index) {
            //1.判断占用情况，并拷贝
            if (FileHelper.IsFileInUse(file.FullName)) {
                return false;
            }
            //2.不占用--拷贝到目录下
            string destDir = Path.Combine(workPath, "V" + index.ToString());
            try {
                FileHelper.CreateDir(destDir); //目标文件路径
                string destFileFullName = Path.Combine(destDir, file.Name);//目标文件名
                FileHelper.FileCopy(file.FullName, destFileFullName, true);
                if (index == 1) {
                    CurrMainDB = SqliteHelper.GenerateSqlite(DbName.TmpDbA.ToString(), destFileFullName);
                    IndexMainDB();

                } else if (index == 2) {
                    CurrSecondDB = SqliteHelper.GenerateSqlite(DbName.TmpDbB.ToString(), destFileFullName);
                    IndexSecondDB();
                }
            } catch { }


            return true;
        }
    }
}
