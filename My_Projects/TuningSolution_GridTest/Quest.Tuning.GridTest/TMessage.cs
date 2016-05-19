using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Quest.Tuning.GridTest
{
    public enum gdata
    {
        none,
        first,
        second,
    }

    public enum gdata2
    {
        d1,
        d2
    }

    public class TMessageList : BindingList<TMessage>
    { }
    public class TMessage : INotifyPropertyChanged
    {
        #region Field
        private string fID;
        private string fHostName;
        private string fApplicationName;
        private double fTextData;
        #region Const / Delegate / Enum
        public const string C_COL_ID = "ID";
        public const string C_COL_HostName = "HostName";
        public const string C_COL_ApplicationName = "ApplicationName";
        public const string C_COL_TextData = "TextData";
        #endregion Const / Delegate / Enum

        #region Property
        public string ID
        {
            get { return fID; }
            set
            {
                if (this.fID != value)
                {
                    this.fID = value;
                    this.NotifyPropertyChanged(C_COL_ID);
                }
            }
        }
        public string HostName
        {
            get { return this.fHostName; }
            set
            {
                if (this.fHostName != value)
                {
                    this.fHostName = value;
                    this.NotifyPropertyChanged(C_COL_HostName);
                }
            }

        }

        public string ApplicationName
        {
            get { return this.fApplicationName; }
            set
            {
                if (this.fApplicationName != value)
                {
                    this.fApplicationName = value;
                    this.NotifyPropertyChanged(C_COL_ApplicationName);
                }
            }
        }

        public double TextData
        {
            get { return this.fTextData; }
            set
            {
                if (this.fTextData != value)
                {
                    this.fTextData = value;
                    this.NotifyPropertyChanged(C_COL_TextData);
                }
            }
        }
        #endregion Property

        #endregion Field

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string aName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aName));
            }
        }

        #endregion Events


    }

    public class TMessage2List : BindingList<TMessage4>
    {
        TMessage4 FproperyObject;

        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID.Equals(key.ToString()))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Find(string id)
        {
            PropertyDescriptorCollection properyCollection = TypeDescriptor.GetProperties(FproperyObject);
            PropertyDescriptor property = properyCollection.Find("ID", true);
            return FindCore(property, id);
        }
    }

    public class TMessage2
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

    }


    public class TMessage3
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private bool FVisible = true;

        public bool Visible
        {
            get { return FVisible; }
            set { FVisible = value; }
        }
    }

    public class TMessage4
    {
        private string FID;

        public string ID
        {
            get { return FID; }
            set { FID = value; }
        }
        private string FData;

        public string Data
        {
            get { return FData; }
            set { FData = value; }
        }
    }
}
