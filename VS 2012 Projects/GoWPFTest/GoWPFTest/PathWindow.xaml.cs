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
using System.Windows.Shapes;

namespace GoWPFTest
{
    /// <summary>
    /// Interaction logic for PathWindow.xaml
    /// </summary>
    public partial class PathWindow : Window
    {
        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(PathWindow), new PropertyMetadata(string.Empty, Path_PropertyChanged));

        private static void Path_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PathWindow element = d as PathWindow;
            if (element != null)
            {
                element.IsValidPath = (string.IsNullOrWhiteSpace((string)e.NewValue) == false);
            }
        }

        public bool IsValidPath
        {
            get { return (bool)GetValue(IsValidPathProperty); }
            set { SetValue(IsValidPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsValidPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsValidPathProperty =
            DependencyProperty.Register("IsValidPath", typeof(bool), typeof(PathWindow), new PropertyMetadata(false));


        public PathWindow()
        {
            InitializeComponent();
            txtPath.Text= System.IO.Path.Combine(System.IO.Path.GetTempPath(), "diagram.jpg");
            txtPath.Focus();
            txtPath.SelectAll();
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            
            this.DialogResult = true;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
