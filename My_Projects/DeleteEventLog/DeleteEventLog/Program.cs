using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DeleteEventLog
{
    class Program
    {
        private const string C_EventSource = "ESXiHelperEventSource";
        static void Main(string[] args)
        {
            try
            {
                if (EventLog.SourceExists(C_EventSource))
                {
                    string logName = EventLog.LogNameFromSourceName(C_EventSource, System.Environment.MachineName);
                    EventLog.DeleteEventSource(C_EventSource, System.Environment.MachineName);
                    EventLog.Delete(logName, System.Environment.MachineName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
