using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DPITest
{
    public partial class FormDPI : Form
    {
        float fDPINormal = 96.0f;
        float fratiox = 0;
        float fratioy = 0;
        double ffontRatiox = 0;
        double ffontRatioy = 0;
        int x = 100;
        int y = 100;
        public FormDPI()
        {            
            InitializeComponent();            
        }

        private void FormDPI_Load(object sender, EventArgs e)
        {
            button2.Size = DPIScale(x, y);
            button3.Size = DPIFont(x, y);

            label1.Text = button1.Size.ToString();
            label2.Text = button2.Size.ToString();
            label3.Text = button3.Size.ToString();
            label4.Text = "fontfratiox: " + ffontRatiox + "  &  fontfratioy: " + ffontRatioy; 
            this.Text += " --> fratiox: " + fratiox + "  &  fratioy: " + fratioy; 
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

            ffontRatiox = this.CurrentAutoScaleDimensions.Width / 6.0;
            ffontRatioy = this.CurrentAutoScaleDimensions.Height / 13.0;
            return new Size((int)(ffontRatiox * w), (int)(ffontRatioy * h));
        }

    }
}