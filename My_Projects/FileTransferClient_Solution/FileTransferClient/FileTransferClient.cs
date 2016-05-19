using System;
using System.Collections.Generic;
using System.Text;
using Quest.Tuning.FileTransferCommon;
using System.ServiceModel;
using System.IO;
using System.Threading;

namespace Quest.Tuning.FileTransferClient
{
    public class FileTransferClient
    {
        private IFileTransfer FService;
        private ChannelFactory<IFileTransfer> FChannelFactory;
        private int FUploadBuffer = 50000;
        private int FDownloadBuffer = 8000;

        public FileTransferClient()
        {
            FUploadBuffer = FileTransferSetting.Default.UploadBuffer;
            FDownloadBuffer = FileTransferSetting.Default.DownloadBuffer;
        }

        ~FileTransferClient()
        {
            DisConnect();
        }

        public void DisConnect()
        {
            if (FChannelFactory != null)
            {
                if (FService != null && FChannelFactory.State == CommunicationState.Opened)
                {
                    FService.UnregisterClient(Environment.MachineName);
                }
                FChannelFactory.Abort();
                FChannelFactory.Close();
            }
            FService = null;
            FChannelFactory = null;
        }

        public void Connect()
        {
            FChannelFactory = new ChannelFactory<IFileTransfer>("NetTcpEndpoint");
            FService = FChannelFactory.CreateChannel();
            FService.RegisterClient(Environment.MachineName);
            string version = FService.GetVersion();
            Log.Instance.WriteLine("Service version: " + version);
        }

        public void ProcessTask(string aTaskXMLPath)
        {
            Log.Instance.WriteLine("Task start >>>>>>");
            Log.Instance.WriteLine("Task from " + aTaskXMLPath);
            if (File.Exists(aTaskXMLPath))
            {
                string taskXML = File.ReadAllText(aTaskXMLPath);
                List<TaskInfo> Tasks = TaskXMLOperator.TaskFromXML(taskXML);
                for (int i = 0; i < Tasks.Count; i++)
                {

                    TaskInfo task = Tasks[i];
                    StringBuilder sb = new StringBuilder();
                    Log.Instance.WriteLine("------------------------Task Info------------------------------");
                    Log.Instance.WriteLine(string.Format("Action: {0} *** Source: {1} *** Destination: {2}", task.CurrentType, task.Source, task.Destination));
                    Log.Instance.WriteLine("---------------------------------------------------------------");
                    task.Result = ProcessAction(task);
                }
                File.WriteAllText(aTaskXMLPath, TaskXMLOperator.TaskToXML(Tasks));
            }
            Log.Instance.WriteLine("Task complete <<<<<<<<");
        }

        public TaskResult ProcessAction(TaskInfo aTaskInfo)
        {
            TaskResult Result = new TaskResult();
            if (aTaskInfo != null && string.IsNullOrEmpty(aTaskInfo.Source) == false && string.IsNullOrEmpty(aTaskInfo.Destination) == false)
            {
                switch (aTaskInfo.CurrentType)
                {
                    case TaskType.Download:
                        Result = DownLoad(aTaskInfo.Source, aTaskInfo.Destination);
                        break;
                    case TaskType.Upload:
                        Result = Upload(aTaskInfo.Source, aTaskInfo.Destination);
                        break;
                }
            }
            return Result;
        }

        #region Download

