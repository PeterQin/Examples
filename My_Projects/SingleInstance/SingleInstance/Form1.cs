using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SingleInstance
{
    public partial class Form1 : Form
    {
        private static string ApplicationPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        private string fHelpCHM = Path.Combine(ApplicationPath, "TestProgram_Help.chm");
        System.Windows.Forms.ContextMenu Nicon;
        System.Windows.Forms.MenuItem menu_exit;
        public Form1()
        {
            InitializeComponent();
            InitMenuFornotifyIcon();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }

        private void InitMenuFornotifyIcon()
        {
            this.Nicon = new ContextMenu();
            this.menu_exit = new MenuItem();

            this.Nicon.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[]
                {
                    this.menu_exit
                }
                );

            this.notifyIcon1.ContextMenu =this.Nicon;

            this.menu_exit.Text = "Exit";
            this.menu_exit.Click += new EventHandler(menu_exit_Click);

        }

        void menu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (File.Exists(fHelpCHM)==false)
            {
                File.WriteAllBytes(fHelpCHM, SingleInstance.Properties.Resources.TestProgram_Help);
            }
           
            Help.ShowHelp(this, fHelpCHM);
        }
    }
}