using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Web;

namespace Quest.Tuning.FileTransferCommon
{
    public static class TXMLOperator
    {
        public static XmlWriterSettings InterWriteSettings
        {
            get
            {
                XmlWriterSettings _Settings = new XmlWriterSettings();
                _Settings.Encoding = Encoding.Unicode;
                _Settings.OmitXmlDeclaration = true;
                return _Settings;
            }
        }
    }

    public class TaskXMLOperator
    {
        private const string C_XML_Tasks = "Tasks";
        private const string C_XML_Task = "Task";
        private const string C_XML_Type = "Type";
        private const string C_XML_Source = "Source";
        private const string C_XML_Destination = "Destination";
        public const string C_XML_Result = "Result";

        public static List<TaskInfo> TaskFromXML(string aTaskXML)
        {
            List<TaskInfo> Result = new List<TaskInfo>();
            if (string.IsNullOrEmpty(aTaskXML) == false)
            {
                using (StringReader sr = new StringReader(aTaskXML))
                {
                    using (XmlReader Reader = XmlReader.Create(sr))
                    {
                        TaskReader(Reader, ref Result);
                    }
                }
            }
            return Result;
        }

        public static void TaskReader(XmlReader aReader, ref List<TaskInfo> aTaskList)
        {
            aReader.Read();
            aReader.MoveToContent();
            while (aReader.Read())
            {
                aReader.MoveToContent();
                if (aReader.Name.Equals(C_XML_Tasks) && aReader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }

                if (aReader.IsStartElement(C_XML_Task))
                {
                    TaskInfo task = new TaskInfo();
                  

                    if (aReader.MoveToAttribute(C_XML_Type))
                    {
                        TaskType type = Util.StringToEnum<TaskType>(aReader.Value);
                        task.CurrentType = type;
                    }

                    ReadTaskInfo(aReader, ref task);
                    aTaskList.Add(task);
                }

            }
        }

        private static void ReadTaskInfo(XmlReader aReader, ref TaskInfo aTask)
        {
            string VMFile = string.Empty;
            aReader.MoveToContent();
            while (aReader.Read())
            {
                aReader.MoveToContent();
                if (aReader.NodeType == XmlNodeType.EndElement && aReader.Name.Equals(C_XML_Task))
                {
                    break;
                }
                if (aReader.IsStartElement(C_XML_Source))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.Source = HttpUtility.HtmlDecode(aReader.Value);
                    }

                }
                else if (aReader.IsStartElement(C_XML_Destination))
                {
                    aReader.Read();
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.Destination = HttpUtility.HtmlDecode(aReader.Value);
                    }

                }
                else if (aReader.IsStartElement(C_XML_Result))
                {
                    aReader.Read();
                    aTask.Result = new TaskResult();
                    if (aReader.MoveToAttribute(C_XML_Type))
                    {
                        aTask.Result.ResultType = Util.StringToEnum<ResultType>(aReader.Value);
                    }
                    if (aReader.MoveToContent() == XmlNodeType.CDATA)
                    {
                        aTask.Result.ResultMessage = HttpUtility.HtmlDecode(aReader.Value);
                    }
                }
                
            }
        }

        public static string TaskToXML(List<TaskInfo> aListTask)
        {
            StringBuilder sbResult = new StringBuilder();
            if (aListTask.Count > 0)
            {
                using (XmlWriter _Writer = XmlWriter.Create(sbResult, TXMLOperator.InterWriteSettings))
                {
                    _Writer.WriteStartDocument();
                    _Writer.WriteStartElement(C_XML_Tasks);

                    foreach (TaskInfo task in aListTask)
                    {
                        _Writer.WriteRaw(TaskToXML(task));
                    }

                    _Writer.WriteEndElement();  //end of C_XML_Tasks
                    _Writer.WriteEndDocument();
                    _Writer.Close();
                }
            }
            return sbResult.ToString();
        }

        private static string TaskToXML(TaskInfo aTask)
        {
            StringBuilder sbResult = new StringBuilder();
            using (XmlWriter _Writer = XmlWriter.Create(sbResult, TXMLOperator.InterWriteSettings))
            {
                _Writer.WriteStartDocument();
                _Writer.WriteStartElement(C_XML_Task);
                _Writer.WriteAttributeString(C_XML_Type, aTask.CurrentType.ToString());

                _Writer.WriteStartElement(C_XML_Source);
                _Writer.WriteCData(HttpUtility.HtmlEncode(aTask.Source));
                _Writer.WriteEndElement();//end of C_XML_Source

                _Writer.WriteStartElement(C_XML_Destination);
                _Writer.WriteCData(HttpUtility.HtmlEncode(aTask.Destination));
                _Writer.WriteEndElement();//end of C_XML_Destination

                if (aTask.Result != null)
                {
                    _Writer.WriteStartElement(C_XML_Result);
                    _Writer.WriteAttributeString(C_XML_Type, aTask.Result.ResultType.ToString());
                    _Writer.WriteCData(HttpUtility.HtmlEncode(aTask.Result.ResultMessage));
                    _Writer.WriteEndElement();//end of C_XML_VMFile
                }
                
                _Writer.WriteEndElement();//end of C_XML_Task
                _Writer.WriteEndDocument();
                _Writer.Close();
            }
            return sbResult.ToString();
        }

    }
}
