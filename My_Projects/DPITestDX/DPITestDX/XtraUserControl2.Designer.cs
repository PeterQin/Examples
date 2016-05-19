namespace DPITestDX
{
    partial class XtraUserControl2
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
            this.xtraUserControl11 = new DPITestDX.XtraUserControl1();
            this.xtraUserControl31 = new DPITestDX.XtraUserControl3();
            this.SuspendLayout();
            // 
            // xtraUserControl11
            // 
            this.xtraUserControl11.Location = new System.Drawing.Point(173, 189);
            this.xtraUserControl11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.xtraUserControl11.Name = "xtraUserControl11";
            this.xtraUserControl11.Size = new System.Drawing.Size(384, 276);
            this.xtraUserControl11.TabIndex = 0;
            // 
            // xtraUserControl31
            // 
            this.xtraUserControl31.Location = new System.Drawing.Point(18, 19);
            this.xtraUserControl31.Name = "xtraUserControl31";
            this.xtraUserControl31.Size = new System.Drawing.Size(440, 325);
            this.xtraUserControl31.TabIndex = 1;
            // 
            // XtraUserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraUserControl31);
            this.Controls.Add(this.xtraUserControl11);
            this.Name = "XtraUserControl2";
            this.Size = new System.Drawing.Size(596, 483);
            this.ResumeLayout(false);

        }

        #endregion

        private XtraUserControl1 xtraUserControl11;
        private XtraUserControl3 xtraUserControl31;
    }
}
