using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Project2C.FileOp {
    class FileHelper {
        /// <summary>
        /// 得到图像的二进制byte[] -- 传入图像路径
        /// </summary>
        /// <param name="imgPath">图像路径</param>
        /// <returns></returns>
        public static byte[] getImageByte(String imgPath) {
            byte[] imageBytes = null;
            string imgName = Path.GetFileNameWithoutExtension(imgPath);
            try {
                FileStream fs = new FileStream(imgPath, FileMode.Open);
                imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imageBytes = br.ReadBytes(Convert.ToInt32(fs.Length));//图片转换成二进制流
            }
            catch (Exception ex) {
                Console.WriteLine("Insert {0} is error;\n{1}", imgName, ex.Message);//显示异常信息
            }
            return imageBytes;
        }
        /// <summary>
        /// 得到图像的二进制byte[] -- 传入图像Image
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <returns></returns>
        public static byte[] getImageByte(System.Drawing.Image imgPhoto) {
            //将Image转换成流数据，并保存为byte[]
            using (MemoryStream mstream = new MemoryStream()) {
                imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] byData = new Byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(byData, 0, byData.Length);
                return byData;
            }

        }
        /// <summary>
        /// 将xml转为Datable
        /// </summary>
        public static DataTable XmlToDataTable(string xmlStr) {
            if (!string.IsNullOrEmpty(xmlStr)) {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息  
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据  
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据                 
                    ds.ReadXml(Xmlrdr);
                    return ds.Tables[0];
                }
                catch (Exception e) {
                    return null;
                }
                finally {
                    //释放资源  
                    if (Xmlrdr != null) {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            return null;
        }
        public static DataSet XmlToDataSet(string xmlFilePath) {

            StreamReader sr = null;
            DataSet ds = new DataSet();
            try {
                sr = new StreamReader(xmlFilePath, System.Text.Encoding.Default);
                ds.ReadXml(sr);
            }
            catch (Exception e) {
                return null;
            }
            finally {
                sr.Close();
                //释放资源  

            }
            DataSetToXml(ds);
            return ds;
        }
        /// <summary>
        /// 将datatable转为xml 
        /// </summary>
        public static void DataTableToXml(DataTable vTable) {
            string savePath = Application.StartupPath.ToString();
            if (!Directory.Exists(savePath)) {
                Directory.CreateDirectory(savePath);
            }
            string xml = savePath + @"\编组信息表.xml";
            //如果文件DataTable.xml存在则直接删除
            if (File.Exists(xml)) {
                File.Delete(xml);
            }
            vTable.WriteXml(savePath + @"\编组信息表.xml");
        }
        public static void DataSetToXml(DataSet ds) {
            string savePath = Application.StartupPath.ToString();
            if (!Directory.Exists(savePath)) {
                Directory.CreateDirectory(savePath);
            }
            string xml = savePath + @"\111.xml";
            //如果文件DataTable.xml存在则直接删除
            if (File.Exists(xml)) {
                File.Delete(xml);
            }
            ds.WriteXml(savePath + @"\111.xml");
        }




    }
}
