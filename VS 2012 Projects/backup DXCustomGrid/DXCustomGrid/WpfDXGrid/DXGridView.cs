using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections;
using DevExpress.Xpf.Grid;

namespace WpfDXGrid
{
    public class DXGridView : DevExpress.Xpf.Grid.TableView
    {
        #region Field

        public event Action<int> OnDisplayedRowHandleChanged;
        //the row handle indicate which row is displayed on UI
        private bool FMustHasRowSelected = true;
        private bool FCalcSelectedListIndexesInGroup = true;
        private bool FIsInternalSelected = false;
        private int FDisplayedRowHandle;
        private object FDisplayedRow;
        #region Const / Enum / Delegate / Event
        #endregion Const / Enum / Delegate / Event

        #region Property

        /// <summary>
        /// Gets or sets a Handle indicating which row is display on UI.
        /// </summary>
        public int DisplayedRowHandle
        {
            get
            {
                return (int)GetValue(DisplayedRowHandleProperty);
            }
            set
            {
                SetValue(DisplayedRowHandleProperty, value);
                if (FDisplayedRowHandle != value)
                {
                    FDisplayedRowHandle = value;
                    if (OnDisplayedRowHandleChanged != null)
                    {
                        OnDisplayedRowHandleChanged(value);
                    }
                    if (FIsInternalSelected == false)
                    {
                        FocusedRowHandle = value;
                    }
                }
            }
        }

        // Using a DependencyProperty as the backing store for DisplayedRowHandle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayedRowHandleProperty =
            DependencyProperty.Register("DisplayedRowHandle", typeof(int), typeof(DXGridView), new PropertyMetadata(-2147483648));

        /// <summary>
        /// Gets or sets which row is display on UI.
        /// </summary>        
        public object DisplayedRow
        {
            get
            {
                return (object)GetValue(DisplayedRowProperty);
            }
            set
            {
                SetValue(DisplayedRowProperty, value);
                if (FDisplayedRow != value)
                {
                    FDisplayedRow = value;
                    if (FIsInternalSelected == false)
                    {
                        FocusedRow = value;
                    }
                }
            }
        }

        // Using a DependencyProperty as the backing store for DisplayedRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayedRowProperty =
            DependencyProperty.Register("DisplayedRow", typeof(object), typeof(DXGridView));



        public object test
        {
            get { return (object)GetValue(testProperty); }
            set { SetValue(testProperty, value); }
        }

        // Using a DependencyProperty as the backing store for test.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty testProperty =
            DependencyProperty.Register(
            "test", 
            typeof(object), 
            typeof(DXGridView), 
            new FrameworkPropertyMetadata(  null,
                                            FrameworkPropertyMetadataOptions.AffectsMeasure,
                                            new PropertyChangedCallback(OnCurrentReadingChanged),
                                            new CoerceValueCallback(CoerceCurrentReading)),
            new ValidateValueCallback(IsValidReading)
            
            );
        private static void OnCurrentReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DXGridView view = (DXGridView)d;
            if (view.FIsInternalSelected == false)
            {
                view.FocusedRow = e.NewValue;
                view.ClearSelection();
                view.SelectRow(view.FocusedRowHandle);
            }         

          //d.CoerceValue(MaxReadingProperty);
        }

        private static object CoerceCurrentReading(DependencyObject d, object value)
        {
          //Gauge g = (Gauge)d;
          //double current = (double)value;
          //if (current < g.MinReading) current = g.MinReading;
          //if (current > g.MaxReading) current = g.MaxReading;
          return value;
        }

        private static bool IsValidReading(object value)
        {
            //throw new NotImplementedException();
            return true;
        }




        private int FDisplayedRowListIndex;
        /// <summary>
        /// Gets and Sets a value indicate index on source list your want to display
        /// </summary>
        public int DisplayedRowListIndex
        {
            get { return (int)GetValue(DisplayedRowListIndexProperty); }
            set
            {
                SetValue(DisplayedRowListIndexProperty, value);
                if (FDisplayedRowListIndex != value)
                {
                    FDisplayedRowListIndex = value;
                    if (Grid != null)
                    {
                        int handle = Grid.GetRowHandleByListIndex(value);
                        if (FIsInternalSelected == false)
                        {
                            FocusedRowHandle = handle;
                        }
                    }
                }
            }
        }

        // Using a DependencyProperty as the backing store for DisplayedRowListIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayedRowListIndexProperty =
            DependencyProperty.Register("DisplayedRowListIndex", typeof(int), typeof(DXGridView), new PropertyMetadata(0));




