using CompileCondition.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace CompileCondition
{
    public class XMLHelper
    {
        public static readonly string Z_Product = "Product";
        public static readonly string Z_Name = "Name";
        public static readonly string Z_Production = "Production";
        public static readonly string Z_Trial = "Trial";
        public static readonly string Z_Beta = "Beta";
        public static readonly string Z_BuildDelphi = "BuildDelphi";
        public static readonly string Z_BuildCSharp = "BuildCSharp";
        public static readonly string Z_Projects = "Projects";
        public static readonly string Z_Project = "Project";
        public static readonly string Z_SourceRoot = "SourceRoot";
        public static readonly string Z_CompileCond = "CompileCond";
        public static readonly string Z_DefConstants = "DefConstants";

        public static readonly string Z_CSharpProjIDPref = "CSharpProj_";
        public static readonly string Z_CSharpProjExtension = ".csproj";
        public static readonly string Z_DelphiProjIDPref = "DelphiProj_";
        public static readonly string Z_DelphiProjExtension = ".dproj";

        public static readonly string Z_ItemGroup = "ItemGroup";
        public static readonly string Z_PropertyGroup = "PropertyGroup";
        public static readonly string Z_C_Condition_Format = "'$(Configuration)|$(Platform)' == '{0}'"; //'$(Configuration)|$(Platform)' == 'Beta|x86'
        public static readonly string Z_D_Condition_Format = "'$({0})'!=''"; //'$(Cfg_2_Win64)'!=''
        public static readonly string Z_D_Condition_End = ";$(DCC_Define)";
        public static readonly string Z_Condition = "Condition";
        public static readonly string Z_DefineConstants = "DefineConstants";
        public static readonly string Z_DCC_Define = "DCC_Define";
        public static readonly string Z_BuildConfiguration = "BuildConfiguration";
        public static readonly string Z_Include = "Include";
        public static readonly string Z_Key = "Key";
        public static readonly string Z_VerInfo_MajorVer = "VerInfo_MajorVer";
        public static readonly string Z_VerInfo_MinorVer = "VerInfo_MinorVer";
        public static readonly string Z_VerInfo_Release = "VerInfo_Release";
        public static readonly string Z_VerInfo_Build = "VerInfo_Build";
        public static readonly string Z_VerInfo_Keys = "VerInfo_Keys";

        private static readonly XMLHelper FInstance = new XMLHelper();

        public static XMLHelper Instance
        {
            get { return FInstance; }
        }       

        private XMLHelper() { }

        static XMLHelper()
        {

        }

        #region Load

        public List<Product> LoadProducts(string aXML)
        {
            List<Product> result = null;
            using (StringReader sr = new StringReader(aXML))
            {
                using (XmlReader reader = XmlReader.Create(sr, XMLOperation.ReaderSettings))
                {
                    if (XMLOperation.gotoNode(reader, Z_Product))
                    {
                        reader.Read();
                        result = new List<Product>();
                        do
                        {
                            reader.MoveToContent();

                            if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Z_Product)
                            {
                                return result;
                            }

                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                Product product;
                                Read(reader, out product);
                                result.Add(product);
                            }


                        } while (reader.Read());
                    }
                    else
                    {
                        result = null;
                    }
                }
            }

            return result;
        }

        private static void Read(XmlReader reader, out Product product)
        {
            product = null;
            if (reader.NodeType == XmlNodeType.Element)
            {
                string nodeName = reader.Name;

                product = new Product();
                string name = reader.GetAttribute(Z_Name);
                if (string.IsNullOrWhiteSpace(name) == false)
                {
                    product.Name = name;
                }

                List<Edition> editionList = new List<Edition>();
                List<Project> allProjectList = new List<Project>();

                do
                {
                    reader.MoveToContent();

                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == nodeName)
                    {
                        break;
                    }

                    if (reader.NodeType == XmlNodeType.Element && IsEditionNode(reader.Name))
                    {
                        Edition edition = null;
                        List<Project> projectList = new List<Project>();
                        Read(reader, out edition, out projectList);
                        if (edition != null && editionList.Contains(edition) == false)
                        {
                            editionList.Add(edition);
                        }
                        if (projectList.HasElement())
                        {
                            foreach (Project proj in projectList)
                            {
                                if (allProjectList.Contains(proj) == false)
                                {
                                    allProjectList.Add(proj);
                                }
                            }
                        }
                    }


                } while (reader.Read());

                if (editionList.HasElement())
                {
                    product.EditionList = new List<Edition>(editionList);
                }
                if (allProjectList.HasElement())
                {
                    product.ProjectList = new List<Project>(allProjectList);
                }
            }

        }

        private static void Read(XmlReader reader, out Edition aEdition, out List<Project> aProjectList)
        {
            aEdition = null;
            aProjectList = null;

            if (reader.NodeType == XmlNodeType.Element)
            {
                aEdition = new Edition();
                aProjectList = new List<Project>();
                aEdition.Name = reader.Name;
                aEdition.ProjectList = new List<string>();
                do
                {
                    reader.MoveToContent();
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == aEdition.Name)
                    {
                        return;
                    }

                    if (reader.NodeType == XmlNodeType.Element && IsBuildDelphiProject(reader.Name))
                    {
                        List<DelphiProject> delphiProjects = null;
                        Read(reader, out delphiProjects);
                        if (delphiProjects.HasElement())
                        {
                            aProjectList.AddRange(delphiProjects);
                            foreach (Project proj in delphiProjects)
                            {
                                if (aEdition.ProjectList.Contains(proj.ID) == false)
                                {
                                    aEdition.ProjectList.Add(proj.ID);
                                }
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Element && IsBuildCSharpProject(reader.Name))
                    {
                        List<CSharpProject> cProjectList = null;
                        Read(reader, out cProjectList);
                        if (cProjectList.HasElement())
                        {
                            aProjectList.AddRange(cProjectList);
                            foreach (Project proj in cProjectList)
                            {
                                if (aEdition.ProjectList.Contains(proj.ID) == false)
                                {
                                    aEdition.ProjectList.Add(proj.ID);
                                }
                            }
                        }
                    }
                } while (reader.Read());
            }
        }

        private static bool IsEditionNode(string aNodeName)
        {
            return aNodeName.StartsWith(Z_Production) || aNodeName.StartsWith(Z_Trial) || aNodeName.StartsWith(Z_Beta);
        }

        private static bool IsBuildDelphiProject(string aNodeName)
        {
            return aNodeName.Equals(Z_BuildDelphi);
        }

        private static bool IsBuildCSharpProject(string aNodeName)
        {
            return aNodeName.Equals(Z_BuildCSharp);
        }

        private static void Read(XmlReader reader, out List<DelphiProject> aProjectList)
        {
            aProjectList = null;
            if (XMLOperation.gotoNode(reader, Z_Projects))
            {
                aProjectList = new List<DelphiProject>();
                do
                {
                    reader.MoveToContent();

                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Z_Projects)
                    {
                        return;
                    }

                    if (reader.Name == Z_Project)
                    {
                        DelphiProject proj = null;
                        Read(reader, out proj);
                        if (proj != null)
                        {
                            aProjectList.Add(proj);
                        }
                    }
                } while (reader.Read());
            }
        }

        private static void Read(XmlReader reader, out DelphiProject aProject)
        {
            aProject = null;
            if (XMLOperation.gotoNode(reader, Z_Project))
            {
                string name = reader.GetAttribute(Z_Name);
                if (string.IsNullOrWhiteSpace(name))
                {
                    return;
                }
                string id = Z_DelphiProjIDPref + name;
                aProject = new DelphiProject(id);
                aProject.Name = name + Z_DelphiProjExtension;
                do
                {
                    reader.MoveToContent();

                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Z_Project)
                    {
                        return;
                    }

                    if (reader.Name == Z_SourceRoot)
                    {
                        aProject.Location = XMLOperation.readNodeValue(reader);
                    }
                    else if (reader.Name == Z_CompileCond)
                    {
                        aProject.Condition = XMLOperation.readNodeValue(reader);
                    }

                } while (reader.Read());

            }
        }

        private static void Read(XmlReader reader, out List<CSharpProject> aProjectList)
        {
            aProjectList = null;
            if (XMLOperation.gotoNode(reader, Z_Projects))
            {
                aProjectList = new List<CSharpProject>();
                do
                {
                    reader.MoveToContent();

                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Z_Projects)
                    {
                        return;
                    }

                    if (reader.Name == Z_Project)
                    {
                        CSharpProject proj = null;
                        Read(reader, out proj);
                        if (proj != null)
                        {
                            aProjectList.Add(proj);
                        }
                    }
                } while (reader.Read());
            }
        }

        private static void Read(XmlReader reader, out CSharpProject aProject)
        {
            aProject = null;
            if (XMLOperation.gotoNode(reader, Z_Project))
            {
                string name = reader.GetAttribute(Z_Name);
                if (string.IsNullOrWhiteSpace(name))
                {
                    return;
                }
                string id = Z_CSharpProjIDPref + name;
                aProject = new CSharpProject(id);
                aProject.Name = name + Z_CSharpProjExtension;
                do
                {

                    reader.MoveToContent();

                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Z_Project)
                    {
                        return;
                    }

                    if (reader.Name == Z_SourceRoot)
                    {
                        aProject.Location = XMLOperation.readNodeValue(reader);
                    }
                    else if (reader.Name == Z_DefConstants)
                    {
                        aProject.Condition = XMLOperation.readNodeValue(reader);
                    }

                } while (reader.Read());

            }
        }

        #endregion Load

        #region SaveToLocal

        public void UpdateCSharpProjCondition(string aProjFile, string aConditionContent, string aEditionStr)
        {
            if (File.Exists(aProjFile) == false)
            {
                return;
            }

            string edition = string.Format(Z_C_Condition_Format, aEditionStr);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aProjFile);
            XmlElement root = xmlDoc.DocumentElement;
            //for loop PropertyGroup
            foreach (XmlNode node in root.ChildNodes)
            {
                XmlElement element = node as XmlElement;
                if (element != null && element.Name == Z_PropertyGroup && element.GetAttribute(Z_Condition) == edition)
                {
                    foreach (XmlNode nodeGroupDetail in element.ChildNodes)
                    {
                        XmlElement elementGroupDetail = (XmlElement)nodeGroupDetail;
                        if (elementGroupDetail.Name == Z_DefineConstants)
                        {
                            elementGroupDetail.InnerText = aConditionContent;
                        }
                    }
                    break;
                }
            }
            xmlDoc.Save(aProjFile);
        }

        private bool TrySelectSingleNode(XmlNodeList aChildNodes, string aName, out XmlNode aNode)
        {
            aNode = null;
            foreach (XmlNode item in aChildNodes)
            {
                XmlElement element = item as XmlElement;
                if (element.Name == aName)
                {
                    aNode = item;
                    return true;
                }
            }

            return false;
        }

        public void UpdateDelphiProjCondition(string aProjFile, string aConditionContent, string aEditionStr)
        {
            string configKey = null;

            if (File.Exists(aProjFile) == false)
            {
                return;
            }

            string config = aEditionStr.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[0];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aProjFile);
            XmlElement root = xmlDoc.DocumentElement;
            
            //Get configuration key
            XmlNode nodeItemGroup;
            if (TrySelectSingleNode(root.ChildNodes, Z_ItemGroup, out nodeItemGroup))
            {
                foreach (XmlNode node in nodeItemGroup.ChildNodes)
                {
                    XmlElement element = node as XmlElement;
                    if (element.Name == Z_BuildConfiguration && element.GetAttribute(Z_Include) == config)
                    {
                        XmlNode nodeKey;
                        if (TrySelectSingleNode(node.ChildNodes, Z_Key, out nodeKey))
                        {
                            XmlElement elementKey = nodeKey as XmlElement;
                            configKey = elementKey.InnerText;
                        } 
                        break;
                    }
                }
            }            

            if (configKey != null)
            {
                string strDelphiEdition = aEditionStr.Replace(config, configKey).Replace("|x", "_Win").Replace("86", "32");
                strDelphiEdition = string.Format(Z_D_Condition_Format, strDelphiEdition);

                //for loop PropertyGroup
                foreach (XmlNode node in root.ChildNodes)
                {
                    XmlElement element = node as XmlElement;
                    if (element != null && element.Name == Z_PropertyGroup && element.GetAttribute(Z_Condition) == strDelphiEdition)
                    {
                        XmlNode dccNode = null;
                        XmlElement elementDCC = null;

                        if (TrySelectSingleNode(element.ChildNodes, Z_DCC_Define, out dccNode))
                        {
                            elementDCC = dccNode as XmlElement;
                        }
                        else
                        {
                            //Create a new node.
                            elementDCC = xmlDoc.CreateElement(Z_DCC_Define);
                            node.AppendChild(elementDCC);
                        }
                        if (elementDCC.Name == Z_DCC_Define)
                        {
                            elementDCC.InnerText = aConditionContent + Z_D_Condition_End;
                        }
                        break;
                    }
                }
            }           
            xmlDoc.Save(aProjFile);
        }


        #endregion SaveToLocal
    }
}
