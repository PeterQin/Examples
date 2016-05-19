using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace Quest.Tuning.FileTransferCommon
{
    [MessageContract]
    public class FileTransferResult : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public bool IsTransferSuccess;

        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public string Message;

        [MessageBodyMember(Order = 1)]
        public Stream FileByteStream;

        #region IDisposable Members

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }

        #endregion
    }
}
