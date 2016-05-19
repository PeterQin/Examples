using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Quest.Tuning.Profiler
{
    public partial class frmMessage : DevExpress.XtraEditors.XtraForm
    {
        public frmMessage(string amsg)
        {
            InitializeComponent();
            richTextBox1.Text = amsg;
        }
    }
}