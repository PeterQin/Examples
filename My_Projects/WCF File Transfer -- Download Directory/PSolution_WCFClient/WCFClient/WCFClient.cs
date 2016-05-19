using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace ServiceModelSamples
{
    class WCFClient
    {
        const string endPoint = "NetTcpBinding_ICalculator";
        static void Main(string[] args)
        {
            //Step 1: Create an endpoint address and an instance of the WCF Client.           
            CalculatorClient client = new CalculatorClient(endPoint);

            try
            {
                //DownLoadFile(client, @"C:\4.txt", @"C:\2.txt");
                DownLoadDirectory(client, @"D:\Software\", @"D:\test2\");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine("StackTrace:\r\n");
                Console.WriteLine(ex.StackTrace);

            }
            finally
            {
                client.Abort();
                //Step 3: Closing the client gracefully closes the connection and cleans up resources.
                client.Close();
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();

        }

        private static void Operation(CalculatorClient aClient)
        {
             //Step 2: Call the service operations.
             //Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = aClient.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = aClient.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = aClient.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = aClient.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
        }

        private static void DownLoadFile(CalculatorClient aClient, string aSourcePath, string aDestinationPath)
        {
            string strFileName = aSourcePath;


            //long lngFileLength = client.FileSpicalSize(strFileName);
            //Stream streamFileContent = client.DownloadFileSpical(strFileName);


            //Stream streamFileContent;
            //long lngFileLength = client.DownloadFileWithMsgContract(ref strFileName, out streamFileContent);


            //Stream streamFileContent = client.DownloadFileSpicalWithLength(strFileName);
            //long lngFileLength = streamFileContent.Length;

            long lngFileLength = aClient.FileSpicalSize(strFileName);
            long offset = 0;
            long count = 4000;

            Console.WriteLine("Download file from [" + strFileName +"] to ["+aDestinationPath+"]");
            int intFileSize = Convert.ToInt32((double)lngFileLength / 1024);
            Console.WriteLine("File Size: " + intFileSize.ToString() + " KB");
            bool isEnd = true;
            int totalByteRead = 0;
            using (FileStream fsFile = File.Create(aDestinationPath))
            {

                do
                {
                    isEnd = true;
                    Stream streamFileContent = aClient.DownloadFileWithCustomStream(strFileName, offset, count);
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
                            Console.WriteLine("Process: " + (int)(currentProgress * 100) + " %");                            
                            if (byteRead > 0)
                            {
                                isEnd = false;
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
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

        private static void DownLoadDirectory(CalculatorClient aClient, string aSourcePath, string aDestinationPath)
        {
            DateTime beginTime = DateTime.Now;
            string[] files = aClient.GetFiles(aSourcePath, "*.*", SearchOption.AllDirectories);
            int CurrentFileNum = 1;
            foreach (string var in files)
            {
                Console.WriteLine("Process: " + CurrentFileNum + " in "+ files.Length);
                string FileOrSubDirectory = var.Remove(0, aSourcePath.Length);
                string NewPath = Path.Combine(aDestinationPath, FileOrSubDirectory);
                string NewSubDire = Path.GetDirectoryName(NewPath);
                if (Directory.Exists(NewSubDire) == false) 
                {
                    Directory.CreateDirectory(NewSubDire);
                }
                DownLoadFile(aClient, var, NewPath);
                CurrentFileNum++;
            }
            TimeSpan totaluse = DateTime.Now.Subtract(beginTime);
            Console.WriteLine(totaluse.ToString());
        }
    }
}
