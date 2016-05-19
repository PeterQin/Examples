using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ucTime
{
    public partial class ucShowCurrentTime : UserControl
    {
        private string nametest;
        public string NameTest
        {
            get
            {
                return this.nametest;
            }
            set
            {
                this.nametest = value;
            }
        }
        Thread ShowTimeThread;
        delegate void SetTextCallback(string text);
        public ucShowCurrentTime()
        {
            InitializeComponent();

        }
        public void ShowCurrentTime()
        {
            System.DateTime time = new System.DateTime();
            while (true)
            {
                time = System.DateTime.Now;
                this.SetText(time.ToString());
                Thread.Sleep(100);
            }



        }
        private void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }

        }

        private void ucShowCurrentTime_Load(object sender, EventArgs e)
        {
            if (DesignMode == false && System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {

                ShowTimeThread = new Thread(new ThreadStart(this.ShowCurrentTime));
                ShowTimeThread.Start();
            }

        }
    }
}