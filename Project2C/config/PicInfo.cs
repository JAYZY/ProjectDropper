using System.Web.Script.Serialization;

namespace Project2C.config {

    public class PicInfo {

        //public int _1 { get; set; }
        //public string _2 { get; set; }
        //public string _3 { get; set; }
        //public string _4 { get; set; }
        //public int _5 { get; set; }
        public int CID { get; set; }
        public string Tim { get; set; }
        public string GPS { get; set; }
        public string POL { get; set; }
        public int SAT { get; set; }

        public static PicInfo FromJson(string sJson) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            PicInfo p2 = serializer.Deserialize<PicInfo>(sJson); //反序列化：JSON字符串=>对象
            return p2;

        }
    }


}
