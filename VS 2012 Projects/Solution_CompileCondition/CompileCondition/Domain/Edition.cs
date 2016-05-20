using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompileCondition.Domain
{
    public class Edition : Model
    {
        private string FName;

        public string Name
        {
            get { return FName; }
            set 
            {
                if (FName != value)
                {
                    FName = value;
                    DisplayName = FormatEdition(value);
                }
            }
        }

        private const string C_Prop_DisplayName = "DisplayName";
        private string FDisplayName;

        public string DisplayName
        {
            get { return FDisplayName; }
            set
            {
                if (FDisplayName != value)
                {
                    FDisplayName = value;
                    RaisePropertyChanged(C_Prop_DisplayName);
                }
            }
        }
        
        private List<string> FProjectList;

        public List<string> ProjectList
        {
            get { return FProjectList; }
            set { FProjectList = value; }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Edition edition = obj as Edition;
            if (edition != null)
            {
                return this.Name.Equals(edition.Name);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            if (Name != null)
            {
                return Name.GetHashCode();
            }
            return base.GetHashCode();
        }

        public static string FormatEdition(string aEditionName)
        {
            string result = aEditionName.Replace("Production", "Release");
            result = result.Replace("32", "|x86");
            result = result.Replace("64", "|x64");
            return result;
        }
    }
}
