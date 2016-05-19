using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UpdateAssemblyInfo
{
    public class Log
    {
        private StringBuilder FLogMsg = new StringBuilder();
        private bool FLogToFile = false;

        public bool LogToFile
        {
            get { return FLogToFile; }
            set { FLogToFile = value; }
        }

        private static readonly Log FInstance = new Log();

        public static Log Instance
        {
            get { return Log.FInstance; }
        }

        private Log() 
        {             
        }
        
        public void Output(string aMsg)
        {
            if (LogToFile)
            {
                FLogMsg.AppendLine(aMsg);
            }
            Console.WriteLine(aMsg);
        }

        public void Save()
        {
            if (LogToFile == false)
            {
                return;
            }
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".log");
            if (File.Exists(logFile))
            {
                File.Delete(logFile);   
            }
            File.AppendAllText(logFile, FLogMsg.ToString());
        }
    }
}
