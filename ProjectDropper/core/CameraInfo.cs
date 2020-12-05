namespace ProjectDropper.core {
   public class CameraInfo {
        public string CameraID;
        public int Status;
        public int Exposure;
        public double Gain;
        public double Fps;
        public int ImageWidth;
        public int ImageHeight;
        public int LEDOn;
        public int LEDWidth;
        public int FocusPos;
        public int IrisPos;
        public int ZoomPos;
        public double CpuUse;
        public double DiskFree;
        public int BufferCount;
        public int TotalBuffer;
        public int FreeBuffer;
        public string IP;
        
    }
    public class UPDInfo {
        //{"ip":"192.168.100.114","rssi":-44,"time":156855,"cam0":1,"cam1":1,"cam2":1,"cam3":1,"bat":152.1}
        public string ip;
        public int rssi;
        public int time;
        public int cam0;
        public int cam1;
        public int cam2;
        public int cam3;
        public double bat;
        public double GetCBat() {
            return 0.076449 * bat + 12.906132;
        }
    }
}
