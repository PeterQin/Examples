using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Xml;

namespace WCFService
{
    public delegate void delegate_Output(string aMsg);

    

    [ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.Single)]
    //[DeliveryRequirements(TargetContract = typeof(IMyService), RequireOrderedDelivery = true)]
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
            FOutput(DateTime.Now.ToString()+Environment.NewLine);
            return "Test return from Service at " + DateTime.Now.ToString();
        }

        #endregion


        public List<string> TestList()
        {
            return new List<string>() { "1", "2" };
        }


        public List<Data> TestDataList()
        {
            return new List<Data>() { new Data() { ID = "1" }, new Data() { ID = "2" } };
        }


        public Data TestData()
        {
            return new Data() { ID = "11"};
        }
    }
}
