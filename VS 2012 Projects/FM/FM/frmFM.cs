using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FM
{
    public partial class frmFM : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmFM()
        {
            InitializeComponent();
        }

        private void frmFM_Load(object sender, EventArgs e)
        {
            webBrowserFM.Navigate(@"http://douban.fm/partner/baidu/doubanradio");
        }

        private void TiltleControlLabel_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.ForeColor = Color.Yellow;
                lbl.BackColor = Color.Black;
            }
        }

        private void TitleControlLabel_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.ForeColor = Color.Gray;
                lbl.BackColor = Color.Transparent;
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tableLayoutPanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

    }
}
