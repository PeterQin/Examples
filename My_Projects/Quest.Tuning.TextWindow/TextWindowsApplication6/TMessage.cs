using System;
using System.Collections.Generic;
using System.Text;

namespace Quest.Tuning.TextWindowsApplication6
{
    class TMessage
    {
        #region Field

        #region Const / Delegate / Enum
        #endregion Const / Delegate / Enum

        #region Property
        static private int FIndexLocation;
        //public int IndexLocation
        //{
        //    get
        //    {
        //        return FIndexLocation;
        //    }
        //    set
        //    {
        //        this.FIndexLocation = value;
        //    }
        //}

        static private string FFindString;
        //public string FindString
        //{
        //    get
        //    {
        //        return FFindString;
        //    }
        //    set
        //    {
        //        this.FFindString = value;
        //    }
        //}
        
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer
        #endregion Constructor & Destroyer

        #region Private Section
        #endregion Private Section

        #region Protected Section
        #endregion Protected Section

        #region Public Section
        #endregion Public Section

        #region Events
        #endregion Events

        #region Method
        public static void SetFindIndex(int aIndex)
        {
            FIndexLocation = aIndex;
        }
        public static int GetFindIndex()
        {
            return FIndexLocation;
        }
        public static void SetFindString(string aFindString)
        {
            FFindString = aFindString;
        }
       public static string GetFindString()
        {
            return FFindString;
        }
        #endregion
    }
}
