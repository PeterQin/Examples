using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DXGridUnbound
{
    public class ViewModel {
        public List<string> Cities { get; private set; }
        // Returns a list of employees so that they can be bound to the grid control. 
        public List<Employee> Source { get; private set; }
        // The collection of grid columns. 
        public ObservableCollection<Column> Columns { get; private set; }
        public List<UnboundColumn> UnboundColumns;
        public ViewModel() {
            Source = EmployeeData.DataSource;
            List<string> _cities = new List<string>();
            UnboundColumns = new List<UnboundColumn>();

            foreach (Employee employee in Source) 
            {
                if (!_cities.Contains(employee.City))
                    _cities.Add(employee.City);

               
            }

            if (Source != null && Source.Count > 0 && Source[0].TestDT != null && Source[0].TestDT.Count > 0)
            {
                foreach (string item in Source[0].TestDT.Keys)
                {
                    UnboundColumns.Add(new UnboundColumn() { FieldName = item, Settings = SettingsType.Unbound, UnboundType = "String", SortOrder = SortOrder.Ascending.ToString() });
                }
            }

            Cities = _cities;
            Columns = new ObservableCollection<Column>() {
                new Column() { FieldName = "FirstName", Settings = SettingsType.Default },
                new Column() { FieldName = "LastName", Settings = SettingsType.Default },
                new Column() { FieldName = "JobTitle", Settings = SettingsType.Default },
                new Column() { FieldName = "BirthDate", Settings = SettingsType.Default },
                new ComboColumn() { FieldName = "City", Settings = SettingsType.Combo, Source = Cities }
            };
            foreach (UnboundColumn item in UnboundColumns)
            {
                Columns.Add(item);
            }
        }
    }


    public class UnboundObj : IComparable
    {
        public double Value { get; set; }
        public string name { get; set; }

        public int CompareTo(object obj)
        {
            UnboundObj unboundobj = obj as UnboundObj;
            if (unboundobj != null)
            {
                return this.Value.CompareTo(unboundobj.Value);
            }
            return -1;
        }
    }

    // The data item. 
    public class Employee {

        public string ID { get; set; }
        public SQLNameObject FirstName
        {
            get { return new SQLNameObject(JobTitle, ID); }
        }

        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public Dictionary<string, UnboundObj> TestDT { get; set; }
    }

    public class SQLNameObject : IComparable
    {
        private const string C_Default_Format = "{0}-{1}";
        private int FDisplayID = -1;

        public int DisplayID
        {
            get { return FDisplayID; }
            set { FDisplayID = value; }
        }

        private string FNamePrefix;

        public string NamePrefix
        {
            get { return FNamePrefix; }
            set { FNamePrefix = value; }
        }

        private string FFormat = C_Default_Format;

        public string Format
        {
            get { return FFormat; }
            set { FFormat = value; }
        }

        public SQLNameObject() { }
        public SQLNameObject(string aName, string aID)
            : this(C_Default_Format, aName, aID)
        {
        }
        public SQLNameObject(string aFormat, string aName, string aID)
        {
            int id;
            if (string.IsNullOrWhiteSpace(aID) == false && Int32.TryParse(aID, out id))
            {
                DisplayID = id;
            }

            NamePrefix = aName;
            Format = aFormat;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Format))
            {
                return base.ToString();
            }
            if (DisplayID == -1)
            {
                return string.Empty;
            }
            return string.Format(Format, NamePrefix, DisplayID);
        }

        public int CompareTo(object obj)
        {
            SQLNameObject name = obj as SQLNameObject;
            if (name == null)
            {
                return -1;
            }
            else
            {
                return this.DisplayID.CompareTo(name.DisplayID);
            }
        }
    }

    public class EmployeeData : List<Employee> {
        public static List<Employee> DataSource {
            get {
                List<Employee> list = new List<Employee>();

                Dictionary<string, UnboundObj> test1 = new Dictionary<string, UnboundObj>();
                Dictionary<string, UnboundObj> test2 = new Dictionary<string, UnboundObj>();
                for (int i = 0; i < 3; i++)
                {
                    test1.Add("UnboundData" + i, new UnboundObj() {name = "unboudData" + i, Value = DateTime.Now.ToOADate() - i * 10 });
                    test2.Add("UnboundData" + i, new UnboundObj() { name = "unboudData" + i, Value = DateTime.Now.ToOADate() - i * 10 });
                }

                list.Add(
                    new Employee() 
                        {
                            ID = "1",
                            LastName = "White",
                            City = "NY",
                            JobTitle = "HR",
                            BirthDate = new DateTime(1970, 1, 10),
                            TestDT = test1,
                        }
                    );
                list.Add(new Employee()
                {
                    ID = "2",
                    LastName = "White",
                    City = "LA",
                    JobTitle = "HR",
                    BirthDate = new DateTime(2012, 12, 22),
                    TestDT = test2,
                });
                list.Add(new Employee()
                {
                    ID = "3",
                    LastName = "White",
                    City = "LA",
                    JobTitle = "HR",
                    BirthDate = new DateTime(2013, 12, 22),
                   
                });
                return list;
            }
        }
    }
    public class Column {
        // Specifies the name of a data source field to which the column is bound. 
        public string FieldName { get; set; }
        // Specifies the type of an in-place editor used to edit column values. 
        public SettingsType Settings { get; set; }
    }
    // Corresponds to a column with the combo box in-place editor. 
    public class ComboColumn : Column {
        // The source of combo box items. 
        public IList Source { get; set; }
    }
    public enum SettingsType { Default, Combo, Unbound }

    public class UnboundColumn : Column, INotifyPropertyChanged
    {
        private string FSortOrder;

        public string SortOrder
        {
            get { return FSortOrder; }
            set 
            { 
                FSortOrder = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SortOrder"));
                }
                
            }
        }

        public string UnboundType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
