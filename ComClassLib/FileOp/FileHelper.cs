﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ComClassLib.FileOp {
    public class FileHelper {
        #region 文件操作
        //创建文件夹
        public static bool CreateDir(String sDirPath) {
            try {
                if (false == System.IO.Directory.Exists(sDirPath)) {
                    //创建文件夹
                    DirectoryInfo dinfo = Directory.CreateDirectory(sDirPath);
                }
            } catch (Exception) {

                return false;
            }

            return true;
        }
        /// <summary>
        /// 文件拷贝
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="destFile"></param>
        /// <param name="isOverwrite"></param>
        /// <returns></returns>
        public static FileInfo FileCopy(string srcFile, string destFile, bool isOverwrite) {
            FileInfo file = new FileInfo(srcFile);
            FileInfo newFile = null;
            try {
                newFile = file.CopyTo(destFile, isOverwrite);
            } catch (IOException) {
                newFile = null;
                //MsgBox.Error("文件备份失败，检查目标文件是否已存在！\n详情：" + ex.ToString());
            }
            return newFile;
        }




        public static string OpenDir(string selTip, string defaultDir = "") {
            string sRtn = string.Empty;
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.SelectedPath = defaultDir;
            dialog.Description = selTip ?? "请选择文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (string.IsNullOrEmpty(dialog.SelectedPath)) {
                    MsgBox.Warning(@"文件夹路径不能为空", @"提示");
                    sRtn = string.Empty;
                } else {
                    sRtn = dialog.SelectedPath;
                }
            }
            return sRtn;
        }

        //写入图像
        public static bool ImgToFile(string sFileFullPath, byte[] imgBytes) {
            try {
                int iNewImgLen = imgBytes.Length - 8;
                byte[] img = new byte[iNewImgLen];
                Buffer.BlockCopy(imgBytes, 8, img, 0, iNewImgLen);
                System.IO.File.WriteAllBytes(sFileFullPath, img);
            } catch (Exception) {
                return false;
            }
            return true;


        }
        /// <summary>
        /// 采用内存缓存方式拷贝大文件
        /// </summary>
        public void CopyBigFile(string srcPath, string destPath) {
            //string originalPath = @"E:\AdvanceCSharpProject\LearnCSharp\21.zip";
            //string destPath = @"F:\BaiduNetdiskDownload\21.zip";
            //定义读文件流
            using (FileStream fsr = new FileStream(srcPath, FileMode.Open)) {
                //定义写文件流
                using (FileStream fsw = new FileStream(destPath, FileMode.OpenOrCreate)) {
                    //申请1M内存空间
                    byte[] buffer = new byte[1024 * 1024];
                    //无限循环中反复读写，直到读完写完
                    while (true) {
                        int readCount = fsr.Read(buffer, 0, buffer.Length);
                        fsw.Write(buffer, 0, readCount);
                        if (readCount < buffer.Length) {
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 得到指定目录下的文件
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="extName">扩展名-文件类型</param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static void GetFiles(string path, string extName, ref List<FileInfo> lst, bool isChildDir = false) {
            try {
                if (lst == null) lst = new List<FileInfo>();
                string[] dir = Directory.GetDirectories(path); //文件夹列表   
                DirectoryInfo fdir = new DirectoryInfo(path);
                FileInfo[] file = fdir.GetFiles();
                //FileInfo[] file = Directory.GetFiles(path); //文件列表   
                if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空                   
                {
                    foreach (FileInfo f in file) { //显示当前目录所有文件   
                        if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0) {
                            lst.Add(f);
                        }
                    }
                    foreach (string d in dir) {
                        GetFiles(d, extName, ref lst, isChildDir);//递归   
                    }
                }
            } catch (Exception) {
                // MsgBox.Show("获取文件出错！\n详细信息\n" + ex.ToString());
            }
        }
        #endregion
        public static byte[] getImageByte(string imgPath) {
            byte[] imageBytes = null;
            string imgName = Path.GetFileNameWithoutExtension(imgPath);
            try {
                FileStream fs = new FileStream(imgPath, FileMode.Open);
                imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imageBytes = br.ReadBytes(Convert.ToInt32(fs.Length));//图片转换成二进制流
            } catch (Exception ex) {
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
        /// 文件是否被占用
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsFileInUse(string fileName) {
            bool inUse = true;

            //using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None)) {
            //    inUse = false;
            //}

            FileStream fs = null;
            try {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                inUse = false;
            } catch {
            } finally {
                if (fs != null) {
                    fs.Close();
                }
            }
            return inUse;//true表示正在使用,false没有使用
        }

        public static string _InitialDirectory = "C:\\";

        public static string OpenFile(string title, string sFilter = "(*.*)|*.*") {
            string sFileName = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = _InitialDirectory;//初始化路径
            fileDialog.Filter = sFilter;//过滤选项设置，文本文件，所有文件。
            fileDialog.Title = title;// "选择导入的基础数据文件";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                sFileName = fileDialog.FileName;
                _InitialDirectory = Path.GetDirectoryName(sFileName);
            }
            return sFileName;

        }
        
        /// <summary>
        /// 从系统资源管理器中打开指定文件目录
        /// </summary>
        /// <param name="sDir"></param>
        public static void OpenLocalDir(string sDir) {
            try {
                System.Diagnostics.Process.Start(sDir);
            } catch (Exception) {

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
                } catch (Exception) {
                    return null;
                } finally {
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
            } catch (Exception) {
                return null;
            } finally {
                sr.Close();
                //释放资源  

            }
            DataSetToXml(ds);
            return ds;
        }
        public static string GetWeekName() {
            string weekName = "";
            switch (DateTime.Now.DayOfWeek) {
                case DayOfWeek.Monday:
                    weekName = "周一";
                    break;
                case DayOfWeek.Tuesday:
                    weekName = "周二";
                    break;
                case DayOfWeek.Wednesday:
                    weekName = "周三";
                    break;
                case DayOfWeek.Thursday:
                    weekName = "周四";
                    break;
                case DayOfWeek.Friday:
                    weekName = "周五";
                    break;
                case DayOfWeek.Saturday:
                    weekName = "周六";
                    break;
                case DayOfWeek.Sunday:
                    weekName = "周日";
                    break;
            }
            return weekName;
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

        #region 读写文件
        public static bool SaveTextFile(string path, string content) {
            if (string.IsNullOrEmpty(content)) {
                return false;
            }
            try {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(content);
                    sw.Close();
                }
                return true;
            } catch (Exception) {
                // Debug.WriteLine(string.Format("写入文件出错：消息={0},堆栈={1}", ex.Message, ex.StackTrace));
                return false;
            }
        }

        #endregion
        #region 类型转换
        /// <summary>
        /// 转换C的多字节汉字为C#正常文本。
        /// 如："\xBA\xBC\xD6\xDD\xC4\xCF-\xBA\xBC\xD6\xDD\xC4\xCF"
        /// </summary>
        /// <param name="str"></param>
        public static String ConvertToStr(String str) {
            if (String.IsNullOrEmpty(str)) {
                return null;
            }
            if (str.Length == 0) {
                return null;
            }

            byte[] gb = new byte[str.Length];
            for (int i = 0; i < str.Length; i++) {
                gb[i] = Convert.ToByte(str[i]);
            }
            return System.Text.Encoding.Default.GetString(gb);
        }
        /// <summary>
        /// 转换时间戳为C#时间
        /// </summary>
        /// <param name="timeStamp">时间戳 单位：毫秒</param>
        /// <returns>C#时间</returns>
        public static DateTime ConvertTimeStampToDateTime(long timeStamp) {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(timeStamp);
            return dt;
        }

        /// <summary> 
        /// 获取时间戳 
        /// </summary> 
        /// <returns>UTC</returns> 
        public static string GetTimeStamp() {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

    }
    //日志文件
    class Log {
        public const string Update = "U";
        public const string Add = "A";
        public const string Del = "D";
        #region 创建单实例对象
        private static Log _log;
        private static readonly object _obj = new object();
        private readonly string sLogPath;
        public static Log GetInstance() {
            if (_log == null) {
                lock (_obj) {
                    if (_log == null) {
                        _log = new Log();
                    }
                }
            }
            return _log;
        }


        #endregion


    }
}
