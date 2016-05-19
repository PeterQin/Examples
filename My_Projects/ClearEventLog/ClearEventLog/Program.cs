using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ClearEventLog
{
    
    class Program
    {
        
        private const string C_EventSource = "ESXiHelperEventSource";
        private const string C_EventLog = "ESXiHelperEventLog";
        static void Main(string[] args)
        {
            try
            {
                EventLog EXSiEventLog = new EventLog();
                if (!EventLog.SourceExists(C_EventSource))
                {
                    EventLog.CreateEventSource(C_EventSource, C_EventLog);
                }
                EXSiEventLog.Source = C_EventSource;
                EXSiEventLog.Log = C_EventLog;
                EXSiEventLog.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
           
        }
    }
}
