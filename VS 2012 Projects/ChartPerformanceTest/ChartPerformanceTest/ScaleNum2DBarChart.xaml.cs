using DevExpress.Xpf.Charts;
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

namespace ChartPerformanceTest
{
    /// <summary>
    /// Interaction logic for ScaleNum2DBarChart.xaml
    /// </summary>
    public partial class ScaleNum2DBarChart : Window
    {
        Action FStartWatchAction;
        SimpleViewModel FVM;
        public ScaleNum2DBarChart(Action aStartWatchAction, SimpleViewModel aVM)
        {
            InitializeComponent();
            FStartWatchAction = aStartWatchAction;
            FVM = aVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FStartWatchAction();
            Console.WriteLine("DataContext start " + DateTime.Now.ToString("HH:mm:ss.fff"));
            this.DataContext = FVM;
            Console.WriteLine("DataContext end " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            Point hitPosition = Mouse.GetPosition(chart);
            DiagramCoordinates coords = diagram.PointToDiagram(hitPosition);
            if (coords.IsEmpty)
            {
                return;
            }
            int actaulArgument = (int)Math.Round(coords.NumericalArgument);
            //lineSelectSeries.Value = actaulArgument;
            //SeriesPointPresentationData
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FStartWatchAction();
            Console.WriteLine("diagram.Visibility >>> " + DateTime.Now.ToString("HH:mm:ss.fff"));
            diagram.Visibility = System.Windows.Visibility.Visible;
            Console.WriteLine("diagram.Visibility <<< " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }
    }
}
