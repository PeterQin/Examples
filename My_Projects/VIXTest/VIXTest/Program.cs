using System;
using System.Collections.Generic;
using System.Text;
using Vestris.VMWareLib;
using System.Threading;

namespace VIXTest
{
    class Program
    {
        private static VMWareVirtualHost FCurrentHost;
        private static VMWareVirtualMachine FCurrentMachine;
        private const string C_Success = "success";
        static void Main(string[] args)
        {
            //string Host = "zhu11241.prod.quest.corp";
            //string HostLogin = "root";
            //string HostPwd = "sqlexp!23456";
            //string VMFile = "[datastore2] ST_AUTO_WINXPEN_ES19/ST_AUTO_WINXPEN_ES19.vmx";
            //string Snapshot = "Backup";
            string Host = "zhu11155.prod.quest.corp";
            string HostLogin = "root";
            string HostPwd = "sqlexp!23456";
            string VMFile = "[datastore1] ST_AUTO_WINXPEN_ES11/ST_AUTO_WINXPEN_ES11.vmx";
            string Snapshot = "Backup";
            try
            {
                string Result = PowerOnVM(Host, HostLogin, HostPwd, VMFile, Snapshot);

                Console.WriteLine(Result);
                Console.WriteLine("any key to power off");
                Console.Read();
                Result = PowerOffVM(Host, HostLogin, HostPwd, VMFile, Snapshot);

                Console.WriteLine(Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
            Console.ReadLine();
        }

        public static string PowerOnVM(string aHost, string aHostLogin, string aHostPwd, string aVMLocation, string aSnapshot)
        {
            string Result = C_Success;
            try
            {
                FCurrentHost = new VMWareVirtualHost();
                Console.WriteLine("Connecting to Host: "+ aHost);
                FCurrentHost.ConnectToVMWareVIServer(aHost, aHostLogin, aHostPwd);
                Console.WriteLine("Connected to " + aHost);

                FCurrentMachine = FCurrentHost.Open(aVMLocation, 800);
                //VMWareSnapshot sn = FCurrentMachine.Snapshots.FindSnapshotByName(aSnapshot);
                
                //sn.RevertToSnapshot(300);
                Console.WriteLine("Powering On");
                FCurrentMachine.PowerOn(700);
                Console.WriteLine(FCurrentMachine.PowerState);
                Console.WriteLine("Powered On");
                Console.WriteLine("Waiting for Tool in guest");
                Thread.Sleep(180000);
                FCurrentMachine.WaitForToolsInGuest(800);
                Console.WriteLine("Tool ready");
                         

            }
            catch (Exception ex)
            {
                Result = "PowerOnVM: " + ex.Message;
            }
            return Result;
        }

        public static string PowerOffVM(string aHost, string aHostLogin, string aHostPwd, string aVMLocation, string aSnapshot)
        {
            string Result = C_Success;
            try
            {
                FCurrentHost = new VMWareVirtualHost();
                FCurrentHost.ConnectToVMWareVIServer(aHost, aHostLogin, aHostPwd);

                FCurrentMachine = FCurrentHost.Open(aVMLocation, 600);
                Console.WriteLine(FCurrentMachine.PowerState);
                FCurrentMachine.PowerOff(0, 700); 

            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }

            return Result;
        }
             
    }
}
