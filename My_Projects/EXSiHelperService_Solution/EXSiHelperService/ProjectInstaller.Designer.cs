namespace AJMS
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ESXiServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.ESXiServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // ESXiServiceProcessInstaller
            // 
            this.ESXiServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.ESXiServiceProcessInstaller.Password = null;
            this.ESXiServiceProcessInstaller.Username = null;
            // 
            // ESXiServiceInstaller
            // 
            this.ESXiServiceInstaller.ServiceName = "ESXiHelperService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ESXiServiceProcessInstaller,
            this.ESXiServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ESXiServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller ESXiServiceInstaller;
    }
}