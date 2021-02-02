using ComClassLib.core;
using ComClassLib.DB;
using Project2C.DB;
using Project2C.Properties;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace Project2C.ChildFrm {
    public partial class FrmWelcome : Form {
        public bool IsLogin;

        public FrmWelcome() {
            InitializeComponent();
            panelLogin.Visible = false;
          

        }

        private void timer1_Tick(object sender, EventArgs e) {
            // FrmMain.GetInstance().Show();
            timer1.Stop();
            //FrmMain.GetInstance().Show();
           // Thread.Sleep(2000);
            int x=this.Width / 2 - panelLogin.Width/2;
            int y = this.Height / 2 - panelLogin.Height/2;
            panelLogin.Location = new System.Drawing.Point(x, y);

            
            panelLogin.Visible = true;
            txtB_LoginID.Text = Settings.Default.loginUser;//载入已有用户名
            if (txtB_LoginID.Text.Trim() == "")
                txtB_LoginID.Focus();
            else
                txtB_PWD.Focus();

        }

        private void Login() {
            if (string.IsNullOrEmpty(txtB_PWD.Text)) {
                lblInfo.Text = @"请输入密码！";
                txtB_PWD.SelectAll();
                txtB_PWD.Focus();
                return;
            }
            string pwd = Crypto.DesEncrypt(txtB_PWD.Text);
            IsLogin = LoginCheck(pwd);
            if (IsLogin) {
                this.Hide();
                FrmMain.GetInstance().Show();

            } else {
                lblInfo.Text = @"密码输入错误！";
                txtB_PWD.SelectAll();
                txtB_PWD.Focus();
            }
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="pwd">密码</param>
        /// <returns>返回验证结果</returns>
        private bool LoginCheck(string pwd) {
            SqliteHelper gDb = SqliteHelper.GetSqlite(DataType.DbName.LoginDb.ToString());
            try {
                //SqliteHelper.DbPath = Application.StartupPath + "/DB/globalDb.db";

                string sQuery = "";
                int iLoginId;

                if (int.TryParse(txtB_LoginID.Text, out iLoginId)) //使用的登陆编号
                    sQuery = string.Format("select * from logintable where userLoginId='{0}' and userPwd='{1}'",
                        iLoginId, pwd);
                else
                    sQuery = string.Format("select * from logintable where userName='{0}' and userPwd='{1}'",
                        txtB_LoginID.Text, pwd);

                DataTable dt = gDb.ExecuteDataTable(sQuery, null);
                if (dt.Rows.Count > 0) {
                    Settings.Default.loginId = dt.Rows[0]["loginId"].ToString();
                    Settings.Default.loginUser = dt.Rows[0]["userName"].ToString();
                    gDb.CloseDb();
                    return true;
                }
                gDb.CloseDb();
                return false;
            } catch (Exception e) {
                MessageBox.Show(@"登录数据库连接错误！");
                return false;
            } finally {
                gDb.CloseDb();
            }

        }

        private void LoadGlobalDb() {
            SqliteHelper gSqlite = SqliteHelper.GenerateSqlite(DataType.DbName.LoginDb.ToString(), Application.StartupPath + "/DB/globalDb.db");
            //gSqlite.CloseDb();
             FrmMain.GetInstance();
            


            timer1.Start();
        }

        private void FrmWelcome_Shown(object sender, EventArgs e) {

            LoadGlobalDb();


            //FrmLogin frmLogin = new FrmLogin();
            //frmLogin.ShowDialog();
            //if (frmLogin.IsLogin) {
            //    Settings.Default.Save();
            //    //lblItemName.Text = Settings.Default.loginUser + @"你好！";
            //} 
        }

        private void btnOk_Click(object sender, EventArgs e) {
            Login();
        }

        private void FrmWelcome_FormClosing(object sender, FormClosingEventArgs e) {
            if (IsLogin) return;
            if (MessageBox.Show(@"确定退出人工分析程序！", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                e.Cancel = true;
        }

        private void FrmWelcome_FormClosed(object sender, FormClosedEventArgs e) {
            if (!IsLogin)
                Application.Exit();
        }

        private void picBoxExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
