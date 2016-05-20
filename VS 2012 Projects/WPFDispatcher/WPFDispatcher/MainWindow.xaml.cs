using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WPFDispatcher
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

        public BindingList<TData> source = new BindingList<TData>();
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = source;
            listBox.DisplayMemberPath = "Data";
            TDispatherDoEvent = new delegate_void(DispatcherHelper.DoEvents);
            Thread addThread = new Thread(new ThreadStart(AddItemProc));
            addThread.Start();
        }

        delegate void delegate_void();
        delegate_void TDispatherDoEvent;
        void AddItemProc()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new delegate_void(AddNow));
        }

        void AddNow()
        {
            for (int i = 0; i < 10000000; i++)
            {
                source.Add(new TData(i));
                TDispatherDoEvent();
            }
        }        
    }

    public class TData
    {
        public int Data { get; set; }
        public TData(int aData)
        {
            Data = aData;
        }
    }
   
}
