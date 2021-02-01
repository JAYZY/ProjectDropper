using ComClassLib;
using ComClassLib.core;
using ComClassLib.DB;
using ComClassLib.FileOp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDropper.core {
    /// <summary>
    /// 完成对数据库文件的操作
    /// </summary>
    public class DBFileOp {

        const int offsetDB = 10000000;
        public enum DbName {
            LoginDb,    //登录数据库
            IndexDb,    //索引数据库
            CurrDb,     //当前分库图像数据库
            TmpDbA,     //临时数据库A
            TmpDbB      //临时数据库A
        }
        public enum Cmd {
            CProgressA,
            CProgressB,
            CPA,
            CPB,
            IndexA,
            MatchB,
            NoMath,
            Over
        }
        public static Action<string> CallFunc { get; set; } //回调函数
        private readonly string srcPathA, srcPathB, workPath;//监听2个文件路径
        private string _destDirA = "", _destDirB = "";//拷贝路径 A  B


        private readonly CancellationTokenSource _tokenSource;
        private CancellationToken _token;
        private readonly ManualResetEvent _resetEvent;
        private string DestDirA {
            get {
                if (string.IsNullOrEmpty(_destDirA)) {
                    _destDirA = string.IsNullOrEmpty(workPath) ? "" : Path.Combine(workPath, "V1");
                }
                return _destDirA;
            }
        }

        private string DestDirB {
            get {
                if (string.IsNullOrEmpty(_destDirB)) {
                    _destDirB = string.IsNullOrEmpty(workPath) ? "" : Path.Combine(workPath, "V2");
                }
                return _destDirB;
            }
        }
        private SqliteHelper CurrMainDB, CurrSecondDB, DBIndex;
        private List<string> lsCopyedFilesA, lsCopyedFilesB; //已经拷贝的文件
        private ConcurrentQueue<string> qUnprocessedA, qUnprocessedB; //还没有处理的文件--线程安全集合

        private ConcurrentQueue<Int64> qMainDbID; //时间ID数据 -- 记录并用于检查 次图像库的匹配信息。

        private ConcurrentBag<string> lsProcessedFilesA, lsProcessedFilesB; //已经处理的文件--线程安全集合
        private ConcurrentQueue<DataTable> lsDtImgBs;//用来存储数据
        private Dictionary<Int64, string> NoMachImgInfo;//记录没有匹配上的数据
        private Thread currTh;
        public bool IsStop;

        public bool IsCpyOver;
        public bool IsIndDBOver;
        /// <summary>
        /// 索引库文件路径（包含文件名）
        /// </summary>
        public string IndexDBFullName {
            get; set;
        }
        public object _dbObj { get; set; }

        public DBFileOp(string _pathA, string _pathB, string _workPath) {
            srcPathA = _pathA; srcPathB = _pathB; workPath = _workPath;
            // destDirA = Path.Combine(workPath, "V1");
            //  destDirB = Path.Combine(workPath, "V2");
            //创建目录
            FileHelper.CreateDir(DestDirA);
            FileHelper.CreateDir(DestDirB);
            IsCpyOver = false;
            IsIndDBOver = false;
            lsCopyedFilesA = new List<string>(); lsCopyedFilesB = new List<string>();

            qUnprocessedA = new ConcurrentQueue<string>(); qUnprocessedB = new ConcurrentQueue<string>();

            lsProcessedFilesA = new ConcurrentBag<string>(); lsProcessedFilesB = new ConcurrentBag<string>();

            NoMachImgInfo = new Dictionary<Int64, string>();

            IndexDBFullName = Path.Combine(workPath, DbName.IndexDb.ToString() + ".db");

            //判断并创建索引库
            CreateIndexDB();

            DBIndex = SqliteHelper.GetSqlite(DbName.IndexDb.ToString());

            currTh = new Thread(MonitorDir);

        }
        /// <summary>
        /// 目录监控
        /// </summary>
        public void MonitorDir() {
            IsStop = false;
            //开启线程任务 -- 拷贝文件
            var taskCpA = new Task(() => CopyMainFile());
            var taskCpB = new Task(() => CopySecondFile());
            taskCpA.Start();
            taskCpB.Start();

            // 在线不做 数据库索引  主数据库与次数据库是互斥的。
            //var TastIndexDB = new Task(() => ProcessIndexDB());
            // TastIndexDB.Start();

        }



        #region 文件拷贝
        public void CopyMainFile() {
            //主目录监控
            List<FileInfo> lsFiles = new List<FileInfo>();

            bool isExit = false;
            //线程 -- 不断的拷贝文件，添加未处理列表
            while (true) {
                lsFiles.Clear();
                FileHelper.GetFiles(srcPathA, ".db", ref lsFiles, false);
                bool isUsed = false;
                //进行处理 -- 处理主数据库文件
                foreach (FileInfo fileInfo in lsFiles) {
                    //1.判断占用情况 
                    if (FileHelper.IsFileInUse(fileInfo.FullName)) {
                        isUsed = true;
                        isExit = false;
                        continue;
                    }
                    string fileName = fileInfo.Name;
                    //2.文件已经拷贝过了
                    if (lsCopyedFilesA.Contains(fileName)) { //已经拷贝了的不拷贝
                        continue;
                    }
                    //3.文件直接拷贝
                    bool res = Copy(fileInfo.FullName, Path.Combine(DestDirA, fileName), true, Cmd.CProgressA);

                    // FileInfo filecpy = FileHelper.FileCopy(fileInfo.FullName, Path.Combine(DestDirA, fileName), true);
                    if (res) {
                        lsCopyedFilesA.Add(fileName);
                        if (!fileName.Contains("sm")) {//缩略图不放入待处理队列中
                            qUnprocessedA.Enqueue(fileName);
                            MsgBox.Show("qUnprocessedA 大小" + qUnprocessedA.Count);
                        }
                        CallFunc?.Invoke($"{Cmd.CPA.ToString()}#{lsCopyedFilesA.Count}#{lsFiles.Count}");
                    }
                }
                if (isExit) {

                    break;
                }

                if (IsStop && !isUsed) {
                    isExit = true;  //在跑一趟
                }
            }
            if (IsCpyOver) {
                CallFunc?.Invoke($"{Cmd.CPB}#{lsCopyedFilesA.Count}#{lsFiles.Count}");
                CallFunc?.Invoke($"{Cmd.Over.ToString()}#cp");
            }
            IsCpyOver = true;

        }

        /// <summary>
        /// 不断拷贝 文件
        /// </summary>
        public void CopySecondFile() {
            //主目录监控
            List<FileInfo> lsFiles = new List<FileInfo>();
            bool isExit = false;
            //线程 -- 不断的拷贝文件，添加未处理列表
            while (true) {
                lsFiles.Clear();
                FileHelper.GetFiles(srcPathB, ".db", ref lsFiles, false);
                //进行处理 -- 处理主数据库文件
                bool isUsed = false;
                foreach (FileInfo fileInfo in lsFiles) {
                    //1.判断占用情况 
                    if (FileHelper.IsFileInUse(fileInfo.FullName)) {
                        isUsed = true;
                        isExit = false;
                        continue;
                    }
                    string fileName = fileInfo.Name;
                    //2.文件已经拷贝过了
                    if (lsCopyedFilesB.Contains(fileName)) { //已经拷贝了的不拷贝
                        continue;
                    }
                    //3.文件直接拷贝
                    bool res = Copy(fileInfo.FullName, Path.Combine(DestDirB, fileName), true, Cmd.CProgressB);
                    // FileInfo filecpy = FileHelper.FileCopy(fileInfo.FullName, Path.Combine(DestDirB, fileName), true);
                    if (res) {
                        lsCopyedFilesB.Add(fileName);
                        if (!fileName.Contains("sm")) {//缩略图不放入待处理队列中
                            MsgBox.Show("qUnprocessedB 大小" + qUnprocessedB.Count);
                            qUnprocessedB.Enqueue(fileName);
                        }
                        CallFunc?.Invoke($"{Cmd.CPB}#{lsCopyedFilesB.Count}#{lsFiles.Count}");
                    }
                }
                //线程停止且没有文件在使用，说明拷贝结束。
                if (isExit) {
                    CallFunc?.Invoke($"{Cmd.CPB}#{lsCopyedFilesB.Count}#{lsFiles.Count}");
                    break;
                }
                if (IsStop && !isUsed) {

                    isExit = true;  //在跑一趟
                }
            }
            if (IsCpyOver) {
                CallFunc?.Invoke($"{Cmd.Over.ToString()}#cp");
            }
            IsCpyOver = true;
        }


        public static Object lockObj = new object(); //写文件的线程锁 
        private static int bufferSize = 1;

        public static bool Copy(string srcFile, string destFile, bool isOverwrite, Cmd pCmd) {
            FileStream fsRead = null;
            FileStream fsWrite = null;
            //定义一个1M的缓冲区 
            byte[] buffer = new byte[1024 * 1024 * bufferSize];
            try {

                //创建一个文件流指向源文件 
                fsRead = new FileStream(srcFile, FileMode.Open);
                //创建一个文件流指向目标文件 
                if (isOverwrite && File.Exists(destFile)) {
                    File.Delete(destFile);
                }
                string fileName = Path.GetFileName(destFile);
                fsWrite = new FileStream(destFile, FileMode.Create);
                //记录一下该文件的长度
                long fileLength = fsRead.Length;
                //先读取一次,并且将读取到的真正内容长度记录下来 
                int readLength = fsRead.Read(buffer, 0, buffer.Length);
                //用来记录已经将多少内容写入到了文件中 
                long readCount = 0; //只要读取到的内容不为0就接着读 
                while (readLength != 0) {

                    //将前面已经读取到内存中的数据写入到文件中 
                    fsWrite.Write(buffer, 0, readLength);
                    //已经读取的数量累加 
                    readCount += readLength;
                    //计算已经读取的数据百分比 
                    int percentage = (int)(readCount * 100 / fileLength);
                    CallFunc?.Invoke($"{pCmd.ToString()}#{fileName}#{percentage}");
                    lock (lockObj) {
                        //进行下一次读取 
                        readLength = fsRead.Read(buffer, 0, buffer.Length);
                    }
                }


            } catch (Exception) {
            } finally {
                fsRead.Close(); fsWrite.Close();
                //清空缓冲区
                buffer = null;
                //回收一下内存
                GC.Collect();
            }
            return true;
        }

        #endregion




        public void WriteLineInfo(StationInfo stationInfo) {
            string sSQL = $"insert into stationInfo (sLineName,sStartStation,sEndStation,iType,taskDate) " +
                $"values('{stationInfo.LineName}','{stationInfo.StartStation}','{stationInfo.EndStation}', {stationInfo.IType},'{stationInfo.TaskDate.ToString("s")}')";
            try {
                DBIndex.ExecuteNonQuery(sSQL);
            } catch {
                DBIndex.CloseDb();
            }

        }
        /// <summary>
        /// 读取索引数据库 查看已经处理过的文件
        /// </summary>
        private void IniProcessedFiles() {
            string strSQL = "select distict dbIndexA from indexTB";
            DataTable dt = DBIndex.ExecuteDataTable(strSQL, null);
            foreach (DataRow row in dt.Rows) {
                lsProcessedFilesA.Add(row[0].ToString());
            }
            strSQL = "select distict dbIndexB from indexTB";
            dt = DBIndex.ExecuteDataTable(strSQL, null);
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
            DBIndex = SqliteHelper.GenerateSqlite(DbName.IndexDb.ToString(), IndexDBFullName);
            if (!DBIndex.IsTableExist("indexTB")) {
                //线路信息表
                string strCreateStationTB = "CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY AUTOINCREMENT, sLineName varchar(255),sStartStation VARCHAR(255), sEndStation VARCHAR(255), iType tinyint, taskDate  DATETIME );";

                //创建索引表
                string strCreateIndexTB = "CREATE TABLE indexTB([timestamp] INT64 PRIMARY KEY,[poleNum] VARCHAR(50), [KMValue] INTEGER, " +
                    "[timestampA] INT64 NOT NULL, [dbIndexA] VARCHAR(1024) NOT NULL,[timestampB] INT64 ,[dbIndexB] VARCHAR(1024));";
                try {
                    DBIndex = SqliteHelper.GenerateSqlite(DbName.IndexDb.ToString(), IndexDBFullName);
                    //创建站点信息表
                    DBIndex.ExecuteNonQuery(strCreateStationTB);
                    //创建索引表
                    DBIndex.ExecuteNonQuery(strCreateIndexTB);
                } catch {
                    if (DBIndex != null) {
                        DBIndex.CloseDb();
                        DBIndex = null;
                    }
                }
            }
        }

        #region  数据索引和匹配



        /// <summary>
        /// 开启线程 -- 对主图像进行索引-- 将值查询插入即可
        /// 算法修改： 直接从队列中获取主视频文件进行索引，
        /// </summary>
        private void ProcessIndexDB() {
            while (true) {
                Int64 maxMainTime = 0;
                //CREATE TABLE GWVIDEO(time_stamp INT64 primary key,file_time INT64,file_index int,frame_index int,camera_us INT64, frame_no int,info TEXT,jpeg BLOB);
                if (qUnprocessedA.IsEmpty) {
                    if (IsCpyOver) {
                        IsIndDBOver = true;
                        break;
                    }

                    Thread.Sleep(1000);
                    continue;
                }
                //MsgBox.Show("=====索引相机A文件：" );
                //获取数据库
                string fileNameA = "";
                if (qUnprocessedA.TryDequeue(out fileNameA)) {
                    // MsgBox.Show("开始索引相机A文件：" + fileNameA);
                    CurrMainDB = SqliteHelper.GenerateSqlite(DbName.TmpDbA.ToString(), Path.Combine(DestDirA, fileNameA));
                    DataTable dtA = CurrMainDB.ExecuteDataTable("select file_time from GWVIDEO"); //获取主图像数据库的数据。
                    lock (_dbObj) {
                        try {                                                                              //循环遍历添加到主索引库中
                            DBIndex.BeginTransaction();
                            for (int i = 0; i < dtA.Rows.Count; ++i) {
                                Int64 timestamp = Convert.ToInt64(dtA.Rows[i][0]);
                                maxMainTime = System.Math.Max(maxMainTime, timestamp);
                                string insertSQL = $"insert into indexTB(timestamp,timestampA,dbIndexA) values({timestamp},{timestamp},'{fileNameA}')";
                                DBIndex.ExecuteNonQueryByTran(insertSQL);
                                //算法优化 -- 主图像时间戳进队
                                qMainDbID.Enqueue(timestamp);
                            }
                            DBIndex.Commit();
                            //处理完后记录处理后的文件
                            lsProcessedFilesA.Add(fileNameA);
                            CallFunc?.Invoke($"{Cmd.IndexA.ToString()}#{lsProcessedFilesA.Count}");//上报主索引的数据条数
                        } catch (Exception ex) {
                            MsgBox.Show("索引A数据库出错" + ex.ToString());
                            Console.WriteLine(ex.ToString());
                            DBIndex.Rollback();
                        } finally {
                            DBIndex.CloseDb();
                            CurrMainDB.CloseDb();
                        }
                    }
                }
                //索引 相机B文件 ====== 
                try {
                    if (lsDtImgBs.IsEmpty) {
                        continue;
                    }
                    DataTable dtB;
                    lsDtImgBs.TryDequeue(out dtB);
                    //循环遍历查找匹配的数据                                                                    

                    string fileNameB = dtB.ExtendedProperties["fileName"].ToString();
                    if (string.IsNullOrEmpty(fileNameB)) {
                        continue;
                    }
                    //开启事务
                    DBIndex.BeginTransaction();
                    for (int i = 0; i < dtB.Rows.Count; ++i) {
                        Int64 timestampB = Convert.ToInt64(dtB.Rows[i][0]);
                        Int64 matchTimeID = MatchTimeID(timestampB);
                        if (matchTimeID == -1) { //没有找到--很大概率是匹配速度比主图像速度快， 添加到未匹配数据中
                            NoMachImgInfo[timestampB] = fileNameB;
                            CallFunc?.Invoke($"{Cmd.NoMath.ToString()}#{NoMachImgInfo.Count}");//上报未匹配的数据条数
                            continue;
                        }
                        //找到了 更新数据库
                        string update = $"update indexTb set timestampB={timestampB} ,dbIndexB='{fileNameB}' where timestamp={matchTimeID} ";
                        DBIndex.ExecuteNonQueryByTran(update);
                    }
                    // DBIndex.Commit();
                    //处理完后记录处理后的文件
                    lsProcessedFilesB.Add(fileNameB);
                    CallFunc?.Invoke($"{Cmd.MatchB.ToString()}#{lsProcessedFilesB.Count}");//上报次索引的数据条数
                } catch (Exception ex) {
                    MsgBox.Show("索引B数据库出错" + ex.ToString());
                    Console.WriteLine(ex.ToString());
                    //DBIndex.Rollback();
                } finally {
                    DBIndex.CloseDb();
                    CurrSecondDB.CloseDb();
                }
                //算法优化，如果直接打开数据库在进行数据匹配 速度会很慢。思路：既然已经读取了数据 直接放在一个队列里面 进行匹配就好了。
                // new Task(() => IndexSecondDB()).Start();
            }
        }

        /// <summary>
        /// 线程--不断读取B数据库文件内容,添加到文件列表中。
        /// </summary>
        private void ReadImgSecondDB() {
            while (true) {
                if (qUnprocessedB.IsEmpty) {
                    if (IsIndDBOver) {
                        break;
                    }
                    Thread.Sleep(1000);
                    continue;
                }
                string fileNameB = "";
                if (qUnprocessedB.TryDequeue(out fileNameB)) {
                    //获取数据库
                    CurrSecondDB = SqliteHelper.GenerateSqlite(DbName.TmpDbB.ToString(), Path.Combine(DestDirB, fileNameB));
                    DataTable dtB = CurrSecondDB.ExecuteDataTable("select file_time from GWVIDEO"); //获取次图像数据库的数据。
                    dtB.ExtendedProperties.Add("fileName", fileNameB);
                    lsDtImgBs.Enqueue(dtB);
                }
            }
        }

        /// <summary>
        /// 开启线程 -- 对次图像库进行索引-- 比较麻烦，需要查询匹对 再插入
        /// 算法修改 -- 
        /// </summary>
        private void IndexSecondDB() {
            //开始处理 次数据库文件
            while (true) {

                if (qUnprocessedB.IsEmpty) {
                    if (IsIndDBOver) {
                        break;
                    }
                    Thread.Sleep(1000);
                    continue;
                }

                string fileNameB = "";
                if (qUnprocessedB.TryDequeue(out fileNameB)) {
                    //获取数据库
                    CurrSecondDB = SqliteHelper.GenerateSqlite(DbName.TmpDbB.ToString(), Path.Combine(DestDirB, fileNameB));
                    DataTable dtB = CurrSecondDB.ExecuteDataTable("select file_time from GWVIDEO"); //获取次图像数据库的数据。
                    lock (_dbObj) {
                        try {
                            //循环遍历查找匹配的数据                                                                    
                            DBIndex.BeginTransaction();
                            for (int i = 0; i < dtB.Rows.Count; ++i) {
                                Int64 timestampB = Convert.ToInt64(dtB.Rows[i][0]);

                                //查找匹配 --算法优化
                                // string strQuery = $"select timestamp from indexTB where timestamp>{timestampB}  limit 1 ";
                                //DataRow dr = DBIndex.ExecuteDataRow(strQuery, null);
                                //if (dr == null) { //没有找到--添加到未匹配
                                //    NoMachImgInfo[timestampB] = fileNameB;
                                //    CallFunc?.Invoke($"{Cmd.NoMath.ToString()}#{NoMachImgInfo.Count}");//上报未匹配的数据条数
                                //    continue;
                                // }
                                Int64 matchTimeID = MatchTimeID(timestampB);
                                if (matchTimeID == -1) { //没有找到--很大概率是匹配速度比主图像速度快， 添加到未匹配数据中
                                    NoMachImgInfo[timestampB] = fileNameB;
                                    CallFunc?.Invoke($"{Cmd.NoMath.ToString()}#{NoMachImgInfo.Count}");//上报未匹配的数据条数
                                    continue;
                                }
                                //找到了 更新数据库
                                string update = $"update indexTb set timestampB={timestampB} ,dbIndexB='{fileNameB}' where timestamp={matchTimeID} ";
                                DBIndex.ExecuteNonQueryByTran(update);
                            }
                            // DBIndex.Commit();
                            //处理完后记录处理后的文件
                            lsProcessedFilesB.Add(fileNameB);
                            CallFunc?.Invoke($"{Cmd.MatchB.ToString()}#{lsProcessedFilesB.Count}");//上报次索引的数据条数
                        } catch (Exception ex) {
                            MsgBox.Show("索引B数据库出错" + ex.ToString());
                            Console.WriteLine(ex.ToString());
                            //DBIndex.Rollback();
                        } finally {
                            DBIndex.CloseDb();
                            CurrSecondDB.CloseDb();

                        }
                    }

                }
            }
        }

        private Int64 MatchTimeID(Int64 secondImgID) {

            if (qMainDbID.IsEmpty) {
                return -1;
            }
            Int64 mainTimeId = -1;
            while (true) {
                if (qMainDbID.TryDequeue(out mainTimeId)) {
                    if (mainTimeId >= secondImgID) {
                        break;
                    }
                }
            }
            return mainTimeId;
        }
        #endregion

        /// <summary>
        /// 开始数据处理
        /// </summary>
        public void StartProcessDB() {
            if (!currTh.IsAlive) {
                IsStop = false;
                IsCpyOver = false;
                currTh.Start();
            }
        }
        /// <summary>
        /// 停止逻辑 --  所有数据文件均拷贝完毕 才能停止
        /// </summary>
        public void StopProcessDB() {
            IsStop = true;
            bufferSize = 16;
            if (CurrSecondDB != null) {
                CurrSecondDB.CloseDb();
            }

            if (CurrMainDB != null) {
                CurrMainDB.CloseDb();
            }

            if (DBIndex != null) {
                DBIndex.CloseDb();
            }
        }





    }
}
