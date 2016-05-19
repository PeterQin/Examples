using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DPITestDX
{
    public partial class frmMargin : DevExpress.XtraEditors.XtraForm
    {
        public frmMargin()
        {
            InitializeComponent();
        }

        private void frmMargin_Load(object sender, EventArgs e)
        {
            this.Text = this.Size.ToString();
        }
    }
}