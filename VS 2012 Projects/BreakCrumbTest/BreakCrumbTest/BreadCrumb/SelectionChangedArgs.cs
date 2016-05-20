using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCrumbTest
{
    /// <summary>
    /// Custom Event Arguments for when a node has been changed.
    /// </summary>
    public class SelectionChangedArgs : EventArgs
    {
        #region Field
        private int FIndex = -1;

        #region Property
        public int Index
        {
            get { return this.FIndex; }
        }
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public SelectionChangedArgs(int aIndex)
        {
            this.FIndex = aIndex;
        }
        #endregion Constructor & Destroyer
    }
}
