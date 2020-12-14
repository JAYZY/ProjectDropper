using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace Project2C.DB {
    class SqliteHelper {



        private static Dictionary<string, SqliteHelper> mapSqlite = new Dictionary<string, SqliteHelper>();
        public static SqliteHelper GenerateSqlite(string strName, string dbPath) {
            //if (!mapSqlite.ContainsKey(strName))
            mapSqlite[strName] = new SqliteHelper(dbPath);
            return mapSqlite[strName];
        }
        public static SqliteHelper GetSqlite(string strName) {
            if (!mapSqlite.ContainsKey(strName)) {
                return null;
            }

            return mapSqlite[strName];
        }
        public SqliteHelper(string dbPath) {
            DbPath = dbPath;
        }

        private SQLiteConnection cn = null;
        private SQLiteCommand cmd = null;
        public string DbPath = @"C:\\test\\Release\\Data\\PicInfoDb.db";
        private readonly object objLock = new object();

        /// <summary>
        /// 准备操作命令参数
        /// </summary>
        /// <param name="cmd">SQLiteCommand</param>
        /// <param name="conn">SQLiteConnection</param>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, Dictionary<String, String> data) {
            OpenDb();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (data != null && data.Count >= 1) {
                foreach (KeyValuePair<String, String> val in data) {
                    cmd.Parameters.AddWithValue(val.Key, val.Value);
                }
            }
        }
        //---创建数据库
        public void CreateDB(string dbFullName) {
            DbPath = dbFullName;
            cn = new SQLiteConnection("data source=" + dbFullName);
            cn.Open();
            CreateTable();
            cn.Close();
        }
        //---添加表
        public void CreateTable() {
            OpenDb();
            cmd = new SQLiteCommand();
            cmd.Connection = cn;
            cmd.CommandText = "drop table if exists picInfo";
            cmd.ExecuteNonQuery(); //--PRIMARY KEY
            cmd.CommandText = "CREATE TABLE picInfo(id INTEGER PRIMARY KEY AUTOINCREMENT,shootTime INTEGER,poleNum INTEGER,KMValue INTEGER ,areaType INTEGER,imgContent BLOG)";
            cmd.ExecuteNonQuery();
            CloseDb();
        }
        /// <summary>
        /// 创建缺陷表
        /// </summary>
        public void CreateFaultTb() {
            try {
                OpenDb();
                if (IsFieldExist("FaultRecode", "ImgB")) {
                    return;
                }

                using (SQLiteCommand command = new SQLiteCommand(cn)) {
                    command.CommandText = "drop table if exists FaultRecode";
                    command.ExecuteNonQuery();
                    command.CommandText = " create TABLE FaultRecode(rid INTEGER primary key AUTOINCREMENT,pid INTEGER,uid INTEGER,fid INTEGER,fLevel char(10),analyzeDate DATETIME,comfirmDate DATETIME,OffsetX INTEGER NOT NULL,OffsetY INTEGER NOT NULL,width INTEGER NOT NULL,height INTEGER NOT NULL,memo text, faultCamId INTEGER,ImgA BLOB,ImgB BLOB);";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally {
                CloseDb();
            }
        }

        public void OpenDb() {

            if (cn == null) {
                cn = new SQLiteConnection("data source=" + DbPath);
            }
            else if (cn.State == System.Data.ConnectionState.Open) {
                return;
            }
            cn.Open();

        }
        public void CloseDb() {
            if (cn == null || cn.State == System.Data.ConnectionState.Closed) {
                return;
            }

            if (cmd != null) {
                cmd.Dispose();
                cmd = null;
            }
            cn.Close();
            cn = null;

        }

        public int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters) {
            int affectedRows = 0;
            OpenDb();
            using (DbTransaction transaction = cn.BeginTransaction()) {
                using (SQLiteCommand command = new SQLiteCommand(cn)) {
                    command.CommandText = sql;
                    if (parameters != null) {
                        command.Parameters.AddRange(parameters);
                    }
                    command.Prepare();
                    affectedRows = command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            return affectedRows;
        }

        public object ExecuteScalar(string cmdText, params SQLiteParameter[] parameters) {
            OpenDb();
            object rtn = null;
            using (DbTransaction transaction = cn.BeginTransaction()) {
                using (SQLiteCommand command = new SQLiteCommand(cn)) {
                    command.CommandText = cmdText;
                    if (parameters != null) {
                        command.Parameters.AddRange(parameters);
                    }
                    command.Prepare();
                    rtn = command.ExecuteScalar();
                }
                transaction.Commit();
            }
            return rtn;

        }


        #region Trans(事务处理)
        public void BeginTransaction() {
            cmd.CommandText = "begin transaction;";
            cmd.ExecuteNonQuery();
        }

        public void Commit() {
            cmd.CommandText = "commit;";
            cmd.ExecuteNonQuery();
        }

        public void Rollback() {
            cmd.CommandText = "rollback";
            cmd.ExecuteNonQuery();
        }
        public void Execute(string sql) {
            Execute(sql, new List<SQLiteParameter>());
        }

        public void Execute(string sql, Dictionary<string, object> dicParameters = null) {
            List<SQLiteParameter> lst = GetParametersList(dicParameters);
            Execute(sql, lst);
        }

        public void Execute(string sql, IEnumerable<SQLiteParameter> parameters = null) {
            cmd.CommandText = sql;
            if (parameters != null) {
                foreach (var param in parameters) {
                    cmd.Parameters.Add(param);
                }
            }
            cmd.ExecuteNonQuery();
        }

        private List<SQLiteParameter> GetParametersList(Dictionary<string, object> dicParameters) {
            List<SQLiteParameter> lst = new List<SQLiteParameter>();
            if (dicParameters != null) {
                foreach (KeyValuePair<string, object> kv in dicParameters) {
                    lst.Add(new SQLiteParameter(kv.Key, kv.Value));
                }
            }
            return lst;
        }


        #endregion

        #region Select(查询相关)

        private bool IsTableExist(String tableName) {
            try {
                using (SQLiteCommand command = new SQLiteCommand(cn)) {
                    command.CommandText = "select sql from sqlite_master where type = 'table' and name = '{0}'";
                    var rtn = command.ExecuteScalar();
                    if (rtn == null || String.IsNullOrEmpty(rtn.ToString())) {
                        return false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(tableName + " 表存在检查失败！\n" + ex.ToString()); }
            return true;
        }
        /// <summary>
        /// 判定表中字段是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        private bool IsFieldExist(String tableName, String fieldName) {
            string tableCreateSql = "";
            try {
                using (SQLiteCommand command = new SQLiteCommand(cn)) {
                    command.CommandText = String.Format("select sql from sqlite_master where type = 'table' and name = '{0}'", tableName);
                    var rtn = command.ExecuteScalar();
                    if (rtn != null) {
                        tableCreateSql = rtn.ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(fieldName + " 字段检查失败\n" + ex.ToString()); }

            if (!string.IsNullOrEmpty(tableCreateSql) && tableCreateSql.Contains(fieldName)) {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 查询，返回DataSet
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataset(string cmdText, Dictionary<string, string> data) {
            OpenDb();
            var ds = new DataSet();
            cmd = new SQLiteCommand();
            PrepareCommand(cmd, cn, cmdText, data);
            var da = new SQLiteDataAdapter(cmd);
            da.Fill(ds);
            CloseDb();
            return ds;
        }
        /// <summary>
        /// 查询，返回DataTable
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string cmdText, Dictionary<string, string> data) {
            lock (objLock) {
                OpenDb();
                var dt = new DataTable();
                using (SQLiteCommand cmd = new SQLiteCommand()) {
                    try {
                        PrepareCommand(cmd, cn, cmdText, data);
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows) {
                            dt.Load(reader);
                        }
                    }
                    finally {
                        CloseDb();
                    }
                }
                return dt;
            }
        }
        /// <summary>
        /// 返回一行数据
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">参数数组</param>
        /// <returns>DataRow</returns>
        public DataRow ExecuteDataRow(string cmdText, Dictionary<string, string> data) {
            DataSet ds = ExecuteDataset(cmdText, data);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                return ds.Tables[0].Rows[0];
            }

            return null;
        }
        /// <summary>
        /// 返回SqlDataReader对象
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">传入的参数</param>
        /// <returns>SQLiteDataReader</returns>
        public SQLiteDataReader ExecuteReader(string cmdText, Dictionary<string, string> data) {
            var command = new SQLiteCommand();
            OpenDb();
            try {
                PrepareCommand(command, cn, cmdText, data);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch {
                cn.Close();
                command.Dispose();
                throw;
            }
        }
        /// <summary>
        /// 返回结果集中的第一行第一列，忽略其他行或列
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="data">传入的参数</param>
        /// <returns>object</returns>
        public object ExecuteScalar(string cmdText, Dictionary<string, string> data) {
            OpenDb();
            var cmd = new SQLiteCommand();
            PrepareCommand(cmd, cn, cmdText, data);
            return cmd.ExecuteScalar();

        }


        #endregion




        public int insertByParam(string sName, byte[] byData) {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            SQLiteParameter[] sp = new SQLiteParameter[2];
            sql.Clear();
            sql.Append("INSERT INTO Info (Name,Code) VALUES(@Name,@Code) \r\n");
            sp[0] = new SQLiteParameter("@p1", sName);
            sp[1] = new SQLiteParameter("@p2", byData);
            ExecuteNonQuery(sql.ToString(), sp, CommandType.Text);

            return result;
        }

        public void execSql(string strSql) {
            if (cn == null) {

                cn = new SQLiteConnection("data source=" + DbPath);
            }
            if (cn.State != System.Data.ConnectionState.Open) {
                cn.Open();
            }
            if (cmd == null) {
                cmd = new SQLiteCommand();
                cmd.Connection = cn;
            }
            cmd.CommandText = strSql;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public byte[] query(string sName) {
            if (cn == null) {

                cn = new SQLiteConnection("data source=" + DbPath);
            }

            if (cn.State != System.Data.ConnectionState.Open) {
                cn.Open();
            }

            if (cmd == null) {
                cmd = new SQLiteCommand();
                cmd.Connection = cn;
            }

            cmd.CommandText = "select img from imgTb  where (imgname=@fname)";
            cmd.Parameters.Add("fname", DbType.String).Value = sName;

            SQLiteDataReader sr = cmd.ExecuteReader();
            sr.Read();
            byte[] byData = (byte[])sr[0];
            cmd.Dispose();
            cmd = null;

            return byData;
        }
        public int ExecuteNonQuery(string commandText, SQLiteParameter[] sp, CommandType commandType) {
            int result = 0;
            if (commandText == null || commandText.Length == 0) {
                throw new ArgumentNullException("sql语句为空");
            }

            if (cn == null) {

                cn = new SQLiteConnection("data source=" + DbPath);
            }
            if (cn.State != System.Data.ConnectionState.Open) {
                cn.Open();
            }
            if (cmd == null) {
                cmd = new SQLiteCommand();
                cmd.Connection = cn;
            }
            cmd.CommandText = commandText;
            cmd.Parameters.AddRange(sp);
            cmd.Prepare();//开启预处理

            //cmd.Parameters.Add("img", DbType.Binary).Value = byData;
            try {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                throw ex;
            }
            return result;
        }

    }

}
