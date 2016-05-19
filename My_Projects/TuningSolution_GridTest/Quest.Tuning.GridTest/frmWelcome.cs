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
    public partial class frmWelcome : DevExpress.XtraEditors.XtraForm
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void btnSimpleSQLProfiler_Click(object sender, EventArgs e)
        {
            new frmGrid().Show();
        }

        private void btnFixRowGrid_Click(object sender, EventArgs e)
        {
            new frmGrid2().Show();
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            new frmTree().Show();
        }

        private void btnSortBindList_Click(object sender, EventArgs e)
        {
            new frmBindingList().Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new frmDictionary().Show();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            //Peter: try to use Seven Classic Skin, will be Removed after one build.
            //Register the skins with the designer
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel defaultLF = DevExpress.LookAndFeel.UserLookAndFeel.Default;
            defaultLF.UseWindowsXPTheme = false;
            defaultLF.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
           
            defaultLF.SkinName = "Seven Classic";
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmSimpleGrid frm = new frmSimpleGrid();
            frm.Show();
        }
    }
}