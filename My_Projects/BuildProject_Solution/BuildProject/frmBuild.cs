using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using BuildProject.Properties;
using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.Collections;

namespace BuildProject
{

    public partial class frmBuild : Form
    {

        #region Field

        private ViewModel FData;

        #region Const / Enum / Delegate / Event

        delegate void delegate_Message(string aMessage);
        delegate void Action();

        #endregion Const / Enum / Delegate / Event

        #region Property

        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public frmBuild()
        {
            InitializeComponent();
            FData = new ViewModel();
            FData.PropertyChanged += new PropertyChangedEventHandler(FData_PropertyChanged);
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private string GetSolutionDirectory()
        {
            if (FData == null)
            {
                return string.Empty;
            }
            return Path.GetDirectoryName(FData.Solution);
        }

        private void Endisable()
        {
            updateToolStripMenuItem.Enabled =
                (listBoxAssemblyInfo.SelectedItems != null && listBoxAssemblyInfo.SelectedItems.Count == 1);
        }

        private void GetProjects()
        {
            if (string.IsNullOrEmpty(FData.Solution) == false)
            {
                FData.Projects.Clear();
                StreamReader reader = new StreamReader(FData.Solution);
                try
                {
                    string line;
                    ProjectInfo proj;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (TryProcessProjectLine(line, out proj))
                        {
                            FData.Projects.Add(proj);
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        private bool TryProcessProjectLine(string aLine, out ProjectInfo aProjectInfo)
        {
            bool result = false;
            aProjectInfo = null;
            if (string.IsNullOrEmpty(aLine) == false && aLine.StartsWith(ProjectInfo.C_Start))
            {
                string projLocation = aLine.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[1];
                aProjectInfo = new ProjectInfo(Path.Combine(GetSolutionDirectory(), projLocation.Replace("\"", "")));
                result = true;
            }
            return result;
        }

        private void UpdateFile()
        {
            string[] FileArray = Directory.GetFiles(Path.GetDirectoryName(FData.Solution), "AssemblyInfo.cs", SearchOption.AllDirectories);
            if (FileArray.Length > 0)
            {
                foreach (string file in FileArray)
                {
                    ProcessFile(file);
                }
            }
            this.Invoke(new Action(CloseProgress));
        }

        private void ShowProgress(string aMessage)
        {
            progressBar.Visible = true;
            tableLayoutPanel1.Enabled = false;
            toolStripStatusLabel1.Text = aMessage;

        }

        private void CloseProgress()
        {
            progressBar.Visible = false;
            tableLayoutPanel1.Enabled = true;
            toolStripStatusLabel1.Text = "Ready";
        }

        private void ProcessFile(string aFile)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader reader = new StreamReader(aFile);
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.Append(ProcessLine(line));
                    sb.Append(Environment.NewLine);
                }
            }
            finally
            {
                reader.Close();
            }
            File.WriteAllText(aFile, sb.ToString(), Encoding.Unicode);
        }

        private string ProcessLine(string aLine)
        {
            string result = aLine;
            foreach (TAssemblyInfo item in FData.AssemblyInfoSource)
            {
                int start = aLine.IndexOf(item.IdentyString);
                if (start >= 0)
                {
                    int end = aLine.IndexOf(AssemblyString.C_Identify_End, start);
                    string original = aLine.Substring(start, end + AssemblyString.C_Identify_End.Length - start);
                    result = aLine.Replace(original, item.DisplayInfo);
                    break;
                }
            }
            return result;
        }

        private void OutputProc(string aMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delegate_Message(Output), aMessage);
            }
            else
            {
                Output(aMessage);
            }
        }


        private void Output(string aMessage)
        {
            rchMessage.AppendText(aMessage);
            rchMessage.AppendText(Environment.NewLine);

        }

        private void BuildSetup()
        {
            UpdateDevenvFolder(FData.SetupSolution);
            string config = FData.BuildConfig;
            if (DetectVSVersion(FData.SetupSolution) == 2005)
            {
                config = Resources.BuildConfig2005;
            }
            string buildSolution = string.Format(FData.BuildSolutionCmd, FData.SetupSolution, config);
            string buildSetupProj = buildSolution + string.Format(FData.BuildProjectCmd, FData.SetupProject, config);
            ExecuteCmd(buildSetupProj, FData.DevenvFolder);

            if (string.IsNullOrEmpty(FData.SetupOutput) == false)
            {
                string setupProFolder = Path.GetDirectoryName(FData.SetupProject);
                string setupOutput = setupProFolder + FData.SetupProjOriginalOutput;
                if (DetectVSVersion(FData.SetupSolution) == 2005)
                {
                    setupOutput = setupProFolder + Resources.SetupProjOriginalOutput2005;
                }
                ArrayList buildFileArray = new ArrayList();
                if (Directory.Exists(setupOutput))
                {
                    buildFileArray.AddRange(Directory.GetFiles(setupOutput, "*.msi"));
                    buildFileArray.AddRange(Directory.GetFiles(setupOutput, "*.exe"));
                }
                if (buildFileArray.Count > 0)
                {
                    foreach (string file in buildFileArray)
                    {
                        File.Copy(file, Path.Combine(FData.SetupOutput, Path.GetFileName(file)), true);
                    }
                }
            }
            
            this.Invoke(new Action(CloseProgress));
        }

