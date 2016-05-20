using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCrumbTest
{
    /// <summary>
    /// Custom Event Arguments for when getting child list for popup window.
    /// </summary>
    public class RequestChildListArgs : EventArgs
    {
        #region Field
        private int FIndex = -1;
        private bool FHandled = false;
        private BreadCrumbItemCollection FChildList = null;

        #region Property
        public int Index
        {
            get { return this.FIndex; }
        }

        public BreadCrumbItemCollection ChildList
        {
            get { return FChildList; }
            set { FChildList = value; }
        }

        public bool Handled
        {
            get { return FHandled; }
            set { FHandled = value; }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public RequestChildListArgs(int aIndex, BreadCrumbItemCollection aChildList)
        {
            this.FIndex = aIndex;
            this.FChildList = aChildList;
        }
        #endregion Constructor & Destroyer

    }
}
