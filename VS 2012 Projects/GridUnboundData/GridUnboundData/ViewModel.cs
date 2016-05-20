using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridUnboundData
{
    public class ViewModel
    {
        public List<string> Cities { get; private set; }
        // Returns a list of employees so that they can be bound to the grid control. 
        public List<Employee> Source { get; private set; }
        // The collection of grid columns. 
        public ObservableCollection<Column> Columns { get; private set; }
        public ViewModel()
        {
            Source = EmployeeData.DataSource;
            List<string> _cities = new List<string>();
            foreach (Employee employee in Source)
            {
                if (!_cities.Contains(employee.City))
                    _cities.Add(employee.City);
            }
            Cities = _cities;

            Columns = new ObservableCollection<Column>() {
                new Column() { Caption = "FirstName", FieldName = "FirstName", Settings = SettingsType.Default },
                new Column() { Caption = "LastName", FieldName = "LastName", Settings = SettingsType.Default },
                new Column() { Caption = "JobTitle", FieldName = "JobTitle", Settings = SettingsType.Default },
                new Column() { Caption = "BirthDate", FieldName = "BirthDate", Settings = SettingsType.Default },
                new ComboColumn() { Caption = "City", FieldName = "City", Settings = SettingsType.Combo, Source = Cities }
            };
        }

        public void TestChangedColumn()
        {
            Columns.Clear();
            Columns.Add(new Column() { Caption = "FirstName", FieldName = "FirstName", Settings = SettingsType.Default });
            Columns.Add(new Column() { Caption = "LastName", FieldName = "LastName", Settings = SettingsType.Default });
            Columns.Add(new Column() { Caption = "JobTitle", FieldName = "JobTitle", Settings = SettingsType.Default });
            Columns.Add(new Column() { Caption = "BirthDate", FieldName = "BirthDate", Settings = SettingsType.Default });
            Columns.Add(new Column() { Caption = "TestTime Custom Caption", FieldName = "TestTime", Settings = SettingsType.Default });
            
        }


    }

    // The data item. 
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TestTime { get; set; }
    }
    public class EmployeeData : List<Employee>
    {
        public static List<Employee> DataSource
        {
            get
            {
                List<Employee> list = new List<Employee>();
                list.Add(new Employee()
                {
                    FirstName = "Nathan",
                    LastName = "White",
                    City = "NY",
                    JobTitle = "Sales Manager",
                    BirthDate = new DateTime(1970, 1, 10),
                    TestTime = DateTime.Now
                });
                list.Add(new Employee()
                {
                    FirstName = "Sendra",
                    LastName = "Oldman",
                    City = "LA",
                    JobTitle = "Marketing Manager",
                    BirthDate = new DateTime(1980, 12, 22),
                    TestTime = DateTime.Now
                });
                return list;
            }
        }
    }
    public class Column
    {
        // Specifies the header of the column is bound. 
        public string Caption { get; set; }
        // Specifies the name of a data source field to which the column is bound. 
        public string FieldName { get; set; }
        // Specifies the type of an in-place editor used to edit column values. 
        public SettingsType Settings { get; set; }
    }
    // Corresponds to a column with the combo box in-place editor. 
    public class ComboColumn : Column
    {
        // The source of combo box items. 
        public IList Source { get; set; }
    }
    public enum SettingsType { Default, Combo }
}
