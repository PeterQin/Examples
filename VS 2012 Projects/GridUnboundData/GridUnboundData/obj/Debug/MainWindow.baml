   M S B A M L   `   `   `  ����J  FGridUnboundData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GridUnboundDataGridUnboundData  5   	        GridUnboundData.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Grid.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v12.2.Core, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   +localclr-namespace:GridUnboundData   5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5         ColumnStyle �� 
TargetType$  DevExpress.Xpf.Grid.GridColumn$  DevExpress.Xpf.Grid.ColumnBase �� Property �� Value,   &GridUnboundData.ColumnTemplateSelector  ColumnTemplateSelector  DefaultColumnTemplate   UnboundType] YDevExpress.Data.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a8  2DevExpress.Utils.Design.UnboundColumnTypeConverter   	FieldName   Header  ComboColumnTemplate   EditSettings:  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings8  2DevExpress.Xpf.Editors.Settings.ButtonEditSettings	   IsTextEditable<  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase
   ItemsSource��%  &	        &	 �     &	 �     &	 ?    �� 5	   
   "  6$   .�5
      ��  �@ FilterPopupMode$ CheckedList=�60   �� 5       �@ 	FieldName 6*   �� *	FieldName+5        5   
   6'   �� 5   
   .R�5      �� .��5        $ String 6\    6!   �� *	FieldName+ 6A   �� *	Caption+6\   5      5      �� 5   
   .R�5      �� .��5         6!   �� *	FieldName+ 5        5      	 .  
 63   �� *Source+6R   5      5      5      5      .��5      � .+�5!   
   %  DevExpress.Xpf.Grid.GridControl  -   5          Name$
 grid��5!      $��0,0,0,34q�5#   )   )	  #DevExpress.Xpf.Grid.DataControlBase 	  AutoPopulateColumns .   	  ItemsSource 5"      �� *Source+ 	  ColumnsSource 5#      �� *	Columns+& 	  ColumnGeneratorTemplateSelector 5$      �� 5%       �� ResourceKey$ ColumnTemplateSelector��6!      View 5'      #
  DevExpress.Xpf.Grid.TableView
  5(      -   5         
 Name$ 
tableView1��5(        
  	AutoWidth . &   DevExpress.Xpf.Grid.DataViewBase   NavigationStyle$
 Cell=�5*   	   5,      �� 5-   
   -   5        $��Button��5-      $
��Left=�6"   $��197,291,0,0q�6=   $	��Top=�6R   $��75��6j   6u   5/      50      