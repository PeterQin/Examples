using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PSolution.Common
{
    public partial class CommonMidLvl<TBaseUI, TControlID, TCommand, TUIToUI> : BaseUserControlMidLvl where TBaseUI : class
    {
        public CommonMidLvl()
        {
            InitializeComponent();
        }

        protected object BaseExecuteUIToUI(TUIToUI aUIToUI, TControlID aDestination, object aContent)
        {
            if (BaseUserControlObj != null)
            {
                return BaseUserControlObj.ExecuteInUIToUserControl(new TCommandWithCallerID(aUIToUI, aDestination), aContent);
            }
            else
            {
                return null;
            }
        }

        public void RegisterBaseUserControl(BaseUserControl aBaseUI, object aID)
        {
            BaseUserControlObj = aBaseUI;
            AddUserControlToBase(aID, this);
        }

    }
}
