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
            if (FOutput != null)
            {
                FOutput("Test from Client at " + DateTime.Now.ToString());
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(@"\\zhuflsw01\WORKGROUP\RND\Quest Code Tester for Oracle\Automation\Automation logs\QuestCodeTesterOracle_2.6.2.937\Regression Test\W1 - test\ZHUVMXQCTO02\2013-11-15_13-33-09\Result2013-11-15 13-33-09.xml");
            return "Test return from Service at " + DateTime.Now.ToString();
        }

        #endregion
    }
}
