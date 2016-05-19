using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace Quest.Tuning.FileTransferCommon
{
    [ServiceContract(Namespace = "http://Quest.Tuning.FileTransferCommon")]
    public interface IFileTransfer
    {

        [OperationContract]
        string GetVersion();

        [OperationContract]
        bool RegisterClient(string HostName);

        [OperationContract]
        void UnregisterClient(string HostName);

        /// <summary>
        /// FileTransfer with stream
        /// </summary>
        /// <param name="aFileName"></param>
        /// <returns></returns>
        [OperationContract]
        long GetFileSize(string aFileName);

        [OperationContract]
        FileTransferResult DownloadFile(RemoteFileInfo aFileInfo);

        [OperationContract]
        string[] GetFiles(string aPath, string aSearchPattern, SearchOption aSearchOption);

        [OperationContract]
        FileTransferResult UploadFile(RemoteFileInfo aFileByteStream);

 
    }
}
