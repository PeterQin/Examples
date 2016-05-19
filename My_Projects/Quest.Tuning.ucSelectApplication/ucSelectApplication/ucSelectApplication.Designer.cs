namespace Quest.Tunning.SelectApplication
{
    partial class ucSelectApplication
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
            this.lblApplication = new DevExpress.XtraEditors.LabelControl();
            this.lblAgument = new DevExpress.XtraEditors.LabelControl();
            this.memArgument = new DevExpress.XtraEditors.MemoEdit();
            this.edtProgram = new DevExpress.XtraEditors.ButtonEdit();
            this.ofdProgram = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.memArgument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProgram.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblApplication
            // 
            this.lblApplication.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.Appearance.Options.UseFont = true;
            this.lblApplication.Location = new System.Drawing.Point(9, 15);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(50, 13);
            this.lblApplication.TabIndex = 0;
            this.lblApplication.Text = "File Name:";
            // 
            // lblAgument
            // 
            this.lblAgument.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgument.Appearance.Options.UseFont = true;
            this.lblAgument.Location = new System.Drawing.Point(9, 50);
            this.lblAgument.Name = "lblAgument";
            this.lblAgument.Size = new System.Drawing.Size(51, 13);
            this.lblAgument.TabIndex = 1;
            this.lblAgument.Text = "Argument:";
            // 
            // memArgument
            // 
            this.memArgument.Location = new System.Drawing.Point(65, 47);
            this.memArgument.Name = "memArgument";
            this.memArgument.Size = new System.Drawing.Size(338, 90);
            this.memArgument.TabIndex = 3;
            // 
            // edtProgram
            // 
            this.edtProgram.Location = new System.Drawing.Point(65, 12);
            this.edtProgram.Name = "edtProgram";
            this.edtProgram.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtProgram.Size = new System.Drawing.Size(338, 20);
            this.edtProgram.TabIndex = 4;
            this.edtProgram.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtProgram_ButtonClick);
            this.edtProgram.EditValueChanged += new System.EventHandler(this.edtProgram_EditValueChanged);
            // 
            // ofdProgram
            // 
            this.ofdProgram.Filter = "All Files(*.*)|*.*";
            // 
            // ucSelectApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtProgram);
            this.Controls.Add(this.memArgument);
            this.Controls.Add(this.lblAgument);
            this.Controls.Add(this.lblApplication);
            this.Name = "ucSelectApplication";
            this.Size = new System.Drawing.Size(414, 145);
            ((System.ComponentModel.ISupportInitialize)(this.memArgument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProgram.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblApplication;
        private DevExpress.XtraEditors.LabelControl lblAgument;
        private DevExpress.XtraEditors.MemoEdit memArgument;
        private DevExpress.XtraEditors.ButtonEdit edtProgram;
        private System.Windows.Forms.OpenFileDialog ofdProgram;
    }
}
