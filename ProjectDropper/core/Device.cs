using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDropper.core {
    public enum DevClass {
        SupportDev=1,//支撑装置
        dropper=2//接触吊弦
    }

    /// <summary>
    /// 设备类
    /// </summary>
    public class Device {
        private string dName;//设备名称
        private DevClass devBigClass;//设备大区域分类
        private string dClass;//设备分类
        private string IP;//设备IP
        private int port;//设备端口
        private string memo;//备注信息

        public Device(string dName, DevClass devBigClass, string dClass, string iP, int port, string memo) {
            this.dName = dName ?? "未知设备";
            this.devBigClass = devBigClass;            
            this.dClass = dClass ?? throw new ArgumentNullException(nameof(dClass));
            IP = iP ?? "127.0.0.1";
            this.port = 123456;
            this.memo = memo ?? "";
        }
    }
}
