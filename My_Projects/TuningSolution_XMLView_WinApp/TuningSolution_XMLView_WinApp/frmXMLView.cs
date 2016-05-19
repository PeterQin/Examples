using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TuningSolution_XMLView_WinApp
{
    public partial class frmXMLView : Form
    {
        private ViewType CurrentViewType = ViewType.XML;
        private string FSubText = string.Empty;
        public frmXMLView(string aFilePath)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(aFilePath) == false)
            {
                rchXMLString.Text = File.ReadAllText(aFilePath);
            }
            RefreshVisualizer();
            Endisable();
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rchXMLString.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string content = Clipboard.GetText();
                if (string.IsNullOrEmpty(content) == false)
                {
                    rchXMLString.Paste();
                }
            }
            catch (Exception ex)
            {
                ucXMLViewer1.DisplayText(ex.Message);
            }           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ucXMLViewer1.SaveAs(FSubText, saveFileDialog1.FileName);
            }
        }

        private void rchXMLString_TextChanged(object sender, EventArgs e)
        {
            FSubText = rchXMLString.Text;
            RefreshVisualizer();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rchXMLString.SelectedText) == false)
            {
                rchXMLString.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rchXMLString.SelectedText) == false)
            {
                rchXMLString.Copy();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchXMLString.SelectAll();            
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchXMLString.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchXMLString.Redo();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ExtractString(string aContent)
        {
            string Result = aContent;
            string xml = aContent;
            int startPosition = xml.IndexOf(txtExtractNode.Text, StringComparison.CurrentCultureIgnoreCase) - 1;
            if (startPosition >= 0)
            {
                int length = xml.LastIndexOf(txtExtractNode.Text, StringComparison.CurrentCultureIgnoreCase) + txtExtractNode.Text.Length - startPosition + 1;
                Result = xml.Substring(startPosition, length);
            }           
            return Result;
        }

        private void radioButtonHTML_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHTML.Checked)
            {
                ViewTypeChanged(ViewType.HTML);
            }
        }

        private void radioButtonXML_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonXML.Checked)
            {
                ViewTypeChanged(ViewType.XML);
            }
        }

        private void ViewTypeChanged(ViewType aViewType)
        {
            if (CurrentViewType != aViewType)
            {
                CurrentViewType = aViewType;

                RefreshVisualizer();

                Endisable();
            }            

        }

        public void RefreshVisualizer()
        {
            if (string.IsNullOrEmpty(rchXMLString.Text) == false)
            {
                if (string.IsNullOrEmpty(txtExtractNode.Text))
                {
                    FSubText = rchXMLString.Text;
                }
                else
                {
                    FSubText = ExtractString(rchXMLString.Text);
                }
            }

            switch (CurrentViewType)
            {
                case ViewType.Text:
                    break;
                case ViewType.HTML:
                    ucXMLViewer1.TryToBrowerHTML(FSubText);
                    break;
                case ViewType.XML:
                    ucXMLViewer1.TryToBrower(FSubText);
                    break;
                default:
                    break;
            }
        }

        public void Endisable()
        {
            radioButtonHTML.Checked = CurrentViewType == ViewType.HTML;
            radioButtonXML.Checked = CurrentViewType == ViewType.XML;
        }

        private void txtExtractNode_TextChanged(object sender, EventArgs e)
        {
            RefreshVisualizer();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            rchXMLString.Refresh();
        }      

    }
}