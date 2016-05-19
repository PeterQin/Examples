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
    public partial class BaseXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseXtraForm()
        {
            InitializeComponent();
        }

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

        public Size Scale(Size aSize) //simply scale the value by the DPI rate
        {
            return DPINew.Scale(aSize, QAutoScaleFactor);
        }
    }
}