namespace ATCMDataMigrate
{
    partial class frmMerge
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
            this.components = new System.ComponentModel.Container();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbProjSuite = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateRelation = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSourceDB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjSuite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSourceDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Source Project:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "To ProjectSuite:";
            // 
            // cmbProjSuite
            // 
            this.cmbProjSuite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProjSuite.Location = new System.Drawing.Point(98, 69);
            this.cmbProjSuite.Name = "cmbProjSuite";
            this.cmbProjSuite.Properties.AutoComplete = false;
            this.cmbProjSuite.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProjSuite.Size = new System.Drawing.Size(436, 20);
            this.cmbProjSuite.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(408, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Import";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(474, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblMsg.Location = new System.Drawing.Point(15, 115);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 6;
            // 
            // btnCreateRelation
            // 
            this.btnCreateRelation.Location = new System.Drawing.Point(315, 168);
            this.btnCreateRelation.Name = "btnCreateRelation";
            this.btnCreateRelation.Size = new System.Drawing.Size(248, 25);
            this.btnCreateRelation.TabIndex = 8;
            this.btnCreateRelation.Text = "Create relationship after all Projects imported!!!";
            this.btnCreateRelation.Click += new System.EventHandler(this.btnCreateRelation_Click);
            // 
            // cmbSourceDB
            // 
            this.cmbSourceDB.Location = new System.Drawing.Point(98, 35);
            this.cmbSourceDB.Name = "cmbSourceDB";
            this.cmbSourceDB.Properties.AutoComplete = false;
            this.cmbSourceDB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSourceDB.Size = new System.Drawing.Size(436, 20);
            this.cmbSourceDB.TabIndex = 10;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Lilian";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbSourceDB);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cmbProjSuite);
            this.groupControl1.Controls.Add(this.lblMsg);
            this.groupControl1.Controls.Add(this.btnOK);
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(551, 134);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Import all your Projects";
            // 
            // frmMigrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 217);
            this.Controls.Add(this.btnCreateRelation);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmMigrate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATCM Merge Data";
            this.Load += new System.EventHandler(this.frmMigrate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjSuite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSourceDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProjSuite;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private DevExpress.XtraEditors.SimpleButton btnCreateRelation;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSourceDB;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}

