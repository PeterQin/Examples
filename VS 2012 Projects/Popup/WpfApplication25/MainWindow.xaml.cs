using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RecommendSQLDataModel data = new RecommendSQLDataModel();
            data.SQLName = "Batch-1";
            data.TopN = 25;
            data.TopNBaseSQLType = "batches";
            data.TopNConsumedPercent = "38.1%";
            data.CurrentStat = "Total Work Time(CPU)";
            data.BaseSQLType = "Batch";
            data.SQLStatList = new List<StatInfo>();
            data.TopSQLStatList = new List<StatInfo>();
            for (int i = 0; i < 4; i++)
            {
                bool visible = true;
                double value = 200 + i;
                if (i == 2)
                {
                    visible = true;
                    value = 123456789.00;
                }
                data.SQLStatList.Add(new StatInfo() { DisplayName = "Total Worker Time" + i, Percentage = 12 + i, Value = 200 + i, Visible = visible });
                data.TopSQLStatList.Add(new StatInfo() { DisplayName = "Total CPU Time" + i, Percentage = 12 + i, Value = value, Visible = visible });
            }
            this.DataContext = data;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            pop.PlacementTarget = btn;
            pop.IsOpen = true;
        }
    }

    class VisibleConver : IValueConverter
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
