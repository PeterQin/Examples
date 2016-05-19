namespace Quest.Tuning.FileTransferWindowsService
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
            this.FileTransferServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.FileTransferServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // FileTransferServiceProcessInstaller
            // 
            this.FileTransferServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.FileTransferServiceProcessInstaller.Password = null;
            this.FileTransferServiceProcessInstaller.Username = null;
            // 
            // FileTransferServiceInstaller
            // 
            this.FileTransferServiceInstaller.Description = "Quest Tuning File Transfer Service";
            this.FileTransferServiceInstaller.DisplayName = "File Transfer Service";
            this.FileTransferServiceInstaller.ServiceName = "FileTransferWindowsService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.FileTransferServiceProcessInstaller,
            this.FileTransferServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller FileTransferServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller FileTransferServiceInstaller;
    }
}