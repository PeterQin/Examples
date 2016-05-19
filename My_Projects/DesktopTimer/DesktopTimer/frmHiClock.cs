using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DesktopTimer
{
    delegate void delegate_UpdateTime(int aMinutes);
    delegate void delegate_Void();

    public partial class frmHiClock : Form
    {
        private const string C_DesktopTimer = "DesktopTimer";
        private const string C_RemindTime = "RemindTimeInMinutes";

        private IniFileHelper FIniFileHelper = null;
        private HiClockData FHiClockData = null;

        internal frmHiClock()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            FHiClockData = new HiClockData();
            FIniFileHelper = new IniFileHelper(FHiClockData.SettingFileFullName);
            FHiClockData.PropertyChanged += FHiClockData_PropertyChanged;
            Init();
        }

        private void Init()
        {
            timerRemind.Enabled = true;
            timerBreak.Enabled = false;
            int time;
            if (Int32.TryParse(FIniFileHelper.IniReadValue(C_DesktopTimer, C_RemindTime), out time))
            {
                FHiClockData.RemindTime = time;
                numericUpDownMinutes.Value = time;
            }
            Thread threadInit = new Thread(new ThreadStart(LoadFiles));
            threadInit.Start();

        }

        private void LoadFiles()
        {
            if (Directory.Exists(FHiClockData.ImageDirectory))
            {
                DirectoryInfo ImageDire = new DirectoryInfo(FHiClockData.ImageDirectory);
                foreach (FileInfo fi in ImageDire.GetFiles())
                {
                    FHiClockData.AddImageFile(fi.FullName);
                }
            }

            if (Directory.Exists(FHiClockData.SoundDirectory))
            {
                DirectoryInfo soundsDirectory = new DirectoryInfo(FHiClockData.SoundDirectory);
                foreach (FileInfo fi in soundsDirectory.GetFiles())
                {
                    FHiClockData.AddSoundsFile(fi.FullName);
                }
            }

            UpdateImageCount();
            UpdateSoundCount();
        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            FIniFileHelper.IniWriteValue(C_DesktopTimer, C_RemindTime, FHiClockData.RemindTime.ToString());

            if (timerBreak != null)
            {
                timerBreak.Enabled = false;
                timerRemind = null;
            }

            if (timerRemind != null)
            {
                timerRemind.Enabled = false;
                timerRemind = null;
            }

            if (notifyIconDesktopTimer != null)
            {
                notifyIconDesktopTimer.Visible = false;
                notifyIconDesktopTimer.Icon = null;
                notifyIconDesktopTimer.Dispose();
                notifyIconDesktopTimer = null;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            Application.Exit();
        }

        private void FHiClockData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(HiClockData.C_RemindTime))
            {
                if (timerRemind.Interval != FHiClockData.RemindTime * 60 * 1000)
                {
                    timerRemind.Interval = FHiClockData.RemindTime * 60 * 1000;
                }                
                FIniFileHelper.IniWriteValue(C_DesktopTimer, C_RemindTime, FHiClockData.RemindTime.ToString());
            }
        }

        private void UpdateImageCount()
        {
            lblImage.Text = string.Format(rcHiClock.Setting_TotalImage, FHiClockData.ImageCount);
        }

        private void UpdateSoundCount()
        {
            lblSound.Text = string.Format(rcHiClock.Setting_TotalSound, FHiClockData.SoundCount);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int newTime;
            if (Int32.TryParse(numericUpDownMinutes.Value.ToString(), out newTime))
            {
                FHiClockData.RemindTime = newTime;
            }
        }

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FHiClockData.AddImageFile(openFileDialog1.FileNames);
            }
        }

        private void btnImportSound_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FHiClockData.AddSoundsFile(openFileDialog1.FileNames);
            }
        }

        private void timerRemind_Tick(object sender, EventArgs e)
        {
            TurnOnBreak();
        }

        private void timerBreak_Tick(object sender, EventArgs e)
        {
            TimeSpan breakNow = DateTime.Now.Subtract(FHiClockData.LastBreakTime);

            if (breakNow > FHiClockData.BreakTime)
            {
                lblDesc.Visible = false;
                CloseBreakWindow();
            }
            else
            {
                TimeSpan remainBreak = FHiClockData.BreakTime.Subtract(breakNow);
                lblDesc.Text = string.Format("Please take a break {0} minutes", remainBreak.TotalMinutes.ToString("N"));
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBreakWindow();
        }

        private void CloseBreakWindow()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            //timerBreak.Enabled = false;
            //timerRemind.Enabled = true;
            this.Hide();
        }

        private void ShowBreakWindow()
        {
            this.SuspendLayout();
            try
            {
                string path;
                if (FHiClockData.TryGetImageFileName(out path))
                {
                    this.BackgroundImage = Image.FromFile(path);
                }
                Play();
                this.Show();
            }
            finally
            {
                this.ResumeLayout();
            }

        }

        private void TurnOnBreak()
        {
            timerRemind.Enabled = false;
            ShowBreakWindow();
            FHiClockData.LastBreakTime = DateTime.Now;
            timerBreak.Enabled = true;
            lblDesc.Visible = true;
        }

    }
}
