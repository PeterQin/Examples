using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CompileCondition
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
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.Run(new frmCondition());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unhandle Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);           
        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {            
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex.Message, "Unhandle Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);    
        }
    }
}
