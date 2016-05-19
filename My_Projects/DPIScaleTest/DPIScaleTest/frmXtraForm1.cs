using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DPIScaleTest
{
    public partial class frmXtraForm1 : BaseXtraForm
    {
        public static frmXtraForm1 Form = new frmXtraForm1();

        public frmXtraForm1()
        {
            InitializeComponent();

            this.Text = this.Text + " -- " + QAutoScaleFactor.ToString();            

        }


    }
}