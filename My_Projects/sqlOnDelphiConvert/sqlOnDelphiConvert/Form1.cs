using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sqlOnDelphiConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnconvert_Click(object sender, EventArgs e)
        {
            string content = richTextBox2.Text;
            content = content.Replace("'", "''");
            StringBuilder sbConverted = new StringBuilder();
            sbConverted.Append("exec sp_executesql N'");
            sbConverted.Append(content);
            sbConverted.Append("',");
            sbConverted.Append("\r\n");
            sbConverted.Append("N'@a nvarchar(max)', @a = N'sqlexp'");
            richTextBox3.Text = sbConverted.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sbConverted = new StringBuilder();
            string content = richTextBox1.Text;
            string[] arraycontent = content.Split(new string[] { "+ #13#10 +" }, StringSplitOptions.None);

            for (int i = 0; i < arraycontent.Length; i++)
            {
                string line = arraycontent[i];
                if (string.IsNullOrEmpty(line) == false)
                {
                    line = line.Trim();

                    

                    
                    //if (i == arraycontent.Length - 1)
                    //{
                    //    line = line.Remove(line.LastIndexOf("'"));
                    //}

                    int lidx = line.LastIndexOf("'");
                    if (lidx >= 0)
                    {
                        line = line.Remove(lidx);
                    }

                    if (line.StartsWith("'"))
                    {
                        line = line.Remove(0, 1);
                    }
                    line = line.Replace("''", "'");
                    sbConverted.Append(line);
                    sbConverted.Append("\r\n");
                }
            }

            richTextBox2.Text = sbConverted.ToString();
        }
    }
}