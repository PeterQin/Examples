using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCrumbTest
{
    public enum AddItemAction
    {
        /// <summary>
        /// Create item by calling AddItem function.
        /// </summary>
        AddItem,
        /// <summary>
        /// Create item by click on sub item list..
        /// </summary>
        SubItem,
    }

    public enum HistoryActionType
    {
        ChangeFocus,
        ChangeList,
    }
}
