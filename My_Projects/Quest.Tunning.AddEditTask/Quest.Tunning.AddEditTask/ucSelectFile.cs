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
    /// this user contorl use to select file or folder
    /// Peter Qin --August 27,2010
    /// </summary>
    public partial class ucSelectFile : UserControl
    {

        #region Field

        private string FSourcePath;
        public string SourcePath
        {
            get { return FSourcePath; }
            set { FSourcePath = value; }
        }
        private string FDestinationPath;
        public string DestinationPath
        {
            get { return FDestinationPath; }
            set { FDestinationPath = value; }
        }

        public enum ActionType
        {
            CopyFolder,
            CopyFile
        }

        private ActionType FAction;
        public ActionType Action
        {
            get { return FAction; }
            set { FAction = value; }
        }
        public int EditLocationX
        {
            get { return this.edtDestination.Location.X; }
        }
        public event EventHandler EditTextChanged;

        #endregion
        #region Method

        public ucSelectFile()
        {
            InitializeComponent();
            //this._Action = ActionType.CopyFile;
        }

        /// <summary>
        /// Open different dialog depend on FAction  and Change the path.
        /// </summary>
        /// <param name="path">A file path or A folder path</param>
        private void SetPath(ref string path)
        {
            if (this.FAction == ActionType.CopyFolder)
            {
                if (DialogResult.OK == this.fbdFolder.ShowDialog())
                {

                    path = this.fbdFolder.SelectedPath;

                }
            }
            else if (this.FAction == ActionType.CopyFile)
            {
                if (DialogResult.OK == this.ofdFile.ShowDialog())
                {
                    path = this.ofdFile.FileName;
                }
                
            }

        }

        /// <summary>
        /// Change the label's name
        /// </summary>
        public void TurnLabelName()
        {
            if (this.FAction == ActionType.CopyFolder)
            {
                this.lblSource.Text = rcLabelText.lblFolderSource;
                this.lblDestination.Text = rcLabelText.lblFolderDestination;
            }
            else if (this.FAction == ActionType.CopyFile)
            {

                this.lblSource.Text = rcLabelText.lblFileSource;
                this.lblDestination.Text = rcLabelText.lblFileDestination;
            }
        }
        #endregion
        #region Event
        /// <summary>
        /// Open different dialog(FolderBrowserDialog or OpenFileDialog) for source when button is clicked in Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edtSource_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.SetPath(ref this.FSourcePath);
            this.edtSource.Text = this.FSourcePath;
        }

        /// <summary>
        /// Destination:
        /// Open different dialog(FolderBrowserDialog or OpenFileDialog) for destination when button is clicked in Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edtDestination_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.SetPath(ref this.FDestinationPath);
            this.edtDestination.Text = this.FDestinationPath;
        }

        private void edtSource_EditValueChanged(object sender, EventArgs e)
        {
            this.FSourcePath = this.edtSource.Text;
            if (EditTextChanged != null)
            {
                this.EditTextChanged(sender, e);
            }

        }

        private void edtDestination_EditValueChanged(object sender, EventArgs e)
        {
            this.FDestinationPath = this.edtDestination.Text;
            if (EditTextChanged != null) 
            {
                this.EditTextChanged(sender, e);
            }
            
        }
        #endregion
    }
}