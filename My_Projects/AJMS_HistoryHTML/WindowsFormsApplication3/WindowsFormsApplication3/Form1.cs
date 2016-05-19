using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using WindowsFormsApplication3.Properties;



namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Xml history file
        /// </summary>
        public class ModifyHistoryFile
        {
            public string HistoryFileLocation;
            public string HistoryFileName;
            public string HistoryStatus;
            public List<ModifyHistory> Historys;
            public ModifyHistoryFile()
            {
                Historys = new List<ModifyHistory>();
            }
        }

        /// <summary>
        /// Xml history file
        /// </summary>
        public class ModifyHistory
        {
            public string HistoryRevision;
            public string HistoryAuthor;
            public string HistoryDate;
            public string HistoryComment;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<ModifyHistoryFile> files = GetXMLHistory("c:\\FilesHistory_9_0_0_2603.xml");
            GenerateHistoryFileTable(files);
        }
        private List<ModifyHistoryFile> GetXMLHistory(string aXMLPath)
        {
            List<ModifyHistoryFile> lsModifyHistoryFile = new List<ModifyHistoryFile>();
            XmlDocument XMLDoc = new XmlDocument();

            bool IsCorrectXMLFormat = true;

            try
            {
                FileInfo XMLFile = new FileInfo(aXMLPath);
                if (XMLFile.Extension.ToLower() == ".xml")
                {
                    XMLDoc.Load(aXMLPath);
                }
            }
            catch (Exception ex)
            {
                //HandleException(ex);
                IsCorrectXMLFormat = false;
            }
            if (IsCorrectXMLFormat)
            {
                XmlNode filesHistory = XMLDoc.FirstChild;
                foreach (XmlNode FL in filesHistory.ChildNodes)
                {
                    ModifyHistoryFile FModifyHistoryFile = new ModifyHistoryFile();
                    FModifyHistoryFile.Historys = new List<ModifyHistory>();
                    foreach (XmlNode fileChild in FL.ChildNodes)
                    {
                        if (fileChild.Name == "Location")
                        {
                            FModifyHistoryFile.HistoryFileLocation = fileChild.InnerText;

                        }
                        else if (fileChild.Name == "Name")
                        {
                            FModifyHistoryFile.HistoryFileName = fileChild.InnerText;
                        }
                        else if (fileChild.Name == "Status")
                        {
                            FModifyHistoryFile.HistoryStatus = fileChild.InnerText;
                        }
                        else if (fileChild.Name == "History")
                        {
                            ModifyHistory FModifyHistory = new ModifyHistory();
                            FModifyHistory.HistoryRevision = fileChild.SelectSingleNode("Revision").InnerText;
                            FModifyHistory.HistoryAuthor = fileChild.SelectSingleNode("Author").InnerText;
                            FModifyHistory.HistoryDate = fileChild.SelectSingleNode("Date").InnerText;
                            FModifyHistory.HistoryComment = fileChild.SelectSingleNode("Comment").InnerText;
                            FModifyHistoryFile.Historys.Add(FModifyHistory);
                        }
                    }
                    //FModifyHistoryFile.HistoryFileLocation = FL.SelectSingleNode("Location").InnerText;
                    //FModifyHistoryFile.HistoryFileName = FL.SelectSingleNode("Name").InnerText;
                    //FModifyHistoryFile.HistoryStatus = FL.SelectSingleNode("Status").InnerText;
                    //XmlNode history = FL.SelectSingleNode("History");
                    //FModifyHistoryFile.Historys = new List<ModifyHistory>();
                    //foreach (XmlNode HT in history.ChildNodes)
                    //{
                    //    ModifyHistory FModifyHistory = new ModifyHistory();
                    //    FModifyHistory.HistoryRevision = HT.SelectSingleNode("Revision").Value;
                    //    FModifyHistory.HistoryAuthor = HT.SelectSingleNode("Author").InnerText;
                    //    FModifyHistory.HistoryDate = HT.SelectSingleNode("Date").InnerText;
                    //    FModifyHistory.HistoryComment = HT.SelectSingleNode("Comment").InnerText;
                    //    FModifyHistoryFile.Historys.Add(FModifyHistory);
                    //}
                    lsModifyHistoryFile.Add(FModifyHistoryFile);
                }
            }
            return lsModifyHistoryFile;

        }

        //private object GenerateHistoryFileTable(List<ModifyHistoryFile> aFile)
        //{
        //    string strHistoryFile = "";

        //    string strLocation = "";
        //    string strName = "";
        //    string strStatus = "";
        //    string strRevision = "";
        //    string strAuthor = "";
        //    string strDate = "";
        //    string strComment = "";
        //    int intHistoryCount = 0;
        //    string strHistoryHTML = "";
        //    int j = 1;
        //    int l = 0;
        //    StringBuilder sbTableContent = new StringBuilder();
        //    //StringBuilder sbTableContent1 = new StringBuilder();
        //    Dictionary<string, int> LocationCounter = new Dictionary<string, int>();
        //    foreach (ModifyHistoryFile FileList in aFile)
        //    {
        //        if (LocationCounter.ContainsKey(FileList.HistoryFileLocation))
        //        {
        //            LocationCounter[FileList.HistoryFileLocation] += 1;
        //        }
        //        else
        //        {
        //            LocationCounter[FileList.HistoryFileLocation] = 1;
        //        }

        //    }
        //    for (int k = 0; k < aFile.Count; k++)
        //    {
        //        strLocation = aFile[k].HistoryFileLocation;
        //        strName = aFile[k].HistoryFileName;
        //        strStatus = aFile[k].HistoryStatus;
        //        if (aFile[k].Historys != null && aFile[k].Historys.Count > 0)
        //        {
        //            intHistoryCount = aFile[k].Historys.Count;
        //            for (int i = 0; i < aFile[k].Historys.Count; i++)
        //            {
        //                strRevision = aFile[k].Historys[i].HistoryRevision;
        //                strAuthor = aFile[k].Historys[i].HistoryAuthor;
        //                strDate = aFile[k].Historys[i].HistoryDate;
        //                strComment = aFile[k].Historys[i].HistoryComment;

        //                if (k == 0 || (aFile[k].HistoryFileLocation != aFile[k - 1].HistoryFileLocation && i == 0))
        //                {
        //                    if (i == 0)
        //                    {
        //                        sbTableContent.Append(string.Format(WindowsFormsApplication3.Properties.Resources.ReportHistoryFileContent, strLocation, strName, strStatus, strRevision, strAuthor, strComment, strDate, LocationCounter[strLocation]));
        //                    }
        //                    else
        //                    {
        //                        sbTableContent.Append(string.Format(WindowsFormsApplication3.Properties.Resources.ReportHistoryContent, strRevision, strAuthor, strComment, strDate));
        //                    }
        //                }
        //                else
        //                {
        //                    if (i == 0)
        //                    {
        //                        sbTableContent.Append(string.Format(WindowsFormsApplication3.Properties.Resources.FirstRowMerge, strName, strStatus, strRevision, strAuthor, strComment, strDate, intHistoryCount));
        //                    }
        //                    else
        //                    {
        //                        sbTableContent.Append(string.Format(WindowsFormsApplication3.Properties.Resources.ReportHistoryContent, strRevision, strAuthor, strComment, strDate));
        //                    }
        //                }

        //            }
        //        }


        //    }
        //    string historyHTML1 = string.Format(WindowsFormsApplication3.Properties.Resources.ReportHistoryFileColumnHeader, sbTableContent.ToString());
        //    return historyHTML1;
        //}



        #region Format FileModifiedHistory To HTML

        private string GenerateHistoryFileTable(List<ModifyHistoryFile> aFile)
        {
            try
            {

                List<HistoryRow> HistoryRowList = new List<HistoryRow>();

                //Step 1: conver to each HTML Row
                foreach (ModifyHistoryFile historyFile in aFile)
                {
                    if (historyFile.Historys != null)
                    {
                        for (int i = 0; i < historyFile.Historys.Count; i++)
                        {
                            ModifyHistory history = historyFile.Historys[i];

                            HistoryRow row = new HistoryRow();
                            HistoryColumn colLocation = new HistoryColumn(HistoryColumnType.FileLocation);
                            HistoryColumn colName = new HistoryColumn(HistoryColumnType.FileName);
                            HistoryColumn colStatus = new HistoryColumn(HistoryColumnType.Status);
                            HistoryColumn colRevision = new HistoryColumn(HistoryColumnType.Revision);
                            HistoryColumn colAuthor = new HistoryColumn(HistoryColumnType.Author);
                            HistoryColumn colComment = new HistoryColumn(HistoryColumnType.Comment);
                            HistoryColumn colDate = new HistoryColumn(HistoryColumnType.Date);

                            colLocation.Content = historyFile.HistoryFileLocation;
                            colName.Content = historyFile.HistoryFileName;
                            colStatus.Content = historyFile.HistoryStatus;
                            colRevision.Content = history.HistoryRevision;
                            colAuthor.Content = history.HistoryAuthor;
                            colComment.Content = history.HistoryComment;
                            colDate.Content = history.HistoryDate;
                            row.Columns = new List<HistoryColumn>();
                            row.Columns.AddRange
                                (
                                    new HistoryColumn[]
                                    {
                                        colLocation,
                                        colName,
                                        colStatus,
                                        colRevision,
                                        colAuthor,
                                        colComment,
                                        colDate
                                    }
                                );
                            HistoryRowList.Add(row);
                        }

                    }
                }

                //Step 2: merge Location row
                MergeHistoryRow(HistoryRowList, HistoryColumnType.FileLocation, new List<HistoryColumnType>() { HistoryColumnType.FileLocation });

                
                //Step 3: merge File and Status row
                MergeHistoryRow(HistoryRowList, HistoryColumnType.FileName, new List<HistoryColumnType>() { HistoryColumnType.FileName, HistoryColumnType.Status });

                StringBuilder sbTableContent = new StringBuilder();
                foreach (HistoryRow row in HistoryRowList)
                {
                    if (sbTableContent.Length != 0)
                    {
                        sbTableContent.Append(Environment.NewLine);
                    }
                    sbTableContent.Append(row.ToHTMLString());
                }

                string historyHTML1 = string.Format(Resources.ReportHistoryFileColumnHeader, sbTableContent.ToString());
                return historyHTML1;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private void MergeHistoryRow(List<HistoryRow> aHistoryRowList, HistoryColumnType aIndicateColumnType, List<HistoryColumnType> aMergeColumnList)
        {
            if (aHistoryRowList != null && aHistoryRowList.Count > 0 && aMergeColumnList != null && aMergeColumnList.Count > 0)
            {
                int index = 0;
                while (index < aHistoryRowList.Count - 1)
                {
                    HistoryRow row = aHistoryRowList[index];
                    int rowspan = 1;
                    for (int j = index + 1; j < aHistoryRowList.Count; j++)
                    {
                        index = j;
                        if (aHistoryRowList[j].HasColumn(aIndicateColumnType, row.GetColumnContent(aIndicateColumnType)))
                        {
                            rowspan++;
                            foreach (HistoryColumnType colType in aMergeColumnList)
                            {
                                aHistoryRowList[j].RemoveColumn(colType);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    foreach (HistoryColumnType colType in aMergeColumnList)
                    {
                        row.UpdateRowspan(colType, rowspan);
                    }

                }
            }
        }


        private class HistoryRow : IHTMLFormat
        {
            public List<HistoryColumn> Columns { get; set; }
            public string GetColumnContent(HistoryColumnType aColumnType)
            {
                if (Columns != null && Columns.Count > 0)
                {
                    foreach (HistoryColumn col in Columns)
                    {
                        if (col.ColumnType == aColumnType)
                        {
                            return col.Content;
                        }
                    }
                }
                return string.Empty;
            }

            public bool HasColumn(HistoryColumnType aColumnType, string aContent)
            {
                return aContent.Equals(GetColumnContent(aColumnType));
            }

            public void RemoveColumn(HistoryColumnType aColumnType)
            {
                for (int i = Columns.Count -1; i >= 0; i--)
                {
                    if (Columns[i].ColumnType == aColumnType)
                    {
                        Columns.RemoveAt(i);
                        break;
                    }
                }

            }

            public void UpdateRowspan(HistoryColumnType aColumnType, int aRowspan)
            {
                for (int i = 0; i < Columns.Count; i++)
                {
                    if (Columns[i].ColumnType == aColumnType)
                    {
                        Columns[i].Rowspan = aRowspan;
                    }
                }

            }

            //********************************************
            //<tr>
            //<td width="39%" rowspan = "4">W:\Common\Common Source\Delphi 2009\Tuning_COM\CommObj\</td>
            //<td width="15%">BaseParam.pas</td>
            //<td width="8%">Modified</td>
            //<td width="1%">241</td>
            //<td width="7%">Frank Li</td>
            //<td width="17%">For QSOSS actual plan</td>
            //<td width="13%">8/5/13 4:18:13 PM </td>
            //</tr>
            //********************************************
            public string ToHTMLString()
            {
                StringBuilder sbResult = new StringBuilder();
                sbResult.Append("<tr>");
                if (Columns != null && Columns.Count > 0 )
                {
                    foreach (HistoryColumn col in Columns)
                    {
                        sbResult.Append(Environment.NewLine);
                        sbResult.Append(col.ToHTMLString());
                    }
                }
                sbResult.Append(Environment.NewLine);
                sbResult.Append("</tr>");
                return sbResult.ToString();

            }
        }

        
        private class HistoryColumn : IHTMLFormat
        {
            #region Field
            public string Header
            {
                get
                {
                    return ColumnType.ToString();
                }
            }

            private string FWidth = "10%";
            public string Width
            {
                get
                {
                    return FWidth;
                }
                set
                {
                    if (FWidth != value)
                    {
                        FWidth = value;
                    }
                }
            }

            private int FRowspan = 1;
            public int Rowspan
            {
                get
                {
                    return FRowspan;
                }
                set
                {
                    if (FRowspan != value)
                    {
                        FRowspan = value;
                    }
                }
            }
            private string FContent = string.Empty;
            public string Content
            {
                get
                {
                    return FContent;
                }
                set
                {
                    if (FContent != value)
                    {
                        FContent = value;
                    }
                }
            }
            private HistoryColumnType FColumnType = HistoryColumnType.None;

            public HistoryColumnType ColumnType
            {
                get { return FColumnType; }
                set
                {
                    if (FColumnType != value)
                    {
                        FColumnType = value;
                    }

                }
            }
            #endregion Field

            #region Constructor & Destroyer

            public HistoryColumn() { }
            public HistoryColumn(HistoryColumnType aColumnType)
            {
                ColumnType = aColumnType;
                Width = GetColumnWidth(aColumnType);
            }

            #endregion Constructor & Destroyer

            #region Public Section

            public string GetColumnWidth(HistoryColumnType aColumnType)
            {
                string result = "10%";
                switch (aColumnType)
                {
                    case HistoryColumnType.None:
                        break;
                    case HistoryColumnType.FileLocation:
                        result = "39%";
                        break;
                    case HistoryColumnType.FileName:
                        result = "15%";
                        break;
                    case HistoryColumnType.Status:
                        result = "8%";
                        break;
                    case HistoryColumnType.Revision:
                        result = "1%";
                        break;
                    case HistoryColumnType.Author:
                        result = "7%";
                        break;
                    case HistoryColumnType.Comment:
                        result = "17%";
                        break;
                    case HistoryColumnType.Date:
                        result = "13%";
                        break;
                    default:
                        break;
                }
                return result;
            }

            /// <summary>
            /// <td width="39%" rowspan = "4">W:\Common\Common Source\Delphi 2009\Tuning_COM\CommObj\</td>
            /// </summary>
            /// <returns></returns>
            public string ToHTMLString()
            {
                StringBuilder sbResult = new StringBuilder();
                sbResult.Append("<td");
                if (string.IsNullOrEmpty(Width) == false)
                {
                    sbResult.Append(string.Format(" width = \"{0}\"", Width));
                }
                sbResult.Append(string.Format(" rowspan = \"{0}\"", Rowspan));
                sbResult.Append(string.Format(">{0}</td>", Content));
                return sbResult.ToString();
            }


            #endregion Public Section

        }

        interface IHTMLFormat
        {
            string ToHTMLString();
        }

        enum HistoryColumnType
        {
            None,
            FileLocation,
            FileName,
            Status,
            Revision,
            Author,
            Comment,
            Date,
        }

        #endregion Format FileModifiedHistory To HTML

    }
}
