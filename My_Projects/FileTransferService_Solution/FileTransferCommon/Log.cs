using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Quest.Tuning.FileTransferCommon
{
    public class Log
    {
        private static readonly Log FInstance = new Log();
        private EventLog FEXSiEventLog = null;
        public const string C_EventSource = "FileTransferEventSource";
        public const string C_EventLog = "FileTransferEventLog";
        public static Log Instance
        {
            get
            {
                return FInstance;
            }
        }

        private bool FIsConsoleLog = false;

        public bool IsConsoleLog
        {
            get { return FIsConsoleLog; }
            set { FIsConsoleLog = value; }
        }

        private bool FIsEventLog = false;

        public bool IsEventLog
        {
            get { return FIsEventLog; }
            set 
            {
                if (FIsEventLog != value)
                {
                    FIsEventLog = value;
                    InitEventLog();
                }
                
            }
        }


        private string FLastMsg = string.Empty;

        public string LastMsg
        {
            get { return FLastMsg; }
        }

        private Log() 
        { 
        }

        private void InitEventLog()
        {
            FEXSiEventLog = new EventLog();
            if (!EventLog.SourceExists(C_EventSource))
            {
                EventLog.CreateEventSource(C_EventSource, C_EventLog);
            }
            FEXSiEventLog.Source = C_EventSource;
            FEXSiEventLog.Log = C_EventLog;
        }

        public void LogInfo(string aMessage)
        {
            FEXSiEventLog.WriteEntry(aMessage);
        }

        public void LogError(string aMessage)
        {
            FEXSiEventLog.WriteEntry(aMessage, EventLogEntryType.Error);
        }

        public void LogWarning(string aMessage)
        {
            FEXSiEventLog.WriteEntry(aMessage, EventLogEntryType.Warning);
        }


        public void WriteLine(string aMsg)
        {
            WriteLine(aMsg, false);
        }

        public void WriteLine(string aMsg, bool aReplaceCurrentLine)
        {
            FLastMsg = aMsg;

            if (IsConsoleLog)
            {
                if (aReplaceCurrentLine)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                }
                Console.WriteLine(string.Format("[{0}]  {1}", DateTime.Now.ToLongTimeString(), aMsg));
            }            

            if (FIsEventLog)
            {
                LogInfo(aMsg);
            }
        }

        public void HandleException(Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            if (IsConsoleLog)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }            

            if (FIsEventLog)
            {
                LogError(ex.Message + "\r\n" + ex.StackTrace);
            }
            
        }
    }
}
