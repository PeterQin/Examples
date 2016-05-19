using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DPITestDX
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
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F);
            Application.Run(new frmDPITest());
        }
    }
}