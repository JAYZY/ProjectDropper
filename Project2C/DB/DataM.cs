using ComClassLib.DB;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2C.DB {
    /// <summary>
    /// 数据管理
    /// </summary>
    class DataM {
        /// <summary>
        /// 创建缺陷表
        /// </summary>
        public static void CreateFaultTb(SqliteHelper db) {
            try {
                db.OpenDb();
                if (db.IsFieldExist("FaultRecode", "ImgB")) {
                    return;
                }
                db.ExecuteNonQuery("drop table if exists FaultRecode");
                string sSQL = " create TABLE FaultRecode(rid INTEGER primary key AUTOINCREMENT," +
                    "pid INT64,uid INTEGER,fid INTEGER,fLevel char(10),analyzeDate DATETIME,comfirmDate DATETIME," +
                    "OffsetX INTEGER NOT NULL,OffsetY INTEGER NOT NULL,width INTEGER NOT NULL,height INTEGER NOT NULL,memo text," +
                    " faultCamId INTEGER,ImgA BLOB,ImgB BLOB);";
                db.ExecuteNonQuery(sSQL,null);             
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                db.CloseDb();
            }
        }
        /// <summary>
        /// 创建基础信息表
        /// </summary>
        public static void CreateBaseData(SqliteHelper db) {
            try {

                db.OpenDb(); 
                db.ExecuteNonQuery("drop table if exists BaseData");
                string sSQL = "  CREATE TABLE BaseData(id INTEGER PRIMARY KEY," +
                    "stationRegion  VARCHAR(255),tunnelName VARCHAR(255), poleName VARCHAR(255),ImgId INT64);";
                db.ExecuteNonQuery(sSQL);

            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                db.CloseDb();
            }
        }

    }
}
