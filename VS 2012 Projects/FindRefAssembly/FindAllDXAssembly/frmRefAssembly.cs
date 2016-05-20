using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindRefAssembly
{
    public partial class frmRefAssembly : Form
    {
        private static readonly string C_Dll = ".dll";
        private const string C_ref = "<Reference Include=\"";
        List<string> FListAssemblyName = new List<string>();
        public frmRefAssembly()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyWord = txtKeyWord.Text;
            string projFolder = txtProjectFolder.Text;
            string projExtantion = ".csproj";

            if (string.IsNullOrWhiteSpace(keyWord))
            {
                MessageBox.Show("Key word cannot be null or empty!");
                return;
            }

            rchMsg.Clear();
            rchMsg.Text = ">>>>>>>>>>>> All Assembly >>>>>>>>>>" + Environment.NewLine;

            List<string> listProjFile = new List<string>();
            listProjFile.AddRange(Directory.GetFiles(projFolder, "*" + projExtantion, SearchOption.AllDirectories));

            if (listProjFile.Count == 0)
            {
                MessageBox.Show("No project file found!");
                return;
            }

            foreach (string item in listProjFile)
            {               
                string content = File.ReadAllText(item);
                while (content.IndexOf(C_ref) > -1)
                {
                    int index =content.IndexOf(C_ref);
                    int indexreal = index+ C_ref.Length;   
                    int length = content.IndexOf(",", index) - indexreal;
                    if (length > 0)
                    {
                        string name = content.Substring(indexreal, length);
                        if (name.ToLower().StartsWith(keyWord.ToLower()))
                        {
                            bool contain = false;
                            foreach (string asm in FListAssemblyName)
                            {
                                if (asm.ToLower().Equals(name.ToLower()))
                                {
                                    contain = true;
                                    break;
                                }
                            }
                            if (contain == false)
                            {
                                FListAssemblyName.Add(name);
                            }
                        }
                    }
                    
                    content = content.Substring(content.IndexOf("/>", indexreal));
                }
            }

            FListAssemblyName.Sort();
            for (int i = 0; i < FListAssemblyName.Count; i++)
            {
                FListAssemblyName[i] = FListAssemblyName[i] + C_Dll;
                rchMsg.Text = rchMsg.Text + FListAssemblyName[i] + Environment.NewLine;
            }

            rchMsg.Text = rchMsg.Text + "<<<<<<<<<< All Assembly <<<<<<<<<<<<<";
        }
               
        private void btnCopy_Click(object sender, EventArgs e)
        {
            string destination = txtDestination.Text;
            string assemblyFolder = txtInstallFolder.Text;

            rchMsg.Text = string.Empty;
            rchMsg.Text = ">>>>>>>>>>>>>> Copy files >>>>>>>>>>" + Environment.NewLine;
            foreach (string item in FListAssemblyName)
            {
                string[] paths = Directory.GetFiles(assemblyFolder, item, SearchOption.AllDirectories);
                foreach (string path in paths)
                {
                    File.Copy(path, Path.Combine(destination, item), true);
                    rchMsg.Text = rchMsg.Text + path + Environment.NewLine;
                }
               
            }
            rchMsg.Text = rchMsg.Text + Environment.NewLine + "<<<<<<<<<<<< Copy complete <<<<<<<<<<<<<<<";
        }

        private void btnProj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectFolder.Text) == false)
            {
                folderBrowserDialog1.SelectedPath = txtProjectFolder.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtProjectFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnInstallFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInstallFolder.Text) == false)
            {
                folderBrowserDialog1.SelectedPath = txtInstallFolder.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtInstallFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCopyFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestination.Text) == false)
            {
                folderBrowserDialog1.SelectedPath = txtDestination.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDestination.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FListAssemblyName.Clear();
            rchMsg.Clear();
        }
    }


}
