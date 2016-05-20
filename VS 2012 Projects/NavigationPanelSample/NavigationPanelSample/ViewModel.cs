using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class MyViewModel : Model
    {
        private const string C_Prop_SQLTypeList = "SQLTypeList";
        private List<SQLTypeDataModel> FSQLTypeList;

        public List<SQLTypeDataModel> SQLTypeList
        {
            get { return FSQLTypeList; }
            set
            {
                if (FSQLTypeList != value)
                {
                    FSQLTypeList = value;
                    RaisePropertyChanged(C_Prop_SQLTypeList);
                }
            }
        }


        public MyViewModel(ICommand aCommand)
        {
            SQLTypeList = new List<SQLTypeDataModel>();
            SQLTypeList.AddRange(new SQLTypeDataModel[] {
                new SQLTypeDataModel(aCommand){Title="Most Expensive SQL Statements", Descript="Number of SQL statements that occupy the first intellgence portion (%) of resources consumption."},
            new SQLTypeDataModel(aCommand){Title="Most Expensive Batches", Descript="Number of Batches that occupy the first intellgence portion (%) of resources consumption."},
            new SQLTypeDataModel(aCommand){Title="Most Expensive Database Objects", Descript="Number of DB Objects that occupy the first intellgence portion (%) of resources consumption."}});
        }
    }

    public class SQLTypeDataModel : Model
    {
        private const string C_Prop_AllowExpandButton = "AllowExpandButton";
        private bool FAllowExpandButton = true;

        public bool AllowExpandButton
        {
            get { return FAllowExpandButton; }
            set
            {
                if (FAllowExpandButton != value)
                {
                    FAllowExpandButton = value;
                    RaisePropertyChanged(C_Prop_AllowExpandButton);
                }
            }
        }

        private const string C_Prop_Title = "Title";
        private string FTitle;

        public string Title
        {
            get { return FTitle; }
            set
            {
                if (FTitle != value)
                {
                    FTitle = value;
                    RaisePropertyChanged(C_Prop_Title);
                }
            }
        }

        private const string C_Prop_Descript = "Descript";
        private string FDescript;

        public string Descript
        {
            get { return FDescript; }
            set
            {
                if (FDescript != value)
                {
                    FDescript = value;
                    RaisePropertyChanged(C_Prop_Descript);
                }
            }
        }
        
        private const string C_Prop_GoalList = "GoalList";
        private ObservableCollection<GoalDataMoel> FGoalList;

        public ObservableCollection<GoalDataMoel> GoalList
        {
            get { return FGoalList; }
            set
            {
                if (FGoalList != value)
                {
                    FGoalList = value;
                    RaisePropertyChanged(C_Prop_GoalList);
                }
            }
        }
        private static int count = 0;

        public SQLTypeDataModel(ICommand aCommand)
        {
            count++;
            //6.40821400721363129E-10
            double percent = Convert.ToDouble("6.40821400721363129E-10");
            ObservableCollection<GoalDataMoel> goalList = new ObservableCollection<GoalDataMoel>();
            goalList.Add(new GoalDataMoel() { Name = "Logical Reads", Percent = 0, NumOfSQL = 15, ViewChartDetailCommand = aCommand });
            goalList.Add(new GoalDataMoel() { Name = "CPU", DisplayType = CellType.Chart, Percent = percent, NumOfSQL = 120, ViewChartDetailCommand = aCommand });
            goalList.Add(new GoalDataMoel() { Name = "Elapsed Time", Percent = 0.33, NumOfSQL = 33, ViewChartDetailCommand = aCommand });
            if (count == 3)
            {
                goalList.Add(new GoalDataMoel() { Name = "Physical Reads -- Database Objects", Percent = 0.55, NumOfSQL = 56, ViewChartDetailCommand = aCommand });
            }
            else
            {
                goalList.Add(new GoalDataMoel() { Name = "Physical Reads", Percent = 0.55, NumOfSQL = 56, ViewChartDetailCommand = aCommand });
            }
            GoalList = goalList;

            
        }
    }

    public enum CellType
    {
        Chart,
        Text,
    }

    public class GoalDataMoel : Model
    {
        private const string C_Prop_Name = "Name";
        private string FName;

        public string Name
        {
            get { return FName; }
            set
            {
                if (FName != value)
                {
                    FName = value;
                    RaisePropertyChanged(C_Prop_Name);
                }
            }
        }

        private const string C_Prop_IsMouseOver = "IsMouseOver";
        private bool FIsMouseOver = false;

        public bool IsMouseOver
        {
            get { return FIsMouseOver; }
            set
            {
                if (FIsMouseOver != value)
                {
                    FIsMouseOver = value;
                    RaisePropertyChanged(C_Prop_IsMouseOver);
                }
            }
        }
        

        private const string C_Prop_DisplayType = "DisplayType";
        private CellType FDisplayType = CellType.Chart;

        public CellType DisplayType
        {
            get { return FDisplayType; }
            set
            {
                if (FDisplayType != value)
                {
                    FDisplayType = value;
                    RaisePropertyChanged(C_Prop_DisplayType);
                }
            }
        }



        private const string C_Prop_Percent = "Percent";
        private double FPercent = -1;

        public double Percent
        {
            get { return FPercent; }
            set
            {
                if (FPercent != value)
                {
                    FPercent = Math.Round(value, 2);
                    RaisePropertyChanged(C_Prop_Percent);
                    List<GoalPercentDataModel> percentList = new List<GoalPercentDataModel>();
                    percentList.AddRange(new GoalPercentDataModel[] { 
                        new GoalPercentDataModel(){Argument="Other", Percentage = 1 - FPercent, IsComparedPercentage = true},
                        new GoalPercentDataModel(){Argument=Name, Percentage = FPercent, IsComparedPercentage = false}
                        
                    });
                    PercentDisplay = percentList;
                }
            }
        }

        private const string C_Prop_PercentDisplay = "PercentDisplay";
        private List<GoalPercentDataModel> FPercentDisplay;

        public List<GoalPercentDataModel> PercentDisplay
        {
            get { return FPercentDisplay; }
            set
            {
                if (FPercentDisplay != value)
                {
                    FPercentDisplay = value;
                    RaisePropertyChanged(C_Prop_PercentDisplay);
                }
            }
        }



        private const string C_Prop_NumOfSQL = "NumOfSQL";
        private int FNumOfSQL;

        public int NumOfSQL
        {
            get { return FNumOfSQL; }
            set
            {
                if (FNumOfSQL != value)
                {
                    FNumOfSQL = value;
                    RaisePropertyChanged(C_Prop_NumOfSQL);
                }
            }
        }

        private const string C_Prop_ViewChartDetailCommand = "ViewChartDetailCommand";
        private ICommand FViewChartDetailCommand;

        public ICommand ViewChartDetailCommand
        {
            get { return FViewChartDetailCommand; }
            set
            {
                if (FViewChartDetailCommand != value)
                {
                    FViewChartDetailCommand = value;
                    RaisePropertyChanged(C_Prop_ViewChartDetailCommand);
                }
            }
        }

        public override string ToString()
        {
            return Name + "\r\nPercent: " + Percent +"\r\nNumber of SQL: " + NumOfSQL;
        }

    }

    public class GoalPercentDataModel : Model
    {
        private const string C_Prop_Percentage = "Percentage";
        private double FPercentage;

        public double Percentage
        {
            get { return FPercentage; }
            set
            {
                if (FPercentage != value)
                {
                    FPercentage = value;
                    RaisePropertyChanged(C_Prop_Percentage);
                }
            }
        }

        private const string C_Prop_Argument = "Argument";
        private string FArgument;

        public string Argument
        {
            get { return FArgument; }
            set
            {
                if (FArgument != value)
                {
                    FArgument = value;
                    RaisePropertyChanged(C_Prop_Argument);
                }
            }
        }

        private const string C_Prop_IsComparedPercentage = "IsComparedPercentage";
        private bool FIsComparedPercentage;

        public bool IsComparedPercentage
        {
            get { return FIsComparedPercentage; }
            set
            {
                if (FIsComparedPercentage != value)
                {
                    FIsComparedPercentage = value;
                    RaisePropertyChanged(C_Prop_IsComparedPercentage);
                }
            }
        }


        
    }

    public class Model : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string aName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aName));
            }
        }
    }

    public class MyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (FCanExecute != null)
            {
                return FCanExecute(parameter);
            }
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            FExecute(parameter);
        }

        private Action<object> FExecute;
        private Func<object, bool> FCanExecute;

        public MyCommand(Action<object> aExecute)
        {
            FExecute = aExecute;
            FCanExecute = null;
        }

        public MyCommand(Action<object> aExecute, Func<object, bool> aCanExecute)
        {
            FExecute = aExecute;
            FCanExecute = aCanExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
