using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reflection
{
    public partial class frmReflection : Form
    {
        public frmReflection()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbClass.Text == string.Empty)
            {
                MessageBox.Show("Input is empty!");
            }
            else
            {
                Type _type = Type.GetType("Reflection."+cmbClass.Text);                
                IClass _myClass = (IClass)Activator.CreateInstance(_type);
                rchMsg.Text = _myClass.Display();
            }
        }       
    }
}