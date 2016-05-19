using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Quest.Tuning.ResourceFileDemo
{
    public partial class SelectionForm : Form
    {
        frmCultrueSamples ShowCultrue;
        public SelectionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cmbCultrue.Text != "" && this.cmbUICultrue.Text != "")
            {
                //Set Culture
                Thread.CurrentThread.CurrentCulture = new CultureInfo(this.cmbCultrue.Text);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.cmbUICultrue.Text);
                ShowCultrue = new frmCultrueSamples();
                ShowCultrue.Show();
            }
            else
            {
                MessageBox.Show("You must choose both Cultrue and UICultrue before New");
            }
            
        }

        
    }
}