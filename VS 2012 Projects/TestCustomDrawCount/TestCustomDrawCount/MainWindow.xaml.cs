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

namespace TestCustomDrawCount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleViewModel FVM;
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = FVM = new SimpleViewModel();
        }

        private void btnChangeValue_Click(object sender, RoutedEventArgs e)
        {
            FVM.ChangeNextValue();
        }

        private void btnShowCount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
