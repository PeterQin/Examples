using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChartPerformanceTest
{
    /// <summary>
    /// Interaction logic for StopWatchWindow.xaml
    /// </summary>
    public partial class StopwatchWindow : Window
    {
        DispatcherTimer FTimer;
        DateTime FLastStartLoading = DateTime.Now;
        public StopwatchWindow()
        {
            InitializeComponent();
            FTimer = new DispatcherTimer();
            FTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            FTimer.Tick += FTimer_Tick;
            digitalControl.Text = "00:00:00.000000";
        }

        private void FTimer_Tick(object sender, EventArgs e)
        {
            digitalControl.Text = DateTime.Now.Subtract(FLastStartLoading).ToString();
        }

        public void Start()
        {
            this.Dispatcher.BeginInvoke(new Action(StartProc));
        }

        private void StartProc()
        {
            FTimer.Stop();
            digitalControl.Text = "00:00:00.000000";
            FLastStartLoading = DateTime.Now;
            FTimer.Start();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            FTimer.Stop();
            digitalControl.Text = "00:00:00.000000";
        }

        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            FLastStartLoading = DateTime.Now;
            FTimer.IsEnabled = !(FTimer.IsEnabled);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
