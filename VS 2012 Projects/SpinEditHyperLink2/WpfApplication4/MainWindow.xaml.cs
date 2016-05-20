using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication4
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

        private void onDragStarted(object sender, DragStartedEventArgs e)
        {
            Thumb t = (Thumb)sender;
            t.Cursor = Cursors.Hand;
        }

        private void onDragDelta(object sender, DragDeltaEventArgs e)
        {
            //double yadjust = this.Popup.ActualHeight + e.VerticalChange;
            //double xadjust = this.Popup.ActualWidth + e.HorizontalChange;
            //if ((xadjust > 0) && (yadjust > 0))
            //{
            //    if (xadjust < 10)
            //    {

            //    }
            //    this.Popup.Width = xadjust;
            //    this.Popup.Height = yadjust;
            //}
        }

        private void onDragCompleted(object sender, DragCompletedEventArgs e)
        {
            Thumb t = (Thumb)sender;
            t.Cursor = null;
        }

      

    }
}
