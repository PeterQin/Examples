using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCrumbTest
{
    /// <summary>
    /// Custom Event Arguments for when add a new item.
    /// </summary>
    public class ItemAddedArgs : EventArgs
    {
        #region Field
        private int FIndex = -1;
        private AddItemAction FAction;

        #region Property
        public int Index
        {
            get { return this.FIndex; }
        }

        public AddItemAction Action
        {
            get { return FAction; }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public ItemAddedArgs(int aIndex, AddItemAction aAction)
        {
            this.FIndex = aIndex;
            this.FAction = aAction;
        }
        #endregion Constructor & Destroyer
    }
}
