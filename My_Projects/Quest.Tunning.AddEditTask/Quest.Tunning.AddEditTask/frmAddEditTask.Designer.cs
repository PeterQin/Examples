namespace Quest.Tunning.AddEditTask
{
    partial class frmAddEditTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditTask));
            this.lblTaskType = new DevExpress.XtraEditors.LabelControl();
            this.cmbTaskType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.spcView = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucSelectApplication = new Quest.Tunning.AddEditTask.ucSelectApplication();
            this.ucSelectFile = new Quest.Tunning.AddEditTask.ucSelectFile();
            this.barStatus = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgStatus = new DevExpress.Utils.ImageCollection(this.components);
            this.pnlSelect = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTaskType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcView)).BeginInit();
            this.spcView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSelect)).BeginInit();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTaskType
            // 
            this.lblTaskType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskType.Appearance.Options.UseFont = true;
            this.lblTaskType.Location = new System.Drawing.Point(9, 12);
            this.lblTaskType.Name = "lblTaskType";
            this.lblTaskType.Size = new System.Drawing.Size(50, 13);
            this.lblTaskType.TabIndex = 1;
            this.lblTaskType.Text = "TaskType:";
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.EditValue = "CopyFolder";
            this.cmbTaskType.Location = new System.Drawing.Point(105, 9);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTaskType.Properties.Items.AddRange(new object[] {
            "CopyFolder",
            "CopyFile",
            "RunProgram"});
            this.cmbTaskType.Size = new System.Drawing.Size(96, 20);
            this.cmbTaskType.TabIndex = 3;
            this.cmbTaskType.SelectedIndexChanged += new System.EventHandler(this.cmbTaskType_SelectedIndexChanged);
            this.cmbTaskType.Click += new System.EventHandler(this.cmbTaskType_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(360, 182);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // spcView
            // 
            this.spcView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcView.Location = new System.Drawing.Point(0, 35);
            this.spcView.Name = "spcView";
            this.spcView.Panel1.Controls.Add(this.ucSelectApplication);
            this.spcView.Panel1.Text = "Panel1";
            this.spcView.Panel2.Controls.Add(this.ucSelectFile);
            this.spcView.Panel2.Text = "Panel2";
            this.spcView.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            this.spcView.Size = new System.Drawing.Size(449, 141);
            this.spcView.SplitterPosition = 231;
            this.spcView.TabIndex = 5;
            this.spcView.Text = "splitContainerControl1";
            // 
            // ucSelectApplication
            // 
            this.ucSelectApplication.Argument = new string[0];
            this.ucSelectApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSelectApplication.Location = new System.Drawing.Point(0, 0);
            this.ucSelectApplication.Name = "ucSelectApplication";
            this.ucSelectApplication.ProgramPath = "";
            this.ucSelectApplication.Size = new System.Drawing.Size(0, 0);
            this.ucSelectApplication.TabIndex = 0;
            // 
            // ucSelectFile
            // 
            this.ucSelectFile.Action = Quest.Tunning.AddEditTask.ucSelectFile.ActionType.CopyFolder;
            this.ucSelectFile.DestinationPath = null;
            this.ucSelectFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSelectFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSelectFile.Location = new System.Drawing.Point(0, 0);
            this.ucSelectFile.Name = "ucSelectFile";
            this.ucSelectFile.Size = new System.Drawing.Size(449, 141);
            this.ucSelectFile.SourcePath = null;
            this.ucSelectFile.TabIndex = 0;
            // 
            // barStatus
            // 
            this.barStatus.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barStatus.DockControls.Add(this.barDockControlTop);
            this.barStatus.DockControls.Add(this.barDockControlBottom);
            this.barStatus.DockControls.Add(this.barDockControlLeft);
            this.barStatus.DockControls.Add(this.barDockControlRight);
            this.barStatus.Form = this;
            this.barStatus.Images = this.imgStatus;
            this.barStatus.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus});
            this.barStatus.MaxItemId = 1;
            this.barStatus.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // lblStatus
            // 
            this.lblStatus.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // imgStatus
            // 
            this.imgStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgStatus.ImageStream")));
            this.imgStatus.Images.SetKeyName(0, "qso_completed.png");
            this.imgStatus.Images.SetKeyName(1, "qso_error.png");
            // 
            // pnlSelect
            // 
            this.pnlSelect.Controls.Add(this.lblTaskType);
            this.pnlSelect.Controls.Add(this.cmbTaskType);
            this.pnlSelect.Controls.Add(this.btnOK);
            this.pnlSelect.Controls.Add(this.spcView);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(447, 217);
            this.pnlSelect.TabIndex = 6;
            // 
            // frmAddEditTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 239);
            this.Controls.Add(this.pnlSelect);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Service Config File";
            ((System.ComponentModel.ISupportInitialize)(this.cmbTaskType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcView)).EndInit();
            this.spcView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSelect)).EndInit();
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTaskType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTaskType;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SplitContainerControl spcView;
        private Quest.Tunning.AddEditTask.ucSelectApplication ucSelectApplication;
        private Quest.Tunning.AddEditTask.ucSelectFile ucSelectFile;
        private DevExpress.XtraBars.BarManager barStatus;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlSelect;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.Utils.ImageCollection imgStatus;
    }
}

