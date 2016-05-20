using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCrumbTest
{
    [System.Diagnostics.DebuggerDisplay("BreadCrumbItem: Caption:{Caption}")]
    public class BreadCrumbItem : ICloneable
    {
        #region Field
        private string FCaption = string.Empty;
        private object FActualObj;
        private object FData = null;
        private BreadCrumbItemCollection FChildList = null;
        private BreadCrumbItemCollection FParentChildList = null;
        private BreadCrumbButton FOwnerButton = null;
        private BreadCrumbItem FSelectedChildItem = null;
        private bool FAllowShowDorpDown = true;
        private bool FIsChildListLoadedCompleted = false;
        private bool FShowWarningMessage = false;
        private string FWarningMessage = string.Empty;
        private string FItemTypeText = string.Empty;

        #region Const / Enum / Delegate / Event
        public const string C_PN_Caption = "Caption";
        public const string C_PN_Data = "Data";
        #endregion Const / Enum / Delegate / Event

        #region Property
        public BreadCrumbButton OwnerButton
        {
            get { return FOwnerButton; }
            set { FOwnerButton = value; }
        }

        public string Caption
        {
            get { return FCaption; }
            set { FCaption = value; }
        }

        public object Data
        {
            get { return FData; }
        }

        /// <summary>
        /// Mark the represent object
        /// </summary>
        public object ActualObj
        {
            get { return FActualObj; }
        }


        public BreadCrumbItemCollection ChildList
        {
            get { return FChildList; }
            set { FChildList = value; }
        }

        public BreadCrumbItemCollection ParentChildList
        {
            get { return FParentChildList; }
            set { FParentChildList = value; }
        }

        /// <summary>
        /// This property, Gets use when AddRangeItem, Sets when the dropdown list change selected item.
        /// </summary>
        public BreadCrumbItem SelectedChildItem
        {
            get { return FSelectedChildItem; }
            set { FSelectedChildItem = value; }
        }

        public bool AllowShowDorpDown
        {
            get { return FAllowShowDorpDown; }
            set
            {
                if (FAllowShowDorpDown != value)
                {
                    FAllowShowDorpDown = value;
                }
            }
        }

        public bool IsChildListLoadedCompleted
        {
            get { return FIsChildListLoadedCompleted; }
            set { FIsChildListLoadedCompleted = value; }
        }

        public string WarningMessage
        {
            get { return FWarningMessage; }
            set
            {
                if (FWarningMessage != value)
                {
                    FWarningMessage = value;

                    //if (OwnerButton != null)
                    //{
                    //    OwnerButton.WarningMessage = FWarningMessage;
                    //}
                }
            }
        }

        public bool ShowWarningMessage
        {
            get { return FShowWarningMessage; }
            set
            {
                if (FShowWarningMessage != value)
                {
                    FShowWarningMessage = value;

                    //if (OwnerButton != null)
                    //{
                    //    OwnerButton.ShowWarningMessage = FShowWarningMessage;
                    //}
                }
            }
        }

        public string ItemTypeText
        {
            get { return FItemTypeText; }
            set { FItemTypeText = value; }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer
        public BreadCrumbItem(string aCaption, object aData, BreadCrumbItemCollection aChildList, object aActualObj)
            : this(aCaption, aData, aChildList, true)
        {
            FActualObj = aActualObj;
        }

        public BreadCrumbItem(string aCaption, object aData, BreadCrumbItemCollection aChildList)
            : this(aCaption, aData, aChildList, true)
        {
        }

        public BreadCrumbItem(string aCaption, object aData, BreadCrumbItemCollection aChildList, bool aAllowShowDorpDown)
        {
            FCaption = aCaption;
            FData = aData;
            FChildList = aChildList;
            FAllowShowDorpDown = aAllowShowDorpDown;
        }
        public BreadCrumbItem(string aCaption, object aData, BreadCrumbItemCollection aChildList, bool aAllowShowDorpDown, object aActualObj)
            :this(aCaption, aData, aChildList, aAllowShowDorpDown)
        {
            FActualObj = aActualObj;            
        }
        #endregion Constructor & Destroyer

        #region Public Section
        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is BreadCrumbItem)
            {
                BreadCrumbItem item = (BreadCrumbItem)obj;

                if (item.Caption == this.Caption
                    && object.Equals(item.Data, this.Data))
                {
                    result = true;
                }
            }

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Caption;
        }
        #endregion

        #region ICloneable Members

        public object Clone()
        {
            object data = null;
            BreadCrumbItemCollection childList = null;
            object actualobj = null;

            if (this.Data != null)
            {
                if (this.Data is ICloneable)
                {
                    data = ((ICloneable)Data).Clone();
                }
                else
                {
                    data = this.Data;
                }
            }


            if (this.ChildList != null)
            {
                childList = (BreadCrumbItemCollection)this.ChildList.Clone();
            }

            if (this.ActualObj != null)
            {
                if (this.ActualObj is ICloneable)
                {
                    actualobj = ((ICloneable)ActualObj).Clone();
                }
                else
                {
                    actualobj = this.ActualObj;
                }
            }

            BreadCrumbItem newInstance = new BreadCrumbItem(this.Caption, data, childList, this.AllowShowDorpDown, actualobj);

            if (this.SelectedChildItem != null)
            {
                newInstance.SelectedChildItem = (BreadCrumbItem)this.SelectedChildItem.Clone();
            }            

            newInstance.ItemTypeText = this.ItemTypeText;

            return newInstance;
        }

        #endregion
    }
}
