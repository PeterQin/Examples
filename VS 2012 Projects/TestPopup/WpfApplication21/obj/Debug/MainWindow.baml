   M S B A M L   `   `   `  ����K  GWpfApplication21, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApplication21WpfApplication21  5   	   !    WpfApplication21.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   a ]DevExpress.Xpf.Grid.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v12.2.Core, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   ,localclr-namespace:WpfApplication21   5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   $  DevExpress.Xpf.Bars.BarManager     Items 5      '  !DevExpress.Xpf.Bars.BarButtonItem  5      -   5          Name$ item1��5   $   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ item 1 63   6D     5      -   5        $ item2��5   $   $ item 2 63   6D   ._�5      � .+�5      %  DevExpress.Xpf.Grid.GridControl  -   5        $
��grid��5   "   )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6.   �� *
MySource+ �� Mode$ OneWay=�   Columns 5      $  DevExpress.Xpf.Grid.GridColumn  5      -   5        $  DevExpress.Xpf.Grid.ColumnBase  Name$ colID��5   5      Header$ ID 6)   	   	FieldName$	 ID��6B   
   AllowSorting] YDevExpress.Data.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5	  /DevExpress.Utils.Design.DefaultBooleanConverter$

 True	 6Q      AllowGrouping$
 True	 6e      AllowBestFit$ False	 6z      AllowSearchPanel .  6�     5      -   5        $ colName��5   8   $
 Name 6*   $
	 Name��6G      View 5      #
  DevExpress.Xpf.Grid.TableView
  5      -   5         
 Name$
 view��5   (   &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     RowCellMenuCustomizations 5      $  DevExpress.Xpf.Bars.BarSubItem  5   "   -   5         �Name$ subItemSettings��5   1   $ Settings 6H   5   #   5      5&      5'      5(      5)      5*      