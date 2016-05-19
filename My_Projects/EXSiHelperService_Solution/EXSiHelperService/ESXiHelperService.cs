using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using Vestris.VMWareLib;
using System.ServiceModel.Description;

namespace AJMS
{
    public partial class ESXiHelperService : ServiceBase
    {

        #region Field

        private ServiceHost FSvcHost;
        public const string C_EventSource = "ESXiHelperEventSource";
        public const string C_EventLog = "ESXiHelperEventLog";
        #endregion Field

        public ESXiHelperService()
        {
            InitializeComponent();
            if (!EventLog.SourceExists(C_EventSource))  //create a Event Log
            {
                EventLog.CreateEventSource(C_EventSource, C_EventLog);
            }
            EXSiEventLog.Source = C_EventSource;
            EXSiEventLog.Log = C_EventLog;
        }

        protected override void OnStart(string[] args)
        {
            StartService();
        }

        protected override void OnStop()
        {
            StopService();
        }

        private void StartService()
        {
            try
            {

                Uri baseAddress = new Uri("http://localhost:8061/TESXiHelper");

                FSvcHost = new ServiceHost(typeof(TESXiHelper), baseAddress);

                WSHttpBinding wsBinding = new WSHttpBinding();
                wsBinding.Security.Mode = SecurityMode.None;

                NetTcpBinding tcpBinding = new NetTcpBinding();
                tcpBinding.Security.Mode = SecurityMode.Transport;

                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

                FSvcHost.AddServiceEndpoint(typeof(IESXiHelper), wsBinding, baseAddress);

                FSvcHost.AddServiceEndpoint(typeof(IESXiHelper), tcpBinding, "net.tcp://localhost:8062/TESXiHelper");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                FSvcHost.Description.Behaviors.Add(smb);

                FSvcHost.Open();
                EXSiEventLog.WriteEntry("EXSi Helper Service is ready");

            }
            catch (Exception ex)
            {
                EXSiEventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        private void StopService()
        {
            try
            {
                if (FSvcHost != null && FSvcHost.State == CommunicationState.Opened)
                {
                    FSvcHost.Close();
                    EXSiEventLog.WriteEntry("EXSi Helper Service is closed");
                }
            }
            catch (Exception ex)
            {
                EXSiEventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

        }
    }

    [ServiceContract]
    public interface IESXiHelper
    {
        /// <summary>
        /// Power on VM on EXSi server
        /// </summary>
        /// <param name="aHost">EXSi server</param>
        /// <param name="aHostLogin">User name</param>
        /// <param name="aHostPwd">Password</param>
        /// <param name="aVMFile">VM configuration file</param>
        /// <param name="aSnapshot">Snapshot use to test</param>
        /// <returns>SUCCESS if power on aVMFile successfully; Otherwise, exception message</returns>
        [OperationContract]
        string PowerOnVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile, string aSnapshot);

        /// <summary>
        /// Power on VM on EXSi server
        /// </summary>
        /// <param name="aHost">EXSi server</param>
        /// <param name="aHostLogin">User name</param>
        /// <param name="aHostPwd">Password</param>
        /// <param name="aVMFile">VM configuration file</param>
        /// <returns>SUCCESS if power off aVMFile sucessfully; Otherwise, exception message</returns>
        [OperationContract]
        string PowerOffVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile);

        /// <summary>
        /// Get all snapshots on VM
        /// </summary>
        /// <param name="aHost">EXSi server</param>
        /// <param name="aHostLogin">User name</param>
        /// <param name="aHostPwd">Password</param>
        /// <param name="aVMFile">VM configuration file</param>
        /// <returns>All snapshots name if no exception; Otherwise, empty string array</returns>
        [OperationContract]
        string[] GetSnapshotList(string aHost, string aHostLogin, string aHostPwd, string aVMFile);

    }

    class TESXiHelper : IESXiHelper
    {
        #region Field
        EventLog EXSiEventLog = new EventLog();
        private VMWareVirtualHost FCurrentHost = null;
        private VMWareVirtualMachine FCurrentVM = null;
        private string FCurrentHostName = string.Empty;

        #region Const / Enum / Delegate / Event

        private const string C_Success = "SUCCESS";

        #endregion Const / Enum / Delegate / Event

        #endregion Field

        #region Constructor & Destroyer

