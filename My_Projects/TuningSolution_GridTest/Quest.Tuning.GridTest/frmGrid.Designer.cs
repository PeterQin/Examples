namespace Quest.Tuning.GridTest
{
    partial class frmGrid
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
                if (AddThread != null)
                {
                    if (AddThread.IsAlive)
                    {
                        AddThread.Abort();
                    }
                }
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
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colHostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApplicationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTextData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.bamBar = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnRun = new DevExpress.XtraBars.BarButtonItem();
            this.btnThread = new DevExpress.XtraBars.BarButtonItem();
            this.btnStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnStartProfiler = new DevExpress.XtraBars.BarButtonItem();
            this.btnStopProfiler = new DevExpress.XtraBars.BarButtonItem();
            this.btnLastRow = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bamBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.Location = new System.Drawing.Point(0, 48);
            this.grdData.MainView = this.grdView;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupContainerEdit1,
            this.repositoryItemHyperLinkEdit1});
            this.grdData.Size = new System.Drawing.Size(780, 237);
            this.grdData.TabIndex = 0;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView});
            // 
            // grdView
            // 
            this.grdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colHostName,
            this.colApplicationName,
            this.colTextData});
            this.grdView.CustomizationFormBounds = new System.Drawing.Rectangle(854, 423, 208, 170);
            this.grdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdView.GridControl = this.grdData;
            this.grdView.Name = "grdView";
            this.grdView.OptionsBehavior.Editable = false;
            this.grdView.OptionsBehavior.ReadOnly = true;
            this.grdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdView.OptionsView.EnableAppearanceEvenRow = true;
            this.grdView.OptionsView.ShowGroupPanel = false;
            this.grdView.RowHeight = 30;
            this.grdView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdView_CustomDrawCell);
            this.grdView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdView_MouseUp);
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colID.Caption = "NO.";
            this.colID.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.colID.Name = "colID";
            this.colID.ToolTip = "Number of Message";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 110;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.ReadOnly = true;
            // 
            // colHostName
            // 
            this.colHostName.AppearanceCell.Options.UseTextOptions = true;
            this.colHostName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHostName.Caption = "Host Name";
            this.colHostName.Name = "colHostName";
            this.colHostName.Visible = true;
            this.colHostName.VisibleIndex = 2;
            this.colHostName.Width = 130;
            // 
            // colApplicationName
            // 
            this.colApplicationName.AppearanceCell.Options.UseTextOptions = true;
            this.colApplicationName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colApplicationName.Caption = "Application Name";
            this.colApplicationName.Name = "colApplicationName";
            this.colApplicationName.Visible = true;
            this.colApplicationName.VisibleIndex = 1;
            this.colApplicationName.Width = 161;
            // 
            // colTextData
            // 
            this.colTextData.Caption = "Text Data";
            this.colTextData.DisplayFormat.FormatString = "00:00:00.000";
            this.colTextData.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTextData.Name = "colTextData";
            this.colTextData.Visible = true;
            this.colTextData.VisibleIndex = 3;
            this.colTextData.Width = 458;
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // bamBar
            // 
            this.bamBar.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.bamBar.DockControls.Add(this.barDockControlTop);
            this.bamBar.DockControls.Add(this.barDockControlBottom);
            this.bamBar.DockControls.Add(this.barDockControlLeft);
            this.bamBar.DockControls.Add(this.barDockControlRight);
            this.bamBar.Form = this;
            this.bamBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRun,
            this.btnThread,
            this.btnStop,
            this.btnStartProfiler,
            this.btnStopProfiler,
            this.btnLastRow,
            this.barButtonItem1,
            this.barButtonItem2});
            this.bamBar.MainMenu = this.bar2;
            this.bamBar.MaxItemId = 17;
            this.bamBar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.bamBar.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRun),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThread),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStop),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStartProfiler),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStopProfiler),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLastRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.bar1.Text = "Tools";
            // 
            // btnRun
            // 
            this.btnRun.Caption = "RunTestCase";
            this.btnRun.Id = 0;
            this.btnRun.Name = "btnRun";
            this.btnRun.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRun_ItemClick);
            // 
            // btnThread
            // 
            this.btnThread.Caption = "ThreadSample";
            this.btnThread.Id = 1;
            this.btnThread.Name = "btnThread";
            this.btnThread.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barThread_ItemClick);
            // 
            // btnStop
            // 
            this.btnStop.Caption = "Stop";
            this.btnStop.Id = 2;
            this.btnStop.Name = "btnStop";
            this.btnStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStop_ItemClick);
            // 
            // btnStartProfiler
            // 
            this.btnStartProfiler.Caption = "StartProfiler";
            this.btnStartProfiler.Id = 3;
            this.btnStartProfiler.Name = "btnStartProfiler";
            // 
            // btnStopProfiler
            // 
            this.btnStopProfiler.Caption = "StopProfiler";
            this.btnStopProfiler.Id = 4;
            this.btnStopProfiler.Name = "btnStopProfiler";
            // 
            // btnLastRow
            // 
            this.btnLastRow.Caption = "LastRow";
            this.btnLastRow.Id = 12;
            this.btnLastRow.Name = "btnLastRow";
            this.btnLastRow.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLastRow_CheckedChanged);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Save As HTML";
            this.barButtonItem1.Id = 13;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.sbExportToHTML_Click);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "AddOne";
            this.barButtonItem2.Id = 14;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(780, 48);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 404);
            this.barDockControlBottom.Size = new System.Drawing.Size(780, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 48);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 356);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(780, 48);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 356);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Lilian";
            // 
            // frmGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 427);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmGrid";
            this.Text = "Grid Sample";
            this.Load += new System.EventHandler(this.frmGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bamBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView;
        private DevExpress.XtraBars.BarManager bamBar;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colHostName;
        private DevExpress.XtraGrid.Columns.GridColumn colApplicationName;
        private DevExpress.XtraGrid.Columns.GridColumn colTextData;
        private DevExpress.XtraBars.BarButtonItem btnRun;
        private DevExpress.XtraBars.BarButtonItem btnThread;
        private DevExpress.XtraBars.BarButtonItem btnStop;
        private DevExpress.XtraBars.BarButtonItem btnStartProfiler;
        private DevExpress.XtraBars.BarButtonItem btnStopProfiler;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraBars.BarCheckItem btnLastRow;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
    }
}

