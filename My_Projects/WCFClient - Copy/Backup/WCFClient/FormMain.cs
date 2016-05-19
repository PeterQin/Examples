using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using WCFService;
using System.ServiceModel.Configuration;
using System.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.MsmqIntegration;

namespace WCFClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {

            /*
             * Simple
             * 
            ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>("NetTcpBinding_IMyService");
            try
            {
                IMyService proxy = factory.CreateChannel();
                using (proxy as IDisposable)
                {
                    try
                    {
                        this.richTextBox1.Text += proxy.Test() + "\r";
                    }
                    catch (CommunicationException ex)
                    {
                        factory.Abort();
                        this.richTextBox1.Text = ex.Message;
                    }
                }

            }
            finally
            {
                factory.Abort();
                factory.Close();
            }
            */

            try
            {
                string Address;
                string strBinding;
                string strBindingName;
                if (TryToFindEndPointConfig(textBoxEndpoint.Text, out Address, out strBinding, out strBindingName))
                {
                    System.ServiceModel.Channels.Binding CurrentBinding = StrToBinding(strBinding);
                   
                    IMyService proxy = InProcFactory.CreateInstance<MyService, IMyService>(CurrentBinding, Address);
                    try
                    {
                        InProcOutput(proxy.Test());
                    }
                    finally
                    {
                        InProcFactory.CloseProxy<IMyService>(proxy);
                    }
                }
                else
                {
                    InProcOutput("Fail to get configuration for endpoint ");
                }
            }
            catch (Exception ex)
            {
                InProcOutput(ex.Message);
            }           
        }

        private System.ServiceModel.Channels.Binding StrToBinding(string aBinding)
        {
            /*
                BasicHttpBinding        HTTP/HTTPS  Text, MTOM  Yes
                NetTcpBinding           TCP         Binary      No
                NetPeerTcpBinding       P2P         Binary      No
                NetNamedPipeBinding     IPC         Binary      No
                WSHttpBinding           HTTP/HTTPS  Text, MTOM  Yes
                WSFederationHttpBinding HTTP/HTTPS  Text, MTOM  Yes
                WSDualHttpBinding       HTTP        Text, MTOM  Yes
                NetMsmqBinding          MSMQ        Binary      No
                MsmqIntegrationBinding  MSMQ        Binary      Yes
             */
            switch (aBinding)
            {
                case "basicHttpBinding":  
                    return new BasicHttpBinding();
                case "netPeerTcpBinding":
                    return new NetPeerTcpBinding();
                case "netTcpBinding":
                    return new NetTcpBinding();
                case "netNamedPipeBinding":
                    return new NetNamedPipeBinding();
                case "wsHttpBinding":
                    return new WSHttpBinding();
                case "wsFederationHttpBinding":
                    return new WSFederationHttpBinding();
                case "wsDualHttpBinding":
                    return new WSDualHttpBinding();
                case "netMsmqBinding":
                    return new NetMsmqBinding();
                case "msmqIntegrationBinding":
                    return new MsmqIntegrationBinding();
                default:
                    return new CustomBinding();
            }
        }

        //private System.ServiceModel.Channels.Binding TryToFindBinding(string aBinding)
        //{
        //    System.ServiceModel.Channels.Binding result = null;

        //    BindingsSection setion = ConfigurationManager.GetSection("system.serviceModel/bindings") as BindingsSection;

            
        //}

        private bool TryToFindEndPointConfig(string aEndPointName, out string aAddress, out string aBinding, out string aBindingName)
        {
            bool rtnFound = false;
            
            ClientSection clientSettings = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            aAddress = string.Empty;
            aBinding = string.Empty;
            aBindingName = string.Empty;
            foreach (ChannelEndpointElement endpoint in clientSettings.Endpoints)
            {
                if (endpoint.Name == aEndPointName)
                {
                    aAddress = endpoint.Address.ToString();
                    aBinding = endpoint.Binding;
                    aBindingName = endpoint.BindingConfiguration;
                    rtnFound = true;
                    break;
                }
            }
            return rtnFound;
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
            this.richTextBox1.Text += DateTime.Now.ToString() + " --> " + aMsg + "\r\r";
        }
    }
}