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
    [ServiceContract(Namespace = "http://Miscrosoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double aOriginal, double aFactor);

        [OperationContract]
        double Subtract(double aOriginal, double aFactor);

        [OperationContract]
        double Multiply(double aOriginal, double aFactor);

        [OperationContract]
        double Divide(double aOriginal, double aFactor);

        [OperationContract]
        ResponeFileInfo DownloadFileWithMsgContract(RequestFileInfo aFileInfo);

        [OperationContract]
        Stream DownloadFileSpical(string aFileName);

        [OperationContract]
        Stream DownloadFileSpicalWithLength(string aFileName);

        [OperationContract]
        long FileSpicalSize(string aFileName);
    }

    [MessageContract]
    public class ResponeFileInfo
    {
        private string FFileName;
        private long FFileLength;

        [MessageHeader]
        public string FileName
        {
            get { return FFileName; }
            set { FFileName = value; }
        }        

        [MessageHeader]
        public long FileLength
        {
            get { return FFileLength; }
        }

        [MessageBodyMember]
        public Stream FFileContent;

        public ResponeFileInfo(string aFileName, long aFileLength, Stream aFileContent)
        {
            FFileName = aFileName;
            FFileLength = aFileLength;
            FFileContent = aFileContent;
        }       

    }

    [MessageContract]
    public class RequestFileInfo
    {
        private string FFileName;

        [MessageBodyMember]
        public string FileName
        {
            get { return FFileName; }
            set { FFileName = value; }
        }

        public RequestFileInfo()
        {
        }

        public RequestFileInfo(string aFileName)
        {
            FFileName = aFileName;
        }

    }

    // Step 1: Create service class that implements the service contract.
    public class CalculatorService : ICalculator
    {
         // Step 2: Implement functionality for the service operations.
        public double Add(double aOriginal, double aFactor)
        {
            double result = aOriginal + aFactor;
            Console.WriteLine("Received Add({0},{1})", aOriginal, aFactor);
            // Code added to write output to the console window.
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double aOriginal, double aFactor)
        {
            double result = aOriginal - aFactor;
            Console.WriteLine("Received Subtract({0},{1})", aOriginal, aFactor);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double aOriginal, double aFactor)
        {
            double result = aOriginal * aFactor;
            Console.WriteLine("Received Multiply({0},{1})", aOriginal, aFactor);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double aOriginal, double aFactor)
        {
            double result = aOriginal / aFactor;
            Console.WriteLine("Received Divide({0},{1})", aOriginal, aFactor);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public ResponeFileInfo DownloadFileWithMsgContract(RequestFileInfo aFileInfo)
        {
            string strFileName = aFileInfo.FileName;
            Stream streamContent = File.OpenRead(strFileName);
            OperationContext clientContext = OperationContext.Current;
            clientContext.OperationCompleted += new EventHandler(delegate(object sender, EventArgs args)
            {
                if (streamContent != null)
                {
                    streamContent.Dispose();
                }
                   
            });
            ResponeFileInfo fileInfo = new ResponeFileInfo(strFileName, streamContent.Length, streamContent);
            return fileInfo;
        }

        public long FileSpicalSize(string aFileName)
        {
            long Result = 0;
            using(Stream fstream = File.OpenRead(aFileName))
            {
                Result = fstream.Length;
                fstream.Close();
            }
            return Result;
        }

        public Stream DownloadFileSpical(string aFileName)
        {
            Stream rtnStream = File.OpenRead(aFileName);
            return rtnStream;
        }

        public Stream DownloadFileSpicalWithLength(string aFileName)
        {
            FileStream rtnStream = File.OpenRead(aFileName);
            CustomStream customStream = new CustomStream(rtnStream);
            return customStream;
        }
    }

    public class CustomStream : Stream
    {
        private FileStream FFileStream;
        public CustomStream(FileStream aStream)
        {
            FFileStream = aStream;
        }

        public override long Length
        {
            get { return FFileStream.Length; }
        }

        public override void Close()
        {
            FFileStream.Close();
            base.Close();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int byteRead = FFileStream.Read(buffer,offset,count);
            return byteRead;
        }

        protected override void Dispose(bool disposing)
        {
            FFileStream.Dispose();
            base.Dispose(disposing);
        }

        public override bool CanRead
        {
            get { return FFileStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return FFileStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return FFileStream.CanWrite; }
        }

        public override void Flush()
        {
            FFileStream.Flush();
        }

        public override long Position
        {
            get
            {
                return FFileStream.Position;
            }
            set
            {
                FFileStream.Position = value;
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return FFileStream.Seek(offset,origin);
        }

        public override void SetLength(long value)
        {
           FFileStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            FFileStream.Write(buffer, offset, count);
        }
    }


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
