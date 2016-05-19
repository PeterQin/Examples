using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using Quest.Tuning.FileTransferService;
using System.ServiceModel;

namespace Quest.Tuning.FileTransferWindowsService
{
    public partial class FileTransferWindowsService : ServiceBase
    {
        private FileTransfer FFileTransfer = null;
        private ServiceHost FSvcHost;
        public const string C_EventSource = "FileTransferServiceEventSource";
        public const string C_EventLog = "FileTransferServiceEventLog";

        public FileTransferWindowsService()
        {
            InitializeComponent();
            FFileTransfer = new FileTransfer();

            if (!EventLog.SourceExists(C_EventSource))  //create a Event Log
            {
                EventLog.CreateEventSource(C_EventSource, C_EventLog);
            }
            FileTransferServiceEventLog.Source = C_EventSource;
            FileTransferServiceEventLog.Log = C_EventLog;

        }

        ~FileTransferWindowsService()
        {
            StopService();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            StartService();

        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            StopService();

        }

        private void StartService()
        {
            try
            {

                Uri baseAddress = new Uri("http://localhost:6060/");

                FSvcHost = new ServiceHost(FFileTransfer, baseAddress);

                FSvcHost.Open();
                FileTransferServiceEventLog.WriteEntry("File Transfer Service is ready");

            }
            catch (Exception ex)
            {
                FileTransferServiceEventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        private void StopService()
        {
            try
            {
                if (FSvcHost != null && FSvcHost.State == CommunicationState.Opened)
                {
                    FSvcHost.Close();
                    FileTransferServiceEventLog.WriteEntry("File Transfer Service is closed");
                }
            }
            catch (Exception ex)
            {
                FileTransferServiceEventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

        }
    }
    
}
