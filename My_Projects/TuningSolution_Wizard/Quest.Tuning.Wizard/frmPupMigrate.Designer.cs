namespace Quest.Tuning.Wizard
{
    partial class frmPupMigrate
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
            this.ucMigratte1 = new Quest.Tuning.Wizard.ucMigratte();
            this.SuspendLayout();
            // 
            // ucMigratte1
            // 
            this.ucMigratte1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMigratte1.Location = new System.Drawing.Point(0, 0);
            this.ucMigratte1.Name = "ucMigratte1";
            this.ucMigratte1.Size = new System.Drawing.Size(571, 443);
            this.ucMigratte1.TabIndex = 0;
            // 
            // frmPupMigrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 443);
            this.Controls.Add(this.ucMigratte1);
            this.Name = "frmPupMigrate";
            this.Text = "frmPupMigrate";
            this.ResumeLayout(false);

        }

        #endregion

        private ucMigratte ucMigratte1;
    }
}