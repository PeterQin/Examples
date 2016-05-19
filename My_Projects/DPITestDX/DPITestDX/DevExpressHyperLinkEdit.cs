using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;

namespace DPITestDX
{
    public enum TDisplayMode
    {
        /// <summary>
        /// Default is Quest mode.
        /// </summary>
        Default,
        /// <summary>
        /// In Quest mode.
        /// 1. The edit will allow auto size.
        /// </summary>
        Quest,
        /// <summary>
        /// In DevExpress mode.
        /// 1. The edit will not allow auto size.
        /// </summary>
        DevExpress
    }

    public enum TFontLineStyle
    {
        /// <summary>
        /// Show line when mouse on the text, hide line when mouse leave.
        /// </summary>
        AutoUnderline = 0,
        UserFont = 1
    }


    /// <summary>
    /// A text editor with hyperlink functionality.
    /// </summary>
    /// <remarks>
    /// 1.Can't use event CustomDisplayText when DisplayMode is TDisplayMode.Default or TDisplayMode.Quest.
    ///     You can use event CustomInnerLableDisplayText instead. 
    /// </remarks>
    public partial class DevExpressHyperLinkEdit : HyperLinkEdit, IUseCustomFont
    {
        #region Field
        protected DevExpress.XtraEditors.LabelControl lblText;
        private TDisplayMode FDisplayMode = TDisplayMode.Default;
        private TFontLineStyle FFontLineStyle = TFontLineStyle.AutoUnderline;
        private HorzAlignment FPreviousImageAlignemnt = HorzAlignment.Default;
        private bool FShowHighlightColorInLable = false;
        private int FImageSpace = 3;
        /// <summary>
        /// Just for save font  FontFamilyName and Size.
        /// </summary>
        private Font FUnderLineFont = DefaultFont;
        private Font FOldFont = null;
        /// <summary>
        /// Left Property.Buttons width.
        /// </summary>
        protected int FLeftButtonsWidth = -1;
        /// <summary>
        /// Right Property.Buttons width.
        /// </summary>
        protected int FRightButtonsWidth = -1;
        /// <summary>
        /// Array of each left property.Buttons width.
        /// </summary>
        protected int[] FLeftButtonsWidthArr = new int[0];
        /// <summary>
        /// Array of each right property.Buttons width.
        /// </summary>
        protected int[] FRightButtonsWidthArr = new int[0];
        private bool FIsSettingLoaded = false;
        private bool FIsInnerUpdate = false;
        private bool FIsPreviousUseFont = false;
        private bool FIsFirstResize = true;
        private bool FAutoSize = false;
        private bool FInnerControlResizing = false;
        private Color FBackColorOnPaint = Color.Empty;
        private bool FHasSetToHasFocus = false;
        private bool FToolTipOnlyWhenTextEllipsis = false;
        private Color FUnderLineForeColor = Color.Transparent;
        private Color FForeColor = Color.Empty;
        private bool FShowUnderLineWhenEdit = true;

        #region Const / Delegate / Enum
        /// <summary>
        /// The min editor size allow show the image. No include the property buttons.
        /// </summary>
        protected const int C_MaxHasImageWidth = 34;
        protected const int C_ControlSpace = 3;
        protected const int C_ImageMinWidth = 15;

        /// <summary>
        /// Enables custom display text to be provided for an inner lable.
        /// </summary>    
        [Category("Events")]
        [Description("Enables custom display text to be provided for an inner lable.")]
        public event CustomDisplayTextEventHandler CustomInnerLableDisplayText;
        #endregion Const / Delegate / Enum

        #region Property

        /// <summary>
        /// Gets or sets the editor display style. Default is Quest mode.
        /// </summary>
        [Category("Quest")]
        [Description("Gets or sets the editor display style. Default is Quest mode.")]
        [DefaultValue(TDisplayMode.Default)]
        [Bindable(true)]
        public TDisplayMode DisplayMode
        {
            get { return FDisplayMode; }
            set
            {
                FDisplayMode = value;

                ResetInnerControl();
            }
        }

        /// <summary>
        /// Gets or sets the editor display font line style.
        /// </summary>
        [Category("Quest")]
        [Description("Gets or sets the editor display font line style.")]
        [DefaultValue(TFontLineStyle.AutoUnderline)]
        [Bindable(true)]
        public TFontLineStyle FontLineStyle
        {
            get { return FFontLineStyle; }
            set
            {
                FFontLineStyle = value;

                RefreshFontLineStyle();
            }
        }

