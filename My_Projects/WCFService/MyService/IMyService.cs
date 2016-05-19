using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WCFService
{
    


    [ServiceContract(Namespace = "WCFService")]
    public interface IMyService
    {
        [OperationContract]
        string Test();

        [OperationContract]
        List<string> TestList();

        [OperationContract]
        List<Data> TestDataList();

        [OperationContract]
        Data TestData();
    }

    
}
