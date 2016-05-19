using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ReceiveMessageWindow
{
    public partial class frmClient : Form
    {
        private const int WM_COPYDATA = 0x004A;
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public int dwData;
            public int cbData;
            public IntPtr lpData;
        }
        public frmClient()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                COPYDATASTRUCT CDS = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                byte[] Buffer = new byte[CDS.cbData];
                Marshal.Copy(CDS.lpData, Buffer, 0, CDS.cbData);
                Encoding unicode = Encoding.UTF8; 
                string receiveString = string.Empty;
                if (CDS.cbData > 0)
                {
                    //if (Buffer[0] == 0xFF && Buffer[1] == 0xFE)
                    //    unicode = Encoding.Unicode;
                    //else if (Buffer[0] == 0xFE && Buffer[1] == 0xFF)
                    //    unicode = Encoding.BigEndianUnicode;
                    //else if (Buffer[0] == 0xEF && Buffer[1] == 0xBB && Buffer[2] == 0xBF)
                    //    unicode = Encoding.UTF8;
                    //else
                    //    unicode = Encoding.Unicode;
                    receiveString = unicode.GetString(Buffer);
                }
                rchMessage.Text = receiveString;
                m.Result = IntPtr.Zero;
                
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}