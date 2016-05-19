using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using DevExpress.XtraEditors;

namespace Quest.Tunning.AddEditTask
{
    public partial class frmAddEditTask : Form
    {
        #region Field
        private const string C_cmdCopyFolder = "CopyFolder";
        private const string C_cmdCopyFile = "CopyFile";
        private const string C_cmdRunProgram = "RunProgram";
        private Point pointFileCombox;
        private Point pointProgramCombox;
        private string XMLPath = Application.StartupPath + "\\Tasks.xml";
        #endregion

        #region Constructor & Destroyer
        public frmAddEditTask()
        {
            InitializeComponent();
            pointFileCombox = new Point(ucSelectFile.EditLocationX, this.cmbTaskType.Location.Y);
            pointProgramCombox = new Point(ucSelectApplication.EditLocationX, this.cmbTaskType.Location.Y);
            ucSelectApplication.OnEditTextChanged += new EventHandler(uc_TextChanged);
            ucSelectFile.EditTextChanged += new EventHandler(uc_TextChanged);
        }
        #endregion

        #region Events
        private void cmbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbTaskType.SelectedItem.ToString())
            {
                case C_cmdCopyFolder:
                    this.cmbTaskType.Location = this.pointFileCombox;
                    this.spcView.PanelVisibility = SplitPanelVisibility.Panel2;
                    this.ucSelectFile.Action = ucSelectFile.ActionType.CopyFolder;
                    this.ucSelectFile.TurnLabelName();
                    break;
                case C_cmdCopyFile:
                    this.cmbTaskType.Location = this.pointFileCombox;
                    this.spcView.PanelVisibility = SplitPanelVisibility.Panel2;
                    this.ucSelectFile.Action = ucSelectFile.ActionType.CopyFile;
                    this.ucSelectFile.TurnLabelName();
                    break;
                case C_cmdRunProgram:
                    this.cmbTaskType.Location = this.pointProgramCombox;
                    this.spcView.PanelVisibility = SplitPanelVisibility.Panel1;
                    break;
                default:
                    break;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.cmbTaskType.SelectedItem.ToString())
                {
                    case C_cmdCopyFolder:
                        TEditXML.WriteXML(XMLPath, C_cmdCopyFolder, this.ucSelectFile.SourcePath, this.ucSelectFile.DestinationPath);
                        break;
                    case C_cmdCopyFile:
                        TEditXML.WriteXML(XMLPath, C_cmdCopyFile, this.ucSelectFile.SourcePath, this.ucSelectFile.DestinationPath);
                        break;
                    case C_cmdRunProgram:
                        TEditXML.WriteXML(XMLPath, C_cmdRunProgram, this.ucSelectApplication.ProgramPath, this.ucSelectApplication.Argument[0].ToString());
                        break;
                    default:
                        break;
                }
                this.SuccessStatus();
               


            }
            catch (Exception)
            {
                this.FailStatus();
                MessageBox.Show(e.ToString());
            }


        }

        private void cmbTaskType_Click(object sender, EventArgs e)
        {
            this.ResetStatus();
            
        }
        #endregion

        #region Method
        /// <summary>
        /// When the user control send event then will run this method. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uc_TextChanged(object sender, EventArgs e)
        {
            this.ResetStatus();
        }

        /// <summary>
        /// Change Status label to ready and change OK button to enable.
        /// </summary>
        private void ResetStatus()
        {
            this.lblStatus.Caption = rcStatus.lblReady;
            this.lblStatus.ImageIndex = -1;
            this.btnOK.Enabled = true;
        }

        /// <summary>
        /// Change Status label to Success and change OK button to unenable.
        /// </summary>
        private void SuccessStatus()
        {
            this.lblStatus.Caption = rcStatus.lblSuccess;
            this.lblStatus.ImageIndex = 0;
            this.btnOK.Enabled = false;
        }

        /// <summary>
        /// Change Status label to Fail and change OK button to unenable.
        /// </summary>
        private void FailStatus()
        {
            this.lblStatus.Caption = rcStatus.lblFail;
            this.lblStatus.ImageIndex = 1;
            this.btnOK.Enabled = false;
        }
        #endregion

    }

    /// <summary>
    /// Edit XML which from xmlPath
    /// </summary>
    public class TEditXML
    {
        /// <summary>
        /// Change the XML doucument
        /// </summary>
        /// <param name="xmlPath">the xml file path</param>
        /// <param name="nodeName">a string node name</param>
        /// <param name="firstNodeText">a string node text</param>
        /// <param name="secondNodeText">a string node text</param>
        protected internal static void WriteXML(string xmlPath, string nodeName, string firstNodeText, string secondNodeText)
        {
            XmlDocument doucument = new XmlDocument();

            doucument.Load(xmlPath);
            foreach (XmlNode node in doucument.ChildNodes[0].ChildNodes)
            {
                if (node.Name.ToString() == nodeName)
                {
                    node.ChildNodes[0].ChildNodes[0].InnerText = firstNodeText;
                    node.ChildNodes[1].ChildNodes[0].InnerText = secondNodeText;
                }

            }
            doucument.Save(xmlPath);


        }



    }
}