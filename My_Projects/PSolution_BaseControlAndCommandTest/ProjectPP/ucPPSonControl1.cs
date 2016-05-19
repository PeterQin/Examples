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
    public partial class ucPPSonControl1 : PPMidLvl
    {
        public ucPPSonControl1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BaseExecuteUIToUI(UIToUI.DisplayText, PPControl.Son2, "From: " + this.GetType());
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                ExecuteInController(Command.Execute, "123");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
