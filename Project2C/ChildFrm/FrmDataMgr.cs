
using ComClassLib.core;
using ComClassLib.DB;
using ComClassLib.FileOp;
using Project2C.DB;
using Project2C.Dialog;
using Project2C.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2C.ChildFrm {
    public partial class FrmDataMgr : DevComponents.DotNetBar.OfficeForm {
        private bool IsModify { get; set; }
        private string _indexDBFullName;//索引数据库路径
        private string _jhDBFullName;//索引数据库路径
        private SqliteHelper _dbIndex, _dbJH;

        private StationInfo stationInfo;

        public SqliteHelper DBIndex {
            get {
                if (_dbIndex == null) {
                    SetDBIndex();
                }
                //_dbIndex = SqliteHelper.GetSqlite(DbName.IndexDb.ToString());
                return _dbIndex;
            }
        }


        private string IndexDbFullName {
            get { return _indexDBFullName; }
            set {
                _indexDBFullName = value;
                SetDBIndex();
            }
        }



        private void SetDBIndex() {
            if (string.IsNullOrEmpty(_indexDBFullName)) {
                MsgBox.Show("数据库路径不能为空");
                return;
            }
            _dbIndex = SqliteHelper.GenerateSqlite(DataType.DbName.IndexDb.ToString(), _indexDBFullName);
        }

        private string JHDbFullName {
            get { return _jhDBFullName; }
            set {
                _jhDBFullName = value;
                SetJHDB();
            }
        }
        public SqliteHelper DBJH {
            get {
                if (_dbJH == null) {
                    SetJHDB();
                }
                //_dbIndex = SqliteHelper.GetSqlite(DbName.IndexDb.ToString());
                return _dbJH;
            }
        }
        private void SetJHDB() {
            if (string.IsNullOrEmpty(_jhDBFullName)) {
                MsgBox.Show("缺少几何数据库");
                return;
            }
            _dbJH = SqliteHelper.GenerateSqlite(DataType.DbName.JHDB.ToString(), _jhDBFullName);
        }

        public FrmDataMgr() {
            InitializeComponent();
            lblDBPath.Text = "";
            

        }

        public bool isDataSetSuccess { get; private set; }
        #region 任务选择(数据选择)

        private string SelectDBDir() {

            string selDir = FileHelper.OpenDir("请选择离线任务数据所在目录", Settings.Default.lastDbDir);
            if (string.IsNullOrEmpty(selDir))
                return string.Empty;
            //得到索引库文件
            IndexDbFullName = Path.Combine(selDir, "IndexDb.db");
            string tmpStr = Path.GetFileName(selDir);
            JHDbFullName = Path.Combine(selDir, $"{tmpStr}_几何.db");
            if (File.Exists(IndexDbFullName)) {
                try {
                    SetDBIndex();
                    //读取索引数据内容
                    DataRow dr = DBIndex.ExecuteDataRow("select count(timestamp) from indexTB", null);
                    if (dr == null || Convert.ToInt32(dr[0]) == 0) {
                        MsgBox.Error("索引数据缺失，请对任务数据进行索引!");
                        superTabControl1.SelectedTabIndex = 1;


                    }
                } catch (Exception ex) {
                    Console.WriteLine("索引库打开失败" + ex.ToString());
                    MsgBox.Error("索引库打开失败，请检查文件是否存在或被损坏!");
                    IndexDbFullName = string.Empty;
                }
            } else {
                MsgBox.Error("索引库不存在，离线数据库打开失败！");
                IndexDbFullName = string.Empty;
            }
            return IndexDbFullName;

        }
        private StationInfo QueryStationInfo() {
            // SqliteHelper indexDB = SqliteHelper.GetSqlite(DbName.IndexDb.ToString());
            StationInfo stationInfo = null;
            if (DBIndex != null) {
                try {
                    DataRow dr = DBIndex.ExecuteDataRow("select * from stationInfo", null);
                    stationInfo = new StationInfo(dr["sLineName"].ToString(), dr["sStartStation"].ToString(), dr["sEndStation"].ToString(), Convert.ToInt16(dr["iType"]), Convert.ToDateTime(dr["taskDate"]));
                    stationInfo.SId = Convert.ToInt32(dr["sId"]);
                } catch {
                    DBIndex.ExecuteDataRow("delete from stationInfo", null);
                    Console.WriteLine("线路信息读取错误！");
                }
            }
            return stationInfo;
        }

        private void btnOpenDir_Click(object sender, EventArgs e) {
            string indexDBFullName = SelectDBDir();
            if (string.IsNullOrEmpty(indexDBFullName))
                return;
            try {
                if (!string.IsNullOrEmpty(indexDBFullName)) {

                    //检查并创建缺陷表
                    DataM.CreateFaultTb(DBIndex);
                    //设置显示
                    string selDir = Path.GetDirectoryName(indexDBFullName);
                    lblDBPath.Text = selDir;
                    Settings.Default.lastDbDir = selDir;//获取目录路径
                    Settings.Default.Save();
                    stationInfo = QueryStationInfo();
                    //数据选择成功
                    isDataSetSuccess = true;

                    if (stationInfo == null) {
                        MsgBox.Show("线路信息缺失，请手动添加！");
                        tbStationName.Focus();
                        tbStationName.Text = "";
                        return;
                    }
                    tbStationName.Text = stationInfo.LineName;
                    dateTimeInput.Value = Convert.ToDateTime(stationInfo.TaskDate);
                    cbBoxUpDown.SelectedIndex = (stationInfo.SType == "上行") ? 0 : 1;
                    tbStartStation.Text = stationInfo.StartStation;
                    tbEndStation.Text = stationInfo.EndStation;
                    //刷新线路基础数据
                    UpdateBaseData();
                    //根据情况填写信息
                    if (String.IsNullOrEmpty(tbStationName.Text.Trim())) {
                        MsgBox.Show("缺少线路信息，请手动输入");
                        tbStationName.Focus();
                    }

                }
            } catch (Exception) {
                isDataSetSuccess = false;
                MessageBox.Show("数据库读取失败！\n");
            }
        }
        //刷新线路基础数据
        private void UpdateBaseData() {
            cbHasBaseData.Checked = DBIndex.IsFieldExist("BaseData", "id");
        }

        private void btnTaskOk_Click(object sender, EventArgs e) {
            if (!isDataSetSuccess) {

                MessageBox.Show(this, "请检查数据任务！", "任务选择错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(tbStationName.Text.Trim())) {
                MsgBox.Show("缺少线路信息，请手动输入");
                tbStationName.Focus();
                return;
            }
            if (!cbHasBaseData.Checked) {
                MsgBox.Show("缺少线路基础数据，请导入");
                btnLoadBaseData.Focus();
                return;
            }
            stationInfo = QueryStationInfo();
            bool isOk = true;
            if (stationInfo == null) {
                //插入数据
                stationInfo = new StationInfo(tbStationName.Text, tbStartStation.Text,tbEndStation.Text,(short)cbBoxUpDown.SelectedIndex,dateTimeInput.Value);
                //stationInfo.LineName = tbStationName.Text;
                //stationInfo.StartStation = tbStartStation.Text;
                //stationInfo.EndStation = tbEndStation.Text;
                //stationInfo.TaskDate = dateTimeInput.Value;
                //stationInfo.IType = cbBoxUpDown.SelectedIndex;
                isOk = UpdateTaskInfo(true);

            } else if (stationInfo.LineName != tbStationName.Text || stationInfo.TaskDate != dateTimeInput.Value
                || stationInfo.SType != cbBoxUpDown.Text || stationInfo.StartStation != tbStartStation.Text.Trim() || stationInfo.EndStation != tbEndStation.Text.Trim()) {
                if (MsgBox.YesNo("任务信息已经修改，确认修改？") == DialogResult.Yes) {
                    stationInfo.LineName = tbStationName.Text;
                    stationInfo.StartStation = tbStartStation.Text;
                    stationInfo.EndStation = tbEndStation.Text;
                    stationInfo.TaskDate = dateTimeInput.Value;
                    stationInfo.IType = cbBoxUpDown.SelectedIndex;
                    isOk = UpdateTaskInfo(false);
                }
            }
            if (isOk) {
                config.ConfigInfo.GetInstance().TaskInfo = stationInfo;
                FrmMain.GetInstance().DataSetSuccess();
            } else {
                MsgBox.Error("线路信息写入有错！");
            }

        }
        /// <summary>
        /// 登录成功 -- 更新任务信息
        /// </summary>
        /// <param name="isNew"></param>
        /// <returns></returns>
        public bool UpdateTaskInfo(bool isNew) {
            if (DBIndex == null) {
                return false;
            }

            //int iType = (SType == "站") ? 0 : 1;
            //int iUpDown = (UpDown == "上行") ? 0 : 2;
            //iType |= iUpDown;
            //stationInfo(sId INTEGER PRIMARY KEY AUTOINCREMENT,sLineName varchar(255),[sStartStation] VARCHAR(255),sEndStation VARCHAR(255),sType tinyint,taskDate DATE);


            string sqlStr = "";
            if (isNew) {
                sqlStr = "insert into stationInfo (sLineName,iType,taskDate,sStartStation,sEndStation,) values (?,?,?,?,?)";
                SQLiteParameter[] parameters = { new SQLiteParameter(DbType.String), new SQLiteParameter(DbType.Int32), new SQLiteParameter(DbType.Date), new SQLiteParameter(DbType.String), new SQLiteParameter(DbType.String) };
                parameters[0].Value = stationInfo.LineName;
                parameters[1].Value = stationInfo.IType;
                parameters[2].Value = stationInfo.TaskDate.ToString("s");
                parameters[3].Value = stationInfo.StartStation;
                parameters[4].Value = stationInfo.EndStation;
                DBIndex.ExecuteNonQuery(sqlStr, parameters);
            } else {
                sqlStr = "update stationInfo set sLineName=?,iType=?,taskDate=?,sStartStation=?,sEndStation=? where sId=?";
                SQLiteParameter[] parameters = { new SQLiteParameter(DbType.String), new SQLiteParameter(DbType.Int32),
                    new SQLiteParameter(DbType.Date),new SQLiteParameter(DbType.String),new SQLiteParameter(DbType.String), new SQLiteParameter(DbType.Int32) };
                parameters[0].Value = stationInfo.LineName;
                parameters[1].Value = stationInfo.IType;
                parameters[2].Value = stationInfo.TaskDate.ToString("s");

                parameters[3].Value = stationInfo.StartStation;
                parameters[4].Value = stationInfo.EndStation;
                parameters[5].Value = stationInfo.SId;
                DBIndex.ExecuteNonQuery(sqlStr, parameters);
            }

            return true;
        }
        #endregion

        private void lblDBPath_Click(object sender, EventArgs e) {

        }

        private void lblStationName_TextChanged(object sender, EventArgs e) {

        }

        private void dateTimeInput_ValueChanged(object sender, EventArgs e) {

        }

        private void cbBoxUpDown_TextChanged(object sender, EventArgs e) {

        }
        #region 数据索引
        List<DataTable> _lstAllDbA, _lstAllDbB;
        Queue<Int64> _qMainDbID;
        /// <summary>
        /// 选择数据目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelIndexTaskDir_Click(object sender, EventArgs e) {
            string selDir = FileHelper.OpenDir("请选择离线任务数据所在目录", Settings.Default.lastDbDir);
            if (String.IsNullOrEmpty(selDir)) {
                return;
            }
            LoadDataInfo(selDir);


        }


        private void LoadDataInfo(string selDir) {
            //得到索引库文件
            IndexDbFullName = Path.Combine(selDir, "IndexDb.db");
            lblIndexTaskDir.Text = selDir;
            if (!File.Exists(_indexDBFullName)) {
                MsgBox.Warning("该目录下没有索引文件！检查是否目录选择正确", "任务数据选择确认");
                return;
            }

            string DestSrcDbA = Path.Combine(selDir, "V1");
            string DestSrcDbB = Path.Combine(selDir, "V2");
            List<FileInfo> lstDbA = new List<FileInfo>();
            List<FileInfo> lstDbB = new List<FileInfo>();
            FileHelper.GetFiles(DestSrcDbA, ".db", ref lstDbA);
            FileHelper.GetFiles(DestSrcDbB, ".db", ref lstDbB);
            lstDbA = filterFiles(lstDbA, "sm");
            lstDbB = filterFiles(lstDbB, "sm");
            lblDbFilesNumA.Text = lstDbA.Count.ToString() + "个";
            lblDbFilesNumB.Text = lstDbB.Count.ToString() + "个";
            //读取索引数据

            DataRow drA = DBIndex.ExecuteDataRow("select count(timestampA) from indexTB ", null);
            lblIndexImgNumA.Text = (drA == null) ? "0" : drA[0].ToString();
            DataRow drB = DBIndex.ExecuteDataRow("select count(timestampB) from indexTB ", null);
            lblIndexImgNumB.Text = (drB == null) ? "0" : drB[0].ToString();
            int outA, outB;
            _lstAllDbA = GetAllImgs(lstDbA, out outA);
            lblIndexImgNumA.Text += $"/{outA.ToString()}";
            _lstAllDbB = GetAllImgs(lstDbB, out outB);
            lblIndexImgNumB.Text += $"/{outB.ToString()}";
        }

        /// <summary>
        /// 过滤不需要的文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private List<FileInfo> filterFiles(List<FileInfo> files, string filter) {
            List<FileInfo> lstFiles = new List<FileInfo>();
            foreach (FileInfo file in files) {
                if (file.Name.Contains(filter)) {
                    continue;
                }
                lstFiles.Add(file);
            }
            return lstFiles;
        }
        //得到所有的图像数据
        private List<DataTable> GetAllImgs(List<FileInfo> files, out int totalNum) {
            totalNum = 0;
            List<DataTable> lstDt = new List<DataTable>();
            for (int i = 0; i < files.Count; i++) {
                FileInfo file = files[i];
                SqliteHelper selDB = SqliteHelper.GenerateSqlite(DataType.DbName.TmpDbA.ToString(), file.FullName);
                DataTable dt = selDB.ExecuteDataTable("select file_time from GWVIDEO ");
                dt.ExtendedProperties.Add("fileName", file.Name);
                lstDt.Add(dt);
                totalNum += dt.Rows.Count;
            }
            return lstDt;
        }

        private void lblIndexTaskDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            FileHelper.OpenLocalDir(lblIndexTaskDir.Text);
        }
        private void UpdateProcessA(int num, int totalNum) {
            if (progressBarX1.InvokeRequired) {
                Action<int, int> a = UpdateProcessA;
                progressBarX1.Invoke(a, num, totalNum);
            } else {
                int precenpt = (num * 100) / totalNum;
                progressBarX1.Value = precenpt;
                progressBarX1.Text = precenpt.ToString() + "%";
                lblProcessA.Text = $"{ num}/{totalNum}";
            }
        }
        private void UpdateProcessB(int num, int totalNum) {
            if (progressBarX2.InvokeRequired) {
                Action<int, int> a = UpdateProcessB;
                progressBarX2.Invoke(a, num, totalNum);
            } else {
                int precenpt = (num * 100) / totalNum;
                progressBarX2.Value = precenpt;
                progressBarX2.Text = precenpt.ToString() + "%";
                lblProcessB.Text = $"{ num}/{totalNum}";
            }
        }

        /// <summary>
        /// 线程
        /// </summary>
        /// <param name="_lstAllDbA"></param>
        private void IndexMainDB() {

            //清除所有数据 
            DBIndex.ExecuteNonQuery("delete  from indexTB", null);
            for (int i = 0; i < _lstAllDbA.Count; i++) {
                DataTable dtA = _lstAllDbA[i];
                try {
                    //循环遍历添加到主索引库中
                    DBIndex.BeginTransaction();
                    for (int j = 0; j < dtA.Rows.Count; ++j) {
                        Int64 timestamp = Convert.ToInt64(dtA.Rows[j][0]);
                        string fileNameA = dtA.ExtendedProperties["fileName"].ToString();
                        string insertSQL = $"insert into indexTB(timestamp,timestampA,dbIndexA) values({timestamp},{timestamp},'{fileNameA}')";
                        DBIndex.ExecuteNonQueryByTran(insertSQL, null);
                        //算法优化 -- 主图像时间戳进队
                        _qMainDbID.Enqueue(timestamp);
                    }
                    DBIndex.Commit();
                    UpdateProcessA(i + 1, _lstAllDbA.Count);
                    //处理完后记录处理后的文件
                    // CallFunc?.Invoke($"{Cmd.IndexA.ToString()}#{lsProcessedFilesA.Count}");//上报主索引的数据条数
                } catch (Exception ex) {
                    MsgBox.Show("索引A数据库出错" + ex.ToString());
                    Console.WriteLine(ex.ToString());
                    DBIndex.Rollback();
                } finally {
                    DBIndex.CloseDb();
                }
            }
            IndexSecondDB();
        }
        private Int64 MatchTimeID(Int64 secondImgID) {
            if (_qMainDbID.Count == 0) {
                return -1;
            }
            Int64 mainTimeId = -1;
            while (true) {
                mainTimeId = _qMainDbID.Dequeue();
                if (mainTimeId >= secondImgID) {
                    break;
                }

            }
            return mainTimeId;
        }
        #region 基础线路数据加载
        private void btnLoadBaseData_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(lblDBPath.Text)) {
                MsgBox.Warning("请先选择检测数据！","警告");
                return;
            }
            if (cbHasBaseData.Checked) {
                if (MsgBox.YesNo("已经有线路信息，确认重新载入？") == DialogResult.No) {
                    return;
                }
            }           
            if (LoadBaseData()) {
                MsgBox.Show(@"线路基础数据信息导入成功！");
                //刷新线路基础数据
                UpdateBaseData();
            } else {
                MsgBox.Warning("线路基础数据信息导入失败！\n请检查文件格式是否正确!","提示");
            }
        }
        private bool LoadBaseData() {
            bool res = false;
            string fileFilter = "csv files (*.csv)|*.csv";//过滤选项设置，文本文件，所有文件。
            string title = "选择导入的线路基础数据文件";
            FileHelper._InitialDirectory = Settings.Default.loadDatabasePath;
            string selFileName = FileHelper.OpenFile(title, fileFilter);     
            if (!string.IsNullOrEmpty(selFileName)) {

                Settings.Default.loadDatabasePath = Path.GetDirectoryName(selFileName);
                Settings.Default.Save();
                //判断基础数据表是否存在，存在-清除数据；不存在创建表
                if (DBIndex.IsFieldExist("BaseData", "id")) {
                    DBIndex.ExecuteNonQuery("delete from BaseData", null);
                } else {
                    DataM.CreateBaseData(DBIndex);
                }
                CsvHelper csv = new CsvHelper(selFileName);
                DataTable dt = csv.csvDT;
                string sSQL = "";
                if (dt != null) {
                    try {
                        DBIndex.OpenDb();
                        //循环遍历添加到主索引库中
                        DBIndex.BeginTransaction();
                        int i = 0;
                        foreach (DataRow dataRow in dt.Rows) {
                            if (dataRow[0] == null || string.IsNullOrEmpty(dataRow[0].ToString())) {
                                continue;
                            }
                            sSQL = $"insert into BaseData values({dataRow[0]},'{dataRow[1]}','{dataRow[2]}','{dataRow[3]}',null)";

                            DBIndex.ExecuteNonQueryByTran(sSQL, null);
                        }
                        DBIndex.Commit();
                        //处理完后记录处理后的文件
                        UpdateProcessB(i + 1, dt.Rows.Count);
                        res = true;
                    } catch (Exception ex) {
                        MsgBox.Show("载入线路基础数据出错" + ex.ToString());
                        Console.WriteLine(ex.ToString());
                        DBIndex.Rollback();
                    } finally {
                        DBIndex.CloseDb();
                    }
                }

            }
            return res;
        }

        #endregion
        private void lblDBPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            FileHelper.OpenLocalDir(lblDBPath.Text.Trim());
        }

        private void IndexSecondDB() {
            //索引 相机B文件 ====== 
            for (int i = 0; i < _lstAllDbB.Count; i++) {
                try {
                    DataTable dtB = _lstAllDbB[i];
                    //循环遍历查找匹配的数据     
                    string fileNameB = dtB.ExtendedProperties["fileName"].ToString();
                    if (string.IsNullOrEmpty(fileNameB)) {
                        continue;
                    }
                    //开启事务
                    DBIndex.BeginTransaction();
                    for (int j = 0; j < dtB.Rows.Count; ++j) {
                        Int64 timestampB = Convert.ToInt64(dtB.Rows[j][0]);
                        Int64 matchTimeID = MatchTimeID(timestampB);
                        if (matchTimeID == -1) { //没有找到--很大概率是匹配速度比主图像速度快， 添加到未匹配数据中                              
                                                 // CallFunc?.Invoke($"{Cmd.NoMath.ToString()}#{NoMachImgInfo.Count}");//上报未匹配的数据条数
                            continue;
                        }
                        //找到了 更新数据库
                        string update = $"update indexTb set timestampB={timestampB} ,dbIndexB='{fileNameB}' where timestamp={matchTimeID} ";
                        DBIndex.ExecuteNonQueryByTran(update);
                    }
                    DBIndex.Commit();
                    //处理完后记录处理后的文件
                    UpdateProcessB(i + 1, _lstAllDbB.Count);
                } catch (Exception ex) {
                    MsgBox.Show("索引B数据库出错" + ex.ToString());
                    Console.WriteLine(ex.ToString());
                    //DBIndex.Rollback();
                } finally {
                    DBIndex.CloseDb();
                }
            }
        }

        #endregion

        private void btnProcessDb_Click(object sender, EventArgs e) {
            _qMainDbID = new Queue<long>();
            Task taskIndexDBA = new Task(() => IndexMainDB());
            taskIndexDBA.Start();
        }
    }
}
