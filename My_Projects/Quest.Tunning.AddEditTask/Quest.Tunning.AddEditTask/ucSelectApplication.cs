using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Quest.Tunning.AddEditTask
{
    /// <summary>
    /// this is a user control to select program
    /// Peter Qin -- August 30, 2010
    /// </summary>
    public partial class ucSelectApplication : UserControl
    {
        public event EventHandler OnEditTextChanged;
        
        #region Properties
        private string FProgramPath;
        public string ProgramPath
        {
            get { return FProgramPath; }
            set { FProgramPath = value; }
        }
        private string[] FArgument;
        public string[] Argument
        {
            get { return this.memArgument.Lines; }
            set { FArgument = value; }
        }
        public int EditLocationX
        {
            get { return edtProgram.Location.X; }
        }
        
        #endregion

        #region Constructor & Destroyer
        public ucSelectApplication()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void edtProgram_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (DialogResult.OK == this.ofdProgram.ShowDialog())
            {
                this.edtProgram.Text = this.ofdProgram.FileName;
                this.FProgramPath = this.ofdProgram.FileName;
            }
        }

        private void edtProgram_EditValueChanged(object sender, EventArgs e)
        {
            this.FProgramPath = this.edtProgram.Text;
            if (OnEditTextChanged!=null)
            {
                OnEditTextChanged(sender, e);
            }
            
        }

        private void memArgument_EditValueChanged(object sender, EventArgs e)
        {
            if (OnEditTextChanged != null)
            {
                OnEditTextChanged(sender, e);
            }
        }

        #endregion

       
        
    }
}