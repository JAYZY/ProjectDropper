using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDropper {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);



            try {
                Application.Run(new P4C.FrmP4());
              //  Application.Run(new FrmParent());
                //Application.Run(new FrmMain());
            } catch (Exception e) {
               MessageBox.Show(@"系统缺少运行环境：" + e.ToString());
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            //LogHelper.Save("CurrentDomain_UnhandledException", LogType.Error);
            //LogHelper.Save("IsTerminating : " + e.IsTerminating.ToString(), LogType.Error);
           MessageBox.Show(e.ExceptionObject.ToString());

            while (true) {//循环处理，否则应用程序将会退出
                //if (glExitApp) {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                //    LogHelper.Save("ExitApp");
                //    return;
                //}
                System.Threading.Thread.Sleep(2 * 1000);
            };
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
        
            MessageBox.Show(e.Exception.Message);
            //throw new NotImplementedException();
        }
    }
}
