using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using System.Threading;
using Microsoft.SqlServer.Management.Trace;
using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraGrid.Columns;

namespace Quest.Tuning.Profiler
{
    /// <summary>
    /// this is a sample about Profiler Trace
    /// </summary>
    public partial class frmProfiler : Form
    {
        public frmProfiler()
        {
            InitializeComponent();
        }
    }

}