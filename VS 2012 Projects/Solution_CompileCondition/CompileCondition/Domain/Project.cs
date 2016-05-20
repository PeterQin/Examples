using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace CompileCondition.Domain
{
    public class Project : Model, ICloneable
    {
        private readonly string FID;

        public string ID
        {
            get { return FID; }
        }

        private string FName;

        public string Name
        {
            get { return FName; }
            set { FName = value; }
        }

        private string FLocation;

        public string Location
        {
            get { return FLocation; }
            set { FLocation = value; }
        }

        private string FCondition;

        public string Condition
        {
            get { return FCondition; }
            set { FCondition = value; }
        }

        //this is formatted condition
        private const string C_Prop_DisplayCondition = "DisplayCondition";
        private string FDisplayCondition;

        public string DisplayCondition
        {
            get { return FDisplayCondition; }
            set
            {
                if (FDisplayCondition != value)
                {
                    FDisplayCondition = value;
                    RaisePropertyChanged(C_Prop_DisplayCondition);
                }
            }
        }

        
        public Project(string aID) 
        {
            this.FID = aID;
        }

        public virtual void ApplyToLocal(string aEdition, string aVersion)
        {

        }

        public override string ToString()
        {
            return string.Format("Project: {0}", Name);
        }



        public object Clone()
        {
            Project result = new Project(this.ID);

            result.Name = this.Name;
            result.Location = this.Location;
            result.Condition = this.Condition;

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            //if (this.GetType() != obj.GetType())
            //{
            //    return false;
            //}

            Project proj = obj as Project;

            if (proj != null)
            {
                return this.ID.Equals(proj.ID);
            }

            return base.Equals(obj);
        }
    }

    public class DelphiProject : Project
    {
        public DelphiProject(string aID)
            : base(aID)           
        {
        }

        public override void ApplyToLocal(string aEdition, string aVersion)
        {
            string projFile = Path.Combine(Location, Name);
            XMLHelper.Instance.UpdateDelphiProjCondition(projFile, DisplayCondition, aEdition);
        }

    }

    public class CSharpProject : Project
    {
        public CSharpProject(string aID)
            : base(aID)
        {
        }

        public override void ApplyToLocal(string  aEdition, string aVersion)
        {
            string projFile = Path.Combine(Location, Name);
            XMLHelper.Instance.UpdateCSharpProjCondition(projFile, DisplayCondition, aEdition);
            string assemblyFile = Path.Combine(Location, "Properties\\AssemblyInfo.cs");
            AssemblyInfoUtil.Instance.UpdateCSharpVersionInfo(assemblyFile, aVersion);
        }
    }

}
