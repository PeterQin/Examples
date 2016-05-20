using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid.LookUp;
using System;
using System.Collections.Generic;
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
    ///     <MyNamespace:BreadCrumbButton/>
    ///
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("BreadCrumbButton: DisplayText:{DisplayText}")]
    [ToolboxItem(false)]
    public class BreadCrumbButton : LookUpEdit
    {
        static BreadCrumbButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadCrumbButton), new FrameworkPropertyMetadata(typeof(BreadCrumbButton)));
        }

        #region Field
        ResourceDictionary FImagesDictionary;
        private Image FDropDownImage;
        private BreadCrumbItem FItemObject = null;
        private ButtonInfo FTextButton = null;
        private ButtonInfo FDropDownButton = null;

        private bool FIsTailItem = false;
        private bool FMouseInHere = false;

        private int FArrowImageIndex = -1;
        private int FMaxTextWidth = 200;
        private int FTextWidth = -1;
        /// <summary>
        /// Make the value to false to change edit value, but didnot raise changed event.
        /// </summary>
        private bool FFireEditValueChanged = true;
        /// <summary>
        /// Set the value when press a button. Use for make the edit value whether is undoubted change.
        /// It will use for fix bellow bug:
        /// 1. Click "Text Button" will raise edit value changed problem.
        /// </summary>
        private bool FIsCorrectEditValueChange = true;
        /// <summary>
        /// Set the value when press a button. Use for make the current edit value.
        /// It will use for fix bellow bug:
        /// 1. Click "Text Button" will raise edit value changed problem.
        /// 2. Click current edit value in popup window still will raise edit value changed problem.
        /// </summary>
        private object FCorrectOldEditValue = null;

        #region Const / Enum / Delegate / Event
        private const int C_SpaceForBorder_HasDropDown = 7;
        private const int C_SpaceForBorder_NoDropDown = 2;

        public event RoutedEventHandler ClickTextButton;
        #endregion Const / Enum / Delegate / Event

        #region Property
        public ButtonInfo DropDownButton
        {
            get { return FDropDownButton; }
        }

        public int ArrowImageIndex
        {
            get { return FArrowImageIndex; }
            set
            {
                if (FArrowImageIndex != value)
                {
                    FArrowImageIndex = value;

                    switch (FArrowImageIndex)
                    {
                        case 0:
                            FDropDownImage.Source = (ImageSource)FImagesDictionary["qso_right"];
                            break;
                        case 1:
                            FDropDownImage.Source = (ImageSource)FImagesDictionary["qso_right_disable"];
                            break;
                        case 2:
                            FDropDownImage.Source = (ImageSource)FImagesDictionary["qso_down"];
                            break;
                        case 3:
                            FDropDownImage.Source = (ImageSource)FImagesDictionary["qso_down_disable"];
                            break;
                    }
                }
            }
        }

        public bool IsTailItem
        {
            get { return FIsTailItem; }
            set
            {
                if (FIsTailItem != value)
                {
                    FIsTailItem = value;
                    UpdateTextStyle();
                }
            }
        }

        public BreadCrumbItem ItemObject
        {
            get { return FItemObject; }
        }

        public ButtonInfo TextButton
        {
            get { return FTextButton; }
        }

        private bool FCanShowDropDown = false;
        public bool ShowDropDownButton
        {
            get
            {
                return FCanShowDropDown;
            }
            set
            {
                if (FCanShowDropDown != value)
                {
                    FCanShowDropDown = value;
                    FDropDownButton.Visibility = FCanShowDropDown ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                }

            }
        }

        public int MaxTextWidth
        {
            get { return FMaxTextWidth; }
            set
            {
                if (FMaxTextWidth != value)
                {
                    FMaxTextWidth = value;
                }
            }
        }

        public BreadCrumbItem SelectedChildItem
        {
            get
            {
                return this.EditValue as BreadCrumbItem;
            }
        }

        private string FCaptionDataMember;

        public string CaptionDataMember
        {
            get { return FCaptionDataMember; }
            set { FCaptionDataMember = value; }
        }

        #endregion Property

        #endregion Field

        #region Constructor & Destroyer
        public BreadCrumbButton(BreadCrumbItem aItem, string aCaptionField)
            : this(aItem)
        {
            CaptionDataMember = aCaptionField;
            FTextButton.SetBinding(ButtonInfo.ContentProperty, new Binding(CaptionDataMember) { Source = FItemObject.ActualObj });
        }

        public BreadCrumbButton(BreadCrumbItem aItem)
            : base()
        {
            FItemObject = aItem;
            aItem.OwnerButton = this;

            /*

            this.ShowWarningMessage = FItemObject.ShowWarningMessage;
            this.WarningMessage = FItemObject.WarningMessage;

             */

            FImagesDictionary = new ResourceDictionary();
            FImagesDictionary.Source = new Uri("pack://application:,,,/BreakCrumbTest;component/Themes/BreadCrumbImages.xaml");
            FTextButton = new ButtonInfo();

            //FDropDownButton = new ButtonInfo() {GlyphKind = GlyphKind.Right };
            FDropDownImage = new Image();
            FDropDownImage.Width = 10;
            FDropDownButton.GlyphKind = GlyphKind.User;
            FDropDownButton.Content = FDropDownImage;
            DropDownButton.Visibility = System.Windows.Visibility.Collapsed;
            this.AllowDefaultButton = false;
            this.ShowText = false;
            this.Buttons.Add(FTextButton);
            this.Buttons.Add(FDropDownButton);
            HideBody();
            ShowRightArrow();            

            this.AddHandler(Button.ClickEvent, new RoutedEventHandler(OnButtonClick));
            this.CustomDisplayText += BreadCrumbButton_CustomDisplayText;

            //if (FItemObject.ActualObj != null)
            //{
            //    INotifyPropertyChanged ObjProperty = FItemObject.ActualObj as INotifyPropertyChanged;
            //    ObjProperty.PropertyChanged += ObjProperty_PropertyChanged;
            //}

            
        }

        //~BreadCrumbButton()
        //{
        //    if (FItemObject.ActualObj != null)
        //    {
        //        INotifyPropertyChanged ObjProperty = FItemObject.ActualObj as INotifyPropertyChanged;
        //        ObjProperty.PropertyChanged -= ObjProperty_PropertyChanged;
        //    }
        //}

        //void ObjProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == CaptionDataMember)
        //    {
                
        //    }
        //}

        void BreadCrumbButton_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = string.Empty;
            e.Handled = true;
        }

        protected override ButtonInfoBase CreateDefaultButtonInfo()
        {
            FDropDownButton = (ButtonInfo)base.CreateDefaultButtonInfo();
            
            return FDropDownButton;
        }

        protected override void OnPopupClosed()
        {
            ShowRightArrow();
            base.OnPopupClosed();
        }

        protected override void OnPopupOpened()
        {
            ShowDownArrow();
            base.OnPopupOpened();
        }

        #endregion Constructor & Destroyer

        #region Private Section
        private void ShowBody()
        {
            this.ShowBorder = true;
        }

        private void HideBody()
        {
            if (this.IsPopupOpen == false && FMouseInHere == false)
            {
                this.ShowBorder = false;
            }
        }

        private void OnClickTextButtion(RoutedEventArgs e)
        {
            if (ClickTextButton != null)
            {
                ClickTextButton(this, e);
            }
        }

        private void SetWidth(int aWidth)
        {
            this.Width = aWidth;
        }

        private void UpdateTextStyle()
        {
            if (IsTailItem == true)
            {
                this.TextButton.Foreground = Brushes.Gray;
                this.DropDownButton.Foreground = Brushes.Gray;
            }
            else
            {
                this.TextButton.Foreground = this.Foreground;
                this.DropDownButton.Foreground = this.Foreground;
            }

            ShowRightArrow();
        }

        private void ShowRightArrow()
        {
            if (IsTailItem == false)
            {
                ArrowImageIndex = 0;
            }
            else
            {
                ArrowImageIndex = 1;
            }
        }

        private void ShowDownArrow()
        {
            if (IsTailItem == false)
            {
                ArrowImageIndex = 2;
            }
            else
            {
                ArrowImageIndex = 3;
            }
        }

        #endregion Private Section

        #region Protected Section

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);

        //    FMouseInHere = true;

        //    ShowBody();
        //}

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);

        //    FMouseInHere = false;

        //    HideBody();
        //}

        //protected override void OnPopupClosed(PopupCloseMode closeMode)
        //{
        //    base.OnPopupClosed(closeMode);

        //    ShowRightArrow();

        //    HideBody();
        //}

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        EditorButtonObjectInfoArgs info = this.ViewInfo.ButtonInfoByPoint(e.Location);

        //        if (info != null && info.Button == FDropDownButton)
        //        {
        //            if (this.ItemObject.AllowShowDorpDown == true)
        //            {
        //                ShowDownArrow();
        //            }
        //            else
        //            {
        //                // No need raise popup window.
        //                return;
        //            }
        //        }
        //    }

        //    base.OnMouseDown(e);
        //}

        //protected override void OnPressButton(EditorButtonObjectInfoArgs buttonInfo)
        //{
        //    //******************************************************************
        //    //-Edit by Rob Feng at Date: July 13, 2011
        //    //-Desc:
        //    /*
        //     * There is a issue that edit value will be changed by click a non-action button when showing popup window.
        //     *  And this may be is the DevExpress UI Logic.
        //     * 
        //     * For avoid this bug, we will rollback the edit value when press a button which did not as editor's action button.
        //     * 
        //     * How to do that:
        //     * 1. Store the correct edit value.
        //     * 2. Make the edit value change is not correct.
        //     */
        //    //-Source Code:
        //    FCorrectOldEditValue = this.EditValue;
        //    if (ShowDropDownButton == true)
        //    {
        //        if (buttonInfo.Button == FTextButton)
        //        {
        //            FIsCorrectEditValueChange = false;
        //        }
        //        else
        //        {
        //            FIsCorrectEditValueChange = true;
        //        }
        //    }
        //    //******************************************************************

        //    base.OnPressButton(buttonInfo);
        //}

        //protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        //{
        //    base.OnClickButton(buttonInfo);

        //    if (buttonInfo.Button == FTextButton)
        //    {
        //        OnClickTextButtion();
        //    }
        //}


        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button btnClicked = e.OriginalSource as Button;
            if (btnClicked != null && btnClicked.Content == FTextButton.Content)
            {
                 OnClickTextButtion(e);
            }
        }

        //protected override void OnEditValueChanging(ChangingEventArgs e)
        //{
        //    if (FIsCorrectEditValueChange == false)
        //    {
        //        //******************************************************************
        //        //-Edit by Rob Feng at Date: July 13, 2011
        //        //-Desc:
        //        /*
        //         * There is a issue that edit value will be changed by click a non-action button when showing popup window.
        //         *  And this may be is the DevExpress UI Logic.
        //         * 
        //         * For avoid this bug, we will rollback the edit value when press a button which did not as editor's action button.
        //         * 
        //         * How to do that:
        //         * 1. Make FireEditValueChanged to false, to not allow fire changed event.
        //         * 2. Set the new value back to the old edit value.
        //         */
        //        //-Source Code:
        //        FFireEditValueChanged = false;
        //        try
        //        {
        //            e.NewValue = FCorrectOldEditValue;
        //            base.OnEditValueChanging(e);
        //            FIsCorrectEditValueChange = true;
        //        }
        //        finally
        //        {
        //            FFireEditValueChanged = true;
        //        }
        //        //******************************************************************
        //    }
        //    else
        //    {
        //        base.OnEditValueChanging(e);
        //    }
        //}

        //protected override void OnEditValueChanged()
        //{
        //    if (FFireEditValueChanged == true)
        //    {
        //        // Raise evit value changed event only when the edit value is undoubted change.
        //        if (this.EditValue != FCorrectOldEditValue)
        //        {
        //            this.ItemObject.SelectedChildItem = this.SelectedItem;
        //            base.OnEditValueChanged();
        //        }
        //    }
        //}
        #endregion Protected Section

        #region Public Section

        public void SetDataSource(BreadCrumbItemCollection aDataSource)
        {
            if (this.ItemsSource != aDataSource)
            {
                this.ItemObject.ChildList = aDataSource;

                if (aDataSource != null)
                {
                    //******************************************************************
                    //-Edit by Rob Feng at Date: July 29, 2011
                    //-Desc:
                    /*
                     * We find that the "edit value will be changed by click a non-action button when showing popup window" problem.
                     *  Did not happen at all environments. 
                     * So we need to set back to correct change when change data source.
                     */
                    //-Source Code:
                    FIsCorrectEditValueChange = true;
                    //******************************************************************

                    this.ItemsSource = aDataSource;
                    //this.Properties.PopulateViewColumns();
                    this.DisplayMember = BreadCrumbItem.C_PN_Caption;
                    // No need define the value member, because we want the edit value is the BreadCrumbItem.
                    //this.Properties.ValueMember = BreadCrumbItem.C_PN_Data;

                    //foreach (GridColumn column in this.Properties.View.Columns)
                    //{
                    //    if (column.FieldName != this.Properties.DisplayMember)
                    //    {
                    //        column.Visible = false;
                    //    }
                    //}

                    //******************************************************************
                    //-Edit by Rob Feng at Date: Aug 1, 2011
                    //-Desc:
                    /*
                     * If the data source has reference object then allow show the drop down button.
                     * 
                     * Use this logic, outside user can set the child list at "GettingChildList" event.
                     */
                    //-Source Code:
                    /*
                    if (aDataSource.Count > 0)
                    {
                        ShowDropDownButton = true;
                    }
                    else
                    {
                        ShowDropDownButton = false;
                    }
                    */
                    //-Modified Code:
                    ShowDropDownButton = true;
                    //******************************************************************
                }
                else
                {
                    this.ItemsSource = aDataSource;
                    ShowDropDownButton = false;
                }
            }
        }

        public void SetDataSource(BreadCrumbItemCollection aDataSource, BreadCrumbItem aSelectedItem)
        {
            SetDataSource(aDataSource);

            FFireEditValueChanged = false;
            this.EditValue = aSelectedItem;
            this.ItemObject.SelectedChildItem = this.SelectedChildItem;
            FFireEditValueChanged = true;
        }
        #endregion Public Section

        #region Events
        //private void View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    GridView view = (GridView)sender;

        //    if (this.EditValue != null)
        //    {
        //        bool isSelectedRow = false;

        //        BreadCrumbItem editValue = (BreadCrumbItem)this.EditValue;
        //        BreadCrumbItem current = (BreadCrumbItem)view.GetRow(e.RowHandle);
        //        if (current.Caption == editValue.Caption)
        //        {
        //            isSelectedRow = true;
        //        }

        //        if (isSelectedRow == true)
        //        {
        //            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
        //        }
        //    }
        //}
        #endregion Events
    }
}
