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
    /// Interaction logic for SelectedBarChartWindow.xaml
    /// </summary>
    public partial class SelectedBarChartWindow : Window
    {
        Action FStartWatchAction;
        SimpleViewModel FVM;
        private int FSelectIndex = 4500;
        public SelectedBarChartWindow(Action aStartWatchAction, SimpleViewModel aVM)
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

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            FSelectIndex -= 500;
            FStartWatchAction();
            chart.UpdateData();
        }

        private int count = 0;

        private void chart_CustomDrawSeriesPoint(object sender, DevExpress.Xpf.Charts.CustomDrawSeriesPointEventArgs e)
        {
            Data point = e.SeriesPoint.Tag as Data;
            if (point != null)
            {
                int id = Convert.ToInt32(point.ID);
                if (Math.Abs(id - FSelectIndex) < 2)
                {
                    e.DrawOptions.Color = Colors.Red;
                }
                else
                {
                    e.DrawOptions.Color = Colors.YellowGreen;
                }

            }
            else
            {
                e.DrawOptions.Color = Colors.YellowGreen;
            }
            e.Handled = true;

            count++;
        }

        private void btnChangeValue_Click(object sender, RoutedEventArgs e)
        {
            FVM.ChangeNextValue();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(""+count);
        }
    }
}
