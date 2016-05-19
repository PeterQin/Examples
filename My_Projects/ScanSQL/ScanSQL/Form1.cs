using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace ScanSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = textBox1.Text;
        }

        private List<string> FSQLs = new List<string>();

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Path can't be empty");
                return;
            }
            toolStripStatusLabel1.Text = "scan...";
            toolStripProgressBar1.Visible = true;

            Thread scan = new Thread(new ThreadStart(ScanProc));
            scan.Start();

            //File.AppendAllText("C:\\sqls.txt", sb.ToString());

            //toolStripStatusLabel1.Text = "Done!";
            //toolStripProgressBar1.Visible = false;
        }



        private void ScanProc()
        {
            string path = textBox1.Text;
            DirectoryInfo folder = new DirectoryInfo(path);
            FileInfo[] files = folder.GetFiles("*.*", SearchOption.AllDirectories);
            int count = 0;
            double dAll = files.Length;
            StringBuilder sb = new StringBuilder();
            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {                    
                    if (files[i].Extension.ToLower() == ".txt" || files[i].Extension.ToLower() == ".sql")
                    {                        
                        sb.Append("&#");
                        string sql = File.ReadAllText(files[i].FullName);
                        sb.Append(sql);
                        FSQLs.Add(sql);
                    }

                    count += 1;
                    double d = (count / dAll) * 100 ;
                    updateproc((int)Math.Round(d, 0));

                }

            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "run...";
            toolStripProgressBar1.Visible = true;
            Thread run = new Thread(new ThreadStart(runsql));
            run.Start();
            
           
        }

        private void runsql()
        {
            int count = 0;
            double dAll = FSQLs.Count;
            if (FSQLs.Count > 0)
            {
                string FConnectionStr = "server = ZHUVMSTQASQL2012;uid = sqlexp; pwd = sqlexp; database = sqlexp";
                SqlConnection FConnection = new SqlConnection(FConnectionStr);
                FConnection.Open();
                try
                {
                    SqlCommand FCommand = new SqlCommand();
                    FCommand.Connection = FConnection;

                    foreach (string sql in FSQLs)
                    {
                        try
                        {                            
                            FCommand.CommandText = sql;
                            FCommand.ExecuteNonQuery();
                            count += 1;
                            double d = (count / dAll) * 100;
                            updateproc((int)Math.Round(d, 0));
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                finally
                {
                    FConnection.Close();
                }

            }
        }

        delegate void delegate_proc(int p);

        private void updateproc(int p)
        {
            this.BeginInvoke(new delegate_proc(process), p);
        }

        private void process(int p)
        {
            toolStripProgressBar1.Value = p;
            if (p >= 100)
            {
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Text = "Done";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}