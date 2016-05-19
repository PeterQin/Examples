using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Vestris.VMWareLib;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Activation;

namespace AJMS
{
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
        /// <returns>Ture if power on aVMFile successfully; Otherwise, false</returns>
        [OperationContract]
        bool PowerOnVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile, string aSnapshot);

        /// <summary>
        /// Power on VM on EXSi server
        /// </summary>
        /// <param name="aHost">EXSi server</param>
        /// <param name="aHostLogin">User name</param>
        /// <param name="aHostPwd">Password</param>
        /// <param name="aVMFile">VM configuration file</param>
        /// <returns>Ture if power off aVMFile sucessfully; Otherwise, false</returns>
        [OperationContract]
        bool PowerOffVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile);

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
        private VMWareVirtualHost FCurrentHost = null;
        private VMWareVirtualMachine FCurrentVM = null;
        private string FLastHostName = string.Empty;

        #region Const / Enum / Delegate / Event

        private const bool C_Success = true;
        private const bool C_Failure = false;

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
        }

        private void ConnectToHost(string aHost, string aHostLogin, string aHostPwd)
        {
            if (FLastHostName.Equals(aHost) == false || FCurrentHost.IsConnected == false)
            {
                FLastHostName = aHost;
                Console.WriteLine("Connecting to Host: " + aHost);
                FCurrentHost.ConnectToVMWareVIServer(aHost, aHostLogin, aHostPwd);
                Console.WriteLine("Connect success");
            }
            else
            {
                Console.WriteLine(aHost + " is connected");
            }
        }

        #endregion Private Section

        #region Public Section

        public bool PowerOnVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile, string aSnapshot)
        {
            bool Result = C_Success;
            try
            {

                ConnectToHost(aHost, aHostLogin, aHostPwd);     //Check is this host connected, if no, connect it.            
                FCurrentVM = FCurrentHost.Open(aVMFile, 800);
                VMWareSnapshot sn = FCurrentVM.Snapshots.FindSnapshotByName(aSnapshot);
                if (sn != null)
                {
                    sn.RevertToSnapshot(300);
                    Console.WriteLine("Powering on: " + aVMFile);
                    FCurrentVM.PowerOn(700);
                    Console.WriteLine("Power on success");
                    Console.WriteLine("Waiting for VM Tool in guest");
                    FCurrentVM.WaitForToolsInGuest(800);
                    Console.WriteLine("VM Tool is ready");
                }
                else
                {
                    Result = C_Failure;
                    return Result;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = C_Failure;
            }
            return Result;
        }

        public bool PowerOffVM(string aHost, string aHostLogin, string aHostPwd, string aVMFile)
        {
            bool Result = C_Success;
            try
            {
                ConnectToHost(aHost, aHostLogin, aHostPwd);
                FCurrentVM = FCurrentHost.Open(aVMFile, 600);
                Console.WriteLine("Powering off: " + aVMFile);
                FCurrentVM.PowerOff(0, 700);
                Console.WriteLine("Power off success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = C_Failure;
            }

            return Result;
        }

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
                Console.WriteLine(Result.Count + " Snapshots in " + aVMFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

    class TESXiService
    {
        #region Field

        private static ServiceHost FSvcHost;

        #endregion Field

        #region Constructor & Destroyer

        static void Main(string[] args)
        {
            StartService();
            Console.WriteLine("Press <ENTER> to terminate service");
            Console.ReadLine();
            StopService();
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private static void StartService()
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
                Console.WriteLine("EXSi Helper Service is ready");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void StopService()
        {
            try
            {
                if (FSvcHost != null && FSvcHost.State == CommunicationState.Opened)
                {
                    FSvcHost.Close();
                    Console.WriteLine("EXSi Helper Service is closed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        #endregion Private Section        
       
    }
}
