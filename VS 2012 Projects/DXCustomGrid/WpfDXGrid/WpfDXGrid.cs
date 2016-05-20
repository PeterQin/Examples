using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using System;
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

namespace WpfDXGrid
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfDXGrid"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfDXGrid;assembly=WpfDXGrid"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class WpfDXGrid : DevExpress.Xpf.Grid.GridControl
    {
        #region Field 
        private bool FAttachedDefautContextMenuItem = false;
        private bool FAttachedDefautDXPopupMenuItem = false;
        #region Const / Enum / Delegate / Event
        //For Windows context menu
        private const string C_WinMenuItem_Excel = "miExcel";
        private const string C_WinMenuItem_HTML = "miHTML";
        private const string C_WinMenuItem_PDF = "miPDF";
        private const string C_WinMenuItem_TXT = "miTXT";
        private const string C_WinMenuItem_XML = "miXML";
        private const string C_WinMenuItem_Print = "miPrint";

        //For devexpress popup menu
        private const string C_DXPopupMenu_SaveAs = "WpfDXGridPopupMenu_SaveAs";
        private const string C_DXPopupMenu_Excel = "WpfDXGridPopupMenu_Excel";
        private const string C_DXPopupMenu_HTML = "WpfDXGridPopupMenu_HTML";
        private const string C_DXPopupMenu_PDF = "WpfDXGridPopupMenu_PDF";
        private const string C_DXPopupMenu_TXT = "WpfDXGridPopupMenu_TXT";
        private const string C_DXPopupMenu_XML = "WpfDXGridPopupMenu_XML";
        private const string C_DXPopupMenu_Print = "WpfDXGridPopupMenu_Print";
        #endregion Const / Enum / Delegate / Event

        #region Property

        [Category("Quest")]
        [Description("Gets a value indicating whether Grid View is printable")]
        private bool IsPrintableControl
        {
            get
            {
                return (IPrintableControl)View != null; 
            }
        }
        
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public WpfDXGrid()
        {
            
        }
     
        #endregion Constructor & Destroyer

        #region Private Section

        public bool AttachDefautContextMenuItem()
        {
            if (IsPrintableControl == false || FAttachedDefautContextMenuItem)
            {
                return false;
            }
            //Save As MenuItem
            MenuItem miSaveAs = new MenuItem();
            miSaveAs.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(OnMenuItemClick));
            miSaveAs.Header = "Save As";

            //Save as Excel
            MenuItem miExcel = new MenuItem();
            miExcel.Header = "Excel Document";
            miExcel.Name = C_WinMenuItem_Excel;

            //Save as HTML
            MenuItem miHTML = new MenuItem();
            miHTML.Header = "HTML Document";
            miHTML.Name = C_WinMenuItem_HTML;

            //Save as PDF
            MenuItem miPDF = new MenuItem();
            miPDF.Header = "PDF Document";
            miPDF.Name = C_WinMenuItem_PDF;

            //Save as TXT
            MenuItem miTXT = new MenuItem();
            miTXT.Header = "TXT Document";
            miTXT.Name = C_WinMenuItem_TXT;

            //Save as XML
            MenuItem miXML = new MenuItem();
            miXML.Header = "XML Document";
            miXML.Name = C_WinMenuItem_XML;

            //Add Save As sub MenuItem
            miSaveAs.Items.Add(miExcel);
            miSaveAs.Items.Add(miHTML);
            miSaveAs.Items.Add(miPDF);
            miSaveAs.Items.Add(miTXT);
            miSaveAs.Items.Add(miXML);

            //Print menu
            MenuItem miPrint = new MenuItem();
            miPrint.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(OnMenuItemClick));
            miPrint.Header = "Print...";
            miPrint.Name = C_WinMenuItem_Print;

            //Add to Context Menu
            if (ContextMenu == null)
            {
                ContextMenu = new ContextMenu();
            }
            if (ContextMenu.Items.Count > 0)
            {
                ContextMenu.Items.Add(new Separator());
            }
            ContextMenu.Items.Add(miSaveAs);
            ContextMenu.Items.Add(new Separator());
            ContextMenu.Items.Add(miPrint);
            FAttachedDefautContextMenuItem = true;
            return FAttachedDefautContextMenuItem;
        }      

        #endregion Private Section

        #region Protected Section       

        
        #endregion Protected Section

        #region Public Section        

        public bool AttachDefautDXPopupMenuItem(BarManager aBarManager)
        {
            if (IsPrintableControl == false || aBarManager == null || FAttachedDefautDXPopupMenuItem)
            {
                return false;
            }
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

            //Save as XML
            BarButtonItem btnXML = new BarButtonItem();
            btnXML.Content = "XML Document";
            btnXML.Name = C_DXPopupMenu_XML;
            btnXML.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //Add Save As BarButtonItem to Bar
            aBarManager.Items.Add(subItemSaveAs);
            aBarManager.Items.Add(btnExcel);
            aBarManager.Items.Add(btnHTML);
            aBarManager.Items.Add(btnPDF);
            aBarManager.Items.Add(btnTXT);
            aBarManager.Items.Add(btnXML);

            //Add BarButtonItem to Save As Menu
            subItemSaveAs.ItemLinks.Add(btnExcel);
            subItemSaveAs.ItemLinks.Add(btnHTML);
            subItemSaveAs.ItemLinks.Add(btnPDF);
            subItemSaveAs.ItemLinks.Add(btnTXT);
            subItemSaveAs.ItemLinks.Add(btnXML);

            //Print menu
            BarButtonItem btnPrint = new BarButtonItem();
            btnPrint.Content = "Print...";
            btnPrint.Name = C_DXPopupMenu_Print;
            btnPrint.AddHandler(BarButtonItem.ItemClickEvent, new RoutedEventHandler(OnMenuItemClick));

            //add Print menu
            aBarManager.Items.Add(btnPrint);

            //Add to Bar Manager popup menu
            PopupMenu pop = BarManager.GetDXContextMenu(this) as PopupMenu;
            if (pop == null)
            {
                pop = new PopupMenu();
                BarManager.SetDXContextMenu(this, pop);
            }
            pop.ItemLinks.Add(subItemSaveAs);
            pop.ItemLinks.Add(btnPrint);
            FAttachedDefautDXPopupMenuItem = true;
            return FAttachedDefautDXPopupMenuItem;
        }
        #endregion Public Section

        #region Events
        private void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            string strClickItemName = string.Empty;
            BarButtonItem clickBtn = e.Source as BarButtonItem;
            //for Devexpress popup menu
            if (clickBtn != null)
            {
                strClickItemName = clickBtn.Name;
            }
            else   //for windows context menu
            {
                MenuItem clickItem = e.Source as MenuItem;
                if (clickItem != null)
                {
                    strClickItemName = clickItem.Name;
                }
            }

            switch (strClickItemName)
            {
                case C_DXPopupMenu_Excel:
                case C_WinMenuItem_Excel:
                    SaveAsDialog("ss", "ss");
                    break;
                case C_WinMenuItem_HTML:
                case C_DXPopupMenu_HTML:
                    break;
                case C_WinMenuItem_PDF:
                case C_DXPopupMenu_PDF:
                    break;
                case C_WinMenuItem_Print:
                case C_DXPopupMenu_Print:
                    break;
                case C_WinMenuItem_TXT:
                case C_DXPopupMenu_TXT:
                    break;
                case C_WinMenuItem_XML:
                case C_DXPopupMenu_XML:
                    break;
            }            
        }

        private void SaveAsDialog(string aTitle, string aFilterStr)
        {
            using (PrintableControlLink link = new PrintableControlLink((IPrintableControl)View))
            {
                
                //link.ExportToXlsx(@"C:\exporttest.xlsx");
            }
        }

        #endregion Events
    }
    
}
