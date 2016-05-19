using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetSQLFromCSharpCoding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = string.Empty;
            string content = richTextBox1.Text;

            string[] lines = content.Split('+');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                line = line.Remove(0, line.IndexOf("\"") + 1);  
                line = line.Remove(line.LastIndexOf("\""));
                if (line.Equals("\\n") == false)
                {
                    sb.Append(line);
                }
                
                sb.Append("\n");
            }

            richTextBox2.Text = sb.ToString();
        }
    }
}