using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PSolution.ProjectPP
{
    public partial class ucPPMainMidUI : PPMidLvl
    {
        public ucPPMainMidUI()
        {
            InitializeComponent();
        }

        public override object ExecuteInUIFromUserControl(object aAction, object bObject)
        {
            if (aAction is UIToUI)
            {
                UIToUI Action = (UIToUI)aAction;
                switch (Action)
                {
                    case UIToUI.DisplayText:
                        MessageBox.Show(bObject.ToString(),"Main Mid");
                        break;
                }
            }
            return null;
        }

        public void LinkBaseUserControl(ucPPBase ucBaseUI)
        {
            this.RegisterBaseUserControl(ucBaseUI, PPControl.MainMid);
            ucPPSonControl11.RegisterBaseUserControl(ucBaseUI, PPControl.Son1);
            ucPPSonControl21.RegisterBaseUserControl(ucBaseUI, PPControl.Son2);
            
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            ucPPSonControl11.Visible = false;
            ucPPSonControl21.Visible = false;
            if (e.Page == xtraTabPage1)
            {
                ucPPSonControl11.Visible = true;
            }
            else if (e.Page == xtraTabPage2)
            {
                ucPPSonControl21.Visible = true;
            }
            
        }

    }
}
