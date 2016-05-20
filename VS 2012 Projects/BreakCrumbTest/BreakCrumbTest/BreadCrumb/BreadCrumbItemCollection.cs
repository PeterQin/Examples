using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BreakCrumbTest
{
    [ListBindable(false)]
    [System.Diagnostics.DebuggerDisplay("BreadCrumbItemCollection: Count:{Count}")]
    public class BreadCrumbItemCollection : System.Collections.CollectionBase, ICloneable
    {
        #region Field
        private Hashtable indexes;
        private int lockUpdate;
        private Control FParentControl;
        private BreadCrumbItem FLastItem = null;
        private BreadCrumbItem FFirstItem = null;

        #region Const / Enum / Delegate / Event
        private const int C_RegetFirstAndLastItem = -1;

        public event CollectionChangeEventHandler CollectionChanged;
        #endregion Const / Enum / Delegate / Event

        #region Property
        protected virtual Hashtable Indexes
        {
            get
            {
                return this.indexes;
            }
        }

        protected bool IsLockUpdate
        {
            get
            {
                return (this.lockUpdate != 0);
            }
        }

        public Control ParentControl
        {
            get { return FParentControl; }
        }

        [Description("Gets or sets an item at the specified position.")]
        public BreadCrumbItem this[int index]
        {
            get
            {
                return (BreadCrumbItem)base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }

        public BreadCrumbItem FirstItem
        {
            get { return FFirstItem; }
        }

        public BreadCrumbItem LastItem
        {
            get { return FLastItem; }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer
        public BreadCrumbItemCollection(Control aParent)
            : this()
        {
            FParentControl = aParent;
        }

        public BreadCrumbItemCollection()
        {
            this.indexes = new Hashtable();
            this.lockUpdate = 0;
        }

        public BreadCrumbItemCollection(BreadCrumbItemCollection aCollection)
            : this()
        {
            AddRange(aCollection);
        }
        #endregion Constructor & Destroyer

        #region Private Section
        private void RefreshFirstOrLastItem(int aIndex)
        {
            if (aIndex == -1)
            {
                FFirstItem = null;
                FLastItem = null;

                if (this.Count > 0)
                {
                    FFirstItem = this[0];
                    FLastItem = this[this.Count - 1];
                }
            }
            else
            {
                if (aIndex == 0)
                {
                    FFirstItem = this[aIndex];
                }

                if (this.Count > 0 && aIndex == this.Count - 1)
                {
                    FLastItem = this[aIndex];
                }
            }
        }
        #endregion Private Section

        #region Protected Section

        protected override void OnClearComplete()
        {
            this.Indexes.Clear();

            RefreshFirstOrLastItem(C_RegetFirstAndLastItem);

            this.RaiseCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        protected override void OnInsertComplete(int index, object item)
        {
            if (index != (base.Count - 1))
            {
                this.Indexes.Clear();
            }
            else if (item != null)
            {
                this.Indexes[item] = base.Count - 1;
            }

            if (this.Indexes.Count > 0)
            {
                RefreshFirstOrLastItem((int)this.Indexes[item]);
            }

            this.RaiseCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
        }

        protected override void OnRemoveComplete(int index, object item)
        {
            if (index != base.Count)
            {
                this.Indexes.Clear();
            }
            else if (item != null)
            {
                this.Indexes.Remove(item);
            }

            RefreshFirstOrLastItem(C_RegetFirstAndLastItem);

            this.RaiseCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, item));
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            if (oldValue != null)
            {
                this.Indexes.Remove(oldValue);
            }

            if (newValue != null)
            {
                this.Indexes[newValue] = index;
            }

            RefreshFirstOrLastItem((int)this.Indexes[newValue]);

            this.RaiseCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, newValue));
        }

        protected virtual void RaiseCollectionChanged(CollectionChangeEventArgs e)
        {
            if (!this.IsLockUpdate && (this.CollectionChanged != null))
            {
                this.CollectionChanged(this, e);
            }
        }
        #endregion Protected Section

        #region Public Section
        public virtual int Add(BreadCrumbItem item)
        {
            return base.List.Add(item);
        }

        public virtual void AddRange(BreadCrumbItemCollection aCollection)
        {
            this.BeginUpdate();
            try
            {
                foreach (BreadCrumbItem item in aCollection)
                {
                    this.Add(item);
                }
            }
            finally
            {
                this.EndUpdate();
            }
        }

        public virtual void AddRange(BreadCrumbItem[] items)
        {
            this.BeginUpdate();
            try
            {
                foreach (BreadCrumbItem item in items)
                {
                    this.Add(item);
                }
            }
            finally
            {
                this.EndUpdate();
            }
        }

        public virtual int IndexOf(BreadCrumbItem item)
        {
            if ((item != null) && this.Indexes.Contains(item))
            {
                return (int)this.Indexes[item];
            }
            int index = base.List.IndexOf(item);
            if ((item != null) && (index > -1))
            {
                this.Indexes[item] = index;
            }
            return index;
        }

        public virtual void Insert(int index, object item)
        {
            base.List.Insert(index, item);
        }

        public virtual void Remove(BreadCrumbItem item)
        {
            base.List.Remove(item);
        }

        public virtual bool Contains(BreadCrumbItem item)
        {
            return (this.IndexOf(item) != -1);
        }

        public virtual void BeginUpdate()
        {
            this.lockUpdate++;
        }

        internal void CancelUpdate()
        {
            this.lockUpdate--;
        }

        public virtual void EndUpdate()
        {
            if (--this.lockUpdate == 0)
            {
                this.RaiseCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
            }
        }
        #endregion Public Section

        #region ICloneable Members

        public object Clone()
        {
            BreadCrumbItemCollection newInstance = new BreadCrumbItemCollection();

            if (this.Count > 0)
            {
                foreach (BreadCrumbItem item in this)
                {
                    newInstance.Add((BreadCrumbItem)item.Clone());
                }
            }

            return newInstance;
        }

        #endregion
    }
}
