using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApplication21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();
        }

        private void item1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            IPrintableControl printable = view as IPrintableControl;
            if (printable != null)
            {
                using (PrintableControlLink link = new PrintableControlLink(printable))
                {
                    link.ShowPrintPreviewDialog(Application.Current.MainWindow, "gggg");
                }
            }
        }

        private void item2_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //Sort Ascending
            //view.FocusedColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            //Group By This Column
            //view.FocusedColumn.GroupIndex = view.FocusedColumn.IsGrouped ? -1: view.GroupedColumns.Count;

            //Show Hide Group Panel
            //view.ShowGroupPanel = !view.ShowGroupPanel;

            //Show Hide Column Chooser
            //if (view.IsColumnChooserVisible)
            //{
            //    view.HideColumnChooser();
            //}
            //else
            //{
            //    view.ShowColumnChooser();
            //}

            //Best Fit Column
            //view.BestFitColumn(view.FocusedColumn);

            //Best Fit All Columns
            //view.BestFitColumns();

            //Filter Editor...
            //view.ShowFilterEditor(view.FocusedColumn);

            //Show Search Panel
            //if (view.ActualShowSearchPanel == false)
            //{
            //    view.ShowSearchPanel(true);
            //}
            //else
            //{
            //    view.HideSearchPanel();
            //}
            
        }

        private const string C_Setting_SortAscending = "Setting_SortAscending";
        private const string C_Setting_SortAscending_Content = "Sort Ascending";

        private const string C_Setting_SortDescending = "Setting_SortDescending";
        private const string C_Setting_SortDescending_Content = "Sort Descending";

        private const string C_Setting_ClearSorting = "Setting_ClearSorting";
        private const string C_Setting_ClearSorting_Content = "Clear Sorting";

        private const string C_Setting_GroupByColumn = "Setting_GroupByColumn";
        private const string C_Setting_GroupByColumn_Content = "Group By This Column";

        private const string C_Setting_ShowHideGroupPanel = "Setting_ShowGroupPanel";
        private const string C_Setting_ShowGroupPanel_Content = "Show Group Panel";
        private const string C_Setting_HideGroupPanel_Content = "Hide Group Panel";

        private const string C_Setting_ShowHideColumnChooser = "Setting_ShowHdieColumnChooser";
        private const string C_Setting_ShowColumnChooser_Content = "Show Column Chooser";
        private const string C_Setting_HideColumnChooser_Content = "Hide Column Chooser";

        private const string C_Setting_BestFit = "Setting_BestFit";
        private const string C_Setting_BestFit_Content = "Best Fit";

        private const string C_Setting_BestFitAll = "Setting_BestFitAll";
        private const string C_Setting_BestFitAll_Content = "Best Fit (all columns)";

        private const string C_Setting_FilterEditor = "Setting_FilterEditor";
        private const string C_Setting_FilterEditor_Content = "Filter Editor...";

        private const string C_Setting_ShowHideSearchPanel= "Setting_ShowHideSearchPanel";
        private const string C_Setting_ShowSearchPanel_Content = "Show Search Panel";
        private const string C_Setting_HideSearchPanel_Content = "Hide Search Panel";

        private enum PopupItem
        {
            None,
            Setting_SortAscending,
            Setting_SortDescending,
            Setting_ClearSorting,
            Setting_GroupByColumn,
            Setting_ShowGroupPanel,
            Setting_HideGroupPanel,
            Setting_ShowColumnChooser,
            Setting_HideColumnChooser,
            Setting_BestFit,
            Setting_BestFitAll,
            Setting_FilterEditor,
            Setting_ShowSearchPanel,
            Setting_HideSearchPanel,

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddSettingItems2();
        }

        private void AddSettingItems()
        {
            //Sort Ascending
            BarButtonItem btnSortAscending = new BarButtonItem();
            btnSortAscending.Content = C_Setting_SortAscending_Content;
            btnSortAscending.Name = C_Setting_SortAscending;
            btnSortAscending.Tag = PopupItem.Setting_SortAscending;
            btnSortAscending.IsEnabled = view.FocusedColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False;
            btnSortAscending.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Sort Descending
            BarButtonItem btnSortDescending = new BarButtonItem();
            btnSortDescending.Content = C_Setting_SortDescending_Content;
            btnSortDescending.Name = C_Setting_SortDescending;
            btnSortDescending.Tag = PopupItem.Setting_SortDescending;
            btnSortDescending.IsEnabled = view.FocusedColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False;
            btnSortDescending.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Clear Sorting
            BarButtonItem btnClearSorting = new BarButtonItem();
            btnClearSorting.Content = C_Setting_ClearSorting_Content;
            btnClearSorting.Name = C_Setting_ClearSorting;
            btnClearSorting.Tag = PopupItem.Setting_ClearSorting;
            btnClearSorting.IsEnabled = (view.FocusedColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False)
                                && (view.FocusedColumn.SortOrder != DevExpress.Data.ColumnSortOrder.None);
            btnClearSorting.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Group By This Column
            BarButtonItem btnGroupByColumn = new BarButtonItem();
            btnGroupByColumn.Content = C_Setting_GroupByColumn_Content;
            btnGroupByColumn.Name = C_Setting_GroupByColumn;
            btnGroupByColumn.Tag = PopupItem.Setting_GroupByColumn;
            btnGroupByColumn.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Show/Hide Group Panel
            BarButtonItem btnShowHideGroupPanel = new BarButtonItem();
            if (view.IsGroupPanelVisible)
            {
                btnShowHideGroupPanel.Content = C_Setting_HideGroupPanel_Content;
                btnShowHideGroupPanel.Tag = PopupItem.Setting_HideGroupPanel;
            }
            else
            {
                btnShowHideGroupPanel.Content = C_Setting_ShowGroupPanel_Content;
                btnShowHideGroupPanel.Tag = PopupItem.Setting_ShowGroupPanel;
            }
            btnShowHideGroupPanel.Name = C_Setting_ShowHideGroupPanel;            
            btnShowHideGroupPanel.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Show/Hide Column Chooser
            BarButtonItem btnShowColumnChooser = new BarButtonItem();
            if (view.IsColumnChooserVisible)
            {
                btnShowColumnChooser.Content = C_Setting_HideColumnChooser_Content;
                btnShowColumnChooser.Tag = PopupItem.Setting_HideColumnChooser;
            }
            else
            {
                btnShowColumnChooser.Content = C_Setting_ShowColumnChooser_Content;
                btnShowColumnChooser.Tag = PopupItem.Setting_ShowColumnChooser;
            }            
            btnShowColumnChooser.Name = C_Setting_ShowHideColumnChooser;
            btnShowColumnChooser.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Best Fit
            BarButtonItem btnBestFit = new BarButtonItem();
            btnBestFit.Content = C_Setting_BestFit_Content;
            btnBestFit.Name = C_Setting_BestFit;
            btnBestFit.Tag = PopupItem.Setting_BestFit;
            btnBestFit.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Best Fit (all columns)
            BarButtonItem btnBestFitAll = new BarButtonItem();
            btnBestFitAll.Content = C_Setting_BestFitAll_Content;
            btnBestFitAll.Name = C_Setting_BestFitAll;
            btnBestFitAll.Tag = PopupItem.Setting_BestFitAll;
            btnBestFitAll.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Filter Editor...
            BarButtonItem btnFilterEditor = new BarButtonItem();
            btnFilterEditor.Content = C_Setting_FilterEditor_Content;
            btnFilterEditor.Name = C_Setting_FilterEditor;
            btnFilterEditor.Tag = PopupItem.Setting_FilterEditor;
            btnFilterEditor.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Show/Hide Search Panel
            BarButtonItem btnShowHideSearchPanel = new BarButtonItem();
            if (view.ActualShowSearchPanel)
            {
                btnShowHideSearchPanel.Content = C_Setting_HideSearchPanel_Content;
                btnShowHideSearchPanel.Tag = PopupItem.Setting_HideSearchPanel;
            }
            else
            {
                btnShowHideSearchPanel.Content = C_Setting_ShowSearchPanel_Content;
                btnShowHideSearchPanel.Tag = PopupItem.Setting_ShowSearchPanel;
            }
            btnShowHideSearchPanel.Name = C_Setting_ShowHideSearchPanel;
            btnShowHideSearchPanel.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Add BarButtonItem to Save As Menu
            subItemSettings.ItemLinks.Clear();
            subItemSettings.ItemLinks.Add(btnSortAscending);
            subItemSettings.ItemLinks.Add(btnSortDescending);
            subItemSettings.ItemLinks.Add(btnClearSorting);
            subItemSettings.ItemLinks.Add(new BarItemLinkSeparator());
            subItemSettings.ItemLinks.Add(btnGroupByColumn);
            subItemSettings.ItemLinks.Add(btnShowHideGroupPanel);
            subItemSettings.ItemLinks.Add(new BarItemLinkSeparator());
            subItemSettings.ItemLinks.Add(btnShowColumnChooser);
            subItemSettings.ItemLinks.Add(btnBestFit);
            subItemSettings.ItemLinks.Add(btnBestFitAll);
            subItemSettings.ItemLinks.Add(new BarItemLinkSeparator());
            subItemSettings.ItemLinks.Add(btnFilterEditor);
            subItemSettings.ItemLinks.Add(btnShowHideSearchPanel);
        }

        private void AddSettingItems2()
        {
            //Sort Ascending
            BarButtonItem btnSortAscending = new BarButtonItem();
            btnSortAscending.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnSortAscending));
            btnSortAscending.Name = DefaultColumnMenuItemNames.SortAscending;
            btnSortAscending.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.SortAscending);
            btnSortAscending.Tag = PopupItem.Setting_SortAscending;
            btnSortAscending.IsEnabled = view.FocusedColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False;
            btnSortAscending.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Sort Descending
            BarButtonItem btnSortDescending = new BarButtonItem();
            btnSortDescending.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnSortDescending));
            btnSortDescending.Name = DefaultColumnMenuItemNames.SortDescending;
            btnSortDescending.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.SortDescending);
            btnSortDescending.Tag = PopupItem.Setting_SortDescending;
            btnSortDescending.IsEnabled = view.FocusedColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False;
            btnSortDescending.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));
            
            //Clear Sorting
            BarButtonItem btnClearSorting = new BarButtonItem();
            btnClearSorting.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnClearSorting));
            btnClearSorting.Name = DefaultColumnMenuItemNames.ClearSorting;
            btnClearSorting.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.ClearSorting);
            btnClearSorting.Tag = PopupItem.Setting_ClearSorting;
            btnClearSorting.IsEnabled = (view.FocusedColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False)
                                && (view.FocusedColumn.SortOrder != DevExpress.Data.ColumnSortOrder.None);
            btnClearSorting.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Group By This Column
            BarButtonItem btnGroupByColumn = new BarButtonItem();
            btnGroupByColumn.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnGroup));
            btnGroupByColumn.Name = DefaultColumnMenuItemNames.GroupColumn;
            btnGroupByColumn.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.GroupColumn);
            btnGroupByColumn.Tag = PopupItem.Setting_GroupByColumn;
            btnGroupByColumn.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Show/Hide Group Panel
            BarButtonItem btnShowHideGroupPanel = new BarButtonItem();
            if (view.IsGroupPanelVisible)
            {
                btnShowHideGroupPanel.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnHideGroupPanel));
                btnShowHideGroupPanel.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.GroupBox);
                btnShowHideGroupPanel.Tag = PopupItem.Setting_HideGroupPanel;
            }
            else
            {
                btnShowHideGroupPanel.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnShowGroupPanel)); ;
                btnShowHideGroupPanel.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.GroupBox);
                btnShowHideGroupPanel.Tag = PopupItem.Setting_ShowGroupPanel;
            }
            btnShowHideGroupPanel.Name = DefaultColumnMenuItemNames.GroupBox;
            btnShowHideGroupPanel.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Show/Hide Column Chooser
            BarButtonItem btnShowColumnChooser = new BarButtonItem();
            if (view.IsColumnChooserVisible)
            {
                btnShowColumnChooser.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnHideColumnChooser));
                btnShowColumnChooser.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.ColumnChooser);
                btnShowColumnChooser.Tag = PopupItem.Setting_HideColumnChooser;
            }
            else
            {
                btnShowColumnChooser.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnShowColumnChooser));
                btnShowColumnChooser.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.ColumnChooser);
                btnShowColumnChooser.Tag = PopupItem.Setting_ShowColumnChooser;
            }
            btnShowColumnChooser.Name = DefaultColumnMenuItemNames.ColumnChooser;
            btnShowColumnChooser.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Best Fit
            BarButtonItem btnBestFit = new BarButtonItem();
            btnBestFit.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnBestFit));
            btnBestFit.Name = DefaultColumnMenuItemNames.BestFit;
            btnBestFit.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.BestFit);
            btnBestFit.Tag = PopupItem.Setting_BestFit;
            btnBestFit.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Best Fit (all columns)
            BarButtonItem btnBestFitAll = new BarButtonItem();
            btnBestFitAll.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnBestFitColumns));
            btnBestFitAll.Name = DefaultColumnMenuItemNames.BestFitColumns;
            btnBestFitAll.Tag = PopupItem.Setting_BestFitAll;
            btnBestFitAll.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Filter Editor...
            BarButtonItem btnFilterEditor = new BarButtonItem();
            btnFilterEditor.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnFilterEditor));
            btnFilterEditor.Name = DefaultColumnMenuItemNames.FilterEditor;
            btnFilterEditor.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.FilterEditor);
            btnFilterEditor.Tag = PopupItem.Setting_FilterEditor;
            btnFilterEditor.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Show/Hide Search Panel
            BarButtonItem btnShowHideSearchPanel = new BarButtonItem();
            if (view.ActualShowSearchPanel)
            {
                btnShowHideSearchPanel.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnHideSearchPanel));
                btnShowHideSearchPanel.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.SearchPanel);
                btnShowHideSearchPanel.Tag = PopupItem.Setting_HideSearchPanel;
            }
            else
            {
                btnShowHideSearchPanel.Content = view.LocalizationDescriptor.GetValue(Enum.GetName(typeof(GridControlStringId), GridControlStringId.MenuColumnShowSearchPanel));
                btnShowHideSearchPanel.Glyph = ImageHelper.GetImage(DefaultColumnMenuItemNames.SearchPanel);
                btnShowHideSearchPanel.Tag = PopupItem.Setting_ShowSearchPanel;
            }
            btnShowHideSearchPanel.Name = DefaultColumnMenuItemNames.SearchPanel;
            btnShowHideSearchPanel.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Add BarButtonItem to Save As Menu
            subItemSettings.ItemLinks.Clear();
            subItemSettings.ItemLinks.Add(btnSortAscending);
            subItemSettings.ItemLinks.Add(btnSortDescending);
            subItemSettings.ItemLinks.Add(btnClearSorting);
            subItemSettings.ItemLinks.Add(new BarItemLinkSeparator());
            subItemSettings.ItemLinks.Add(btnGroupByColumn);
            subItemSettings.ItemLinks.Add(btnShowHideGroupPanel);
            subItemSettings.ItemLinks.Add(new BarItemLinkSeparator());
            subItemSettings.ItemLinks.Add(btnShowColumnChooser);
            subItemSettings.ItemLinks.Add(btnBestFit);
            subItemSettings.ItemLinks.Add(btnBestFitAll);
            subItemSettings.ItemLinks.Add(new BarItemLinkSeparator());
            subItemSettings.ItemLinks.Add(btnFilterEditor);
            subItemSettings.ItemLinks.Add(btnShowHideSearchPanel);

            object item = subItemSettings.ItemLinks[0].Tag;
        }


        private void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            if (sender is BarButtonItem)
            {
                BarButtonItem item = sender as BarButtonItem;
                PopupItem itemtype = (PopupItem)(item.Tag);
                switch (itemtype)
                {
                    case PopupItem.Setting_SortAscending:
                        view.FocusedColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        break;
                    case PopupItem.Setting_SortDescending:
                        view.FocusedColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                        break;
                    case PopupItem.Setting_ClearSorting:
                        view.FocusedColumn.SortOrder = DevExpress.Data.ColumnSortOrder.None;
                        break;
                    case PopupItem.Setting_GroupByColumn:
                        view.FocusedColumn.GroupIndex = view.FocusedColumn.IsGrouped ? -1 : view.GroupedColumns.Count;
                        break;
                    case PopupItem.Setting_ShowGroupPanel:
                        view.ShowGroupPanel = true;
                        break;
                    case PopupItem.Setting_HideGroupPanel:
                        view.ShowGroupPanel = false;
                        break;
                    case PopupItem.Setting_ShowColumnChooser:
                        view.ShowColumnChooser();
                        break;
                    case PopupItem.Setting_HideColumnChooser:
                        view.HideColumnChooser();
                        break;
                    case PopupItem.Setting_BestFit:
                        view.BestFitColumn(view.FocusedColumn);
                        break;
                    case PopupItem.Setting_BestFitAll:
                        view.BestFitColumns();
                        break;
                    case PopupItem.Setting_FilterEditor:
                        view.ShowFilterEditor(view.FocusedColumn);
                        break;
                    case PopupItem.Setting_ShowSearchPanel:
                        view.ShowSearchPanel(true);
                        break;
                    case PopupItem.Setting_HideSearchPanel:
                        view.HideSearchPanel();
                        break;
                }
            }
        }

        private void view_ShowGridMenu(object sender, DevExpress.Xpf.Grid.GridMenuEventArgs e)
        {
            //UpdateItems(e.Items);
            //foreach (var item in e.Items)
            //{
            //    SaveIcon(item.Glyph, item.Name);
            //}
            
        }

        private void SaveIcon(ImageSource image, string itemName)
        {
            if (image == null)
            {
                return;
            }
            //int width = 16;
            //int height = width;
            //int stride = width / 8;
            //byte[] pixels = new byte[height * stride];

            // Define the image palette
            BitmapPalette myPalette = BitmapPalettes.Halftone256;

            //// Creates a new empty image with the pre-defined palette
            //BitmapSource image = BitmapSource.Create(
            //    width,
            //    height,
            //    96,
            //    96,
            //    PixelFormats.Indexed1,
            //    myPalette,
            //    pixels,
            //    stride);

            //FileStream stream = new FileStream("d:\\icon\\" + itemName + ".png", FileMode.Create);
            //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
            //encoder.Save(stream);
            //stream.Close();
        }



        private void UpdateItems(ReadOnlyCollection<BarItem> aItemList)
        {
            foreach (BarItem item in aItemList)
            {
                BarButtonItem btnItem = item as BarButtonItem;
                if (btnItem == null || btnItem.Tag == null)
                {
                    continue;
                }
                PopupItem itemtype = (PopupItem)(btnItem.Tag);
                switch (itemtype)
                {
                    case PopupItem.Setting_SortAscending:
                        break;
                    case PopupItem.Setting_SortDescending:
                        break;
                    case PopupItem.Setting_ClearSorting:
                        btnItem.IsEnabled = (view.FocusedColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False)
                                                && (view.FocusedColumn.SortOrder != DevExpress.Data.ColumnSortOrder.None);
                        break;
                    case PopupItem.Setting_GroupByColumn:
                        break;
                    case PopupItem.Setting_ShowGroupPanel:
                    case PopupItem.Setting_HideGroupPanel:
                        if (view.IsGroupPanelVisible)
                        {
                            btnItem.Content = C_Setting_HideGroupPanel_Content;
                            btnItem.Tag = PopupItem.Setting_HideGroupPanel;
                        }
                        else
                        {
                            btnItem.Content = C_Setting_ShowGroupPanel_Content;
                            btnItem.Tag = PopupItem.Setting_ShowGroupPanel;
                        }
                        break;
                    case PopupItem.Setting_ShowColumnChooser:
                    case PopupItem.Setting_HideColumnChooser:
                        if (view.IsColumnChooserVisible)
                        {
                            btnItem.Content = C_Setting_HideColumnChooser_Content;
                            btnItem.Tag = PopupItem.Setting_HideColumnChooser;
                        }
                        else
                        {
                            btnItem.Content = C_Setting_ShowColumnChooser_Content;
                            btnItem.Tag = PopupItem.Setting_ShowColumnChooser;
                        }    
                        break;
                    case PopupItem.Setting_BestFit:
                        break;
                    case PopupItem.Setting_BestFitAll:
                        break;
                    case PopupItem.Setting_FilterEditor:
                        break;
                    case PopupItem.Setting_ShowSearchPanel:
                    case PopupItem.Setting_HideSearchPanel:
                        if (view.ActualShowSearchPanel)
                        {
                            btnItem.Content = C_Setting_HideSearchPanel_Content;
                            btnItem.Tag = PopupItem.Setting_HideSearchPanel;
                        }
                        else
                        {
                            btnItem.Content = C_Setting_ShowSearchPanel_Content;
                            btnItem.Tag = PopupItem.Setting_ShowSearchPanel;
                        }
                        break;
                }
                  
            }
        }

    }

    public interface IDXGridView
    {
        LocalizationDescriptor LocalizationDescriptor { get; }
        ColumnBase FocusedColumn { get; }
        bool IsGroupPanelVisible { get; }
        bool IsHandleGroupPanel{ get; }
    }
}
