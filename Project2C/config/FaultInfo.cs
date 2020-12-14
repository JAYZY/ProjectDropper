using System;
using System.Web.Script.Serialization;

namespace Project2C.config {
    public class FaultInfo {
         
        public string uName;
        public string fName;
        public string memo;

        public FaultInfo() {
        }

        public FaultInfo(string uName, string fName, string memo) {
            this.uName = uName;
            this.fName = fName;
            this.memo = memo;
        }

        public string GetJson() {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(this); //序列化成JSON
            return json;
        }
        public static FaultInfo FromJson(string sJson) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try {
                FaultInfo p2 = serializer.Deserialize<FaultInfo>(sJson); //反序列化：JSON字符串=>对象
                return p2;
            }
            catch(Exception e) {
                return null;
            }
        

        }

    }
}
