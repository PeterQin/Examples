using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace DesktopTimer
{
    public partial class frmDesktopTimer : Form
    {

        private HiClockData FHiClockData = null;

        public frmDesktopTimer(HiClockData aHiClockData)
        {
            InitializeComponent();
            if (aHiClockData == null)
            {
                throw new ArgumentNullException();
            }
            FHiClockData = aHiClockData;
        }

        private void Play()
        {
            string path;
            if (FHiClockData.TryGetSoundFileName(out path))
            {
                axWindowsMediaPlayer1.URL = path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void DisplayImage()
        {
            string path;
            if (FHiClockData.TryGetImageFileName(out path))
            {
                this.BackgroundImage = Image.FromFile(path);
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDesktopTimer_Load(object sender, EventArgs e)
        {
            DisplayImage();
            Play();
        }
       
    }
}