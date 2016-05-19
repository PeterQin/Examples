using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Quest.Tunning.SelectApplication
{
    /// <summary>
    /// this is a user control to select program
    /// Peter Qin -- August 30, 2010
    /// </summary>
    public partial class ucSelectApplication : UserControl
    {
        private string _ProgramPath;
        public string ProgramPath
        {
            get { return _ProgramPath; }
            set { _ProgramPath = value; }
        }
        private string[] _Argument;
        public string[] Argument
        {
            get { return this.memArgument.Lines; }
            set { _Argument = value; }
        }
        public ucSelectApplication()
        {
            InitializeComponent();
        }

        private void edtProgram_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (DialogResult.OK == this.ofdProgram.ShowDialog())
            {
                this.edtProgram.Text = this.ofdProgram.FileName;
                this._ProgramPath = this.ofdProgram.FileName;
            }
        }

        private void edtProgram_EditValueChanged(object sender, EventArgs e)
        {
            this._ProgramPath = this.edtProgram.Text;
        }
    }
}