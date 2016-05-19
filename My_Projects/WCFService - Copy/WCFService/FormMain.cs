using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace AJMS
{
    public partial class frmService : Form
    {
        ServiceHost selfHost = null;
        AJMSService serviceInstance = null;
        public frmService()
        {
            InitializeComponent();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            serviceInstance = new AJMSService();
            //serviceInstance.Init(new delegate_Output(InProcOutput));
            selfHost = new ServiceHost(serviceInstance);
            try
            {
                selfHost.Open();
                InProcOutput("WCF Service Runing...");
                this.progressBar1.Visible = true;
            }
            catch (Exception ex)
            {
                InProcOutput(ex.Message);
                selfHost.Abort();
                this.progressBar1.Visible = false;
            }
        }

        private void frmService_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (selfHost != null)
                {
                    selfHost.Abort();
                    selfHost.Close();
                }
            }
            catch (Exception ex)
            {
                InProcOutput(ex.Message);
                e.Cancel = true;
            }
            
        }

        public void InProcOutput(string aMsg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delegate_Output(Output));
            }
            else
            {
                Output(aMsg);
            }
        }

        public void Output(string aMsg)
        {
            this.richTextBox1.Text +=DateTime.Now.ToString() +" --> "+ aMsg + "\r\r";
        }


    }
}