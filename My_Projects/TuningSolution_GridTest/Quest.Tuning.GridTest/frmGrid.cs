using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Quest.Tuning.GridTest
{
    public partial class frmGrid : XtraForm
    {
        #region Field

        Thread AddThread;
        bool FLastRow = false;
        private TMessageList fMessage = new TMessageList();
        #region Const / Delegate / Enum

        delegate void AddCallBack(TMessage aMessage);

        #endregion Const / Delegate / Enum

        #region Property
        #endregion Property

        private delegate void SendMessageListHandle(TMessageList aMessageList);

        #endregion Field

        #region Constructor & Destroyer
        public frmGrid()
        {
            InitializeComponent();
        }
        #endregion Constructor & Destroyer

        #region Private Section
        #endregion Private Section

        #region Protected Section
        #endregion Protected Section

        #region Public Section
        public void AddData()
        {
            int count = 0;
            while (true)
            {
                TMessage TempMessage = new TMessage();
                TempMessage.ID = "TMemList "+count ;
                TempMessage.HostName = "create";
                TempMessage.ApplicationName = "889"+count;
                TempMessage.TextData = 7897+count*3;
                this.AddDataToList(TempMessage);
                count++;
                Thread.Sleep(500);
            }
        }
        

        public void SetDataSource()
        {
            
            this.colID.FieldName = TMessage.C_COL_ID;
            this.colHostName.FieldName = TMessage.C_COL_HostName;
            this.colApplicationName.FieldName = TMessage.C_COL_ApplicationName;
            this.colTextData.FieldName = TMessage.C_COL_TextData;
            this.grdData.DataSource = fMessage;

        }
        public void AddDataToList(TMessage aMessage)
        {
            if (grdData.InvokeRequired)
            {
                AddCallBack addcallback = new AddCallBack(AddDataToList);
                this.Invoke(addcallback, new object[] { aMessage });
            }
            else
            {
                this.fMessage.Add(aMessage);
                if (FLastRow)
                {
                    this.grdView.TopRowIndex = this.grdView.RowCount;
                }
               

            }

        }

        #endregion Public Section

        #region Events

        private void frmGrid_Load(object sender, EventArgs e)
        {
            this.SetDataSource();

        }

        private void btnRun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //grdView.BeginDataUpdate();

            for (int i = 0; i < 10; i++)
            {
                TMessage TempMessage = new TMessage();
                TempMessage.ID = "MYID "+i.ToString();
                TempMessage.HostName = "10.30.152.3";
                TempMessage.ApplicationName = "Grid" + " " + DateTime.Now.ToLongTimeString();
                TempMessage.TextData = 7704.0;
                this.AddDataToList(TempMessage);
            }

            //grdView.EndDataUpdate();

        }

        private void barThread_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddThread = new Thread(this.AddData);
            if (AddThread.ThreadState == ThreadState.Unstarted)
            {
                AddThread.Start();
            }

        }

        private void barStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (AddThread.IsAlive)
            {
                AddThread.Abort();
            }
        }
        #endregion Events

        private void btnLastRow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (btnLastRow.Checked)
            //{
            //    this.FLastRow = true;
            //}
            //else
            //{
            //    this.FLastRow = false;
            //}

            TMessage TempMessage = new TMessage();
            TempMessage.ID = "8888";
            TempMessage.HostName = "10.30.152.3";
            TempMessage.ApplicationName = "Test" + " " + DateTime.Now.ToLongTimeString();
            //TempMessage.TextData = "\r\nSQL\r\n another string";
            this.AddDataToList(TempMessage);
        }


        //..
        private void ExportTo(IExportProvider provider)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = grdView.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            //link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            link.ExportTo(true);
            provider.Dispose();
            //link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            Cursor.Current = currentCursor;
        }
        //..
        //private void Export_Progress(object sender, DevExpress.XtraGrid.Export.ProgressEventArgs e)
        //{
        //    if (e.Phase == DevExpress.XtraGrid.Export.ExportPhase.Link)
        //    {
        //        progressBarControl1.Position = e.Position;
        //        this.Update();
        //    }
        //}

        private void sbExportToHTML_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
            if (fileName != "")
            {
                ExportTo(new ExportHtmlProvider(fileName));
                PromptOpenNow(fileName);
            }
        }

        public static string ShowSaveFileDialog(string title, string filter)
        {
            return ShowSaveFileDialog(title, filter, "");
        }

        public static string ShowSaveFileDialog(string title, string filter, string fileName)
        {
            return ShowSaveFileDialog(title, filter, fileName, "");
        }

        public static string ShowSaveFileDialog(string title, string filter, string fileName, string path)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.RestoreDirectory = true;
                dlg.Title = "strSaveAs" + title;
                dlg.FileName = fileName;
                dlg.Filter = filter;
                if (string.IsNullOrEmpty(path) == false)
                {
                    dlg.InitialDirectory = path;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.FileName;
                return "";
            }
        }
        private static void PromptOpenNow(string aPath)
        {
            // Use the code below if you want the created file to be automatically
            // opened in the appropriate application.
            if (XtraMessageBox.Show("msgOpenFile", "Product_Name", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = aPath;
                    process.Start();
                }
            }
        }

        private void grdView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.RowHandle == 2 && e.Column == colID)
            //{
            //    e.Column.ColumnEdit = null;
            //    e.CellValue = null;
            //    e.DisplayText = "1";
            //}

            e.Appearance.BackColor = Color.Beige;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                TMessage TempMessage = new TMessage();
                //TempMessage.ID = i.ToString();
                //TempMessage.HostName = "10.30.152.3";
                //TempMessage.ApplicationName = "Grid" + " " + DateTime.Now.ToLongTimeString();
                //TempMessage.TextData = -1;
                this.AddDataToList(TempMessage);
            }
        }

        private void grdView_MouseUp(object sender, MouseEventArgs e)
        {
            //GridHitInfo hitInfo = grdView.CalcHitInfo(grdView.GridControl.PointToClient(MousePosition));
            //if (hitInfo.InRow)
            //{
            //    object value = grdView.GetRowCellValue(hitInfo.RowHandle,colID);
            //    MessageBox.Show(value.ToString());
            //}
        }

        
    }
}