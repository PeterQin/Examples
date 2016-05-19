namespace Quest.Tuning.GridTest
{
    partial class frmWelcome
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
            this.btnSimpleSQLProfiler = new DevExpress.XtraEditors.SimpleButton();
            this.btnFixRowGrid = new DevExpress.XtraEditors.SimpleButton();
            this.btnTree = new DevExpress.XtraEditors.SimpleButton();
            this.btnSortBindList = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnSimpleSQLProfiler
            // 
            this.btnSimpleSQLProfiler.Location = new System.Drawing.Point(12, 12);
            this.btnSimpleSQLProfiler.Name = "btnSimpleSQLProfiler";
            this.btnSimpleSQLProfiler.Size = new System.Drawing.Size(126, 37);
            this.btnSimpleSQLProfiler.TabIndex = 0;
            this.btnSimpleSQLProfiler.Text = "Simple SQL Profiler";
            this.btnSimpleSQLProfiler.Click += new System.EventHandler(this.btnSimpleSQLProfiler_Click);
            // 
            // btnFixRowGrid
            // 
            this.btnFixRowGrid.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnFixRowGrid.Appearance.Options.UseForeColor = true;
            this.btnFixRowGrid.Location = new System.Drawing.Point(178, 12);
            this.btnFixRowGrid.Name = "btnFixRowGrid";
            this.btnFixRowGrid.Size = new System.Drawing.Size(120, 37);
            this.btnFixRowGrid.TabIndex = 1;
            this.btnFixRowGrid.Text = "Fix Row Grid";
            this.btnFixRowGrid.Click += new System.EventHandler(this.btnFixRowGrid_Click);
            // 
            // btnTree
            // 
            this.btnTree.Location = new System.Drawing.Point(342, 12);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(125, 36);
            this.btnTree.TabIndex = 2;
            this.btnTree.Text = "Tree";
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnSortBindList
            // 
            this.btnSortBindList.Location = new System.Drawing.Point(12, 79);
            this.btnSortBindList.Name = "btnSortBindList";
            this.btnSortBindList.Size = new System.Drawing.Size(126, 37);
            this.btnSortBindList.TabIndex = 3;
            this.btnSortBindList.Text = "Sort BindingList";
            this.btnSortBindList.Click += new System.EventHandler(this.btnSortBindList_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(178, 79);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(129, 37);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Dictionary";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(342, 79);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(125, 37);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "simpleGrid";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 228);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnSortBindList);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.btnFixRowGrid);
            this.Controls.Add(this.btnSimpleSQLProfiler);
            this.Name = "frmWelcome";
            this.Text = "frmWelcome";
            this.Load += new System.EventHandler(this.frmWelcome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSimpleSQLProfiler;
        private DevExpress.XtraEditors.SimpleButton btnFixRowGrid;
        private DevExpress.XtraEditors.SimpleButton btnTree;
        private DevExpress.XtraEditors.SimpleButton btnSortBindList;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}