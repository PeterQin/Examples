using SkinEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace UpdateDXSkinAssemblyInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox7.Text = CultureInfo.CurrentCulture.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(richTextBox1.Text) == false)
            {
                MessageBox.Show("Can't found project file!");
                return;
            }
            UpdateAssembly(richTextBox1.Text);
        }

        public void UpdateAssembly(string aProjectPath)
        {
            SkinProject project = SkinProject.LoadProject(Path.GetFullPath(aProjectPath));

            SkinAssemblyBuilderArgs arguments = new SkinAssemblyBuilderArgs(project.AssemblyName,
                project.ClassName, project.ExtraNamespace, project.Name);
            CustomSkinAssemblyBuilder builder = new CustomSkinAssemblyBuilder(arguments);
            builder.AssemblyTitle = textBox2.Text;
            builder.AssemblyFileVersion = textBox3.Text;
            builder.AssemblyProduct = textBox4.Text;
            builder.AssemblyInformationalVersion = textBox5.Text;
            builder.AssemblyCopyright = textBox6.Text;
            builder.AssemblyCulture = CultureInfo.CurrentCulture.ToString();
            bool created = false;
            try
            {
                created = builder.Generate(project);
                if (created)
                {
                    MessageBox.Show("Assembly re-generated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }  
            
        }

        public class CustomSkinAssemblyBuilder : SkinAssemblyBuilder
        {
            public CustomSkinAssemblyBuilder() : base() { }
            public CustomSkinAssemblyBuilder(SkinAssemblyBuilderArgs args) : base(args) { }

            public string AssemblyTitle { get; set; }
            public string AssemblyFileVersion { get; set; }
            public string AssemblyProduct { get; set; }
            public string AssemblyInformationalVersion { get; set; }
            public string AssemblyCopyright { get; set; }
            public string AssemblyCulture { get; set; }

            protected override bool OnGenerate()
            {
                AssemblyBuilder asm = DefineDynamicAssembly(AppDomain.CurrentDomain);
                asm.Save(Args.AsmFileName);
                return true;
            }

            AssemblyBuilder DefineDynamicAssembly(AppDomain domain)
            {
                AssemblyBuilder result = (AssemblyBuilder)typeof(SkinAssemblyBuilder).GetMethod("DefineDynamicAssembly",
                    BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, new object[] { domain });

                if (string.IsNullOrWhiteSpace(AssemblyTitle) == false)
                {
                    result.SetCustomAttribute(new CustomAttributeBuilder(typeof(AssemblyTitleAttribute).GetConstructor(new Type[] { typeof(string) }),
                      new string[] { AssemblyTitle }));
                }
                if (string.IsNullOrWhiteSpace(AssemblyFileVersion) == false)
                {
                    result.SetCustomAttribute(new CustomAttributeBuilder(typeof(AssemblyFileVersionAttribute).GetConstructor(new Type[] { typeof(string) }),
                    new string[] { AssemblyFileVersion }));
                }
                if (string.IsNullOrWhiteSpace(AssemblyProduct) == false)
                {
                    result.SetCustomAttribute(new CustomAttributeBuilder(typeof(AssemblyProductAttribute).GetConstructor(new Type[] { typeof(string) }),
                    new string[] { AssemblyProduct }));
                }
                if (string.IsNullOrWhiteSpace(AssemblyInformationalVersion) == false)
                {
                    result.SetCustomAttribute(new CustomAttributeBuilder(typeof(AssemblyInformationalVersionAttribute).GetConstructor(new Type[] { typeof(string) }),
                    new string[] { AssemblyInformationalVersion }));
                }
                if (string.IsNullOrWhiteSpace(AssemblyCopyright) == false)
                {
                    result.SetCustomAttribute(new CustomAttributeBuilder(typeof(AssemblyCopyrightAttribute).GetConstructor(new Type[] { typeof(string) }),
                    new string[] { AssemblyCopyright }));
                }
                if (string.IsNullOrWhiteSpace(AssemblyCulture)== false)
                {
                    result.SetCustomAttribute(new CustomAttributeBuilder(typeof(AssemblyCultureAttribute).GetConstructor(new Type[] { typeof(string) }),
                    new string[] { AssemblyCulture }));
                }
                
                result.DefineVersionInfoResource();
                return result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(richTextBox1.Text);
            openFileDialog1.FileName = richTextBox1.Text;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Text = openFileDialog1.FileName;
            }
        }
    }
}
