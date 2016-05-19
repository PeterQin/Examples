using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using System.ServiceModel.Security;
using System.IO;

namespace Miscrosoft.ServiceModel.Samples
{
    class WCFService
    {
        static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            //Uri baseAddress = new Uri("http://Localhost:8000/ServiceModelSamples/Service");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService));

            try
            {


                // Step 3 of the hosting procedure: Add a service endpoint.
                //WSHttpBinding httpBinding = new WSHttpBinding();
                //httpBinding.Security.Mode = SecurityMode.None;

                //selfHost.AddServiceEndpoint(
                //    typeof(ICalculator),
                //    httpBinding,
                //    "CalculatorService");
                

                // Step 4 of the hosting procedure: Enable metadata exchange.
                //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                //smb.HttpGetEnabled = true;
                //selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }

        }
    }

}
