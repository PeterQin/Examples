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

namespace WebTest
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            web.Source = FormatURL(edit.Text);
            
        }

        private Uri FormatURL(string aUriString)
        {
            Uri uri;
            if (Uri.TryCreate(aUriString, UriKind.Absolute, out uri) == false)
            {
                uri = new Uri(Uri.UriSchemeHttp + Uri.SchemeDelimiter + aUriString);
            }
            return uri;
        }


        private void edit_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                web.Source = FormatURL(edit.Text);
                 
            }
        }
    }
}
