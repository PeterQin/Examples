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
using ViewModel;

namespace NavigationPanelSample
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            ViewModel3 vm = new ViewModel3();
            vm.ClickCommand = new MyCommand(ClickProc);
            this.DataContext = vm;
            
        }
        int Count = 0;
        public void ClickProc(object apara)
        {
            MessageBox.Show("Click" + (Count++));
        }
    }

    public class BoolToVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ViewModel3 : ViewModel.Model
    {
        private const string C_Prop_ClickCommand = "ClickCommand";
        private MyCommand FClickCommand;

        public MyCommand ClickCommand
        {
            get { return FClickCommand; }
            set
            {
                if (FClickCommand != value)
                {
                    FClickCommand = value;
                    RaisePropertyChanged(C_Prop_ClickCommand);
                }
            }
        }

    }
}
