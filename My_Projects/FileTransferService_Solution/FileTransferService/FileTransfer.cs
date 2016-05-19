using System;
using System.Collections.Generic;
using System.Text;
using Quest.Tuning.FileTransferCommon;
using System.IO;
using System.ServiceModel;

namespace Quest.Tuning.FileTransferService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)] // makes the service a sigleton instance, Support multiple console request
    public class FileTransfer : IFileTransfer
    {
        private int FUploadBuffer = 6500;
        public FileTransfer()
        {
            FUploadBuffer = FileTransferServiceSettings.Default.UploadFileBuffer;
        }

        #region IFileTransfer Members

        public string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public bool RegisterClient(string HostName)
        {
            Log.Instance.WriteLine(string.Format("Client {0} register", HostName));
            return true;
        }

        public void UnregisterClient(string HostName)
        {
            Log.Instance.WriteLine(string.Format("Client {0} unregister", HostName));
        }


        public long GetFileSize(string aFileName)
        {
            long Result = 0;
            try
            {
                Log.Instance.WriteLine(string.Format("Get file size: {0}", aFileName));
                using (Stream fstream = File.OpenRead(aFileName))
                {
                    Result = fstream.Length;
                    fstream.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.HandleException(ex);
            }
            return Result;

        }

        public string[] GetFiles(string aPath, string aSearchPattern, SearchOption aSearchOption)
        {
            try
            {
                Log.Instance.WriteLine(string.Format("Get files: {0}", aPath));
                if (string.IsNullOrEmpty(aPath) == false && Directory.Exists(aPath))
                {
                    return Directory.GetFiles(aPath, aSearchPattern, aSearchOption);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.HandleException(ex);

            }
            return new string[0];
        }

        public FileTransferResult DownloadFile(RemoteFileInfo aFileInfo)
        {
            FileTransferResult result = new FileTransferResult();
            string aFilePath = aFileInfo.FileFullName;
            long aOffset = aFileInfo.Offset;
            long aCount = aFileInfo.Length;
            try
            {
                if (aFileInfo == null || IsValidSharedPath(Path.GetDirectoryName(aFilePath)) == false)
                {
                    result.FileByteStream = Stream.Null;
                    result.IsTransferSuccess = false;
                    result.Message = "Isn't valid shared path";
                    return result;
                }
                if (Log.Instance.LastMsg.StartsWith("Download file:"))
                {
                    Log.Instance.WriteLine(string.Format("Download file: {0}", aFilePath), true);
                }
                else
                {
                    Log.Instance.WriteLine(string.Format("Download file: {0}", aFilePath));
                }
                result.FileByteStream = new CustomFileStream(aFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, aOffset, aCount);
                result.IsTransferSuccess = true;
                result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                Log.Instance.HandleException(ex);
                result.FileByteStream = Stream.Null;
                result.IsTransferSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        private bool IsValidSharedPath(string aPath)
        {
            bool result = false;

            try
            {
                Uri networkPath = new Uri(aPath);
                if (networkPath.IsUnc)
                {
                    result = Directory.Exists(Path.GetPathRoot(aPath));
                }
            }
            catch (Exception)
            {
                result = false;
            }

            if (result == false && FileTransferServiceSettings.Default.SharedFolders.Count > 0)
            {
                foreach (string path in FileTransferServiceSettings.Default.SharedFolders)
                {
                    if (path.StartsWith(aPath))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public FileTransferResult UploadFile(RemoteFileInfo aFileInfo)
        {
            FileTransferResult result = new FileTransferResult();
            result.FileByteStream = Stream.Null;
            try
            {
                if (aFileInfo == null || (IsValidSharedPath(aFileInfo.TargetDirectory) == false && string.IsNullOrEmpty(aFileInfo.FileName) == false))
                {
                    result.IsTransferSuccess = false;
                    result.Message = "Isn't valid shared path";
                    return result;
                }
                result.FileName = aFileInfo.FileName;

                if (Log.Instance.LastMsg.StartsWith("Upload file "))
                {
                    Log.Instance.WriteLine(string.Format("Upload file [{1}%]: {0} to \"{2}\"", aFileInfo.FileName, aFileInfo.Percentage, aFileInfo.TargetDirectory), true);
                }
                else
                {
                    Log.Instance.WriteLine(string.Format("Upload file [{1}%]: {0} to \"{2}\"", aFileInfo.FileName, aFileInfo.Percentage, aFileInfo.TargetDirectory));
                }

                string filePath = Path.Combine(aFileInfo.TargetDirectory, aFileInfo.FileName);

                string dirNew = Path.GetDirectoryName(filePath);
                if (Directory.Exists(dirNew) == false)
                {
                    Directory.CreateDirectory(dirNew);
                }

                FileStream targetStream = null;
                if (aFileInfo.IsHeader)
                {
                    targetStream = File.Create(filePath);
                }
                else
                {
                    targetStream = new FileStream(filePath, FileMode.Append);
                }

                Stream sourceStream = aFileInfo.FileByteStream;
                try
                {
                    //read from the input stream in 4000 byte chunks
                    int bufferLen = FUploadBuffer;
                    byte[] buffer = new byte[bufferLen];
                    int count = 0;
                    do
                    {
                        count = sourceStream.Read(buffer, 0, bufferLen);
                        // save to output stream
                        targetStream.Write(buffer, 0, count);
                    } while (count > 0);
                    result.IsTransferSuccess = true;
                    result.Message = string.Empty;
                }
                finally
                {
                    targetStream.Close();
                    sourceStream.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.HandleException(ex);
                result.IsTransferSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        #endregion

    }
}
