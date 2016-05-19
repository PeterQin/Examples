using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace WCFService
{
    [ServiceContract(Namespace = "WCFService")]
    public interface IMyService
    {
        [OperationContract]
        string Test();
    }
}
