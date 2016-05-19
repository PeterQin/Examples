namespace DPIScaleTest
{
    partial class frmXtraForm1
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
            this.xtraUserControl11 = new DPIScaleTest.XtraUserControl1();
            this.SuspendLayout();
            // 
            // xtraUserControl11
            // 
            this.xtraUserControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraUserControl11.Location = new System.Drawing.Point(0, 0);
            this.xtraUserControl11.Name = "xtraUserControl11";
            this.xtraUserControl11.Size = new System.Drawing.Size(492, 358);
            this.xtraUserControl11.TabIndex = 0;
            // 
            // frmXtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 358);
            this.Controls.Add(this.xtraUserControl11);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmXtraForm1";
            this.Text = "frmDX";
            this.ResumeLayout(false);

        }

        #endregion

        private XtraUserControl1 xtraUserControl11;

    }
}