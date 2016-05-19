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
    public partial class BaseUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public BaseUserControl()
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




        //-----------------simply scale the value by the DPI rate----------------
        public Size Scale(Size aSize) 
        {
            return DPINew.Scale(aSize, QAutoScaleFactor);
        }

        public Point Scale(Point aSize)
        {
            return DPINew.Scale(aSize);
        }

        public bool IsHighDPI()
        {
            return DPINew.IsHighDPI(QAutoScaleFactor);
        }

        public int Scale(int i, BoundsScale aBounds) 
        {
            return DPINew.Scale(i, QAutoScaleFactor, aBounds);
        }

    }
}
