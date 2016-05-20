using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCrumbTest
{
    #region Delegate

    #region SelectionChanged
    /// <summary>
    /// Delegate for handling when a new node is selected.
    /// </summary>
    /// <param name="sender">Sender of this event</param>
    /// <param name="nca">Event Arguments</param>
    public delegate void SelectionChangedEventHandler(object sender, SelectionChangedArgs e);

    #endregion

    #region ItemAdded
    /// <summary>
    /// Delegate for handling when add a new item.
    /// </summary>
    /// <param name="sender">Sender of this event</param>
    /// <param name="nca">Event Arguments</param>
    public delegate void ItemAddedEventHandler(object sender, ItemAddedArgs e);


    #endregion

    #region GettingChildList
    /// <summary>
    /// Delegate for handling when getting child list for popup window.
    /// </summary>
    /// <param name="sender">Sender of this event</param>
    /// <param name="nca">Event Arguments</param>
    public delegate void RequestChildListEventHandler(object sender, RequestChildListArgs e);


    #endregion

    #endregion
}
