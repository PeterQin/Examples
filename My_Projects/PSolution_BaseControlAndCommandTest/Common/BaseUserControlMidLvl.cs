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
    public partial class BaseUserControlMidLvl : DevExpress.XtraEditors.XtraUserControl
    {
        private BaseUserControl FBaseUserControl = null;
        private TExecuteInController FExecuteInController_Link;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseUserControl BaseUserControlObj
        {
            get { return FBaseUserControl; }
            set
            {
                if (value != null)
                {
                    FExecuteInController_Link = value.ExecuteInController;
                    FBaseUserControl = value;
                }
            }
        }

        [Browsable(false)]
        public TExecuteInController ExecuteInController
        {
            get
            {
                return FExecuteInController_Link;
            }
        }

        public BaseUserControlMidLvl()
        {
            InitializeComponent();
        }

        public virtual object ExecuteInUIFromUserControl(object aAction, object bObject)
        {
            return null;
        }

        public void AddUserControlToBase(object aUserControlID, object aUserControlObj)
        {
            if (BaseUserControlObj != null)
            {
                BaseUserControlObj.AddUserControlToBase(aUserControlID, aUserControlObj);
            }

        }
    }

    public struct TCommandWithCallerID
    {
        private object OneCommand;
        private object OneUserControlID;

        public TCommandWithCallerID(object aCommand, object aUserControlID)
        {
            OneCommand = aCommand;
            OneUserControlID = aUserControlID;
        }

        public object UserControlID
        { get { return OneUserControlID; } }

        public object ActionCommand
        { get { return OneCommand; } }
    }

 }
