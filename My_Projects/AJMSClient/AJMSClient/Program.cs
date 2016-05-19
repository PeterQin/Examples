using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace AJMS
{
    class Program
    {
        static void Main(string[] args)
        {
            string Host = "zhu11155.prod.quest.corp";
            string HostLogin = "root";
            string HostPwd = "sqlexp!23456";
            string VMFile = "[datastore1] ST_AUTO_WINXPEN_ES11/ST_AUTO_WINXPEN_ES11.vmx";
            string Snapshot = "Locale Korean";
            ESXiHelperClient ES = new ESXiHelperClient("WSHttpBinding_IESXiHelper");
            try
            {
                List<string> SnapshotList = new List<string>();                
                SnapshotList.AddRange(ES.GetSnapshotList(Host,HostLogin,HostPwd,VMFile));
                Console.WriteLine(SnapshotList.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.ReadLine();

        }
    }
}
