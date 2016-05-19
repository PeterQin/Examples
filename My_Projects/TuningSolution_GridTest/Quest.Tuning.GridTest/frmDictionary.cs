using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Quest.Tuning.GridTest
{
    public partial class frmDictionary : DevExpress.XtraEditors.XtraForm
    {
        public frmDictionary()
        {
            InitializeComponent();
        }

        private void frmDictionary_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(i.ToString(), i.ToString());
            }
            gridControl1.DataSource = source;
        }
    }
}