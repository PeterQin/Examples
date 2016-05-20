using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChartPerformanceTest
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        private int Count = 8000;

        private ObservableCollection<Data> FTestDataSource;

        public ObservableCollection<Data> TestDataSource
        {
            get { return FTestDataSource; }
            set
            {
                FTestDataSource = value;
                RaisePropertyChanged("TestDataSource");
            }
        }

        #region ForSeries
        private ObservableCollection<Data> FTestDataSource1;

        public ObservableCollection<Data> TestDataSource1
        {
            get { return FTestDataSource1; }
            set
            {
                FTestDataSource1 = value;
                RaisePropertyChanged("TestDataSource1");
            }
        }
        private ObservableCollection<Data> FTestDataSource2;

        public ObservableCollection<Data> TestDataSource2
        {
            get { return FTestDataSource2; }
            set
            {
                FTestDataSource2 = value;
                RaisePropertyChanged("TestDataSource2");
            }
        }
        private ObservableCollection<Data> FTestDataSource3;

        public ObservableCollection<Data> TestDataSource3
        {
            get { return FTestDataSource3; }
            set
            {
                FTestDataSource3 = value;
                RaisePropertyChanged("TestDataSource3");
            }
        }
        private ObservableCollection<Data> FTestDataSource4;

        public ObservableCollection<Data> TestDataSource4
        {
            get { return FTestDataSource4; }
            set
            {
                FTestDataSource4 = value;
                RaisePropertyChanged("TestDataSource4");
            }
        }
        #endregion ForSeries

        public SimpleViewModel()
        {
            Console.WriteLine("SimpleViewModel--Start--" + DateTime.Now.ToString("HH:mm:ss:fff"));
            TestDataSource = new ObservableCollection<Data>();
            TestDataSource1 = new ObservableCollection<Data>();
            TestDataSource2 = new ObservableCollection<Data>();
            TestDataSource3 = new ObservableCollection<Data>();
            TestDataSource4 = new ObservableCollection<Data>();
            Data dtemp;
            for (int i = 0; i < Count; i++)
            {
                int data = i * i;
                string id = (Count - i).ToString();
                if (i > (Count / 4) * 3)
                {
                    dtemp = new Data() { ID = id, Value = data, SeriesID = 1 };
                    TestDataSource1.Add(dtemp);
                }
                else if (i > (Count / 4) * 2)
                {
                    dtemp = new Data() { ID = id, Value = data, SeriesID = 2 };
                    TestDataSource2.Add(dtemp);
                }
                else if (i > (Count / 4))
                {
                    dtemp = new Data() { ID = id, Value = data, SeriesID = 3 };
                    TestDataSource3.Add(dtemp);
                }
                else
                {
                    dtemp = new Data() { ID = id, Value = data, SeriesID = 4 };
                    TestDataSource4.Add(dtemp);
                }

                TestDataSource.Add(dtemp);
            }
            Console.WriteLine("SimpleViewModel--End--" + DateTime.Now.ToString("HH:mm:ss:fff"));
        }

        int index = 500;

        public void ChangeNextValue()
        {
            TestDataSource[index].Value = 1000;
            index++;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string aPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aPropertyName));
            }
        }
    }

    public class Data : INotifyPropertyChanged
    {
        private const string C_Prop_ID = "ID";
        private string FID;

        public string ID
        {
            get { return FID; }
            set
            {
                if (FID != value)
                {
                    FID = value;
                    RaisePropertyChanged(C_Prop_ID);
                }
            }
        }


        private const string C_Prop_Value = "Value";
        private int FValue;

        public int Value
        {
            get { return FValue; }
            set
            {
                if (FValue != value)
                {
                    FValue = value;
                    RaisePropertyChanged(C_Prop_Value);
                }
            }
        }

        private const string C_Prop_SeriesID = "SeriesID";
        private int FSeriesID;

        public int SeriesID
        {
            get { return FSeriesID; }
            set
            {
                if (FSeriesID != value)
                {
                    FSeriesID = value;
                    RaisePropertyChanged(C_Prop_SeriesID);
                }
            }
        }

        private void RaisePropertyChanged(string aProp)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aProp));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
