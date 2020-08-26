using ComClassLib;
using DevComponents.DotNetBar;
using ProjectDropper.core;
using ProjectDropper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDropper {
    public partial class FrmMain : Form {

        enum CameraParam {
            Gain, //增益 0.0-30.0
            Exposure, //曝光时间  60u
            FocusMinus, //聚焦  默认200 <1000
            FocusPlus,
            LEDWidth,
            EnableLED,
            FrameRate, //帧率 0.5~12.0  
            TriggerMode, //0 不   1-触发（使能）
            MoveUp,   //跟值 >1 <100
            MoveDown,
            MoveLeft,
            MoveRight,
            MoveStop,
            MoveTo,    //预置位 1~16
            SetPos,   // 将当前 位置设置为预置位
            RemovePos,  //1 。
            ShutDown,
            Restart
        }
        string[] arrParam = { "Gain", "Exposure", "FocusMinus", "FocusPlus", "LEDWidth", "EnableLED", "FrameRate", "TriggerMode", "MoveUp", "MoveDown", "MoveLeft", "MoveRight", "MoveStop", "MoveTo", "SetPos", "RemovePos", "ShutDown", "Restart" };
        CameraParam param;
        string sParamValue;
        private IntPtr[] _hDevs;//设备Handle
        private CtrlView[] _imageViews;//图像控件
        private Panel[] _imgPanels;
        private string[] _ipAddress;
        protected Label[] _lblTips;
        private Label[] _lblCameraStates;
        private int _iPort;//端口统一
        private System.Windows.Forms.Timer[] _videoDisplays;
        private CancellationTokenSource[] _tokenSource;
        //private CancellationToken[] _token;
        private ManualResetEvent _resetEvent;
        private Task[] _tasks;
        bool _isRunVideoServ;
        public FrmMain() {
           // GetTimeStamp(DateTime.Now); //时间戳
            InitializeComponent();
            IniCtrl();
            ConnJH();
        }
        private void IniCtrl() {
            _tasks = new Task[4];
             
            _hDevs = new IntPtr[4] { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero };
            _imageViews = new CtrlView[] { new CtrlView("cView1"), new CtrlView("cView2"), new CtrlView("cView3"), new CtrlView("cView4") };
            _ipAddress = new string[] { Settings.Default.cameraIPA, Settings.Default.cameraIPB, Settings.Default.cameraIPC, Settings.Default.cameraIPD };
            _iPort = Settings.Default.cameraPort;
            _imgPanels = new Panel[] { panelImgA, panelImgB, panelImgC, panelImgD };
            _lblTips = new Label[] { lblTipA, lblTipB, lblTipC, lblTipD };
            // lblTipA.ForeColor = lblTipB.ForeColor = lblTipC.ForeColor = lblTipD.ForeColor = Color.White;
            _lblCameraStates = new Label[] { lblCameraStateA, lblCameraStateB, lblCameraStateC, lblCameraStateD };


            /// 任务初始化
            _tokenSource = new CancellationTokenSource[] { new CancellationTokenSource(), new CancellationTokenSource(), new CancellationTokenSource(), new CancellationTokenSource() };

            _resetEvent = new ManualResetEvent(true);
            //
            comBoxCameraSel.Items.Clear();
            for (int i = 0; i < _imgPanels.Length; i++) {
                //_token[i] = _tokenSource[i].Token;
                _imgPanels[i].Controls.Add(_imageViews[i]);
                _imageViews[i].Dock = DockStyle.Fill;
                
                _imageViews[i].MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(ImgView_MouseDoubleClick);
                _lblCameraStates[i].ImageIndex = 1;
                _lblTips[i].Text = _ipAddress[i];
                _lblTips[i].ForeColor = Color.Red;
                comBoxCameraSel.Items.Add($"吊弦相机_{_ipAddress[i]}");

                //ConnectCamera(i);//链接相机
            }
            if (comBoxCameraSel.Items.Count > 0) {
                comBoxCameraSel.SelectedIndex = 0;
            }
            //开启相机
            OpenCamera();
            timerConnState.Start();
        }

        private object obj = new object();
        private bool ConnectCamera(int i) {
            bool isConn = false;
            try {
                lock (obj) {
                    if (_hDevs[i] == IntPtr.Zero) {

                        IntPtr hDec = VideoM.Connection(_ipAddress[i], _iPort);
                        if (hDec != IntPtr.Zero) {
                            isConn = !string.IsNullOrEmpty(VideoM.GetCameraParam(hDec));
                            _hDevs[i] = hDec;
                        }

                    } else {
                        string sInfo = VideoM.GetCameraParam(_hDevs[i]);
                        isConn = !string.IsNullOrEmpty(sInfo);
                    }

                }
                // MessageBox.Show($"{i} 连通{isConn}");
                //VideoM.CloseRPC(hDec);
                //hDec = IntPtr.Zero;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            } catch {
                if (_hDevs[i] != IntPtr.Zero) {
                    VideoM.CloseRPC(_hDevs[i]);
                }
                _hDevs[i] = IntPtr.Zero;

            } finally {
                CameraConnState(i, isConn);
                // if (!isConn && _hDevs[i] != IntPtr.Zero) {
                //VideoM.CloseRPC(_hDevs[i]);
                //     _hDevs[i] = IntPtr.Zero;
                // }
            }
            return isConn;
        }
        //异步刷新
        private void CameraConnState(int i, bool isConn) {
            if (_lblTips[i].InvokeRequired) {
                Action<int, bool> a = CameraConnState;
                _lblTips[i].Invoke(a, i, isConn);
            } else {
                if (isConn) {
                    // _lblTips[i].ForeColor =  Color.gr ;
                    _lblCameraStates[i].ImageIndex = 0;
                    _lblTips[i].ForeColor = Color.Lime;
                } else {
                    _lblCameraStates[i].ImageIndex = 1;
                    _lblTips[i].ForeColor = Color.Red;
                }
            }
        }
        private void imgViewRefresh(int i) {
            if (_imageViews[i].InvokeRequired) {
                Action<int> a = imgViewRefresh;
                _imageViews[i].Invoke(a, i);
            } else {
                _imageViews[i].Refresh();
            }
        }
        private void OpenCamera() {
            _isRunVideoServ = true;
            Thread.Sleep(1000);
            CameraTask(0);
            CameraTask(1);
            CameraTask(2);
            CameraTask(3);
        }
        #region 显示控制

        //开启四个线程 链接相机
        private void CameraTask(int i) {
            CancellationToken token = _tokenSource[i].Token;
            _tasks[i] = new Task(async () =>
            {
                while (_isRunVideoServ) {
                    if (_tokenSource[i].IsCancellationRequested) {
                        return;
                    }

                    if (!ConnectCamera(i)) {
                        //若没有连通 休息10秒重试
                        Console.WriteLine($"{i}号相机，没有连通！");
                        _imageViews[i].LoadImg("ico/VideoNoFound.png");
                        imgViewRefresh(i);
                        await Task.Delay(5000);
                        continue;
                    }
                    long lTime = 0; int ih = 0, iw = 0;

                    VideoM.LoadImg(_imageViews[i], _hDevs[i], ref iw, ref ih, ref lTime);
                    imgViewRefresh(i);
                    // picVideo.Image = VideoM.GetImg(_hDec, ref iw, ref ih, ref lTime);
                    //lblCameraInfo.Text = VideoM.GetCameraParam(_hDevs[i]);                    
                    await Task.Delay(500);
                }
            }, token);
            _tasks[i].Start();
        }


        #endregion
        #region 参数设置
        /// <summary>
        /// FPS值(帧率)参数设置
        /// </summary>
        private void dInputFPS_ValueChanged(object sender, EventArgs e) {
            // SetBtnPos(dInputFPS.Location, dInputFPS.Width);
            btnSetFPSOk.Location = new Point(dInputFPS.Location.X + dInputFPS.Width + 3, dInputFPS.Location.Y);
            btnSetFPSOk.Visible = true;
            param = CameraParam.FrameRate;
            sParamValue = dInputFPS.Value.ToString();
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        private void dInputExposure_ValueChanged(object sender, EventArgs e) {
            SetBtnPos(dInputExposure.Location, dInputExposure.Width);
            param = CameraParam.Exposure;
            sParamValue = dInputExposure.Value.ToString();
        }




        /// <summary>
        /// 修改增益
        /// </summary>
        private void iInputGain_ValueChanged(object sender, EventArgs e) {
            SetBtnPos(iInputGain.Location, iInputGain.Width);
            param = CameraParam.Gain;
            sParamValue = iInputGain.Value.ToString();
        }

        /// <summary>
        /// 查找预置位
        /// </summary>
        private void btnCameraPosView_Click(object sender, EventArgs e) {
            Point p = new Point(panelPos.Location.X + iInputCameraPos.Location.X, panelPos.Top + iInputCameraPos.Top + iInputCameraPos.Height);
            dgvCameraPos.Location = p;
            dgvCameraPos.Visible = !dgvCameraPos.Visible;
            // btnCameraPosView.Image = dgvCameraPos.Visible ? Image.FromFile("img\\hideTB.png") : Image.FromFile("img\\showTB.png");
        }
        /// <summary>
        /// 设置是否触发-使能
        /// </summary>
        private void sBtnTriggerMode_ValueChanged(object sender, EventArgs e) {
            //SetBtnPos(iInputGain.Location, iInputGain.Width);
            param = CameraParam.TriggerMode;
            sParamValue = sBtnTriggerMode.Value ? "1" : "0";
            SetCameraParam();
        }


        #region 聚焦控制

        int _maxFocus = 79000;
        int _minFocus = 1000;
        /// <summary>
        /// 聚焦增加
        /// </summary> 
        private void btnFocusPlus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrValue.Value + iInputChgValue.Value;
            if (currValue > _maxFocus) {
                MessageBox.Show("聚焦调整超过最大值：" + _maxFocus);
                return;
            }
            param = CameraParam.FocusMinus;
            sParamValue = iInputChgValue.Value.ToString();
            iInputCurrValue.Value = currValue;
            SetCameraParam();
        }
        /// <summary>
        /// 聚焦减少
        /// </summary> 
        private void btnFocusMinus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrValue.Value - iInputChgValue.Value;
            if (currValue < _maxFocus) {
                MessageBox.Show("聚焦调整小于最小值：" + _minFocus);
                return;
            }
            param = CameraParam.FocusMinus;
            sParamValue = iInputChgValue.Value.ToString();
            iInputCurrValue.Value = currValue;
            SetCameraParam();
        }
        #endregion

        #region 云台控制 

        bool isLongAction = false; bool isfinish = false;
        private void btn_MouseDown(object sender, MouseEventArgs e) {
            ButtonX btn = (ButtonX)sender;
            switch (btn.Name) {
                case "btnUP":
                    param = CameraParam.MoveUp;
                    break;
                case "btnDown":
                    param = CameraParam.MoveDown;
                    break;
                case "btnLeft":
                    param = CameraParam.MoveLeft;
                    break;
                case "btnRight":
                    param = CameraParam.MoveRight;
                    break;
            }

            sParamValue = iInputMoveValue.Value.ToString();
            SetCameraParam();
            isfinish = false;
            isLongAction = true;
            timer1.Interval = 100;  //按下鼠标 发送动的指令。 100毫秒后如果鼠标放开 则 发送停止，否则
            timer1.Start();
        }
        private void btn_MouseUp(object sender, MouseEventArgs e) {
            if (isfinish) {
                param = CameraParam.MoveStop;
                sParamValue = "0";
                SetCameraParam();
                isLongAction = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e) {
            if (!isLongAction) {
                param = CameraParam.MoveStop;
                sParamValue = "0";
                SetCameraParam();
            }
            isfinish = true;
            timer1.Stop();

        }
        private void timer2_Tick(object sender, EventArgs e) {

        }


        /// <summary>
        /// 云台向上移动--- 一直动直到stop
        /// </summary>
        private void btnUP_Click(object sender, EventArgs e) {
            param = CameraParam.MoveUp;
            sParamValue = "16";
            SetCameraParam();
        }




        /// <summary>
        /// 云台向左移动--- 一直动直到stop
        /// </summary>

        private void btnLeft_Click(object sender, EventArgs e) {
            param = CameraParam.MoveLeft;
            sParamValue = "16";
            SetCameraParam();
        }
        /// <summary>
        /// 云台向右移动--- 一直动直到stop
        /// </summary>
        private void btnRight_Click(object sender, EventArgs e) {
            param = CameraParam.MoveRight;
            sParamValue = "16";
            SetCameraParam();
        }
        /// <summary>
        /// 云台向左移动--- 一直动直到stop
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e) {
            param = CameraParam.MoveDown;
            sParamValue = "16";
            SetCameraParam();
        }
        private void btnStop_Click(object sender, EventArgs e) {
            param = CameraParam.MoveStop;
            sParamValue = "0";
            SetCameraParam();
        }
        
        #endregion

        #region 确定相机参数
        /// <summary>
        /// 设置确定按钮位置
        /// </summary>
        private void SetBtnPos(Point location, int Width) {
            btnSetParamOk.Location = new Point(location.X + Width + 3, location.Y);
            btnSetParamOk.Visible = true;

        }
        /// <summary>
        /// 确定按钮点击 设置相机参数
        /// </summary>
        private void btnSetParamOk_Click(object sender, EventArgs e) {
            SetCameraParam();
            btnSetParamOk.Visible = false;

        }
        private void btnSetFPSOk_Click(object sender, EventArgs e) {
            SetCameraParam();
            btnSetFPSOk.Visible = false;
        }
        /// <summary>
        /// 设置相机参数
        /// </summary>
        private void SetCameraParam() {
            string str = "{\"" + param.ToString() + "\":" + sParamValue + "}";
            Boolean isSet = false;

            //设置被选中的相机
            if (comBoxCameraSel.SelectedIndex > -1) {
                int selInd = comBoxCameraSel.SelectedIndex;
                lock (obj1) {
                    bool re = VideoM.SetRPCParam(_hDevs[selInd], 0, str);
                    isSet = true;
                }
            }

            //bool re = VideoM.SetRPCParam(_hDec, 0, str);
            if (!isSet) {
                ToastNotification.Show(this, "请选择相机！");
            } else {
                ToastNotification.Show(this, param.ToString() + "参数设置成功！");
            }
        }

        #endregion

        #endregion

        #region 预置位设置
        /// <summary>
        /// 移动到预置位
        /// </summary>
        private void btnMoveTo_Click(object sender, EventArgs e) {
            param = CameraParam.MoveTo;
            sParamValue = iInputCameraPos.Value.ToString();
            SetCameraParam();
        }
        /// <summary>
        /// 设置预置位
        /// </summary>

        private void btnSetPos_Click(object sender, EventArgs e) {
            param = CameraParam.SetPos;
            sParamValue = iInputCameraPos.Value.ToString();
            SetCameraParam();
        }





        #endregion

        /// <summary>
        /// 双击放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgView_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e) {

            if (e.Button == MouseButtons.Left) {
                ShowOneImg((CtrlView)sender);
            }

        }
        bool isShowOne = false;//是否只显示一张图片
        private void ShowOneImg(CtrlView imgV) {
            int iRowId = 0, iColId = 0;
            if (imgV.Name == "cView1") {
                iRowId = 0; iColId = 0;
            } else if (imgV.Name == "cView2") {
                iRowId = 0; iColId = 1;
            } else if (imgV.Name == "cView3") {
                iRowId = 1; iColId = 0;
            } else if (imgV.Name == "cView4") {
                iRowId = 1; iColId = 1;
            }
            try {
                if (isShowOne) {
                    tbLayoutPanelRight.ColumnStyles[iColId].Width = 0.5f * tbLayoutPanelRight.Width;
                    tbLayoutPanelRight.ColumnStyles[1 - iColId].Width = 0.5f * tbLayoutPanelRight.Width;
                    tbLayoutPanelRight.RowStyles[iRowId].Height = 0.5f * tbLayoutPanelRight.Height;
                    tbLayoutPanelRight.RowStyles[1 - iRowId].Height = 0.5f * tbLayoutPanelRight.Height;
                    isShowOne = !isShowOne;
                } else {
                    //tbLayoutPanelRight.ColumnStyles[iColId].Width = 0.98f*tbLayoutPanelRight.Width;
                    //tbLayoutPanelRight.ColumnStyles[1 - iColId].Width = 0.02f * tbLayoutPanelRight.Width;
                    //tbLayoutPanelRight.RowStyles[iRowId].Height = 0.98f*tbLayoutPanelRight.Height;
                    //tbLayoutPanelRight.RowStyles[1 - iRowId].Height = 0.02f * tbLayoutPanelRight.Height; ;
                    tbLayoutPanelRight.ColumnStyles[iColId].Width = tbLayoutPanelRight.Width;
                    tbLayoutPanelRight.ColumnStyles[1 - iColId].Width = 0;
                    tbLayoutPanelRight.RowStyles[iRowId].Height = tbLayoutPanelRight.Height;
                    tbLayoutPanelRight.RowStyles[1 - iRowId].Height = 0;
                    isShowOne = !isShowOne;
                }
                imgV.Fit();
                //double mag = imgV.Width * 1.0 / imgV.Display.ImageSize.Width;
                //if (mag < 0.001) {
                //    return;
                //}
                //imgV.Display.Magnification = mag;
            } catch (Exception) {

            }
        }


        private void sBtnDisplay_ValueChanged(object sender, EventArgs e) {

            if (comBoxCameraSel.SelectedIndex > -1) {
                int selInd = comBoxCameraSel.SelectedIndex;
                if (sBtnDisplay.Value) {
                    CameraTask(selInd);
                } else {
                    if (_tasks[selInd].Status == TaskStatus.Running) {
                        _tokenSource[selInd].Cancel();
                    }
                }
            }

        }

        private void expandablePanel1_Click(object sender, EventArgs e) {

        }

        private void timer2_Tick_1(object sender, EventArgs e) {
            for (int i = 0; i < 4; i++) {
                _lblCameraStates[i].Visible = !_lblCameraStates[i].Visible;
            }
         }

        private void BtnState_MouseHover(object sender, EventArgs e) {
            ((Button)sender).BackgroundImage = Image.FromFile("ico/bgBtn.png");
        }

        private void BtnState_MouseLeave(object sender, EventArgs e) {
            ((Button)sender).BackgroundImage = null;
        }

                

        #region 接触网几何参数绘制

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
                    timeJH.Start();
                }
            }
        }
      
        Queue<JCWJH> lstJCWJH = new Queue<JCWJH>();
        private object obj1=new object();

        private void timeJH_Tick(object sender, EventArgs e) {
           
            
                int iCount = 0;
                JCWJH jh = new JCWJH();

                while (JcwReturn.JCW_OK == jcwlib.Jcw_PopResult(m_hjcw, ref jh)) {
                    lstJCWJH.Enqueue(jh);
                    //绘制图像   jh
                    if (jh.uiLineNum > 0) { //判断数量
                        line1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y);

                        if (jh.uiLineNum > 1) {
                            line2.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y);
                        }
                        if (jh.uiLineNum > 2) {
                            line3.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y);
                        }
                        if (jh.uiLineNum > 3) {
                            line4.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y);
                        }
                        //绘制point
                        if (jh.jcx[0].posi == JCWPosi.JCXP_DROPPER) {
                            points1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y, Color.Black);

                        } else if (jh.jcx[0].posi == JCWPosi.JCXP_POLE) {
                            points1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y, Color.Red);
                        }
                    }
                    iCount++;
                    if (lstJCWJH.Count > 1000) {
                        JCWJH jhGet = lstJCWJH.Dequeue();
                        if (jhGet.uiLineNum > 0) {
                            line1.Delete(0);
                            if (jhGet.uiLineNum > 1) {
                                line2.Delete(0);
                            }
                            if (jhGet.uiLineNum > 2) {
                                line3.Delete(0);
                            }
                            if (jhGet.uiLineNum > 3) {
                                line4.Delete(0);
                            }
                        }

                        if (jhGet.jcx[0].posi == JCWPosi.JCXP_DROPPER) {
                            points1.Delete(0);

                        } else if (jhGet.jcx[0].posi == JCWPosi.JCXP_POLE) {
                            points1.Delete(0);
                        }
                    }

                }

            }
        #endregion

    }
}
