using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSolution.Common;

namespace PSolution.ProjectPP
{
    public partial class ucPPBase : BaseUserControl
    {
        PPController FController = new PPController();
        public ucPPBase()
        {
            InitializeComponent();
            if (this.DesignMode == true 
                || this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null 
                || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }
            ExecuteInController = new TExecuteInController(FController.ProcessUIRequest);
            ucPPMainMidUI1.LinkBaseUserControl(this);           
        }
    }
}
