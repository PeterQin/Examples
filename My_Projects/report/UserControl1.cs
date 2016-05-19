using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WindowsApplication61
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class UserControl1 : System.Windows.Forms.UserControl
	{
        public DevExpress.XtraPrinting.Preview.PrintBarManager printBarManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraPrinting.Preview.MultiplePagesControlContainer multiplePagesControlContainer1;
        private DevExpress.XtraPrinting.Preview.ColorPopupControlContainer colorPopupControlContainer1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox printPreviewRepositoryItemComboBox1;
        private DevExpress.XtraPrinting.Preview.PreviewBar previewBar1;
        private DevExpress.XtraPrinting.Preview.PreviewBar previewBar2;
        private DevExpress.XtraPrinting.Preview.PreviewBar previewBar3;
        private DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem printPreviewStaticItem1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem printPreviewStaticItem2;
        private DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem printPreviewStaticItem3;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem2;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem3;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem4;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem5;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem6;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem7;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem8;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem9;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem10;
        private DevExpress.XtraPrinting.Preview.ZoomBarEditItem zoomBarEditItem1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem11;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem12;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem13;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem14;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem15;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem16;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem17;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem18;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem19;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem20;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem21;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem22;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem23;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem2;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem3;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem4;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem5;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem6;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem7;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem8;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem9;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem10;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem11;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem12;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem13;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem14;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem printPreviewBarCheckItem15;
        private DevExpress.XtraPrinting.Control.PrintControl printControl1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserControl1()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            XtraReport1 report = new XtraReport1();
            printControl1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UserControl1));
            this.printBarManager1 = new DevExpress.XtraPrinting.Preview.PrintBarManager();
            this.previewBar1 = new DevExpress.XtraPrinting.Preview.PreviewBar();
            this.printPreviewBarItem1 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem2 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem3 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem4 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem5 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem6 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem7 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem8 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem9 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem10 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.zoomBarEditItem1 = new DevExpress.XtraPrinting.Preview.ZoomBarEditItem();
            this.printPreviewRepositoryItemComboBox1 = new DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox();
            this.printPreviewBarItem11 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem12 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem13 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem14 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem15 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem16 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.multiplePagesControlContainer1 = new DevExpress.XtraPrinting.Preview.MultiplePagesControlContainer();
            this.printPreviewBarItem17 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.colorPopupControlContainer1 = new DevExpress.XtraPrinting.Preview.ColorPopupControlContainer();
            this.printPreviewBarItem18 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem19 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem20 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem21 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.previewBar2 = new DevExpress.XtraPrinting.Preview.PreviewBar();
            this.printPreviewStaticItem1 = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
            this.printPreviewStaticItem2 = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
            this.printPreviewStaticItem3 = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
            this.previewBar3 = new DevExpress.XtraPrinting.Preview.PreviewBar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.printPreviewBarItem22 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem23 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.printPreviewBarCheckItem1 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem2 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem3 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem4 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem5 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem6 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem7 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem8 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem9 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem10 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem11 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem12 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem13 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem14 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarCheckItem15 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printControl1 = new DevExpress.XtraPrinting.Control.PrintControl();
            ((System.ComponentModel.ISupportInitialize)(this.printBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printPreviewRepositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiplePagesControlContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPopupControlContainer1)).BeginInit();
            this.SuspendLayout();
            // 
            // printBarManager1
            // 
            this.printBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
                                                                                  this.previewBar1,
                                                                                  this.previewBar2,
                                                                                  this.previewBar3});
            this.printBarManager1.ColorPopupControlContainer = this.colorPopupControlContainer1;
            this.printBarManager1.DockControls.Add(this.barDockControlTop);
            this.printBarManager1.DockControls.Add(this.barDockControlBottom);
            this.printBarManager1.DockControls.Add(this.barDockControlLeft);
            this.printBarManager1.DockControls.Add(this.barDockControlRight);
            this.printBarManager1.Form = this;
            this.printBarManager1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printBarManager1.ImageStream")));
            this.printBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                                                                                       this.printPreviewBarItem17,
                                                                                       this.printPreviewStaticItem1,
                                                                                       this.printPreviewStaticItem2,
                                                                                       this.printPreviewStaticItem3,
                                                                                       this.printPreviewBarItem1,
                                                                                       this.printPreviewBarItem2,
                                                                                       this.printPreviewBarItem3,
                                                                                       this.printPreviewBarItem4,
                                                                                       this.printPreviewBarItem5,
                                                                                       this.printPreviewBarItem6,
                                                                                       this.printPreviewBarItem7,
                                                                                       this.printPreviewBarItem8,
                                                                                       this.printPreviewBarItem9,
                                                                                       this.printPreviewBarItem10,
                                                                                       this.zoomBarEditItem1,
                                                                                       this.printPreviewBarItem11,
                                                                                       this.printPreviewBarItem12,
                                                                                       this.printPreviewBarItem13,
                                                                                       this.printPreviewBarItem14,
                                                                                       this.printPreviewBarItem15,
                                                                                       this.printPreviewBarItem16,
                                                                                       this.printPreviewBarItem18,
                                                                                       this.printPreviewBarItem19,
                                                                                       this.printPreviewBarItem20,
                                                                                       this.printPreviewBarItem21,
                                                                                       this.barSubItem1,
                                                                                       this.barSubItem2,
                                                                                       this.barSubItem3,
                                                                                       this.barSubItem4,
                                                                                       this.printPreviewBarItem22,
                                                                                       this.printPreviewBarItem23,
                                                                                       this.barToolbarsListItem1,
                                                                                       this.printPreviewBarCheckItem1,
                                                                                       this.printPreviewBarCheckItem2,
                                                                                       this.printPreviewBarCheckItem3,
                                                                                       this.printPreviewBarCheckItem4,
                                                                                       this.printPreviewBarCheckItem5,
                                                                                       this.printPreviewBarCheckItem6,
                                                                                       this.printPreviewBarCheckItem7,
                                                                                       this.printPreviewBarCheckItem8,
                                                                                       this.printPreviewBarCheckItem9,
                                                                                       this.printPreviewBarCheckItem10,
                                                                                       this.printPreviewBarCheckItem11,
                                                                                       this.printPreviewBarCheckItem12,
                                                                                       this.printPreviewBarCheckItem13,
                                                                                       this.printPreviewBarCheckItem14,
                                                                                       this.printPreviewBarCheckItem15});
            this.printBarManager1.MainMenu = this.previewBar3;
            this.printBarManager1.MaxItemId = 47;
            this.printBarManager1.MultiplePagesControlContainer = this.multiplePagesControlContainer1;
            this.printBarManager1.PreviewBar = this.previewBar1;
            this.printBarManager1.PrintControl = this.printControl1;
            this.printBarManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                                                                                                                      this.printPreviewRepositoryItemComboBox1});
            this.printBarManager1.StatusBar = this.previewBar2;
            this.printBarManager1.ZoomItem = this.zoomBarEditItem1;
            // 
            // previewBar1
            // 
            this.previewBar1.BarName = "Toolbar";
            this.previewBar1.DockCol = 0;
            this.previewBar1.DockRow = 1;
            this.previewBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.previewBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem1),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem2),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem3, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem4, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem5),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem6),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem7),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem8, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem9),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem10, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.zoomBarEditItem1),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem11),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem12, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem13),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem14),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem15),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem16, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem17),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem18),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem19, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem20),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem21, true)});
            this.previewBar1.Text = resources.GetString("previewBar1.Text");
            // 
            // printPreviewBarItem1
            // 
            this.printPreviewBarItem1.AccessibleDescription = resources.GetString("printPreviewBarItem1.AccessibleDescription");
            this.printPreviewBarItem1.AccessibleName = resources.GetString("printPreviewBarItem1.AccessibleName");
            this.printPreviewBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem1.Caption = resources.GetString("printPreviewBarItem1.Caption");
            this.printPreviewBarItem1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.DocumentMap;
            this.printPreviewBarItem1.Description = resources.GetString("printPreviewBarItem1.Description");
            this.printPreviewBarItem1.Enabled = false;
            this.printPreviewBarItem1.Hint = resources.GetString("printPreviewBarItem1.Hint");
            this.printPreviewBarItem1.Id = 3;
            this.printPreviewBarItem1.ImageIndex = 19;
            this.printPreviewBarItem1.Name = "printPreviewBarItem1";
            // 
            // printPreviewBarItem2
            // 
            this.printPreviewBarItem2.AccessibleDescription = resources.GetString("printPreviewBarItem2.AccessibleDescription");
            this.printPreviewBarItem2.AccessibleName = resources.GetString("printPreviewBarItem2.AccessibleName");
            this.printPreviewBarItem2.Caption = resources.GetString("printPreviewBarItem2.Caption");
            this.printPreviewBarItem2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Find;
            this.printPreviewBarItem2.Description = resources.GetString("printPreviewBarItem2.Description");
            this.printPreviewBarItem2.Enabled = false;
            this.printPreviewBarItem2.Hint = resources.GetString("printPreviewBarItem2.Hint");
            this.printPreviewBarItem2.Id = 4;
            this.printPreviewBarItem2.ImageIndex = 20;
            this.printPreviewBarItem2.Name = "printPreviewBarItem2";
            this.printPreviewBarItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // printPreviewBarItem3
            // 
            this.printPreviewBarItem3.AccessibleDescription = resources.GetString("printPreviewBarItem3.AccessibleDescription");
            this.printPreviewBarItem3.AccessibleName = resources.GetString("printPreviewBarItem3.AccessibleName");
            this.printPreviewBarItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem3.Caption = resources.GetString("printPreviewBarItem3.Caption");
            this.printPreviewBarItem3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Customize;
            this.printPreviewBarItem3.Description = resources.GetString("printPreviewBarItem3.Description");
            this.printPreviewBarItem3.Enabled = false;
            this.printPreviewBarItem3.Hint = resources.GetString("printPreviewBarItem3.Hint");
            this.printPreviewBarItem3.Id = 5;
            this.printPreviewBarItem3.ImageIndex = 14;
            this.printPreviewBarItem3.Name = "printPreviewBarItem3";
            this.printPreviewBarItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // printPreviewBarItem4
            // 
            this.printPreviewBarItem4.AccessibleDescription = resources.GetString("printPreviewBarItem4.AccessibleDescription");
            this.printPreviewBarItem4.AccessibleName = resources.GetString("printPreviewBarItem4.AccessibleName");
            this.printPreviewBarItem4.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem4.Caption = resources.GetString("printPreviewBarItem4.Caption");
            this.printPreviewBarItem4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Print;
            this.printPreviewBarItem4.Description = resources.GetString("printPreviewBarItem4.Description");
            this.printPreviewBarItem4.Enabled = false;
            this.printPreviewBarItem4.Hint = resources.GetString("printPreviewBarItem4.Hint");
            this.printPreviewBarItem4.Id = 6;
            this.printPreviewBarItem4.ImageIndex = 0;
            this.printPreviewBarItem4.Name = "printPreviewBarItem4";
            // 
            // printPreviewBarItem5
            // 
            this.printPreviewBarItem5.AccessibleDescription = resources.GetString("printPreviewBarItem5.AccessibleDescription");
            this.printPreviewBarItem5.AccessibleName = resources.GetString("printPreviewBarItem5.AccessibleName");
            this.printPreviewBarItem5.Caption = resources.GetString("printPreviewBarItem5.Caption");
            this.printPreviewBarItem5.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect;
            this.printPreviewBarItem5.Description = resources.GetString("printPreviewBarItem5.Description");
            this.printPreviewBarItem5.Enabled = false;
            this.printPreviewBarItem5.Hint = resources.GetString("printPreviewBarItem5.Hint");
            this.printPreviewBarItem5.Id = 7;
            this.printPreviewBarItem5.ImageIndex = 1;
            this.printPreviewBarItem5.Name = "printPreviewBarItem5";
            // 
            // printPreviewBarItem6
            // 
            this.printPreviewBarItem6.AccessibleDescription = resources.GetString("printPreviewBarItem6.AccessibleDescription");
            this.printPreviewBarItem6.AccessibleName = resources.GetString("printPreviewBarItem6.AccessibleName");
            this.printPreviewBarItem6.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem6.Caption = resources.GetString("printPreviewBarItem6.Caption");
            this.printPreviewBarItem6.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup;
            this.printPreviewBarItem6.Description = resources.GetString("printPreviewBarItem6.Description");
            this.printPreviewBarItem6.Enabled = false;
            this.printPreviewBarItem6.Hint = resources.GetString("printPreviewBarItem6.Hint");
            this.printPreviewBarItem6.Id = 8;
            this.printPreviewBarItem6.ImageIndex = 2;
            this.printPreviewBarItem6.Name = "printPreviewBarItem6";
            // 
            // printPreviewBarItem7
            // 
            this.printPreviewBarItem7.AccessibleDescription = resources.GetString("printPreviewBarItem7.AccessibleDescription");
            this.printPreviewBarItem7.AccessibleName = resources.GetString("printPreviewBarItem7.AccessibleName");
            this.printPreviewBarItem7.Caption = resources.GetString("printPreviewBarItem7.Caption");
            this.printPreviewBarItem7.Command = DevExpress.XtraPrinting.PrintingSystemCommand.EditPageHF;
            this.printPreviewBarItem7.Description = resources.GetString("printPreviewBarItem7.Description");
            this.printPreviewBarItem7.Enabled = false;
            this.printPreviewBarItem7.Hint = resources.GetString("printPreviewBarItem7.Hint");
            this.printPreviewBarItem7.Id = 9;
            this.printPreviewBarItem7.ImageIndex = 15;
            this.printPreviewBarItem7.Name = "printPreviewBarItem7";
            this.printPreviewBarItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // printPreviewBarItem8
            // 
            this.printPreviewBarItem8.AccessibleDescription = resources.GetString("printPreviewBarItem8.AccessibleDescription");
            this.printPreviewBarItem8.AccessibleName = resources.GetString("printPreviewBarItem8.AccessibleName");
            this.printPreviewBarItem8.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem8.Caption = resources.GetString("printPreviewBarItem8.Caption");
            this.printPreviewBarItem8.Command = DevExpress.XtraPrinting.PrintingSystemCommand.HandTool;
            this.printPreviewBarItem8.Description = resources.GetString("printPreviewBarItem8.Description");
            this.printPreviewBarItem8.Enabled = false;
            this.printPreviewBarItem8.Hint = resources.GetString("printPreviewBarItem8.Hint");
            this.printPreviewBarItem8.Id = 10;
            this.printPreviewBarItem8.ImageIndex = 16;
            this.printPreviewBarItem8.Name = "printPreviewBarItem8";
            // 
            // printPreviewBarItem9
            // 
            this.printPreviewBarItem9.AccessibleDescription = resources.GetString("printPreviewBarItem9.AccessibleDescription");
            this.printPreviewBarItem9.AccessibleName = resources.GetString("printPreviewBarItem9.AccessibleName");
            this.printPreviewBarItem9.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem9.Caption = resources.GetString("printPreviewBarItem9.Caption");
            this.printPreviewBarItem9.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Magnifier;
            this.printPreviewBarItem9.Description = resources.GetString("printPreviewBarItem9.Description");
            this.printPreviewBarItem9.Enabled = false;
            this.printPreviewBarItem9.Hint = resources.GetString("printPreviewBarItem9.Hint");
            this.printPreviewBarItem9.Id = 11;
            this.printPreviewBarItem9.ImageIndex = 3;
            this.printPreviewBarItem9.Name = "printPreviewBarItem9";
            // 
            // printPreviewBarItem10
            // 
            this.printPreviewBarItem10.AccessibleDescription = resources.GetString("printPreviewBarItem10.AccessibleDescription");
            this.printPreviewBarItem10.AccessibleName = resources.GetString("printPreviewBarItem10.AccessibleName");
            this.printPreviewBarItem10.Caption = resources.GetString("printPreviewBarItem10.Caption");
            this.printPreviewBarItem10.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomOut;
            this.printPreviewBarItem10.Description = resources.GetString("printPreviewBarItem10.Description");
            this.printPreviewBarItem10.Enabled = false;
            this.printPreviewBarItem10.Hint = resources.GetString("printPreviewBarItem10.Hint");
            this.printPreviewBarItem10.Id = 12;
            this.printPreviewBarItem10.ImageIndex = 5;
            this.printPreviewBarItem10.Name = "printPreviewBarItem10";
            // 
            // zoomBarEditItem1
            // 
            this.zoomBarEditItem1.AccessibleDescription = resources.GetString("zoomBarEditItem1.AccessibleDescription");
            this.zoomBarEditItem1.AccessibleName = resources.GetString("zoomBarEditItem1.AccessibleName");
            this.zoomBarEditItem1.Caption = resources.GetString("zoomBarEditItem1.Caption");
            this.zoomBarEditItem1.Description = resources.GetString("zoomBarEditItem1.Description");
            this.zoomBarEditItem1.Edit = this.printPreviewRepositoryItemComboBox1;
            this.zoomBarEditItem1.EditValue = "100%";
            this.zoomBarEditItem1.Enabled = false;
            this.zoomBarEditItem1.Hint = resources.GetString("zoomBarEditItem1.Hint");
            this.zoomBarEditItem1.Id = 13;
            this.zoomBarEditItem1.Name = "zoomBarEditItem1";
            this.zoomBarEditItem1.Width = 70;
            // 
            // printPreviewRepositoryItemComboBox1
            // 
            this.printPreviewRepositoryItemComboBox1.AccessibleDescription = resources.GetString("printPreviewRepositoryItemComboBox1.AccessibleDescription");
            this.printPreviewRepositoryItemComboBox1.AccessibleName = resources.GetString("printPreviewRepositoryItemComboBox1.AccessibleName");
            this.printPreviewRepositoryItemComboBox1.AutoComplete = false;
            this.printPreviewRepositoryItemComboBox1.AutoHeight = ((bool)(resources.GetObject("printPreviewRepositoryItemComboBox1.AutoHeight")));
            this.printPreviewRepositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                                                                                                                             new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.printPreviewRepositoryItemComboBox1.DropDownRows = 9;
            this.printPreviewRepositoryItemComboBox1.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.AutoComplete")));
            this.printPreviewRepositoryItemComboBox1.Mask.BeepOnError = ((bool)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.BeepOnError")));
            this.printPreviewRepositoryItemComboBox1.Mask.EditMask = resources.GetString("printPreviewRepositoryItemComboBox1.Mask.EditMask");
            this.printPreviewRepositoryItemComboBox1.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.IgnoreMaskBlank")));
            this.printPreviewRepositoryItemComboBox1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.MaskType")));
            this.printPreviewRepositoryItemComboBox1.Mask.PlaceHolder = ((char)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.PlaceHolder")));
            this.printPreviewRepositoryItemComboBox1.Mask.SaveLiteral = ((bool)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.SaveLiteral")));
            this.printPreviewRepositoryItemComboBox1.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.ShowPlaceHolders")));
            this.printPreviewRepositoryItemComboBox1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("printPreviewRepositoryItemComboBox1.Mask.UseMaskAsDisplayFormat")));
            this.printPreviewRepositoryItemComboBox1.Name = "printPreviewRepositoryItemComboBox1";
            this.printPreviewRepositoryItemComboBox1.NullText = resources.GetString("printPreviewRepositoryItemComboBox1.NullText");
            // 
            // printPreviewBarItem11
            // 
            this.printPreviewBarItem11.AccessibleDescription = resources.GetString("printPreviewBarItem11.AccessibleDescription");
            this.printPreviewBarItem11.AccessibleName = resources.GetString("printPreviewBarItem11.AccessibleName");
            this.printPreviewBarItem11.Caption = resources.GetString("printPreviewBarItem11.Caption");
            this.printPreviewBarItem11.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomIn;
            this.printPreviewBarItem11.Description = resources.GetString("printPreviewBarItem11.Description");
            this.printPreviewBarItem11.Enabled = false;
            this.printPreviewBarItem11.Hint = resources.GetString("printPreviewBarItem11.Hint");
            this.printPreviewBarItem11.Id = 14;
            this.printPreviewBarItem11.ImageIndex = 4;
            this.printPreviewBarItem11.Name = "printPreviewBarItem11";
            // 
            // printPreviewBarItem12
            // 
            this.printPreviewBarItem12.AccessibleDescription = resources.GetString("printPreviewBarItem12.AccessibleDescription");
            this.printPreviewBarItem12.AccessibleName = resources.GetString("printPreviewBarItem12.AccessibleName");
            this.printPreviewBarItem12.Caption = resources.GetString("printPreviewBarItem12.Caption");
            this.printPreviewBarItem12.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowFirstPage;
            this.printPreviewBarItem12.Description = resources.GetString("printPreviewBarItem12.Description");
            this.printPreviewBarItem12.Enabled = false;
            this.printPreviewBarItem12.Hint = resources.GetString("printPreviewBarItem12.Hint");
            this.printPreviewBarItem12.Id = 15;
            this.printPreviewBarItem12.ImageIndex = 7;
            this.printPreviewBarItem12.Name = "printPreviewBarItem12";
            // 
            // printPreviewBarItem13
            // 
            this.printPreviewBarItem13.AccessibleDescription = resources.GetString("printPreviewBarItem13.AccessibleDescription");
            this.printPreviewBarItem13.AccessibleName = resources.GetString("printPreviewBarItem13.AccessibleName");
            this.printPreviewBarItem13.Caption = resources.GetString("printPreviewBarItem13.Caption");
            this.printPreviewBarItem13.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowPrevPage;
            this.printPreviewBarItem13.Description = resources.GetString("printPreviewBarItem13.Description");
            this.printPreviewBarItem13.Enabled = false;
            this.printPreviewBarItem13.Hint = resources.GetString("printPreviewBarItem13.Hint");
            this.printPreviewBarItem13.Id = 16;
            this.printPreviewBarItem13.ImageIndex = 8;
            this.printPreviewBarItem13.Name = "printPreviewBarItem13";
            // 
            // printPreviewBarItem14
            // 
            this.printPreviewBarItem14.AccessibleDescription = resources.GetString("printPreviewBarItem14.AccessibleDescription");
            this.printPreviewBarItem14.AccessibleName = resources.GetString("printPreviewBarItem14.AccessibleName");
            this.printPreviewBarItem14.Caption = resources.GetString("printPreviewBarItem14.Caption");
            this.printPreviewBarItem14.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowNextPage;
            this.printPreviewBarItem14.Description = resources.GetString("printPreviewBarItem14.Description");
            this.printPreviewBarItem14.Enabled = false;
            this.printPreviewBarItem14.Hint = resources.GetString("printPreviewBarItem14.Hint");
            this.printPreviewBarItem14.Id = 17;
            this.printPreviewBarItem14.ImageIndex = 9;
            this.printPreviewBarItem14.Name = "printPreviewBarItem14";
            // 
            // printPreviewBarItem15
            // 
            this.printPreviewBarItem15.AccessibleDescription = resources.GetString("printPreviewBarItem15.AccessibleDescription");
            this.printPreviewBarItem15.AccessibleName = resources.GetString("printPreviewBarItem15.AccessibleName");
            this.printPreviewBarItem15.Caption = resources.GetString("printPreviewBarItem15.Caption");
            this.printPreviewBarItem15.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowLastPage;
            this.printPreviewBarItem15.Description = resources.GetString("printPreviewBarItem15.Description");
            this.printPreviewBarItem15.Enabled = false;
            this.printPreviewBarItem15.Hint = resources.GetString("printPreviewBarItem15.Hint");
            this.printPreviewBarItem15.Id = 18;
            this.printPreviewBarItem15.ImageIndex = 10;
            this.printPreviewBarItem15.Name = "printPreviewBarItem15";
            // 
            // printPreviewBarItem16
            // 
            this.printPreviewBarItem16.AccessibleDescription = resources.GetString("printPreviewBarItem16.AccessibleDescription");
            this.printPreviewBarItem16.AccessibleName = resources.GetString("printPreviewBarItem16.AccessibleName");
            this.printPreviewBarItem16.ActAsDropDown = true;
            this.printPreviewBarItem16.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.printPreviewBarItem16.Caption = resources.GetString("printPreviewBarItem16.Caption");
            this.printPreviewBarItem16.Command = DevExpress.XtraPrinting.PrintingSystemCommand.MultiplePages;
            this.printPreviewBarItem16.Description = resources.GetString("printPreviewBarItem16.Description");
            this.printPreviewBarItem16.DropDownControl = this.multiplePagesControlContainer1;
            this.printPreviewBarItem16.Enabled = false;
            this.printPreviewBarItem16.Hint = resources.GetString("printPreviewBarItem16.Hint");
            this.printPreviewBarItem16.Id = 19;
            this.printPreviewBarItem16.ImageIndex = 11;
            this.printPreviewBarItem16.Name = "printPreviewBarItem16";
            // 
            // multiplePagesControlContainer1
            // 
            this.multiplePagesControlContainer1.AccessibleDescription = resources.GetString("multiplePagesControlContainer1.AccessibleDescription");
            this.multiplePagesControlContainer1.AccessibleName = resources.GetString("multiplePagesControlContainer1.AccessibleName");
            this.multiplePagesControlContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("multiplePagesControlContainer1.Anchor")));
            this.multiplePagesControlContainer1.AutoScroll = ((bool)(resources.GetObject("multiplePagesControlContainer1.AutoScroll")));
            this.multiplePagesControlContainer1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("multiplePagesControlContainer1.AutoScrollMargin")));
            this.multiplePagesControlContainer1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("multiplePagesControlContainer1.AutoScrollMinSize")));
            this.multiplePagesControlContainer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("multiplePagesControlContainer1.BackgroundImage")));
            this.multiplePagesControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.multiplePagesControlContainer1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("multiplePagesControlContainer1.Dock")));
            this.multiplePagesControlContainer1.Enabled = ((bool)(resources.GetObject("multiplePagesControlContainer1.Enabled")));
            this.multiplePagesControlContainer1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("multiplePagesControlContainer1.ImeMode")));
            this.multiplePagesControlContainer1.Location = ((System.Drawing.Point)(resources.GetObject("multiplePagesControlContainer1.Location")));
            this.multiplePagesControlContainer1.Manager = this.printBarManager1;
            this.multiplePagesControlContainer1.Name = "multiplePagesControlContainer1";
            this.multiplePagesControlContainer1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("multiplePagesControlContainer1.RightToLeft")));
            this.multiplePagesControlContainer1.Size = ((System.Drawing.Size)(resources.GetObject("multiplePagesControlContainer1.Size")));
            this.multiplePagesControlContainer1.TabIndex = ((int)(resources.GetObject("multiplePagesControlContainer1.TabIndex")));
            this.multiplePagesControlContainer1.Text = resources.GetString("multiplePagesControlContainer1.Text");
            this.multiplePagesControlContainer1.Visible = ((bool)(resources.GetObject("multiplePagesControlContainer1.Visible")));
            // 
            // printPreviewBarItem17
            // 
            this.printPreviewBarItem17.AccessibleDescription = resources.GetString("printPreviewBarItem17.AccessibleDescription");
            this.printPreviewBarItem17.AccessibleName = resources.GetString("printPreviewBarItem17.AccessibleName");
            this.printPreviewBarItem17.ActAsDropDown = true;
            this.printPreviewBarItem17.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.printPreviewBarItem17.Caption = resources.GetString("printPreviewBarItem17.Caption");
            this.printPreviewBarItem17.Command = DevExpress.XtraPrinting.PrintingSystemCommand.FillBackground;
            this.printPreviewBarItem17.Description = resources.GetString("printPreviewBarItem17.Description");
            this.printPreviewBarItem17.DropDownControl = this.colorPopupControlContainer1;
            this.printPreviewBarItem17.Enabled = false;
            this.printPreviewBarItem17.Hint = resources.GetString("printPreviewBarItem17.Hint");
            this.printPreviewBarItem17.Id = 20;
            this.printPreviewBarItem17.ImageIndex = 12;
            this.printPreviewBarItem17.Name = "printPreviewBarItem17";
            // 
            // colorPopupControlContainer1
            // 
            this.colorPopupControlContainer1.AccessibleDescription = resources.GetString("colorPopupControlContainer1.AccessibleDescription");
            this.colorPopupControlContainer1.AccessibleName = resources.GetString("colorPopupControlContainer1.AccessibleName");
            this.colorPopupControlContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("colorPopupControlContainer1.Anchor")));
            this.colorPopupControlContainer1.AutoScroll = ((bool)(resources.GetObject("colorPopupControlContainer1.AutoScroll")));
            this.colorPopupControlContainer1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("colorPopupControlContainer1.AutoScrollMargin")));
            this.colorPopupControlContainer1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("colorPopupControlContainer1.AutoScrollMinSize")));
            this.colorPopupControlContainer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorPopupControlContainer1.BackgroundImage")));
            this.colorPopupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.colorPopupControlContainer1.ColorRectangle = new System.Drawing.Rectangle(7, 7, 8, 8);
            this.colorPopupControlContainer1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("colorPopupControlContainer1.Dock")));
            this.colorPopupControlContainer1.DrawColorRectangle = false;
            this.colorPopupControlContainer1.Enabled = ((bool)(resources.GetObject("colorPopupControlContainer1.Enabled")));
            this.colorPopupControlContainer1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("colorPopupControlContainer1.ImeMode")));
            this.colorPopupControlContainer1.Item = this.printPreviewBarItem17;
            this.colorPopupControlContainer1.Location = ((System.Drawing.Point)(resources.GetObject("colorPopupControlContainer1.Location")));
            this.colorPopupControlContainer1.Manager = this.printBarManager1;
            this.colorPopupControlContainer1.Name = "colorPopupControlContainer1";
            this.colorPopupControlContainer1.ResultColor = System.Drawing.Color.Empty;
            this.colorPopupControlContainer1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("colorPopupControlContainer1.RightToLeft")));
            this.colorPopupControlContainer1.Size = ((System.Drawing.Size)(resources.GetObject("colorPopupControlContainer1.Size")));
            this.colorPopupControlContainer1.TabIndex = ((int)(resources.GetObject("colorPopupControlContainer1.TabIndex")));
            this.colorPopupControlContainer1.Text = resources.GetString("colorPopupControlContainer1.Text");
            this.colorPopupControlContainer1.Visible = ((bool)(resources.GetObject("colorPopupControlContainer1.Visible")));
            // 
            // printPreviewBarItem18
            // 
            this.printPreviewBarItem18.AccessibleDescription = resources.GetString("printPreviewBarItem18.AccessibleDescription");
            this.printPreviewBarItem18.AccessibleName = resources.GetString("printPreviewBarItem18.AccessibleName");
            this.printPreviewBarItem18.Caption = resources.GetString("printPreviewBarItem18.Caption");
            this.printPreviewBarItem18.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Watermark;
            this.printPreviewBarItem18.Description = resources.GetString("printPreviewBarItem18.Description");
            this.printPreviewBarItem18.Enabled = false;
            this.printPreviewBarItem18.Hint = resources.GetString("printPreviewBarItem18.Hint");
            this.printPreviewBarItem18.Id = 21;
            this.printPreviewBarItem18.ImageIndex = 21;
            this.printPreviewBarItem18.Name = "printPreviewBarItem18";
            // 
            // printPreviewBarItem19
            // 
            this.printPreviewBarItem19.AccessibleDescription = resources.GetString("printPreviewBarItem19.AccessibleDescription");
            this.printPreviewBarItem19.AccessibleName = resources.GetString("printPreviewBarItem19.AccessibleName");
            this.printPreviewBarItem19.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.printPreviewBarItem19.Caption = resources.GetString("printPreviewBarItem19.Caption");
            this.printPreviewBarItem19.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile;
            this.printPreviewBarItem19.Description = resources.GetString("printPreviewBarItem19.Description");
            this.printPreviewBarItem19.Enabled = false;
            this.printPreviewBarItem19.Hint = resources.GetString("printPreviewBarItem19.Hint");
            this.printPreviewBarItem19.Id = 22;
            this.printPreviewBarItem19.ImageIndex = 18;
            this.printPreviewBarItem19.Name = "printPreviewBarItem19";
            // 
            // printPreviewBarItem20
            // 
            this.printPreviewBarItem20.AccessibleDescription = resources.GetString("printPreviewBarItem20.AccessibleDescription");
            this.printPreviewBarItem20.AccessibleName = resources.GetString("printPreviewBarItem20.AccessibleName");
            this.printPreviewBarItem20.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.printPreviewBarItem20.Caption = resources.GetString("printPreviewBarItem20.Caption");
            this.printPreviewBarItem20.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendFile;
            this.printPreviewBarItem20.Description = resources.GetString("printPreviewBarItem20.Description");
            this.printPreviewBarItem20.Enabled = false;
            this.printPreviewBarItem20.Hint = resources.GetString("printPreviewBarItem20.Hint");
            this.printPreviewBarItem20.Id = 23;
            this.printPreviewBarItem20.ImageIndex = 17;
            this.printPreviewBarItem20.Name = "printPreviewBarItem20";
            // 
            // printPreviewBarItem21
            // 
            this.printPreviewBarItem21.AccessibleDescription = resources.GetString("printPreviewBarItem21.AccessibleDescription");
            this.printPreviewBarItem21.AccessibleName = resources.GetString("printPreviewBarItem21.AccessibleName");
            this.printPreviewBarItem21.Caption = resources.GetString("printPreviewBarItem21.Caption");
            this.printPreviewBarItem21.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ClosePreview;
            this.printPreviewBarItem21.Description = resources.GetString("printPreviewBarItem21.Description");
            this.printPreviewBarItem21.Enabled = false;
            this.printPreviewBarItem21.Hint = resources.GetString("printPreviewBarItem21.Hint");
            this.printPreviewBarItem21.Id = 24;
            this.printPreviewBarItem21.ImageIndex = 13;
            this.printPreviewBarItem21.Name = "printPreviewBarItem21";
            // 
            // previewBar2
            // 
            this.previewBar2.BarName = "Status Bar";
            this.previewBar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.previewBar2.DockCol = 0;
            this.previewBar2.DockRow = 0;
            this.previewBar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.previewBar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewStaticItem1),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewStaticItem2),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewStaticItem3)});
            this.previewBar2.OptionsBar.AllowQuickCustomization = false;
            this.previewBar2.OptionsBar.DrawDragBorder = false;
            this.previewBar2.OptionsBar.UseWholeRow = true;
            this.previewBar2.Text = resources.GetString("previewBar2.Text");
            // 
            // printPreviewStaticItem1
            // 
            this.printPreviewStaticItem1.AccessibleDescription = resources.GetString("printPreviewStaticItem1.AccessibleDescription");
            this.printPreviewStaticItem1.AccessibleName = resources.GetString("printPreviewStaticItem1.AccessibleName");
            this.printPreviewStaticItem1.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.printPreviewStaticItem1.Caption = resources.GetString("printPreviewStaticItem1.Caption");
            this.printPreviewStaticItem1.Description = resources.GetString("printPreviewStaticItem1.Description");
            this.printPreviewStaticItem1.Hint = resources.GetString("printPreviewStaticItem1.Hint");
            this.printPreviewStaticItem1.Id = 0;
            this.printPreviewStaticItem1.Name = "printPreviewStaticItem1";
            this.printPreviewStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.printPreviewStaticItem1.Type = "CurrentPageNo";
            this.printPreviewStaticItem1.Width = 200;
            // 
            // printPreviewStaticItem2
            // 
            this.printPreviewStaticItem2.AccessibleDescription = resources.GetString("printPreviewStaticItem2.AccessibleDescription");
            this.printPreviewStaticItem2.AccessibleName = resources.GetString("printPreviewStaticItem2.AccessibleName");
            this.printPreviewStaticItem2.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.printPreviewStaticItem2.Caption = resources.GetString("printPreviewStaticItem2.Caption");
            this.printPreviewStaticItem2.Description = resources.GetString("printPreviewStaticItem2.Description");
            this.printPreviewStaticItem2.Hint = resources.GetString("printPreviewStaticItem2.Hint");
            this.printPreviewStaticItem2.Id = 1;
            this.printPreviewStaticItem2.Name = "printPreviewStaticItem2";
            this.printPreviewStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            this.printPreviewStaticItem2.Type = "TotalPageNo";
            this.printPreviewStaticItem2.Width = 200;
            // 
            // printPreviewStaticItem3
            // 
            this.printPreviewStaticItem3.AccessibleDescription = resources.GetString("printPreviewStaticItem3.AccessibleDescription");
            this.printPreviewStaticItem3.AccessibleName = resources.GetString("printPreviewStaticItem3.AccessibleName");
            this.printPreviewStaticItem3.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.printPreviewStaticItem3.Caption = resources.GetString("printPreviewStaticItem3.Caption");
            this.printPreviewStaticItem3.Description = resources.GetString("printPreviewStaticItem3.Description");
            this.printPreviewStaticItem3.Hint = resources.GetString("printPreviewStaticItem3.Hint");
            this.printPreviewStaticItem3.Id = 2;
            this.printPreviewStaticItem3.Name = "printPreviewStaticItem3";
            this.printPreviewStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            this.printPreviewStaticItem3.Type = "ZoomFactor";
            this.printPreviewStaticItem3.Width = 200;
            // 
            // previewBar3
            // 
            this.previewBar3.BarName = "Main Menu";
            this.previewBar3.DockCol = 0;
            this.previewBar3.DockRow = 0;
            this.previewBar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.previewBar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3)});
            this.previewBar3.OptionsBar.MultiLine = true;
            this.previewBar3.OptionsBar.UseWholeRow = true;
            this.previewBar3.Text = resources.GetString("previewBar3.Text");
            // 
            // barSubItem1
            // 
            this.barSubItem1.AccessibleDescription = resources.GetString("barSubItem1.AccessibleDescription");
            this.barSubItem1.AccessibleName = resources.GetString("barSubItem1.AccessibleName");
            this.barSubItem1.Caption = resources.GetString("barSubItem1.Caption");
            this.barSubItem1.Description = resources.GetString("barSubItem1.Description");
            this.barSubItem1.Hint = resources.GetString("barSubItem1.Hint");
            this.barSubItem1.Id = 25;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem6),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem4),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem5),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem19, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem20),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem21, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem2
            // 
            this.barSubItem2.AccessibleDescription = resources.GetString("barSubItem2.AccessibleDescription");
            this.barSubItem2.AccessibleName = resources.GetString("barSubItem2.AccessibleName");
            this.barSubItem2.Caption = resources.GetString("barSubItem2.Caption");
            this.barSubItem2.Description = resources.GetString("barSubItem2.Description");
            this.barSubItem2.Hint = resources.GetString("barSubItem2.Hint");
            this.barSubItem2.Id = 26;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4, true),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.barToolbarsListItem1, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem4
            // 
            this.barSubItem4.AccessibleDescription = resources.GetString("barSubItem4.AccessibleDescription");
            this.barSubItem4.AccessibleName = resources.GetString("barSubItem4.AccessibleName");
            this.barSubItem4.Caption = resources.GetString("barSubItem4.Caption");
            this.barSubItem4.Description = resources.GetString("barSubItem4.Description");
            this.barSubItem4.Hint = resources.GetString("barSubItem4.Hint");
            this.barSubItem4.Id = 28;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem22),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem23)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // printPreviewBarItem22
            // 
            this.printPreviewBarItem22.AccessibleDescription = resources.GetString("printPreviewBarItem22.AccessibleDescription");
            this.printPreviewBarItem22.AccessibleName = resources.GetString("printPreviewBarItem22.AccessibleName");
            this.printPreviewBarItem22.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem22.Caption = resources.GetString("printPreviewBarItem22.Caption");
            this.printPreviewBarItem22.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutFacing;
            this.printPreviewBarItem22.Description = resources.GetString("printPreviewBarItem22.Description");
            this.printPreviewBarItem22.Enabled = false;
            this.printPreviewBarItem22.GroupIndex = 100;
            this.printPreviewBarItem22.Hint = resources.GetString("printPreviewBarItem22.Hint");
            this.printPreviewBarItem22.Id = 29;
            this.printPreviewBarItem22.Name = "printPreviewBarItem22";
            // 
            // printPreviewBarItem23
            // 
            this.printPreviewBarItem23.AccessibleDescription = resources.GetString("printPreviewBarItem23.AccessibleDescription");
            this.printPreviewBarItem23.AccessibleName = resources.GetString("printPreviewBarItem23.AccessibleName");
            this.printPreviewBarItem23.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.printPreviewBarItem23.Caption = resources.GetString("printPreviewBarItem23.Caption");
            this.printPreviewBarItem23.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutContinuous;
            this.printPreviewBarItem23.Description = resources.GetString("printPreviewBarItem23.Description");
            this.printPreviewBarItem23.Enabled = false;
            this.printPreviewBarItem23.GroupIndex = 100;
            this.printPreviewBarItem23.Hint = resources.GetString("printPreviewBarItem23.Hint");
            this.printPreviewBarItem23.Id = 30;
            this.printPreviewBarItem23.Name = "printPreviewBarItem23";
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.AccessibleDescription = resources.GetString("barToolbarsListItem1.AccessibleDescription");
            this.barToolbarsListItem1.AccessibleName = resources.GetString("barToolbarsListItem1.AccessibleName");
            this.barToolbarsListItem1.Caption = resources.GetString("barToolbarsListItem1.Caption");
            this.barToolbarsListItem1.Description = resources.GetString("barToolbarsListItem1.Description");
            this.barToolbarsListItem1.Hint = resources.GetString("barToolbarsListItem1.Hint");
            this.barToolbarsListItem1.Id = 31;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            // 
            // barSubItem3
            // 
            this.barSubItem3.AccessibleDescription = resources.GetString("barSubItem3.AccessibleDescription");
            this.barSubItem3.AccessibleName = resources.GetString("barSubItem3.AccessibleName");
            this.barSubItem3.Caption = resources.GetString("barSubItem3.Caption");
            this.barSubItem3.Description = resources.GetString("barSubItem3.Description");
            this.barSubItem3.Hint = resources.GetString("barSubItem3.Hint");
            this.barSubItem3.Id = 27;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem17),
                                                                                                     new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem18)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.AccessibleDescription = resources.GetString("barDockControlTop.AccessibleDescription");
            this.barDockControlTop.AccessibleName = resources.GetString("barDockControlTop.AccessibleName");
            this.barDockControlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("barDockControlTop.Anchor")));
            this.barDockControlTop.Enabled = ((bool)(resources.GetObject("barDockControlTop.Enabled")));
            this.barDockControlTop.Font = ((System.Drawing.Font)(resources.GetObject("barDockControlTop.Font")));
            this.barDockControlTop.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("barDockControlTop.ImeMode")));
            this.barDockControlTop.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("barDockControlTop.RightToLeft")));
            this.barDockControlTop.Text = resources.GetString("barDockControlTop.Text");
            this.barDockControlTop.Visible = ((bool)(resources.GetObject("barDockControlTop.Visible")));
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.AccessibleDescription = resources.GetString("barDockControlBottom.AccessibleDescription");
            this.barDockControlBottom.AccessibleName = resources.GetString("barDockControlBottom.AccessibleName");
            this.barDockControlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("barDockControlBottom.Anchor")));
            this.barDockControlBottom.Enabled = ((bool)(resources.GetObject("barDockControlBottom.Enabled")));
            this.barDockControlBottom.Font = ((System.Drawing.Font)(resources.GetObject("barDockControlBottom.Font")));
            this.barDockControlBottom.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("barDockControlBottom.ImeMode")));
            this.barDockControlBottom.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("barDockControlBottom.RightToLeft")));
            this.barDockControlBottom.Text = resources.GetString("barDockControlBottom.Text");
            this.barDockControlBottom.Visible = ((bool)(resources.GetObject("barDockControlBottom.Visible")));
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.AccessibleDescription = resources.GetString("barDockControlLeft.AccessibleDescription");
            this.barDockControlLeft.AccessibleName = resources.GetString("barDockControlLeft.AccessibleName");
            this.barDockControlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("barDockControlLeft.Anchor")));
            this.barDockControlLeft.Enabled = ((bool)(resources.GetObject("barDockControlLeft.Enabled")));
            this.barDockControlLeft.Font = ((System.Drawing.Font)(resources.GetObject("barDockControlLeft.Font")));
            this.barDockControlLeft.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("barDockControlLeft.ImeMode")));
            this.barDockControlLeft.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("barDockControlLeft.RightToLeft")));
            this.barDockControlLeft.Text = resources.GetString("barDockControlLeft.Text");
            this.barDockControlLeft.Visible = ((bool)(resources.GetObject("barDockControlLeft.Visible")));
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.AccessibleDescription = resources.GetString("barDockControlRight.AccessibleDescription");
            this.barDockControlRight.AccessibleName = resources.GetString("barDockControlRight.AccessibleName");
            this.barDockControlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("barDockControlRight.Anchor")));
            this.barDockControlRight.Enabled = ((bool)(resources.GetObject("barDockControlRight.Enabled")));
            this.barDockControlRight.Font = ((System.Drawing.Font)(resources.GetObject("barDockControlRight.Font")));
            this.barDockControlRight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("barDockControlRight.ImeMode")));
            this.barDockControlRight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("barDockControlRight.RightToLeft")));
            this.barDockControlRight.Text = resources.GetString("barDockControlRight.Text");
            this.barDockControlRight.Visible = ((bool)(resources.GetObject("barDockControlRight.Visible")));
            // 
            // printPreviewBarCheckItem1
            // 
            this.printPreviewBarCheckItem1.AccessibleDescription = resources.GetString("printPreviewBarCheckItem1.AccessibleDescription");
            this.printPreviewBarCheckItem1.AccessibleName = resources.GetString("printPreviewBarCheckItem1.AccessibleName");
            this.printPreviewBarCheckItem1.Caption = resources.GetString("printPreviewBarCheckItem1.Caption");
            this.printPreviewBarCheckItem1.Checked = true;
            this.printPreviewBarCheckItem1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportPdf;
            this.printPreviewBarCheckItem1.Description = resources.GetString("printPreviewBarCheckItem1.Description");
            this.printPreviewBarCheckItem1.Enabled = false;
            this.printPreviewBarCheckItem1.GroupIndex = 1;
            this.printPreviewBarCheckItem1.Hint = resources.GetString("printPreviewBarCheckItem1.Hint");
            this.printPreviewBarCheckItem1.Id = 32;
            this.printPreviewBarCheckItem1.Name = "printPreviewBarCheckItem1";
            // 
            // printPreviewBarCheckItem2
            // 
            this.printPreviewBarCheckItem2.AccessibleDescription = resources.GetString("printPreviewBarCheckItem2.AccessibleDescription");
            this.printPreviewBarCheckItem2.AccessibleName = resources.GetString("printPreviewBarCheckItem2.AccessibleName");
            this.printPreviewBarCheckItem2.Caption = resources.GetString("printPreviewBarCheckItem2.Caption");
            this.printPreviewBarCheckItem2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm;
            this.printPreviewBarCheckItem2.Description = resources.GetString("printPreviewBarCheckItem2.Description");
            this.printPreviewBarCheckItem2.Enabled = false;
            this.printPreviewBarCheckItem2.GroupIndex = 1;
            this.printPreviewBarCheckItem2.Hint = resources.GetString("printPreviewBarCheckItem2.Hint");
            this.printPreviewBarCheckItem2.Id = 33;
            this.printPreviewBarCheckItem2.Name = "printPreviewBarCheckItem2";
            // 
            // printPreviewBarCheckItem3
            // 
            this.printPreviewBarCheckItem3.AccessibleDescription = resources.GetString("printPreviewBarCheckItem3.AccessibleDescription");
            this.printPreviewBarCheckItem3.AccessibleName = resources.GetString("printPreviewBarCheckItem3.AccessibleName");
            this.printPreviewBarCheckItem3.Caption = resources.GetString("printPreviewBarCheckItem3.Caption");
            this.printPreviewBarCheckItem3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportTxt;
            this.printPreviewBarCheckItem3.Description = resources.GetString("printPreviewBarCheckItem3.Description");
            this.printPreviewBarCheckItem3.Enabled = false;
            this.printPreviewBarCheckItem3.GroupIndex = 1;
            this.printPreviewBarCheckItem3.Hint = resources.GetString("printPreviewBarCheckItem3.Hint");
            this.printPreviewBarCheckItem3.Id = 34;
            this.printPreviewBarCheckItem3.Name = "printPreviewBarCheckItem3";
            // 
            // printPreviewBarCheckItem4
            // 
            this.printPreviewBarCheckItem4.AccessibleDescription = resources.GetString("printPreviewBarCheckItem4.AccessibleDescription");
            this.printPreviewBarCheckItem4.AccessibleName = resources.GetString("printPreviewBarCheckItem4.AccessibleName");
            this.printPreviewBarCheckItem4.Caption = resources.GetString("printPreviewBarCheckItem4.Caption");
            this.printPreviewBarCheckItem4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportCsv;
            this.printPreviewBarCheckItem4.Description = resources.GetString("printPreviewBarCheckItem4.Description");
            this.printPreviewBarCheckItem4.Enabled = false;
            this.printPreviewBarCheckItem4.GroupIndex = 1;
            this.printPreviewBarCheckItem4.Hint = resources.GetString("printPreviewBarCheckItem4.Hint");
            this.printPreviewBarCheckItem4.Id = 35;
            this.printPreviewBarCheckItem4.Name = "printPreviewBarCheckItem4";
            // 
            // printPreviewBarCheckItem5
            // 
            this.printPreviewBarCheckItem5.AccessibleDescription = resources.GetString("printPreviewBarCheckItem5.AccessibleDescription");
            this.printPreviewBarCheckItem5.AccessibleName = resources.GetString("printPreviewBarCheckItem5.AccessibleName");
            this.printPreviewBarCheckItem5.Caption = resources.GetString("printPreviewBarCheckItem5.Caption");
            this.printPreviewBarCheckItem5.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht;
            this.printPreviewBarCheckItem5.Description = resources.GetString("printPreviewBarCheckItem5.Description");
            this.printPreviewBarCheckItem5.Enabled = false;
            this.printPreviewBarCheckItem5.GroupIndex = 1;
            this.printPreviewBarCheckItem5.Hint = resources.GetString("printPreviewBarCheckItem5.Hint");
            this.printPreviewBarCheckItem5.Id = 36;
            this.printPreviewBarCheckItem5.Name = "printPreviewBarCheckItem5";
            // 
            // printPreviewBarCheckItem6
            // 
            this.printPreviewBarCheckItem6.AccessibleDescription = resources.GetString("printPreviewBarCheckItem6.AccessibleDescription");
            this.printPreviewBarCheckItem6.AccessibleName = resources.GetString("printPreviewBarCheckItem6.AccessibleName");
            this.printPreviewBarCheckItem6.Caption = resources.GetString("printPreviewBarCheckItem6.Caption");
            this.printPreviewBarCheckItem6.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls;
            this.printPreviewBarCheckItem6.Description = resources.GetString("printPreviewBarCheckItem6.Description");
            this.printPreviewBarCheckItem6.Enabled = false;
            this.printPreviewBarCheckItem6.GroupIndex = 1;
            this.printPreviewBarCheckItem6.Hint = resources.GetString("printPreviewBarCheckItem6.Hint");
            this.printPreviewBarCheckItem6.Id = 37;
            this.printPreviewBarCheckItem6.Name = "printPreviewBarCheckItem6";
            // 
            // printPreviewBarCheckItem7
            // 
            this.printPreviewBarCheckItem7.AccessibleDescription = resources.GetString("printPreviewBarCheckItem7.AccessibleDescription");
            this.printPreviewBarCheckItem7.AccessibleName = resources.GetString("printPreviewBarCheckItem7.AccessibleName");
            this.printPreviewBarCheckItem7.Caption = resources.GetString("printPreviewBarCheckItem7.Caption");
            this.printPreviewBarCheckItem7.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf;
            this.printPreviewBarCheckItem7.Description = resources.GetString("printPreviewBarCheckItem7.Description");
            this.printPreviewBarCheckItem7.Enabled = false;
            this.printPreviewBarCheckItem7.GroupIndex = 1;
            this.printPreviewBarCheckItem7.Hint = resources.GetString("printPreviewBarCheckItem7.Hint");
            this.printPreviewBarCheckItem7.Id = 38;
            this.printPreviewBarCheckItem7.Name = "printPreviewBarCheckItem7";
            // 
            // printPreviewBarCheckItem8
            // 
            this.printPreviewBarCheckItem8.AccessibleDescription = resources.GetString("printPreviewBarCheckItem8.AccessibleDescription");
            this.printPreviewBarCheckItem8.AccessibleName = resources.GetString("printPreviewBarCheckItem8.AccessibleName");
            this.printPreviewBarCheckItem8.Caption = resources.GetString("printPreviewBarCheckItem8.Caption");
            this.printPreviewBarCheckItem8.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportGraphic;
            this.printPreviewBarCheckItem8.Description = resources.GetString("printPreviewBarCheckItem8.Description");
            this.printPreviewBarCheckItem8.Enabled = false;
            this.printPreviewBarCheckItem8.GroupIndex = 1;
            this.printPreviewBarCheckItem8.Hint = resources.GetString("printPreviewBarCheckItem8.Hint");
            this.printPreviewBarCheckItem8.Id = 39;
            this.printPreviewBarCheckItem8.Name = "printPreviewBarCheckItem8";
            // 
            // printPreviewBarCheckItem9
            // 
            this.printPreviewBarCheckItem9.AccessibleDescription = resources.GetString("printPreviewBarCheckItem9.AccessibleDescription");
            this.printPreviewBarCheckItem9.AccessibleName = resources.GetString("printPreviewBarCheckItem9.AccessibleName");
            this.printPreviewBarCheckItem9.Caption = resources.GetString("printPreviewBarCheckItem9.Caption");
            this.printPreviewBarCheckItem9.Checked = true;
            this.printPreviewBarCheckItem9.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf;
            this.printPreviewBarCheckItem9.Description = resources.GetString("printPreviewBarCheckItem9.Description");
            this.printPreviewBarCheckItem9.Enabled = false;
            this.printPreviewBarCheckItem9.GroupIndex = 2;
            this.printPreviewBarCheckItem9.Hint = resources.GetString("printPreviewBarCheckItem9.Hint");
            this.printPreviewBarCheckItem9.Id = 40;
            this.printPreviewBarCheckItem9.Name = "printPreviewBarCheckItem9";
            // 
            // printPreviewBarCheckItem10
            // 
            this.printPreviewBarCheckItem10.AccessibleDescription = resources.GetString("printPreviewBarCheckItem10.AccessibleDescription");
            this.printPreviewBarCheckItem10.AccessibleName = resources.GetString("printPreviewBarCheckItem10.AccessibleName");
            this.printPreviewBarCheckItem10.Caption = resources.GetString("printPreviewBarCheckItem10.Caption");
            this.printPreviewBarCheckItem10.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt;
            this.printPreviewBarCheckItem10.Description = resources.GetString("printPreviewBarCheckItem10.Description");
            this.printPreviewBarCheckItem10.Enabled = false;
            this.printPreviewBarCheckItem10.GroupIndex = 2;
            this.printPreviewBarCheckItem10.Hint = resources.GetString("printPreviewBarCheckItem10.Hint");
            this.printPreviewBarCheckItem10.Id = 41;
            this.printPreviewBarCheckItem10.Name = "printPreviewBarCheckItem10";
            // 
            // printPreviewBarCheckItem11
            // 
            this.printPreviewBarCheckItem11.AccessibleDescription = resources.GetString("printPreviewBarCheckItem11.AccessibleDescription");
            this.printPreviewBarCheckItem11.AccessibleName = resources.GetString("printPreviewBarCheckItem11.AccessibleName");
            this.printPreviewBarCheckItem11.Caption = resources.GetString("printPreviewBarCheckItem11.Caption");
            this.printPreviewBarCheckItem11.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv;
            this.printPreviewBarCheckItem11.Description = resources.GetString("printPreviewBarCheckItem11.Description");
            this.printPreviewBarCheckItem11.Enabled = false;
            this.printPreviewBarCheckItem11.GroupIndex = 2;
            this.printPreviewBarCheckItem11.Hint = resources.GetString("printPreviewBarCheckItem11.Hint");
            this.printPreviewBarCheckItem11.Id = 42;
            this.printPreviewBarCheckItem11.Name = "printPreviewBarCheckItem11";
            // 
            // printPreviewBarCheckItem12
            // 
            this.printPreviewBarCheckItem12.AccessibleDescription = resources.GetString("printPreviewBarCheckItem12.AccessibleDescription");
            this.printPreviewBarCheckItem12.AccessibleName = resources.GetString("printPreviewBarCheckItem12.AccessibleName");
            this.printPreviewBarCheckItem12.Caption = resources.GetString("printPreviewBarCheckItem12.Caption");
            this.printPreviewBarCheckItem12.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendMht;
            this.printPreviewBarCheckItem12.Description = resources.GetString("printPreviewBarCheckItem12.Description");
            this.printPreviewBarCheckItem12.Enabled = false;
            this.printPreviewBarCheckItem12.GroupIndex = 2;
            this.printPreviewBarCheckItem12.Hint = resources.GetString("printPreviewBarCheckItem12.Hint");
            this.printPreviewBarCheckItem12.Id = 43;
            this.printPreviewBarCheckItem12.Name = "printPreviewBarCheckItem12";
            // 
            // printPreviewBarCheckItem13
            // 
            this.printPreviewBarCheckItem13.AccessibleDescription = resources.GetString("printPreviewBarCheckItem13.AccessibleDescription");
            this.printPreviewBarCheckItem13.AccessibleName = resources.GetString("printPreviewBarCheckItem13.AccessibleName");
            this.printPreviewBarCheckItem13.Caption = resources.GetString("printPreviewBarCheckItem13.Caption");
            this.printPreviewBarCheckItem13.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendXls;
            this.printPreviewBarCheckItem13.Description = resources.GetString("printPreviewBarCheckItem13.Description");
            this.printPreviewBarCheckItem13.Enabled = false;
            this.printPreviewBarCheckItem13.GroupIndex = 2;
            this.printPreviewBarCheckItem13.Hint = resources.GetString("printPreviewBarCheckItem13.Hint");
            this.printPreviewBarCheckItem13.Id = 44;
            this.printPreviewBarCheckItem13.Name = "printPreviewBarCheckItem13";
            // 
            // printPreviewBarCheckItem14
            // 
            this.printPreviewBarCheckItem14.AccessibleDescription = resources.GetString("printPreviewBarCheckItem14.AccessibleDescription");
            this.printPreviewBarCheckItem14.AccessibleName = resources.GetString("printPreviewBarCheckItem14.AccessibleName");
            this.printPreviewBarCheckItem14.Caption = resources.GetString("printPreviewBarCheckItem14.Caption");
            this.printPreviewBarCheckItem14.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf;
            this.printPreviewBarCheckItem14.Description = resources.GetString("printPreviewBarCheckItem14.Description");
            this.printPreviewBarCheckItem14.Enabled = false;
            this.printPreviewBarCheckItem14.GroupIndex = 2;
            this.printPreviewBarCheckItem14.Hint = resources.GetString("printPreviewBarCheckItem14.Hint");
            this.printPreviewBarCheckItem14.Id = 45;
            this.printPreviewBarCheckItem14.Name = "printPreviewBarCheckItem14";
            // 
            // printPreviewBarCheckItem15
            // 
            this.printPreviewBarCheckItem15.AccessibleDescription = resources.GetString("printPreviewBarCheckItem15.AccessibleDescription");
            this.printPreviewBarCheckItem15.AccessibleName = resources.GetString("printPreviewBarCheckItem15.AccessibleName");
            this.printPreviewBarCheckItem15.Caption = resources.GetString("printPreviewBarCheckItem15.Caption");
            this.printPreviewBarCheckItem15.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic;
            this.printPreviewBarCheckItem15.Description = resources.GetString("printPreviewBarCheckItem15.Description");
            this.printPreviewBarCheckItem15.Enabled = false;
            this.printPreviewBarCheckItem15.GroupIndex = 2;
            this.printPreviewBarCheckItem15.Hint = resources.GetString("printPreviewBarCheckItem15.Hint");
            this.printPreviewBarCheckItem15.Id = 46;
            this.printPreviewBarCheckItem15.Name = "printPreviewBarCheckItem15";
            // 
            // printControl1
            // 
            this.printControl1.AccessibleDescription = resources.GetString("printControl1.AccessibleDescription");
            this.printControl1.AccessibleName = resources.GetString("printControl1.AccessibleName");
            this.printControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("printControl1.Anchor")));
            this.printControl1.AutoScroll = ((bool)(resources.GetObject("printControl1.AutoScroll")));
            this.printControl1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("printControl1.AutoScrollMargin")));
            this.printControl1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("printControl1.AutoScrollMinSize")));
            this.printControl1.BackColor = ((System.Drawing.Color)(resources.GetObject("printControl1.BackColor")));
            this.printControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("printControl1.BackgroundImage")));
            this.printControl1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("printControl1.Dock")));
            this.printControl1.Enabled = ((bool)(resources.GetObject("printControl1.Enabled")));
            this.printControl1.Font = ((System.Drawing.Font)(resources.GetObject("printControl1.Font")));
            this.printControl1.ForeColor = ((System.Drawing.Color)(resources.GetObject("printControl1.ForeColor")));
            this.printControl1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("printControl1.ImeMode")));
            this.printControl1.IsMetric = ((bool)(resources.GetObject("printControl1.IsMetric")));
            this.printControl1.Location = ((System.Drawing.Point)(resources.GetObject("printControl1.Location")));
            this.printControl1.Name = "printControl1";
            this.printControl1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("printControl1.RightToLeft")));
            this.printControl1.Size = ((System.Drawing.Size)(resources.GetObject("printControl1.Size")));
            this.printControl1.TabIndex = ((int)(resources.GetObject("printControl1.TabIndex")));
            this.printControl1.TooltipBackColor = ((System.Drawing.Color)(resources.GetObject("printControl1.TooltipBackColor")));
            this.printControl1.TooltipFont = ((System.Drawing.Font)(resources.GetObject("printControl1.TooltipFont")));
            this.printControl1.TooltipForeColor = ((System.Drawing.Color)(resources.GetObject("printControl1.TooltipForeColor")));
            this.printControl1.Visible = ((bool)(resources.GetObject("printControl1.Visible")));
            // 
            // UserControl1
            // 
            this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
            this.AccessibleName = resources.GetString("$this.AccessibleName");
            this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
            this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
            this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.printControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
            this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
            this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
            this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
            this.Name = "UserControl1";
            this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
            this.Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
            ((System.ComponentModel.ISupportInitialize)(this.printBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printPreviewRepositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiplePagesControlContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPopupControlContainer1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion
	}
}
