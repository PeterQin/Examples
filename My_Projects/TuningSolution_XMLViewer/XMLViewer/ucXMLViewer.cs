using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace XMLViewer
{
    public partial class ucXMLViewer : UserControl
    {
        public ucXMLViewer()
        {
            InitializeComponent();
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
            bool Result = false;
            string _TempFileURL = Path.GetTempPath() + "XMLViewertempxmlfile.xml";           
            try
            {
                Extract(aXML, _TempFileURL);
                webViewer.Navigate(_TempFileURL);
                Result = true;
            }
            catch (Exception ex)
            {
                DisplayText(ex.Message);
                Result = false;
            }
            return Result;
        }

        public void DisplayText(string aText)
        {
            webViewer.DocumentText = aText;
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
    }
}