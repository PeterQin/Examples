using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompileCondition.Domain
{
    public class Product
    {
        private string FName;

        public string Name
        {
            get { return FName; }
            set { FName = value; }
        }

        private List<Edition> FEditionList;

        public List<Edition> EditionList
        {
            get { return FEditionList; }
            set { FEditionList = value; }
        }

        private List<Project> FProjectList;

        public List<Project> ProjectList
        {
            get { return FProjectList; }
            set { FProjectList = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
