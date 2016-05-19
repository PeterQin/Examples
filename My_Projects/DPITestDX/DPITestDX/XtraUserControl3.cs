using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DPITestDX
{
    public partial class XtraUserControl3 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl3()
        {
            InitializeComponent();
        }

        private void XtraUserControl3_Load(object sender, EventArgs e)
        {
            devExpressHyperLinkEdit1.Visible = false;
            devExpressHyperLinkEdit1.Visible = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hyperLinkEdit1.Margin : " + hyperLinkEdit1.Margin + " --- simpleButton3.Margin " + simpleButton3.Margin + "");
        }


    }
}
