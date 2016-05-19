using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace Quest.Tuning.FileTransferCommon
{
    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public string FileFullName;

        [MessageHeader(MustUnderstand = true)]
        public string TargetDirectory;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageHeader(MustUnderstand = true)]
        public long Offset;

        [MessageHeader(MustUnderstand = true)]
        public long StreamLength;

        [MessageHeader(MustUnderstand = true)]
        public bool IsHeader;

        [MessageHeader(MustUnderstand = true)]
        public int Percentage;

        [MessageBodyMember(Order = 1)]
        public Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
