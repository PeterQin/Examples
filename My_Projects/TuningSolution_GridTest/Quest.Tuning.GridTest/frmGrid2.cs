using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace Quest.Tuning.GridTest
{
    public partial class frmGrid2 : DevExpress.XtraEditors.XtraForm
    {
        private static int cnt = 10;
        List<TMessage3> source;
        public frmGrid2()
        {
            InitializeComponent();
        }

        private void frmGrid2_Load(object sender, EventArgs e)
        {
            source = new List<TMessage3>();
            for (int i = 0; i < 10; i++)
            {
                TMessage3 tempmessage = new TMessage3();
                tempmessage.ID = i;
                tempmessage.Data = DateTime.FromOADate(DateTime.Now.ToOADate() + i * 100);             
                source.Add(tempmessage);
            }
            //source.Sort(new Comparison< TMessage3 >(MyCompare));
            gridControl1.DataSource = source;
            //CriteriaOperator _FilterOperator = new BinaryOperator("Visible", true, BinaryOperatorType.Equal);
            //gridView1.ActiveFilterEnabled = true;
            //gridView1.ActiveFilterString = _FilterOperator.ToString(); 

            grdColVisible.Visible = false;
        }

        private int MyCompare(TMessage3 m1, TMessage3 m2)
        {
            return DateTime.Compare(m1.Data, m2.Data) * -1;
        }

        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            //TMessage3 m1 = e.RowObject1 as TMessage3;
            //m1.Visible = true;
            //TMessage3 m2 = e.RowObject2 as TMessage3;
            //m2.Visible = true;
            //if (e.Column == grdColID)
            //{
            //    e.Result = DateTime.Compare(m1.Data, m2.Data);
            //}
            //e.Handled = true;
        }

        private void gridView1_EndSorting(object sender, EventArgs e)
        {
            //for (int i = gridView1.RowCount - 1; i > 4; i--)
            //{
            //    TMessage3 m = gridView1.GetRow(i) as TMessage3;
            //    m.Visible = false;
            //}
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            source.RemoveAt(source.Count -1);
            gridControl1.RefreshDataSource();
            //gridView1.ActiveFilterEnabled = false;            
            //gridView1.ActiveFilterEnabled = true;
        }
        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TMessage3 m = new TMessage3();

            m.ID = cnt;
            cnt++;
            m.Data = DateTime.FromOADate(DateTime.Now.ToOADate() + cnt * 100);
            source.Add(m);
            gridControl1.RefreshDataSource();
            //gridView1.ActiveFilterEnabled = false;
            //gridView1.ActiveFilterEnabled = true;
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            //if (gridView1.ActiveFilterEnabled == true)
            //{
                
            //    //TMessage3 m = gridView1.GetRow(gridView1.GetRowHandle(e.ListSourceRow)) as TMessage3;

            //    //if (m != null)
            //    //{
            //    //    if (m.Visible == false)
            //    //    {
            //    //        e.Handled = true;
            //    //        e.Visible = false;
            //    //    }
            //    //}
            //}
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //gridView1.ActiveFilterEnabled = false;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //gridView1.ActiveFilterEnabled = true;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            object row = gridView1.GetRow(e.RowHandle) as TMessage3;
            if (row != null)
            {
                
            }
        }

        private void btnAddVisibleCol_Click(object sender, EventArgs e)
        {
            if (gridView1.Columns.Contains(grdColVisible) == false)
            {                
                gridView1.Columns.Add(grdColVisible);
                grdColVisible.VisibleIndex = 1;
            }
        }

        private void btnRemoveVisible_Click(object sender, EventArgs e)
        {
            if (gridView1.Columns.Contains(grdColVisible))
            {
                gridView1.Columns.Remove(grdColVisible);
            }
        }

        private GridViewInfo GetViewInfo(GridView view)
        {
            FieldInfo fi;
            fi = typeof(GridView).GetField("fViewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            return fi.GetValue(view) as GridViewInfo;

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            GridViewInfo info = GetViewInfo(gridView1);
            int number = info.RowsInfo.GetInfoByHandle(gridView1.FocusedRowHandle).VisibleIndex;
            MessageBox.Show(number.ToString());
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == grdColRowNum)
            {
                GridViewInfo info = GetViewInfo(gridView1);
                int number = info.RowsInfo.GetInfoByHandle(e.RowHandle).VisibleIndex;
                e.DisplayText = number.ToString();
            }
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            if (gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                MessageBox.Show(gridView1.GetGroupRowDisplayText(gridView1.FocusedRowHandle));
            }
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grdColRowNum.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
        }

        private void gridView1_CustomColumnGroup(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            if (e.Column == grdColID)
            {
                TMessage3 ms1 = e.RowObject1 as TMessage3;
                TMessage3 ms2 = e.RowObject2 as TMessage3;
                if ((ms1.ID  == 1) && (ms2.ID == 2))
                {
                    e.Result = 0;
                    e.Handled = true;
                }
               
            }
        }
    }

}