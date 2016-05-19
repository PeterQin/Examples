using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReadFileFromFolder
{
    public partial class frmReadFile : Form
    {
        public frmReadFile()
        {
            InitializeComponent();
        }

        private void frmReadFile_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = string.Empty;
                progressBarControl1.Visible = true;
                StringBuilder sb = new StringBuilder();
                DirectoryInfo di = new DirectoryInfo(buttonEdit1.Text);
                FileInfo[] fi = di.GetFiles(comboBoxEdit1.Text);
                int tempcnt = 0;
                foreach (FileInfo var in fi)
                {
                    using (StreamReader sr = var.OpenText())
                    {
                        sb.Append(sr.ReadToEnd());
                    }

                    handleshowprogress((tempcnt / fi.Length) * 100);
                    tempcnt++;
                }
                File.AppendAllText(buttonEdit2.Text, sb.ToString());
                lblMsg.Text = fi.Length+" file(s) copy";
                progressBarControl1.Visible = false;
            }
            catch (Exception ex)
            {
                progressBarControl1.Visible = false;
                lblMsg.Text = ex.Message;
            }          

        }
        delegate void delegate_show(int percent);
        private void handleshowprogress(int percent)
        {
            this.Invoke(new delegate_show(showprogress),percent);
        }

        private void showprogress(int percent)
        {
            progressBarControl1.Position = percent;
        }

        private void buttonEdit1_Properties_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonEdit2_Properties_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit2.Text = saveFileDialog1.FileName;
            }
        }
    }
}