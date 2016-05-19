using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BuildProject
{
    public partial class frmEdit : Form
    {
        public frmEdit()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return this.Title; }
            set { this.Title = value; }
        }

        public bool EnableValueEdit
        {
            get { return tbxValue.Enabled; }
            set { tbxValue.Enabled = value; }
        }

        public bool EnableNameEdit
        {
            get { return tbxName.Enabled; }
            set { tbxName.Enabled = value; }
        }

        public string TextBoxName
        {
            get { return tbxName.Text; }
            set { tbxName.Text = value; }
        }

        public string TextBoxValue
        {
            get { return tbxValue.Text; }
            set { tbxValue.Text = value; }
        }	

    }
}