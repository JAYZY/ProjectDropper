using ComClassLib.core;
using ComClassLib.FileOp;
using System.Data;

namespace Project2C.config {

    /// <summary>
    /// 全局配置文件
    /// </summary>
    class ConfigInfo {
        #region 创建单实例对象

        private static ConfigInfo _config;
        private static readonly object _obj = new object();
        public static ConfigInfo GetInstance() {
            if (_config == null) {
                lock (_obj) {
                    if (_config == null)
                        _config = new ConfigInfo();
                }
            }
            return _config;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        private ConfigInfo() {

        }
        #endregion

        public int defaultMarkW = 300;
        public int defaultMarkH = 300;
        private DataSet ds = null;
        public DataSet GetConfigInfo() {
            if (ds == null) {
                ds = FileHelper.XmlToDataSet("config/BaseData.xml");
            }
            return ds;
        }
        /// <summary>
        /// 全局任务信息
        /// </summary>
       public StationInfo TaskInfo { get; set; }

    }
}
