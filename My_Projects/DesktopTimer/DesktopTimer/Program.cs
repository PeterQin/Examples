using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopTimer
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
            frmHiClock mainForm = new frmHiClock();
            Application.Run();
        }
    }
}