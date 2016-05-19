using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Configuration;

namespace DBManagerCodeSimple
{   

    public partial class frmDBManager : Form
    {

        ITable_ptest FTablePTest = null;

        public frmDBManager()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (FTablePTest == null)
            {
                MessageBox.Show("Create table ptest fail");
                return;
            }
            DataTable dt = FTablePTest.Select(txtID.Text);            
            gridControl1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                FTablePTest = DBHelper.GetTable_Ptest();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (FTablePTest == null)
            {
                MessageBox.Show("Create table ptest fail");
                return;
            }
            FTablePTest.Insert(txtID.Text, txtData.Text);
            RefreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FTablePTest == null)
            {
                MessageBox.Show("Create table ptest fail");
                return;
            }
            FTablePTest.Update(txtID.Text, txtData.Text);
            RefreshGrid();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (FTablePTest == null)
            {
                MessageBox.Show("Create table ptest fail");
                return;
            }
            FTablePTest.Delete(txtID.Text);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            if (FTablePTest == null)
            {
                MessageBox.Show("Create table ptest fail");
                return;
            }
            gridControl1.DataSource = FTablePTest.Select(string.Empty);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ProjectDBHelper db = new ProjectDBHelper();
            db.LoadAllProject();
        }

    }
    
}