namespace DPITestDX
{
    partial class frmMargin
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
            this.xtraUserControl41 = new DPITestDX.XtraUserControl4();
            this.SuspendLayout();
            // 
            // xtraUserControl41
            // 
            this.xtraUserControl41.Location = new System.Drawing.Point(40, 73);
            this.xtraUserControl41.Name = "xtraUserControl41";
            this.xtraUserControl41.Size = new System.Drawing.Size(456, 355);
            this.xtraUserControl41.TabIndex = 0;
            // 
            // frmMargin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 352);
            this.Controls.Add(this.xtraUserControl41);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMargin";
            this.Text = "frmMargin";
            this.Load += new System.EventHandler(this.frmMargin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private XtraUserControl4 xtraUserControl41;


    }
}