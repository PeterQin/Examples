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
    public delegate void OnSelectionChangedCoreEventHandler(int aRowHandle);
    public class DXGridView : DevExpress.Xpf.Grid.TableView
    {
        #region Field

        public event OnSelectionChangedCoreEventHandler OnSelectionChangedCore;
        private int FPrevDisplayedRow = InvalidRowHandle;

        private GridViewFocusedInfo FPreviousFocusedInfo = new GridViewFocusedInfo(int.MinValue, int.MinValue, int.MinValue, int.MinValue);
        private bool FMustHasRowSelected = true;
        private bool FCalcSelectedListIndexesInGroup = true;
        private bool FIsDeletingRow = false;
        private bool FChangeFocusByUserCancelSelected = false;
        private int FRowHandleBeforeAvoidFocuseChanged = DevExpress.Xpf.Grid.GridControl.InvalidRowHandle;
        private bool FHadCancelFocuseRowChanged = false;
        #region Const / Enum / Delegate / Event
        #endregion Const / Enum / Delegate / Event

        #region Property
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
                    //if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift && GridControl.Focused == true)
                    //    || ((Control.ModifierKeys & Keys.Control) == Keys.Control && GridControl.Focused == true))
                    //{
                    //    result = true;
                    //}
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
            FocusedRowChanged += DXGridView_FocusedRowChanged;
            FocusedRowHandleChanged += DXGridView_FocusedRowHandleChanged;
        }

        private void DXGridView_FocusedRowHandleChanged(object sender, FocusedRowHandleChangedEventArgs e)
        {
            if (FHadCancelFocuseRowChanged)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Check is it handled on OnFocusedRowHandleChangedCore
        /// case: Select child in group, there will be a FocusedRowChanged, 
        /// even I have not call  base.OnFocusedRowHandleChangedCore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DXGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (FHadCancelFocuseRowChanged)
            {
                e.Handled = true;
            }
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
                && this.GetSelectedRowHandles().Length == 0
                && FIsDeletingRow == false)
            {
                this.SelectRow(this.FocusedRowHandle);
            }
        }

        private void CreatePreviousFocuseInfo(int prevFocused, int focusedRowHandle)
        {
            //******************************************************************
            //-Edit by Rob Feng at Date: March 29, 2010
            //-Desc:
            //  Save old focuse information.
            //-Code:
            FPreviousFocusedInfo = new GridViewFocusedInfo(prevFocused, GetDataSourceCorrectRowIndex(prevFocused),
                focusedRowHandle, GetDataSourceCorrectRowIndex(focusedRowHandle));
            //******************************************************************
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

        //
        // Summary:
        //     Refreshes the specified row.
        //
        // Parameters:
        //   rowHandle:
        //     An integer value which identifies the row.
        protected void RefreshRow(int aHandle)
        {
            if (Grid != null)
            {
                Grid.RefreshRow(aHandle);
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

            if (FHadCancelFocuseRowChanged == true && NeedAvoidFocuseRowChanged == false)
            {
                //******************************************************************
                //-Edit by Rob Feng at Date: Dec 1, 2010
                //-Desc:
                /*
                 * Handle a special case when avoid focuse row changed event.
                 * 
                 * Case:
                 *  1. The grid has three rows that is Alt1,Alt2,Alt3.
                 *  2. Click to select Alt1.
                 *  3. Press Ctrl or Shift key to select those 3 rows.
                 *  4. Unselected Alt2. (Current focuse row is at Alt2)
                 *  5. Release key and then mouse Click to the Alt2.
                 * 
                 * This case result is the outside control cannot know current focused row had changed.
                 * 
                 * How to fix?
                 *  So we check the old focuse info with current focused row, if true then raise focuse event.
                 */
                //-Source Code:
                if (this.FocusedRowHandle == FPreviousFocusedInfo.FocusedRowHandle)
                {
                    FHadCancelFocuseRowChanged = false;
                    //RaiseFocusedRowChanged(FPreviousFocusedInfo.PrevFocusedRowHandle, FPreviousFocusedInfo.FocusedRowHandle);
                    OnFocusedRowHandleChangedCore(FPreviousFocusedInfo.PrevFocusedRowHandle);
                }
                //******************************************************************
            }
            else if (NeedAvoidFocuseRowChanged == true)
            {
                //******************************************************************
                //-Edit by Rob Feng at Date: Dec 15, 2010
                //-Desc:
                /*
                 * Handle 3 cases for cancel selected for the focus row which focus before press key "Ctrl" or "Shift".
                 * 
                 * Case 1:
                 *   Use "Ctrl" key to cancel selected.
                 *   --> Handle code is "e.Action == CollectionChangeAction.Remove" + "DoChangeFocusedRowInternal"
                 * 
                 * Case 2:
                 *   Use "Shift" key to cancel selected.
                 *   1. Left click to selected row "Alt2".
                 *   2. Press "Ctrl" to selected row "Alt3".
                 *   3. Press "Shift" to selected row "Alt5". (Then only 3, 4 and 5 have seleted)
                 *   --> Handle code is "e.Action == CollectionChangeAction.Refresh" + "DoChangeFocusedRowInternal"
                 * 
                 * Case 3:
                 *   Use "Shift" key to cancel selected.
                 *   1. Left click to selected row "Alt2".
                 *   2. Press "Ctrl" to selected row "Alt1".
                 *   3. Press "Shift" to selected row "Alt0". (Then only 1 and 0 have seleted)
                 *   --> Handle code is "e.Action == CollectionChangeAction.Refresh" + "RaiseFocusedRowChanged"
                 */
                //-Source Code:
                if (e.Action == CollectionChangeAction.Remove && e.ControllerRow == FRowHandleBeforeAvoidFocuseChanged
                    ||
                    e.Action == CollectionChangeAction.Refresh && this.IsRowSelected(FRowHandleBeforeAvoidFocuseChanged) == false)
                {
                    if (this.GetSelectedRowHandles().Length > 0)
                    {
                        FChangeFocusByUserCancelSelected = true;

                        if (this.FocusedRowHandle == this.GetSelectedRowHandles()[0])
                        {
                            // Code for Case 3.
                            // This function will cancel all selected row except the new focus row.
                            // So it only use when the current focus row is the new focus row.
                            //RaiseFocusedRowChanged(FPreviousFocusedInfo.FocusedRowHandle, this.GetSelectedRowHandles()[0]);
                            OnFocusedRowHandleChangedCore(FPreviousFocusedInfo.FocusedRowHandle);

                        }
                        else
                        {
                            // Code for Case 1 and 2.
                            // This function only work when current focus row is not the new focus row.
                            //DoChangeFocusedRowInternal(this.GetSelectedRowHandles()[0], true);
                            this.FocusedRowHandle = this.GetSelectedRowHandles()[0];
                        }
                    }
                }
                //******************************************************************
            }

            /*
             * Peter: move to UpdateRowsState()
             * Bease on WPF DXGrid RaiseSelectionChanged is fast than  OnFocusedRowHandleChangedCore
             * That means when you set the SelectRow to FocusedRow, the FocusedRow is the old Focused One
             * e.g.
             * 1) Press Ctrl and then select A1 and A2 (you will found grid is now focused on A2)
             * 2) Press Ctrl and Unselect A2 (Grid still focused on A2)
             * 3) Press Ctrl and Unselect A1
             * 4) CheckAndSetMustHasRowSelected() will Set A2 as selected, because A2 is now focused. FocuseChanged is later then SelectionChanged.
             */
            //CheckAndSetMustHasRowSelected();  
  
            //Prepare Selected List Indexes
            if (CalcSelectedListIndexesInGroup)
            {
                SelectedListIndexes = GetSelectedListIndexes();
            }            

        }

        /// <summary>
        /// Check when selected row count == 0
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateRowsState()
        {
            CheckAndSetMustHasRowSelected();
            return base.UpdateRowsState();
        }

        protected override void OnFocusedRowHandleChangedCore(int oldRowHandle)
        {

            if (FIsDeletingRow == true)
            {
                // Nothing to do. No need save the focus info.
                // Cancel raise focused row changed event during deleting row.
            }
            else if (NeedAvoidFocuseRowChanged && FChangeFocusByUserCancelSelected == false)
            {
                // Even though the focuse changed event is avoid, still save the focus info.
                CreatePreviousFocuseInfo(oldRowHandle, this.FocusedRowHandle);

                FHadCancelFocuseRowChanged = true;
                //Refresh row state
                RefreshRow(oldRowHandle);
                RefreshRow(this.FocusedRowHandle);
            }
            else
            {
                if (FHadCancelFocuseRowChanged == true)
                {
                    // Set the value to false, then no need the selection changed event to raise focuse changed event.
                    FHadCancelFocuseRowChanged = false;
                }

                if (FChangeFocusByUserCancelSelected == true)
                {
                    FChangeFocusByUserCancelSelected = false;
                }

                base.OnFocusedRowHandleChangedCore(oldRowHandle);

                CreatePreviousFocuseInfo(oldRowHandle, this.FocusedRowHandle);
                FRowHandleBeforeAvoidFocuseChanged = this.FocusedRowHandle;
            }

            CheckAndSetMustHasRowSelected();

        }
      
        
        #endregion Protected Section

        #region Public Section

        public int GetDataSourceCorrectRowIndex(int aRowHandle)
        {
            int dataSourceRowIndex = -1;

            if (aRowHandle < 0)
            {
                dataSourceRowIndex = -1;
            }
            else
            {
                //The reason why adding this variant as a parameter is that:
                //if focusedRowHandle < 0 the result of GetDataSourceRowIndex(focusedRowHandle) is 0;
                //but if the focusedRowHandle = 0 the result of GetDataSourceRowIndex(focusedRowHandle) is 0 too;
                //So using a variant to differ, or else it will cause unexpected problem.
                dataSourceRowIndex = this.GetListIndexByRowHandle(aRowHandle);
            }

            return dataSourceRowIndex;
        }

        /// <summary>
        /// Prevents the focus row changed event until the DevExpressGridView.EndDeleting() method is called.
        /// </summary>
        public void BeginDeleting()
        {
            FIsDeletingRow = true;

            //******************************************************************
            //-Edit by Rob Feng at Date: Jan 05, 2011
            //-Desc:
            /*
             * Set the previou focus info to a invalid row handle.
             * At "EndDeleting" function, it will raise the focused row changed event,
             *  and outside control will use the previou focus info to check whether need refresh data for new focused row.
             */
            //-Source Code:
            CreatePreviousFocuseInfo(this.FocusedRowHandle, InvalidRowHandle);
            //******************************************************************
        }

        /// <summary>
        /// Enables the focus row changes event after calling the DevExpressGridView.BeginDeleting() method and forces an immediate update.
        /// </summary>
        public void EndDeleting()
        {
            if (FIsDeletingRow == true)
            {
                //Change value first. For allow raise focus row change and auto set seleted row.
                FIsDeletingRow = false;

                if (this.IsRowSelected(this.FocusedRowHandle) == true)
                {
                    //RaiseFocusedRowChanged(FPreviousFocusedInfo.PrevFocusedRowHandle, this.FocusedRowHandle);
                    OnFocusedRowHandleChangedCore(FPreviousFocusedInfo.PrevFocusedRowHandle);
                }
                else
                {
                    //******************************************************************
                    //-Edit by Rob Feng at Date: Jan 05, 2011
                    //-Desc:
                    // Base on the focus row changed event will be raise when delete at data source with column sorting.
                    // Case 1:
                    //  1. Sorting the column.
                    //  2. Delete row by data source.
                    //  3. Result: selected at deleted row, but focused row is at different row.
                    //-Source Code:
                    if (this.SelectedRows.Count > 0)
                    {
                        //DoChangeFocusedRow(DevExpress.XtraGrid.GridControl.InvalidRowHandle, this.GetSelectedRows()[0], true);
                        //RaiseFocusedRowChanged(InvalidRowHandle, this.GetSelectedRowHandles()[0]);
                        this.FocusedRowHandle = this.GetSelectedRowHandles()[0];
                    }
                    else
                    {
                        //DoChangeFocusedRow(InvalidRowHandle, this.FocusedRowHandle, true);
                        //RaiseFocusedRowChanged(InvalidRowHandle, this.FocusedRowHandle);
                        OnFocusedRowHandleChangedCore(InvalidRowHandle);                        
                    }
                    //******************************************************************
                }
            }
        }

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

        #region Events
        #endregion Events

        #region FocusedInfo

        /// <summary>
        /// Define the View previously and current focus information.
        /// </summary>
        [System.Diagnostics.DebuggerDisplay("GridViewFocusedInfo: Pre[Handle:{PrevFocusedRowHandle} Index:{DataSourceRowIndexByPrevFocused}] Cur[Handle:{FocusedRowHandle} Index:{DataSourceRowIndexByFocused}]")]
        private class GridViewFocusedInfo
        {
            private int fPrevFocusedRowHandle;
            private int fDataSourceRowIndexByPrevFocused;
            private int fFocusedRowHandle;
            private int fDataSourceRowIndexByFocused;

            public int PrevFocusedRowHandle
            {
                get { return fPrevFocusedRowHandle; }
            }

            public int DataSourceRowIndexByPrevFocused
            {
                get { return fDataSourceRowIndexByPrevFocused; }
            }

            public int FocusedRowHandle
            {
                get { return fFocusedRowHandle; }
            }

            public int DataSourceRowIndexByFocused
            {
                get { return fDataSourceRowIndexByFocused; }
            }

            public GridViewFocusedInfo(int aPrevFocusedRowHandle, int aDataSourceRowIndexByPrevFocused, int aFocusedRowHandle, int aDataSourceRowIndexByFocused)
            {
                fPrevFocusedRowHandle = aPrevFocusedRowHandle;
                fDataSourceRowIndexByPrevFocused = aDataSourceRowIndexByPrevFocused;
                fFocusedRowHandle = aFocusedRowHandle;
                fDataSourceRowIndexByFocused = aDataSourceRowIndexByFocused;
            }
        }
        #endregion FocusedInfo

    }    
}
