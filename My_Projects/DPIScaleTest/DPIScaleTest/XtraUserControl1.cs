using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DPIScaleTest
{
    public partial class XtraUserControl1 : BaseUserControl
    {

        private string FMsg = "The SQL criteria cannot be modified as there was error during the index optimization.";
        public XtraUserControl1()
        {
            InitializeComponent();

            btnUseCodeScale.Size = Scale(new Size(100, 100)); //Calculate by DPIScale function
            labelControl2.Text = "Current: " + simpleButton1.Size.ToString();

            
            //simpleButton9.Location = new Point(242, 262);
            btnCalculate.Location = Scale(new Point(242, 262));//Calculate
            
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            
            if (this.AutoScaleDimensions != this.CurrentAutoScaleDimensions)
            {
                if (xtraTabPage1 != null)
                {
                    xtraTabPage1.AutoScrollMinSize = DPINew.Scale(xtraTabPage1.AutoScrollMinSize, factor);
                }                
            }
        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            new frmDPI().Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            new frmFont().Show();
        }


    }
}