        private TaskResult DownLoad(string aSourcePath, string aDestinationPath)
        {
            TaskResult Result = new TaskResult();
            if (IsFile(aSourcePath) && IsFile(aDestinationPath))
            {
                Result = DownLoadFile(aSourcePath, aDestinationPath);
            }
            else if (IsFile(aSourcePath) && IsFile(aDestinationPath) == false)
            {
                string DestinationFileFullName = Path.Combine(aDestinationPath, Path.GetFileName(aSourcePath));
                Result = DownLoadFile(aSourcePath, DestinationFileFullName);
            }
            else if (IsFile(aSourcePath) == false && IsFile(aDestinationPath) == false)
            {
                if (aDestinationPath.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                {
                    aDestinationPath = aDestinationPath + Path.DirectorySeparatorChar;
                }
                Result = DownLoadDirectory(aSourcePath, aDestinationPath);
            }
            return Result;
        }

        private TaskResult DownLoadDirectory(string aSourcePath, string aDestinationPath)
        {
            TaskResult Result = new TaskResult();
            if (string.IsNullOrEmpty(aSourcePath) == false && aSourcePath.Length > 1)
            {
                StringBuilder sbResultMsg = new StringBuilder();
                DateTime beginTime = DateTime.Now;
                string[] files = FService.GetFiles(aSourcePath, "*.*", SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    Result.ResultType = ResultType.Fail;
                    Result.ResultMessage = "No file found in sourec path: " + aSourcePath;
                }
                else
                {
                    int CurrentFileNum = 1;
                    foreach (string path in files)
                    {
                        Log.Instance.WriteLine("Totle Files Process: " + CurrentFileNum + " in " + files.Length);

                        //Get sub folder from host
                        if (aSourcePath.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                        {
                            aSourcePath = aSourcePath + Path.DirectorySeparatorChar.ToString();
                        }
                        string orgFileOrSubDirectory = path.Remove(0, aSourcePath.Length);

                        //Combine sub folder to Destination
                        string NewPath = Path.Combine(aDestinationPath, orgFileOrSubDirectory);
                        string newSubDirectory = Path.GetDirectoryName(NewPath);

                        if (Directory.Exists(newSubDirectory) == false)
                        {
                            Directory.CreateDirectory(newSubDirectory);
                        }
                        TaskResult fileResult = DownLoadFile(path, NewPath);
                        if (fileResult.ResultType == ResultType.Fail)
                        {
                            sbResultMsg.Append(string.Format("Download from {0} fail with exception: {1}\r\n", path, fileResult.ResultMessage));
                        }
                        CurrentFileNum++;

                    }
                    if (sbResultMsg.Length > 0)
                    {
                        Result.ResultType = ResultType.Fail;
                        Result.ResultMessage = sbResultMsg.ToString();
                    }
                    else
                    {
                        Result.ResultType = ResultType.Success;
                    }
                    TimeSpan totaluse = DateTime.Now.Subtract(beginTime);
                    Log.Instance.WriteLine("Time Spent [" + totaluse.ToString() + "]");
                }
                
            }
            else
            {
                Result.ResultType = ResultType.Fail;
                Result.ResultMessage = "Source path can't be empty! "; 
            }
            
            return Result;
        }

        private TaskResult DownLoadFile(string aSourcePath, string aDestinationPath)
        {
            TaskResult Result = new TaskResult();
            Result.ResultType = ResultType.None;
            string targetFolder = Path.GetDirectoryName(aDestinationPath);
            bool isCreateTargetFolder = false;
            try
            {
                
                long lngFileLength = FService.GetFileSize(aSourcePath);
                long offset = 0;
                long count = FDownloadBuffer;

                Log.Instance.WriteLine("Download file from [" + aSourcePath + "] to [" + aDestinationPath + "]");
                int intFileSize = Convert.ToInt32((double)lngFileLength / 1024);
                Log.Instance.WriteLine("File Size: " + intFileSize.ToString() + " KB");
                int totalByteRead = 0;
                int percentage = 0;

                RemoteFileInfo fileInfo = new RemoteFileInfo();
                fileInfo.FileByteStream = Stream.Null;
                fileInfo.FileFullName = aSourcePath;
                fileInfo.FileName = Path.GetFileName(aSourcePath);
                fileInfo.IsHeader = true;
                fileInfo.Length = count;
                fileInfo.Offset = offset;
                fileInfo.Percentage = percentage;
                fileInfo.StreamLength = 0;
                fileInfo.TargetDirectory = targetFolder;

                
                if (Directory.Exists(targetFolder) == false)
                {
                    Directory.CreateDirectory(targetFolder);
                    isCreateTargetFolder = true;
                }

                using (FileStream fsFile = File.Create(aDestinationPath))
                {
                    do
                    {
                        FileTransferResult streamFileContent = FService.DownloadFile(fileInfo);
                        if (streamFileContent.IsTransferSuccess == false)
                        {
                            Result.ResultType = ResultType.Fail;
                            Result.ResultMessage = streamFileContent.Message;
                            break;
                        }
                        try
                        {
                            offset = offset + count;
                            //Save file to local
                            int byteRead = 0;
                            byte[] buffer = new byte[count];
                            do
                            {
                                byteRead = streamFileContent.FileByteStream.Read(buffer, 0, buffer.Length);
                                fsFile.Write(buffer, 0, byteRead);
                                totalByteRead += byteRead;
                                percentage = (int)(((double)totalByteRead / lngFileLength) * 100);
                                Log.Instance.WriteLine("Current File Process: " + percentage + " %");
                                Console.SetCursorPosition(0, Console.CursorTop - 1);

                            } while (byteRead > 0);
                        }
                        finally
                        {
                            streamFileContent.FileByteStream.Close();
                        }
                        if (fileInfo.IsHeader)
                        {
                            fileInfo.IsHeader = false;
                        }                        
                        fileInfo.Offset = offset;
                        fileInfo.Percentage = percentage;

                    } while (offset < lngFileLength);

                    fsFile.Close();
                    if (Result.ResultType == ResultType.None)
                    {
                        Result.ResultType = ResultType.Success;
                        Result.ResultMessage = string.Empty;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Log.Instance.HandleException(ex);
                Result.ResultType = ResultType.Fail;
                Result.ResultMessage = ex.Message;
            }
            
            //Cleanup if error
            if (Result.ResultType == ResultType.Fail)
            {
                if (File.Exists(aDestinationPath))
                {
                    File.Delete(aDestinationPath);
                }
                if (isCreateTargetFolder && Directory.Exists(targetFolder))
                {
                    Directory.Delete(targetFolder);
                }
                Log.Instance.WriteLine(string.Format("Error!!! Fail to download file {0} \r\nError Message: {1}", aSourcePath, Result.ResultMessage));
            }

            return Result;
        }

        private bool IsFile(string aPath)
        {
            return string.IsNullOrEmpty(Path.GetExtension(aPath)) == false;
        }

        #endregion Download

        #region Upload

        private TaskResult Upload(string aSourcePath, string aDestinationPath)
        {
            TaskResult Result = new TaskResult();
            if (IsFile(aSourcePath) && IsFile(aDestinationPath))
            {
                Result = UploadFile(aSourcePath, aDestinationPath);
            }
            else if (IsFile(aSourcePath) && IsFile(aDestinationPath) == false)
            {
                string DestinationFileFullName = Path.Combine(aDestinationPath, Path.GetFileName(aSourcePath));
                Result = UploadFile(aSourcePath, DestinationFileFullName);
            }
            else if (IsFile(aSourcePath) == false && IsFile(aDestinationPath) == false)
            {
                Result = UploadFolder(aSourcePath, aDestinationPath);
            }
            return Result;
        }

        private TaskResult UploadFile(string aSourcePath, string aDestinationPath)
        {
            TaskResult Result = new TaskResult();
            try
            {
                if (File.Exists(aSourcePath) == false)
                {
                    Result.ResultType = ResultType.Fail;
                    Result.ResultMessage = "Can't found the file: " + aSourcePath;
                }
                else
                {
                    string sourceFileName = Path.GetFileName(aSourcePath);
                    long offset = 0;
                    long count = FUploadBuffer;
                    int currentProgress = 0;
                    long lngFileLength = new FileInfo(aSourcePath).Length;

                    RemoteFileInfo uploadRequestInfo = new RemoteFileInfo();
                    uploadRequestInfo.FileName = Path.GetFileName(aDestinationPath);
                    uploadRequestInfo.FileFullName = aDestinationPath;
                    uploadRequestInfo.TargetDirectory = Path.GetDirectoryName(aDestinationPath);
                    uploadRequestInfo.IsHeader = true;                    
                    uploadRequestInfo.Offset = offset;
                    uploadRequestInfo.Length = count;
                    uploadRequestInfo.Percentage = currentProgress;

                    do
                    {
                       
                        using (CustomFileStream stream = new CustomFileStream(aSourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, offset, count))
                        {
                            offset = offset + count;
                            currentProgress = (int)(((double)offset / lngFileLength) * 100);
                            uploadRequestInfo.StreamLength = stream.Length;
                            uploadRequestInfo.FileByteStream = stream;
                            uploadRequestInfo.Percentage = currentProgress > 100 ? 100 : currentProgress;      

                            FileTransferResult transferResult = FService.UploadFile(uploadRequestInfo);

                            if (uploadRequestInfo.IsHeader)
                            {
                                uploadRequestInfo.IsHeader = false;
                            }
                           
                            if (transferResult.IsTransferSuccess == false)
                            {
                                Result.ResultType = ResultType.Fail;
                                Result.ResultMessage = "Upload file error: " + transferResult.Message;
                                Log.Instance.WriteLine(Result.ResultMessage);
                                break;
                            }
                        }

                        if (Log.Instance.LastMsg.StartsWith("Upload file ["))
                        {
                            Log.Instance.WriteLine(string.Format("Upload file [{1}%]: {0} to \"{2}\"", sourceFileName, uploadRequestInfo.Percentage, uploadRequestInfo.TargetDirectory), true);
                        }
                        else
                        {
                            Log.Instance.WriteLine(string.Format("Upload file [{1}%]: {0} to \"{2}\"", sourceFileName, uploadRequestInfo.Percentage, uploadRequestInfo.TargetDirectory));
                        }


                    } while (offset < lngFileLength);

                    Result.ResultType = ResultType.Success;
                    Result.ResultMessage = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                Result.ResultMessage = ex.Message;
                Result.ResultType = ResultType.Fail;
                Log.Instance.HandleException(ex);
            }
            return Result;

        }

        private TaskResult UploadFolder(string aSourcePath, string aDestinationPath)
        {
            TaskResult Result = new TaskResult();
            if (Directory.Exists(aSourcePath) == false)
            {
                Result.ResultType = ResultType.Fail;
                Result.ResultMessage = "Can't found directory: " + aSourcePath;
            }
            else
            {
                StringBuilder sbResultMsg = new StringBuilder();
                DateTime beginTime = DateTime.Now;
                string[] files = Directory.GetFiles(aSourcePath, "*.*", SearchOption.AllDirectories);
                int CurrentFileNum = 1;
                foreach (string path in files)
                {
                    Log.Instance.WriteLine("Totle Files Process: " + CurrentFileNum + " in " + files.Length);
                    //Get sub folder from host
                    if (aSourcePath.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                    {
                        aSourcePath = aSourcePath + Path.DirectorySeparatorChar.ToString();
                    }
                    string orgFileOrSubDirectory = path.Remove(0, aSourcePath.Length);

                    //Combine sub folder to Destination
                    string NewPath = Path.Combine(aDestinationPath, orgFileOrSubDirectory);
                    
                    TaskResult fileResult = UploadFile(path, NewPath);
                    if (fileResult.ResultType == ResultType.Fail)
                    {
                        sbResultMsg.Append(string.Format("Download from {0} fail with exception: {1}\r\n", path, fileResult.ResultMessage));
                    }
                    CurrentFileNum++;
                }
                if (sbResultMsg.Length > 0)
                {
                    Result.ResultType = ResultType.Fail;
                    Result.ResultMessage = sbResultMsg.ToString();
                }
                else
                {
                    Result.ResultType = ResultType.Success;
                }
                TimeSpan totaluse = DateTime.Now.Subtract(beginTime);
                Log.Instance.WriteLine("Time Spent [" + totaluse.ToString() + "]");
            }
            
            return Result;

        }

        #endregion Upload

       
        
    }
}
