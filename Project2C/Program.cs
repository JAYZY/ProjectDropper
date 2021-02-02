using System;
using System.Windows.Forms;

namespace Project2C {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run((new ChildFrm.FrmWelcome()));
            //Application.Run(FrmMain.GetInstance());
            //  Application.Run(new Template.MyReport());
        }
    }
}
