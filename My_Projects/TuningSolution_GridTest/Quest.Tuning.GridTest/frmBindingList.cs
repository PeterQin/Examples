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
    public partial class frmBindingList : DevExpress.XtraEditors.XtraForm
    {
        TMessage2List FSource = null;
        public frmBindingList()
        {
            InitializeComponent();
        }

        private void frmBindingList_Load(object sender, EventArgs e)
        {
            FSource = new TMessage2List();
            for (int i = 0; i < 10; i++)
            {
                TMessage4 temp = new TMessage4();
                temp.ID = i.ToString();
                temp.Data = ""+DateTime.FromOADate(DateTime.Now.ToOADate() + i * 100);
                FSource.Add(temp);
            }
            gridControl1.DataSource = FSource;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //FSource.properyObject = FSource[0];
            textEdit2.Text = FSource[FSource.Find(textEdit1.Text)].Data;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            FSource[FSource.Find(textEdit1.Text)].Data = textEdit2.Text;
            FSource[0].Data = "test";
        }
    }
}