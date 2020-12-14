using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Project2C.DB {
    public class Crypto {
        const string SKey = "gwgw2016";
        /// <summary>
        /// 加密函数--输入字符串加密为密码
        /// </summary>
        /// <param name="pToEncrypt">加密的字符串（密码）</param>
        /// <returns></returns>
        public static string DesEncrypt(string pToEncrypt) {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(SKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(SKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray()) {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
            //return a;
        }
        /// <summary>
        /// 解密原函数
        /// </summary>
        /// <param name="pToDecrypt">解密的字符串内容</param>
        /// <returns></returns>
        public static string DesDecrypt(string pToDecrypt) {
            try {

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++) {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(SKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(SKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch { return "error"; }
        }
        public static bool JudgUseLegal(string[] pwd, string strName) {
            int useDay = int.Parse(pwd[1]);
            //成功写文件 隐藏目录为 cookie
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            string pwdPath = Path.Combine(dir, "ver@" + strName + ".txt");
            if (File.Exists(@pwdPath))//存在
            {
                //读取第一次运行的时间
                DateTime firstDateTime;
                using (StreamReader sr = new StreamReader(@pwdPath)) {
                    firstDateTime = DateTime.Parse(DesDecrypt(sr.ReadLine()));
                    DateTime PrevDateTime = DateTime.Parse(DesDecrypt(sr.ReadLine()));
                    TimeSpan ts = DateTime.Now - firstDateTime;
                    TimeSpan tsTime = DateTime.Now - PrevDateTime;

                    int diffDay = (int)(ts.TotalDays);
                    if (diffDay < 0 || (int)tsTime.TotalMinutes < 0)
                        return false;
                    if (diffDay >= useDay)
                        return false;
                }
                //写入文件-更新最近的打开文件时间
                using (StreamWriter sw = new StreamWriter(@pwdPath, false)) {
                    sw.WriteLine(DesEncrypt(firstDateTime.ToString()));
                    sw.WriteLine(DesEncrypt(DateTime.Now.ToString()));
                }
            }
            else {
                if (pwd[0] != DateTime.Now.ToShortDateString())
                    return false;
                //删除无效日志文件
                string[] dirs = Directory.GetFiles(@dir, "ver@*");
                foreach (string fileName in dirs)
                    File.Delete(fileName);
                using (StreamWriter sr = new StreamWriter(@pwdPath)) {
                    sr.WriteLine(DesEncrypt(DateTime.Now.ToString()));
                    sr.WriteLine(DesEncrypt(DateTime.Now.ToString()));
                };

            }
            return true;
        }
    }
}
