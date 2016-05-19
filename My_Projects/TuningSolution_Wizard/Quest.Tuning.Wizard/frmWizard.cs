using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quest.Tuning.Wizard
{
    public partial class frmWizard : Form
    {
        public frmWizard()
        {
            InitializeComponent();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPupWizard PupWizard = new frmPupWizard();
            PupWizard.Show();
        }

        private void btnMigrate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPupMigrate PupMigrate = new frmPupMigrate();
            PupMigrate.Show();
        }
    }
}