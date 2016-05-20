using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class MyViewModel : Model
    {
        private const string C_Prop_MySource = "MySource";
        private List<Data> FMySource;

        public List<Data> MySource
        {
            get { return FMySource; }
            set
            {
                if (FMySource != value)
                {
                    FMySource = value;
                    RaisePropertyChanged(C_Prop_MySource);
                }
            }
        }

        public MyViewModel()
        {
            MySource = new List<Data>();
            for (int i = 0; i < 20; i++)
            {
                MySource.Add(new Data() { ID = i, Name = "d " + i });
            }
        }
    }

    public class Data : Model
    {
        private const string C_Prop_ID = "ID";
        private int FID;

        public int ID
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
}
