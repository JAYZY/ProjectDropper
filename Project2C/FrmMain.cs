using Project2C.ChildFrm;
using Project2C.Properties;
using Project2C.UI;
using System;
using System.Windows.Forms;

namespace Project2C {

    public partial class FrmMain : DevComponents.DotNetBar.OfficeForm {


        #region 创建单实例对象
        private static FrmMain _frmParent;
        private static object _obj = new object();
        public static FrmMain GetInstance() {
            if (_frmParent == null) {
                lock (_obj) {
                    if (_frmParent == null)
                        _frmParent = new FrmMain();
                }
            }
            return _frmParent;
        }
        private FrmMain() {
           
            InitializeComponent();
           // this.styleManager1.ManagerStyle = eStyle.Office2007Blue;
        }
        #endregion

        //当前打开的子窗体
        private Form m_CurrentMdiChild;


        private void MainFrm_Shown(object sender, EventArgs e) {
            exPanelSide.Expanded = false;
           // FrmLogin frmLogin = new FrmLogin();
            //frmLogin.ShowDialog();
           // if (frmLogin.IsLogin) {
                Settings.Default.Save();
                lblItemName.Text = Settings.Default.loginUser + @"你好！";
                exPanelSide.Expanded = true;
                iniCtrl();
                FrmDataMgr frmDataMgr = new FrmDataMgr();
                ShowMdiChild(frmDataMgr);

          //  }

        }
        private void iniCtrl() {
            exBarGroupItemAnalyse.Enabled = false;
            exBarGroupItemReport.Enabled = false;
        }
        /// <summary>
        /// 打开子窗体 
        /// </summary>
        /// <param name="mdiForm"></param>
        /// <param name="isHideSide">是否隐藏左导航</param>
        private void ShowMdiChild(Form mdiForm, bool isHideSide = false) {
            if (m_CurrentMdiChild != null) {
                m_CurrentMdiChild.Close(); //关闭当前窗体
            }
            if (isHideSide)
                exPanelSide.Expanded = false;
            m_CurrentMdiChild = mdiForm; //本窗体设置成为当前窗体
            mdiForm.MdiParent = this;
            mdiForm.WindowState = FormWindowState.Maximized;
            mdiForm.Show();

        }

        private void btnItem_ViewAnalyse_Click(object sender, EventArgs e) {
            ShowMdiChild(new FrmAnalyse(), true);
        }
        public void DataSetSuccess() {
            exBarGroupItemAnalyse.Enabled = true;
            exBarGroupItemAnalyse.Expanded = true;
            exBarGroupItemReport.Expanded = true;
            exBarGroupItemReport.Enabled = true;
            ShowMdiChild(new FrmAnalyse(), true);
        }
        private void btnItem_DataSet_Click(object sender, EventArgs e) {
            ShowMdiChild(new FrmDataMgr());
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            (new ChildFrm.FrmWelcome()).ShowDialog();
        }

        private void btnItemExit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void btnItem_ViewReprot_Click(object sender, EventArgs e) {
            ShowMdiChild(new ChildFrm.FrmReport());
        }

        private void buttonItem5_Click(object sender, EventArgs e) {
            ShowMdiChild(new ChildFrm.FrmSet());
        }
    }
}
