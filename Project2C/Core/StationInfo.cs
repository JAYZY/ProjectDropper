using ComClassLib.DB;
using Project2C.DB;
using System;
using System.Data;
using System.Data.SQLite;

namespace Project2C.Core {
    class StationInfo {

        private int sId;
        private string sName;
        private string sType;
        private string taskDate;
        public string UpDown { get; set; }
        #region 创建单实例对象
        private static StationInfo _stationInfo;
        private static readonly object _obj = new object();
        public static StationInfo GetInstance(bool ReGet = false) {
            if (ReGet) { Destory(); }
            if (_stationInfo == null) {
                lock (_obj) {
                    if (_stationInfo == null)
                        _stationInfo = new StationInfo();
                }
            }
            return _stationInfo;
        }
        public static void Destory() {
            if (_stationInfo != null) {
                _stationInfo = null;
                GC.Collect();
            }
        }
        private static SqliteHelper imgSqlite = null;
        private StationInfo() {
            sId = -1;
            string sqlStr = "select * from stationInfo";
            imgSqlite = SqliteHelper.GetSqlite("imgDb");
            if (imgSqlite == null) return;
            DataRow dr = imgSqlite.ExecuteDataRow(sqlStr, null);
            if (dr == null) return;
            sId = Int32.Parse(dr[0].ToString());
            sName = dr[1].ToString();
            int iType = Convert.ToInt32(dr[2].ToString());

            SType = ((iType & 1) == 1) ? "站区间" : "站";
            UpDown = ((iType & 2) == 2) ? "下行" : "上行";
            taskDate = dr[3].ToString();
        }
        #endregion

        public StationInfo(int sId, string sName, string sType, string taskDate) {
            this.sId = sId;
            this.SName = sName;
            this.SType = sType;
            this.taskDate = taskDate;
        }
        //检测时间
        public string TaskDate { get => taskDate; set => taskDate = value; }
        //站区类型 0-站 1-站区间
        public string SType { get => sType; set => sType = value; }
        //站区名称
        public string SName { get => sName; set => sName = value; }
        //站区编号
        public int SId { get => sId; set => sId = value; }

        private static StationInfo QueryFromDb() {
            string sqlStr = "select * from stationInfo";
            if (imgSqlite == null) return null;
            DataRow dr = imgSqlite.ExecuteDataRow(sqlStr, null);
            StationInfo stationInfo = new StationInfo(Int32.Parse(dr[0].ToString()), dr[1].ToString(), (dr[2].ToString() == "0") ? "站" : "站区间", dr[3].ToString());

            return stationInfo;
        }
        public bool UpdateTaskInfo(bool isNew) {
            if (imgSqlite == null) return false;

            int iType = (SType == "站") ? 0 : 1;
            int iUpDown = (UpDown == "上行") ? 0 : 2;
            iType |= iUpDown;

            string sqlStr = "";
            if (isNew) {
                sqlStr = "insert into stationInfo (sName,sType,taskDate) values (?,?,?)";
                SQLiteParameter[] parameters = { new SQLiteParameter(DbType.String), new SQLiteParameter(DbType.Int32), new SQLiteParameter(DbType.Date) };
                parameters[0].Value = SName;
                parameters[1].Value = iType;
                parameters[2].Value =DateTime.Parse(TaskDate) ;
                imgSqlite.ExecuteNonQuery(sqlStr, parameters);
            }
            else {
                sqlStr = "update stationInfo set sName=?,sType=?,taskDate=? where sId=?";
                SQLiteParameter[] parameters = { new SQLiteParameter(DbType.String), new SQLiteParameter(DbType.Int32), new SQLiteParameter(DbType.Date), new SQLiteParameter(DbType.Int32) };
                parameters[0].Value = SName;
                parameters[1].Value = iType;
                parameters[2].Value = DateTime.Parse(TaskDate);
                parameters[3].Value = sId;
                imgSqlite.ExecuteNonQuery(sqlStr, parameters);
            }
            return true;
        }
    }
}
