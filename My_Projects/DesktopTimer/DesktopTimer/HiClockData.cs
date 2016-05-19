using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DesktopTimer
{
    internal class HiClockData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string C_Setting = "Setting.ini";
        private const string C_Images = "Images";
        private const string C_Sounds = "Sounds";
        private const string C_CloseText = "Close";

        private List<string> FImageFileList = null;
        private List<string> FSoundsFileList = null;
        private int FCurrentDisplayImageIndex = -1;
        private int FCurrentPlaySoundsIndex = -1;
        private DateTime FLastBreakTime = DateTime.Now;
        private int FRemindTime = 60; //in minutes

        internal int CurrentDisplayImageIndex
        {
            get { return FCurrentDisplayImageIndex; }
            set 
            {
                if (FCurrentDisplayImageIndex != value)
                {
                    if (FImageFileList.Count <= FCurrentDisplayImageIndex)
                    {
                        FCurrentDisplayImageIndex = 0;
                    }
                    else
                    {
                        FCurrentDisplayImageIndex = value; 
                    }
                }
                
            }
        }
        internal int CurrentPlaySoundsIndex
        {
            get { return FCurrentPlaySoundsIndex; }
            set 
            {
                if (FCurrentPlaySoundsIndex != value)
                {
                    if (FSoundsFileList.Count <= FCurrentPlaySoundsIndex)
                    {
                        FCurrentPlaySoundsIndex = 0;
                    }
                    else
                    {
                        FCurrentPlaySoundsIndex = value;
                    }
                }
                
            }
        }


        internal TimeSpan BreakTime
        {
            get
            {
                return new TimeSpan(0, 3, 0);
            }
        }

        internal string SettingFileFullName
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + C_Setting;
            }
        }

        internal string ImageDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + C_Images;
            }
        }

        internal string SoundDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + C_Sounds;
            }
        }
        public const string C_RemindTime = "RemindTime";
        internal int RemindTime
        {
            get
            {
                return FRemindTime;
            }
            set
            {
                if (FRemindTime != value)
                {
                    FRemindTime = value;
                    RaisePropertyChanged(C_RemindTime);
                }
            }
        }

        internal DateTime LastBreakTime
        {
            get
            {
                return FLastBreakTime;
            }
            set
            {
                if (FLastBreakTime != value)
                {
                    FLastBreakTime = value;
                }
            }
        }

        internal int ImageCount
        {
            get
            {
                return FImageFileList.Count;
            }
        }

        internal int SoundCount
        {
            get
            {
                return FSoundsFileList.Count;
            }
        }

        internal HiClockData()
        {
            FImageFileList = new List<string>();
            FSoundsFileList = new List<string>();
        }

        private void RaisePropertyChanged(string aPropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aPropName));
            }
        }

        internal bool TryGetSoundFileName(out string aPath)
        {
            bool result = false;
            aPath = null;
            CurrentPlaySoundsIndex++;
            if (FSoundsFileList.Count > 0)
            {
                aPath = FSoundsFileList[CurrentPlaySoundsIndex];
                result = true;
            }
            return result;
        }

        internal bool TryGetImageFileName(out string aPath)
        {
            bool result = false;
            aPath = null;
            CurrentDisplayImageIndex++;
            if (FImageFileList.Count > 0)
            {
                aPath = FImageFileList[CurrentDisplayImageIndex];
                result = true;
            }
            return result;
        }

        internal void AddSoundsFile(string aPath)
        {
            FSoundsFileList.Add(aPath);
        }

        internal void AddSoundsFile(string[] aPaths)
        {
            FSoundsFileList.AddRange(aPaths);
        }

        internal void AddImageFile(string aPath)
        {
            FImageFileList.Add(aPath);
        }

        internal void AddImageFile(string[] aPaths)
        {
            FImageFileList.AddRange(aPaths);
        }

        
    }
}
