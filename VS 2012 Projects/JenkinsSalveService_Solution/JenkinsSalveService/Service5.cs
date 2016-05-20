using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Security.Principal;

namespace JenkinsSalveService
{
    public partial class Service5 : ServiceBase
    {
        public Service5()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Thread go = new Thread(new ThreadStart(google));
            go.Start();
        }

        private void google()
        {
            WriteLine("Environment.UserName: " + Environment.UserName);
            WriteLine("WindowsIdentity.GetCurrent().Name: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            IPrincipal principal = Thread.CurrentPrincipal;
            IIdentity identity = principal == null ? null : principal.Identity;
            string name = identity == null ? "" : identity.Name;
            WriteLine("Thread.CurrentPrincipal: " + name);
        }

        private void WriteLine(string aMsg)
        {
            File.AppendAllText(Path.Combine("C:\\", "log.txt"), aMsg);
        }

        protected override void OnStop()
        {
        }
    }
}