        /// <summary>
        /// Gets or sets the editor's value.
        /// </summary>
        public override object EditValue
        {
            get
            {
                return base.EditValue;
            }
            set
            {
                base.EditValue = value;

                if (string.IsNullOrEmpty(Properties.Caption) == false)
                {
                    this.SetLabelText(Properties.Caption);
                }
                else
                {
                    this.SetLabelText(value + "");
                }
            }
        }

        /// <summary>
        /// Gets or sets the background color of an enabled editor.
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                RefreshLabelBackColor();
            }
        }

        /// <summary>
        /// Gets or sets the editor content's foreground color.
        /// </summary>
        [Category("Quest")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                FForeColor = value;
                base.ForeColor = value;
                lblText.ForeColor = value;
                RefreshFontLineStyle();
            }
        }

        /// <summary>
        /// Gets or sets the editor content's foreground color when display under line. Default is use the ForeColor.
        /// </summary>
        [Category("Quest")]
        [Description("Gets or sets the editor content's foreground color when display under line. Default is use the ForeColor.")]
        [DefaultValue(typeof(Color), "Transparent")]
        public Color UnderLineForeColor
        {
            get
            {
                if (DesignMode == false)
                {
                    if (FUnderLineForeColor != Color.Transparent)
                    {
                        return this.FUnderLineForeColor;
                    }
                    else
                    {
                        return this.ForeColor;
                    }
                }
                else
                {
                    return this.FUnderLineForeColor;
                }
            }
            set
            {
                if (this.FUnderLineForeColor != value)
                {
                    this.FUnderLineForeColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the font used to display editor contents.
        /// </summary>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                FOldFont = value;
                InnerControlResize();
            }
        }

        /// <summary>
        /// Gets or sets the label whether display a height color when focus.
        /// </summary>
        [Category("Quest")]
        [Description("Gets or sets the label whether display a height color when focus.")]
        [DefaultValue(false)]
        [Bindable(true)]
        public bool ShowHighlightColorInLable
        {
            get { return FShowHighlightColorInLable; }
            set
            {
                FShowHighlightColorInLable = value;
                if (value == true)
                {
                    CheckShowHeightColor();
                }
                else
                {
                    this.lblText.BackColor = TrueColor(this.BackColor);
                }
            }
        }

        [Category("Quest")]
        [Description("Gets or sets the space between Image and Text.")]
        [DefaultValue(3)]
        [Bindable(true)]
        public int ImageSpace
        {
            get { return FImageSpace; }
            set
            {
                FImageSpace = value < 0 ? 0 : value;
                InnerControlResize();
            }
        }

        /// <summary>
        /// Inner LabelControl
        /// </summary>
        [Browsable(false)]
        public LabelControl InnerLable
        {
            get
            {
                return lblText;
            }
        }

        /// <summary>
        /// Whether the control had loaded before it is displayed for the first time.
        /// </summary>  
        [Bindable(false)]
        public bool IsLoaded
        {
            get { return FIsSettingLoaded; }
        }

        public Size TextSize
        {
            get
            {
                return GetTextSize(this.EditValue + "");
            }
        }

        private bool UseQuestMode
        {
            get
            {
                return FDisplayMode == TDisplayMode.Default || FDisplayMode == TDisplayMode.Quest;
            }
        }

        /// <summary>
        /// Gets the true color of the parent.
        /// </summary>
        protected Color ParentBackColor
        {
            get
            {
                Color result = Color.Empty;
                if (Parent != null)
                {
                    Control pCtl = Parent;
                    do
                    {
                        result = pCtl.BackColor;
                        pCtl = pCtl.Parent;
                    } while (result == Color.Transparent && pCtl != null);
                }
                return result;
            }
        }

        protected int ImageWidth
        {
            get
            {
                return C_ImageMinWidth + ImageSpace;
            }
        }

        /// <summary>
        /// Auto size when LabelStyle is True and WordWrap is False.
        /// </summary>
        [Category("Quest")]
        [Description("Auto size when DisplayMode is TDisplayMode.Quest.")]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                if (FIsLoaaded == false)
                {
                    return false;
                }
                else
                {
                    return FAutoSize;
                }
            }
            set
            {
                FAutoSize = value;
                ResetInnerControl();
            }
        }

        /// <summary>
        /// Gets or sets a regular tooltip's content.
        /// </summary>
        public override string ToolTip
        {
            get
            {
                return base.ToolTip;
            }
            set
            {
                base.ToolTip = value;
                lblText.ToolTip = value;
            }
        }

        /// <summary>
        /// Gets or sets whether a tooltip should be displayed when the mouse pointer is over the control.
        /// </summary>
        public override bool ShowToolTips
        {
            get
            {
                return base.ShowToolTips;
            }
            set
            {
                if (FToolTipOnlyWhenTextEllipsis == false)
                {
                    base.ShowToolTips = value;
                }
            }
        }

        public override SuperToolTip SuperTip
        {
            get
            {
                return base.SuperTip;
            }
            set
            {
                base.SuperTip = value;
                lblText.SuperTip = value;
            }
        }

        /// <summary>
        /// Gets or sets the tooltip whether only show when text ellipsis.
        /// </summary>
        [Category("Quest")]
        [Description("Gets or sets the tooltip whether only show when text ellipsis.")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool ToolTipOnlyWhenTextEllipsis
        {
            get { return FToolTipOnlyWhenTextEllipsis; }
            set
            {
                if (FToolTipOnlyWhenTextEllipsis != value)
                {
                    FToolTipOnlyWhenTextEllipsis = value;

                    if (FToolTipOnlyWhenTextEllipsis == true)
                    {
                        base.ShowToolTips = false;
                        lblText.ShowToolTips = false;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the size that is the upper limit that System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size) can specify.
        /// </summary>
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                if (base.MaximumSize != value)
                {
                    base.MaximumSize = value;
                    InnerControlResize();
                }
            }
        }

        /// <summary>
        /// Gets or sets the size that is the lower limit that System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size) can specify.
        /// </summary>
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                if (base.MinimumSize != value)
                {
                    base.MinimumSize = value;
                    InnerControlResize();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether use under line style when edit text.
        /// </summary>
        [Category("Quest")]
        [Description("Gets or sets a value indicating whether use under line style when edit text.")]
        [DefaultValue(true)]
        public bool ShowUnderLineWhenEdit
        {
            get { return FShowUnderLineWhenEdit; }
            set { FShowUnderLineWhenEdit = value; }
        }

        /// <summary>
        /// Get display text of the edit.
        /// </summary>
        [Browsable(false)]
        public string ActualDisplayText
        {
            get
            {
                if (UseQuestMode == true)
                {
                    return this.InnerLable.Text;
                }
                else
                {
                    return this.Text;
                }
            }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer
        public DevExpressHyperLinkEdit()
        {
            InitializeComponent();
            InitInnerControl();
            Cursor = Cursors.Hand;
            Properties.StartKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
        }

        public DevExpressHyperLinkEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitInnerControl();
            Cursor = Cursors.Hand;
            Properties.StartKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
        }
        #endregion Constructor & Destroyer

        #region Private Section

        private Size GetTextSize(string aText)
        {
            SizeF sf;
            using (Graphics g = this.CreateGraphics())
            {
                sf = g.MeasureString(aText, this.Font);
            }
            Size result = new Size(Convert.ToInt32(Math.Round(new decimal(sf.Width), MidpointRounding.AwayFromZero)) + 5,
                Convert.ToInt32(Math.Round(new decimal(sf.Height), MidpointRounding.AwayFromZero)));

            return result;
        }

        private void BeginInnerUpdate()
        {
            FIsInnerUpdate = true;
        }

        private void EndInnerUpdate()
        {
            FIsInnerUpdate = false;
        }

        private void InitInnerControl()
        {
            FForeColor = base.ForeColor;

            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.AutoEllipsis = true;
            this.lblText.AutoSizeMode = LabelAutoSizeMode.None;
            this.Controls.Add(lblText);
            this.lblText.BringToFront();

            lblText.MouseDown += new MouseEventHandler(lblText_MouseDown);
            lblText.MouseEnter += new EventHandler(lblText_MouseEnter);
            lblText.MouseLeave += new EventHandler(lblText_MouseLeave);
            lblText.MouseUp += new MouseEventHandler(lblText_MouseUp);
            lblText.Click += new EventHandler(lblText_Click);

            this.CustomDisplayText += new CustomDisplayTextEventHandler(DevExpressHyperLinkEdit_CustomDisplayText);
            this.Properties.Appearance.Changed += new EventHandler(Properties_Appearance_Changed);
            this.Properties.Buttons.CollectionChanged += new CollectionChangeEventHandler(Properties_Buttons_CollectionChanged);
            this.Properties.PropertiesChanged += new EventHandler(Properties_PropertiesChanged);

            ResetInnerControl();
        }

        private void ResetInnerControl()
        {
            this.lblText.Visible = UseQuestMode;
            if (UseQuestMode && AutoSize)
            {
                if (lblText.AutoSizeMode != LabelAutoSizeMode.Default)
                {
                    this.lblText.AutoSizeMode = LabelAutoSizeMode.Default;
                    InnerControlResize();
                }
            }
            else if (lblText.AutoSizeMode != LabelAutoSizeMode.None)
            {
                this.lblText.AutoSizeMode = LabelAutoSizeMode.None;
                InnerControlResize();
            }
        }

        private void AutoResize()
        {
            if (AutoSize == true)
            {
                InnerControlResize();
            }
        }

        /// <summary>
        /// Refresh the innser control location and size.
        /// </summary>
        private void InnerControlResize()
        {
            if (FInnerControlResizing == true)
            {
                return;
            }

            FInnerControlResizing = true;
            if (UseQuestMode)
            {
                if (this.Properties.Image != null && FPreviousImageAlignemnt == HorzAlignment.Center)
                {
                    //No need display label.
                    lblText.Visible = false;
                }
                else
                {
                    lblText.Visible = true;

                    int imageSpace = -1;
                    int emptySpaceWidth = -1;
                    int labelAutoSizeWidth = -1;
                    int labelAutoSizeHeight = -1;

                    //******************************************************************
                    //-Edit by Rob Feng at Date: March 07, 2011
                    //-Desc:
                    /*
                     * Set to auto size for calculate the label best width.
                     * And rollback to none after calculate completed.
                     */
                    //-Source Code:
                    this.lblText.AutoSizeMode = LabelAutoSizeMode.Default;
                    labelAutoSizeWidth = lblText.PreferredSize.Width;
                    labelAutoSizeHeight = lblText.PreferredSize.Height;
                    //******************************************************************

                    #region 1.Lable Left(Location.X)
                    //Image space
                    if (this.Properties.Image != null && (this.Width >= FLeftButtonsWidth + C_MaxHasImageWidth + FRightButtonsWidth || AutoSize))
                    {
                        switch (FPreviousImageAlignemnt)
                        {
                            case HorzAlignment.Default:
                            case HorzAlignment.Near:
                                imageSpace = ImageWidth;

                                //When auto size then Image will always show.
                                // So when the text width is smaller than 8 and imageSpace is smaller than 24, then set the min 24 image space.
                                if (AutoSize && lblText.Width <= 8 && imageSpace < 24)
                                {
                                    imageSpace = 24;
                                }
                                break;
                            case HorzAlignment.Far:
                                imageSpace = 0;
                                break;
                        }

                        lblText.Left = imageSpace + C_ControlSpace;
                    }
                    else
                    {
                        lblText.Left = C_ControlSpace;
                    }

                    //Left button space
                    if (this.Width > FLeftButtonsWidth + FRightButtonsWidth + 1)
                    {
                        lblText.Left += FLeftButtonsWidth;
                    }
                    else if (FLeftButtonsWidthArr.Length > 1)
                    {
                        int accumulator = 0;
                        foreach (int tempWidth in FLeftButtonsWidthArr)
                        {
                            accumulator += tempWidth;
                            if (this.Width > FRightButtonsWidth + FLeftButtonsWidth - accumulator + 1)
                            {
                                //excess buttons width.
                                lblText.Left += FLeftButtonsWidth - accumulator;
                                break;
                            }
                        }
                    }
                    #endregion

                    #region 2.Lable Top(Location.Y)
                    // Set the height first before calculate top.
                    lblText.Height = labelAutoSizeHeight;

                    if (this.Height > lblText.Height)
                    {
                        lblText.Top = (this.Height / 2 + this.Height % 2) - (lblText.Height / 2 + lblText.Height % 2);
                    }
                    #endregion

                    #region 3.Lable Width
                    int tempButtonsWidth = 0;
                    //Right button width
                    if (this.Width > FRightButtonsWidth + 1)
                    {
                        tempButtonsWidth = FRightButtonsWidth;
                    }
                    else if (FRightButtonsWidthArr.Length > 1)
                    {
                        int accumulator = 0;
                        foreach (int tempWidth in FRightButtonsWidthArr)
                        {
                            accumulator += tempWidth;
                            if (this.Width > FRightButtonsWidth - accumulator + 1)
                            {
                                //excess buttons width.
                                tempButtonsWidth = FRightButtonsWidth - accumulator;
                                break;
                            }
                        }
                    }

                    emptySpaceWidth = this.Width - lblText.Left - tempButtonsWidth - C_ControlSpace;

                    //If image is display alignemnt in far and it is display in UI, then subtract its width.
                    if (FPreviousImageAlignemnt == HorzAlignment.Far && imageSpace != -1)
                    {
                        emptySpaceWidth -= ImageWidth;
                    }
                    #endregion

                    #region 4.Check who follow who width.
                    bool editorFllowLabelWidth = false;

                    if (AutoSize == true)
                    {
                        this.lblText.AutoSizeMode = LabelAutoSizeMode.Default;
                        labelAutoSizeWidth = lblText.PreferredSize.Width;

                        editorFllowLabelWidth = true;

                        //******************************************************************
                        //-Edit by Rob Feng at Date: March 3, 2011
                        //-Desc:
                        /*
                         * If the label size > max or < min then the editor cannot follow its size,
                         * So canncel the label auto size and ask the label follow the editor size.
                         */
                        //-Source Code:
                        if (this.MinimumSize.IsEmpty == false)
                        {
                            if (this.MinimumSize.Width >= 0 && labelAutoSizeWidth < this.MinimumSize.Width)
                            {
                                editorFllowLabelWidth = false;
                            }
                        }

                        if (this.MaximumSize.IsEmpty == false)
                        {
                            if (this.MaximumSize.Width >= 0 && labelAutoSizeWidth > this.MaximumSize.Width)
                            {
                                editorFllowLabelWidth = false;
                            }
                        }
                        //******************************************************************

                        if (editorFllowLabelWidth == false)
                        {
                            // Cancel label autosize when it fllow the editor width.
                            this.lblText.AutoSizeMode = LabelAutoSizeMode.None;
                        }
                    }
                    else
                    {
                        // Rollback the setting after calculate the label best width.
                        this.lblText.AutoSizeMode = LabelAutoSizeMode.None;
                    }
                    #endregion

                    if (editorFllowLabelWidth == true)
                    {
                        // Editor follow the label width. Make the label has best width.
                        this.Width += labelAutoSizeWidth - emptySpaceWidth + 2;

                        if (FToolTipOnlyWhenTextEllipsis == true)
                        {
                            base.ShowToolTips = false;
                            lblText.ShowToolTips = false;
                        }
                    }
                    else
                    {
                        // Label follow the editor width. Maybe the lable string is truncated.
                        lblText.Width = emptySpaceWidth;

                        if (FToolTipOnlyWhenTextEllipsis == true)
                        {
                            if (labelAutoSizeWidth > emptySpaceWidth)
                            {
                                base.ShowToolTips = true;
                                lblText.ShowToolTips = true;
                            }
                            else
                            {
                                base.ShowToolTips = false;
                                lblText.ShowToolTips = false;
                            }
                        }
                    }
                }
            }
            FInnerControlResizing = false;
        }

        private void CheckShowHeightColor()
        {
            if (ShowHighlightColorInLable == true)
            {
                if (this.Focused)
                {
                    this.lblText.BackColor = System.Drawing.SystemColors.Highlight;
                }
                else
                {
                    this.lblText.BackColor = TrueColor(this.BackColor);
                }

                CancelForeColorWhenDisabled();
            }
        }

        /// <summary>
        /// If the color is Transparent then return the parent back color.
        /// </summary>
        private Color TrueColor(Color aColor)
        {
            if (aColor == Color.Transparent)
            {
                return ParentBackColor;
            }
            return aColor;
        }

        /// <summary>
        /// the disable color will not gray when use fore color.
        /// So we need set the UseForeColor to false when the control is disabled.
        /// That means the fore color will not work when the control is disable.
        /// </summary>
        private void CancelForeColorWhenDisabled()
        {
            if (this.lblText.Enabled == true)
            {
                // The lblText control must use fore color, because its default fore color is not the blue color.
                this.lblText.Appearance.Options.UseForeColor = true;
                if (this.Properties.Appearance.Options.UseForeColor == true)
                {
                    if (this.Properties.Appearance.ForeColor != Color.Empty)
                    {
                        this.lblText.ForeColor = this.Properties.Appearance.ForeColor;
                    }
                    else
                    {
                        this.lblText.ForeColor = this.ForeColor;
                    }
                }
                else
                {
                    this.lblText.ForeColor = this.ForeColor;
                }
            }
            else
            {
                this.lblText.Appearance.Options.UseForeColor = false;
            }
        }

        private void RefreshLabelBackColor()
        {
            this.lblText.BackColor = TrueColor(this.BackColor);

            //******************************************************************
            //-Edit by Rob Feng at Date: March 2, 2011
            //-Desc:
            /*
             * If the label back color is Empty, that means the editor didnot has parent this time.
             * So we need change back the FSelfBackColor value to Empty and let it reset at OnPaintBackground.
             */
            //-Source Code:
            if (this.lblText.BackColor == Color.Empty)
            {
                this.FBackColorOnPaint = Color.Empty;
            }
            //******************************************************************

            CheckShowHeightColor();
        }

        private void RefreshFontLineStyle()
        {
            BeginInnerUpdate();
            switch (FFontLineStyle)
            {
                case TFontLineStyle.AutoUnderline:
                    if (this.Properties.Appearance.Options.UseFont == true)
                    {
                        FOldFont = this.Properties.Appearance.Font;
                    }
                    else
                    {
                        FOldFont = this.Font;
                    }
                    this.Properties.Appearance.Font = FUnderLineFont;
                    Properties.Appearance.Options.UseFont = true;
                    break;
                case TFontLineStyle.UserFont:
                    Properties.Appearance.Options.UseFont = FIsPreviousUseFont;
                    this.Properties.Appearance.Font = FOldFont;
                    break;
            }
            EndInnerUpdate();
        }
        #endregion Private Section

        #region Protected Section

        protected bool SetLabelText(string aText)
        {
            bool result = false;

            if (string.IsNullOrEmpty(aText) == false)
            {
                // Fix the inner label control cannot display "&" char problem.
                //  Label control need use double '&' to display a '&' char.
                aText = aText.Replace("&", "&&");
            }

            if (lblText.Text != aText)
            {
                lblText.Text = aText;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Refresh all property.buttons width.
        /// </summary>
        protected void RefreshButtonsWidth()
        {
            List<int> editorLeftButtonsWidths = new List<int>();
            List<int> editorRightButtonsWidths = new List<int>();

            ButtonEditViewInfo buttonEditViewInfo = this.ViewInfo;

            if (IsLoaded == false)
            {
                if (DesignMode == true)
                {
                    FIsSettingLoaded = true;
                }

                //Only to init HyperLinkEditViewInfo data of the first time,
                // otherwise throw a overflow exception.
                buttonEditViewInfo.Bounds = new Rectangle(0, 0, int.MaxValue, int.MaxValue);
                buttonEditViewInfo.CalcViewInfo(null);
            }

            foreach (EditorButton editorButton in this.Properties.Buttons)
            {
                if (editorButton.Visible == true)
                {
                    EditorButtonObjectInfoArgs editorButtonObjectInfoArgs = null;

                    editorButtonObjectInfoArgs = buttonEditViewInfo.ButtonInfoByButton(editorButton);

                    if (editorButtonObjectInfoArgs == null)
                    {
                        MethodInfo methodInfo = typeof(ButtonEditViewInfo).GetMethod("CreateButtonInfo", BindingFlags.NonPublic | BindingFlags.Instance);
                        object objEditorButtonObjectInfoArgs = methodInfo.Invoke(buttonEditViewInfo, new object[] { editorButton, 0 });

                        editorButtonObjectInfoArgs = objEditorButtonObjectInfoArgs as EditorButtonObjectInfoArgs;
                    }

                    if (editorButtonObjectInfoArgs != null)
                    {
                        if (editorButton.IsLeft == true)
                        {
                            editorLeftButtonsWidths.Add(editorButtonObjectInfoArgs.Bounds.Width);
                        }
                        else
                        {
                            editorRightButtonsWidths.Add(editorButtonObjectInfoArgs.Bounds.Width);
                        }
                    }
                }
            }

            FLeftButtonsWidthArr = editorLeftButtonsWidths.ToArray();
            FRightButtonsWidthArr = editorRightButtonsWidths.ToArray();

            FLeftButtonsWidth = 0;
            foreach (int width in FLeftButtonsWidthArr)
            {
                FLeftButtonsWidth += width;
            }

            FRightButtonsWidth = 0;
            foreach (int width in FRightButtonsWidthArr)
            {
                FRightButtonsWidth += width;
            }

            InnerControlResize();
        }

        protected override void CheckMouseCursorShape(Point pt)
        {
            base.CheckMouseCursorShape(pt);

            if (this.Cursor == Cursors.Default && FontLineStyle != TFontLineStyle.AutoUnderline)
                Cursor.Current = Cursors.Default;
        }

        protected virtual void DoCustomInnerLableDisplayText()
        {
            if (CustomInnerLableDisplayText != null)
            {
                CustomDisplayTextEventArgs arg = new CustomDisplayTextEventArgs(EditValue, lblText.Text);
                CustomInnerLableDisplayText(this, arg);

                this.SetLabelText(arg.DisplayText);
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            //******************************************************************
            //-Edit by Rob Feng at Date: Sep 06, 2011
            //-Desc:
            /*
             * Should refresh the inner control when the hyper link edit had changed layout.
             */
            //-Source Code:
            InnerControlResize();
            //******************************************************************
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            RefreshLabelBackColor();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            RefreshLabelBackColor();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (FHasSetToHasFocus == false)
            {
                //******************************************************************
                //-Edit by Rob Feng at Date: March 02, 2011
                //-Desc:
                /*
                 * The editor only get the correct transparent color when start paint the backgroud.
                 * So the label need reget the correct color at this time.
                 */
                //-Source Code:
                if (FBackColorOnPaint == Color.Empty)
                {
                    //Mark whether already get the correct color.
                    FBackColorOnPaint = TrueColor(this.BackColor);
                }

                if (this.FBackColorOnPaint != this.lblText.BackColor)
                {
                    RefreshLabelBackColor();
                }
                //******************************************************************
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (FontLineStyle == TFontLineStyle.AutoUnderline)
            {
                if (DesignMode == false)
                {
                    Cursor.Current = lblText.Cursor = Cursors.Hand;
                    Properties.Appearance.Font = new Font(FUnderLineFont, FontStyle.Underline);
                    lblText.ForeColor = this.UnderLineForeColor;
                }
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (FontLineStyle == TFontLineStyle.AutoUnderline)
            {
                if (DesignMode == false)
                {
                    Cursor.Current = lblText.Cursor = Cursors.Default;
                    Properties.Appearance.Font = FOldFont;
                    Properties.Appearance.Options.UseFont = true;
                    lblText.ForeColor = this.ForeColor;
                }
            }
            base.OnMouseLeave(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            this.FHasSetToHasFocus = false;
            CheckShowHeightColor();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            CheckShowHeightColor();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.lblText.Enabled = this.Enabled;

            //the disable color will not gray when use fore color.
            CancelForeColorWhenDisabled();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            AutoResize();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (FIsSettingLoaded == false)
            {
                FIsSettingLoaded = true;

                // Set the correct settings to label.
                FPreviousImageAlignemnt = Properties.ImageAlignment;

                FOldFont = this.Font;

                // Save current font style.
                FUnderLineFont = FOldFont;

                #region Set Value to Label
                lblText.Font = this.Font;
                lblText.ForeColor = this.ForeColor;
                lblText.Cursor = this.Cursor;
                lblText.BorderStyle = BorderStyles.NoBorder;
                if (string.IsNullOrEmpty(Properties.Caption) == false)
                {
                    this.SetLabelText(Properties.Caption);
                }
                else
                {
                    this.SetLabelText(this.Text);
                }
                #endregion
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (FIsFirstResize == true)
            {
                FIsFirstResize = false;
                //After loaded UI then refresh buttons width and label location.
                RefreshButtonsWidth();
            }
        }

        protected override void UpdateMaskBoxProperties(bool always)
        {
            base.UpdateMaskBoxProperties(always);

            if (ShowUnderLineWhenEdit == false)
            {
                MaskBox.Font = new Font(Properties.Appearance.Font, Properties.Appearance.Font.Style);
            }
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //CustomFontUtil.Unsubscribe(this);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion Protected Section

        #region Public Section
        /// <summary>
        /// Get the editor hit info.
        /// </summary>
        public DevExpress.XtraEditors.ViewInfo.EditHitInfo HitInfo(Point p)
        {
            DevExpress.XtraEditors.ViewInfo.HyperLinkEditViewInfo viewInfo = null;
            DevExpress.XtraEditors.ViewInfo.EditHitInfo hitInfo = null;

            viewInfo = this.Properties.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.HyperLinkEditViewInfo;
            viewInfo.Bounds = this.ClientRectangle;
            using (Graphics g = this.CreateGraphics())
            {
                viewInfo.CalcViewInfo(g);
            }
            hitInfo = viewInfo.CalcHitInfo(p);

            return hitInfo;
        }

        /// <summary>
        /// Draw the focus color even though the editor didnot has focus.
        /// </summary>
        public void SetToHasFocus()
        {
            this.lblText.BackColor = Color.FromArgb(122, 150, 223);

            this.FHasSetToHasFocus = true;
        }

        public void UseCustomFont(CustomFontUserType type, Font newFont)
        {
            if (!this.IsDisposed)
            {
                //FUnderLineFont = CustomFontUtil.GetUnderlinedFont(CustomFontUserType.DataGrid, this);
                this.Font =
                this.Properties.Appearance.Font = newFont;
                this.Properties.Appearance.Options.UseFont = true;
            }
        }

        #endregion Public Section

        #region Events
        private void DevExpressHyperLinkEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (UseQuestMode)
            {
                string oldText = lblText.Text;

                this.SetLabelText(e.DisplayText);

                DoCustomInnerLableDisplayText();

                if (oldText != lblText.Text)
                {
                    AutoResize();
                }

                //Set the HyperLinkEdit not display text.
                e.DisplayText = string.Empty;
            }
        }

        private void Properties_PropertiesChanged(object sender, EventArgs e)
        {
            if (FIsInnerUpdate == false)
            {
                //When image alignment change then reset button width.
                if (FPreviousImageAlignemnt != Properties.ImageAlignment)
                {
                    FPreviousImageAlignemnt = Properties.ImageAlignment;
                    RefreshButtonsWidth();
                }
            }
        }

        private void Properties_Appearance_Changed(object sender, EventArgs e)
        {
            if (FIsInnerUpdate == false)
            {
                FIsPreviousUseFont = Properties.Appearance.Options.UseFont;
                if (Properties.Appearance.Options.UseFont == false)
                {
                    //lblText.Font = new Font(DefaultFont, FontStyle.Underline);
                    lblText.Font = new Font(this.Font, FontStyle.Underline);
                }
                else
                {
                    lblText.Font = this.Properties.Appearance.Font;
                }

                if (FUnderLineFont != lblText.Font)
                {
                    FUnderLineFont = new Font(lblText.Font.FontFamily.Name, lblText.Font.Size);
                }

                //******************************************************************
                //-Edit by Rob Feng at Date: May 30, 2010
                //-Desc:
                //  Handle Properties's Appearance fore color change will not call this.ForeColor problem.
                //  So check and update fore color after the Appearance changed.
                //-Source Code:
                if (lblText.ForeColor != this.ForeColor)
                {
                    lblText.ForeColor = this.ForeColor;

                    //the disable color will not gray when use fore color.
                    CancelForeColorWhenDisabled();
                }
                //******************************************************************
            }
        }

        private void Properties_Buttons_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            RefreshButtonsWidth();
        }

        private void lblText_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lblText_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void lblText_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Focus();
            }
        }

        private void lblText_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void lblText_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }
        #endregion Events

        private bool FIsLoaaded = false;
        protected override void OnLoaded()
        {
            base.OnLoaded();

            if (FIsLoaaded == false)
            {
                FIsLoaaded = true;
                InnerControlResize();
            }
        }
    }


    public enum CustomFontUserType
    {
        None,
        SQLTextEditor,
        DataGrid,
        Report,
    }

    public interface IUseCustomFont
    {
        void UseCustomFont(CustomFontUserType type, Font f);
    }
}