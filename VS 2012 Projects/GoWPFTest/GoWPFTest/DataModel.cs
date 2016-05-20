using Northwoods.GoXam;
using Northwoods.GoXam.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GoWPFTest
{
    // add some properties for each node data
    [Serializable]
    public class SimpleData : GraphLinksModelNodeData<String>
    {

        private const string C_Prop_CanExpanded = "CanExpanded";
        private bool FCanExpanded = true;

        public bool CanExpanded
        {
            get { return FCanExpanded; }
            set
            {
                if (FCanExpanded != value)
                {
                    bool old = FCanExpanded;
                    FCanExpanded = value;
                    RaisePropertyChanged(C_Prop_CanExpanded, old, value);
                }
            }
        }


        private const string C_Prop_Cost = "Cost";
        private string FCost = "0 %";

        public string Cost
        {
            get { return FCost; }
            set
            {
                if (FCost != value)
                {
                    string old = FCost;
                    FCost = value;
                    RaisePropertyChanged(C_Prop_Cost, old, value);
                }
            }
        }        

        #region IsAnimation
        private bool FIsAnimaiton=true;
        private const string C_Prop_IsAnimation = "IsAnimation";
        public bool IsAnimation
        {
            get { return FIsAnimaiton; }
            set
            {
                if (FIsAnimaiton != value)
                {
                    bool old = FIsAnimaiton;
                    FIsAnimaiton = value;
                    RaisePropertyChanged(C_Prop_IsAnimation, old, value);
                }
            }
        }
        
        #endregion
	
        private const string C_Prop_Operation = "Operation";
        private string FOperation;

        public string Operation
        {
            get { return FOperation; }
            set
            {
                if (FOperation != value)
                {
                    string old = FOperation;
                    FOperation = value;
                    RaisePropertyChanged(C_Prop_Operation, old, value);
                }
            }
        }

        private const string C_Prop_OperationData = "OperationData";
        private string FOperationData;

        public string OperationData
        {
            get { return FOperationData; }
            set
            {
                if (FOperationData != value)
                {
                    string old = FOperationData;
                    FOperationData = value;
                    RaisePropertyChanged(C_Prop_OperationData, old, value);
                }
            }
        }

        
        private const string C_Prop_Columns = "Columns";
        [XmlIgnore]
        [NonSerialized]
        private List<Column> FColumns;

        public List<Column> Columns
        {
            get { return FColumns; }
            set
            {
                if (FColumns != value)
                {
                    List<Column> old = FColumns;
                    FColumns = value;
                    RaisePropertyChanged(C_Prop_Columns, old, FColumns);
                }
            }
        }


        private const string C_Prop_Rows = "Rows";
        private int FRows;

        public int Rows
        {
            get { return FRows; }
            set
            {
                if (FRows != value)
                {
                    int old = FRows;
                    FRows = value;
                    RaisePropertyChanged(C_Prop_Rows, old, value);
                }
            }
        }
	
        private const string C_Prop_CostColor = "CostColor";
        private string FCostColor = "Transparent";

        public string CostColor
        {
            get { return FCostColor; }
            set
            {
                if (FCostColor != value)
                {
                    string old = FCostColor;
                    FCostColor = value;
                    RaisePropertyChanged(C_Prop_CostColor, old, value);
                }
            }
        }

        private const string C_Prop_OperationColor = "OperationColor";
        private string FOperationColor = "Transparent";

        public string OperationColor
        {
            get { return FOperationColor; }
            set
            {
                if (FOperationColor != value)
                {
                    string old = FOperationColor;
                    FOperationColor = value;
                    RaisePropertyChanged(C_Prop_OperationColor, old, value);
                }
            }
        }

        private const string C_Prop_ImageSource = "ImageSource";

        [XmlIgnore]
        [NonSerialized]
        private BitmapSource FImageSource;

        public BitmapSource ImageSource
        {
            get { return FImageSource; }
            set
            {
                if (FImageSource != value)
                {
                    BitmapSource old = FImageSource;
                    FImageSource = value;
                    RaisePropertyChanged(C_Prop_ImageSource, old, value);
                }
            }
        }

        private const string C_Prop_ImageName = "ImageName";
        private string FImageName;

        public string ImageName
        {
            get { return FImageName; }
            set
            {
                if (FImageName != value)
                {
                    string old = FImageName;
                    FImageName = value;
                    RaisePropertyChanged(C_Prop_ImageName, old , value);
                }
            }
        }



        private const string C_Prop_AllowImageBorder = "AllowAnimateBorder";
        private bool FAllowImageBorder = false;

        public bool AllowImageBorder
        {
            get { return FAllowImageBorder; }
            set
            {
                if (FAllowImageBorder != value)
                {
                    bool old = FAllowImageBorder;
                    FAllowImageBorder = value;
                    RaisePropertyChanged(C_Prop_AllowImageBorder, old, value);
                }
            }
        }

        private const string C_Prop_ImageBorderColor = "ImageBorderColor";
        private string FImageBorderColor = "#FF276D70";

        public string ImageBorderColor
        {
            get { return FImageBorderColor; }
            set
            {
                if (FImageBorderColor != value)
                {
                    string old = FImageBorderColor;
                    FImageBorderColor = value;
                    RaisePropertyChanged(C_Prop_ImageBorderColor, old, value);
                }
            }
        }


        #region SelectedPathColor
        private const string C_Prop_SelectedPathColor = "SelectedPathColor";
        private string FSelectedPathColor;

        public string SelectedPathColor
        {
            get { return FSelectedPathColor; }
            set
            {
                if (FSelectedPathColor != value)
                {
                    string old = FSelectedPathColor;
                    FSelectedPathColor = value;
                    RaisePropertyChanged(C_Prop_SelectedPathColor, old, value);
                }
            }
        }
        
        #endregion
	



        private const string C_Prop_ImageBorderAnimationSpeed = "ImageBorderAnimationSpeed";
        private AnimationSpeedLevel FImageBorderAnimationSpeed = AnimationSpeedLevel.Zero;

        public AnimationSpeedLevel ImageBorderAnimationSpeed
        {
            get { return FImageBorderAnimationSpeed; }
            set
            {
                if (FImageBorderAnimationSpeed != value)
                {
                    AnimationSpeedLevel old = FImageBorderAnimationSpeed;
                    FImageBorderAnimationSpeed = value;
                    RaisePropertyChanged(C_Prop_ImageBorderAnimationSpeed, old, value);
                }
            }
        }

        public override string ToString()
        {
            return Key + ": " + Operation;
        }

        #region ToXML

        // support standard reading/writing via Linq for XML
        public override XElement MakeXElement(XName n)
        {
            XElement e = base.MakeXElement(n);

            e.Add(XHelper.Attribute(C_Prop_Cost, this.Cost, ""));
            e.Add(XHelper.Attribute(C_Prop_CostColor, this.CostColor, ""));
            e.Add(XHelper.Attribute(C_Prop_Operation, this.Operation, ""));
            e.Add(XHelper.Attribute(C_Prop_OperationColor, this.OperationColor, ""));
            e.Add(XHelper.Attribute(C_Prop_OperationData, this.OperationData, ""));
            e.Add(XHelper.Attribute(C_Prop_Rows, this.Rows, 0));
            e.Add(XHelper.Attribute(C_Prop_ImageName, this.ImageName, ""));           
            
            return e;
        }

        public override void LoadFromXElement(XElement e)
        {
            base.LoadFromXElement(e);
            this.Cost = XHelper.Read(C_Prop_Cost, e, "");
            this.CostColor = XHelper.Read(C_Prop_CostColor, e, "");
            this.Operation = XHelper.Read(C_Prop_Operation, e, "");
            this.OperationColor = XHelper.Read(C_Prop_OperationColor, e, "");
            this.OperationData = XHelper.Read(C_Prop_OperationData, e, "");
            this.Rows = XHelper.Read(C_Prop_Rows, e, 0);
            this.ImageName = XHelper.Read(C_Prop_ImageName, e, "");
        }

        #endregion ToXML
    }

    // no additional properties are needed for link data
    [Serializable]
    public class LinkData : Northwoods.GoXam.Model.GraphLinksModelLinkData<String, String>
    {
        private const string C_Prop_BorderSize = "BorderSize";
        private int FBorderSize;

        public int BorderSize
        {
            get { return FBorderSize; }
            set
            {
                if (FBorderSize != value)
                {
                    int old = FBorderSize;
                    FBorderSize = value;
                    RaisePropertyChanged(C_Prop_BorderSize, old, value);
                }
            }
        }

        private const string C_Prop_LineSize = "LineSize";
        private int FLineSize;

        public int LineSize
        {
            get { return FLineSize; }
            set
            {
                if (FLineSize != value)
                {
                    int old = FLineSize;
                    FLineSize = value;
                    RaisePropertyChanged(C_Prop_LineSize, old, value);
                }
            }
        }


        #region SelectedPathSize
        private const string C_Prop_SelectedPathSize = "SelectedPathSize";
        private int FSelectedPathSize;

        public int SelectedPathSize
        {
            get { return FSelectedPathSize; }
            set
            {
                if (FSelectedPathSize != value)
                {
                    int old = FSelectedPathSize;

                    FSelectedPathSize = value;
                    RaisePropertyChanged(C_Prop_SelectedPathSize, old, value);
                }
            }
        }
        
        #endregion



        #region SelectPathColor
        private const string C_Prop_SelectPathColor = "SelectPathColor";
        private string FSelectPathColor = "#FFC1DCFC";

        public string SelectPathColor
        {
            get { return FSelectPathColor; }
            set
            {
                if (FSelectPathColor != value)
                {
                    string old = FSelectPathColor;
                    FSelectPathColor = value;
                    RaisePropertyChanged(C_Prop_SelectPathColor, old, value);
                }
            }
        }
        
        #endregion
	
        #region IsAnimation
        private bool FIsAnimaiton = true;
        private const string C_Prop_IsAnimation = "IsAnimation";
        public bool IsAnimation
        {
            get { return FIsAnimaiton; }
            set
            {
                if (FIsAnimaiton != value)
                {
                    bool old = FIsAnimaiton;
                    FIsAnimaiton = value;
                    RaisePropertyChanged(C_Prop_IsAnimation, old, value);
                }
            }
        }

        #endregion


        private const string C_Prop_ImageBorderAnimationSpeed = "ImageBorderAnimationSpeed";
        private AnimationSpeedLevel FImageBorderAnimationSpeed = AnimationSpeedLevel.Zero;

        public AnimationSpeedLevel ImageBorderAnimationSpeed
        {
            get { return FImageBorderAnimationSpeed; }
            set
            {
                if (FImageBorderAnimationSpeed != value)
                {
                    AnimationSpeedLevel old = FImageBorderAnimationSpeed;
                    FImageBorderAnimationSpeed = value;
                    RaisePropertyChanged(C_Prop_ImageBorderAnimationSpeed, old, value);
                }
            }
        }

        private const string C_Prop_LinkColor = "LinkColor";
        private string FLinkColor = "#FFE2E2E2";

        public string LinkColor
        {
            get { return FLinkColor; }
            set
            {
                if (FLinkColor != value)
                {
                    string old = FLinkColor;
                    FLinkColor = value;
                    RaisePropertyChanged(C_Prop_LinkColor, old, value);
                }
            }
        }

        private const string C_Prop_LinkBorderColor = "LinkBorderColor";
        private string FLinkBorderColor = "#FF555555";

        public string LinkBorderColor
        {
            get { return FLinkBorderColor; }
            set
            {
                if (FLinkBorderColor != value)
                {
                    string old = FLinkBorderColor;
                    FLinkBorderColor = value;
                    RaisePropertyChanged(C_Prop_LinkBorderColor, old, value);
                }
            }
        }

        private const string C_Prop_Link2 = "Link2";
        private bool FLink2 = false;

        public bool Link2
        {
            get { return FLink2; }
            set
            {
                if (FLink2 != value)
                {
                    bool old = FLink2;
                    FLink2 = value;
                    RaisePropertyChanged(C_Prop_Link2, old, value);
                }
            }
        }

        private const string C_Prop_Link1 = "Link1";
        private bool FLink1 = true;

        public bool Link1
        {
            get { return FLink1; }
            set
            {
                if (FLink1 != value)
                {
                    bool old = FLink1;
                    FLink1 = value;
                    RaisePropertyChanged(C_Prop_Link1, old, value);
                }
            }
        }

        public override string ToString()
        {
            return this.From + " To " + this.To;
        }

        #region ToXML

        // support standard reading/writing via Linq for XML
        public override XElement MakeXElement(XName n)
        {
            XElement e = base.MakeXElement(n);
            
            e.Add(XHelper.Attribute(C_Prop_BorderSize, this.BorderSize, 1));
            e.Add(XHelper.Attribute(C_Prop_LineSize, this.LineSize, 1));

            return e;
        }

        public override void LoadFromXElement(XElement e)
        {
            base.LoadFromXElement(e);
            this.BorderSize = XHelper.Read(C_Prop_BorderSize, e, 1);
            this.LineSize = XHelper.Read(C_Prop_LineSize, e, 1);
        }

        #endregion ToXML

    }

    [Serializable]
    public class NodeDataCollection : ObservableCollection<SimpleData>
    {
        public NodeDataCollection LoadFromXML(string aXML)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(NodeDataCollection));
                if (string.IsNullOrWhiteSpace(aXML) == false)
                {
                    StringReader reader = new StringReader(aXML);
                    try
                    {
                        NodeDataCollection root = xs.Deserialize(reader) as NodeDataCollection;
                        return root;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        public string ToXML()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(NodeDataCollection));
                StringBuilder sb = new StringBuilder();
                StringWriter writer = new StringWriter(sb);
                try
                {
                    xs.Serialize(writer, this);
                }
                finally
                {
                    writer.Close();
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }

    [Serializable]
    public class LinkDataCollection : ObservableCollection<LinkData>
    {
        public LinkDataCollection LoadFromXML(string aXML)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(LinkDataCollection));
                if (string.IsNullOrWhiteSpace(aXML) == false)
                {
                    StringReader reader = new StringReader(aXML);
                    try
                    {
                        LinkDataCollection root = xs.Deserialize(reader) as LinkDataCollection;
                        return root;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        public string ToXML()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(LinkDataCollection));
                StringBuilder sb = new StringBuilder();
                StringWriter writer = new StringWriter(sb);
                try
                {
                    xs.Serialize(writer, this);
                }
                finally
                {
                    writer.Close();
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }

    #region group nodes

    [Serializable]
    public class SimpleDataGroup : SimpleData
    {
        private const string C_Prop_IsSmall = "IsSmall";
        private bool FIsSmall = false;

        public bool IsSmall
        {
            get { return FIsSmall; }
            set
            {
                if (FIsSmall != value)
                {
                    bool old = FIsSmall;
                    FIsSmall = value;
                    RaisePropertyChanged(C_Prop_IsSmall, old, FIsSmall);
                }
            }
        }


        public bool EverExpanded { get; set; }

        public String Color { get; set; }

        private const string C_Prop_ChildIconList = "ChildIconList";
        private List<string> FChildIconList;

        public List<string> ChildIconList
        {
            get { return FChildIconList; }
            set
            {
                if (FChildIconList != value)
                {
                    List<string> old = FChildIconList;
                    FChildIconList = value;
                    RaisePropertyChanged(C_Prop_ChildIconList, old, value);
                }
            }
        }

        private const string C_Prop_ChildIconSourceList = "ChildIconSourceList";
        [NonSerialized]
        [XmlIgnore]
        private List<BitmapSource> FChildIconSourceList;

        public List<BitmapSource> ChildIconSourceList
        {
            get { return FChildIconSourceList; }
            set
            {
                if (FChildIconSourceList != value)
                {
                    List<BitmapSource> old = FChildIconSourceList;
                    FChildIconSourceList = value;
                    RaisePropertyChanged(C_Prop_ChildIconSourceList, old, value);
                }
            }
        }

        private const string C_Prop_Visible = "Visible";
        private bool FVisible;

        public bool Visible
        {
            get { return FVisible; }
            set
            {
                if (FVisible != value)
                {
                    bool old = FVisible;
                    FVisible = value;
                    RaisePropertyChanged(C_Prop_Visible, old, value);
                }
            }
        }


        private const string C_Prop_OperationType = "OperationType";

        private OperationType FOperationType = OperationType.Others;

        public OperationType OperationType
        {
            get { return FOperationType; }
            set
            {
                if (FOperationType != value)
                {
                    OperationType old = FOperationType;
                    FOperationType = value;
                    RaisePropertyChanged(C_Prop_OperationType, old, value);
                }
            }
        }

        private const string C_Prop_TotalCost = "TotalCost";
        private double FTotalCost = 0.0;

        public double TotalCost
        {
            get { return FTotalCost; }
            set
            {
                if (FTotalCost != value)
                {
                    double old = FTotalCost;
                    FTotalCost = value;
                    RaisePropertyChanged(C_Prop_TotalCost, old, FTotalCost);
                }
            }
        }


    }

    [Serializable]
    public enum OperationType
    {
        Others,
        TableAccess,
        MergeJoin,
        HashMatch,
    }

    [Serializable]
    public class LinkDataGroup : LinkData
    {
        private static int count = 0;
        public LinkDataGroup()
        {
            FromPort = "port_image";
            ToPort = "port_image";
            LineSize = 2;
            BorderSize = 2;
            LinkColor = "LightGreen";
            LinkBorderColor = "#FFB9B9B9";
            count += 1;
            ID = "link" + count;
        }

        private const string C_Prop_DataSize = "DataSize";
        private string FDataSize = "DataSize: 0";

        public string DataSize
        {
            get { return FDataSize; }
            set
            {
                if (FDataSize != value)
                {
                    string old = FDataSize;
                    FDataSize = value;
                    RaisePropertyChanged(C_Prop_DataSize, old, value);
                }
            }
        }

        private const string C_Prop_RowSize = "RowSize";
        private string FRowSize = "RowSize: 0";

        public string RowSize
        {
            get { return FRowSize; }
            set
            {
                if (FRowSize != value)
                {
                    string old = FRowSize;
                    FRowSize = value;
                    RaisePropertyChanged(C_Prop_RowSize, old, value);
                }
            }
        }



        private const string C_Prop_AllowArrow = "AllowArrow";
        private bool FAllowArrow = true;

        public bool AllowArrow
        {
            get { return FAllowArrow; }
            set
            {
                if (FAllowArrow != value)
                {
                    bool old = FAllowArrow;
                    FAllowArrow = value;
                    RaisePropertyChanged(C_Prop_AllowArrow, old, value);
                }
            }
        }

        private const string C_Prop_ID = "ID";
        private string FID;

        public string ID
        {
            get { return FID; }
            set
            {
                if (FID != value)
                {
                    string old = FID;
                    FID = value;
                    RaisePropertyChanged(C_Prop_ID, old, FID);
                }
            }
        }


        public override object Clone()
        {
            LinkDataGroup link = new LinkDataGroup();
            link.To = this.To;
            link.From = this.From;
            link.AllowArrow = this.AllowArrow;
            link.ID = this.ID;
            return link;
        }

    }

    public static class CollectionUtil
    {
        public static void AddRange<type>(this ObservableCollection<type> aResult, ObservableCollection<type> aRange)
        {
            foreach (var item in aRange)
            {
                aResult.Add(item);
            }
        }
    }


    #endregion group nodes

    public class Column : INotifyPropertyChanged
    {
        public Column(String name, string aDataType, bool iskey, NodeFigure fig, String color)
        {
            this.Name = name;
            this.IsKey = iskey;
            this.DataType = aDataType;
            this.Figure = fig;
            this.Color = color;
        }

        // Property setters need to raise the PropertyChanged event,
        // only when the value has changed, and passing both the previous and the new values

        public String Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    String old = _Name;
                    _Name = value;
                    RaisePropertyChanged("Name", old, value);
                }
            }
        }
        private String _Name;

        private const string C_Prop_DataType = "DataType";
        private string FDataType;

        public string DataType
        {
            get { return FDataType; }
            set
            {
                if (FDataType != value)
                {
                    string old = FDataType;
                    FDataType = value;
                    RaisePropertyChanged(C_Prop_DataType, old, value);
                }
            }
        }


        public bool IsKey
        {
            get { return _IsKey; }
            set
            {
                if (_IsKey != value)
                {
                    bool old = _IsKey;
                    _IsKey = value;
                    RaisePropertyChanged("IsKey", old, value);
                }
            }
        }
        private bool _IsKey;

        public NodeFigure Figure
        {
            get { return _Figure; }
            set
            {
                if (_Figure != value)
                {
                    NodeFigure old = _Figure;
                    _Figure = value;
                    RaisePropertyChanged("Figure", old, value);
                }
            }
        }
        private NodeFigure _Figure = NodeFigure.DiskStorage;

        public String Color
        {
            get { return _Color; }
            set
            {
                if (_Color != value)
                {
                    String old = _Color;
                    _Color = value;
                    RaisePropertyChanged("Color", old, value);
                }
            }
        }
        private String _Color;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(String pname, Object oldval, Object newval)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new ModelChangedEventArgs(pname, this, oldval, newval));
            }
        }
    }
}
