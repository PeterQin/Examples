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
    public partial class BaseUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        private class TMessageFlow
        {
            private object FUserControlObj = null;
            private object FUserControlID = null;

            public object UserControlObj
            {
                get { return FUserControlObj; }
            }           

            public object UserControlID
            {
                get { return FUserControlID; }
            }

            public TMessageFlow(object aUserControlID, object aUserControlObj)
            {
                FUserControlID = aUserControlID;
                FUserControlObj = aUserControlObj;
            }
        }

        private TExecuteInController FExecuteInController;
        List<TMessageFlow> FUserControlCollection = new List<TMessageFlow>();

        public TExecuteInController ExecuteInController
        {
            get
            {
                return FExecuteInController;
            }
            set
            {
                FExecuteInController = value;
            }
        }

        public BaseUserControl()
        {
            InitializeComponent();
        }

        public virtual object ExecuteInUIToUserControl(TCommandWithCallerID aAction, object aObject)
        {
            BaseUserControlMidLvl UserControl = null;
            foreach (TMessageFlow MessageFlow in FUserControlCollection)
            {
                if (MessageFlow.UserControlID.GetType() == aAction.UserControlID.GetType() 
                    && MessageFlow.UserControlID.ToString() == aAction.UserControlID.ToString())
                {
                    UserControl = (BaseUserControlMidLvl)MessageFlow.UserControlObj;
                    return UserControl.ExecuteInUIFromUserControl(aAction.ActionCommand, aObject);
                }}
            return null;
        }

        public void AddUserControlToBase(object aUserControlID, object aUserControlObj)
        {
            FUserControlCollection.Add(new TMessageFlow(aUserControlID, aUserControlObj));
        }

    }

    
}
