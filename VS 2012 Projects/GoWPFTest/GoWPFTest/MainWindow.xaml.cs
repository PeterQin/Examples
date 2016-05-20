using Northwoods.GoXam;
using Northwoods.GoXam.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoWPFTest
{
    public enum AnimationAction
    {
        AnimationProperty,
        OnlyVisibleAnimation,
    }

    public enum AnimationSpeedLevel
    {
        Zero = 0,
        One = 20,
        Two = 40,
        Three = 60,
        Four = 80,
        Five = 100,
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private FrameworkElement FCurrentFocusElement;
        public static AnimationAction CurrentAnimationAction=AnimationAction.OnlyVisibleAnimation;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        
        /// <summary>
        /// Demo Ke:It will make diagram set NodeSources very slowly when Dynamic chage the background for node.
        /// So it only provide the example for change color.just for demo.
        /// </summary>
        public string HighlightPathColor
        {
            get { return (string)GetValue(HighlightPathColorProperty); }
            set { SetValue(HighlightPathColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightPathColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightPathColorProperty =
            DependencyProperty.Register("HighlightPathColor", typeof(string), typeof(MainWindow), new PropertyMetadata("#FFC1DCFC", OnHighlightColorChanged));

        private static void OnHighlightColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
       

        //private void Init(int loadNode=20)
        //{

        //    myDiagram.Model = new GraphLinksModel<SimpleDataGroup, String, String, LinkData>();
        //    myDiagram.Model.Modifiable = true;
        //    GenerateTree(loadNode);
        //}


        #region SelectedNode
        private Node FSelectedNode;

        public Node SelectedNode
        {
            get { return FSelectedNode; }
            set
            {
                if (FSelectedNode != value)
                {
                    HighlightPath(true);
                    FSelectedNode = value;
                    if (FSelectedNode != null)
                    {
                        SimpleDataGroup test = FSelectedNode.Data as SimpleDataGroup;
                        SelectedData = DataProvider.Clone<SimpleDataGroup>(test);
                    }
                    else
                    {
                        SelectedData = null;
                    }
                    HighlightPath();
                    if (radioOnlyPathAnimation.IsChecked == true)
                    {
                        HighOnlySelectPath();
                    }

                    this.NotifyPropertyChanged("SelectedNode");
                }
            }
        }
        #endregion

        #region SelectedData
        private SimpleDataGroup FSelectedData;

        public SimpleDataGroup SelectedData
        {
            get { return FSelectedData; }
            set
            {
                if (FSelectedData != value)
                {
                    if(FSelectedData!=null)
                        FSelectedData.PropertyChanged -= FSelectedData_PropertyChanged;
                    FSelectedData = value;
                    if (FSelectedData != null)
                        FSelectedData.PropertyChanged+=FSelectedData_PropertyChanged;
                    this.NotifyPropertyChanged("SelectedData");
                }
            }
        }

        private void FSelectedData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Node node = SelectedNode;
            SimpleDataGroup presentData = null;
            if (e.PropertyName == "ImageBorderColor")
            {
                if (node != null)
                {
                    presentData = node.Data as SimpleDataGroup;
                    presentData.ImageBorderColor = SelectedData.ImageBorderColor;
                }
            }
            else if (e.PropertyName == "IsAnimation")
            {
                if (node != null)
                {
                    presentData = node.Data as SimpleDataGroup;
                    presentData.IsAnimation = SelectedData.IsAnimation;
                    myDiagram.Panel.LineRight();
                }
            }
            else if (e.PropertyName == "ImageBorderAnimationSpeed")
            {
                if (node != null)
                {
                    presentData = node.Data as SimpleDataGroup;
                    presentData.ImageBorderAnimationSpeed = SelectedData.ImageBorderAnimationSpeed;
                    myDiagram.Panel.LineRight();
                }
            }

        }
        
        #endregion


        #region SelectedLink
        private Link FSelectLink;

        public Link SelectedLink
        {
            get { return FSelectLink; }
            set
            {
                if (FSelectLink != value)
                {
                    FSelectLink = value;
                    if (FSelectLink != null)
                    {
                        LinkData test = FSelectLink.Data as LinkData;
                        SelectedLinkData = DataProvider.Clone<LinkData>(test);
                    }
                    else
                    {
                        SelectedLinkData = null;
                    }
                }
            }
        }
        
        #endregion


        #region SelectedLinkData
        private LinkData FSelectedLinkData;

        public LinkData SelectedLinkData
        {
            get { return FSelectedLinkData; }
            set
            {
                if (FSelectedLinkData != value)
                {
                    if(FSelectedLinkData!=null)
                        FSelectedLinkData.PropertyChanged -= FSelectedLinkData_PropertyChanged;
                    FSelectedLinkData = value;
                    if (FSelectedLinkData != null)
                        FSelectedLinkData.PropertyChanged+=FSelectedLinkData_PropertyChanged;
                    this.NotifyPropertyChanged("SelectedLinkData");
                }
            }
        }

        #endregion

        private void FSelectedLinkData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Link link = SelectedLink;

            if (e.PropertyName == "IsAnimation")
            {           
                if (link != null)
                {
                    LinkData presentLink = link.Data as LinkData;
                    presentLink.IsAnimation = SelectedLinkData.IsAnimation;
                    myDiagram.Panel.LineRight();
                }
            }
            else if (e.PropertyName == "LinkColor")
            {
                if (link != null)
                {
                    LinkData presentData = link.Data as LinkData;
                    presentData.LinkColor = SelectedLinkData.LinkColor;
                }
            }
            else if (e.PropertyName == "LinkBorderColor")
            {
                if (link != null)
                {
                    LinkData presentData = link.Data as LinkData;
                    presentData.LinkBorderColor = SelectedLinkData.LinkBorderColor;
                }
            }
            else if (e.PropertyName == "SelectPathColor")
            {
                if (link != null)
                {
                    LinkData presentData = link.Data as LinkData;
                    presentData.SelectPathColor = SelectedLinkData.SelectPathColor;
                }
            }
            else if (e.PropertyName == "SelectedPathSize")
            {
                LinkData presentData = link.Data as LinkData;
                presentData.SelectedPathSize = SelectedLinkData.SelectedPathSize;
            }
            else if (e.PropertyName == "ImageBorderAnimationSpeed")
            {
                LinkData presentData = link.Data as LinkData;
                presentData.ImageBorderAnimationSpeed = SelectedLinkData.ImageBorderAnimationSpeed;
                myDiagram.Panel.LineLeft();
            }
            else if (e.PropertyName == "BorderSize")
            {
                LinkData presentData = link.Data as LinkData;
                presentData.BorderSize = SelectedLinkData.BorderSize;
            }
            else if (e.PropertyName == "LineSize")
            {
                LinkData presentData = link.Data as LinkData;
                presentData.LineSize = SelectedLinkData.LineSize;
            }
        }
        
        //// Generates a random tree respecting MinNodes/MaxNodes/MinLinks/MaxLinks
        //private void GenerateTree(int loadNode)
        //{
        //    ObservableCollection<SimpleDataGroup> nodes = DataProvider.Instance.GenerateNodes(loadNode-5);
        //    myDiagram.Model.NodesSource = nodes;
        //    GraphLinksModel<SimpleDataGroup, String, String, LinkData> linkModel = myDiagram.Model as GraphLinksModel<SimpleDataGroup, String, String, LinkData>;
        //    linkModel.LinksSource = DataProvider.Instance.GenerateLinks(nodes);
        //}

        // When a RadioButton becomes checked, set the Tag of the button container to the button's content (string)
        // For internationalization, this should use RadioButton.Tag to hold the value, not the RadioButton.Content
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                FrameworkElement group = VisualTreeHelper.GetParent(rb) as FrameworkElement;
                if (group != null)
                {
                    group.Tag = rb.Content;
                    //colorEdit.Color
                }
            }
        }

        private void myCollapseExpandButton_Click(object sender, RoutedEventArgs e)
        {
            // the Button is in the visual tree of a Node
            Button button = (Button)sender;
            Node n = Part.FindAncestor<Node>(button);
            if (n != null)
            {
                SimpleDataGroup parentdata = (SimpleDataGroup)n.Data;
                // always make changes within a transaction
                myDiagram.StartTransaction("CollapseExpand");
                // toggle whether this node is expanded or collapsed
                n.IsExpandedTree = !n.IsExpandedTree;
                myDiagram.CommitTransaction("CollapseExpand");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PathWindow pathWindow = new PathWindow();
            if (pathWindow.ShowDialog() == true)
            {
                string path = pathWindow.Path;
                WritePngFile(path);
                
            }
        }

        public void WritePngFile(String filename)
        {
            Rect bounds = myDiagram.Panel.DiagramBounds;
            double w = bounds.Width;
            double h = bounds.Height;
            // calculate scale so maximum width or height is 2000: 
            double s = 1.0;
            if (w > 2000) s = 2000 / w;
            if (h > 2000) s = Math.Min(s, 2000 / h);
            w = Math.Ceiling(w * s);
            h = Math.Ceiling(h * s);
            BitmapSource bmp = myDiagram.Panel.MakeBitmap(new Size(w, h), 96, new Point(bounds.X, bounds.Y), s);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bmp));
            using (System.IO.Stream stream = System.IO.File.Create(filename))
            {
                png.Save(stream);
            }
        }

        private void LoadData_Button_Click(object sender, RoutedEventArgs e)
        {
            //int nodenum = 0;
            //bool isSucess=int.TryParse(txtNodeNum.Text,out nodenum);
            //if (isSucess)
            //{
            //    Init(nodenum);
            //}
            //else
            //{
            //    Init();
            //}

            CreateData();
        }        

        #region Create Group Nodes

        private void CreateData()
        {
            myDiagram.BeginInit();

            var model = new GraphLinksModel<SimpleDataGroup, String, String, LinkDataGroup>();
            ObservableCollection<SimpleDataGroup> nodes = CreateDataGroupStyle2();

            foreach (SimpleDataGroup item in nodes)
            {
                if (item.Operation.Equals("Table Scan"))
                {
                    item.OperationType = OperationType.TableAccess;
                    item.ImageSource = null;
                }
                else if (item.Operation.Contains("Index Scan"))
                {
                    item.OperationType = OperationType.TableAccess;
                }
                else if (item.Operation.Contains("Index Seek"))
                {
                    item.OperationType = OperationType.TableAccess;
                }
                else if (item.Operation.Equals("Merge Join"))
                {
                    item.OperationType = OperationType.MergeJoin;
                }
                else if (item.Operation.Equals("Hash Match"))
                {
                    item.OperationType = OperationType.HashMatch;
                }
            }

            model.NodesSource = nodes;
            model.LinksSource = CreateLink2(nodes);
            myDiagram.Model = model;
            model.Modifiable = true;

            myDiagram.EndInit();
        }

        /// <summary>
        /// Group nodes except the last one
        /// 
        /// Select <-- [.] <--- Merge Join <---
        /// 
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<SimpleDataGroup> CreateDataGroupStyle2()
        {
            return DataProvider.Instance.CreateDataGroupStyle3();
        }

        private ObservableCollection<LinkDataGroup> CreateLink2(ObservableCollection<SimpleDataGroup> aNodes)
        {
            return DataProvider.Instance.CreateLink3(aNodes);
        }

        #endregion Create Group Nodes

        private void nodeContent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (FCurrentFocusElement != null)
            {
                VisualStateManager.GoToElementState(FCurrentFocusElement, "NormalState", true);
            }
            FCurrentFocusElement = sender as FrameworkElement;
            OnChangeStatus(FCurrentFocusElement);
        }

        private void nodeContent_MouseEnter(object sender, MouseEventArgs e)
        {
            OnChangeStatus(sender as FrameworkElement);
        }

        private void nodeContent_MouseLeave(object sender, MouseEventArgs e)
        {
            OnChangeStatus(sender as FrameworkElement);
        }

        private void OnChangeStatus(FrameworkElement element)
        {
            //if node is press
            if (element == FCurrentFocusElement)
            {
                VisualStateManager.GoToElementState(element, "mousePressState", true);
            }
            else if (element.IsMouseOver)
            {
                VisualStateManager.GoToElementState(element, "MouseOverState", true);
            }
            else
            {
                VisualStateManager.GoToElementState(element, "NormalState", true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void GetParentNodes(Node aNode,ObservableCollection<Node> parentNodes)
        {
            if(aNode.NodesInto.ToList()[0] !=null)
                parentNodes.Add(aNode.NodesInto.ToList()[0]);

            if (aNode.NodesInto.ToList()[0].NodesInto.Count() > 0)
                GetParentNodes(aNode.NodesInto.ToList()[0], parentNodes);
            
        }

        private void HighlightPath(bool aIsClearData=false)
        {
            if (chkEnableHighlight.IsChecked == true && FSelectedNode != null && FSelectedNode.NodesInto.Count() > 0 &&aIsClearData==false)
            {
                ObservableCollection<Node> parentNodes = new ObservableCollection<Node>();
                parentNodes.Add(FSelectedNode);
                GetParentNodes(FSelectedNode, parentNodes);
                ObservableCollection<Link> parentLinks = new ObservableCollection<Link>();
                foreach (Node item in parentNodes)
                {
                    if (item.LinksInto.Count() > 0)
                        parentLinks.Add(item.LinksInto.ToList<Link>()[0]);
                }

                foreach (Link linkItem in myDiagram.Links)
                {
                    LinkData test = linkItem.Data as LinkData;
                    if (parentLinks.Contains(linkItem))
                    {
                        linkItem.LayerName = "Foreground";
                        test.SelectedPathSize = (int)pathSize.Value;
                        test.SelectPathColor = HighlightPathColor;
                    }
                    else
                    {
                        linkItem.LayerName = null;
                        test.SelectedPathSize = 0;
                    }
                }

                if (chkOnlyLink.IsChecked == false)
                {
                    foreach (Node nodeItem in myDiagram.Nodes)
                    {
                        SimpleDataGroup testNode = nodeItem.Data as SimpleDataGroup;
                        Border nodeBorder = nodeItem.LocationElement as Border;
                        if (nodeBorder != null)
                        {
                            if (parentNodes.Contains(nodeItem))
                            {
                                nodeItem.LayerName = "Foreground";
                                nodeBorder.Background = new SolidColorBrush(pathColorEdit.Color);
                                nodeItem.InvalidateRelationships();
                            }
                            else
                            {
                                nodeItem.LayerName = null;
                                nodeBorder.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255)); //Tran
                            }
                        }

                    }
                }

                
            }
            else
            {
                foreach (Link linkItem in myDiagram.Links)
                {
                    LinkData test = linkItem.Data as LinkData;
                    test.SelectedPathSize = 0;
                }

                if (chkOnlyLink.IsChecked == false)
                {
                    foreach (Node nodeItem in myDiagram.Nodes)
                    {
                        SimpleDataGroup testNode = nodeItem.Data as SimpleDataGroup;
                        Border nodeBorder = nodeItem.LocationElement as Border;
                        if (testNode != null && nodeBorder != null)
                            nodeBorder.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255)); //Tran
                    }
                }
            }
        }

        private void chkEnableHighlight_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            HighlightPath();
        }

        private void trackbarNode_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            int newValue = 0;
            int.TryParse(e.NewValue.ToString(), out newValue);
            if (FSelectedData != null)
            {
                switch (newValue)
                {
                    case 0:
                        FSelectedData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Zero;
                        break;
                    case 20:
                        FSelectedData.ImageBorderAnimationSpeed = AnimationSpeedLevel.One;
                        break;
                    case 40:
                        FSelectedData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Two;
                        break;
                    case 60:
                        FSelectedData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Three;
                        break;
                    case 80:
                        FSelectedData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Four;
                        break;
                    case 100:
                        FSelectedData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Five;
                        break;
                    default:
                        break;
                }
            }
           
        }

        private void trackBarLink_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            int newValue = 0;
            int.TryParse(e.NewValue.ToString(), out newValue);
            if (FSelectedLinkData != null)
            {
                switch (newValue)
                {
                    case 0:
                        FSelectedLinkData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Zero;
                        break;
                    case 20:
                        FSelectedLinkData.ImageBorderAnimationSpeed = AnimationSpeedLevel.One;
                        break;
                    case 40:
                        FSelectedLinkData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Two;
                        break;
                    case 60:
                        FSelectedLinkData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Three;
                        break;
                    case 80:
                        FSelectedLinkData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Four;
                        break;
                    case 100:
                        FSelectedLinkData.ImageBorderAnimationSpeed = AnimationSpeedLevel.Five;
                        break;
                    default:
                        break;
                }
            }
        }

        private void pathColorEdit_ColorChanged(object sender, RoutedEventArgs e)
        {
            HighlightPath();
        }

        private void radio_AllAnimation_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentAnimationAction = AnimationAction.AnimationProperty;
            if (FSelectedData != null)
                FSelectedData.PropertyChanged -= FSelectedData_PropertyChanged;
            foreach (Node item in myDiagram.Nodes)
            {
                SimpleDataGroup testNode = item.Data as SimpleDataGroup;
                testNode.IsAnimation = true;
            }
            if (FSelectedData != null)
                FSelectedData.PropertyChanged += FSelectedData_PropertyChanged;

            if (FSelectedLinkData != null)
                FSelectedLinkData.PropertyChanged -= FSelectedLinkData_PropertyChanged;
            foreach (var item in myDiagram.Links)
            {
                LinkData testlink = item.Data as LinkData;
                testlink.IsAnimation = true;
            }
            if (FSelectedLinkData != null)
                FSelectedLinkData.PropertyChanged += FSelectedLinkData_PropertyChanged;

            if(myDiagram.Panel!=null)
                myDiagram.Panel.LineRight();
        }

        private void radio_OnlyVisibleAnimaiton_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentAnimationAction = AnimationAction.OnlyVisibleAnimation;
            if (myDiagram.Panel != null)
                myDiagram.Panel.LineRight();
        }

        private void radio_All_UnAnimation_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentAnimationAction = AnimationAction.AnimationProperty;
            if (FSelectedData != null)
                FSelectedData.PropertyChanged -= FSelectedData_PropertyChanged;
            foreach (Node item in myDiagram.Nodes)
            {
                SimpleDataGroup testNode = item.Data as SimpleDataGroup;
                testNode.IsAnimation = false;
            }
            if (FSelectedData != null)
                FSelectedData.PropertyChanged += FSelectedData_PropertyChanged;

            if (FSelectedLinkData != null)
                FSelectedLinkData.PropertyChanged -= FSelectedLinkData_PropertyChanged;
            foreach (var item in myDiagram.Links)
            {
                LinkData testlink = item.Data as LinkData;
                testlink.IsAnimation = false;
            }
            if (FSelectedLinkData != null)
                FSelectedLinkData.PropertyChanged += FSelectedLinkData_PropertyChanged;
            if (myDiagram.Panel != null)
                myDiagram.Panel.LineLeft();
        }

        private void HighOnlySelectPath()
        {
            if (FSelectedNode != null && FSelectedNode.NodesInto.Count() > 0)
            {
                ObservableCollection<Node> parentNodes = new ObservableCollection<Node>();
                parentNodes.Add(FSelectedNode);
                GetParentNodes(FSelectedNode, parentNodes);
                ObservableCollection<Link> parentLinks = new ObservableCollection<Link>();
                foreach (Node item in parentNodes)
                {
                    if (item.LinksInto.Count() > 0)
                        parentLinks.Add(item.LinksInto.ToList<Link>()[0]);
                }

                MainWindow.CurrentAnimationAction = AnimationAction.AnimationProperty;
                if (FSelectedData != null)
                    FSelectedData.PropertyChanged -= FSelectedData_PropertyChanged;
                foreach (Node item in myDiagram.Nodes)
                {
                    SimpleDataGroup testNode = item.Data as SimpleDataGroup;
                    if (parentNodes.Contains(item))
                        testNode.IsAnimation = true;
                    else
                        testNode.IsAnimation = false;
                }
                if (FSelectedData != null)
                    FSelectedData.PropertyChanged += FSelectedData_PropertyChanged;

                if (FSelectedLinkData != null)
                    FSelectedLinkData.PropertyChanged -= FSelectedLinkData_PropertyChanged;
                foreach (Link item in myDiagram.Links)
                {
                    LinkData testlink = item.Data as LinkData;
                    if (parentLinks.Contains(item))
                        testlink.IsAnimation = true;
                    else
                        testlink.IsAnimation = false;
                }
                if (FSelectedLinkData != null)
                    FSelectedLinkData.PropertyChanged += FSelectedLinkData_PropertyChanged;

                if (myDiagram.Panel != null)
                    myDiagram.Panel.LineLeft();
            }
            else
            {
                radio_All_UnAnimation_Checked(null,null); //unAnimaiton all.
            } 
        }
        private void radioOnlyPathAnimation_Checked(object sender, RoutedEventArgs e)
        {
            HighOnlySelectPath();
        }

        private void pathSize_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            HighlightPath();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            CreateData();
           
        }

  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("drag");
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("drag");
        }

       
    }


    public class VirtualizingDiagramPanel : DiagramPanel
    {
        // whenever the viewport changes, maybe create or remove some Nodes and Links
        protected override void OnViewportBoundsChanged(RoutedPropertyChangedEventArgs<Rect> e)
        {
            base.OnViewportBoundsChanged(e);

            switch (MainWindow.CurrentAnimationAction)
            {
                case AnimationAction.AnimationProperty:
                    foreach (Node nodeItem in this.Diagram.Nodes)
                    {
                        SimpleDataGroup nodeData = nodeItem.Data as SimpleDataGroup;
                        if (nodeData.IsAnimation == true)
                        {
                            switch (nodeData.ImageBorderAnimationSpeed)
                            {
                                case AnimationSpeedLevel.Zero:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelZero", true);
                                    break;
                                case AnimationSpeedLevel.One:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelOne", true);
                                    break;
                                case AnimationSpeedLevel.Two:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelTwo", true);
                                    break;
                                case AnimationSpeedLevel.Three:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelThree", true);
                                    break;
                                case AnimationSpeedLevel.Four:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelFour", true);
                                    break;
                                case AnimationSpeedLevel.Five:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelFive", true);
                                    break;
                            }
                        }
                        else
                        {
                            VisualStateManager.GoToElementState(nodeItem.LocationElement, "NoAnimation", true);
                        }
                    }

                    foreach (Link linkItem in this.Diagram.Links)
                    {
                        LinkData linkData = linkItem.Data as LinkData;
                        if (linkData.IsAnimation == true)
                        {
                            switch (linkData.ImageBorderAnimationSpeed)
                            {
                                case AnimationSpeedLevel.Zero:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelZero", true);
                                    break;
                                case AnimationSpeedLevel.One:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelOne", true);
                                    break;
                                case AnimationSpeedLevel.Two:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelTwo", true);
                                    break;
                                case AnimationSpeedLevel.Three:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelThree", true);
                                    break;
                                case AnimationSpeedLevel.Four:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelFour", true);
                                    break;
                                case AnimationSpeedLevel.Five:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelFive", true);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            VisualStateManager.GoToElementState(linkItem.VisualElement, "NoAnimation", true);
                        }
                    }
                    break;
                case AnimationAction.OnlyVisibleAnimation:
                    foreach (Node nodeItem in this.Diagram.Nodes)
                    {
                        SimpleDataGroup nodeData = nodeItem.Data as SimpleDataGroup;
                        if (IsOnscreen(nodeItem, e.NewValue) == false)
                        {
                            nodeData.IsAnimation = false;
                            VisualStateManager.GoToElementState(nodeItem.LocationElement, "NoAnimation", true);
                        }
                        else
                        {
                            nodeData.IsAnimation = true;
                            switch (nodeData.ImageBorderAnimationSpeed)
                            {
                                case AnimationSpeedLevel.Zero:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelZero", false);
                                    break;
                                case AnimationSpeedLevel.One:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelOne", false);
                                    break;
                                case AnimationSpeedLevel.Two:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelTwo", false);
                                    break;
                                case AnimationSpeedLevel.Three:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelThree", false);
                                    break;
                                case AnimationSpeedLevel.Four:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelFour", false);
                                    break;
                                case AnimationSpeedLevel.Five:
                                    VisualStateManager.GoToElementState(nodeItem.LocationElement, "AnimationNodeLevelFive", false);
                                    break;
                            }
                        }
                    }

                    foreach (Link linkItem in this.Diagram.Links)
                    {
                        LinkData linkData = linkItem.Data as LinkData;
                        if (IsOnscreen(linkItem, e.NewValue) == false)
                        {
                            linkData.IsAnimation = false;
                            VisualStateManager.GoToElementState(linkItem.VisualElement, "NoAnimation", true);
                        }
                        else
                        {
                            linkData.IsAnimation = true;
                            switch (linkData.ImageBorderAnimationSpeed)
                            {
                                case AnimationSpeedLevel.Zero:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelZero", true);
                                    break;
                                case AnimationSpeedLevel.One:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelOne", true);
                                    break;
                                case AnimationSpeedLevel.Two:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelTwo", true);
                                    break;
                                case AnimationSpeedLevel.Three:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelThree", true);
                                    break;
                                case AnimationSpeedLevel.Four:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelFour", true);
                                    break;
                                case AnimationSpeedLevel.Five:
                                    VisualStateManager.GoToElementState(linkItem.VisualElement, "AnimationLinkLevelFive", true);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
           
        }

        private static bool Intersects(Rect a, Rect b)
        {
            double tw = a.Width;
            double rw = b.Width;
            double tx = a.X;
            double rx = b.X;
            if (!Double.IsPositiveInfinity(tw) && !Double.IsPositiveInfinity(rw))
            {
                tw += tx;
                rw += rx;
                if (Double.IsNaN(rw) || Double.IsNaN(tw) || tx > rw || rx > tw) return false;
            }

            double th = a.Height;
            double rh = b.Height;
            double ty = a.Y;
            double ry = b.Y;
            if (!Double.IsPositiveInfinity(th) && !Double.IsPositiveInfinity(rh))
            {
                th += ty;
                rh += ry;
                if (Double.IsNaN(rh) || Double.IsNaN(th) || ty > rh || ry > th) return false;
            }
            return true;
        }

        private bool IsOnscreen(Link link,Rect viewRect)
        {
            if (link == null) return false;
            Node from = link.FromNode;
            if (from == null) return false;
            Node to = link.ToNode;
            if (to == null) return false;
            Rect b = ComputeNodeBounds(from);
            b.Union(ComputeNodeBounds(to));
            return Intersects(viewRect, b);
        }

        private bool IsOnscreen(Node node, Rect viewRect)
        {
            Rect b = ComputeNodeBounds(node);
            return Intersects(viewRect, b);
        }

        public Rect ComputeNodeBounds(Node node)
        {
            return new Rect(node.Location.X - node.ActualWidth / 2, node.Location.Y - node.ActualHeight / 2, node.ActualWidth, node.ActualHeight);
        }
    }



    #region Converter

    public class ImageSourceConverter : IValueConverter
    {
        private static readonly ImageSourceConverter FInstance = new ImageSourceConverter();

        public static ImageSourceConverter Instance
        {
            get { return ImageSourceConverter.FInstance; }
        }

        private ImageSourceConverter() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }
            return App.Current.TryFindResource((string)value) as BitmapSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanToVisibilityConverterInvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion Converter


}

