
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfDXGrid;
using System.Waf.Applications;

namespace WpfApplication50
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            grid.AttachDefautDXPopupMenuItem(bar);
            view.FocusedRowHandleChanged += view_FocusedRowHandleChanged;
            view.SelectionChanged += view_SelectionChanged;
        }

        void view_SelectionChanged(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void view_FocusedRowHandleChanged(object sender, DevExpress.Xpf.Grid.FocusedRowHandleChangedEventArgs e)
        {
            tdata selectd = (tdata)view.FocusedRow;
            if (selectd == null)
            {
                this.Title = "handle: "+view.FocusedRowHandle;
            }
            else
            {
                this.Title = "id: " + selectd.id + " -- data: " + selectd.data;
            }
        }

        private void showpop_FocusedRowChanged_1(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            //if (view.FocusedRow != null)
            //{
            //    tdata selectd =  (tdata)view.FocusedRow;
            //    this.Title = "id: " + selectd.id + " -- data " + selectd.data;
            //}            
        }

        private void itemDel_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            view.BeginDeleting();
            //for (int i = view.SelectedRows.Count - 1; i >= 0; i--)
            //{
            //    tdata d = view.SelectedRows[i] as tdata;
            //    source.Remove(d);
            //}
            //List<int> selection = view.SelectedListIndexes as List<int>;
            //foreach (int item in selection)
            //{
            //    source.RemoveAt(item);
            //}
            view.EndDeleting();
        }

        private void view_SelectionChanged_1(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {
            List<int> selection = view.GetSelectedListIndexes();
        }
    }

    public class ViewModel
    {
        public ICommand del { get; set; }
        public myList source { get; set; }
        public IList Selection { get; set; }
        public ViewModel()
        {
            source = new myList();
            for (int i = 0; i < 10; i++)
            {
                source.Add(new tdata() { id = i, data = i % 3 + "d" });
            }
            del = new DelegateCommand(DeleteSelection);

            Selection = new List<int>();
            
        }

        private void DeleteSelection()
        {
            foreach (int item in Selection)
            {
                source.RemoveAt(item);
            }
        }

    }

    public class command : ICommand
    {

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }

    public class tdata
    {
        public int id { get; set; }
        public string data { get; set; }        
    }

    public class myList : BindingList<tdata>
    {
    }
}
