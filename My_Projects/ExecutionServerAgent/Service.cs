using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Xml;


namespace Quest.Tuning.ExecutionServerAgent
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
            
            //Add an eventlog to note error.

            if (!System.Diagnostics.EventLog.SourceExists("ExecutionServerAgentLogSourse"))
            {
                System.Diagnostics.EventLog.CreateEventSource("ExecutionServerAgentLogSourse",
                                                                      "ExecutionServerAgentLog");
            }
            //
            // the event log source by which 
            //the application is registered on the computer
            //

            ExecutionServerAgentLog.Source = "ExecutionServerAgentLogSourse";
            ExecutionServerAgentLog.Log = "ExecutionServerAgentLog";


        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            try
            {
                TActionClass.RunAction();
            }
            catch (Exception ex)
            {
                //note exception to log file.
                ExecutionServerAgentLog.WriteEntry(ex.ToString());
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }

    #region action for service
    /// <summary>
    /// function for services
    /// Peter Qin -- August 25, 2010
    /// </summary>
    class TActionClass
    {
        /// <summary>
        /// copy file from srcFile to destFile
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="destFile"></param>
        #region Static
        public static void CopyFile(string srcFile, string destFile)
        {
       
                File.Copy(srcFile, destFile, true);

        }
        /// <summary>
        /// copy folder from srcDirectory to destDirectory
        /// </summary>
        /// <param name="srcDirectory"></param>
        /// <param name="destDirectory"></param>
        public static void CopyDirectory(string srcDirectory, string destDirectory)
        {
            
            if (Path.DirectorySeparatorChar != destDirectory[destDirectory.Length - 1])
            {
                destDirectory += Path.DirectorySeparatorChar;
            }
            if (!Directory.Exists(destDirectory))
            {
                Directory.CreateDirectory(destDirectory);
            }
            string[] filelist = Directory.GetFileSystemEntries(srcDirectory);            
            foreach (string file in filelist)
            {
                if (Directory.Exists(file))
                {
                    //
                    //use this method again to copy sub directory
                    //recursion
                    //
                    CopyDirectory(file, destDirectory + Path.GetFileName(file));
                }
                else
                {
                    File.Copy(file, destDirectory + Path.GetFileName(file), true);
                }
            }



        }
        /// <summary>
        /// Launch the Application in srcApplication
        /// </summary>
        /// <param name="srcApplication"></param>
        public static void LaunchApplication(string srcApplication, string arguments)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = srcApplication;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

        }
        /// <summary>
        /// Read XML from installation folder
        /// then run the right function.
        /// </summary>
        public static void RunAction()
        {
            string XMLFilePath = Application.StartupPath + "\\tasks.xml";
            
            XmlDocument doucument = new XmlDocument();

            doucument.Load(XMLFilePath);
            foreach (XmlNode node in doucument.ChildNodes[0].ChildNodes)
            {
                switch (node.Name.ToString())
                {
                    case "CopyFolder":
                        CopyDirectory(node.ChildNodes[0].InnerText, node.ChildNodes[1].InnerText);
                        break;
                    case "CopyFile":
                        CopyFile(node.ChildNodes[0].InnerText, node.ChildNodes[1].InnerText);
                        break;
                    case "RunProgram":
                        LaunchApplication(node.ChildNodes[0].InnerText, node.ChildNodes[1].InnerText);
                        break;
                    default:
                        break;
                }


            }
        }
        #endregion static


    }
    #endregion action for service
}
