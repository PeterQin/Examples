namespace Quest.Tuning.Wizard
{
    partial class frmPupWizard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucExport1 = new Quest.Tuning.Wizard.ucExport();
            this.SuspendLayout();
            // 
            // ucExport1
            // 
            this.ucExport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExport1.Location = new System.Drawing.Point(0, 0);
            this.ucExport1.Name = "ucExport1";
            this.ucExport1.Size = new System.Drawing.Size(589, 386);
            this.ucExport1.TabIndex = 0;
            this.ucExport1.Load += new System.EventHandler(this.ucExport1_Load);
            // 
            // frmPupWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 386);
            this.Controls.Add(this.ucExport1);
            this.Name = "frmPupWizard";
            this.Text = "Optimizer for SQL Server Import and Export Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private ucExport ucExport1;
    }
}