using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BuildProject
{
    public class TAssemblyInfo : INotifyPropertyChanged
    {
        private string FInfoName;

        public string InfoName
        {
            get { return FInfoName; }
            set
            {
                FInfoName = value;
                RaisePropertyChanged("InfoName");
            }
        }

        private string FInfoValue;

        public string InfoValue
        {
            get { return FInfoValue; }
            set
            {
                FInfoValue = value;
                RaisePropertyChanged("InfoValue");
            }
        }

        public string DisplayInfo
        {
            get
            {
                return string.Format(AssemblyString.C_Format, InfoName, InfoValue);
            }
        }

        public string IdentyString
        {
            get
            {
                return string.Format(AssemblyString.C_Identify, InfoName);
            }
        }

        public override bool Equals(object obj)
        {
            TAssemblyInfo assembly = obj as TAssemblyInfo;
            if (assembly != null)
            {
                return this.InfoName.Equals(assembly.InfoName);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void RaisePropertyChanged(string aPropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aPropName));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class AssemblyString
    {
        private AssemblyString() { }
        private static readonly AssemblyString FInstance = new AssemblyString();

        public static AssemblyString Instance
        {
            get { return AssemblyString.FInstance; }
        }

        public const string C_Format = "[assembly: {0}(\"{1}\")]";
        public const string C_Identify = "[assembly: {0}(\"";
        public const string C_Identify_End = ")]";



    }
}
