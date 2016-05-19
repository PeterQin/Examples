using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace ExecutionServerAgent
{
    [RunInstaller(true)]
    public partial class ServiceInstaller : Installer
    {
        public ServiceInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}