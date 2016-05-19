using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace RegexExample
{
    public partial class frmValidataPath : Form
    {
        private const string C_RegexString = "[\\*\\\\/:?<>|\"]";
        private const string C_IllagelPath = "Illegal characters in Path.";
        public frmValidataPath()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            Regex regEx = new Regex(C_RegexString);
            if (regEx.IsMatch(txtPath.Text))
            {
                lblMsgContain.Text = C_IllagelPath;
                txtPath.Focus();
            }
            else
            {
                lblMsgContain.Text=string.Empty;
            }
        }

        private void frmValidataPath_Load(object sender, EventArgs e)
        {
           char[] _IllagelChars= Path.GetInvalidFileNameChars();
           StringBuilder _IllagelContain = new StringBuilder();
           foreach (char _IllagelChar in _IllagelChars)
           {
               _IllagelContain.Append(_IllagelChar);
               _IllagelContain.Append(" ");
           }
           rchIllagelCharacter.Text = _IllagelContain.ToString();
        }
    }
}