        public TESXiHelper()
        {
            Init();
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private void Init()
        {
            FCurrentHost = new VMWareVirtualHost();
            FCurrentVM = null;
            if (!EventLog.SourceExists(ESXiHelperService.C_EventSource))
            {
                EventLog.CreateEventSource(ESXiHelperService.C_EventSource, ESXiHelperService.C_EventLog);
            }
            EXSiEventLog.Source = ESXiHelperService.C_EventSource;
            EXSiEventLog.Log = ESXiHelperService.C_EventLog;
        }

        private void ConnectToHost(string aHost, string aHostLogin, string aHostPwd)
        {
            if (FCurrentHostName.ToLower().Equals(aHost.ToLower()) && FCurrentHost.IsConnected)
            {
                EXSiEventLog.WriteEntry(aHost + " is connected");
            }
            else
            {
                FCurrentHostName = aHost;
                EXSiEventLog.WriteEntry("Connecting to Host: " + aHost);
                FCurrentHost.ConnectToVMWareVIServer(aHost, aHostLogin, aHostPwd);
                EXSiEventLog.WriteEntry("Connect success");
            }
        }

        #endregion Private Section

        #region Public Section

        /// <summary>
        /// Power on VM on EXSi server
        /// </summary>
        /// <param name="aHost">EXSi server</param>
        /// <param name="aHostLogin">User name</param>
        /// <param name="aHostPwd">Password</param>
        /// <param name="aVMFile">VM configuration file</param>
        /// <param name="aSnapshot">Snapshot use to test</param>
        /// <returns>SUCCESS if power on aVMFile successfully; Otherwise, exception message</returns>
        public string PowerOnVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile, string aSnapshot)
        {
            string Result = C_Success;
            try
            {

                ConnectToHost(aHost, aHostLogin, aHostPwd);     //Check is this host connected, if no, connect it.            
                FCurrentVM = FCurrentHost.Open(aVMFile, 800);
                VMWareSnapshot sn = FCurrentVM.Snapshots.FindSnapshotByName(aSnapshot);
                if (sn != null)
                {
                    sn.RevertToSnapshot(300);
                    EXSiEventLog.WriteEntry("Powering on: " + aVMFile);
                    FCurrentVM.PowerOn(700);
                    EXSiEventLog.WriteEntry("Power on success");
                    EXSiEventLog.WriteEntry("Waiting for VM Tool in guest");
                    FCurrentVM.WaitForToolsInGuest(700);
                    EXSiEventLog.WriteEntry("VM Tool is ready");
                }
                else
                {
                    Result = "PowerOnVM Fail: " + aSnapshot + "cannot found";
                    return Result;
                }

            }
            catch (Exception ex)
            {
                string exceptionMessage = "PowerOnVM: " + ex.Message;
                EXSiEventLog.WriteEntry(exceptionMessage, EventLogEntryType.Error);
                Result = exceptionMessage;
            }
            return Result;
        }

        /// <summary>
        /// Power on VM on EXSi server
        /// </summary>
        /// <param name="aHost">EXSi server</param>
        /// <param name="aHostLogin">User name</param>
        /// <param name="aHostPwd">Password</param>
        /// <param name="aVMFile">VM configuration file</param>
        /// <returns>SUCCESS if power off aVMFile sucessfully; Otherwise, exception message</returns>
        public string PowerOffVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile)
        {
            string Result = C_Success;
            try
            {
                ConnectToHost(aHost, aHostLogin, aHostPwd);
                FCurrentVM = FCurrentHost.Open(aVMFile, 600);
                EXSiEventLog.WriteEntry("Powering off: " + aVMFile);
                FCurrentVM.PowerOff(0, 700);
                EXSiEventLog.WriteEntry("Power off success");

            }
            catch (Exception ex)
            {
                string exceptionMessage = "PowerOffVM: " + ex.Message;
                EXSiEventLog.WriteEntry(exceptionMessage, EventLogEntryType.Error);
                Result = exceptionMessage;
            }

            return Result;
        }

        /// <summary>
        /// Get all snapshots on VM
        /// </summary>
        /// <param name="aHost">EXSi server</param>
        /// <param name="aHostLogin">User name</param>
        /// <param name="aHostPwd">Password</param>
        /// <param name="aVMFile">VM configuration file</param>
        /// <returns>All snapshots name if no exception; Otherwise, empty string array</returns>
        public string[] GetSnapshotList(string aHost, string aHostLogin, string aHostPwd, string aVMFile)
        {
            List<string> Result = new List<string>();
            try
            {
                ConnectToHost(aHost, aHostLogin, aHostPwd);
                FCurrentVM = FCurrentHost.Open(aVMFile, 600);
                foreach (VMWareSnapshot varVMWareSnapshot in FCurrentVM.Snapshots)
                {
                    Result.Add(varVMWareSnapshot.DisplayName);
                    Result.AddRange(GetSnapshotNameList(varVMWareSnapshot.ChildSnapshots));
                }
                EXSiEventLog.WriteEntry(Result.Count + " Snapshots in " + aVMFile);
            }
            catch (Exception ex)
            {
                EXSiEventLog.WriteEntry("GetSnapshotList" + ex.Message, EventLogEntryType.Error);
            }
            return Result.ToArray();
        }

        private List<string> GetSnapshotNameList(VMWareSnapshotCollection aSnapshots)
        {
            List<string> newSnapshotList = new List<string>();

            foreach (VMWareSnapshot sn in aSnapshots)
            {
                newSnapshotList.Add(sn.DisplayName);
                newSnapshotList.AddRange(GetSnapshotNameList(sn.ChildSnapshots));
            }
            return newSnapshotList;
        }

        #endregion Public Section

    }
}