        /// <summary>
        /// Gets or sets whether must has one row selected at least.
        /// </summary>
        /// <remarks>
        /// Default the selection rows can be zero when allow multiple select.
        /// 
        /// This property will keep the grid must has one row selected at least,
        ///  and the selected row is the focused row.
        /// </remarks>
        [Category("Quest")]
        [Description("Gets or sets whether must has one row selected at least.")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool MustHasRowSelected
        {
            get { return FMustHasRowSelected; }
            set
            {
                if (FMustHasRowSelected != value)
                {
                    FMustHasRowSelected = value;
                    CheckAndSetMustHasRowSelected();
                }
            }
        }

        /// <summary>
        /// Auto calculate selected list indexes include group child
        /// e.g. Select group A, then all child's list indexes under group A will in this list
        /// </summary>
        [Category("Quest")]
        [Description("Gets or sets whether auto calculate selected list indexes in group")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool CalcSelectedListIndexesInGroup
        {
            get
            {
                return FCalcSelectedListIndexesInGroup;
            }
            set
            {
                FCalcSelectedListIndexesInGroup = value;
            }
        }

        //
        // Summary:
        //     Gets selected List Indexes (include group child). This is a dependency property.
        public IList SelectedListIndexes
        {
            get
            {
                return (IList)GetValue(SelectedListIndexesProperty);
            }
            set
            {
                SetValue(SelectedListIndexesProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for SelectedListIndexes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedListIndexesProperty =
            DependencyProperty.Register("SelectedListIndexes", typeof(IList), typeof(DXGridView));


        private bool NeedAvoidFocuseRowChanged
        {
            get
            {
                bool result = false;

                if (this.MultiSelectMode != DevExpress.Xpf.Grid.TableViewSelectMode.None)
                {
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)
                            || Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        private static int InvalidRowHandle
        {
            get
            {
                return DevExpress.Xpf.Grid.GridControl.InvalidRowHandle;
            }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public DXGridView()
            : base()
        {

        }

        #endregion Constructor & Destroyer

        #region Private Section

        /// <summary>
        /// Check and set the current focused row as selected.
        /// </summary>
        /// <remarks>
        /// When will set to selected?
        /// 1. Return on FMustHasRowSelected field.
        /// 2. Current selected row count is zero.
        /// 3. Didnot in deleting row. (During delete the row, the focused row changed event will be raise.)
        /// </remarks>
        private void CheckAndSetMustHasRowSelected()
        {
            if (FMustHasRowSelected == true
                && this.GetSelectedRowHandles().Length == 0)
            {
                this.SelectRow(DisplayedRowHandle);
            }
        }

        #endregion Private Section

        #region Protected Section

        //Get all handles of child, grand child, great grand child..etc
        //Assume the argument must be group row. Caller should check.
        protected IEnumerable<int> GetOffspringRowHandles(int aStartGroupHandle)
        {
            int count = Grid.GetChildRowCount(aStartGroupHandle);
            for (int i = 0; i < count; i++)
            {
                int childHandle = Grid.GetChildRowHandle(aStartGroupHandle, i);
                if (Grid.IsGroupRowHandle(childHandle))
                {
                    foreach (int grandChildHandle in GetOffspringRowHandles(childHandle))
                    {
                        yield return grandChildHandle;
                    }
                }
                else if (Grid.IsValidRowHandle(childHandle))
                {
                    yield return childHandle;
                }

            }
        }

        /// <summary>
        /// this function have been moved to GridControl
        /// </summary>
        /// <param name="aRowHandle"></param>
        /// <returns></returns>
        protected int GetListIndexByRowHandle(int aRowHandle)
        {
            if (Grid != null)
            {
                return Grid.GetListIndexByRowHandle(aRowHandle);
            }
            return -1;
        }

        protected override void RaiseSelectionChanged(DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {
            base.RaiseSelectionChanged(e);
            if (NeedAvoidFocuseRowChanged == false)
            {
                FIsInternalSelected = true;
                try
                {
                    DisplayedRowHandle = FocusedRowHandle;
                    DisplayedRow = FocusedRowHandle < 0 ? null : Grid.GetRow(FocusedRowHandle);
                    DisplayedRowListIndex = FocusedRowHandle < 0 ? FocusedRowHandle : GetListIndexByRowHandle(FocusedRowHandle);

                }
                finally
                {
                    FIsInternalSelected = false;
                }

            }
            else
            {
                if (IsRowSelected(DisplayedRowHandle) == false && GetSelectedRowHandles().Length > 0)
                {
                    FIsInternalSelected = true;
                    try
                    {
                        if (GetSelectedRowHandles().Any(s => s >= 0))
                        {
                            DisplayedRowHandle = GetSelectedRowHandles().First(s => s >= 0);
                        }
                        else
                        {
                            DisplayedRowHandle = GetSelectedRowHandles().Last();
                        }
                        DisplayedRow = DisplayedRowHandle < 0 ? null : Grid.GetRow(DisplayedRowHandle);
                        DisplayedRowListIndex = DisplayedRowHandle < 0 ? DisplayedRowHandle : GetListIndexByRowHandle(DisplayedRowHandle);

                    }
                    finally
                    {
                        FIsInternalSelected = false;
                    }

                }
            }

            //Prepare Selected List Indexes
            if (CalcSelectedListIndexesInGroup)
            {
                SelectedListIndexes = GetSelectedListIndexes();
            }

            CheckAndSetMustHasRowSelected();

        }

        #endregion Protected Section

        #region Public Section

        public List<int> GetSelectedListIndexes()
        {
            List<int> Result = new List<int>();
            foreach (int item in GetSelectedRowHandlesInGroup())
            {
                Result.Add(Grid.GetListIndexByRowHandle(item));
            }
            Result.Sort(delegate(int a, int b)
            {
                return a.CompareTo(b) * -1;
            });
            return Result;
        }

        public List<int> GetSelectedRowHandlesInGroup()
        {
            List<int> Result = new List<int>();
            Dictionary<int, int> UniqueHandles = new Dictionary<int, int>();
            for (int i = 0; i < GetSelectedRowHandles().Length; i++)
            {
                int handle = GetSelectedRowHandles()[i];
                if (Grid.IsGroupRowHandle(handle))
                {
                    foreach (int offspring in GetOffspringRowHandles(handle))
                    {
                        UniqueHandles[offspring] = offspring;
                    }
                }
                else if (Grid.IsValidRowHandle(handle))
                {
                    UniqueHandles[handle] = handle;
                }
            }
            Result.AddRange(UniqueHandles.Keys);
            return Result;
        }
        #endregion Public Section

    }
}
