using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

namespace DXGridUnbound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();

        }

        private void grid_CustomUnboundColumnData(object sender, DevExpress.Xpf.Grid.GridColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                Dictionary<string, UnboundObj> TestDT = e.GetListSourceFieldValue("TestDT") as Dictionary<string, UnboundObj>;
                if (TestDT != null)
                {
                    e.Value = TestDT[e.Column.FieldName].Value;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (UnboundColumn item in ((ViewModel)DataContext).UnboundColumns)
            {
                item.SortOrder = "None";
            }
        }
    }

    public class ToBindingConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Binding(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColumnTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Column column = (Column)item;
            return (DataTemplate)((Control)container).FindResource(column.Settings + "ColumnTemplate");
        }
    }

    public static class DisplayMemberBindingHelper
    {
        public static readonly DependencyProperty PathProperty = DependencyProperty.RegisterAttached("Path", typeof(string), typeof(DisplayMemberBindingHelper), new PropertyMetadata(string.Empty, (d, e) =>
            {
                GridColumn column = d as GridColumn;
                if (column == null)
                    return;
                if (e.NewValue == null)
                    column.DisplayMemberBinding = null;
                column.DisplayMemberBinding = new Binding(string.Format("RowData.Row.{0}", e.NewValue));

            }));
        public static string GetPath(DependencyObject obj)
        {
            return (string)obj.GetValue(PathProperty);
        }
        public static void SetPath(DependencyObject obj, string value)
        {
            obj.SetValue(PathProperty, value);
        }
    }

    public class OADateToTimeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                double OATime = (double)value;
                CultureInfo ci = CultureInfo.CurrentCulture;
                DateTime time = DateTime.FromOADate(OATime);
                return time.ToString("hh:mm:ss.fff", ci);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
