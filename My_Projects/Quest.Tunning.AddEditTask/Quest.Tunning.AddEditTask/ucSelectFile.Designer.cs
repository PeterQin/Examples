namespace Quest.Tunning.AddEditTask
{
    partial class ucSelectFile
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
            this.fbdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.lblSource = new DevExpress.XtraEditors.LabelControl();
            this.lblDestination = new DevExpress.XtraEditors.LabelControl();
            this.edtSource = new DevExpress.XtraEditors.ButtonEdit();
            this.edtDestination = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDestination.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdFile
            // 
            this.ofdFile.Filter = "All files (*.*)|*.*";
            // 
            // lblSource
            // 
            this.lblSource.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Appearance.Options.UseFont = true;
            this.lblSource.Location = new System.Drawing.Point(8, 15);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(70, 13);
            this.lblSource.TabIndex = 5;
            this.lblSource.Text = "Source Folder:";
            // 
            // lblDestination
            // 
            this.lblDestination.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Appearance.Options.UseFont = true;
            this.lblDestination.Location = new System.Drawing.Point(8, 50);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(91, 13);
            this.lblDestination.TabIndex = 6;
            this.lblDestination.Text = "Destination Folder:";
            // 
            // edtSource
            // 
            this.edtSource.Location = new System.Drawing.Point(105, 12);
            this.edtSource.Name = "edtSource";
            this.edtSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtSource.Size = new System.Drawing.Size(335, 20);
            this.edtSource.TabIndex = 7;
            this.edtSource.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtSource_ButtonClick);
            this.edtSource.EditValueChanged += new System.EventHandler(this.edtSource_EditValueChanged);
            // 
            // edtDestination
            // 
            this.edtDestination.Location = new System.Drawing.Point(105, 47);
            this.edtDestination.Name = "edtDestination";
            this.edtDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtDestination.Size = new System.Drawing.Size(335, 20);
            this.edtDestination.TabIndex = 8;
            this.edtDestination.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtDestination_ButtonClick);
            this.edtDestination.EditValueChanged += new System.EventHandler(this.edtDestination_EditValueChanged);
            // 
            // ucSelectFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtDestination);
            this.Controls.Add(this.edtSource);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucSelectFile";
            this.Size = new System.Drawing.Size(451, 73);
            ((System.ComponentModel.ISupportInitialize)(this.edtSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDestination.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdFolder;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private DevExpress.XtraEditors.LabelControl lblSource;
        private DevExpress.XtraEditors.LabelControl lblDestination;
        private DevExpress.XtraEditors.ButtonEdit edtSource;
        private DevExpress.XtraEditors.ButtonEdit edtDestination;
    }
}
