using DevExpress.Utils;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyViewModel FM;
        public MainWindow()
        {
            InitializeComponent();
  
            this.DataContext= FM = new MyViewModel();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(FM.MySource.Count+"");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FM.MySource.Add(new Data() { ID = 6, Name = "10.30.150.45 (sqlexp)" });
        }
    }

    public class ContentToMarginConverter : IValueConverter
    {
        public static ContentToMarginConverter Default = new ContentToMarginConverter();

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness(0, 0, -((ContentPresenter)value).ActualHeight, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ContentToPathConverter : IValueConverter
    {
        private static readonly ContentToPathConverter FDefault = new ContentToPathConverter();

        public static ContentToPathConverter Default
        {
            get { return ContentToPathConverter.FDefault; }
        }

        public ContentToPathConverter() { }

        #region IMultiValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FrameworkElement cp = (FrameworkElement)value;
            if (cp == null)
            {
                return null;
            }
            

            double w = (double)cp.ActualWidth; // width
            double h = (double)cp.ActualHeight; // height

            var ps = new PathSegmentCollection(4);
            ps.Add(new LineSegment(new Point(1, 0.7 * h), true));
            ps.Add(new BezierSegment(new Point(1, 0.9 * h), new Point(0.1 * h, h), new Point(0.3 * h, h), true));
            ps.Add(new LineSegment(new Point(w , h), true));
            ps.Add(new BezierSegment(new Point(w + 0.2 * h, h), new Point(w + h * 0.4, 0), new Point(w + h * 0.6, 0), true));
            return ps;
        }



        #endregion


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ContentToPathConverter2 : IMultiValueConverter
    {
        public static ContentToPathConverter2 Default = new ContentToPathConverter2();

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
            {
                return null;
            }

            double w = (double)values[0]; // width
            double h = (double)values[1]; // height

            var ps = new PathSegmentCollection(4);
            ps.Add(new LineSegment(new Point(1, 0.7 * h), true));
            ps.Add(new BezierSegment(new Point(1, 0.9 * h), new Point(0.1 * h, h), new Point(0.3 * h, h), true));
            ps.Add(new LineSegment(new Point(w, h), true));
            ps.Add(new BezierSegment(new Point(w + 0.2 * h, h), new Point(w + h * 0.4, 0), new Point(w + h * 0.6, 0), true));
            return ps;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class BoolToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return DefaultBoolean.True;
            }
            else
            {
                return DefaultBoolean.False;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
