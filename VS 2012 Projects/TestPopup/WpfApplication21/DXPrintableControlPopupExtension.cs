using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApplication21
{

    public class DXPrintableControlDefaultPopupItemsOption
    {
        private bool FAttachDefaultItems;

        public bool AttachDefaultItems
        {
            get { return FAttachDefaultItems; }
            set { FAttachDefaultItems = value; }
        }

        private bool FAttachSettingItem;

        public bool AttachSettingItem
        {
            get { return FAttachSettingItem; }
            set { FAttachSettingItem = value; }
        }
        

    }

    public static class DXPrintableControlPopupExtension
    {

        //For devexpress popup menu
        private const string C_DXPopupMenu_SaveAs = "WpfDXGridPopupMenu_SaveAs";
        private const string C_DXPopupMenu_Excel = "WpfDXGridPopupMenu_Excel";
        private const string C_DXPopupMenu_HTML = "WpfDXGridPopupMenu_HTML";
        private const string C_DXPopupMenu_PDF = "WpfDXGridPopupMenu_PDF";
        private const string C_DXPopupMenu_TXT = "WpfDXGridPopupMenu_TXT";
        private const string C_DXPopupMenu_XML = "WpfDXGridPopupMenu_XML";
        private const string C_DXPopupMenu_Print = "WpfDXGridPopupMenu_Print";

        public static DXPrintableControlDefaultPopupItemsOption GetAttachDefaultPopupItems(DependencyObject obj)
        {
            return (DXPrintableControlDefaultPopupItemsOption)obj.GetValue(AttachDefaultPopupItemsProperty);
        }

        public static void SetAttachDefaultPopupItems(DependencyObject obj, DXPrintableControlDefaultPopupItemsOption value)
        {
            obj.SetValue(AttachDefaultPopupItemsProperty, value);
        }

        // Using a DependencyProperty as the backing store for AttachDefaultPopupItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachDefaultPopupItemsProperty =
            DependencyProperty.RegisterAttached("AttachDefaultPopupItems", typeof(DXPrintableControlDefaultPopupItemsOption), typeof(DXPrintableControlPopupExtension), new PropertyMetadata((DXPrintableControlDefaultPopupItemsOption)null, AttachDefaultPopupItems_PropChanged));

        private static void AttachDefaultPopupItems_PropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DXPrintableControlDefaultPopupItemsOption option = e.NewValue as DXPrintableControlDefaultPopupItemsOption;
            if (option != null)
            {
                if (option.AttachDefaultItems && option.AttachSettingItem == false)
                {
                    AttachDefautDXPopupMenuItem(d);
                }
                else if (option.AttachDefaultItems && option.AttachSettingItem)
                {
                    
                    FrameworkElement element = d as FrameworkElement;
                    PopupMenu menu = GetPopupMenu(d);
                    BindingOperations.ClearBinding(d, DXPrintableControlPopupExtension.IsContextMenuOpenProperty);
                    if (menu != null)
                    {
                        BindingOperations.SetBinding(menu, PopupMenu.IsOpenProperty, new Binding() { Path = new PropertyPath(DXPrintableControlPopupExtension.IsContextMenuOpenProperty), Source = d, Mode = BindingMode.OneWayToSource });                   
                    }
                }

            }
        }



        public static bool GetIsContextMenuOpen(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsContextMenuOpenProperty);
        }

        public static void SetIsContextMenuOpen(DependencyObject obj, bool value)
        {
            obj.SetValue(IsContextMenuOpenProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsContextMenuOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsContextMenuOpenProperty =
            DependencyProperty.RegisterAttached("IsContextMenuOpen", typeof(bool), typeof(DXPrintableControlPopupExtension), new PropertyMetadata(false, IsContextMenuOpen_PropChanged));

        private static void IsContextMenuOpen_PropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridControl grid = d as GridControl;
            if (grid != null)
            {
                AttachDefautDXPopupMenuItem(d);
                AttachSettingMenuItem(d);
            }
            
        }



        private static bool GetIsDefaultItemAttached(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDefaultItemAttachedProperty);
        }

        private static void SetIsDefaultItemAttached(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDefaultItemAttachedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsDefaultItemAttached.  This enables animation, styling, binding, etc...
        private static readonly DependencyProperty IsDefaultItemAttachedProperty =
            DependencyProperty.RegisterAttached("IsDefaultItemAttached", typeof(bool), typeof(DXPrintableControlPopupExtension), new PropertyMetadata(false));



        private static bool CheckPrintableControl(object aView)
        {
            return (IPrintableControl)aView != null;
        }

        private static bool AttachDefautDXPopupMenuItem(DependencyObject d)
        {
            GridControl grid = d as GridControl;
            if (CheckPrintableControl(grid.View) == false || GetIsDefaultItemAttached(d))
            {
                return false;
            }

            //Add to Bar Manager popup menu
            PopupMenu pop = GetPopupMenu(d);
            AttachDefautDXPopupMenuItem(pop);
            SetIsDefaultItemAttached(d, true);
            return GetIsDefaultItemAttached(d);
        }

        private static PopupMenu GetPopupMenu(DependencyObject d)
        {
            GridControl grid = d as GridControl;
            if (CheckPrintableControl(grid.View))
            {
                //Add to Bar Manager popup menu
                PopupMenu pop = BarManager.GetDXContextMenu(grid) as PopupMenu;
                if (pop == null)
                {
                    pop = new PopupMenu();
                    BarManager.SetDXContextMenu(grid, pop);
                }
                return pop;
            }
            return null;
            
        }

        public static void AttachDefautDXPopupMenuItem(PopupMenu aPopupMenu)
        {
            //Save Sub Menu
            BarSubItem subItemSaveAs = new BarSubItem();
            subItemSaveAs.Name = C_DXPopupMenu_SaveAs;
            subItemSaveAs.Content = "Save As";

            //Save as Excel
            BarButtonItem btnExcel = new BarButtonItem();
            btnExcel.Content = "Excel Document";
            btnExcel.Name = C_DXPopupMenu_Excel;
            btnExcel.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Save as HTML
            BarButtonItem btnHTML = new BarButtonItem();
            btnHTML.Content = "HTML Document";
            btnHTML.Name = C_DXPopupMenu_HTML;
            btnHTML.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Save as PDF
            BarButtonItem btnPDF = new BarButtonItem();
            btnPDF.Content = "PDF Document";
            btnPDF.Name = C_DXPopupMenu_PDF;
            btnPDF.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Save as TXT
            BarButtonItem btnTXT = new BarButtonItem();
            btnTXT.Content = "TXT Document";
            btnTXT.Name = C_DXPopupMenu_TXT;
            btnTXT.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Add BarButtonItem to Save As Menu
            subItemSaveAs.ItemLinks.Add(btnExcel);
            subItemSaveAs.ItemLinks.Add(btnHTML);
            subItemSaveAs.ItemLinks.Add(btnPDF);
            subItemSaveAs.ItemLinks.Add(btnTXT);

            //Print menu
            BarButtonItem btnPrint = new BarButtonItem();
            btnPrint.Content = "Print...";
            btnPrint.Name = C_DXPopupMenu_Print;
            btnPrint.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));
            btnPrint.GlyphSize = GlyphSize.Small;
            //btnPrint.Glyph = FPrintSource;
            if (CheckAnyDXContextMenuItemVisible(aPopupMenu))
            {
                aPopupMenu.ItemLinks.Add(new BarItemLinkSeparator());
            }

            aPopupMenu.ItemLinks.Add(subItemSaveAs);
            aPopupMenu.ItemLinks.Add(btnPrint);
            
        }

        private static bool AttachSettingMenuItem(DependencyObject d)
        {
            GridControl grid = d as GridControl;
            if (CheckPrintableControl(grid.View) == false)
            {
                return false;
            }

            //Save Sub Menu
            BarSubItem subItemSettings = new BarSubItem();
            subItemSettings.Name = "Setting";
            subItemSettings.Content = "Settings";

            PopupMenu pop = GetPopupMenu(d);
            pop.ItemLinks.Add(subItemSettings);
            //if (grid.View.IsColumnMenuEnabled)
            //{
            //    foreach (IBarManagerControllerAction item in grid.View.ColumnMenuCustomizations)
            //    {
            //        object iobj = item.GetObject();
            //    }
            //}

            return true;

        }

        private static bool CheckAnyDXContextMenuItemVisible(PopupMenu aMenu)
        {
            foreach (BarItemLinkBase item in aMenu.ItemLinks)
            {
                if (item.ActualIsVisible)
                {
                    return true;
                }
            }
            return false;
        }

        private static void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
