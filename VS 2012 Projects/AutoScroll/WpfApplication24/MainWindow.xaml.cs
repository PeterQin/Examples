using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApplication24
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<data> source = new List<data>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                source.Add(new data() { num = i ,test = 0});
            }
            //g.ItemsSource = source;
            //com.ItemsSource = source;
            //com.EditValue = source[0];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            //grid.SaveLayoutToXml("C:\\1.xml");
        }

        private void ChartControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            chart.MinHeight = 600;
        }
    }


    public class ScollerSizeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double size = double.MaxValue;
            if (value != null)
            {
                size = (double)value - 20;
            }
            return size;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class data
    {
        public int num { get; set; }
        public int test { get; set; }
    }
}
