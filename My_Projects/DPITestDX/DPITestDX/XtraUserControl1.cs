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
    public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl1()
        {
            InitializeComponent();
        }


        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            if (this.DesignMode == false)
            {
                //splitContainerControl1.Text = "";
                //simpleButton1.Text = "";

                //MessageBox.Show("BB - this.AutoScaleDimensions : " + this.AutoScaleDimensions + "  && this.CurrentAutoScaleDimensions" + this.CurrentAutoScaleDimensions + "  && " + specified);
            
                base.ScaleControl(factor, specified);
            }

            //MessageBox.Show("Test Design");
        }
        protected override void ScaleCore(float x, float y)
        {
            MessageBox.Show("x=" + x + "  y" + y);
            base.ScaleCore(x, y);
        }


        [DesignerSerializationVisibility(0)]
        [Browsable(false)]
        protected new bool DesignMode
        {
            get
            {
                bool result = false;

#if (DEBUG)
                if (base.DesignMode == true
                    || (this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null)
                    || (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                    || this.ParentDesignMode == true
                    )
                {
                    result = true;
                }
#else
                result = base.DesignMode;
#endif

                return result;
            }
        }

        private bool FParentDesignMode = false;
        private System.Reflection.PropertyInfo FParentDesignModePropInfo = null;
        private bool ParentDesignMode
        {
            get
            {
#if (DEBUG)
                if (FParentDesignModePropInfo == null)
                {
                    FParentDesignMode = GetParentDesignMode();
                }
#else
                FParentDesignMode = false;
#endif

                return FParentDesignMode;
            }
        }
        private bool GetParentDesignMode()
        {
            bool result = false;

            System.Windows.Forms.Control searchCtl = this.Parent;

            for (int i = 0; i < 999 ; i++)
            {
                if (searchCtl != null)
                {
                    if (searchCtl is Component)
                    {

                        FParentDesignModePropInfo = searchCtl.GetType().GetProperty("DesignMode",
                           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                        result = Convert.ToBoolean(FParentDesignModePropInfo.GetValue(searchCtl, null));
                    }
                    else
                    {
                        result = false;
                    }

                    if (result == true)
                    {
                        break;
                    }
                    else
                    {
                        searchCtl = searchCtl.Parent;
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
