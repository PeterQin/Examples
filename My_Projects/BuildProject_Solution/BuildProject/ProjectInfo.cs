using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace BuildProject
{
    public class ProjectInfo : INotifyPropertyChanged
    {
        public const string C_Start = "Project(\"";
        public const string C_End = "EndProject";

        public ProjectInfo() { }
        public ProjectInfo(string aName)
        {
            this.FullName = aName;
        }
        private string FFileName;

        public string FileName
        {
            get { return Path.GetFileName(FullName); }
        }

        private string FFullName;

        public string FullName
        {
            get { return FFullName; }
            set 
            { 
                FFullName = value;
                RaisePropertyChanged("FullName");
                RaisePropertyChanged("FileName");
            }
        }


        private bool FInclude = true;

        public bool Include
        {
            get { return FInclude; }
            set
            {
                FInclude = value;
                RaisePropertyChanged("Include");
            }
        }


        private void RaisePropertyChanged(string aPropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aPropName));
            }
        }

        public override bool Equals(object obj)
        {
            ProjectInfo proj = obj as ProjectInfo;
            if (proj != null)
            {
                return proj.FullName.Equals(this.FullName);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
