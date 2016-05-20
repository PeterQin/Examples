using DevExpress.Xpf.NavBar;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace NavigationPanelSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyCommand FViewDetailCommand;
        public MainWindow()
        {
            InitializeComponent();
            FViewDetailCommand = new MyCommand(ViewDetailCommandProc);
            MyViewModel vm = new MyViewModel(FViewDetailCommand);
            this.DataContext = vm;
        }

        private void ChartControl_CustomDrawSeriesPoint(object sender, DevExpress.Xpf.Charts.CustomDrawSeriesPointEventArgs e)
        {
            if (e.SeriesPoint != null)
            {
                GoalPercentDataModel goadPercent = e.SeriesPoint.Tag as GoalPercentDataModel;
                if (goadPercent != null)
                {
                    if (goadPercent.IsComparedPercentage)
                    {
                        e.DrawOptions.Color = Color.FromRgb(170, 186, 215);
                    }
                    else
                    {
                        e.DrawOptions.Color = Color.FromRgb(64, 105, 156);
                    }
                }
            }
        }

        public void ViewDetailCommandProc(object aPara)
        {
            if (aPara != null)
            {
                MessageBox.Show(aPara.ToString());
            }
            
        }
    }

    public class BooleanToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
