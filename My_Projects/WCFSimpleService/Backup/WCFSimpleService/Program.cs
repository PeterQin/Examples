using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCFSimpleService
{
    [ServiceContract]
    interface IHello
    {
        [OperationContract]
        string SayHello();
    }

    public class THello : IHello
    {
        #region IHello Members

        public string SayHello()
        {

            OperationContext context = OperationContext.Current;
            MessageProperties messageProperties = context.IncomingMessageProperties;
            if (messageProperties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            }
            
            return "Hello Hello";
        }

        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost svcHost = new ServiceHost(typeof(THello));
                svcHost.Open();
                Console.WriteLine("Service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service ...");
                Console.Read();
                svcHost.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
