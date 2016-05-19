using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using Microsoft.SqlServer.Management.Trace;
//using System.Threading;
//using Microsoft.SqlServer.Management.Common;

namespace Quest.Tuning.Profiler
{
    public partial class ucTrace : DevExpress.XtraEditors.XtraUserControl
    {
        //#region Field

        //private static int MessageCount = 0;
        //private static object FlagLock = new object();
        //private static bool ExitFlag = false;
        //private static string ApplicationName;
        //private static string HostName;
        //private static string TextData;

        //TraceServer traceServer = new TraceServer();
        //TraceFile traceFile = new TraceFile();
        //Thread ThreadTrace = new Thread(WriteTraceProc);


        //delegate void SetTextCallback(string text);

        //#endregion Field

        //#region Constructor & Destroyer

        //public ucTrace()
        //{
        //    InitializeComponent();
        //    ucTrace.onTraceRecordChanged += new EventHandler(frmProfiler_onTraceRecordChanged);
        //}

        //~ucTrace()
        //{
        //    StopTrace();
        //}

        //#endregion Constructor & Destroyer

        //#region Private Section

        //private static void WriteTraceProc(object obj)
        //{
        //    TraceFile traceFile = (TraceFile)obj;
        //    while (true)
        //    {
        //        lock (FlagLock)
        //        {
        //            if (ExitFlag)
        //                break;
        //        }
        //        traceFile.Write();

        //    }
        //}

        //private static void WriteHandler(object sender, TraceEventArgs args)
        //{
        //    IDataRecordChanger recordChanger = args.CurrentRecord;
        //    ApplicationName = (string)recordChanger[rcMessage.ApplicationName];
        //    HostName = (string)recordChanger[rcMessage.HostName];
        //    TextData = (string)recordChanger[rcMessage.TextData];
            
        //    if (onTraceRecordChanged != null)
        //    {
        //        onTraceRecordChanged(sender, args);
        //    }

        //}

        //private void SetText(string text)
        //{
        //    if (this.edtForm.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetText);
        //        this.Invoke(d, new object[] { text });
        //    }
        //    else
        //    {
        //        MessageCount++;
        //        String temp = "Message: "+MessageCount+"\r\n"+text + "\r\n" + rcMessage.Spliter + "\r\n" + this.edtForm.Text;
        //        this.edtForm.Text = temp;

        //    }
        //}

        ///// <summary>
        ///// This method will run TraceServer
        ///// </summary>
        //private void StartTrace()
        //{

        //    if (ThreadTrace.ThreadState == ThreadState.Unstarted)
        //    {
        //        SqlConnectionInfo connInfo = new SqlConnectionInfo(ProfilerTestSetting.Default.ServerName, ProfilerTestSetting.Default.UserName, ProfilerTestSetting.Default.Password);
        //        connInfo.UseIntegratedSecurity = false;
        //        traceServer.InitializeAsReader(connInfo, ProfilerTestSetting.Default.Template);
        //        traceFile.InitializeAsWriter(traceServer, ProfilerTestSetting.Default.TraceFile);
        //        traceFile.WriteNotify += new WriteNotifyEventHandler(WriteHandler);
        //        ThreadTrace.Start(traceFile);//pass traceFile as parameter
        //    }

        //}

        //private void StopTrace()
        //{
        //    try
        //    {
        //        if (ExitFlag)
        //        {
        //            return;
        //        }
        //        lock (FlagLock)
        //        {
        //            ExitFlag = true;
        //        }
        //        traceServer.Close();
        //        ThreadTrace.Join();
        //        traceFile.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.edtForm.Text = ex.ToString();
        //    }
        //}


        //#endregion Private Section

        //#region Events

        //public static event EventHandler onTraceRecordChanged;

        private void btnRun_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.StartTrace();
            //}
            //catch (Exception ex)
            //{

            //    this.edtForm.Text = ex.ToString();
            //}
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //StopTrace();
        }

        private void frmProfiler_onTraceRecordChanged(object sender, EventArgs e)
        {
            //string temp = "\r\n" + rcMessage.ApplicationName + ": " + ApplicationName + "\r\n" + "\r\n" + rcMessage.TextData + ": " + TextData + "\r\n" + rcMessage.HostName + ": " + HostName + "\r\n";
            //this.SetText(temp);
        }

        //#endregion Events
    }
}
