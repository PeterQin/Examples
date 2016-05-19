using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace SingleInstance
{
    static class Program
    {
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd,int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_SHOWNORMAL=1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //MutexRun();
            //ProcessRun();
            Win32RunProcess();
        }
        private static void MutexRun()
        {
            bool craateNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out craateNew))
            {
                if (craateNew)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    MessageBox.Show("Process is runing...");
                }
            }
        }

        private static void ProcessRun()
        {
            Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
            if (processes.Length >= 1)
            {
                MessageBox.Show("Process is runing");
            }
            else
            {
                Application.Run(new Form1());
                
            }
        }

        private static void HandleRuningInstance(Process aInstance)
        {
            ShowWindowAsync(aInstance.MainWindowHandle,SW_SHOWNORMAL);
            SetForegroundWindow(aInstance.MainWindowHandle);
        }

        private static Process RuningInstance()
        {
            Process _CurrentProcess = Process.GetCurrentProcess();
            Process[] Processes = Process.GetProcessesByName(_CurrentProcess.ProcessName);
            foreach (Process process in Processes)
            {
                if (process.Id != _CurrentProcess.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/","\\")==_CurrentProcess.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        private static void Win32RunProcess()
        {
            Process _Process = RuningInstance();
            if (_Process == null)
            {
                Application.Run(new Form1());
            }
            else
            {
                HandleRuningInstance(_Process);
            }
        }



    }
}