using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCrumbTest
{
    public class HistoryAction
    {
        public HistoryActionType ActionType;
        public int FocusItemIndex;
        public BreadCrumbItem FocusItem;
        public BreadCrumbItemCollection ItemList;

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is HistoryAction)
            {
                HistoryAction tmp = (HistoryAction)obj;

                if (tmp.ActionType == this.ActionType
                    && object.Equals(tmp.FocusItem, this.FocusItem)
                     && tmp.FocusItemIndex == this.FocusItemIndex
                    //&& tmp.ItemList == this.ItemList // No need check item list. Beacuse it is a clone list.
                    )
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
    }
}
