namespace Quest.Tuning.GridTest
{
    partial class frmTree
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
            this.treM = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treM)).BeginInit();
            this.SuspendLayout();
            // 
            // treM
            // 
            this.treM.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.treM.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treM.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treM.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treM.Location = new System.Drawing.Point(70, 45);
            this.treM.LookAndFeel.SkinName = "Lilian";
            this.treM.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treM.Name = "treM";
            this.treM.OptionsView.EnableAppearanceOddRow = true;
            this.treM.OptionsView.ShowIndicator = false;
            this.treM.Size = new System.Drawing.Size(280, 278);
            this.treM.TabIndex = 0;
            this.treM.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treM_CustomDrawNodeCell);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "ID";
            this.treeListColumn1.FieldName = "ID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 105;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Data";
            this.treeListColumn2.FieldName = "Data";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 172;
            // 
            // frmTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 384);
            this.Controls.Add(this.treM);
            this.Name = "frmTree";
            this.Text = "Tree";
            this.Load += new System.EventHandler(this.frmTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treM;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
    }
}