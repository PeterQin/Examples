using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ServiceModel;

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
        ResponseFileInfo DownloadFileWithMsgContract(RequestFileInfo aFileInfo);

        [OperationContract]
        Stream DownloadFileSpical(string aFileName);

        [OperationContract]
        Stream DownloadFileSpicalWithLength(string aFileName);

        [OperationContract]
        long FileSpicalSize(string aFileName);

        [OperationContract]
        Stream DownloadFileWithCustomStream(string aFilePath, long aOffset, long aCount);

        [OperationContract]
        string[] GetFiles(string aPath, string aSearchPattern, SearchOption aSearchOption);
    }

    [MessageContract]
    public class ResponseFileInfo
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

        public ResponseFileInfo(string aFileName, long aFileLength, Stream aFileContent)
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

        public ResponseFileInfo DownloadFileWithMsgContract(RequestFileInfo aFileInfo)
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
            ResponseFileInfo fileInfo = new ResponseFileInfo(strFileName, streamContent.Length, streamContent);
            return fileInfo;
        }

        public string[] GetFiles(string aPath, string aSearchPattern, SearchOption aSearchOption)
        {
            if (string.IsNullOrEmpty(aPath) == false && Directory.Exists(aPath))
            {
                return Directory.GetFiles(aPath, aSearchPattern, aSearchOption);
            }
            else
            {
                return new string[0];
            }
        }

        public long FileSpicalSize(string aFileName)
        {
            long Result = 0;
            using (Stream fstream = File.OpenRead(aFileName))
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

        public Stream DownloadFileWithCustomStream(string aFilePath, long aOffset, long aCount)
        {
            CusFileStream rtnStream = new CusFileStream(aFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, aOffset, aCount);
            return rtnStream;
        }

    }


    public class CusFileStream : FileStream
    {
        long _count;
        long _lastPosition;
        public CusFileStream(IntPtr handle, FileAccess access)
            : base(handle, access)
        { }

        public CusFileStream(string path, FileMode mode, FileAccess access, FileShare share)
            : base(path, mode, access) { }

        public CusFileStream(string path, FileMode mode, FileAccess access, FileShare share, long offset, long count)
            : base(path, mode, access)
        {
            base.Position = offset;
            _count = count;
            _lastPosition = offset + count;
        }

        public CusFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
            : base(path, mode, access, share, bufferSize)
        { }

        public override int Read(byte[] array, int offset, int count)
        {
            if (this._count > 0 && Position + count > this._lastPosition)
                return base.Read(array, offset, (int)(this._lastPosition - Position));
            else
                return base.Read(array, offset, count);
        }

        public override int ReadByte()
        {
            if (this._count > 0 && Position >= this._lastPosition)
                return -1;
            else
                return base.ReadByte();
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
            int byteRead = FFileStream.Read(buffer, offset, count);
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
            return FFileStream.Seek(offset, origin);
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
}
