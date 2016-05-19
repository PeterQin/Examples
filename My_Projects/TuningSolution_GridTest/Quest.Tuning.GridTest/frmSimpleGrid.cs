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
    public partial class frmSimpleGrid : DevExpress.XtraEditors.XtraForm
    {
        public frmSimpleGrid()
        {
            InitializeComponent();
        }

        private void frmSimpleGrid_Load(object sender, EventArgs e)
        {
            List<UserData> source = new List<UserData>();
            for (int i = 0; i < 20; i++)
            {
                source.Add(new UserData(i, "data" + i, "Remark.." + i, "Name "+i));
            }

            gridControl1.DataSource = source;
            
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column == gridColumn1 && e.RowHandle == gridView1.FocusedRowHandle)
            //{
            //    e.Appearance.ForeColor = Color.Blue;
            //}
            
            
        }
    }

    public class UserData
    {
        private int FID;

        public int ID
        {
            get { return FID; }
            set { FID = value; }
        }

        private string FData;

        public string Data
        {
            get { return FData; }
            set { FData = value; }
        }

        private string FRemark;

        public string Remark
        {
            get { return FRemark; }
            set { FRemark = value; }
        }

        private string FName;

        public string Name
        {
            get { return FName; }
            set { FName = value; }
        }


        public UserData(int aID, string aData, string aRemark, string aName)
        {
            ID = aID;
            Data = aData;
            Remark = aRemark;
            Name = aName;
        }

    }
}