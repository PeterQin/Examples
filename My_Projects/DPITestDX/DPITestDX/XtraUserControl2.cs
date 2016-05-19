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
    public partial class XtraUserControl2 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl2()
        {
            InitializeComponent();
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
        }
    }
}