        private void BuildSolution()
        {
            UpdateDevenvFolder(FData.Solution);
            string config = FData.BuildConfig;
            if (DetectVSVersion(FData.Solution) == 2005)
            {
                config = Resources.BuildConfig2005;
            }
            string buildSolution = string.Format(FData.BuildSolutionCmd, FData.Solution, config);
            ExecuteCmd(buildSolution, FData.DevenvFolder);
            this.Invoke(new Action(CloseProgress));
        }

        private void UpdateDevenvFolder(string aSolutionFileName)
        {
            FData.DevenvFolder = Resources.ResourceManager.GetString("DevenvFolder" + DetectVSVersion(aSolutionFileName));
        }

        private int DetectVSVersion(string aSolutionFileName)
        {
            int result = 2012;
            StreamReader reader = new StreamReader(aSolutionFileName);
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("# Visual Studio "))
                    {
                        string strVersion = line.Replace("# Visual Studio ", "");
                        Int32.TryParse(strVersion, out result);
                        break;
                    }
                }
            }
            finally
            {
                reader.Close();
            }
            return result;
            
        }

        private void ExecuteCmd(string aCommand, string aWorkingDirectory)
        {
            OutputProc(aCommand);
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            if (string.IsNullOrEmpty(aWorkingDirectory) == false)
            {
                p.StartInfo.WorkingDirectory = aWorkingDirectory;
            }
            p.Start();
            p.StandardInput.WriteLine(aCommand);
            p.StandardInput.WriteLine("EXIT");
            string strOutput;
            while ((strOutput = p.StandardOutput.ReadLine()) != null)
            {
                OutputProc(strOutput);
            }
            p.WaitForExit();
            p.Close();
        }

        #endregion Private Section

        #region Protected Section
        #endregion Protected Section

        #region Public Section
        #endregion Public Section

        #region Events

        private void listBoxAssemblyInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Endisable();
        }


        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmEdit editForm = new frmEdit())
            {
                DialogResult result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FData.AddAssemblyInfo(editForm.TextBoxName, editForm.TextBoxValue);
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TAssemblyInfo> selectedObj = new List<TAssemblyInfo>();
            StringBuilder sbMsg = new StringBuilder();
            sbMsg.Append("The following AssemblyInfo will be removed:");
            sbMsg.Append(Environment.NewLine);
            if (listBoxAssemblyInfo.SelectedItems != null && listBoxAssemblyInfo.SelectedItems.Count > 0)
            {
                foreach (object item in listBoxAssemblyInfo.SelectedItems)
                {
                    TAssemblyInfo asm = item as TAssemblyInfo;
                    sbMsg.Append(asm.InfoName);
                    sbMsg.Append(Environment.NewLine);
                    selectedObj.Add(asm);
                }
                if (MessageBox.Show(sbMsg.ToString(), "Remove AssemblyInfo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    for (int i = 0; i < selectedObj.Count; i++)
                    {
                        FData.RemoveAssemblyInfo(selectedObj[i]);
                    }
                }

            }

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TAssemblyInfo assembly = listBoxAssemblyInfo.SelectedItem as TAssemblyInfo;
            if (assembly != null)
            {
                using (frmEdit editForm = new frmEdit())
                {
                    editForm.EnableNameEdit = false;
                    editForm.TextBoxName = assembly.InfoName;
                    editForm.TextBoxValue = assembly.InfoValue;
                    DialogResult result = editForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        FData.UpdateAsseblyInfo(editForm.TextBoxName, editForm.TextBoxValue);
                    }
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = FData.Solution;
            openFileDialog.Filter = @"Solution files (*.sln)|*.sln|All files (*.*)|*.*";
            if (string.IsNullOrEmpty(FData.Solution) == false)
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(FData.Solution);
            }
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FData.Solution = openFileDialog.FileName;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FData.AssemblyInfoSource.Count <= 0)
            {
                return;
            }
            if (MessageBox.Show("Sure to update the following assembly information?","",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Thread thread = new Thread(new ThreadStart(UpdateFile));
                thread.Start();
                ShowProgress("Update AssemblyInfo");
            }
        }

        private void frmBuild_Load(object sender, EventArgs e)
        {
            FData.Load();
            listBoxAssemblyInfo.DataSource = FData.AssemblyInfoSource;
            listBoxAssemblyInfo.DisplayMember = "DisplayInfo";
            listBoxAssemblyInfo.SelectionMode = SelectionMode.MultiExtended;
            listBoxAssemblyInfo.SelectedIndexChanged += new EventHandler(listBoxAssemblyInfo_SelectedIndexChanged);

            listBoxProject.DataSource = FData.Projects;
            listBoxProject.DisplayMember = "FileName";
            listBoxProject.SelectionMode = SelectionMode.MultiExtended;
        }

        private void frmBuild_FormClosing(object sender, FormClosingEventArgs e)
        {
            FData.Save();
        }

        private void listBoxProject_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            if (e.Index >= 0)
            {
                ProjectInfo proj = listBoxProject.Items[e.Index] as ProjectInfo;
                if (proj != null)
                {
                    e.DrawBackground();

                    Brush myBrush = Brushes.Black;
                    if (proj.Include == false)
                    {
                        myBrush = Brushes.LightGray;
                    }
                    e.Graphics.DrawString(proj.FileName, e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                    e.DrawFocusRectangle();
                }
            }
        }

        private void excludeIncludeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ProjectInfo> selectedObj = new List<ProjectInfo>();
            if (listBoxProject.SelectedItems != null && listBoxProject.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listBoxProject.SelectedItems.Count; i++)
                {
                    ProjectInfo proj = listBoxProject.SelectedItems[i] as ProjectInfo;
                    FData.IncludeOrExcludeProject(proj);
                }

            }
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<ProjectInfo> selectedObj = new List<ProjectInfo>();
            StringBuilder sbMsg = new StringBuilder();
            sbMsg.Append("The following ProjectInfo will be removed:");
            sbMsg.Append(Environment.NewLine);
            if (listBoxProject.SelectedItems != null && listBoxProject.SelectedItems.Count > 0)
            {
                foreach (object item in listBoxProject.SelectedItems)
                {
                    ProjectInfo asm = item as ProjectInfo;
                    sbMsg.Append(asm.FileName);
                    sbMsg.Append(Environment.NewLine);
                    selectedObj.Add(asm);
                }
                if (MessageBox.Show(sbMsg.ToString(), "Remove ProjectInfo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    for (int i = 0; i < selectedObj.Count; i++)
                    {
                        FData.RemoveProject(selectedObj[i]);
                    }
                }

            }
        }


        /// <summary>
        /// devenv "C:\Users\pqin.PROD\Documents\Visual Studio 2012\Projects\SetupProject1\SetupProject1.sln" /rebuild "Release|x86"
        /// 
        /// devenv "C:\Users\pqin.PROD\Documents\Visual Studio 2012\Projects\SetupProject1\SetupProject1.sln" /rebuild "Release|x86"
        /// /project "C:\Users\pqin.PROD\Documents\Visual Studio 2012\Projects\SetupProject1\SetupProject1\SetupProject1.wixproj" 
        /// /projectconfig "Release|x86" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FData.SetupProject))
            {
                return;
            }
            Thread buildThread = new Thread(new ThreadStart(BuildSetup));
            buildThread.Start();
            ShowProgress("Build Setup Project...");
        }
        
        private void btnBuildSolution_Click(object sender, EventArgs e)
        {
            if (FData.AssemblyInfoSource.Count <= 0)
            {
                return;
            }
            Thread buildThread = new Thread(new ThreadStart(BuildSolution));
            buildThread.Start();
            ShowProgress("Build Solution...");
        }

        private void btnBrowseSetup_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = FData.SetupProject;
            openFileDialog.Filter = @"Wix Project File (*.wixproj)|*.wixproj|VS Deployment Project (*.vdproj)|*.vdproj|All files (*.*)|*.*";
            if (string.IsNullOrEmpty(FData.SetupProject) == false)
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(FData.SetupProject);
            }
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FData.SetupProject = openFileDialog.FileName;
            }
        }

        private void copySelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchMessage.Copy();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchMessage.Clear();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FData.SetupOutput))
            {
                folderBrowserDialog.SelectedPath = FData.SetupOutput;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FData.SetupOutput = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowseSetupSolution_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = FData.SetupSolution;
            openFileDialog.Filter = @"Solution files (*.sln)|*.sln|All files (*.*)|*.*";
            if (string.IsNullOrEmpty(FData.SetupSolution) == false)
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(FData.SetupSolution);
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FData.SetupSolution = openFileDialog.FileName;
            }
        }


        private void FData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ViewModel.C_Solution)
            {
                txtSolution.Text = FData.Solution;
                if (File.Exists(FData.Solution) && Path.GetExtension(FData.Solution) == ".sln")
                {
                    GetProjects();
                }
            }
            else if (e.PropertyName == ViewModel.C_SetupSolution)
            {
                txtSetupSolution.Text = FData.SetupSolution;
            }
            else if (e.PropertyName == ViewModel.C_SetupProject)
            {
                txtSetupProject.Text = FData.SetupProject;
            }
            else if (e.PropertyName == ViewModel.C_SetupOutput)
            {
                txtSetupOutput.Text = FData.SetupOutput;
            }

        }


        private void txtSolution_TextChanged(object sender, EventArgs e)
        {
            FData.Solution = txtSolution.Text;
        }

        private void txtSetupSolution_TextChanged(object sender, EventArgs e)
        {
            FData.SetupSolution = txtSetupSolution.Text;
        }

        private void txtSetupProject_TextChanged(object sender, EventArgs e)
        {
            FData.SetupProject = txtSetupProject.Text;
        }

        private void txtSetupOutput_TextChanged(object sender, EventArgs e)
        {
            FData.SetupOutput = txtSetupOutput.Text;
        }

        #endregion Events

     
    }
    
}