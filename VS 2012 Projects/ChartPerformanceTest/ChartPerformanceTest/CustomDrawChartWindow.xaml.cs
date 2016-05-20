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
    /// Interaction logic for CustomDrawChartWindow.xaml
    /// </summary>
    public partial class CustomDrawChartWindow : Window
    {

        Color color1 = Colors.BlueViolet;
        Color color2 = Colors.RoyalBlue;
        Color color3 = Colors.GreenYellow;
        Color color4 = Colors.SandyBrown;

        Action FStartWatchAction;
        SimpleViewModel FVM;
        public CustomDrawChartWindow(Action aStartWatchAction, SimpleViewModel aVM)
        {
            InitializeComponent();
            FStartWatchAction = aStartWatchAction;
            FVM = aVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FStartWatchAction();
            this.DataContext = FVM;
        }

        private void chart_CustomDrawSeriesPoint(object sender, DevExpress.Xpf.Charts.CustomDrawSeriesPointEventArgs e)
        {
            //SeriesPointPresentationData
            Data point = e.SeriesPoint.Tag as Data;
            if (point != null)
            {
                if (point.SeriesID == 1)
                {
                    e.DrawOptions.Color = color1;
                }
                else if (point.SeriesID == 2)
                {
                    e.DrawOptions.Color = color2;
                }
                else if (point.SeriesID == 3)
                {
                    e.DrawOptions.Color = color3;
                }
                else if (point.SeriesID == 4)
                {
                    e.DrawOptions.Color = color4;
                }
            }
        }
    }
}
