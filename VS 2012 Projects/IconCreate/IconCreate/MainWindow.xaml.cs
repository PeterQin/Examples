using System;
using System.Collections.Generic;
using System.IO;
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

namespace IconCreate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Background

            string resourceTemplate = Resource1.ResourceTemplate;
            string path = @"W:\Common\Images\production\QExplain";
            string[] files = Directory.GetFiles(path, "*.ico");
            runContent.Text = "";
            foreach (var item in files)
	        {
                runContent.Text += string.Format(resourceTemplate, System.IO.Path.GetFileNameWithoutExtension(item)) + Environment.NewLine;
	        }

            

        }
    }
}
