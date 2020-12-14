using System;
using System.Data;
using System.Windows.Forms;
using ComClassLib.core;
using ComClassLib.DB;
using DevComponents.DotNetBar;
using Project2C.DB;
using Project2C.Properties;
 

namespace Project2C.UI {
    public partial class FrmLogin : OfficeForm {
        public bool IsLogin;

        public FrmLogin() {
            IsLogin = false;
            InitializeComponent();
        }
         

        private void txtB_PWD_TextChanged(object sender, EventArgs e) {

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
            }
            catch (Exception e) {
                MessageBox.Show(@"登录数据库连接错误！");
                return false;
            }
            finally {
                gDb.CloseDb();
            }

        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtB_PWD.Text)) {
                lblInfo.Text = @"请输入密码！";
                txtB_PWD.SelectAll();
                txtB_PWD.Focus();
                return;
            }
            string pwd = Crypto.DesEncrypt(txtB_PWD.Text);
            IsLogin = LoginCheck(pwd);
            if (IsLogin) {
                this.Close();
            }
            else {
                lblInfo.Text = @"密码输入错误！";
                txtB_PWD.SelectAll();
                txtB_PWD.Focus();
            }
        }

        private void lblInfo_Click(object sender, EventArgs e) {

        }

        private void FrmLogin_Load(object sender, EventArgs e) {
            txtB_LoginID.Text = Settings.Default.loginUser;//载入已有用户名
            btnOk.Focus();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e) {
            if (!IsLogin)
                Application.Exit();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e) {
            if (IsLogin) return;
            if (MessageBox.Show(@"确定退出人工分析程序！", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
