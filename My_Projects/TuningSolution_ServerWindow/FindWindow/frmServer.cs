using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FindWindow
{

    public partial class frmServer : Form
    {
        private const int WM_COPYDATA = 0x004A;
        private const string FWindowClassName = "WindowsForms10.Window.8.app.0.14fd2b5";
        private const string FWindowCaption = "Client";

        public frmServer()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public int dwData;
            public int cbData;
            public IntPtr lpData;
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private void btnSendMsg_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(rchMessage.Text)==false)
            {
                IntPtr handle = FindWindow(null, FWindowCaption);
                byte[] Message = StrToByteArray(rchMessage.Text);
                SendCopyData(handle, 0, Message);
            }            

        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static IntPtr SendCopyData(IntPtr hWnd, int dwData, byte[] lpdata)
        {
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = dwData;
            cds.cbData = lpdata.Length;
            cds.lpData = Marshal.AllocHGlobal(lpdata.Length);
            Marshal.Copy(lpdata, 0, cds.lpData, lpdata.Length);
            IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(cds));
            Marshal.StructureToPtr(cds, lParam, true);

            IntPtr result = IntPtr.Zero;
            try
            {
                result = SendMessage(hWnd, WM_COPYDATA, IntPtr.Zero, lParam);
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);
                Marshal.DestroyStructure(lParam, typeof(COPYDATASTRUCT));
                Marshal.FreeHGlobal(lParam);
            }
            return result;
        }

    }
}