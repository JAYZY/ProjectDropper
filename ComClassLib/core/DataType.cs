using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComClassLib.core
{
    public class DataType
    {
        /// <summary>
        /// 任务命令
        /// </summary>
        public enum NetTaskCmd
        {
            Disconn,
            Conn,
            Reconn,
            TaskStart,
            TaskEnd

        }
        public enum DbName {
            LoginDb,    //登录数据库
            IndexDb,    //索引数据库
            JHDB,
            CurrDb,     //当前分库图像数据库
            TmpDbA,     //临时数据库A
            TmpDbB      //临时数据库A
        }
    }
}
