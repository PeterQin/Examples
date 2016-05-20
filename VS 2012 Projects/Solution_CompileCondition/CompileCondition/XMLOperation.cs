using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CompileCondition
{
    public static class XMLOperation
    {
        public const string XMLNode_Error = "!E";

        public static XmlReaderSettings ReaderSettings = new XmlReaderSettings();

        static XMLOperation()
        {
            ReaderSettings.NameTable = ReaderSettings.NameTable ?? new NameTable();
            ReaderSettings.CheckCharacters = false;
        }

        /// <summary>
        /// Locate the first matched Node, Forward only
        /// </summary>
        /// <param name="aReader">the reader contains the XML</param>
        /// <param name="NodeName">the node name to be searched</param>
        /// <returns></returns>
        /// <remarks>
        /// Tony Li 04.04.2006 - Initial
        /// </remarks>
        public static bool gotoNode(XmlReader aReader, string NodeName)
        {
            do
            {
                aReader.MoveToContent();
                if ((aReader.NodeType == XmlNodeType.Element) && (aReader.Name == NodeName)) { return true; }
            } while (aReader.Read());
            return false;
        }

        /// <summary>
        /// Read the node value if the CData is found, it would be htmlDecoded
        /// </summary>
        /// <param name="aReader">the XML reader contains node</param>
        /// <returns></returns>
        public static string readNodeValue(XmlReader aReader)
        {
            string _Result;
            _Result = "";
            if (aReader.IsEmptyElement == false)
            {
                do
                {
                    if (aReader.NodeType == XmlNodeType.Text) { _Result = aReader.ReadContentAsString(); }
                    //if (aReader.NodeType == XmlNodeType.CDATA) { _Result = System.Web.HttpUtility.HtmlDecode(aReader.ReadContentAsString()); }

                    //ReadContentAsString will return end LF and CR character if the XML Node includes LF and CR character.
                    //For example.
                    //      XML:
                    //          <SQLText>\r\n<![CDATA[select * from department where a = b]]>\r\n</SQLText>
                    //      Result:
                    //          select * from department where a = b\r\n
                    //      Expect Result:
                    //          select * from department where a = b
                    if (aReader.NodeType == XmlNodeType.CDATA) { _Result = System.Net.WebUtility.HtmlDecode(aReader.Value); }
                    //According to XML Spec - http://www.dotnet247.com/247reference/a.aspx?u=http://www.w3.org/TR/2004/REC-xml-20040204/#sec-line-ends
                    //#13#10 is not valid to XML, it should be normalize to Single #10
                    //So this is why it replaced with #13#10
                    _Result = _Result.Replace("\r\n", "\n");
                    _Result = _Result.Replace("\n", "\r\n");
                    // Oliver Lee, 15 Sep 06, for error message, it will use !E as newline charactor.
                    // !E charactor is used between lab engine and the lab. We share the error message method with lab engine.
                    // Thus, for error message, the newline charactor is "!E"
                    _Result = _Result.Replace(XMLNode_Error, "\r\n");

                    if (aReader.NodeType == XmlNodeType.EndElement) { break; }
                } while (aReader.Read());
            }
            return _Result;
        }
    }
}
