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
    /// Interaction logic for AreaChart.xaml
    /// </summary>
    public partial class AreaChart : Window
    {
        Action FStartWatchAction;
        SimpleViewModel FVM;
        public AreaChart(Action aStartWatchAction, SimpleViewModel aVM)
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
    }
}
