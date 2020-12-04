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
    }
}
