using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChartPerformanceTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleViewModel FVM;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FVM = new SimpleViewModel();
        }

        private void btnWatch_Click(object sender, RoutedEventArgs e)
        {
            CreateStopwatch();
        }

        private void CreateStopwatch()
        {
            Thread threadWatch = new Thread(new ThreadStart(ShowWatch));
            threadWatch.SetApartmentState(ApartmentState.STA);
            threadWatch.Start();
        }

        StopwatchWindow FStopwatch;
        private void ShowWatch()
        {
            FStopwatch = new StopwatchWindow();
            FStopwatch.ShowDialog();
        }

        private void StartWatch()
        {
            if (FStopwatch == null)
            {
                return;
            }
            FStopwatch.Start();
        }

        private void btnSimple_Click(object sender, RoutedEventArgs e)
        {
            new Simple2DBarChart(StartWatch, FVM).Show();
        }

        private void btnScaleNum_Click(object sender, RoutedEventArgs e)
        {
            new ScaleNum2DBarChart(StartWatch, FVM).Show();
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            new LineChart(StartWatch, FVM).Show();
        }

        private void btnArea_Click(object sender, RoutedEventArgs e)
        {
            new AreaChart(StartWatch, FVM).Show();
        }

        private void btnSelectBar_Click(object sender, RoutedEventArgs e)
        {
            new SelectedBarChartWindow(StartWatch, FVM).Show();
        }

        private void btnSeries_Click(object sender, RoutedEventArgs e)
        {
            new SeriesTestChartWindow(StartWatch, FVM).Show();
        }

        private void btnCustomDrawBar_Click(object sender, RoutedEventArgs e)
        {
            new CustomDrawChartWindow(StartWatch, FVM).Show();
        }

        
    }
}
