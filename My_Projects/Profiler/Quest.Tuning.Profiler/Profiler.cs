using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Trace;
using Microsoft.SqlServer.Management.Common;
using System.Threading;

namespace Quest.Tuning.Profiler
{
    /// <summary>
    /// this is a sample about Profiler Trace
    /// </summary>
    public partial class frmProfiler : Form
    {
        #region Field

        private static int MessageCount = 0;
        private static object FlagLock = new object();
        private static bool ExitFlag = false;
        private static string ApplicationName;
        private static string HostName;
        private static string TextData;
        private static string FilterApplicatinName = "";
        private static string FilterHostName = "";

        #region Const / Delegate / Enum

        delegate void SetTextCallback(string text);

        #endregion Const / Delegate / Enum

        #region Property
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public frmProfiler()
        {
            InitializeComponent();          
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private static void WriteTraceProc(object obj)
        {
            TraceFile traceFile = (TraceFile)obj;
            while (true)
            {
                lock (FlagLock)
                {
                    if (ExitFlag)
                        break;
                }
                traceFile.Write();

            }
        }

        private static void WriteHandler(object sender, TraceEventArgs args)
        {
            IDataRecordChanger recordChanger = args.CurrentRecord;
            ApplicationName = (string)recordChanger[rcMessage.ApplicationName];
            HostName = (string)recordChanger[rcMessage.HostName];
            TextData = (string)recordChanger[rcMessage.TextData];
            
            if (!FilterApplicatinName.Equals("") && !FilterHostName.Equals(""))
            {
                if (ApplicationName != null && HostName != null && TextData != null)
                {
                    if (ApplicationName.Equals(FilterApplicatinName) && HostName.Equals(FilterHostName))
                    {
                        if (onTraceRecordChanged != null)
                        {
                            onTraceRecordChanged(sender, args);
                        }

                    }
                    else
                    {
                        args.SkipRecord = true;
                    }
                }
            }

            else if (!FilterApplicatinName.Equals("") && FilterHostName.Equals(""))
            {
                if (ApplicationName != null && HostName != null && TextData != null)
                {
                    if (ApplicationName.Equals(FilterApplicatinName))
                    {
                        if (onTraceRecordChanged != null)
                        {
                            onTraceRecordChanged(sender, args);
                        }
                        
                    }
                    else
                    {
                        args.SkipRecord = true;
                    }
                }
            }
            else if (!FilterHostName.Equals("") && FilterApplicatinName.Equals(""))
            {
                if (ApplicationName != null && HostName != null && TextData != null)
                {
                    if (HostName.Equals(FilterHostName))
                    {
                        if (onTraceRecordChanged != null)
                        {
                            onTraceRecordChanged(sender, args);
                        }
                        
                    }
                    else
                    {
                        args.SkipRecord = true;
                    }
                }
            }
            else
            {
                if (onTraceRecordChanged != null)
                {
                    onTraceRecordChanged(sender, args);
                }
            }






        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.edtForm.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                MessageCount++;
                String temp = "Message: "+MessageCount+"\r\n"+text + "\r\n" + rcMessage.Spliter + "\r\n" + this.edtForm.Text;
                this.edtForm.Text = temp;

            }
        }


        #endregion Private Section

        #region Protected Section

        TraceServer traceServer = new TraceServer();
        TraceFile traceFile = new TraceFile();
        Thread ThreadTrace = new Thread(WriteTraceProc);

        #endregion Protected Section

        #region Public Section

        /// <summary>
        /// This method will run TraceServer
        /// </summary>
        public void RunTrace()
        {

            if (ThreadTrace.ThreadState==ThreadState.Unstarted)
            {
                
                SqlConnectionInfo connInfo = new SqlConnectionInfo(rcMessage.ServerName, rcMessage.UserName, rcMessage.Password);
                connInfo.UseIntegratedSecurity = false;
                traceServer.InitializeAsReader(connInfo, rcMessage.Template);
                traceFile.InitializeAsWriter(traceServer, rcMessage.TraceFile);
                traceFile.WriteNotify += new WriteNotifyEventHandler(WriteHandler);
                frmProfiler.onTraceRecordChanged += new EventHandler(frmProfiler_onTraceRecordChanged);
                ThreadTrace.Start(traceFile);//pass traceFile as parameter
            }

        }

        #endregion Public Section

        #region Events

        public static event EventHandler onTraceRecordChanged;

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                this.RunTrace();
            }
            catch (Exception ex)
            {

                this.edtForm.Text = ex.ToString();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                lock (FlagLock)
                {
                    ExitFlag = true;
                }
                traceServer.Close();
                ThreadTrace.Join();
                traceFile.Close();
            }
            catch (Exception ex)
            {

                this.edtForm.Text = ex.ToString();
            }

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbFilter.Text.Equals(rcMessage.ApplicationName))
            {
                FilterApplicatinName = this.txtFilter.Text;
            }
            else if (cmbFilter.Text.Equals(rcMessage.HostName))
            {
                FilterHostName = this.txtFilter.Text;
            }

        }

        private void frmProfiler_onTraceRecordChanged(object sender, EventArgs e)
        {
            string temp = "\r\n" + rcMessage.ApplicationName + ": " + ApplicationName + "\r\n" + "\r\n" + rcMessage.TextData + ": " + TextData + "\r\n" + rcMessage.HostName + ": " + HostName + "\r\n";
            this.SetText(temp);
        }

        #endregion Events
    }
}