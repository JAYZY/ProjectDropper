﻿using ComClassLib;
using ComClassLib.core;
using ComClassLib.FileOp;
using DevComponents.DotNetBar;
using ProjectDropper.core;
using ProjectDropper.Properties;
using ProjectDropper.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDropper {
    public partial class FrmMain : Form {

        enum CameraParam {
            SetCurTaskName,
            Gain, //增益 0.0-30.0
            Exposure, //曝光时间  60u
            FocusMinus, //聚焦  默认200 <1000
            FocusPlus,
            LEDWidth,   //补光灯 最小50（关闭）  最大500
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
            Restart,
            ZoomMinus, //变焦+  9000
            ZoomPlus,  //变焦-  10
            IrisMinus, //光圈+  70
            IrisPlus,   //光圈- 10
            StartInspect,
            StopInspect,
        }

        string[] arrParam = {"SetCurTaskName", "Gain", "Exposure", "FocusMinus", "FocusPlus", "LEDWidth", "EnableLED", "FrameRate", "TriggerMode", "MoveUp", "MoveDown", "MoveLeft", "MoveRight", "MoveStop", "MoveTo", "SetPos", "RemovePos", "ShutDown", "Restart"
        ,"ZoomMinus","ZoomPlus","IrisMinus","IrisPlus","StartInspect","StopInspect"};

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
        private NetworkHelper[] _cameraNW;
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
            _tasks = new Task[2];
            _hDevs = new IntPtr[2] { IntPtr.Zero, IntPtr.Zero };
            _imageViews = new CtrlView[] { new CtrlView("cView1"), new CtrlView("cView2") };
            _ipAddress = new string[] { Settings.Default.cameraIPA, Settings.Default.cameraIPB };

            _iPort = Settings.Default.cameraPort;
            _cameraNW = new NetworkHelper[] { new NetworkHelper(_ipAddress[0], _iPort), new NetworkHelper(_ipAddress[1], 502) };
            _cameraNW[0].Receive(); _cameraNW[1].Receive();
            _imgPanels = new Panel[] { panelImgA, panelImgB };
            _lblTips = new Label[] { lblTipA, lblTipB };
            // lblTipA.ForeColor = lblTipB.ForeColor = lblTipC.ForeColor = lblTipD.ForeColor = Color.White;
            _lblCameraStates = new Label[] { lblCameraStateA, lblCameraStateB };

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
            dInputFPS.Tag = 0; dInputExposure.Tag = 0; iInputGain.Tag = 0; dInputLEDWidth.Tag = 0;
            dInputFPS.LostFocus += new EventHandler(InputCtlParam_LostFocus); //添加失去焦点事件
            dInputExposure.LostFocus += new EventHandler(InputCtlParam_LostFocus); //添加失去焦点事件
            iInputGain.LostFocus += new EventHandler(InputCtlParam_LostFocus); //添加失去焦点事件
            dInputLEDWidth.LostFocus += new EventHandler(InputCtlParam_LostFocus); //添加失去焦点事件


            dInputFPS.GotFocus += new EventHandler(InputCtlParam_GotFocus); //添加失去焦点事件
            dInputExposure.GotFocus += new EventHandler(InputCtlParam_GotFocus); //添加失去焦点事件
            iInputGain.GotFocus += new EventHandler(InputCtlParam_GotFocus); //添加失去焦点事件
            dInputLEDWidth.GotFocus += new EventHandler(InputCtlParam_GotFocus); //添加失去焦点事件

            //开启相机
            OpenCamera();
            timerConnState.Start();
            //开始相机状态刷新
            // timerCameraStateUpdate.Start();
        }


        /// <summary>
        /// 获取相机参数
        /// </summary>
        private   string GetCameraParam(IntPtr hDec)
        {
            string sRtn = string.Empty;
            if (hDec != IntPtr.Zero)
            {
                try
                {
                    byte[] info = new byte[1024];
                    int len =VideoM.GetRpcInfo(hDec, 0, ref info[0], info.Length);
                    sRtn = Encoding.ASCII.GetString(info);//Marshal.PtrToStringAnsi(ipStr);
                    if (sRtn.Length < 20)
                    {
                        sRtn = string.Empty;
                    }

                }
                catch (Exception)
                {
                    sRtn = string.Empty;
                    Console.WriteLine("设备打开失败！");
                }
            }
            return sRtn;
        }

        private object obj = new object();
        private bool ConnectCamera(int i) {
            string sInfo = "";
            bool isConn = false;
            try {
                lock (obj) {
                    if (_hDevs[i] == IntPtr.Zero) {

                        IntPtr hDec = VideoM.Connection(_ipAddress[i], _iPort);
                        if (hDec != IntPtr.Zero) {
                            isConn = !string.IsNullOrEmpty(GetCameraParam(hDec));
                            _hDevs[i] = hDec;
                        }
                    } else {
                        sInfo = GetCameraParam(_hDevs[i]);
                        isConn = !string.IsNullOrEmpty(sInfo);
                    }

                }
                // MessageBox.Show($"{i} 连通{isConn}");
                //VideoM.CloseRPC(hDec);
                //hDec = IntPtr.Zero;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            } catch(Exception ex){
                MessageBox.Show(ex.ToString());
                if (_hDevs[i] != IntPtr.Zero) {
                    VideoM.CloseRPC(_hDevs[i]);
                }
                _hDevs[i] = IntPtr.Zero;
                

            } finally {
                CameraConnState(i, sInfo, isConn);
                // if (!isConn && _hDevs[i] != IntPtr.Zero) {
                //VideoM.CloseRPC(_hDevs[i]);
                //     _hDevs[i] = IntPtr.Zero;
                // }
            }
            return isConn;
        }
        //异步刷新
        private void CameraConnState(int i, string sjson, bool isConn) {
            try {

           
            if (_lblTips[i].InvokeRequired) {
                Action<int, string, bool> a = CameraConnState;
                _lblTips[i].Invoke(a, i, sjson, isConn);
            } else {
                if (isConn) {
                    // _lblTips[i].ForeColor =  Color.gr ;
                    _lblCameraStates[i].ImageIndex = 0;
                    _lblTips[i].ForeColor = Color.Lime;
                    if (i == comBoxCameraSel.SelectedIndex) {
                        UpdateCameraState(sjson);
                    }
                } else {
                    _lblCameraStates[i].ImageIndex = 1;
                    _lblTips[i].ForeColor = Color.Red;
                }
            }
            } catch (Exception ex) {

                MsgBox.Show(ex.ToString());
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

        }
        #region 显示控制

        //开启四个线程 链接相机
        private void CameraTask(int i) {
            try {
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
                            await Task.Delay(Settings.Default.ReconnectTime);
                            continue;
                        }
                        long lTime = 0; int ih = 0, iw = 0;

                        VideoM.LoadImg(_imageViews[i], _hDevs[i], ref iw, ref ih, ref lTime);
                        imgViewRefresh(i);
                        // picVideo.Image = VideoM.GetImg(_hDec, ref iw, ref ih, ref lTime);
                        //lblCameraInfo.Text = VideoM.GetCameraParam(_hDevs[i]);                    
                        await Task.Delay(Settings.Default.RateViewTime);
                    }
                }, token);
                _tasks[i].Start();
            } catch (Exception ex) {
                MsgBox.Show(ex.ToString());
            }
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
                    exPanelJHCS.Expanded = true;
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
                    exPanelJHCS.Expanded = false;
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

        /// <summary>
        /// 显示标签闪烁
        /// </summary>
        private void timer2_Tick_1(object sender, EventArgs e) {
            for (int i = 0; i < _lblCameraStates.Length; i++) {
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
        private object obj1 = new object();

        private void timeJH_Tick(object sender, EventArgs e) {


            int iCount = 0;
            JCWJH jh = new JCWJH();

            while (JcwReturn.JCW_OK == jcwlib.Jcw_PopResult(m_hjcw, ref jh)) {
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
                        lczPoint.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.x, Color.Black);

                    } else if (jh.jcx[0].posi == JCWPosi.JCXP_POLE) {
                        points1.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.y, Color.Red);
                        lczPoint.Add(jh.dTimestamp, jh.jcx[0].pntLinePos.x, Color.Red);
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
                        lczPoint.Delete(0);

                    } else if (jhGet.jcx[0].posi == JCWPosi.JCXP_POLE) {
                        points1.Delete(0);
                        lczPoint.Delete(0);
                    }
                }

            }

        }
        #endregion


        #region 参数设置
        private double currFPS;
        private double currExposure;
        private int currGain;
        private int currLEDW;





        //当控件失去焦点，1.启动计时器（2秒后）隐藏按钮
        private void InputCtlParam_LostFocus(object sender, EventArgs e) {
            // Thread.Sleep(2000);
            //btnSetParamOk.Visible = false;
            Thread th = new Thread(new ParameterizedThreadStart(HideCtrl));
            th.Start(sender);

        }
        //控件获取焦点--表明准备修改值
        private void InputCtlParam_GotFocus(object sender, EventArgs e) {
            ((Control)sender).Tag = 1;
        }

        private void InputCtrl_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                btnSetFPSOk.Visible = false;
                btnSetParamOk.Visible = false;
                SetCameraParam();
                ((Control)sender).Tag = 0;
            }
        }


        private void HideCtrl(Object ctl) {
            try {
                Thread.Sleep(1000);
                ((Control)ctl).Tag = 0;
            } catch (Exception e) {

                MsgBox.Show(e.ToString());
            }
        }


        /// <summary>
        /// FPS值(帧率)参数设置
        /// </summary>
        private void dInputFPS_ValueChanged(object sender, EventArgs e) {
            if (!dInputFPS.Focused) {
                return;
            }
            btnSetFPSOk.Location = new Point(dInputFPS.Location.X + dInputFPS.Width + 3, dInputFPS.Location.Y);
            btnSetFPSOk.Visible = true;
            param = CameraParam.FrameRate;
            sParamValue = dInputFPS.Value.ToString();

        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        private void dInputExposure_ValueChanged(object sender, EventArgs e) {
            if (!dInputExposure.Focused) {
                return;
            }
            SetBtnPos(dInputExposure.Location, dInputExposure.Width);
            param = CameraParam.Exposure;
            sParamValue = dInputExposure.Value.ToString();
        }




        /// <summary>
        /// 修改增益
        /// </summary>
        private void iInputGain_ValueChanged(object sender, EventArgs e) {
            if (!iInputGain.Focused) {
                return;
            }
            SetBtnPos(iInputGain.Location, iInputGain.Width);
            param = CameraParam.Gain;
            sParamValue = iInputGain.Value.ToString();
        }

        /// <summary>
        /// 补光灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dInputLEDWidth_ValueChanged(object sender, EventArgs e) {
            if (!dInputLEDWidth.Focused) {
                return;
            }
            SetBtnPos(dInputLEDWidth.Location, dInputLEDWidth.Width);
            param = CameraParam.LEDWidth;
            sParamValue = dInputLEDWidth.Value.ToString();
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
            int currValue = iInputCurrFocusValue.Value + iInputChgFocusValue.Value;
            if (currValue > _maxFocus) {
                MessageBox.Show("聚焦调整超过最大值：" + _maxFocus);
                return;
            }
            param = CameraParam.FocusPlus;
            sParamValue = iInputChgFocusValue.Value.ToString();
            // iInputCurrFocusValue.Value = currValue;
            SetCameraParam();
        }
        /// <summary>
        /// 聚焦减少
        /// </summary> 
        private void btnFocusMinus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrFocusValue.Value - iInputChgFocusValue.Value;
            if (currValue < _minFocus) {
                MessageBox.Show("聚焦调整小于最小值：" + _minFocus);
                return;
            }
            param = CameraParam.FocusMinus;
            sParamValue = iInputChgFocusValue.Value.ToString();
            iInputCurrFocusValue.Value = currValue;
            SetCameraParam();
        }
        #endregion
        #region 光圈控制
        int _maxIris = 70;
        int _minIris = 10;
        /// <summary>
        /// 光圈减少
        /// </summary>
        private void btnIrisMinus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrIrisValue.Value - iInputIrisChgValue.Value;

            if (currValue < _minIris) {
                MessageBox.Show("光圈调整小于最小值：" + _minIris);
                return;
            }
            param = CameraParam.IrisMinus;
            sParamValue = iInputIrisChgValue.Value.ToString();
            iInputCurrIrisValue.Value = currValue;
            SetCameraParam();
        }

        /// <summary>
        /// 光圈增加
        /// </summary>
        private void btnIrisPlus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrIrisValue.Value + iInputIrisChgValue.Value;

            if (currValue > _maxIris) {
                MessageBox.Show("光圈调整超过最大值：" + _maxIris);
                return;
            }
            param = CameraParam.IrisPlus;
            sParamValue = iInputIrisChgValue.Value.ToString();
            iInputCurrIrisValue.Value = currValue;
            SetCameraParam();
        }
        #endregion

        #region 焦距控制
        int _maxZoom = 9000;
        int _minZoom = 10;
        private void btnZoomMinus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrZoomValue.Value - iInputZoomChgValue.Value;
            if (currValue < _minZoom) {
                MessageBox.Show("聚焦调整小于最小值：" + _minZoom);
                return;
            }
            param = CameraParam.ZoomMinus;
            sParamValue = iInputZoomChgValue.Value.ToString();
            iInputCurrZoomValue.Value = currValue;
            SetCameraParam();
        }

        private void btnZoomPlus_Click(object sender, EventArgs e) {
            int currValue = iInputCurrZoomValue.Value + iInputZoomChgValue.Value;
            if (currValue < _minZoom) {
                MessageBox.Show("聚焦调整超过最大值：" + _maxZoom);
                return;
            }
            param = CameraParam.ZoomPlus;
            sParamValue = iInputZoomChgValue.Value.ToString();
            iInputCurrZoomValue.Value = currValue;
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
            string str = "{\"" + param.ToString() + "\":\"" + sParamValue + "\"}";
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
            panelRight.Enabled = false;
            Thread.Sleep(1000);
            panelRight.Enabled = true;
        }

        #endregion



        /// <summary>
        /// 相机状态更新
        /// </summary>
        /// <param name="strJson"></param>
        private void UpdateCameraState(string strJson) {
            if (string.IsNullOrEmpty(strJson)) {
                return;
            }

            lock (obj1) {

                try {
                    CameraInfo cameraInfo = JsonHelper.GetModel<CameraInfo>(strJson);
                    if (cameraInfo == null)
                        return;
                    if (!dInputFPS.Focused && (int)dInputFPS.Tag == 0) {
                        dInputFPS.Value = cameraInfo.Fps;
                        currFPS = cameraInfo.Fps;
                    }
                    if (!dInputExposure.Focused && (int)dInputExposure.Tag == 0) {
                        dInputExposure.Value = cameraInfo.Exposure;
                        currExposure = cameraInfo.Exposure;
                    }
                    if (!dInputLEDWidth.Focused && (int)dInputLEDWidth.Tag == 0) {
                        dInputLEDWidth.Value = cameraInfo.LEDWidth;
                        currLEDW = cameraInfo.LEDWidth;
                    }
                    if (!iInputGain.Focused && (int)iInputGain.Tag == 0) {
                        iInputGain.Value = (int)cameraInfo.Gain;
                        currGain = iInputGain.Value;
                    }
                    iInputCurrFocusValue.Value = cameraInfo.FocusPos;
                    iInputCurrZoomValue.Value = cameraInfo.ZoomPos;
                    iInputCurrIrisValue.Value = cameraInfo.IrisPos;

                    lblCameraState.Text = cameraInfo.Status == 0 ? "停 止" : "工作中";
                } catch (Exception e) {

                    MsgBox.Show(e.ToString());
                }
            }
        }

        #endregion

        private void comBoxCameraSel_SelectedIndexChanged(object sender, EventArgs e) {
            timerSendTaskName.Stop();
            Thread.Sleep(1000);
            timerSendTaskName.Start();
        }
        #region 任务管理


        taskState tState = taskState.none;
        MonitorTask _currTask = null;
        private void btnItemNewTask_Click(object sender, EventArgs e) {
            UI.TaskConfig taskConfig = new UI.TaskConfig();

            taskConfig.ShowDialog();
            _currTask = MonitorTask.GetTask();

            if (_currTask != null && _currTask.State != taskState.running) {
                lblTaskInfo.Text = $"{_currTask.LineName} {_currTask.SType} " +
                    $"{_currTask.StartStation}-{_currTask.EndStation}";

                //新建任务修改按钮状态
                tState = taskState.plan;
                ChBtnState(tState);
            }
        }
        /// <summary>
        /// 改变任务按钮状态
        /// </summary>
        /// <param name="taskState"></param>
        private void ChBtnState(taskState taskS) {
            switch (taskS) {
                case taskState.none:
                    btnItemNewTask.Enabled = true;
                    btnItemBeginTask.Enabled = false;
                    btnItemStopTask.Enabled = false;
                    break;
                case taskState.plan://创建任务成功
                    btnItemBeginTask.Enabled = true;
                    btnItemStopTask.Enabled = false;
                    break;
                case taskState.running:
                    btnItemNewTask.Enabled = false;
                    btnItemBeginTask.Enabled = false;
                    btnItemStopTask.Enabled = true;
                    break;
                case taskState.finish:
                    btnItemNewTask.Enabled = true;
                    btnItemBeginTask.Enabled = false;
                    btnItemStopTask.Enabled = false;

                    break;
                default:
                    break;
            }
        }

        private string dateTimeTaskStr = "";
        private void btnItemBeginTask_Click(object sender, EventArgs e) {
            try {
                ExitWarning exitW = new ExitWarning($"确认结束当前任务{_currTask.TaskName}？");
                DialogResult dr = exitW.ShowDialog();
                if (_currTask == null) {
                    MsgBox.Warning("当没有任务计划，请先配置任务!", "开启任务失败");
                    return;
                }
                DateTime dt = DateTime.Now;
                string dateStr = dt.ToString("yyyy_MM_dd");
                dateTimeTaskStr = dt.ToString("yyyy_MM_dd_HH_mm_ss") + "_[" + _currTask.LineName + "-" + _currTask.TaskName + "]";
                string rootPath = Path.Combine(Settings.Default.DBPath, dateStr, dateTimeTaskStr);
                MessageBox.Show(rootPath);
                if (false == FileHelper.CreateDir(rootPath)) {
                    MsgBox.Error("路径创建错误，不能开始任务，请检查磁盘!\n " + rootPath);
                    return;
                }
                MsgBox.Show("send xc");
                //发送接触网存储指令
                jcwlib.Jcw_CloseDebugDataFile(m_hjcw);
                jcwlib.Jcw_CreateDebugDataFile(m_hjcw, Path.Combine(rootPath, dateTimeTaskStr + "_几何.db"));
                //发送相机指令
                MsgBox.Show("xjk");
                param = CameraParam.StartInspect;
                sParamValue = dateTimeTaskStr;
                SetTaskState();
                tState = taskState.running;
                timerSendTaskName.Start();
                //发送开始命令
                ChBtnState(tState);
                MsgBox.Show("xjk2");
            } catch (Exception ex) {
                MsgBox.Show(ex.ToString());
            }
        }


        private void btnItemStopTask_Click(object sender, EventArgs e) {
            ExitWarning exitW = new ExitWarning($"确认结束当前任务{_currTask.TaskName}？");
            DialogResult dr = exitW.ShowDialog();   //if (DialogResult.Yes == ComClassLib.MsgBox.YesNo($"结束当前任务-{_currTask.TaskName}-！\n请确认！"))
            if (dr == DialogResult.OK) {
                try {
                    _currTask.TaskEnd();
                    MsgBox.Show("ok1");
                    jcwlib.Jcw_CloseDebugDataFile(m_hjcw);
                    MsgBox.Show("ok2");
                    timerSendTaskName.Stop();
                    param = CameraParam.StopInspect;
                    sParamValue = "";
                    SetTaskState();
                    MsgBox.Show("ok3");
                    dateTimeTaskStr = "";
                    tState = taskState.finish;
                    ChBtnState(tState);

                    MsgBox.Show("ok4");
                    Thread.Sleep(1000);
                    MsgBox.Show("ok5");
                    MonitorTask nextTask = MonitorTask.GetNextPlanTask(_currTask);
                    MsgBox.Show("ok6");
                    if (nextTask != null && DialogResult.Yes == ComClassLib.MsgBox.YesNo($"存在计划任务-{nextTask.TaskName}！\n是否自动开启？")) {
                        _currTask = nextTask;
                        lblTaskInfo.Text = $"{_currTask.LineName} {_currTask.SType} " +
                            $"{_currTask.StartStation}-{_currTask.EndStation}";
                        //新建任务修改按钮状态Task
                        tState = taskState.running;
                        ChBtnState(tState);
                        param = CameraParam.StartInspect;
                        sParamValue = $"{_currTask.LineName}-{_currTask.TaskName}";
                        SetTaskState();
                        timerSendTaskName.Start();
                    }
                } catch (Exception ex) {

                    MsgBox.Show(ex.ToString());

                }
            }
        }
        /// <summary>
        /// 设置任务状态
        /// </summary>
        private void SetTaskState() {
            string str = "{\"" + param.ToString() + "\":\"" + sParamValue + "\" }";
            Boolean isSucc = false;

            //设置被选中的相机
            if (comBoxCameraSel.SelectedIndex > -1) {
                for (int i = 0; i < _hDevs.Length; ++i) {
                    lock (obj1) {
                        isSucc = VideoM.SetRPCParam(_hDevs[i], 0, str);
                    }
                }
            }
        }



        #endregion



        #region 系统关闭

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (tState == taskState.running) {
                MsgBox.Error("正在运行任务，请先停止任务，再退出！");
                isClose = false;
                e.Cancel = true;
                return;
            }

            if (!isClose) {
                ExitWarning exitW = new ExitWarning("确认退出系统？");
                DialogResult dr = exitW.ShowDialog();
                if (dr == DialogResult.OK) {
                    isClose = true;
                    Application.Exit();
                } else {
                    isClose = false;
                    e.Cancel = true;
                }
            }
        }
        bool isClose = false;

        /// <summary>
        /// 一键关闭系统
        /// </summary>

        private void btnClossAllSystem_Click(object sender, EventArgs e) {
            if (tState == taskState.running) {
                MsgBox.Warning("无法一键关闭系统", "任务正在运行中，请先停止任务！");
                return;
            }
            param = CameraParam.ShutDown;
            sParamValue = "";
            SetTaskState();

            ChBtnState(taskState.finish);
        }

        #endregion

        /// <summary>
        /// 定时给相机发送 任务名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSendTaskName_Tick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(dateTimeTaskStr)) {
                return;
            }

            param = CameraParam.SetCurTaskName;
            sParamValue = dateTimeTaskStr;
            SetTaskState();
        }
        #region 关闭/上电

          byte[] cmdClose = Encoding.ASCII.GetBytes("00 00 00 00 00 06 01 05 00 04 00 00");
        byte[] cmdOpen = Encoding.ASCII.GetBytes("00 00 00 00 00 06 01 05 00 04 FF 00");

        private void sBtnItemONOFF_ValueChanged(object sender, EventArgs e) {
            SwitchButtonItem sBtnItem = (SwitchButtonItem)sender;
            int ind = sBtnItem.Name.Equals("sBtnItemONOFFA") ? 0 : 1;
            
            if (sBtnItem.Value) {
                _cameraNW[ind].Send(cmdOpen);
                ToastNotification.Show(this, _ipAddress[ind] + ":相机上电！");
            } else {
                _cameraNW[ind].Send(cmdClose);
                ToastNotification.Show(this, _ipAddress[ind] + ":相机关闭！");
            }
        }
        
        #endregion
    }
}
