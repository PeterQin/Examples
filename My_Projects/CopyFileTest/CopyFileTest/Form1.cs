using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CopyFileTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Copy(textBox1.Text, textBox2.Text);
                MessageBox.Show("Complete!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }    
        }
    }
}