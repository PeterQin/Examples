using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid.LookUp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace BreakCrumbTest
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BreakCrumbTest"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BreakCrumbTest;assembly=BreakCrumbTest"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:BreakCrumb/>
    ///
    /// </summary>
    
    public class BreadCrumb : ContentControl, INotifyPropertyChanged
    {
       
        static BreadCrumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadCrumb), new FrameworkPropertyMetadata(typeof(BreadCrumb)));            
        }

         #region Field
        private BrushConverter brushConver = new BrushConverter();
        private StackPanel flpAddressBar;
        /// <summary>
        /// Drop down menu that contains the overflow menu
        /// </summary>
        //PopupMenu FOverflowMenu = null;
        private BreadCrumbButton FPrevButton;
        private BreadCrumbButton FNextButton;
        private BreadCrumbButton FPrevOverflowButton = null;
        private BreadCrumbItemCollection FPrevOverflowItems = null;
        private BreadCrumbButton FBackOverflowButton = null;
        private BreadCrumbItemCollection FBackOverflowItems = null;
        private List<BreadCrumbButton> FVisableControlList = new List<BreadCrumbButton>();

        private BreadCrumbItemCollection FItems = null;
        private int FCurrentItemIndex = C_InvalidItemIndex;

        private double FOldWidth = -1;
        private int FChangingCurrentItem = 0;

        private Color FItemBorderColor = Colors.White;
        private const int FItemMaxTextWidthDefault = 200;
        private int FItemMaxTextWidth = FItemMaxTextWidthDefault;

        private List<HistoryAction> FHistory = new List<HistoryAction>();
        private int FCurrentHistoryIndex = C_HistoryInitIndex;

        #region Const / Enum / Delegate / Event
        private const string C_CanGoToPreviousHistoryAction = "CanGoToPreviousHistoryAction";
        private const string C_CanGoToNextHistoryAction = "CanGoToNextHistoryAction";
        private const int C_InvalidItemIndex = -1;
        private const int C_HistoryInitIndex = -1;
        /// <summary>
        /// History Max Count is 10.
        /// </summary>
        private const int C_HistoryMaxCount = 10;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Stores the callback function for when the selected item changes.
        /// </summary>
        [Category("Quest")]
        [Description("Stores the callback function for when the selected item changes.")]
        public event SelectionChangedEventHandler SelectionChanged = null;

        /// <summary>
        /// Stores the callback function for when add a new item by user action.
        /// </summary>
        [Category("Quest")]
        [Description("Stores the callback function for when add a new item by user action.")]
        public event ItemAddedEventHandler ItemAdded = null;

        /// <summary>
        /// Stores the callback function for when the current history action changes or history action list changes.
        /// </summary>
        [Category("Quest")]
        [Description("Stores the callback function for when the current history action changes or history action list changes.")]
        public event EventHandler HistoryActionChanged = null;

        /// <summary>
        /// Stores the callback function for when request child list for popup window.
        /// </summary>
        [Category("Quest")]
        [Description("Stores the callback function for when request child list for popup window.")]
        public event RequestChildListEventHandler RequestChildList = null;
        #endregion Const / Enum / Delegate / Event

        #region Property

        protected int FixedHeight
        {
            get
            {
                return 22;
            }
        }

        protected bool IsChangingCurrentItem
        {
            get
            {
                return (this.FChangingCurrentItem != 0);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BreadCrumbItem CurrentItem
        {
            get
            {
                if (FCurrentItemIndex != C_InvalidItemIndex)
                {
                    return FItems[FCurrentItemIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentItemIndex
        {
            get { return FCurrentItemIndex; }
            set
            {
                if (FCurrentItemIndex != value)
                {
                    FCurrentItemIndex = value;

                    #region Check the current item whether in overflow button
                    BreadCrumbItem currentItem = CurrentItem;
                    BreadCrumbButton overflowButton = null;

                    if (FPrevOverflowItems != null && FPrevOverflowItems.Contains(currentItem) == true)
                    {
                        overflowButton = FPrevOverflowButton;
                    }
                    else if (FBackOverflowItems != null && FBackOverflowItems.Contains(currentItem) == true)
                    {
                        overflowButton = FBackOverflowButton;
                    }

                    // If the current item is in the overflow button, then move it and the next item to bar.
                    if (overflowButton != null)
                    {
                        BreadCrumbItemCollection list = (BreadCrumbItemCollection)overflowButton.ItemsSource;

                        for (int i = list.IndexOf(currentItem); i >= 0; i--)
                        {
                            ButtonShowInBar(list[i].OwnerButton, list);
                        }

                        if (list.Count == 0)
                        {
                            HideOverflowButton(overflowButton);
                        }

                        ButtonItemMoveToOverflowItem();
                    }
                    else if (TooManyButtons() == true)
                    {
                        ButtonItemMoveToOverflowItem();
                    }
                    #endregion
                    if (FCurrentItemIndex >= 0)
                    {

                        // Previous item clear the tail item style.
                        ClearTailItemStyleBeforeIndex(FCurrentItemIndex);

                        // Back item set the tail item style.
                        ToTailItemStyleAfterIndex(FCurrentItemIndex);
                    }

                    if (IsChangingCurrentItem == false)
                    {
                        // Raise selectio changed event.
                        DoSelectionChanged(FCurrentItemIndex);
                    }                   
                    
                }

                if (FCurrentItemIndex >= 0)
                {
                    ActivedItem = Items[FCurrentItemIndex].ActualObj;
                }
                else
                {
                    ActivedItem = null;
                }
            }
        }

        public object ActivedItem
        {
            get { return (object)GetValue(ActivedItemProperty); }
            set { SetValue(ActivedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActivedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActivedItemProperty =
            DependencyProperty.Register("ActivedItem", typeof(object), typeof(BreadCrumb));



        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BreadCrumbItemCollection Items
        {
            get { return FItems; }
        }

        private string FItemCaptionField = "Caption";

        public string ItemCaptionField
        {
            get { return FItemCaptionField; }
            set { FItemCaptionField = value; }
        }

        private string FItemDataField = "Data";

        public string ItemDataField
        {
            get { return FItemDataField; }
            set { FItemDataField = value; }
        }

        private string FItemChildrenField = "ChildList";

        public string ItemchildrenField
        {
            get { return FItemChildrenField; }
            set { FItemChildrenField = value; }
        }

        private string FItemParentChildrenField = "ParentChildList";

        public string ItemParentChildrenField
        {
            get { return FItemParentChildrenField; }
            set { FItemParentChildrenField = value; }
        }


        public object ItemSource
        {
            get { return (object)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(object), 
                                        typeof(BreadCrumb),
                                        new FrameworkPropertyMetadata
                                                (
                                                    null,
                                                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                                                    new PropertyChangedCallback(ItemSourcePropertyChanged)
                                                )
                                        );


        private static void ItemSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BreadCrumb currentBreadCrumb = d as BreadCrumb;
            if (currentBreadCrumb != null)
            {
                if (e.OldValue != null)
                {
                    currentBreadCrumb.HandleItemSourceCollectionChanged(e.OldValue, false);
                }
                if (e.NewValue != null)
                {
                    currentBreadCrumb.HandleItemSourceCollectionChanged(e.NewValue, true);
                }
            }           
        }

        public void HandleItemSourceCollectionChanged(object aSource, bool aIsListenCollectionChagned)
        {
            INotifyCollectionChanged collectionObj = aSource as INotifyCollectionChanged;
            if (collectionObj != null)
            {
                if (aIsListenCollectionChagned)
                {
                    collectionObj.CollectionChanged += collectionObj_CollectionChanged;
                }
                else
                {
                    collectionObj.CollectionChanged -= collectionObj_CollectionChanged;
                }
            }
        }

        private void collectionObj_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        BeginChangingCurrentItem();
                        try
                        {
                            BreadCrumbItem breadItem = null;
                            this.Items.CollectionChanged -= FItems_CollectionChanged;
                            for (int i = 0; i < e.NewItems.Count; i++)
                            {
                                breadItem = CreateButtonIntoBar(e.NewItems[i]);
                                if (breadItem != null)
                                {                                    

                                    Items.Add(breadItem);

                                    if (breadItem.ParentChildList != null)
                                    {
                                        BreadCrumbItemCollection children = new BreadCrumbItemCollection(breadItem.ParentChildList);
                                        this.Items[CurrentItemIndex].ChildList = children;
                                        this.Items[CurrentItemIndex].OwnerButton.EditValueChanged -= new EditValueChangedEventHandler(SubItem_EditValueChanged);
                                        try
                                        {
                                            this.Items[CurrentItemIndex].OwnerButton.SetDataSource(children, breadItem);
                                        }
                                        finally
                                        {
                                            this.Items[CurrentItemIndex].OwnerButton.EditValueChanged += new EditValueChangedEventHandler(SubItem_EditValueChanged);
                                        }                                      

                                        this.Items[CurrentItemIndex].AllowShowDorpDown = true;
                                    }
                                }


                                

                                CurrentItemIndex = this.Items.IndexOf(breadItem);
                            }                            
                            AddHistoryAction(HistoryActionType.ChangeList, CurrentItemIndex, CloneItemCollectionForHistoryAction());
                        }
                        finally
                        {
                            this.Items.CollectionChanged += FItems_CollectionChanged;
                            EndChangingCurrentItem();
                        }
                    }
                    
                    break;
                case NotifyCollectionChangedAction.Move:

                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        try
                        {
                            BeginChangingCurrentItem();
                            this.Items.CollectionChanged -= FItems_CollectionChanged;
                            BreadCrumbItem breadItem = null;
                            for (int i = 0; i < e.OldItems.Count; i++)
                            {
                                breadItem = ConvertToBreadCrumbItem(e.OldItems[i]);
                                int index = Items.IndexOf(breadItem);
                                if (index > -1)
                                {
                                    HandleRemoveItem(Items[index]);
                                }
                                Items.RemoveAt(index);
                                //move current to last one
                                if (index == CurrentItemIndex)
                                {
                                    CurrentItemIndex = index - 1;
                                }

                                breadItem.OwnerButton = null;
                                breadItem = null;
                            }
                        }
                        finally
                        {
                            this.Items.CollectionChanged += FItems_CollectionChanged;
                            EndChangingCurrentItem();
                        }
                    }                    
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        [Category("Quest")]
        [Description("Gets or sets the border color of button item.")]
        [DefaultValue(typeof(Color), "White")]
        public Color ItemBorderColor
        {
            get { return FItemBorderColor; }
            set
            {
                if (value == Colors.Transparent)
                {
                    throw new Exception("ButtonBorderColor didnot support transparent.");
                }

                if (FItemBorderColor != value)
                {
                    FItemBorderColor = value;
                    RefreshItemBorderColor();
                }
            }
        }

        [Category("Quest")]
        [Description("Gets or sets the max width of button item text.")]
        [DefaultValue(200)]
        public int ItemMaxTextWidth
        {
            get { return FItemMaxTextWidth; }
            set
            {
                if (FItemMaxTextWidth != value)
                {
                    FItemMaxTextWidth = value;
                    RefreshItemTextWidth();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether has a previous history action.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanGoToPreviousHistoryAction
        {
            get
            {
                bool result = false;

                if (FHistory.Count > 1)
                {
                    if (FCurrentHistoryIndex == C_HistoryInitIndex || FCurrentHistoryIndex > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a value indicating whether has a next history action.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanGoToNextHistoryAction
        {
            get
            {
                bool result = false;

                if (FHistory.Count > 1)
                {
                    if (FCurrentHistoryIndex != C_HistoryInitIndex && FCurrentHistoryIndex < FHistory.Count - 1)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        public ButtonEdit PrevButton
        {
            get { return FPrevButton; }
        }        

        public ButtonEdit NextButton
        {
            get { return FNextButton; }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer
        public BreadCrumb()
        {
            ResourceDictionary ImagesDictionary = new ResourceDictionary();
            ImagesDictionary.Source = new Uri("pack://application:,,,/BreakCrumbTest;component/Themes/BreadCrumbImages.xaml");
            this.Resources.MergedDictionaries.Add(ImagesDictionary);

            //Create and add your control to Tab Header
            Grid gridContent = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(1, GridUnitType.Auto);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(1, GridUnitType.Auto);
            ColumnDefinition col3 = new ColumnDefinition();
            col3.Width = new GridLength(1, GridUnitType.Star);
            gridContent.ColumnDefinitions.Add(col1);
            gridContent.ColumnDefinitions.Add(col2);
            gridContent.ColumnDefinitions.Add(col3);

            FPrevButton = new BreadCrumbButton(new BreadCrumbItem("....", null, null, false));
            FPrevButton.TextButton.GlyphKind = GlyphKind.Left;
            FPrevButton.DropDownButton.Visibility = System.Windows.Visibility.Collapsed;
            FPrevButton.SetValue(Grid.ColumnProperty, 0);
            FPrevButton.ClickTextButton += FPrevButton_ClickTextButton;
            FPrevButton.SetBinding(BreadCrumbButton.IsEnabledProperty, new Binding("CanGoToPreviousHistoryAction"){Source = this, Mode= BindingMode.OneWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});

            FNextButton = new BreadCrumbButton(new BreadCrumbItem("....", null, null, false));
            FNextButton.TextButton.GlyphKind = GlyphKind.Right;
            FNextButton.DropDownButton.Visibility = System.Windows.Visibility.Collapsed;
            FNextButton.SetValue(Grid.ColumnProperty, 1);
            FNextButton.ClickTextButton += FNextButton_ClickTextButton;
            FNextButton.SetBinding(BreadCrumbButton.IsEnabledProperty, new Binding("CanGoToNextHistoryAction") { Source = this, Mode = BindingMode.OneWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            flpAddressBar = new StackPanel();
            flpAddressBar.Orientation = Orientation.Horizontal;
            flpAddressBar.LayoutUpdated += flpAddressBar_LayoutUpdated;
            flpAddressBar.SetValue(Grid.ColumnProperty, 2);

            gridContent.Children.Add(FPrevButton);
            gridContent.Children.Add(FNextButton);
            gridContent.Children.Add(flpAddressBar);

            this.Content = gridContent;

            FItems = new BreadCrumbItemCollection();
            FItems.CollectionChanged += new CollectionChangeEventHandler(FItems_CollectionChanged); 
        }

        private void FNextButton_ClickTextButton(object sender, RoutedEventArgs e)
        {
            GoToNextHistoryAction();
        }

        private void FPrevButton_ClickTextButton(object sender, RoutedEventArgs e)
        {
            GoToPreviousHistoryAction();
        }
       
        ~BreadCrumb()
        {
            this.Dispatcher.BeginInvoke(new Action(RemoveCollectionChangedHandler));
        }

        private void RemoveCollectionChangedHandler()
        {
            HandleItemSourceCollectionChanged(ItemSource, false);
        }

        #endregion Constructor & Destroyer

        #region Private Section

        #region Support Overflow Functions

        private void CreateOverflowButton()
        {
            if (this.FPrevOverflowButton == null)
            {
                FPrevOverflowButton = CreateCommonButton(new BreadCrumbItem("....", null, null, false));
                FPrevOverflowButton.TextButton.Visibility = System.Windows.Visibility.Collapsed;
                FPrevOverflowButton.DropDownButton.GlyphKind = GlyphKind.PrevPage;
                FPrevOverflowButton.Visibility = System.Windows.Visibility.Collapsed;

                FPrevOverflowItems = new BreadCrumbItemCollection(FPrevOverflowButton);

                FPrevOverflowButton.SetDataSource(FPrevOverflowItems);
                FPrevOverflowButton.ShowDropDownButton = true;

                FPrevOverflowButton.EditValueChanged += new EditValueChangedEventHandler(OverflowButton_EditValueChanged);

                flpAddressBar.Children.Insert(0, FPrevOverflowButton);
            }

            if (this.FBackOverflowButton == null)
            {

                FBackOverflowButton = CreateCommonButton(new BreadCrumbItem("....", null, null, false));
                FBackOverflowButton.TextButton.Visibility = System.Windows.Visibility.Collapsed;
                FBackOverflowButton.DropDownButton.GlyphKind = GlyphKind.NextPage;
                FBackOverflowButton.Visibility = System.Windows.Visibility.Collapsed;

                FBackOverflowItems = new BreadCrumbItemCollection(FBackOverflowButton);

                FBackOverflowButton.SetDataSource(FBackOverflowItems);
                FBackOverflowButton.ShowDropDownButton = true;

                FBackOverflowButton.EditValueChanged += new EditValueChangedEventHandler(OverflowButton_EditValueChanged);

                flpAddressBar.Children.Insert(flpAddressBar.Children.Count - 1, FBackOverflowButton);
            }
        }

        /// <summary>
        /// Method that calculates if we have too many buttons in our address bar
        /// </summary>
        private bool TooManyButtons()
        {
            bool result = false;

            if (flpAddressBar.Children.Count > 0)
            {
                Control lastCtl = null;

                if (FBackOverflowButton != null && FBackOverflowButton.Visibility == System.Windows.Visibility.Visible)
                {
                    lastCtl = FBackOverflowButton;
                }
                else
                {
                    lastCtl = GetLastVisableControl();
                }

                if (lastCtl != null && GetRight(lastCtl) > flpAddressBar.DesiredSize.Width)
                {
                    result = true;
                }
            }

            return result;
        }

        private double GetRight(Control aControl)
        {
            GeneralTransform transform = aControl.TransformToAncestor(flpAddressBar);
            Point rootPoint = transform.Transform(new Point(0, 0));
            return rootPoint.X + aControl.ActualWidth;
        }

        private void ButtonShowInBar(BreadCrumbButton preDisableCtl, BreadCrumbItemCollection aItemList)
        {
            preDisableCtl.Visibility = System.Windows.Visibility.Visible;
            flpAddressBar.UpdateLayout();
            //******************************************************************
            //-Edit by Rob Feng at Date: May 11, 2011
            //-Desc:
            /*
             * Sometimes the item will has draw style when move to bar, so refresh it when move to bar.
             * 
             * Reproduce steps:
             * 1. Show three items at UI.
             * 2. Change size to only show the last item.
             * 3. Click the last item button.
             * 4. Change size to show the hidden items. This time the second item will has draw style.
             */
            //-Source Code:
            //preDisableCtl.Refresh();
            //******************************************************************

            aItemList.Remove(preDisableCtl.ItemObject);
            FVisableControlList.Add(preDisableCtl);
        }

        private void HideOverflowButton(BreadCrumbButton aOverflowButton)
        {
            aOverflowButton.Visibility = System.Windows.Visibility.Collapsed;
            aOverflowButton.EditValue = null;
        }

        private void RemoveOverflowItem(BreadCrumbItemCollection aOverflowList, BreadCrumbItem aItem)
        {
            aOverflowList.Remove(aItem);
            if (aOverflowList.Count == 0)
            {
                aOverflowList.ParentControl.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Method to create the overflow element for handling
        /// </summary>
        private void ButtonItemMoveToOverflowItem()
        {
            // Try to create the overflow button first.
            CreateOverflowButton();

            #region Check the width and move the button into previous overflow list
            while (TooManyButtons())
            {
                BreadCrumbButton firstVisableCtl = GetFirstVisableControl();

                if (firstVisableCtl == null || firstVisableCtl == CurrentItem.OwnerButton)
                {
                    break;
                }

                FPrevOverflowItems.Insert(0, firstVisableCtl.ItemObject);

                // remove our item from the normal bar
                firstVisableCtl.Visibility = System.Windows.Visibility.Collapsed;
                
                FVisableControlList.Remove(firstVisableCtl);

                // Show the overflow button when it has items. Because the "TooManyButtons" function will use it to calculate.
                if (FPrevOverflowItems.Count > 0)
                {
                    FPrevOverflowButton.Visibility = System.Windows.Visibility.Visible;
                }
                flpAddressBar.UpdateLayout();
            }
            #endregion

            #region Check the width and move the button into back overflow list
            while (TooManyButtons())
            {
                BreadCrumbButton lastVisableCtl = GetLastVisableControl();

                if (lastVisableCtl == null || lastVisableCtl == CurrentItem.OwnerButton)
                {
                    break;
                }

                FBackOverflowItems.Insert(0, lastVisableCtl.ItemObject);

                // remove our item from the normal bar
                lastVisableCtl.Visibility = System.Windows.Visibility.Collapsed;
                
                FVisableControlList.Remove(lastVisableCtl);

                // Show the overflow button when it has items. Because the "TooManyButtons" function will use it to calculate.
                if (FBackOverflowItems.Count > 0)
                {
                    FBackOverflowButton.Visibility = System.Windows.Visibility.Visible;
                    //flpAddressBar.Children.SetChildIndex(FBackOverflowButton, flpAddressBar.Controls.Count - 1);
                }
                flpAddressBar.UpdateLayout();
            }
            #endregion
            
        }

        private void OverflowItemMoveToButtonItem()
        {
            // Move the back overflow item to button first.
            if (FBackOverflowItems != null && FBackOverflowItems.Count > 0)
            {
                BreadCrumbButton preDisableCtl = FBackOverflowItems[0].OwnerButton;

                double overflowItemWidth = 0;
                double lastCtlWidth = 0;

                // Reduce the overflow button width when try to move the last item into bar.
                if (FBackOverflowItems.Count == 1)
                {
                    lastCtlWidth = GetRight(GetLastVisableControl());                    
                    overflowItemWidth = FBackOverflowButton.Width;
                }
                else
                {
                    lastCtlWidth = GetRight(FBackOverflowButton);
                }

                if (lastCtlWidth + preDisableCtl.Width - overflowItemWidth < flpAddressBar.DesiredSize.Width)
                {
                    ButtonShowInBar(preDisableCtl, FBackOverflowItems);

                    if (FBackOverflowItems.Count == 0)
                    {
                        HideOverflowButton(FBackOverflowButton);
                    }

                    OverflowItemMoveToButtonItem();
                }
            }
            else if (FPrevOverflowItems != null && FPrevOverflowItems.Count > 0)
            {
                BreadCrumbButton preDisableCtl = FPrevOverflowItems[0].OwnerButton;

                double overflowItemWidth = 0;
                double lastCtlWidth = 0;

                // Reduce the overflow button width when try to move the last item into bar.
                if (FPrevOverflowItems.Count == 1)
                {
                    overflowItemWidth = FPrevOverflowButton.Width;
                }

                if (FBackOverflowButton != null && FBackOverflowButton.Visibility == System.Windows.Visibility.Visible)
                {
                    lastCtlWidth = GetRight(FBackOverflowButton);
                }
                else
                {
                    lastCtlWidth = GetRight(GetLastVisableControl());
                }

                if (lastCtlWidth + preDisableCtl.Width - overflowItemWidth < flpAddressBar.DesiredSize.Width)
                {
                    ButtonShowInBar(preDisableCtl, FPrevOverflowItems);

                    if (FPrevOverflowItems.Count == 0)
                    {
                        HideOverflowButton(FPrevOverflowButton);
                    }

                    OverflowItemMoveToButtonItem();
                }
            }
        }
        #endregion

        private BreadCrumbButton CreateCommonButton(BreadCrumbItem aItem)
        {
            BreadCrumbButton item = new BreadCrumbButton(aItem, ItemCaptionField);

            //if (Items.Count == 0)
            //{
            //    //Home Button = [Icon + Text] 
            //    //Grid gridContent = new Grid();
            //    //ColumnDefinition col1 = new ColumnDefinition();
            //    //col1.Width = new GridLength(1, GridUnitType.Auto);
            //    //ColumnDefinition col2 = new ColumnDefinition();
            //    //col2.Width = new GridLength(1, GridUnitType.Auto);

            //    StackPanel contentPanel = new StackPanel();
            //    contentPanel.Orientation = Orientation.Horizontal;
            //    Image imgHome = new Image();
            //    imgHome.Width = 16;
            //    imgHome.Source = (ImageSource)this.Resources["qso_right_disable"];
            //    //imgHome.SetValue(Grid.ColumnProperty, 0);

            //    ContentPresenter actualContent = new ContentPresenter();
            //    actualContent.Content = aItem.Caption;

            //    contentPanel.Children.Add(imgHome);
            //    contentPanel.Children.Add(actualContent);

            //    item.TextButton.Content = contentPanel;
            //}
            //else
            //{
            //    item.TextButton.Content = aItem.Caption;
            //}
            //item.TextButton.Content = aItem.Caption;
            item.ShowDropDownButton = false;
            item.MaxTextWidth = ItemMaxTextWidth;
            //item.SetEditorWidth(GetTextSizeAtControl(aItem.Caption, item).Width);
            //item.Margin = new Padding(0);
            //item.BorderColor = this.ItemBorderColor;
            return item;
        }

        private BreadCrumbButton CreateMainItem(BreadCrumbItem aItem)
        {
            BreadCrumbButton item = CreateCommonButton(aItem);

            item.ClickTextButton += new RoutedEventHandler(MainItem_Click);
            item.EditValueChanged += new EditValueChangedEventHandler(SubItem_EditValueChanged);
            item.PopupOpening += new OpenPopupEventHandler(MainItem_QueryPopUp);
            item.LayoutUpdated += item_LayoutUpdated;
            item.SizeChanged += item_SizeChanged;
            return item;
        }

        void item_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        void item_LayoutUpdated(object sender, EventArgs e)
        {
            
        }

        private BreadCrumbItem ConvertToBreadCrumbItem(object aItem)
        {
            try
            {
                Type ItemType = aItem.GetType();

                //Get caption
                PropertyInfo captionInfo = ItemType.GetProperty(ItemCaptionField);
                object captionObj = captionInfo.GetValue(aItem, null);
                string caption = captionObj == null ? string.Empty : captionObj.ToString();

                //Get Data
                PropertyInfo dataInfo = ItemType.GetProperty(ItemDataField);
                object data = dataInfo.GetValue(aItem, null);

                //Get ChildList
                PropertyInfo childrenInfo = ItemType.GetProperty(ItemchildrenField);
                object childrenObj = childrenInfo.GetValue(aItem, null);
                BreadCrumbItemCollection innerChildren = null;

                //Get ParentList
                PropertyInfo parentChildrenInfo = ItemType.GetProperty(ItemParentChildrenField);
                object parentChildrenObj = parentChildrenInfo.GetValue(aItem, null);
                BreadCrumbItemCollection parentChildren = null;

                if (childrenObj != null)
                {
                    IEnumerable childrenAsEnumerable = childrenObj as IEnumerable;
                    if (childrenAsEnumerable != null)
                    {
                        innerChildren = new BreadCrumbItemCollection();
                        IEnumerator childrenEnumerator = childrenAsEnumerable.GetEnumerator();
                        while (childrenEnumerator.MoveNext())
                        {
                            BreadCrumbItem childItem = ConvertToBreadCrumbItem(childrenEnumerator.Current);
                            innerChildren.Add(childItem);
                        }
                    }
                }

               BreadCrumbItem newItem = new BreadCrumbItem(caption, data, innerChildren, aItem);

                if (parentChildrenObj != null)
                {
                    IEnumerable parentChildrenAsEnumerable = parentChildrenObj as IEnumerable;
                    if (parentChildrenAsEnumerable != null)
                    {
                        parentChildren = new BreadCrumbItemCollection();
                        IEnumerator childrenEnumerator = parentChildrenAsEnumerable.GetEnumerator();
                        while (childrenEnumerator.MoveNext())
                        {
                            BreadCrumbItem childItem = ConvertToBreadCrumbItem(childrenEnumerator.Current);
                            parentChildren.Add(childItem);
                        }
                    }

                    if (parentChildren != null && parentChildren.Count > 0)
                    {
                        newItem.ParentChildList = parentChildren;                        
                    }
                }


                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Convert Object To BreadCrumbItem fail.", ex);                
            }

        }

        private BreadCrumbButton ConvertToBreadCrumbButton(UIElement aCtl)
        {
            return (BreadCrumbButton)aCtl;
        }

        private void RemoveBarItemAfterIndex(int aAfterCtlIndex)
        {
            if (aAfterCtlIndex < 0 || aAfterCtlIndex >= flpAddressBar.Children.Count)
            {
                throw new ArgumentOutOfRangeException("The aStartIndex value is less than zero or is greater than or equal to the number of controls in the collection.");
            }

            for (int i = flpAddressBar.Children.Count - 1; i > aAfterCtlIndex; i--)
            {
                BreadCrumbButton item = ConvertToBreadCrumbButton(flpAddressBar.Children[i]);

                if (item != FBackOverflowButton)
                {
                    Items.Remove(item.ItemObject);
                }
            }
        }

        private BreadCrumbButton GetFirstVisableControl()
        {
            BreadCrumbButton firstCtl = null;

            int index = GetFirstVisableControlIndex();

            if (index != -1)
            {
                firstCtl = ConvertToBreadCrumbButton(flpAddressBar.Children[index]);
            }

            return firstCtl;
        }

        private int GetFirstVisableControlIndex()
        {
            int firstCtlIndex = -1;

            for (int i = 0; i < flpAddressBar.Children.Count; i++)
            {
                UIElement ctl = flpAddressBar.Children[i];
                if (ctl != FPrevOverflowButton)
                {
                    if (ctl.Visibility == System.Windows.Visibility.Visible)
                    {
                        firstCtlIndex = i;
                        break;
                    }
                }
            }

            return firstCtlIndex;
        }

        private BreadCrumbButton GetLastVisableControl()
        {
            BreadCrumbButton lastCtl = null;

            int index = GetLastVisableControlIndex();

            if (index != -1)
            {
                lastCtl = ConvertToBreadCrumbButton(flpAddressBar.Children[index]);
            }

            return lastCtl;
        }

        private int GetLastVisableControlIndex()
        {
            int lastCtlIndex = -1;

            for (int i = flpAddressBar.Children.Count - 1; i >= 0; i--)
            {
                UIElement ctl = flpAddressBar.Children[i];
                if (ctl != FPrevOverflowButton && ctl != FBackOverflowButton)
                {
                    if (ctl.Visibility == System.Windows.Visibility.Visible)
                    {
                        lastCtlIndex = i;
                        break;
                    }
                }
            }

            return lastCtlIndex;
        }

        private void AddMainItemIntoBar(BreadCrumbButton aMainItem)
        {
            flpAddressBar.Children.Add(aMainItem);
            FVisableControlList.Add(aMainItem);
        }

        private void HandleRemoveItem(BreadCrumbItem item)
        {
            flpAddressBar.Children.Remove(item.OwnerButton);
            if (FVisableControlList.Contains(item.OwnerButton) == true)
            {
                FVisableControlList.Remove(item.OwnerButton);
            }
            else if (FPrevOverflowItems != null && FPrevOverflowItems.Contains(item) == true)
            {
                RemoveOverflowItem(FPrevOverflowItems, item);
            }
            else if (FBackOverflowItems != null && FBackOverflowItems.Contains(item) == true)
            {
                RemoveOverflowItem(FBackOverflowItems, item);
            }
            GC.SuppressFinalize(item.OwnerButton);
            item.OwnerButton = null;
        }

        private void HandleAddItem(BreadCrumbItem item)
        {
            BeginChangingCurrentItem();
            try
            {
                CreateButtonIntoBar(item);

                CurrentItemIndex = this.Items.IndexOf(item);
            }
            finally
            {
                EndChangingCurrentItem();
            }
        }

        private void HandleAddRangeItems(BreadCrumbItemCollection aItemList)
        {
            BeginChangingCurrentItem();
            try
            {
                foreach (BreadCrumbItem item in aItemList)
                {
                    CreateButtonIntoBar(item);
                }

                CurrentItemIndex = this.Items.IndexOf(aItemList[aItemList.Count - 1]);
            }
            finally
            {
                EndChangingCurrentItem();
            }
        }

        private void RemoveTailItem()
        {
            for (int i = this.Items.Count - 1; i >= 0; i--)
            {
                if (this.Items[i].OwnerButton != null)
                {
                    if (this.Items[i].OwnerButton.IsTailItem == true)
                    {
                        this.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void ClearTailItemStyleBeforeIndex(int aIndex)
        {
            if (aIndex >= 0)
            {
                for (int i = aIndex; i >= 0; i--)
                {
                    if (this.Items[i].OwnerButton.IsTailItem == true)
                    {
                        this.Items[i].OwnerButton.IsTailItem = false;
                    }
                }
            }
        }

        private void ToTailItemStyleAfterIndex(int aIndex)
        {
            for (int i = aIndex + 1; i < this.Items.Count; i++)
            {
                this.Items[i].OwnerButton.IsTailItem = true;
            }
        }

        /// <summary>
        /// Updates the address bar
        /// </summary>
        private void CreateButtonIntoBar(BreadCrumbItem aItem)
        {
            BreadCrumbButton itemButton = CreateMainItem(aItem);

            AddMainItemIntoBar(itemButton);

            itemButton.SetDataSource(aItem.ChildList, aItem.SelectedChildItem);
        }

        private BreadCrumbItem CreateButtonIntoBar(object aItem)
        {
            BreadCrumbItem Item = ConvertToBreadCrumbItem(aItem);
            CreateButtonIntoBar(Item);
            return Item;
        }

        private void RefreshItemBorderColor()
        {
            foreach (Control ctl in flpAddressBar.Children)
            {
                if (ctl is BreadCrumbButton)
                {
                    ((BreadCrumbButton)ctl).BorderBrush = (Brush)brushConver.ConvertFrom(this.ItemBorderColor);
                }
            }
        }

        private void RefreshItemTextWidth()
        {
            foreach (Control ctl in flpAddressBar.Children)
            {
                if (ctl is BreadCrumbButton)
                {
                    ((BreadCrumbButton)ctl).MaxTextWidth = this.ItemMaxTextWidth;
                }
            }
        }

        private void AddHistoryAction(HistoryActionType aActionType, int aFocusItemIndex, BreadCrumbItemCollection aItemList)
        {
            HistoryAction action = new HistoryAction();
            action.ActionType = aActionType;
            action.FocusItemIndex = aFocusItemIndex;
            action.FocusItem = this.Items[aFocusItemIndex];
            action.ItemList = aItemList;

            // Remove history action which behind current action index.
            if (FCurrentHistoryIndex != C_HistoryInitIndex)
            {
                int startIndex = FCurrentHistoryIndex + 1;
                FHistory.RemoveRange(startIndex, FHistory.Count - startIndex);
            }

            // Remove overage history action.
            if (FHistory.Count == C_HistoryMaxCount)
            {
                FHistory.RemoveAt(0);
            }

            FHistory.Add(action);

            // The current history index must be the last action when the list has changed.
            FCurrentHistoryIndex = FHistory.Count - 1;

            DoHistoryActionChanged();
        }

        private void BegineUpdatingUI()
        {
            this.BeginInit();
        }

        private void EndUpdatingUI()
        {
            this.EndInit();
            this.UpdateLayout();
        }

        /// <summary>
        /// Go to current history action.
        /// UI refresh step:
        /// 1. Refresh BreadCrumbButton.
        /// 2. Raise HistoryAction changed event.
        /// 3. Raise BreadCrumbItem selection changed event.
        /// </summary>
        private void GoToCurrentHistoryAction()
        {
            this.BeginChangingCurrentItem();
            try
            {
                HistoryAction action = FHistory[FCurrentHistoryIndex];

                BegineUpdatingUI();
                try
                {
                    HistoryActionType actionType = action.ActionType;

                    // When the action type "ChangeFocus" will has ItemList?
                    // It only has ItemList when the next action type is "ChangeList".
                    if (actionType == HistoryActionType.ChangeFocus && action.ItemList != null)
                    {
                        actionType = HistoryActionType.ChangeList;
                    }

                    switch (action.ActionType)
                    {
                        case HistoryActionType.ChangeFocus:
                            this.CurrentItemIndex = action.FocusItemIndex;
                            break;
                        case HistoryActionType.ChangeList:
                            this.Items.Clear();
                            this.CurrentItemIndex = C_InvalidItemIndex;
                            this.InternalAddRangeItems(action.ItemList);
                            this.CurrentItemIndex = action.FocusItemIndex;
                            break;
                    }
                }
                finally
                {
                    EndUpdatingUI();
                }

                DoHistoryActionChanged();
            }
            finally
            {
                this.EndChangingCurrentItem();
            }
        }

        private BreadCrumbItemCollection CloneItemCollectionForHistoryAction()
        {
            BreadCrumbItemCollection result = new BreadCrumbItemCollection();

            foreach (BreadCrumbItem item in FItems)
            {
                BreadCrumbItem newItem = (BreadCrumbItem)item.Clone();

                //******************************************************************
                //-Edit by Rob Feng at Date: July 13, 2011
                //-Desc:
                /*
                 * In the history action, the BreadCrumbItem must a clone instance.
                 * Because we didnot want the history will affect by other code.
                 * 
                 * But the child list need use the smae refference,
                 * because the child list item didnot load complete at once.
                 */
                //-Source Code:
                if (item.ChildList != null)
                {
                    newItem.ChildList = item.ChildList;
                }
                //******************************************************************

                result.Add(newItem);
            }

            return result;
        }
        #endregion Private Section

        #region Protected Section

        protected void DoSelectionChanged(int aIndex)
        {
            OnSelectionChanged(aIndex);
        }

        protected void OnSelectionChanged(int aIndex)
        {
            if (SelectionChanged != null)
            {
                SelectionChangedArgs arg = new SelectionChangedArgs(aIndex);
                SelectionChanged(this, arg);
            }
        }

        protected void DoItemAdded(int aIndex, AddItemAction aAction)
        {
            OnItemAdded(aIndex, aAction);
        }

        protected void OnItemAdded(int aIndex, AddItemAction aAction)
        {
            if (ItemAdded != null)
            {
                ItemAddedArgs arg = new ItemAddedArgs(aIndex, aAction);
                ItemAdded(this, arg);
            }
        }

        protected void DoHistoryActionChanged()
        {
            OnHistoryActionChanged();
        }

        protected void OnHistoryActionChanged()
        {
            RaisePropertyChanged(C_CanGoToPreviousHistoryAction);
            RaisePropertyChanged(C_CanGoToNextHistoryAction);
            if (HistoryActionChanged != null)
            {
                HistoryActionChanged(this, EventArgs.Empty);
            }
        }

        protected void ClearBackOverflowData()
        {
            if (FBackOverflowButton != null && FBackOverflowItems != null)
            {
                ClearOverflowData(FBackOverflowButton, FBackOverflowItems);
            }
        }

        protected void ClearPreOverflowData()
        {
            if (FPrevOverflowButton != null && FPrevOverflowItems != null)
            {
                ClearOverflowData(FPrevOverflowButton, FPrevOverflowItems);
            }
        }

        protected void ClearAllControls()
        {           
            flpAddressBar.Children.Clear();
            FVisableControlList.Clear();

            ClearPreOverflowData();
            FPrevOverflowButton = null;

            ClearBackOverflowData();
            FBackOverflowButton = null;
        }

        protected void ClearOverflowData(BreadCrumbButton aButton, BreadCrumbItemCollection aOverflowItemList)
        {
            aOverflowItemList.Clear();
            aButton.EditValue = null;
            aButton.Visibility = System.Windows.Visibility.Collapsed;
        }

        protected virtual int InternalAddItem(string aCaption, object aData, BreadCrumbItemCollection aChildList)
        {
            return InternalAddItem(aCaption, aData, aChildList, null);
        }

        protected virtual int InternalAddItem(string aCaption, object aData, BreadCrumbItemCollection aChildList, object aActualObj)
        {
            BreadCrumbItem item = new BreadCrumbItem(aCaption, aData, aChildList, aActualObj);

            // Clear tail item before add the new item.
            RemoveTailItem();

            int index = this.Items.Add(item);
            try
            {
                HandleItemSourceCollectionChanged(ItemSource, false);
                IList sourceList = ItemSource as IList;
                if (sourceList != null)
                {
                    sourceList.Add(aActualObj);
                }
            }
            finally
            {
                HandleItemSourceCollectionChanged(ItemSource, true);
            }
            

            return index;
        }

        protected virtual void InternalAddRangeItems(BreadCrumbItemCollection aItemList)
        {
            // Clear tail item before add the new item.
            RemoveTailItem();

            this.Items.AddRange(aItemList);
        }     
        #endregion Protected Section

        #region Public Section        

        /// <summary>
        /// Add an item. Also will change the CurrentItemIndex to the index of the new item.
        /// </summary>
        /// <param name="aCaption">Item display caption.</param>
        /// <param name="aData">Store data.</param>
        /// <param name="aChildList">Child list for this new item.</param>
        /// <param name="aItemType">Ramark the item type.</param>
        public int AddItem(string aCaption, object aData, BreadCrumbItemCollection aChildList, string aItemType)
        {
            return AddItemWithChangeParentChildList(aCaption, aData, aChildList, aItemType, null, false);
        }

        /// <summary>
        /// Add an item. Also will change the CurrentItemIndex to the index of the new item.
        /// </summary>
        /// <param name="aCaption">Item display caption.</param>
        /// <param name="aData">Store data.</param>
        /// <param name="aChildList">Child list for this new item.</param>
        /// <param name="aItemType">Ramark the item type.</param>
        /// <param name="aParentChildList">Change Child list for it's parent item.</param>
        /// <param name="aAllowParentShowDorpDown">Whether allow parent button show popup window.</param>
        public int AddItemWithChangeParentChildList(string aCaption, object aData, BreadCrumbItemCollection aChildList, string aItemType, BreadCrumbItemCollection aParentChildList, bool aAllowParentShowDorpDown)
        {
            int newItemIndex = -1;

            newItemIndex = InternalAddItem(aCaption, aData, aChildList);

            this.Items[newItemIndex].ItemTypeText = aItemType;

            if (this.Items.Count > 1 && aParentChildList != null)
            {
                this.Items[newItemIndex - 1].ChildList = aParentChildList;
                this.Items[newItemIndex - 1].OwnerButton.SetDataSource(aParentChildList, this.Items[newItemIndex]);
                this.Items[newItemIndex - 1].AllowShowDorpDown = aAllowParentShowDorpDown;
            }

            DoItemAdded(newItemIndex, AddItemAction.AddItem);

            AddHistoryAction(HistoryActionType.ChangeList, newItemIndex, CloneItemCollectionForHistoryAction());

            return newItemIndex;
        }

        /// <summary>
        /// Add a batch item list. Also will change the CurrentItemIndex to the index of the last new item.
        /// </summary>
        public void AddRangeItems(BreadCrumbItemCollection aItemList)
        {
            InternalAddRangeItems(aItemList);

            AddHistoryAction(HistoryActionType.ChangeList, CurrentItemIndex, CloneItemCollectionForHistoryAction());
        }

        /// <summary>
        /// Removes the element at the specified index of the Items.
        /// The elements will not be remove which behide the specified index.
        /// </summary>
        public void DeleteItem(int aItemIndex)
        {
            this.Items.RemoveAt(aItemIndex);
        }

        public void SetChildList(int aItemIndex, BreadCrumbItemCollection aChildList, BreadCrumbItem aSelectedChild)
        {
            this.Items[aItemIndex].ChildList = aChildList;
            this.Items[aItemIndex].OwnerButton.SetDataSource(aChildList, aSelectedChild);
        }

        public void ClearData()
        {
            FItems.Clear();
            FCurrentItemIndex = C_InvalidItemIndex;

            ClearAllControls();

            FCurrentHistoryIndex = C_HistoryInitIndex;
            FHistory.Clear();
        }

        public void BeginChangingCurrentItem()
        {
            FChangingCurrentItem++;
        }

        /// <summary>
        /// Raise selection changed event after change completed.
        /// </summary>
        public void EndChangingCurrentItem()
        {
            FChangingCurrentItem = FChangingCurrentItem - 1;

            if (FChangingCurrentItem == 0)
            {
                // Raise selection changed event after change completed.
                DoSelectionChanged(FCurrentItemIndex);
            }
            else if (FChangingCurrentItem < 0)
            {
                throw new Exception("Call this function before calling BeginChangeCurrentItem.");
            }
        }

        public void GoToPreviousHistoryAction()
        {
            if (CanGoToPreviousHistoryAction == true)
            {
                FCurrentHistoryIndex--;

                GoToCurrentHistoryAction();
            }
        }

        public void GoToNextHistoryAction()
        {
            if (CanGoToNextHistoryAction == true)
            {
                FCurrentHistoryIndex++;

                GoToCurrentHistoryAction();
            }
        }

        #endregion Public Section

        #region Events
        private void FItems_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            BreadCrumbItem item = (BreadCrumbItem)e.Element;
            switch (e.Action)
            {
                case CollectionChangeAction.Add:
                    HandleAddItem(item);
                    break;
                case CollectionChangeAction.Refresh:
                    if (e.Element == null)
                    {
                        if (this.Items.Count > 0)
                        {
                            ClearAllControls();
                            // Refresh all buttons.
                            HandleAddRangeItems(this.Items);
                        }
                    }
                    else
                    {
                        throw new InvalidCastException("ucBreadCrumb FItems_CollectionChanged function didnot handle the refresh action for a element.");
                    }
                    break;
                case CollectionChangeAction.Remove:
                    HandleRemoveItem(item);
                    break;
            }
        }

        private void flpAddressBar_LayoutUpdated(object sender, EventArgs e)
        {
            if (flpAddressBar.Children.Count > 0)
            {
                if (Math.Abs(flpAddressBar.DesiredSize.Width - FOldWidth) > 0.1)
                {
                    if (flpAddressBar.DesiredSize.Width > FOldWidth)
                    {
                        OverflowItemMoveToButtonItem();
                    }
                    else if (flpAddressBar.DesiredSize.Width < FOldWidth)
                    {
                        ButtonItemMoveToOverflowItem();
                    }
                }
            }

            FOldWidth = flpAddressBar.DesiredSize.Width;
        }


        /// <summary>
        /// Handle click the BreadCrumbButton.
        /// 
        /// UI refresh step:
        /// 1. Refresh BreadCrumbButton immediately.
        /// 2. Raise BreadCrumbItem selection changed event.
        /// </summary>
        private void MainItem_Click(object sender, RoutedEventArgs e)
        {
            BreadCrumbButton item = (BreadCrumbButton)sender;

            int oldItemIndex = CurrentItemIndex;

            this.BeginChangingCurrentItem();
            try
            {
                this.BegineUpdatingUI();
                try
                {
                    CurrentItemIndex = this.Items.IndexOf(item.ItemObject);
                }
                finally
                {
                    this.EndUpdatingUI();
                }
            }
            finally
            {
                // Raise selection changed event even thought didnot changed index. This is our expect logic.
                this.EndChangingCurrentItem();
            }

            // No need add the action into history when the index didnot changed.
            if (oldItemIndex != CurrentItemIndex)
            {
                AddHistoryAction(HistoryActionType.ChangeFocus, CurrentItemIndex, null);
            }
        }

        /// <summary>
        /// Handle click the item at the popup window.
        /// 
        /// UI refresh step:
        /// 1. Refresh BreadCrumbButton immediately.
        /// 2. Raise BreadCrumbItem added event.
        /// 3. Raise BreadCrumbItem selection changed event.
        /// </summary>
        private void SubItem_EditValueChanged(object sender, EventArgs e)
        {
            //******************************************************************
            //-Edit by Rob Feng at Date: July 15, 2011
            //-Desc:
            /*
             * By default, if the history action type is "ChangeFocus" then it will store the item list.
             * But the action type "ChangeList" will change the item list, 
             *  so we need store the current item list to previous "ChangeFocus" action.
             */
            //-Source Code:
            if (FHistory.Count > 0)
            {
                HistoryAction preLastAction = FHistory[FHistory.Count - 1];
                if (preLastAction.ActionType == HistoryActionType.ChangeFocus)
                {
                    preLastAction.ItemList = CloneItemCollectionForHistoryAction();
                }
            }
            //******************************************************************

            BreadCrumbButton item = (BreadCrumbButton)sender;

            int newItemIndex = -1;

            this.BeginChangingCurrentItem();
            try
            {
                this.BegineUpdatingUI();
                try
                {
                    // Clear tail item style which before the current item. Beacuse the "InternalAddItem" function will remove all tail items.
                    ClearTailItemStyleBeforeIndex(this.Items.IndexOf(item.ItemObject));

                    // Remove bar item buttons which behind the current bar item button.
                    RemoveBarItemAfterIndex(flpAddressBar.Children.IndexOf(item));

                    // Remove all back overflow items.
                    ClearBackOverflowData();

                    newItemIndex = InternalAddItem(item.SelectedChildItem.Caption, item.SelectedChildItem.Data, null, item.SelectedChildItem.ActualObj);
                }
                finally
                {
                    this.EndUpdatingUI();
                }

                DoItemAdded(newItemIndex, AddItemAction.SubItem);
            }
            finally
            {
                this.EndChangingCurrentItem();
            }

            // Save the history action after added changed event raise, because we need store the child list.
            // Outside control owner just set the previous item's child list when added a new item.
            AddHistoryAction(HistoryActionType.ChangeList, newItemIndex, CloneItemCollectionForHistoryAction());
        }

        /// <summary>
        /// Handle click the item at over flow popup window.
        /// 
        /// UI refresh step:
        /// 1. Refresh BreadCrumbButton immediately.
        /// 2. Raise BreadCrumbItem selection changed event.
        /// </summary>
        private void OverflowButton_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            BreadCrumbButton editor = (BreadCrumbButton)sender;

            if (editor.EditValue != null)
            {
                if (editor.SelectedChildItem != null)
                {
                    BreadCrumbItem item = (BreadCrumbItem)editor.SelectedChildItem;

                    this.BeginChangingCurrentItem();
                    try
                    {
                        this.BegineUpdatingUI();
                        try
                        {
                            int newItemIndex = this.Items.IndexOf(item);

                            CurrentItemIndex = newItemIndex;

                            // Clear the selected data.
                            // The overflow button didnot want to remember the current selected data.
                            editor.EditValue = null;
                        }
                        finally
                        {
                            this.EndUpdatingUI();
                        }
                    }
                    finally
                    {
                        this.EndChangingCurrentItem();
                    }

                    AddHistoryAction(HistoryActionType.ChangeFocus, CurrentItemIndex, null);
                }
            }
        }

        private void MainItem_QueryPopUp(object sender, OpenPopupEventArgs e)
        {
            BreadCrumbButton editor = (BreadCrumbButton)sender;
            int index = this.Items.IndexOf(editor.ItemObject);
            RequestChildListArgs arg = new RequestChildListArgs(index, editor.ItemObject.ChildList);
            if (this.RequestChildList != null)
            {
                RequestChildList(this, arg);

                if (arg.Handled == true)
                {
                    editor.SetDataSource(arg.ChildList, editor.ItemObject.SelectedChildItem);
                }
            }
        }

        public void RaisePropertyChanged(string aPropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aPropName));
            }
        }
        #endregion Events

        
    }
  
}
