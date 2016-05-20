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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private const string C_ref = "<Reference Include=\"";
        private const string C_DXAssembly = @"C:\Program Files (x86)\DevExpress\DXperience 12.2\Bin\Framework\{0}.dll";
        private const string C_DXAssembly_Design = @"C:\Program Files (x86)\DevExpress\DXperience 12.2\Bin\Framework\Design\{0}.dll";
        List<string> names = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            names.Clear();
            richTextBox1.Text = string.Empty;
            string[] files0 = Directory.GetFiles(txtProjects0.Text, "*.csproj", SearchOption.AllDirectories);
            string[] files1 = Directory.GetFiles(txtProjects1.Text, "*.csproj", SearchOption.AllDirectories);
            string[] files2 = Directory.GetFiles(txtProjects2.Text, "*.csproj", SearchOption.AllDirectories);
            
            List<string> files = new List<string>();
            files.AddRange(files0);
            files.AddRange(files1);
            files.AddRange(files2);

            foreach (string item in files)
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
                        if (name.StartsWith("DevExpress") && names.Contains(name) == false)
                        {
                            names.Add(name);
                        }
                    }
                    
                    content = content.Substring(content.IndexOf("/>", indexreal));
                }
            }

            names.Sort();
            foreach (string item in names)
            {
                richTextBox1.Text = richTextBox1.Text + item + "\r\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            foreach (string item in names)
            {
                string path = string.Empty;
                if (item.EndsWith(".Design"))
                {
                    path = string.Format(C_DXAssembly_Design, item);
                    
                }
                else
                {
                    path = string.Format(C_DXAssembly, item);
                    
                }

                File.Copy(path, txtDest.Text + "\\" + item + ".dll");
                richTextBox1.Text = richTextBox1.Text + path + "\r\n";
            }
            MessageBox.Show("copy complete");
        }
    }


}
