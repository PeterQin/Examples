using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace Quest.Tuning.TextWindowsApplication6
{
    public partial class Notepad : Form
    {
        #region Field

       
        #region Const / Delegate / Enum
        static string filepath = "";
        #endregion Const / Delegate / Enum

        #region Property
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public Notepad()
        {
            InitializeComponent();
        }

        #endregion Constructor & Destroyer

        #region Private Section

        /// <summary>
        /// click New menu
        /// display warning window if text isn't empty
        /// </summary>
        private void warningAndsaveFile()
        {
            String warningtext = "The Text has changed.\r\n" + "Do you want to save the change?";
            MessageBoxButtons msbutton = MessageBoxButtons.YesNoCancel;
            DialogResult dialogresult = MessageBox.Show(this, warningtext, "Warning", msbutton, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult.Yes == dialogresult)
            {
                saveFile();
            }
            else if (DialogResult.No == dialogresult)
            {

                this.rtbWindow.Clear();

            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// click Open menu
        /// display warning window if the text is not empty
        /// </summary>
        private void warningAndopenFile()
        {
            String warningtext = "The Text has changed.\r\n" + "Do you want to save the change?";
            MessageBoxButtons msbutton = MessageBoxButtons.YesNoCancel;
            DialogResult dialogresult = MessageBox.Show(this, warningtext, "Warning", msbutton, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult.Yes == dialogresult)
            {
                this.saveFile();
                this.openFile();
            }
            else if (DialogResult.No == dialogresult)
            {

                this.openFile();

            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// save file with a dialog
        /// </summary>
        private void saveFile()
        {
            //save the default path of file
            if (!this.openFileDialog1.FileName.Equals("*.txt"))
            {
                this.saveFileDialog1.FileName = filepath;
            }
            if (DialogResult.OK == this.saveFileDialog1.ShowDialog())
            {
                filepath = this.saveFileDialog1.FileName;
                this.rtbWindow.SaveFile(filepath, RichTextBoxStreamType.PlainText);
            }
            else
            {
                return;
            }
            return;
        }

        /// <summary>
        /// open file with a dialog
        /// </summary>
        private void openFile()
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                filepath = openFileDialog1.FileName;
                using (StreamReader sreader = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    this.rtbWindow.Text = sreader.ReadToEnd();
                    sreader.Close();
                }

            }
            else
            {
                return;
            }
            return;
        }

        /// <summary>
        /// save file with defaultpath
        /// </summary>
        /// <param name="filepath"></param>
        private void defaultsave(string filepath)
        {
            using (System.IO.StreamWriter swriter = new System.IO.StreamWriter(filepath))
            {
                swriter.Write(this.rtbWindow.Text);
                swriter.Flush();
                swriter.Close();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs ev)
        {

            float linesPerPage = 0;
            float yPos = 0;
      //      int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            using (Font printFont = new Font("Arial", 10))
            {

                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                // Print each line of the file.
                //if (!filepath.Equals(""))
                //{
                //    using (StreamReader streamToPrint = new StreamReader(filepath))
                //    {
                //        while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
                //        {
                //            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                //            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                //            count++;
                //        }
                //    }
                //}
                ev.Graphics.DrawString(this.rtbWindow.Text.ToString(), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;



        }

        #endregion Private Section

        #region Protected Section
        #endregion Protected Section

        #region Public Section
        #endregion Public Section

        #region Events
        #endregion Events

        #region ClickAction
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rtbWindow.Text.Equals(""))
            {
                warningAndsaveFile();

            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rtbWindow.Text.Equals(""))
            {
                this.warningAndopenFile();
            }
            else
            {
                this.openFile();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filepath.Equals(""))
            {
                this.saveFile();
            }
            else
            {
                this.defaultsave(filepath);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFile();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printDialog1.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.printPreviewDialog1.ShowDialog();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbWindow.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbWindow.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbWindow.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbWindow.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbWindow.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbWindow.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.Show();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.rtbWindow.SelectedText = "";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.rtbWindow.SelectedText != "")
            {
                toolStripMenuItem1.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
            }
            else
            {
                toolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmFind find = new frmFind(); 
            find.Show();
            find.FindAction += new EventHandler(FindString);
        }

        #endregion ClickAction

        #region Method
        public void FindString(Object sender,EventArgs e)
        {
            if (this.rtbWindow.Text.IndexOf(TMessage.GetFindString()) != -1)
            {
                this.rtbWindow.Select(this.rtbWindow.Text.IndexOf(TMessage.GetFindString()), TMessage.GetFindString().ToString().Length);
                this.rtbWindow.SelectionBackColor = Color.Blue;
                
            }
            else
            {
                
            }
           
        }
        #endregion






    }
}