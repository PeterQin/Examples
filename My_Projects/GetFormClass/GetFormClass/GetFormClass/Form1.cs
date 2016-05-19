using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace GetFormClass
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        private static extern IntPtr WindowFromPoint(Point p);
        [DllImport("User32.dll")]
        private static extern void GetClassName(IntPtr hwnd, StringBuilder sb, int nMaxCount);
        [DllImport("User32.dll")]
        private static extern void GetWindowText(IntPtr handle, StringBuilder text, int MaxLen);
        [DllImport("user32.dll ")]
        private static extern IntPtr GetActiveWindow();

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
        }

        void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.ShowInTaskbar = true;
            else
                this.ShowInTaskbar = false;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            Screen sc = Screen.PrimaryScreen;
            this.Location = new Point(sc.Bounds.Width - this.Width, sc.Bounds.Height - this.Height - 25);
        }


        StringBuilder sb = new StringBuilder(256);

        private void GetClass()
        {
            Point p = Cursor.Position;
            IntPtr hwnd = WindowFromPoint(p);
            GetWindowText(hwnd, sb, 50);
            this.Text = p.X + "," + p.Y;
            this.textBox1.Text = sb.ToString();
            GetClassName(hwnd, sb, 50);
            this.textBox2.Text = sb.ToString();
            this.textBox3.Text = hwnd.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetClass();
        }
    }
}