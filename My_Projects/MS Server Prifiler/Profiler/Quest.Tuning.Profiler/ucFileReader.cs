using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Trace;
using System.Threading;
using System.IO;
using DevExpress.XtraGrid.Columns;

namespace Quest.Tuning.Profiler
{
    public partial class ucFileReader : DevExpress.XtraEditors.XtraUserControl
    {
        TraceFile traceFile = new TraceFile();

        public ucFileReader()
        {
            InitializeComponent();
            btnTraceFileLocation.Text = ProfilerTestSetting.Default.TraceFile;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {

            List<DisplayTraceFileRow> source = new List<DisplayTraceFileRow>();
            if (string.IsNullOrEmpty(btnTraceFileLocation.Text) == false && File.Exists(btnTraceFileLocation.Text))
            {
                try
                {
                    traceFile.InitializeAsReader(btnTraceFileLocation.Text);
                }
                catch (Exception ex)
                {
                    frmMessage frm = new frmMessage(ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.InnerException.Message);
                    frm.ShowDialog();
                    return;
                }

                while (traceFile.Read())
                {
                    DisplayTraceFileRow fileRow = new DisplayTraceFileRow();
                    for (int i = 0; i < ColumnNameArr.Length; i++)
                    {
                        int ordinal = -1;
                        try
                        {
                            ordinal = traceFile.GetOrdinal(ColumnNameArr[i]);
                        }
                        catch (Exception)
                        {

                        }
                        if (ordinal != -1)
                        {
                            object value = traceFile.GetValue(ordinal);
                            fileRow.Row.Add(ColumnNameArr[i], value);

                        }
                    }
                    source.Add(fileRow);

                }

                if (source.Count > 0)
                {
                    gridView1.Columns.Clear();
                    Dictionary<string, object> row = source[0].Row;
                    foreach (KeyValuePair<string, object> keyvalue in row)
                    {
                        GridColumn column = new GridColumn();
                        column.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                        column.Name = "UnboundColumn" + keyvalue.Key;
                        column.Caption = keyvalue.Key;
                        column.FieldName = keyvalue.Key;
                        column.Width = 200;
                        if (gridView1.VisibleColumns.Count == 0)
                        {
                            column.VisibleIndex = 0;
                        }
                        else
                        {
                            column.VisibleIndex = gridView1.VisibleColumns[gridView1.VisibleColumns.Count - 1].VisibleIndex + 1;
                        }
                        gridView1.Columns.Add(column);
                    }
                }

                gridControl1.DataSource = source;
                gridControl1.RefreshDataSource();
                gridView1.RefreshData();
                traceFile.Close();
            }


        }

        string[] ColumnNameArr = new string[] { "TextData", "BinaryData", "DatabaseID", "TransactionID", "LineNumber", "NTUserName", 
            "NTDomainName", "HostName", "ClientProcessID", "ApplicationName", "LoginName", "SPID", "Duration", "StartTime", "EndTime", 
            "Reads", "Writes", "CPU", "Permissions", "Severity", "EventSubClass", "ObjectID", "Success", "IndexID", "IntegerData", 
            "ServerName", "EventClass", "ObjectType", "NestLevel", "State", "Error", "Mode", "Handle", "ObjectName", "DatabaseName", 
            "FileName", "OwnerName", "RoleName", "TargetUserName", "DBUserName", "LoginSid", "TargetLoginName", "TargetLoginSid", 
            "ColumnPermissions", "LinkedServerName", "ProviderName", "MethodName", "RowCounts", "RequestID", "XactSequence", "EventSequence", 
            "BigintData1", "BigintData2", "GUID", "IntegerData2", "ObjectID2", "Type", "OwnerID", "ParentName", "IsSystem", "Offset", 
            "SourceDatabaseID", "SqlHandle", "SessionLoginName", "PlanHandle", "GroupID" };



        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                btnTraceFileLocation.Text = openFileDialog1.FileName;
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

            DisplayTraceFileRow row = gridView1.GetRow(e.RowHandle) as DisplayTraceFileRow;
            if (row != null)
            {
                object value = row.Row[e.Column.FieldName];
                e.Value = value;
            }

        }
    }

    public class DisplayTraceFileRow
    {

        private Dictionary<string, object> FRow = new Dictionary<string, object>();

        public Dictionary<string, object> Row
        {
            get { return FRow; }
        }
    }
}
