using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DPITestDX
{
    public partial class frmDPITest : DevExpress.XtraEditors.XtraForm
    {
        int DesignWidth = 100;
        int DesignHeight = 100;
        float fratiox = 0;
        float fratioy = 0;
        float ffontRatiox = 0;
        float ffontRatioy = 0;

        float fDPINormal = 96.0F;
        float fFontNormalX = 6.0F;
        float fFontNormalY = 13.0F;

        public frmDPITest()
        {
            InitializeComponent();

            MessageBox.Show("AutoScaleFactor" + this.AutoScaleFactor.ToString());
            MessageBox.Show("CurrentAutoScaleDimensions" + this.CurrentAutoScaleDimensions.ToString());

        }

        private void DPITest_Load(object sender, EventArgs e)
        {
            simpleButton2.Size = DPIFont(DesignWidth, DesignHeight);

            labelControl1.Text = simpleButton1.Size.ToString();
            labelControl2.Text = simpleButton1.Font.ToString();
            labelControl3.Text = simpleButton2.Size.ToString();
            labelControl4.Text = simpleButton2.Font.ToString();
            labelControl5.Text = simpleButton3.Size.ToString();
            labelControl6.Text = simpleButton3.Font.ToString();

            //labelControl7.Text = textEdit1.Size.ToString();
            //labelControl8.Text = textEdit1.Font.ToString();
            //labelControl9.Text = textEdit2.Size.ToString();
            //labelControl10.Text = textEdit2.Font.ToString();

            DPIScale(DesignWidth, DesignHeight);
            this.Text += " --> Current DPI : " + fratiox * 100 + "%";
            this.Text += " --> Current Form Size : " + this.Size.ToString();

        }
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            //MessageBox.Show("AA - this.AutoScaleDimensions : "+this.AutoScaleDimensions + "  && this.CurrentAutoScaleDimensions" + this.CurrentAutoScaleDimensions + "  && "+ specified);
            base.ScaleControl(factor, specified);
        }

        private Size DPIScale(int w, int h)
        {

            using (Graphics g = this.CreateGraphics())
            {
                fratiox = g.DpiX / fDPINormal;
                fratioy = g.DpiY / fDPINormal;
            }

            return new Size((int)(w * fratiox), (int)(h * fratioy));
        }

        private Size DPIFont(int w, int h)
        {
            //ffontRatiox = this.AutoScaleFactor.Height;
            //ffontRatioy = this.AutoScaleFactor.Width;

            ffontRatiox = this.CurrentAutoScaleDimensions.Width / fFontNormalX;
            ffontRatioy = this.CurrentAutoScaleDimensions.Height / fFontNormalY;
            int newW = (int)Math.Round((ffontRatiox * w), 0);
            int newY = (int)Math.Round((ffontRatioy * h), 0);
            return new Size(newW, newY);

            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            new frmMargin().Show();
        }

    }
}