using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;

namespace Quest.Tuning.GridTest
{
    public partial class frmTree : DevExpress.XtraEditors.XtraForm
    {
        private List<string> ProjectSuite = new List<string>();
        List<TMessage2> ProjectList = new List<TMessage2>();
        public frmTree()
        {
            InitializeComponent();
            ProjectSuite.Add("Even");
            ProjectSuite.Add("Odd");
            
            for (int i = 0; i < 10; i++)
            {
                TMessage2 m2 = new TMessage2();
                m2.ID = i;
                m2.Data = DateTime.Now;
                ProjectList.Add(m2);
            }
        }

        private void frmTree_Load(object sender, EventArgs e)
        {
            foreach (string var in ProjectSuite)
            {
                treM.AppendNode(new object[] { var, null }, -1);
            }

            int ParentID = -1;
            foreach (TMessage2 mm in ProjectList)
            {
                if (mm.ID % 2 == 0) //check project suite
                {
                    ParentID = FindParentNodeID("Even");                    
                }
                else
                {
                    ParentID = FindParentNodeID("Odd");  
                }

                treM.AppendNode(new object[] { mm.ID, mm.Data }, ParentID);
                
            }
        }

        private int FindParentNodeID(string aParent)
        {
            foreach (TreeListNode node in treM.Nodes)
            {
                if (node.Level == 0)
                {
                    object id = node.GetValue("ID");
                    if (id != null && aParent.Equals(id.ToString()))
                    {
                        return node.Id;
                    }
                }
            }
            return -1;
        }

        private void treM_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Appearance.BackColor = Color.Green;
            }
        }
    }
}