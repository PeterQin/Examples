using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TuningSolution_XMLView_WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Arg)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string strFilePath = string.Empty;
            if (Arg.Length > 0)
            {
                strFilePath = Arg[0];
            }
            Application.Run(new frmXMLView(strFilePath));
        }
    }
}