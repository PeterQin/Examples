using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DPIScaleTest
{
    public partial class frmFont : DevExpress.XtraEditors.XtraForm
    {
        public frmFont()
        {
            InitializeComponent();

            this.Text = this.Text + " -- " + QAutoScaleFactor.ToString();
        }

        private void frmFont_Load(object sender, EventArgs e)
        {
            labelControl2.Text = "Current: " + simpleButton1.Size.ToString();
        }
        //To display on caption

        SizeF FAutoScaleFactor = SizeF.Empty;

        public SizeF QAutoScaleFactor
        {
            get
            {
                return FAutoScaleFactor;
            }
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            if (CurrentAutoScaleDimensions != AutoScaleDimensions)
            {
                FAutoScaleFactor = factor;
            }
            base.ScaleControl(factor, specified);
        }
    }
}