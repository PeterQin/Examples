namespace PSolution.ProjectPP
{
    partial class ucPPMainMidUI
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
            this.ucPPSonControl11 = new PSolution.ProjectPP.ucPPSonControl1();
            this.ucPPSonControl21 = new PSolution.ProjectPP.ucPPSonControl2();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPPSonControl11
            // 
            this.ucPPSonControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPPSonControl11.Location = new System.Drawing.Point(2, 2);
            this.ucPPSonControl11.Name = "ucPPSonControl11";
            this.ucPPSonControl11.Size = new System.Drawing.Size(317, 238);
            this.ucPPSonControl11.TabIndex = 0;
            // 
            // ucPPSonControl21
            // 
            this.ucPPSonControl21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPPSonControl21.Location = new System.Drawing.Point(2, 2);
            this.ucPPSonControl21.Name = "ucPPSonControl21";
            this.ucPPSonControl21.Size = new System.Drawing.Size(317, 238);
            this.ucPPSonControl21.TabIndex = 1;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(321, 22);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(315, 0);
            this.xtraTabPage1.Text = "Son1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(315, 0);
            this.xtraTabPage2.Text = "Son2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ucPPSonControl11);
            this.panelControl1.Controls.Add(this.ucPPSonControl21);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(321, 242);
            this.panelControl1.TabIndex = 3;
            // 
            // ucPPMainMidUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ucPPMainMidUI";
            this.Size = new System.Drawing.Size(321, 264);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPPSonControl1 ucPPSonControl11;
        private ucPPSonControl2 ucPPSonControl21;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
