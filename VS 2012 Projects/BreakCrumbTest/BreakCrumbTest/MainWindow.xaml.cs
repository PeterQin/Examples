using DevExpress.Xpf.Grid.LookUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BreakCrumbTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel FViewModel;
        public MainWindow()
        {
            InitializeComponent();
            FViewModel = new ViewModel();
            FViewModel.Items = new ObservableCollection<BreadCrumbItemTest>();
            this.DataContext = FViewModel;
            bread.SelectionChanged += bread_SelectionChanged;

            FViewModel.PropertyChanged += FViewModel_PropertyChanged;

        }

        void FViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        void bread_SelectionChanged(object sender, SelectionChangedArgs e)
        {
            if (e.Index >= 0)
            {

                this.Title = "trace by event: " + bread.Items[e.Index].Caption;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BreadCrumbItemCollection items = new BreadCrumbItemCollection();
            for (int i = 0; i < 10; i++)
			{
                items.Add(new BreadCrumbItem("Child"+i,"Child"+i, null));
			}
            bread.AddItemWithChangeParentChildList("Home", "Home", items, "SQL", null, false);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LookUpEdit btn = new LookUpEdit();
            btn.Text = "gg";
            tstack.Children.Add(btn);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bread.BorderThickness = new Thickness(6);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ObservableCollection<BreadCrumbItemTest> items = new ObservableCollection<BreadCrumbItemTest>();
            for (int i = 0; i < 10; i++)
            {
                items.Add(new BreadCrumbItemTest("Child" + i + DateTime.Now.Second, "Child" + i, null));
            }
            FViewModel.Items.Add(new BreadCrumbItemTest("Home", DateTime.Now.Ticks, items, true));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FViewModel.Items.RemoveAt(FViewModel.Items.Count - 1);
            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ObservableCollection<BreadCrumbItemTest> items = new ObservableCollection<BreadCrumbItemTest>();
            for (int i = 0; i < 10; i++)
            {
                items.Add(new BreadCrumbItemTest("Child" + i + DateTime.Now.Second, "Child" + i, null));
            }
            FViewModel.Items.Add(new BreadCrumbItemTest("ParentChildList", DateTime.Now.Ticks, null, items));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            FViewModel.Items[0].Caption = "test rename caption";
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private const string C_Prop_Items = "Items";
        private ObservableCollection<BreadCrumbItemTest> FItems;

        public ObservableCollection<BreadCrumbItemTest> Items
        {
            get { return FItems; }
            set
            {
                if (FItems != value)
                {
                    FItems = value;
                    RaisePropertyChanged(C_Prop_Items);
                }
            }
        }


        private void RaisePropertyChanged(string aName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aName));
            }
        }

        public ViewModel()
        {
            
        }
        
    }

    public class BreadCrumbItemTest : INotifyPropertyChanged
    {
        private string FCaption = string.Empty;
        private object FActualObj;
        private object FData = null;
        private ObservableCollection<BreadCrumbItemTest> FChildList = null;
        private bool FAllowShowDorpDown = true;

        public string Caption
        {
            get { return FCaption; }
            set 
            { 
                FCaption = value;
                RaisePropertyChanged("Caption");
            }
        }

        public object Data
        {
            get { return FData; }
        }

        /// <summary>
        /// Mark the represent object
        /// </summary>
        public object ActualObj
        {
            get { return FActualObj; }
        }

        private ObservableCollection<BreadCrumbItemTest> FParentChildList;

        public ObservableCollection<BreadCrumbItemTest> ParentChildList
        {
            get { return FParentChildList; }
            set { FParentChildList = value; }
        }


        public ObservableCollection<BreadCrumbItemTest> ChildList
        {
            get { return FChildList; }
            set { FChildList = value; }
        }

        public bool AllowShowDorpDown
        {
            get { return FAllowShowDorpDown; }
            set
            {
                if (FAllowShowDorpDown != value)
                {
                    FAllowShowDorpDown = value;
                }
            }
        }

        public BreadCrumbItemTest(string aCaption, object aData, ObservableCollection<BreadCrumbItemTest> aChildList)
            : this(aCaption, aData, aChildList, true)
        {
        }

        public BreadCrumbItemTest(string aCaption, object aData, ObservableCollection<BreadCrumbItemTest> aChildList, ObservableCollection<BreadCrumbItemTest> aParentList)
            : this(aCaption, aData, aChildList, true)
        {
            this.ParentChildList = aParentList;
        }

        public BreadCrumbItemTest(string aCaption, object aData, ObservableCollection<BreadCrumbItemTest> aChildList, bool aAllowShowDorpDown)
        {
            FCaption = aCaption;
            FData = aData;
            FChildList = aChildList;
            FAllowShowDorpDown = aAllowShowDorpDown;
        }

        public override string ToString()
        {
            return this.Caption;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string aName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aName));
            }
        }
    }
}
