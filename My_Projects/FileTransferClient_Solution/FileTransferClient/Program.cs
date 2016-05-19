using System;
using System.Collections.Generic;
using System.Text;
using Quest.Tuning.FileTransferCommon;
using System.ServiceModel;

namespace Quest.Tuning.FileTransferClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            string xml = "FileTransferTask.xml";
            if (args.Length > 0)
            {
                xml = args[0];
            }
            Log.Instance.WriteLine("Connecting to service...");
            try
            {
                FileTransferClient client = new FileTransferClient();
                client.Connect();
                client.ProcessTask(xml);
                client.DisConnect();
                Log.Instance.WriteLine("Disconnecting...");
            }
            catch (Exception e)
            {
                Log.Instance.WriteLine("Error connecting to service: " + e.Message);
                if (e.InnerException != null)
                {
                    Log.Instance.WriteLine("Inner exception: " + e.InnerException.ToString());
                }
                
            }
            
        }
    }
   
}
