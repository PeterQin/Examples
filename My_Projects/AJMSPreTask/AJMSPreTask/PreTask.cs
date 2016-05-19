using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AJMS
{

    public class PreTaskAndPostProcess
    {
        private IJobManagementService Service;
        public void Start()
        {
            ConnectToServer();
            string TaskXMLPath = Path.ChangeExtension(Path.GetTempFileName(), "xml");
            string content = Service.GetPreTask(Environment.MachineName);
            File.AppendAllText(TaskXMLPath, content);
            List<PreTaskAndPostTask> Tasks = PreTaskAndPostTaskXML.TasksFromXML(TaskXMLPath);
            foreach (PreTaskAndPostTask task in Tasks)
            {
                if (task.CurrentType == PreTaskAndPostTaskType.RunProgram)
                {
                    RunProgram(task.ProgramFullName, task.Arguments, task.VisiableInUI, false);
                }
                else if (task.CurrentType == PreTaskAndPostTaskType.TransferFiles)
                {
                    DownLoadDirectory(task.Source, task.Destination);
                }
            }          
        }

        private void ConnectToServer()
        {
            Output.WriteLine("Connecting to job management service...");
            try
            {
                ChannelFactory<IJobManagementService> fac = new ChannelFactory<IJobManagementService>("DefaultEndpoint");
                Service = fac.CreateChannel();
                Service.RegisterConsole(Environment.MachineName);
                Output.WriteLine("Connected to Job Management Service version " + Service.Version());
            }
            catch (Exception e)
            {
                Output.WriteLine("Error connecting to service: " + e.Message);
                if (e.InnerException != null)
                {
                    Output.WriteLine("Inner exception: " + e.InnerException.ToString());
                }
            }
        }

        private void RunProgram(string aCmd, string aArg, bool aShowWindow, bool aWaitForExit)
        {
            Output.WriteLine("Launch " + aCmd + " " + aArg);
            ProcessStartInfo psi = new ProcessStartInfo(aCmd, aArg);            
            //psi.UseShellExecute = false;
            //psi.RedirectStandardError = true;
            //psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            if (aShowWindow)
            {
                psi.WindowStyle = ProcessWindowStyle.Hidden;
            }
            Process CurrentProcess = Process.Start(psi);

            //CurrentProcess.BeginErrorReadLine();
            //string strOutput = string.Empty;
            //while ((strOutput = CurrentProcess.StandardOutput.ReadLine()) != null)
            //{
            //    Output.WriteLine(strOutput);
            //}

            if (aWaitForExit)
            {
                CurrentProcess.WaitForExit();
            }
            Output.WriteLine("Complete -- Launch " + aCmd + " " + aArg);

        }

        private void DownLoadFile(string aSourcePath, string aDestinationPath)
        {
            string strFileName = aSourcePath;

            long lngFileLength = Service.FileSpicalSize(strFileName);
            long offset = 0;
            long count = 4000;

            Output.WriteLine("Download file from [" + strFileName + "] to [" + aDestinationPath + "]");
            int intFileSize = Convert.ToInt32((double)lngFileLength / 1024);
            Output.WriteLine("File Size: " + intFileSize.ToString() + " KB");
            bool isEnd = true;
            int totalByteRead = 0;
            using (FileStream fsFile = File.Create(aDestinationPath))
            {

                do
                {
                    isEnd = true;
                    Stream streamFileContent = Service.DownloadFileWithCustomStream(strFileName, offset, count);
                    try
                    {
                        offset = offset + count;
                        //Save file to local

                        int byteRead = 0;
                        byte[] buffer = new byte[4000];
                        do
                        {
                            byteRead = streamFileContent.Read(buffer, 0, buffer.Length);
                            fsFile.Write(buffer, 0, byteRead);
                            totalByteRead += byteRead;
                            double currentProgress = (double)totalByteRead / lngFileLength;
                            Output.WriteLine("Current File Process: " + (int)(currentProgress * 100) + " %");
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            if (byteRead > 0)
                            {
                                isEnd = false;                               
                            }

                        } while (byteRead > 0);
                    }
                    finally
                    {
                        streamFileContent.Close();
                    }

                } while (isEnd == false);

                fsFile.Close();
            }
        }

        private void DownLoadDirectory(string aSourcePath, string aDestinationPath)
        {
            DateTime beginTime = DateTime.Now;
            string[] files = Service.GetFiles(aSourcePath, "*.*", SearchOption.AllDirectories);
            int CurrentFileNum = 1;
            foreach (string var in files)
            {
                Output.WriteLine("Totle Files Process: " + CurrentFileNum + " in " + files.Length);
                string FileOrSubDirectory = var.Remove(0, aSourcePath.Length);
                string NewPath = Path.Combine(aDestinationPath, FileOrSubDirectory);
                string NewSubDire = Path.GetDirectoryName(NewPath);
                if (Directory.Exists(NewSubDire) == false)
                {
                    Directory.CreateDirectory(NewSubDire);
                }
                DownLoadFile(var, NewPath);
                CurrentFileNum++;
            }
            TimeSpan totaluse = DateTime.Now.Subtract(beginTime);
            Output.WriteLine("Time Spent [" + totaluse.ToString() + "]");
        }
    }

    public class Output
    {
        public static void WriteLine(string aMsg)
        {
            Console.WriteLine(aMsg);
        }
    }
}
