using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Quest.Tuning.FileTransferService;

namespace Quest.Tuning.FileTransferConsoleService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost selfHost = new ServiceHost(typeof(FileTransfer));
            try
            {
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                Console.Read();
            }
            finally
            {
                // Close the ServiceHostBase to shutdown the service.
                selfHost.Abort();
                selfHost.Close();
            }
        }
    }
}
