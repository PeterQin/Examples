using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCFService
{
    public delegate void delegate_Output(string aMsg);

    [ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.Single)]
    class MyService : IMyService
    {
        delegate_Output FOutput;
        public void Init(delegate_Output aOutput)
        {
            FOutput = aOutput;
        }

        #region IMyService Members

        public string Test()
        {
            if (FOutput != null)
            {
                FOutput("Test from Client at " + DateTime.Now.ToString());
            }
            return "Test return from Service at " + DateTime.Now.ToString();
        }

        #endregion
    }

    public static class InProcFactory
    {
        public static I CreateInstance<S, I>(Binding aBinding, string aUri)
            where I : class
            where S : I
        {
            //HostRecord hostRecord = GetHostRecord<S, I>();

            return ChannelFactory<I>.CreateChannel(aBinding, new EndpointAddress(aUri));
        }

        public static I CreateInstance<S, I>(Binding aBinding, EndpointAddress aEndpointAddress)
            where I : class
            where S : I
        {
            //HostRecord hostRecord = GetHostRecord<S, I>();

            return ChannelFactory<I>.CreateChannel(aBinding, aEndpointAddress);
        }

        public static void CloseProxy<I>(I aInstance)
        {
            if (aInstance != null)
            {
                ICommunicationObject proxy = aInstance as ICommunicationObject;
                if (proxy != null)
                {
                    proxy.Abort();
                    proxy.Close();
                }
            }
        }
    }

}
