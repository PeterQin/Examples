namespace Quest.Tuning.GridTest
{
    partial class frmGrid2
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.grdColVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColRowNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddVisibleCol = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveVisible = new DevExpress.XtraEditors.SimpleButton();
            this.btnRowNum = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 7);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupContainerEdit1,
            this.repositoryItemPopupContainerEdit2});
            this.gridControl1.Size = new System.Drawing.Size(711, 376);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdColID,
            this.grdColVisible,
            this.grdColRowNum});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsPrint.EnableAppearanceOddRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.EndSorting += new System.EventHandler(this.gridView1_EndSorting);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomRowFilter += new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(this.gridView1_CustomRowFilter);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView1_CustomColumnSort);
            this.gridView1.CustomColumnGroup += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView1_CustomColumnGroup);
            // 
            // grdColID
            // 
            this.grdColID.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdColID.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.grdColID.AppearanceCell.Options.UseBackColor = true;
            this.grdColID.AppearanceCell.Options.UseForeColor = true;
            this.grdColID.Caption = "ID";
            this.grdColID.ColumnEdit = this.repositoryItemPopupContainerEdit2;
            this.grdColID.FieldName = "ID";
            this.grdColID.Name = "grdColID";
            this.grdColID.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.grdColID.Visible = true;
            this.grdColID.VisibleIndex = 0;
            // 
            // repositoryItemPopupContainerEdit2
            // 
            this.repositoryItemPopupContainerEdit2.AutoHeight = false;
            this.repositoryItemPopupContainerEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit2.Name = "repositoryItemPopupContainerEdit2";
            this.repositoryItemPopupContainerEdit2.PopupControl = this.popupContainerControl1;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.listBoxControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(262, 265);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(200, 118);
            this.popupContainerControl1.TabIndex = 9;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Location = new System.Drawing.Point(18, 2);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(120, 95);
            this.listBoxControl1.TabIndex = 0;
            // 
            // grdColVisible
            // 
            this.grdColVisible.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdColVisible.AppearanceCell.Options.UseBackColor = true;
            this.grdColVisible.Caption = "Visible";
            this.grdColVisible.FieldName = "Visible";
            this.grdColVisible.Name = "grdColVisible";
            this.grdColVisible.OptionsColumn.AllowFocus = false;
            this.grdColVisible.Visible = true;
            this.grdColVisible.VisibleIndex = 1;
            // 
            // grdColRowNum
            // 
            this.grdColRowNum.Caption = "Row Number";
            this.grdColRowNum.ColumnEdit = this.repositoryItemPopupContainerEdit1;
            this.grdColRowNum.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DisplayText;
            this.grdColRowNum.Name = "grdColRowNum";
            this.grdColRowNum.OptionsColumn.AllowEdit = false;
            this.grdColRowNum.OptionsColumn.AllowFocus = false;
            this.grdColRowNum.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.grdColRowNum.Visible = true;
            this.grdColRowNum.VisibleIndex = 2;
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus)});
            this.repositoryItemPopupContainerEdit1.HideSelection = false;
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(361, 406);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "delete top one";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(280, 406);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Add one";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Location = new System.Drawing.Point(118, 406);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "show all";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Location = new System.Drawing.Point(199, 406);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 23);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "Filter";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // btnAddVisibleCol
            // 
            this.btnAddVisibleCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVisibleCol.Location = new System.Drawing.Point(457, 406);
            this.btnAddVisibleCol.Name = "btnAddVisibleCol";
            this.btnAddVisibleCol.Size = new System.Drawing.Size(100, 23);
            this.btnAddVisibleCol.TabIndex = 5;
            this.btnAddVisibleCol.Text = "Add Visible Column";
            this.btnAddVisibleCol.Click += new System.EventHandler(this.btnAddVisibleCol_Click);
            // 
            // btnRemoveVisible
            // 
            this.btnRemoveVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveVisible.Location = new System.Drawing.Point(563, 406);
            this.btnRemoveVisible.Name = "btnRemoveVisible";
            this.btnRemoveVisible.Size = new System.Drawing.Size(79, 23);
            this.btnRemoveVisible.TabIndex = 6;
            this.btnRemoveVisible.Text = "Remove Visible";
            this.btnRemoveVisible.Click += new System.EventHandler(this.btnRemoveVisible_Click);
            // 
            // btnRowNum
            // 
            this.btnRowNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRowNum.Location = new System.Drawing.Point(648, 406);
            this.btnRowNum.Name = "btnRowNum";
            this.btnRowNum.Size = new System.Drawing.Size(75, 23);
            this.btnRowNum.TabIndex = 7;
            this.btnRowNum.Text = "Row Number";
            this.btnRowNum.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(37, 406);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(75, 23);
            this.simpleButton5.TabIndex = 8;
            this.simpleButton5.Text = "group row";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click_1);
            // 
            // frmGrid2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 446);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.btnRowNum);
            this.Controls.Add(this.btnRemoveVisible);
            this.Controls.Add(this.btnAddVisibleCol);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmGrid2";
            this.Text = "frmGrid2";
            this.Load += new System.EventHandler(this.frmGrid2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn grdColID;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraGrid.Columns.GridColumn grdColVisible;
        private DevExpress.XtraEditors.SimpleButton btnAddVisibleCol;
        private DevExpress.XtraEditors.SimpleButton btnRemoveVisible;
        private DevExpress.XtraEditors.SimpleButton btnRowNum;
        private DevExpress.XtraGrid.Columns.GridColumn grdColRowNum;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit2;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;

    }
}