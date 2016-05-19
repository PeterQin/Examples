using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quest.Tuning.Profiler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(AppDomain_UnHandledException);

            Application.Run(new frmProfiler());
        }

        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        public static void AppDomain_UnHandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is System.Exception)
            {
                HandleException((System.Exception)e.ExceptionObject);
            }
        }

        private static void HandleException(Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            string message = ex.Message + "\r\n" + ex.StackTrace;
            if (ex.InnerException != null)
            {
                message += "\r\n" + ex.InnerException.Message;
            }
            frmMessage frm = new frmMessage(message );
            frm.ShowDialog();
        }
    }
}