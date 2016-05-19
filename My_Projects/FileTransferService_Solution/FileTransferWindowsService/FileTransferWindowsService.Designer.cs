namespace Quest.Tuning.FileTransferWindowsService
{
    partial class FileTransferWindowsService
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
            this.FileTransferServiceEventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.FileTransferServiceEventLog)).BeginInit();
            // 
            // FileTransferWindowsService
            // 
            this.ServiceName = "FileTransferWindowsService";
            ((System.ComponentModel.ISupportInitialize)(this.FileTransferServiceEventLog)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog FileTransferServiceEventLog;
    }
}
