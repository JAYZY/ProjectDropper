using ComClassLib.core;
using ComClassLib.DB;
using ComClassLib.FileOp;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using FVIL.Data;
using JCW;
using Project2C.config;
using Project2C.Core;
using Project2C.Dialog;
using Project2C.Properties;
using Project2C.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2C.ChildFrm {
    public partial class FrmAnalyse : DevComponents.DotNetBar.OfficeForm {
        private object obj = new object();
        private int iDataBulk = 100;//预读2秒的数据 50/秒
        private int iDataSmallBulk = 50; //预读1秒的数据 50/秒
        private bool readSideImg = true;
        private bool isReload;



        private DataTable dtIndexData, dtPoleNum, dtFault, dtJH; //索引数据，支柱号,缺陷,几何数据

        private DataTable dtDataA1 = null, dtDataA2 = null;

        private DataTable _curDtData = null;

        private DataRow _drViewA = null, _drViewB = null;
        private int _bufferId = 0; //缓冲ID 

        private int _curImgIdA = 0;

        private int iTotalFrameNum;//总帧数
        private int iCurFrameNum = 0; //当前帧数

        #region 获取数据库指针
        private SqliteHelper DBIndex {
            get { return SqliteHelper.GetSqlite(DataType.DbName.IndexDb.ToString()); }
        }

        private SqliteHelper DBJH {
            get { return SqliteHelper.GetSqlite(DataType.DbName.JHDB.ToString()); }
        }
        public object _dbOpObj = new object();
        public object _JHObj = new object();
        private SqliteHelper ImgSqliteA(string dbPath) {
            return SqliteHelper.GetSqlite("V1" + dbPath);
        }
        private SqliteHelper ImgSqliteB(string dbPath) {
            return SqliteHelper.GetSqlite("V2" + dbPath);
        }
        /// <summary>
        /// 加载所有的图像数据库
        /// </summary>
        /// <param name="dbFlag"> 只能是V1  或 V2</param>
        private void GenImgDb(string dbFlag) {
            if (dbFlag != "V1" && dbFlag != "V2") {
                return;
            }
            List<FileInfo> lstFiles = new List<FileInfo>();
            FileHelper.GetFiles(Path.Combine(Path.GetDirectoryName(DBIndex.DbFullName), dbFlag), ".db", ref lstFiles);
            foreach (FileInfo file in lstFiles) {
                if (file.Name.Contains("sm")) {
                    continue;
                }
                SqliteHelper.GenerateSqlite(dbFlag + file.Name, file.FullName);
            }
        }
        #endregion


        /// <summary>
        /// 属性：true - 当前主相机为 相机1 false - 当前主相机为 相机2
        /// </summary>
        private bool MainImgIdIsA = true;

        private Dictionary<int, FVIL.GDI.CFviGdiFigure> dicFaultPid;
        //  Bitmap mainBitmap = null;

        #region 窗体事件

        public FrmAnalyse() {
            InitializeComponent();
            dicFaultPid = new Dictionary<int, FVIL.GDI.CFviGdiFigure>();
            if (DBIndex == null) {
                MessageBox.Show("缺少全局索引数据库，请检查！\n系统将退出");
                Environment.Exit(0);
            }
            //表格初始化
            DataGridViewButtonXColumn bcx = dgViewJHData.Columns["colPosi"] as DataGridViewButtonXColumn;
            if (bcx != null) {
                bcx.BeforeCellPaint += JHDataPosi_BeforeCellPaint;
            }
        }

        /// <summary>
        /// 窗体事件 shown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAnalyse_Shown(object sender, EventArgs e) {
            //ReadData();
            DialogTaskTip.GetInstance().SetTipTxt(@"数据加载中...");
            //初始化几何参数数据库            
            ConnJH();

            //线程 -- 读取数据
            Thread thB = new Thread(ReadData);
            thB.Start();

            DialogTaskTip.GetInstance().ShowDialog();
            //等待加载完毕。


            btnFrameNo.Text = iCurFrameNum.ToString();
            lblTotalFrame.Text = "/" + iTotalFrameNum + @"帧";

            lblItemStationInfo.Text = ConfigInfo.GetInstance().TaskInfo.LineName;
            lblItemUpDown.Text = ConfigInfo.GetInstance().TaskInfo.SType;
            sBtnItemCamera.Value = true; //设置相机id
            cbBoxStation.Items.Add(ConfigInfo.GetInstance().TaskInfo.LineName);
            cbBoxStation.SelectedIndex = 0;
            btnItemPlay.ImageIndex = 0;
            iInputFrameSet.Value = 15;
            ImageView.MouseWheel += new System.Windows.Forms.MouseEventHandler(ImageView_MouseWheel);
        }

        private void FrmAnalyse_Load(object sender, EventArgs e) {
            Inictrl();

            //m_FigureHandlingOverlay.DelMouseEventHandler(ImageView);
        }
        //控件初始化
        private void Inictrl() {
            //图像控件初始化
            FVIL._SetUp.InitVisionLibrary();
            ImageView.Display.Overlays.Add(m_Overlay);
            ImageView.Display.Overlays.Add(m_FigureHandlingOverlay);
            m_FigureHandlingOverlay.AddMouseEventHandler(ImageView);

        }
        #endregion

        #region 数据绑定

        #region 数据缓存 
        /// <summary>
        /// 数据读取
        /// </summary>
        public void ReadData() {
            try {
                //读取索引表中所有数据 
                if (DBIndex == null) {
                    return;
                }
                dtIndexData = DBIndex.ExecuteDataTable("select rowid,* from indexTB", null);

                //DataTable dtTmpData = imgSqlite.ExecuteDataTable("select  count(pid) a  from picInfo where cId=1 ", null);
                //读取总数量  DataTable dtTmpData = imgSqlite.ExecuteDataTable("select seq from sqlite_sequence where name='picInfo' ", null);
                //读取所有图像数据文件，生成图像数据库
                GenImgDb("V1");
                GenImgDb("V2");
                DataRow dr = dtIndexData.Rows[iCurFrameNum];

                string imgKeyA = dr["timestampA"].ToString();
                string imgDBA = dr["dbIndexA"].ToString();
                string imgKeyB = dr["timestampB"].ToString();
                string imgDBB = dr["dbIndexB"].ToString();

                // dtDataA1 = ImgSqliteA(imgDBA).ExecuteDataTable("select * from GWVIDEO");
                //  dtDataA2 = ImgSqliteB(imgDBB).ExecuteDataTable("select * from GWVIDEO");
                //设置总帧数
                iTotalFrameNum = Convert.ToInt32(dtIndexData.Rows.Count);

                //加载基础数据 - 定位数据 
                LoadBaseDataAndPole();
                //加载几何参数数据
                LoadJHData();


                //加载1秒的数据 // ReadBufferSmallData();
                ReadImgData();
                DialogTaskTip.GetInstance().EndProc();
            } catch (Exception ex) {
                DialogTaskTip.GetInstance().EndProc();
                MessageBox.Show(ex.ToString());
            } finally {

            }
        }

        /// <summary>
        /// 根据索引值-读取图片
        /// </summary>

        private void ReadImgData() {
            if (DBIndex == null) {
                return;
            }
            //当前帧 索引数据
            DataRow dr = dtIndexData.Rows[iCurFrameNum];

            string imgKeyA = dr["timestampA"].ToString();
            string imgDBA = dr["dbIndexA"].ToString();
            string imgKeyB = dr["timestampB"].ToString();
            string imgDBB = dr["dbIndexB"].ToString();
            //读取图片1
            var taskLoadImgA = new Task(() => ReadImgA(imgKeyA, imgDBA));
            taskLoadImgA.Start();
            var taskLoadImgB = new Task(() => ReadImgB(imgKeyB, imgDBB));
            taskLoadImgB.Start();
            //读取几何参数
            var taskLoadJH = new Task(() => LoadJH(Convert.ToInt64(imgKeyA)));
            taskLoadJH.Start();
            isReload = true;
        }
        /// <summary>
        /// 加载第一个相机的图像
        /// </summary>
        /// <param name="imgKey"></param>
        /// <param name="imgDB"></param>
        private void ReadImgA(string imgKey, string imgDB) {
            if (string.IsNullOrEmpty(imgDB)) {
                return;
            }
            SqliteHelper sqliteHelper = ImgSqliteA(imgDB);
            if (sqliteHelper == null) {
                return;
            }
            lock (_dbOpObj) {
                _drViewA = sqliteHelper.ExecuteDataRow($"select * from GWVIDEO where file_time={imgKey}", null);
            }
            ActLoadImg(_drViewA, MainImgIdIsA);
        }

        private void ReadImgB(string imgKey, string imgDB) {
            if (string.IsNullOrEmpty(imgDB)) {
                return;
            }
            SqliteHelper sqliteHelper = ImgSqliteB(imgDB);
            if (sqliteHelper == null) {
                return;
            }
            lock (_dbOpObj) {
                _drViewB = sqliteHelper.ExecuteDataRow($"select * from GWVIDEO where file_time={imgKey}", null);
            }
            ActLoadImg(_drViewB, !MainImgIdIsA);
        }

        /// <summary>
        /// //从iStart开始取iLen条数据
        /// </summary>
        /// <param name="iStart"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        private DataTable GetDT(int iStart, int iLen) {
            var t1 = DateTime.Now;
            string strSql = string.Format("select  *  from picInfo  LIMIT  {0} OFFSET {1}", iLen, iStart); //从iStart开始取iLen条数据
            DataTable dt = null;// imgSqlite.ExecuteDataTable(strSql, null);
            Console.WriteLine("预读数据库耗时" + (DateTime.Now - t1).TotalMilliseconds);
            return dt;

        }

        /// <summary>
        /// 从当前帧号开始，预读小数据
        /// </summary>
        private void ReadBufferSmallData() {
            _bufferId = iCurFrameNum;
            _curDtData = dtDataA1 = GetDT(_bufferId, iDataSmallBulk);
            _bufferId += iDataSmallBulk;
            _curImgIdA = 0;
            // LoadImage();    //载入一张图片     
            //线程加载 缓存数据
            isReload = true;
            // (new Thread(ReadBufferData)).Start();
        }

        /// <summary>
        /// 预读取数据缓存
        /// </summary>
        public void ReadBufferData() {
            if (_curDtData == dtDataA1) {
                lock (obj) {
                    dtDataA2 = GetDT(_bufferId, iDataBulk);
                }
            } else {
                lock (obj) {
                    dtDataA1 = GetDT(_bufferId, iDataBulk);
                }
            }

            _bufferId += iDataBulk;
        }



        /// <summary>
        /// 跳转到某帧
        /// </summary>
        /// <param name="iFrameNo"></param>
        private void GoFrameNo(int iFrameNo) {

            if (iFrameNo < 0) {
                iFrameNo = 0;
            }
            if (iFrameNo > iTotalFrameNum) {
                iFrameNo = iTotalFrameNum;
            }

            _bufferId = iFrameNo;
            lock (obj) {
                _curDtData = dtDataA1 = GetDT(iFrameNo, 1);
            }
            iCurFrameNum = iFrameNo;
            _curImgIdA = 0;

            progressBarItem.Value = (int)(iCurFrameNum * 1.0 / iTotalFrameNum * 100.0);
            btnFrameNo.Text = iCurFrameNum.ToString();

            ReadImgData();//载入图片
            isReload = false;
        }

        /// <summary>
        /// 增加主图索引 -- 判断缓存数据是否读完
        /// </summary>
        private void AddCurImgIdA() {
            //判断缓存数据是否读完
            if (++_curImgIdA > _curDtData.Rows.Count - 1) {
                if (dtDataA2 == null && dtDataA1 == null) {
                    MessageBox.Show("数据加载速度过慢！");
                    Stop();
                }
                _curDtData = (_curDtData == dtDataA1) ? dtDataA2 : dtDataA1;
                _curImgIdA = 0;
                isReload = true;
                //(new Thread(ReadBufferData)).Start();//开始读相机缓存数据
            }
        }




        /// <summary>
        /// 从数据库中载入已有缺陷标注
        /// </summary>
        private void LoadMark() {


            if (_drViewA == null) {
                return;
            }

            DelAllLayerDel();
            Int64 pId = Convert.ToInt64(_drViewA["file_time"]);
            string strSql = "select * from FaultRecode where pid=" + pId;
            dtFault = DBIndex.ExecuteDataTable(strSql, null);
            DataTable dtCurFault = new DataTable();
            dtCurFault.Columns.Add("rId"); dtCurFault.Columns.Add("fId"); dtCurFault.Columns.Add("uId"); dtCurFault.Columns.Add("fName"); dtCurFault.Columns.Add("uName");
            dtCurFault.Columns.Add("fLevel"); dtCurFault.Columns.Add("rMemo");
            for (int ind = 0; ind < dtFault.Rows.Count; ++ind) {
                DataRow drFault = dtFault.Rows[ind];
                CFviPoint p = new CFviPoint(Convert.ToInt32(drFault["OffsetX"]), Convert.ToInt32(drFault["OffsetY"]));

                FVIL.GDI.CFviGdiFigure fig = AddLayer(p, Convert.ToInt32(drFault["width"]), Convert.ToInt32(drFault["height"]));
                //添加对应的标注
                dicFaultPid[Convert.ToInt32(drFault["rId"])] = fig;

                DataRow dr = dtCurFault.NewRow();
                dr["rId"] = drFault["rId"]; dr["fId"] = drFault["fId"]; dr["uId"] = drFault["uId"]; dr["fLevel"] = drFault["fLevel"];
                FaultInfo fInfo = FaultInfo.FromJson(drFault["memo"].ToString());
                dr["fName"] = fInfo.fName; dr["uName"] = fInfo.uName; dr["rMemo"] = fInfo.memo;
                dtCurFault.Rows.Add(dr);

            }
            dgViewCurFault.AutoGenerateColumns = false;
            dgViewCurFault.DataSource = dtCurFault;
            exPanelCurFault.Expanded = dtFault.Rows.Count > 0;
        }

        #endregion

        //private void LoadImage() {


        //    DataRow curDr = _curDtData.Rows[_curImgIdA];
        //    byte[] imgbyte = (byte[])curDr["imgContent"];

        //    //获取图像的8个字节 时间撮和相机编号
        //    byte[] byImgGuid = new byte[8];
        //    Array.Copy(imgbyte, 0, byImgGuid, 0, 8);
        //    Int64 iImgGuid = BitConverter.ToInt64(byImgGuid, 0);
        //    int iId = (MainImgIdIsA) ? 1 : 2;
        //    if (iId == iImgGuid % 10) {
        //        _drMainView = curDr;
        //        Thread th = new Thread(new ParameterizedThreadStart(LoadMainImg));
        //        th.Start(imgbyte);
        //    } else {
        //        _drSecView = curDr;
        //        Thread th = new Thread(new ParameterizedThreadStart(LoadSecImg));
        //        th.Start(imgbyte);
        //    }
        //}
        ///// <summary>
        ///// 主图载入 -- 线程
        ///// </summary>
        //private void LoadMainImg(object imgbyte) {
        //    byte[] imgBytes = (byte[])imgbyte;
        //    CFviImage cfimg = JpegCompress.Decompress(imgBytes, (uint)imgBytes.Length);
        //    if (isRecode) { //开启录像
        //        aviImg.Add(imgBytes);
        //    }
        //    ActLoadMainImg(cfimg);

        //}

        ///// <summary>
        ///// 次图载入 -- 线程
        ///// </summary> 
        //private void LoadSecImg(object imgbyte) {
        //    byte[] imgBytes = (byte[])imgbyte;
        //    CFviImage cfimg = JpegCompress.Decompress(imgBytes, (uint)imgBytes.Length);
        //    ActLoadSecImg(cfimg);
        //}
        /// <summary>
        /// 边图像载入前后100ms 200ms图像载入
        /// </summary>
        private void LoadLastImg() {
            return;
            Int64 timeA = Convert.ToInt64(_curDtData.Rows[_curImgIdA]["shootTime"]);
            int iCID = sBtnItemCamera.Value ? 1 : 2;
            string strSql = string.Format("select  *  from picInfo where cId={0} and shootTime >={1} LIMIT  1 ", iCID, timeA - 100);

            DataTable dtTmp = DBIndex.ExecuteDataTable(strSql, null);

            if (dtTmp.Rows.Count > 0) {
                Thread t = new Thread(new ParameterizedThreadStart(LoadRightImg1));
                t.Start(dtTmp);
            }

            strSql = string.Format("select  *  from picInfo where cId={0} and shootTime >={1} LIMIT  1 ", iCID, timeA - 200);

            DataTable dtTmp2 = DBIndex.ExecuteDataTable(strSql, null);
            if (dtTmp2.Rows.Count > 0) {
                Thread t = new Thread(new ParameterizedThreadStart(LoadRightImg2));
                t.Start(dtTmp2);
            }


            strSql = string.Format("select  *  from picInfo where cId={0} and shootTime >={1} LIMIT  1 ", iCID, timeA + 100);

            DataTable dtTmp3 = DBIndex.ExecuteDataTable(strSql, null);
            if (dtTmp3.Rows.Count > 0) {
                Thread t = new Thread(new ParameterizedThreadStart(LoadRightImg3));
                t.Start(dtTmp3);
            }

            strSql = string.Format("select  *  from picInfo where cId={0} and shootTime >={1} LIMIT  1 ", iCID, timeA + 200);

            DataTable dtTmp4 = DBIndex.ExecuteDataTable(strSql, null);
            if (dtTmp4.Rows.Count > 0) {
                Thread t = new Thread(new ParameterizedThreadStart(LoadRightImg4));
                t.Start(dtTmp4);
            }

        }

        private void LoadRightImg1(object obj) {
            LoadSideImg(cFviImageView1, (byte[])((DataTable)obj).Rows[0]["imgContent"]);
        }
        private void LoadRightImg2(object obj) {
            LoadSideImg(cFviImageView2, (byte[])((DataTable)obj).Rows[0]["imgContent"]);
        }
        private void LoadRightImg3(object obj) {
            LoadSideImg(cFviImageView3, (byte[])((DataTable)obj).Rows[0]["imgContent"]);
        }
        private void LoadRightImg4(object obj) {
            LoadSideImg(cFviImageView4, (byte[])((DataTable)obj).Rows[0]["imgContent"]);
        }

        /// <summary>
        /// 前后100ms 200ms图像载入 -- 委托 --
        /// </summary>
        private void LoadSideImg(FVIL.Forms.CFviImageView imageV, byte[] m) {
            if (ImageView.InvokeRequired) {
                Action<FVIL.Forms.CFviImageView, byte[]> a = LoadSideImg;
                imageV.Invoke(a, imageV, m);
            } else {

                using (MemoryStream mStreamSeal = new MemoryStream(m)) {
                    imageV.Image = (CFviImage)new Bitmap(Image.FromStream(mStreamSeal, true));
                }
                imageV.Display.MaskEnable = true;
                imageV.Display.EssentialMaskEnable = true;
                imageV.Display.Magnification = imageV.Width * 1.0 / imageV.Display.ImageSize.Width;
                imageV.Refresh();
            }
        }

        /// <summary>
        /// 载入主图像 --委托事件--
        /// </summary>
        private void ActLoadImg(DataRow dr, bool IsMainImg) {
            if (dr == null) {
                return;
            }
            if (ImageView.InvokeRequired) {
                Action<DataRow, bool> a = ActLoadImg;
                ImageView.Invoke(a, dr, IsMainImg);
            } else {
                if (dr == null) {
                    return;
                }
                byte[] imgBytes = (byte[])dr["jpeg"];
                CFviImage cimg = JpegCompress.Decompress(imgBytes, (uint)imgBytes.Length);
                //ImageView.Display.MaskEnable = true;
                //ImageView.Display.EssentialMaskEnable = true;

                if (IsMainImg) {
                    if (isRecode) { //开启录像
                        aviImg.Add(imgBytes);
                    }
                    ImageView.Image = cimg;
                    if (!IsPlay()) { //没有在播放 则加载标注
                        LoadMark();
                    }
                    //MessageBox.Show("LoadMark");
                    BindingInfo();
                    double mag = ImageView.Height * 1.0 / ImageView.Display.ImageSize.Height;
                    if (mag < 0.1) {
                        mag = 1;
                    }

                    ImageView.Display.Magnification = mag;
                    ImageView.Refresh();
                } else {
                    ImageView2.Image = cimg;
                    ImageView2.Display.MaskEnable = true;
                    ImageView2.Display.EssentialMaskEnable = true;
                    ImageView2.Display.Magnification = ImageView2.Height * 1.0 / ImageView2.Display.ImageSize.Height;
                    ImageView2.Refresh();
                }

            }
        }



        /// <summary>
        /// 绑定数据信息
        /// </summary>
        private void BindingInfo() {
            if (_drViewA != null) {
                // string strDateTime = "20" + _drViewA["file_time"].ToString();
                // lblItemShootTime.Text = DateTime.ParseExact(strDateTime, "yyyyMMddHHmmssfff", null).ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
        }

        /// <summary>
        /// 为dt表添加一个自增的ID字段
        /// </summary>
        /// <param name="dt">用户传进来的表</param>
        /// <returns></returns>
        public static DataTable AddAutoIdColumn(DataTable dt) {
            if (dt != null) {
                //Type.GetType (String) 获取具有指定名称的 Type，运行区分大写和小写的搜索。

                DataColumn column = new DataColumn("ID", Type.GetType("System.Int32"));
                //或者这样的形式
                //DataColumn column=new DataColumn("AutoID",typeof(int));
                dt.Columns.Add(column);
                dt.Columns["FrameNo"].SetOrdinal(0);

                for (int i = 0; i < dt.Rows.Count; i++) {
                    dt.Rows[i][0] = i + 1;
                }
            }
            return dt;

        }



        #endregion

        #region 视频播放代码
        /// <summary>
        /// 返回 视频播放状态 true -播放 false -停止
        /// </summary>
        /// <returns></returns>
        private bool IsPlay() { return btnItemPlay.Checked; }
        //视频播放
        public void Play() {
            if (IsPlay()) {
                return;
            }

            btnItemPlay.ImageIndex = 1;
            btnItemPlay.Checked = true;
            DelAllLayerDel(); //删除所有图层
            timerPlay.Enabled = true;
            ToastNotification.Show(ImageView, @"播放", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
            //if (!isReload) {
            //    //线程加载 缓存数据
            //    (new Thread(ReadBufferData)).Start();
            //}
        }
        //视频暂停
        public void Stop() {
            if (IsPlay()) { //表示播放中            
                btnItemPlay.ImageIndex = 0;
                btnItemPlay.Checked = false;
                timerPlay.Enabled = false;
                //显示 右边4副图像
                // LoadLastImg();
                ToastNotification.Show(ImageView, @"停止", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

            }
        }
        /// <summary>
        /// 主图播放
        /// </summary>
        private void timerPlay_Tick(object sender, EventArgs e) {
            if (iCurFrameNum > iTotalFrameNum - 1) {
                Stop();
            } else {
                if (!isReload) {
                    //从当前帧号开始，预读小数据
                    ReadBufferSmallData();
                } else {
                    //增加图片索引值并判断缓存数据是否读完
                    // AddCurImgIdA();

                    if (iCurFrameNum > dtIndexData.Rows.Count) {
                        Stop();
                        return;
                    }
                    ReadImgData();
                }
                ++iCurFrameNum;
                btnFrameNo.Text = iCurFrameNum.ToString();

                progressBarItem.Value = (int)(iCurFrameNum * 1.0 / iTotalFrameNum * 100.0);

            }

        }


        /// <summary>
        /// 下一帧
        /// </summary>        
        private void btnItemNext_Click(object sender, EventArgs e) {

            StepByOneFrame(true);

        }
        /// <summary>
        /// 上一帧
        /// </summary>
        private void btnItemPrev_Click(object sender, EventArgs e) {

            StepByOneFrame(false);
        }

        /// <summary>
        /// 下一帧或上一帧
        /// </summary>
        private void StepByOneFrame(bool isNext) {
            if (IsPlay()) {
                return;
            }
            string sTip = "";
            if (isNext) {
                if (iCurFrameNum > iTotalFrameNum - 1) {
                    return;
                }
                sTip = $"下一帧:{iCurFrameNum}";
                ++iCurFrameNum; ++_curImgIdA;
            } else {
                if (iCurFrameNum == 1) {
                    return;
                }
                --iCurFrameNum; --_curImgIdA;
                sTip = $"上一帧:{iCurFrameNum}";
            }

            GoFrameNo(iCurFrameNum);
            // progressBarItem.Value = (int)(iCurFrameNum * 1.0 / iTotalFrameNum * 100.0);
            // if (_curImgIdA < 0 || _curImgIdA > _curDtData.Rows.Count - 1) {//不在缓存区间则读取下一帧
            //增加图片索引值并判断缓存数据是否读完                AddCurImgIdA();
            //    GoFrameNo(iCurFrameNum);
            //     isReload = false;
            // } else {
            //      DelAllLayerDel(); //读取缓存数据
            //      ReadImgData();
            //      progressBarItem.Value = (int)(iCurFrameNum * 1.0 / iTotalFrameNum * 100.0);
            //      btnFrameNo.Text = iCurFrameNum.ToString();

            //}
            ToastNotification.Show(ImageView, sTip, null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

        }
        /// <summary>
        /// 事件 - 快放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemFaster_Click(object sender, EventArgs e) {
            if (isRecode) {
                ToastNotification.Show(ImageView, @"录像状态不能设置播放速率!", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                return;
            }
            ++iInputFrameSet.Value;
            timerPlay.Interval = 1000 / iInputFrameSet.Value;
            ToastNotification.Show(ImageView, @"播放速率：" + iInputFrameSet.Value.ToString() + @"帧", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

        }
        /// <summary>
        /// 事件 - 慢放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemSlower_Click(object sender, EventArgs e) {
            if (isRecode) {
                ToastNotification.Show(ImageView, @"录像状态不能设置播放速率!", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                return;
            }
            --iInputFrameSet.Value;
            timerPlay.Interval = 1000 / iInputFrameSet.Value;
            ToastNotification.Show(ImageView, @"播放速率：" + iInputFrameSet.Value.ToString() + @"帧", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

        }
        //播放 -- 按钮事件 --
        private void btnItemPlay_Click(object sender, EventArgs e) {
            if (IsPlay()) {//表示播放中{
                Stop();
            } else {
                Play();
            }
        }
        /// <summary>
        /// 事件-设置播放速率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemFrameSet_Click(object sender, EventArgs e) {
            if (isRecode) {
                ToastNotification.Show(ImageView, @"录像状态不能设置播放速率!", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                return;
            }
            timerPlay.Interval = 1000 / iInputFrameSet.Value;
            ToastNotification.Show(ImageView, @"设置播放速率：" + iInputFrameSet.Value.ToString() + @"帧", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

        }
        /// <summary>
        /// 播放进度条事件 - 鼠标移动显示帧数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void progressBarItem_MouseMove(object sender, MouseEventArgs e) {
            // 计算帧数 鼠标X坐标 -进度条左边坐标）/进度条宽度            
            double prog = 1.0 * (e.X - progressBarItem.Bounds.Left) / progressBarItem.Bounds.Width;
            uint uFrame = (uint)(iTotalFrameNum * prog);
            progressBarItem.Tooltip = uFrame + @"帧";
            progressBarItem.ShowToolTip();

        }
        /// <summary>
        /// 播放进度条事件 - 鼠标单击跳转帧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void progressBarItem_MouseUp(object sender, MouseEventArgs e) {
            if (IsPlay()) {
                return;
            }

            double prog = 1.0 * (e.X - progressBarItem.Bounds.Left) / progressBarItem.Bounds.Width;
            int iFrame = (int)(iTotalFrameNum * prog);
            iCurFrameNum = iFrame;

            GoFrameNo(iFrame);
            btnFrameNo.Text = iCurFrameNum.ToString();
            //  progressBarItem.Value = (int)(100 * prog);


            DelAllLayerDel();

        }
        #endregion

        #region 鼠标事件
        void ImageView_MouseWheel(object sender, MouseEventArgs e) {

            if (IsPlay()) {
                return;
            }

            if (e.Delta > 0) {
                ImageView.Display.Magnification = ImageView.Display.Magnification * 1.2;
            } else if (e.Delta < 0) {
                ImageView.Display.Magnification = ImageView.Display.Magnification * 0.8;
            }
            //ImageView.Display.Magnification += ImageView.Display.Magnification * (e.Delta > 0 ? 1 : -1) * 0.2;

            ImageView.Refresh();

            //else if (imgView.Visible) {
            //    imgView.Display.Magnification += imgView.Display.Magnification * (e.Delta > 0 ? 1 : -1) * 0.2;
            //    //  MessageBox.Show(imgView.Display.DisplayRect.Location.X+""+ imgView.Display.DisplayRect.Location.Y);
            //    imgView.Display.AllocateOption = 1;
            //    imgView.Refresh();
            //}
        }
        private Rectangle markRect;


        private void ImageView_MouseMove(object sender, MouseEventArgs e) {
            if (imgView.Visible == false) {
                return;
            }

            if (ImageView.Image == null) {
                return;
            }

            CFviPoint p = ImageView.Display.DPtoIP(e.Location, FVIL.GDI.ScalingMode.TopLeft);
            Bitmap mainBitmap = (Bitmap)ImageView.Image;
            int row = (int)(p.X - 150);
            int col = (int)(p.Y - 150);
            if (row < 0 || col < 0 || row > mainBitmap.Width || col > mainBitmap.Height) {
                return;
            }

            int w = (row + 300 > mainBitmap.Width) ? mainBitmap.Width - row : 300;
            int h = (col + 300 > mainBitmap.Height) ? mainBitmap.Height - col : 300;

            Bitmap newImg = mainBitmap.Clone(new Rectangle(row, col, w, h), mainBitmap.PixelFormat);
            //byte[]  = new byte[300 * 300];
            if (imgView.Image != null) {
                imgView.Image.Dispose();
            }

            imgView.Image = (CFviImage)newImg;
            newImg.Dispose();
            imgView.Display.MaskEnable = true;
            imgView.Display.EssentialMaskEnable = true;
            imgView.AutoScroll = false;

            imgView.Location = new Point(e.X + 20, e.Y + 20);
            imgView.Visible = true;
            imgView.Refresh();

        }

        /// <summary>
        /// 次图单击 -- 主副图切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageView2_MouseUp(object sender, MouseEventArgs e) {
            if (isRecode) { //录像状态不能切换
                ToastNotification.Show(ImageView, @"录像状态不能切换相机", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

                return;
            }
            sBtnItemCamera.Value = !sBtnItemCamera.Value;

        }
        /// <summary>
        /// 事件--主图鼠标双击（缺陷修改） / 鼠标右键（标注缺陷）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageView_MouseDown(object sender, MouseEventArgs e) {
            if (IsPlay()) {
                return;
            }
            return;
            if (e.Button == MouseButtons.Left && e.Clicks == 2) {//鼠标左键双击   
                FVIL.GDI.CFviGdiFigure item = m_FigureHandlingOverlay.GetSelectedFigure(true);
                if (item != null) {
                    imgView.Visible = false;
                    //弹出修改框
                    FVIL.GDI.CFviGdiRectangle fr = (FVIL.GDI.CFviGdiRectangle)item;
                    DataTable tmpDt = dgViewCurFault.DataSource as DataTable;
                    foreach (DataRow row in tmpDt.Rows) {
                        if (dicFaultPid[Convert.ToInt32(row["rId"])] == item) {
                            (new FrmFault(row, dtIndexData.Rows[iCurFrameNum])).Show();
                            ToastNotification.Show(ImageView, @"缺陷数据更新成功！", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                            break;
                        }
                    }
                } else {
                    imgView.Visible = !imgView.Visible;
                    if (imgView.Visible) {
                        imgView.Display.Magnification = 1;
                    }
                }
            } else if (e.Button == MouseButtons.Right) {//鼠标右键 - 一定是添加数据
                if (ImageView.Image == null || ImageView2.Image == null) {
                    MessageBox.Show("两个相机图像不完整！请下一帧 ");
                    return;
                }
                CFviPoint p = ImageView.Display.DPtoIP(e.Location, FVIL.GDI.ScalingMode.TopLeft);
                FVIL.GDI.CFviGdiFigure newFig = AddLayer(p, config.ConfigInfo.GetInstance().defaultMarkW, config.ConfigInfo.GetInstance().defaultMarkH);

                //保存当前缺陷截图
                CFviImage cvImg = new CFviImage();
                double dMgn = ImageView.Display.Magnification * 0.5;
                ImageView.Display.SaveImage(cvImg, ImageView.Image.ImageSize.ToRectangle(), dMgn);
                Image imgA = (Image)cvImg;

                //识别是相机A 或 相机B sBtnItemCamera.Value
                CFviImage cvImgB = new CFviImage();
                ImageView2.Display.SaveImage(cvImgB, ImageView2.Image.ImageSize.ToRectangle(), dMgn);
                Image imgB = (Image)cvImgB;
                //DataRow _curDataInfo, Rectangle _rect, byte[] _faultImgA, byte[] _faultImgB,bool _isCamA
                FrmFault frmFault = new FrmFault(dtIndexData.Rows[iCurFrameNum], markRect, FileHelper.getImageByte(imgA), FileHelper.getImageByte(imgB), sBtnItemCamera.Value);

                if (frmFault.ShowDialog() == DialogResult.Cancel) {
                    //FVIL.GDI.CFviGdiFigure item = m_FigureHandlingOverlay.Figures[m_FigureHandlingOverlay.Figures.Count - 1];
                    newFig.Dispose();
                    m_FigureHandlingOverlay.Figures.Remove(newFig);
                    ImageView.Refresh();
                } else {
                    //添加对应的标注
                    dicFaultPid[frmFault.LastInsertRid] = newFig;
                    //添加数据
                    // (dgViewCurFault.DataSource as DataTable).Rows.Add(frmFault.DrNewFault);
                }

                if (frmFault.ModifyPoleNum) {
                    //刷新杆号列表                    
                    LoadBaseDataAndPole();
                }
            }
        }
        #endregion

        #region 绘制标注
        /// <summary>
        /// 绘制标注
        /// 
        /// </summary>
        private FVIL.GDI.CFviGdiRectangle AddLayer(CFviPoint e, int w, int h) {
            m_FigureHandlingOverlay.Active = true;
            FVIL.Data.CFviRectangle vis = this.ImageView.Display.VisibleRect;
            FVIL.GDI.CFviGdiRectangle figure = new FVIL.GDI.CFviGdiRectangle();

            figure.Pen.Color = Color.Red;
            figure.St = new CFviPoint((e.X - w), e.Y - h);
            figure.Ed = new CFviPoint(e.X + w, e.Y + h);
            markRect = new Rectangle((int)e.X, (int)e.Y, w, h);

            m_FigureHandlingOverlay.Figures.Add(figure);

            ImageView.Refresh();
            return figure;
        }

        /// <summary>
        /// 刪除图层
        /// </summary>
        private void OnTestLayerDel() {
            foreach (FVIL.GDI.CFviGdiFigure item in m_Overlay.Figures) {
                item.Dispose();
            }
            m_Overlay.Figures.Clear();

            foreach (FVIL.GDI.CFviGdiFigure item in m_FigureHandlingOverlay.Figures) {
                if (item.Select) {
                    item.Dispose();
                    m_FigureHandlingOverlay.Figures.Remove(item);
                    //刪除记录对应的标注
                    dicFaultPid.Remove(item.GetDataID());
                    break;
                }
            }
            //m_FigureHandlingOverlay.Figures.Clear();
            m_RasterLayer = null;
            ImageView.Refresh();
        }
        private void DelAllLayerDel() {
            if (m_FigureHandlingOverlay.Figures.Count == 0) {
                return;
            }

            foreach (FVIL.GDI.CFviGdiFigure item in m_Overlay.Figures) {
                item.Dispose();
            }

            dicFaultPid.Clear();
            m_Overlay.Figures.Clear();
            m_FigureHandlingOverlay.Figures.Clear();
            m_RasterLayer = null;
            ImageView.Refresh();
        }
        /// <summary>
        /// 僆乕僶儗僀忋偵昞帵偡傞GDI夋憸僆僽僕僃僋僩.
        /// </summary>
        protected FVIL.GDI.CFviGdiImage m_RasterLayer = null;
        protected FVIL.GDI.CFviOverlay m_Overlay = new FVIL.GDI.CFviOverlay();

        /// <summary>
        /// GDI恾宍憖嶌梡偺僆乕僶儗僀.
        /// </summary>
        protected FigHandlingOverlay m_FigureHandlingOverlay = new FigHandlingOverlay();

        private void btnSave_Click(object sender, EventArgs e) {
            if (IsPlay()) {
                return;
            }

            SaveCurImg();
        }
        /// <summary>
        /// 保存当前图像
        /// </summary>
        private void SaveCurImg() {
            SaveFileDialog of = new SaveFileDialog();
            try {
                of.InitialDirectory = Properties.Settings.Default.lastDbDir;
                of.FileName = (lblItemShootTime.Text + (sBtnItemCamera.Value ? "_1.jpg" : "_2.jpg")).Replace(" ", "").Replace(":", "_");
                of.Filter = ".jpg文件(*.jpg)|*.jpg";
                if (of.ShowDialog() == DialogResult.OK) {
                    Image img = (Image)(ImageView.Display.Image);
                    img.Save(of.FileName);
                    Properties.Settings.Default.imgSavePath = Path.GetDirectoryName(of.FileName);//获取目录路径
                    ToastNotification.Show(ImageView, @"当前第" + iCurFrameNum.ToString() + "帧图像保存成功！", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

                }
            } catch (Exception ex) {
                MessageBox.Show("图像保存失败！\n" + ex.ToString());
            }
        }


        bool isRecode = false;
        List<byte[]> aviImg = new List<byte[]>();
        string aviName = "";
        /// <summary>
        /// 录像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemRecord_Click(object sender, EventArgs e) {
            isRecode = !isRecode;
            if (!isRecode) { //finish
                if (aviImg.Count < 20) {
                    ToastNotification.Show(ImageView, @"录像时间太短不能生成视频", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                    isRecode = !isRecode;
                    return;
                }
                Stop();
                VideoHelper videohelp = new VideoHelper(iInputFrameSet.Value);
                aviName += "_" + iCurFrameNum.ToString() + ".mp4";
                videohelp.Convert(aviImg, aviName);
                aviImg.Clear();
                aviName = "";
                ToastNotification.Show(ImageView, @"视频:" + aviName + @"保存成功！", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);

            } else {
                aviName = "r" + iCurFrameNum.ToString();
            }
            iInputFrameSet.Enabled = !iInputFrameSet.Enabled;
            btnItemRecord.Checked = !btnItemRecord.Checked;
            lblRecShow.Visible = !lblRecShow.Visible;
            sBtnItemCamera.Enabled = !sBtnItemCamera.Enabled;
        }

        private void buttonItem1_Click(object sender, EventArgs e) {

        }
        /// <summary>
        /// 删除指定缺陷记录
        /// </summary>
        /// <returns></returns>
        private bool DelFaultRecode(int rId) {
            string strSql = "delete from FaultRecode where rId=" + rId;
            return SqliteHelper.GetSqlite("imgDb").ExecuteNonQuery(strSql, null) > 0;
        }
        private void dgViewCurFault_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (dgViewCurFault.CurrentRow == null) {
                return;
            }

            DataGridViewButtonXCell cell = dgViewCurFault.CurrentCell as DataGridViewButtonXCell;
            if (cell != null) {
                if (dgViewCurFault.Columns[e.ColumnIndex] is DataGridViewButtonXColumn bc) {
                    if (bc.Name == "ColDel" && MsgBox.YesNo("确定删除!") == DialogResult.Yes) {
                        if (DelFaultRecode(Convert.ToInt32(dgViewCurFault.CurrentRow.Cells["ColRid"].Value))) {
                            ToastNotification.Show(ImageView, @"缺陷记录删除成功！", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                            LoadMark();
                        } else {
                            ToastNotification.Show(ImageView, @"缺陷记录删除失败！", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                        }

                    }
                }
            } else {
                FVIL.GDI.CFviGdiFigure fig = dicFaultPid[Convert.ToInt32(dgViewCurFault.CurrentRow.Cells["ColRid"].Value)];
                foreach (var item in m_FigureHandlingOverlay.Figures) {
                    item.Pen.Color = Color.Red;
                }
                //选择当前的缺陷

                fig.Pen.Color = Color.Yellow;

                ImageView.Refresh();
            }
        }

        private void btnGoPoleNum_Click(object sender, EventArgs e) {

        }


        #endregion

        #region 全局事件/方法
        /// <summary>
        /// 全局键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAnalyse_KeyUp(object sender, KeyEventArgs e) {
            //1.空格播放 /停止
            if (e.KeyCode == Keys.Space) {
                if (IsPlay()) {
                    Stop();
                } else {
                    Play();
                }
            } else if (e.KeyCode == Keys.Right) {
                StepByOneFrame(true);
            } else if (e.KeyCode == Keys.Left) {
                StepByOneFrame(false);
            }//2.F2 设置支柱号
              else if (e.KeyCode == Keys.F2) {
                ModifyLocalInfo();
            }//3.ctrl+s保存当前图像
              else if (e.Control && e.KeyCode == Keys.S) {
                SaveCurImg();
            }//4.ctrl+g 跳转帧
              else if (e.Control && e.KeyCode == Keys.G) {
                EventGoFrameNo();
            }

        }
        /// <summary>
        /// 主相机切换 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void sBtnItemCamera_ValueChanging(object sender, EventArgs e) {
            MainImgIdIsA = sBtnItemCamera.Value;
            LoadMark();
            var img = ImageView.Image;
            ImageView.Image = ImageView2.Image;
            ImageView2.Image = img;
            ImageView.Refresh();
            ImageView2.Refresh();
        }

        /// <summary>
        /// 双击定位数据 定位到 图像帧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewDataInfo_DoubleClick(object sender, EventArgs e) {
            if (dgViewDataInfo.CurrentRow == null) {
                return;
            }
            var selValue = dgViewDataInfo.CurrentRow.Cells["colImgId"].Value;
            if (selValue != null) {
                string selImgId = selValue.ToString();
                if (!string.IsNullOrEmpty(selImgId)) {
                    GoFrameNo(Convert.ToInt32(selImgId));
                }

            }
            // DataView dv = dgViewDataInfo.DataSource as DataView;
            //DataRow selRow =dgViewDataInfo.CurrentRow;

        }

        private void btnFrameNo_Click(object sender, EventArgs e) {
            EventGoFrameNo();
        }
        private void EventGoFrameNo() {
            FrmGoFrame frmGo = new FrmGoFrame();
            if (frmGo.ShowDialog() == DialogResult.OK) {
                GoFrameNo(frmGo.iGoFrame);
            }
        }
        #endregion

        #region 基础数据+定位信息
        /// <summary>
        /// 载入杆号数据
        /// </summary>
        private void LoadBaseDataAndPole() {
            dtPoleNum = DBIndex.ExecuteDataTable("select * from basedata", null);//  where areaType=5 order by pid limit 0,10000 ", null);
            isChgLocalInfo = false;
            ShowPoleNumInfo();
            isChgLocalInfo = true;
        }
        bool isChgLocalInfo;

        ComboBoxEx[] cbLocalInfo = null;
        /// <summary>
        /// 下拉框--定位信息过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxLocalInfo_SelectedIndexChanged(object sender, EventArgs e) {
            if (!isChgLocalInfo) {
                return;
            }

            var ctrl = (ComboBoxEx)sender;
            if (cbLocalInfo == null) {
                cbLocalInfo = new ComboBoxEx[] { cbBoxStation, cbTunnelName, cbPoleName };
            }
            isChgLocalInfo = false;
            foreach (var comboBox in cbLocalInfo) {
                if (comboBox == ctrl) {
                    continue;
                }

                comboBox.SelectedIndex = 0;
            }
            isChgLocalInfo = true;
            if (ctrl.SelectedIndex == 0) { //还原
                dgViewDataInfo.DataSource = dtPoleNum.DefaultView;
            } else {
                try {
                    DataView dv = new DataView(dtPoleNum);
                    dv.RowFilter = $"{ctrl.Tag}='{ctrl.Text}'";
                    dgViewDataInfo.DataSource = dv;
                } catch { }
            }



        }

        /// <summary>
        /// 修改定位信息--按钮事件
        /// </summary>
        private void btnItemPoleNumSet_Click(object sender, EventArgs e) {
            ModifyLocalInfo();
        }

        int iSelCurrPoleNameId = -1;//选择的当前杆号ID
        /// <summary>
        /// 查找当前定位点
        /// 算法：
        /// 1.若点击了左侧定位点则，为左侧定位点。
        /// 2.否则查找dtPoleName中当前图像Id最近的定位点
        /// 
        /// </summary>
        /// <returns>返回ID </returns>
        private int FindCurrPoleNameInd() {
            if (iSelCurrPoleNameId > -1) {
                return iSelCurrPoleNameId;
            }
            iSelCurrPoleNameId = iCurFrameNum + 1;
            DataRow[] drs = dtPoleNum.Select($"ImgId={iSelCurrPoleNameId}");
            int rtnInd = -1;
            if (drs.Length > 0) {
                rtnInd = Convert.ToInt32(drs[0]["Id"]) - 1; //找到已有定位点               
            } else if (drs.Length == 0) {
                drs = dtPoleNum.Select($"ImgId<{iSelCurrPoleNameId}", "id desc");
                if (drs.Length == 0) {
                    rtnInd = 0;
                } else {
                    rtnInd = Convert.ToInt32(drs[0]["Id"]); //找最近的定位点 例如 已有  
                }
            }

            //iSelCurrPoleNameId = -1;
            return rtnInd;
        }


        /// <summary>
        /// 修改支柱号--方法
        /// </summary>
        private void ModifyLocalInfo() {
            int selCurrPoleName = FindCurrPoleNameInd();

            FrmSetPoleNum frmPoleNum = new FrmSetPoleNum(dtPoleNum, selCurrPoleName, iSelCurrPoleNameId);
            if (frmPoleNum.ShowDialog() == DialogResult.Cancel) {
                iSelCurrPoleNameId = -1;
                return;
            }

            int iBaseDataId = frmPoleNum.selBaseDataId;
            if (iBaseDataId == -1) {
                return;
            }
            string poleName = "";
            //修改数据（采用冗余方式） --A.写入baseData 表ImgId B.写入indexTB表 poleNum
            try {
                string sSQL = $"update BaseData set ImgId={iSelCurrPoleNameId} where Id={iBaseDataId}";
                DBIndex.ExecuteNonQuery(sSQL);
                poleName = dtPoleNum.Rows[iBaseDataId]["poleName"].ToString();
                sSQL = $"update indexTB set poleNum='{poleName}' where rowId={iSelCurrPoleNameId}";
                DBIndex.ExecuteNonQuery(sSQL);
            } catch (Exception ex) {

                MsgBox.Error("定位数据写入错误！\n\n" + ex.ToString());
            }
            LoadBaseDataAndPole();

            iSelCurrPoleNameId = -1;//重置选择
            ToastNotification.Show(ImageView, $"定位信息:{poleName},设置成功", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
        }



        /// <summary>
        /// 显示支柱号（定位）信息
        /// </summary>
        private void ShowPoleNumInfo() {
            if (dgViewDataInfo.InvokeRequired) {
                Action a = ShowPoleNumInfo;
                dgViewDataInfo.Invoke(a);

            } else {
                dgViewDataInfo.AutoGenerateColumns = false;
                dgViewDataInfo.DataSource = dtPoleNum;
                //去重 提取区间信息--考虑效率 
                cbPoleName.Items.Clear(); cbPoleName.Items.Add("-全部-"); cbPoleName.SelectedIndex = 0;
                cbBoxStation.Items.Clear(); cbBoxStation.Items.Add("------全部站区------"); cbBoxStation.SelectedIndex = 0;
                cbTunnelName.Items.Clear(); cbTunnelName.Items.Add("--全部隧道--"); cbTunnelName.SelectedIndex = 0;
                foreach (DataRow datarow in dtPoleNum.Rows) {
                    if (datarow["stationRegion"] != null && cbBoxStation.Items.IndexOf(datarow["stationRegion"]) == -1) {
                        cbBoxStation.Items.Add(datarow["stationRegion"]);
                    }
                    if (datarow["tunnelName"] != null && cbTunnelName.Items.IndexOf(datarow["tunnelName"]) == -1) {
                        if (!string.IsNullOrEmpty(datarow["tunnelName"].ToString())) {
                            cbTunnelName.Items.Add(datarow["tunnelName"]);
                        }
                    }
                    if (datarow["poleName"] != null && cbPoleName.Items.IndexOf(datarow["poleName"]) == -1) {
                        cbPoleName.Items.Add(datarow["poleName"]);
                    }

                }
            }
        }
        #endregion




        private void dgViewDataInfo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            //  e.Row.Cells[3].Value = StationInfo.GetInstance().SName;
        }


        #region # 几何参数
        /// <summary>
        /// 从数据库导入几何数据
        /// </summary>

        private void LoadJHData() {
            /**
             * 参数说明：
             * (1).posi  定位点  0 无（NULL） 	1 导线	2 吊弦  	3 支柱
             * (2).jhx1  拉出值
             * (3).jhy1  导高
             */
            try {
                string strQuery = "select rowid,case posi when 1 then '导线' when 2 then '吊弦' when 3 then '支柱' else '未知'end as posi," +
                    "jhx1,jhy1,time_stamp,file_time from JCWJH where posi>0";
                dtJH = DBJH.ExecuteDataTable(strQuery);
                BindJHDataShow();
            } catch { }
        }
        private void BindJHDataShow() {
            if (dgViewJHData.InvokeRequired) {
                Action a = BindJHDataShow;
                dgViewCurFault.Invoke(a);
            } else {

                dgViewJHData.DataSource = dtJH.DefaultView;

            }
        }

        private void dgViewJHData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex != -1) {
                DataGridViewRow dr = (sender as DataGridViewX).Rows[e.RowIndex];
                var bcColZeg = dr.Cells["colZeg"];
                var bcColHei = dr.Cells["colHei"];  
                if (bcColZeg != null) {
                    string colValue = bcColZeg.Value.ToString().Trim();
                    double zeg = string.IsNullOrEmpty(colValue) ? 0 : Convert.ToDouble(colValue);
                    if (zeg >= Settings.Default.maxZeg || zeg <= Settings.Default.minZeg) {
                        bcColZeg.Style.ForeColor = Color.Red;//FromName("#ffffff");
                        bcColZeg.Style.Font = new Font("宋体", 9F, FontStyle.Bold);
                        dr.DefaultCellStyle.BackColor = Color.Gold;
                    }
                }
                if (bcColHei != null) {
                    string colValue = bcColHei.Value.ToString().Trim();
                    double Hei = string.IsNullOrEmpty(colValue) ? 0 : Convert.ToDouble(colValue);
                    if (Hei >= Settings.Default.maxHei || Hei <= Settings.Default.minHei) {
                        bcColHei.Style.ForeColor = Color.Red;//FromName("#ffffff");
                        bcColHei.Style.Font = new Font("宋体", 9F, FontStyle.Bold);
                        dr.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }

            }
        }
        /// <summary>
        /// 双击 几何参数定位到图像 帧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewJHData_DoubleClick(object sender, EventArgs e) {
            if (dgViewJHData.CurrentRow == null) {
                return;
            }
            var selValue = dgViewJHData.CurrentRow.Cells["colImgId"].Value;
            if (selValue != null) {
                string selImgId = selValue.ToString();
                if (!string.IsNullOrEmpty(selImgId)) {
                    GoFrameNo(Convert.ToInt32(selImgId));
                }
            }
        }

        void JHDataPosi_BeforeCellPaint(object sender, BeforeCellPaintEventArgs e) {
            DataGridViewButtonXColumn bcx = sender as DataGridViewButtonXColumn;

            if (bcx != null) {
                // 1 导线	2 吊弦  	3 支柱

                if (bcx.Text.Trim().Equals("1")) {
                    //bcx.Image = imageList1.Images["SecHigh"];
                    bcx.Text = "<font color=\"red\">导线</font>";
                } else if (bcx.Text.Trim().Equals("2")) {
                    //bcx.Image = imageList1.Images["SecHigh"];
                    bcx.Text = "<font color=\"red\">吊弦</font>";
                } else if (bcx.Text.Trim().Equals("3")) {
                    //bcx.Image = imageList1.Images["SecHigh"];
                    bcx.Text = "<font color=\"red\">支柱</font>";
                } else {
                    //bcx.Image = imageList1.Images["SecHigh"];
                    bcx.Text = "<font color=\"red\">未知</font>";
                }
            }
        }

        /// <summary>
        /// 根据表格内容绘制颜色
        /// </summary>
        private void dgViewJHData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            


        } 
        IntPtr m_hjcw = IntPtr.Zero;
        public void ConnJH() {

            m_hjcw = jcwlib.Jcw_InitInstance();
            if (m_hjcw == IntPtr.Zero) {
                MessageBox.Show("err");
            }
            //加载配置文件
            string iniPath = $"{System.Environment.CurrentDirectory}\\JCWLibConf.ini";

            int iErrcode = (int)jcwlib.Jcw_LoadConfig(m_hjcw, iniPath);
            if (m_hjcw != IntPtr.Zero) {
                JcwReturn jcr = jcwlib.Jcw_Start(m_hjcw);
                if (jcr != JcwReturn.JCW_OK) {
                    MessageBox.Show(((int)jcr).ToString());
                } else {
                    // timeJH.Start();
                }
            }
        }

      

        Queue<JCWJH> lstJCWJH = new Queue<JCWJH>();



        private object obj1 = new object();



        const int timeOffset = 10000000;
        Int64 minImgTime = 0;
        private void LoadJH(Int64 ImgTime) {
            int iCount = 0;
            Int64 maxImgTime = ImgTime + timeOffset;
            string strQuery = $"select * from JCWJH where file_time>{minImgTime} and file_time<= {maxImgTime}";
            minImgTime = maxImgTime;
            DataTable dt = null;
            lock (_JHObj) {
                dt = DBJH.ExecuteDataTable(strQuery);// while (JcwReturn.JCW_OK == jcwlib.Jcw_PopResult(m_hjcw, ref jh)) {
            }
            if (dt == null) {
                return;
            }

            for (int i = 0; i < dt.Rows.Count; i++) {
                JCWJH jh = new JCWJH();
                jh.LoadData(dt.Rows[i]); //加载
                lstJCWJH.Enqueue(jh);
                //绘制图像   jh
                if (jh.uiLineNum > 0) { //判断数量
                    line1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y);
                    lczLine1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.x);
                    if (jh.uiLineNum > 1) {
                        line2.Add(jh.dTimestamp, jh.jcx[1].pntLinePos.y);
                        lczLine2.Add(jh.dTimestamp, jh.jcx[1].pntLinePos.x);
                    }
                    if (jh.uiLineNum > 2) {
                        line3.Add(jh.dTimestamp, jh.jcx[2].pntLinePos.y);
                        lczLine3.Add(jh.dTimestamp, jh.jcx[2].pntLinePos.x);
                    }
                    if (jh.uiLineNum > 3) {
                        line4.Add(jh.dTimestamp, jh.jcx[3].pntLinePos.y);
                        lczLine4.Add(jh.dTimestamp, jh.jcx[3].pntLinePos.x);
                    }
                    //绘制point
                    if (jh.jcx[0].posi == JCWPosi.JCXP_DROPPER) {
                        points1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y, Color.Black);
                        lczPoints.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.x, Color.Black);

                    } else if (jh.jcx[0].posi == JCWPosi.JCXP_POLE) {
                        points1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y, Color.Red);
                        lczPoints.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.x, Color.Red);
                    }
                }
                iCount++;
                if (lstJCWJH.Count > 1000) {
                    JCWJH jhGet = lstJCWJH.Dequeue();
                    if (jhGet.uiLineNum > 0) {
                        line1.Delete(0);
                        lczLine1.Delete(0);
                        if (jhGet.uiLineNum > 1) {
                            line2.Delete(0);
                            lczLine2.Delete(0);
                        }
                        if (jhGet.uiLineNum > 2) {
                            line3.Delete(0);
                            lczLine3.Delete(0);
                        }
                        if (jhGet.uiLineNum > 3) {
                            line4.Delete(0);
                            lczLine4.Delete(0);
                        }
                    }

                    if (jhGet.jcx[0].posi == JCWPosi.JCXP_DROPPER) {
                        points1.Delete(0);
                        lczPoints.Delete(0);

                    } else if (jhGet.jcx[0].posi == JCWPosi.JCXP_POLE) {
                        points1.Delete(0);
                        lczPoints.Delete(0);
                    }
                }

            }
            //if (JcwReturn.JCW_OK == jcwlib.Jcw_GetDevState(m_hjcw, JMID.JMID_GEO_DEV0, ref state)) {
            //    if (state == -1) {//未连接 灰色
            //        lblJH.ForeColor = Color.FromArgb(128, 128, 128, 128);
            //        toolTip1.SetToolTip(lblJH, "未连接！");
            //    } else if (state == 0) {//连接不正常  红色
            //        lblJH.ForeColor = Color.FromArgb(192, 0, 0);
            //        toolTip1.SetToolTip(lblJH, "连接失败！");
            //    } else if (state == 1) {//连接 绿色
            //        lblJH.ForeColor = Color.ForestGreen;
            //        toolTip1.SetToolTip(lblJH, "连接正常！");
            //    }
            //}
        }
        #endregion
    }
}
