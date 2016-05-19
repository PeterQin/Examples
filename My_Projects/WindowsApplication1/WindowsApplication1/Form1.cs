using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();
            textBox1.Visible = true;
            linkLabel1.Visible = false;
            tableLayoutPanel1.ResumeLayout();
            

        }

        private void textEdit1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrEmpty(textEdit1.Text);
        }
    }
}