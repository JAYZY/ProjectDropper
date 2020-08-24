using ComClassLib;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProjectDropper.core;
using ProjectDropper.Properties;
using System;
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
        protected Label[] lblTips;
        private CheckBoxX[] _ckBoxs;
        private int _iPort;//端口统一
        private System.Windows.Forms.Timer[] _videoDisplays;
        private CancellationTokenSource[] _tokenSource;
        //private CancellationToken[] _token;
        private ManualResetEvent _resetEvent;
        private Task[] _tasks;
        bool _isRunVideoServ = false;
        public FrmMain() {
            InitializeComponent();
            IniCtrl();
        }
        private void IniCtrl() {
            _tasks = new Task[4];
            _hDevs = new IntPtr[4] { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero };
            _imageViews = new CtrlView[] { new CtrlView(), new CtrlView(), new CtrlView(), new CtrlView() };
            _ipAddress = new string[] { Settings.Default.cameraIPA, Settings.Default.cameraIPB, Settings.Default.cameraIPC, Settings.Default.cameraIPD };
            _iPort = Settings.Default.cameraPort;
            _imgPanels = new Panel[] { panelImgA, panelImgB, panelImgC, panelImgD };
            lblTips = new Label[] { lblTipA, lblTipB, lblTipC, lblTipD };
            lblTipA.ForeColor = lblTipB.ForeColor = lblTipC.ForeColor = lblTipD.ForeColor = Color.White;
            _ckBoxs = new CheckBoxX[] { cboxA, cboxB, cboxC, cboxD };
            cboxA.ForeColor = cboxB.ForeColor = cboxC.ForeColor = cboxD.ForeColor = Color.Red;
            /// 任务初始化
            _tokenSource = new CancellationTokenSource[] { new CancellationTokenSource(), new CancellationTokenSource(), new CancellationTokenSource(), new CancellationTokenSource() };

            _resetEvent = new ManualResetEvent(true);
            //
            for (int i = 0; i < _imgPanels.Length; i++) {
                //_token[i] = _tokenSource[i].Token;
                _imgPanels[i].Controls.Add(_imageViews[i]);
                _imageViews[i].Dock = DockStyle.Fill;
                lblTips[i].Text = _ipAddress[i];
                //ConnectCamera(i);//链接相机
            }
            //开启相机
            OpenCamera();
        }


        private bool ConnectCamera(int i) {
            bool isConn = false;
            try {
                if (_hDevs[i] == IntPtr.Zero) {
                    string ipAddr = _ipAddress[i];
                    IntPtr hDec = VideoM.Connection(ipAddr, _iPort);
                    if (hDec != IntPtr.Zero) {
                        isConn = !string.IsNullOrEmpty(VideoM.GetCameraParam(hDec));
                        _hDevs[i] = hDec;

                    }
                } else {
                    string sInfo = VideoM.GetCameraParam(_hDevs[i]);
                    isConn = !string.IsNullOrEmpty(sInfo);
                }
                _ckBoxs[i].ForeColor = isConn ? Color.Green : Color.Red;

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
                // if (!isConn && _hDevs[i] != IntPtr.Zero) {
                //VideoM.CloseRPC(_hDevs[i]);
                //     _hDevs[i] = IntPtr.Zero;
                // }
            }
            return isConn;
        }


        private void OpenCamera() {
            Thread.Sleep(5000);
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
                        await Task.Delay(10000);
                        continue;
                    }
                    long lTime = 0; int ih = 0, iw = 0;

                    VideoM.LoadImg(_imageViews[i], _hDevs[i], ref iw, ref ih, ref lTime);
                    // picVideo.Image = VideoM.GetImg(_hDec, ref iw, ref ih, ref lTime);
                    //lblCameraInfo.Text = VideoM.GetCameraParam(_hDevs[i]);                    
                    await Task.Delay(5000);
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
            sParamValue = sBtnTriggerMode.Value ? "true" : "false";
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
                sParamValue = "";
                SetCameraParam();
                isLongAction = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e) {
            if (!isLongAction) {
                param = CameraParam.MoveStop;
                sParamValue = "";
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
            sParamValue = "5";
            SetCameraParam();
        }




        /// <summary>
        /// 云台向左移动--- 一直动直到stop
        /// </summary>

        private void btnLeft_Click(object sender, EventArgs e) {
            param = CameraParam.MoveLeft;
            sParamValue = "5";
            SetCameraParam();
        }
        /// <summary>
        /// 云台向右移动--- 一直动直到stop
        /// </summary>
        private void btnRight_Click(object sender, EventArgs e) {
            param = CameraParam.MoveRight;
            sParamValue = "5";
            SetCameraParam();
        }
        /// <summary>
        /// 云台向左移动--- 一直动直到stop
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e) {
            param = CameraParam.MoveDown;
            sParamValue = "5";
            SetCameraParam();
        }
        private void btnStop_Click(object sender, EventArgs e) {
            param = CameraParam.MoveStop;
            sParamValue = "";
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
            for (int i = 0; i < _ckBoxs.Length; i++) {
                if (_ckBoxs[i].Checked && _hDevs[i] != null) {
                    bool re = VideoM.SetRPCParam(_hDevs[i], 0, str);
                    isSet = true;
                }
            }
            //bool re = VideoM.SetRPCParam(_hDec, 0, str);
            if (!isSet) {
                ToastNotification.Show(this, "没有相机被选中，请确认！");
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

        private void sBtnDisplay_ValueChanged(object sender, EventArgs e) {
            
            for (int i = 0; i < _ckBoxs.Length; i++) {
                if (_ckBoxs[i].Checked) {
                    if (sBtnDisplay.Value) {
                        CameraTask(i);
                    } else {
                        if (_tasks[i].Status == TaskStatus.Running) {
                            _tokenSource[i].Cancel();
                        }
                    }
                }
            }
        }
    }
}
