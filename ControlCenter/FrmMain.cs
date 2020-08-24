
using ControlCenter.core;
using ControlCenter.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCenter {
    public partial class FrmMain : Form {
        public FrmMain() {
            InitializeComponent();
        }
        #region 任务操作-配置，开启持久化，停止任务
        MonitorTask _currTask = null;
        private void btnTaskConfig_Click(object sender, EventArgs e) {
            UI.TaskConfig taskConfig = new UI.TaskConfig();
            taskConfig.ShowDialog();
            _currTask = MonitorTask.GetTask();

            if (_currTask != null && _currTask.State != taskState.running) {
                lblTaskInfo.Text = $"{_currTask.LineName} {_currTask.SType} " +
                    $"{_currTask.StartStation}-{_currTask.EndStation}";
               
                //新建任务修改按钮状态
                ChBtnState(taskState.plan);
            }
        }
        /// <summary>
        /// 改变任务按钮状态
        /// </summary>
        /// <param name="taskState"></param>
        private void ChBtnState(taskState taskS) {
            switch (taskS) {
                case taskState.none:
                    btnTaskConfig.Enabled = true;
                    btnStartTask.Enabled = false;
                    btnStopTask.Enabled = false;
                    break;
                case taskState.plan://创建任务成功
                    btnStartTask.Enabled = true;
                    btnStopTask.Enabled = false;
                    break;
                case taskState.running:
                    btnStartTask.Enabled = false;
                    btnStopTask.Enabled = true;
                    break;
                case taskState.finish:
                    btnStopTask.Enabled = false;
                    btnStartTask.Enabled = false;

                    break;
                default:
                    break;
            }
        }

        private void ShowTaskMsg(string sMsg) {
            if (lblSaveImgNum.InvokeRequired) {
                Action<string> a = ShowTaskMsg;
                lblSaveImgNum.Invoke(a, sMsg);
            } else {
                try {
                    string[] s = sMsg.Split(':');
                    // taskMsg iMsg = (taskMsg)int.Parse(s[0]);
                    switch (s[0]) {
                        case "Msg":
                            string prex = DateTime.Now.ToString("#HH:mm:ss");
                            if (rTbTaskMsg.Lines.Count() > 60) {
                                rTbTaskMsg.Lines = rTbTaskMsg.Lines.Skip(5).ToArray();
                            }

                            rTbTaskMsg.AppendText($"{prex}->{s[1]}\n");
                            rTbTaskMsg.ScrollToCaret();
                            break;
                        case "Mem":
                            lblServMem.Text = s[1];
                            break;
                        case "Del":
                            lblDelNum.Text = $"Tip:#释放图像数量-[{s[2]}]-张";
                            break;
                        case "Img":
                            lblSaveImgNum.Text = s[1] + "张";
                            break;
                        //case "Loc":
                        //    lblSaveLocNum.Text = s[1] + "条";
                        //    break;
                        //case "Flt":
                        //    lblSaveFaultNum.Text = s[1] + "条";
                        //    break;
                        case "BackMsg": //最后消息处理
                            DialogTaskTip.GetInstance().SetTipTxt(s[1]);
                            new Thread(_currTask.TaskBackProc).Start();
                            DialogTaskTip.GetInstance().ShowDialog();
                            break;
                        case "EndMsg":
                            DialogTaskTip.GetInstance().EndProc();
                            break;
                    }
                } catch { }
            }
        }
        private void btnStartTask_Click(object sender, EventArgs e) {
            if (_currTask == null) {
                ComClassLib.MsgBox.Warning("当没有任务计划，请先配置任务!", "开启任务失败");
                return;
            }
            MonitorTask.CallInfo = ShowTaskMsg;
            //ChgPicState(picSaveDataState, true);
            //新建任务修改按钮状态Task
            ChBtnState(taskState.running);
            _currTask.TaskStart();
        }
        

        private void btnStopTask_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == ComClassLib.MsgBox.YesNo($"结束当前任务-{_currTask.TaskName}-！\n请确认！")) {
                _currTask.TaskEnd();
                ChBtnState(taskState.finish);
            }
            Thread.Sleep(2000);
            MonitorTask nextTask = MonitorTask.GetNextPlanTask(_currTask);
            if (nextTask != null && DialogResult.Yes == ComClassLib.MsgBox.YesNo($"存在计划任务-{nextTask.TaskName}-！\n是否自动开启？")) {
                _currTask = nextTask;
                lblTaskInfo.Text = $"{_currTask.LineName} {_currTask.SType} " +
                    $"{_currTask.StartStation}-{_currTask.EndStation}";
                //新建任务修改按钮状态Task
                ChBtnState(taskState.running);
                _currTask.TaskStart();
               
            }
        }
        #endregion

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Visible = !this.Visible;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Visible = false;
            notifyIcon1.ShowBalloonTip(5000, "提示", "双击还原总控平台", ToolTipIcon.Info);
        }
    }
}
