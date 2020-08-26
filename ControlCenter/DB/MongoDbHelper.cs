using ControlCenter.Properties;
using MongodbAccess;
using System;

namespace ControlCenter.DB {


    public class MongoDbHelper {
        public static readonly string connectionString = "Servers=192.168.0.3:27017;ConnectTimeout=30000;ConnectionLifetime=300000;MinimumPoolSize=8;MaximumPoolSize=256;Pooled=true";
        public static readonly string database = "Friends";
        public static readonly string IP = "127.0.0.1";
        private static MongodbAccessImpl mongodbAccess;
        public static void Conn() {
            mongodbAccess = new MongodbAccessImpl(Settings.Default.MongoDbIP, Settings.Default.MongoDBPort, Settings.Default.MongoDBName);
        }
        public static void Find() {
            Console.WriteLine("*************** 接口 查询所有数据**************");
            var re = mongodbAccess.FindAll();
            Console.WriteLine("查询到数据条数为: " + re.Count, " 条");
            Console.WriteLine("输出前五条数据示例");
            for (int i = 0; i < re.Count; i++) {
                if (i < 5)
                    Console.WriteLine(re[i].ToString());
            }
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("*************** 接口 按时间段查询**************");
            var resu = mongodbAccess.FindInTime(132382610645320301, 132382610649907477);
            Console.WriteLine("查询到数据条数为: " + resu.Count, " 条");
            Console.WriteLine("输出前五条数据示例");
            for (int i = 0; i < resu.Count; i++) {
                if (i < 5)
                    Console.WriteLine(resu[i].ToString());
            }
            Console.WriteLine("*************** 接口 按时间> 某个值查询**************");
            resu = mongodbAccess.FindInTime(132382610645320301, -1);
            Console.WriteLine("查询到数据条数为: " + resu.Count, " 条");
            Console.WriteLine("输出大于一个时间撮数据示例");
            for (int i = 0; i < resu.Count; i++) {
                if (i < 5)
                    Console.WriteLine(resu[i].ToString());
            }

        }
    }
}
