using CompileCondition.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompileCondition
{
    public partial class frmCondition : Form
    {
        #region Field
        private List<Product> FProductList;
        private List<Edition> FEditionList;
        private BindingList<Project> FProjectList;

        private Product FCurrentProduct;
        private Edition FCurrentEdition;
        private string FCurrentVersion;

        #region Const / Enum / Delegate / Event

        private static readonly string Z_AutoBuildXML = "Autobuild.xml";
        private static readonly string Z_Va_D_Format = "va%s";
        private static readonly string Z_Vb_D_Format = "vb%s";
        private static readonly string Z_Vc_D_Format = "vc%s";
        private static readonly string Z_Va_C_Format = "va{0}";
        private static readonly string Z_Vb_C_Format = "vb{0}";
        private static readonly string Z_Vc_C_Format = "vc{0}";

        #endregion Const / Enum / Delegate / Event

        #region Property
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public frmCondition()
        {
            InitializeComponent();

            Init();

            cmbProduct.DataSource = FProductList;
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private void Init()
        {
            dataGridViewProject.AutoGenerateColumns = false;

            string autoBuildPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Z_AutoBuildXML);
            if (File.Exists(autoBuildPath))
            {
                FProductList = XMLHelper.Instance.LoadProducts(File.ReadAllText(autoBuildPath));
            }
        }

        private void FormatCondition()
        {
            if (FProjectList.HasElement())
            {
                for (int i = 0; i < FProjectList.Count; i++)
                {
                    Project proj = FProjectList[i];
                    proj.DisplayCondition = GetFormattedCondition(proj.Condition);
                }
            }
        }

        private string GetFormattedCondition(string aCondition)
        {
            if (aCondition.Contains(Z_Va_D_Format)
                || aCondition.Contains(Z_Vb_D_Format)
                || aCondition.Contains(Z_Vc_D_Format))
            {
                string formattedCondition = string.Empty;
                formattedCondition = aCondition.Replace(Z_Va_D_Format, string.Format(Z_Va_C_Format, numMajor.Value));
                formattedCondition = formattedCondition.Replace(Z_Vb_D_Format, string.Format(Z_Vb_C_Format, numMinor.Value));
                formattedCondition = formattedCondition.Replace(Z_Vc_D_Format, string.Format(Z_Vc_C_Format, numRelease.Value));
                return formattedCondition;
            }
            else
            {
                return aCondition;
            }
        }

        #endregion Private Section

        #region Protected Section
        #endregion Protected Section

        #region Public Section
        #endregion Public Section

        #region Events

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            FCurrentProduct = FProductList[cmbProduct.SelectedIndex];
            cmbEdition.DataSource = FEditionList = FCurrentProduct.EditionList;
        }

        private void cmbEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
            FCurrentEdition = FEditionList[cmbEdition.SelectedIndex];
            FProjectList = new BindingList<Project>();
            foreach (string id in FCurrentEdition.ProjectList)
            {
                FProjectList.Add(FCurrentProduct.ProjectList.Find(x => x.ID.Equals(id)));
            }
            dataGridViewProject.DataSource = FProjectList;
            FormatCondition();
        }

        private void numVersion_ValueChanged(object sender, EventArgs e)
        {
            FormatCondition();
            
        }

        private string GetVersion()
        {
            return new Version((int)numMajor.Value, (int)numMinor.Value, (int)numRelease.Value, (int)numBuild.Value).ToString();
        }

        #endregion Events

        private void btnApply_Click(object sender, EventArgs e)
        {
            Edition currentEdition = FEditionList[cmbEdition.SelectedIndex];
            if (currentEdition != null && FProjectList.HasElement())
            {
                foreach (Project proj in FProjectList)
                {
                    proj.ApplyToLocal(currentEdition.DisplayName, GetVersion());
                }
            }
        }

        private void applyToLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edition currentEdition = FEditionList[cmbEdition.SelectedIndex];
            DataGridViewSelectedRowCollection selection = dataGridViewProject.SelectedRows;
            foreach (DataGridViewRow row in selection)
            {
                FProjectList[row.Index].ApplyToLocal(currentEdition.DisplayName, GetVersion());
            }
        }

        
    }
}
