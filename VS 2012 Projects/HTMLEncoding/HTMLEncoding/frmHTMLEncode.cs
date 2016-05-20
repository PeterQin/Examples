using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTMLEncoding
{
    public partial class frmHTMLEncode : Form
    {
        public frmHTMLEncode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = System.Net.WebUtility.HtmlEncode(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = System.Net.WebUtility.HtmlDecode(richTextBox1.Text);
        }
    }
}
