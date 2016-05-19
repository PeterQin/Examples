using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace TuningSolution_XMLView_WinApp
{
    public enum ViewType
    {
        Text,
        XML,
        HTML,
    }
    public partial class ucXMLViewer : UserControl
    {
        private ViewType FCurrentType = ViewType.XML;
        public ucXMLViewer()
        {
            InitializeComponent();
            barManager1.SetPopupContextMenu(panelControl1, popupMenu1);
            webViewer.IsWebBrowserContextMenuEnabled = true;
            webViewer.AllowWebBrowserDrop = false;
            webViewer.Url = new Uri("http://sqloptimizersqlserver.inside.quest.com/index.jspa");
            webViewer.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webViewer_DocumentCompleted);
            
        }

        void webViewer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webViewer.Document.MouseUp -= new HtmlElementEventHandler(Document_MouseUp);
            webViewer.Document.MouseUp += new HtmlElementEventHandler(Document_MouseUp);
        }

        void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Right)
            {
                
            }
           // popupMenu1.ShowPopup(webViewer.PointToScreen(e.MousePosition));
        }

        private void Extract(string aXML, string aPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(aXML);
                xmlDoc.Save(aPath);
            }
            catch (Exception ex)
            {
                DisplayText(ex.Message);
            }
        }

        public bool TryToBrower(string aXML)
        {
            FCurrentType = ViewType.XML;
            bool Result = false;
            string _TempFileURL = Path.GetTempPath() + "XMLViewertempxmlfile.xml";
            try
            {
                Extract(aXML, _TempFileURL);
                //webViewer.Navigate(_TempFileURL);

                XslCompiledTransform xslt = new XslCompiledTransform();

                XmlReaderSettings ReaderSettings = new XmlReaderSettings();
                ReaderSettings.NameTable = ReaderSettings.NameTable ?? new NameTable();
                ReaderSettings.CheckCharacters = false;
                using (StringReader sr = new StringReader(rcXML.xml_pretty_print))
                {
                    using (XmlReader reader = XmlReader.Create(sr, ReaderSettings))
                    {
                        xslt.Load(reader);
                    }
                }

                //xslt.Load("xml-pretty-print.xsl");
                TextReader tr = new StringReader(aXML);
                XPathDocument xpath = new XPathDocument(tr);
                TextWriter tw = new StringWriter();
                XmlWriter xwriter = XmlWriter.Create(tw);
                xslt.Transform(xpath, xwriter);
                webViewer.DocumentText = tw.ToString();
                //webViewer.pri
                Result = true;
                Endisable();
            }
            catch (Exception ex)
            {
                DisplayText(ex.Message);
                Result = false;
            }
            return Result;
        }

        public bool TryToBrowerHTML(string aHTML)
        {
            FCurrentType = ViewType.HTML;
            bool Result = false;
            string _TempFileURL = Path.GetTempPath() + "XMLViewerTempHTMLFile.html";
            try
            {                
                File.WriteAllText(_TempFileURL, aHTML);
                webViewer.Navigate(_TempFileURL);
                Result = true;
                Endisable();
            }
            catch (Exception ex)
            {
                DisplayText(ex.Message);
                Result = false;
            }
            return Result;
        }

        private void Endisable()
        {
            if (FCurrentType == ViewType.Text)
            {
                richTextBoxError.Visible = true;
                webViewer.Visible = false;
            }
            else
            {
                richTextBoxError.Visible = false;
                webViewer.Visible = true;
            }
        }

        public void DisplayText(string aText)
        {
            FCurrentType = ViewType.Text;
            richTextBoxError.Text = aText;
            Endisable();
        }

        public bool SaveAs(string aXML, string aPath)
        {
            bool Result = false;
            try
            {
                Extract(aXML, aPath);
                Result = true;
            }
            catch (Exception ex)
            {
                DisplayText(ex.Message);
                Result = false;
            }
            return Result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //File.WriteAllText("C:\\sqls", webViewer.DocumentText);
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\sqls.txt"))
            //{
            //    file.WriteLine("test");

            //    file.Close();
            //}
            webViewer.DocumentText = string.Empty;
           
        }

        private void webViewer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
 
        }

        private void ucXMLViewer_Click(object sender, EventArgs e)
        {

        }

        private void webViewer_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }
    }
}
