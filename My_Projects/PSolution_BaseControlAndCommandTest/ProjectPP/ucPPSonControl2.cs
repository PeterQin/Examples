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
    public partial class ucPPSonControl2 : PPMidLvl
    {
        public ucPPSonControl2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BaseExecuteUIToUI(UIToUI.DisplayText, PPControl.Son1, "From: " + this.GetType());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            BaseExecuteUIToUI(UIToUI.DisplayText, PPControl.MainMid, "From: " + this.GetType());
        }

        public override object ExecuteInUIFromUserControl(object aAction, object bObject)
        {
            if (aAction is UIToUI)
            {
                UIToUI Action = (UIToUI)aAction;
                switch (Action)
                {
                    case UIToUI.DisplayText:
                        if (richTextBox1.Text != string.Empty)
                        {
                            richTextBox1.AppendText("\r\n" + bObject.ToString());
                        }
                        else
                        {
                            richTextBox1.AppendText(bObject.ToString());
                        }
                        break;
                }
            }
            return null;
        }
    }
}
