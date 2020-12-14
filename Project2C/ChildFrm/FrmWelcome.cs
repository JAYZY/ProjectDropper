using ComClassLib.core;
using ComClassLib.DB;
using System;
using System.Windows.Forms;

namespace Project2C.ChildFrm {
    public partial class FrmWelcome : Form {
        public FrmWelcome() {
            InitializeComponent();
            LoadGlobalDb();

        }

        private void timer1_Tick(object sender, EventArgs e) {
            // FrmMain.GetInstance().Show();
            this.Hide();


        }
        private void LoadGlobalDb() {

            SqliteHelper gSqlite = SqliteHelper.GenerateSqlite(DataType.DbName.LoginDb.ToString(), Application.StartupPath + "/DB/globalDb.db");
            //gSqlite.CloseDb();
            timer1.Start();
        }

        private void FrmWelcome_Shown(object sender, EventArgs e) {

            //FrmLogin frmLogin = new FrmLogin();
            //frmLogin.ShowDialog();
            //if (frmLogin.IsLogin) {
            //    Settings.Default.Save();
            //    //lblItemName.Text = Settings.Default.loginUser + @"你好！";
            //} 
        }
    }
}
