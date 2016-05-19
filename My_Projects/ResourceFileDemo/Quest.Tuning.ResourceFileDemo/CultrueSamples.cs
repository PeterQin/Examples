using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Quest.Tuning.ResourceFileDemo
{
    /// <summary>
    /// This is a sample for Cultrue
    /// Peter Qin -- 2010-9-19
    /// </summary>
    public partial class frmCultrueSamples : Form
    {
        public frmCultrueSamples()
        {
            InitializeComponent();
        }

        private void frmCultrueSamples_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }

        public void DisplayInfo()
        {
            this.edtCultrue.Text = Thread.CurrentThread.CurrentCulture.Name;
            this.edtUICultrue.Text = Thread.CurrentThread.CurrentUICulture.Name;
            int Number = 123456789;
            this.edtNumber.Text = Number.ToString("n");
            int Currency = 10000;
            this.edtCurrency.Text = Currency.ToString("c");
            System.DateTime CurrentTime=new System.DateTime();
            CurrentTime=System.DateTime.Now;
            this.edtTime.Text = CurrentTime.ToLongTimeString();
            this.edtShortDate.Text = CurrentTime.ToShortDateString();
            this.edtLongDate.Text = CurrentTime.ToLongDateString();
            //Display Text from Resource file.
            //When UICulture language changed system also try to find this language resource file.
            //If it can't find this language resource file system will use default resource file.
            //e.g. we have reource file: rcTest.resx, rcTest.zh-CHS.resx, rcTest.zh-HK.resx
            this.edtResourceText.Text = rcTest.Text;
        }

        

    }
}