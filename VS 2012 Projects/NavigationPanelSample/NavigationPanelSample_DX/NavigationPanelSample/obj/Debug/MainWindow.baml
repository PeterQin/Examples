   M S B A M L   `   `   `  ����a  ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ajKclr-namespace:DevExpress.Xpf.Core.Native;assembly=DevExpress.Xpf.Core.v12.2DevExpress.Xpf.Core.Native  5   	   P LNavigationPanelSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NavigationPanelSampleNavigationPanelSample 5
   	   &    NavigationPanelSample.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core   5   	   c _DevExpress.Xpf.NavBar.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5   	   Idxnt>http://schemas.devexpress.com/winfx/2008/xaml/navbar/themekeys  5   	   VdxcnKclr-namespace:DevExpress.Xpf.Core.Native;assembly=DevExpress.Xpf.Core.v12.2  5   	   c _DevExpress.Xpf.Charts.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5	   	   /local#clr-namespace:NavigationPanelSample  5
   	     � Title$  
MainWindow��5   	   $	��500��6   $	��700��6)   $��Tahoma)�65    � WindowStartupLocation$ CenterScreen=�6I   ���	#FFD0E0F8&    DevExpress.Xpf.Core.ThemeManager   	ThemeName0   *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 None 6�    � 	Resources 5      8  2NavigationPanelSample.BooleanToVisibilityConverter   	bolConver �� 
TargetType-  'DevExpress.Xpf.NavBar.NavBarGroupHeaderB  <DevExpress.Xpf.NavBar.Themes.CommonElementsThemeKeyExtension�   �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.NavBar.Themes.CommonElementsThemeKeys, DevExpress.Xpf.NavBar.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   ResourceKey �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States 	  System.Windows.VisualState	 	  
Storyboard
 g� Duration �� 
TargetName �� TargetProperty,
   &DevExpress.Xpf.Core.Native.ValueSetter 
  CornerRadius 
  	Thickness ��Name �� CornerRadius �� Padding � ColumnDefinitions8  2DevExpress.Xpf.NavBar.ImageAndTextContentPresenter  Name   ImageFallbackSizeF  @DevExpress.Xpf.NavBar.Themes.NavBarGroupControlThemeKeyExtension�   �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.NavBar.Themes.NavBarGroupControlThemeKeys, DevExpress.Xpf.NavBar.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   ResourceKey �� 	ConverterQ  KDevExpress.Xpf.NavBar.FrameworkElementInfoSLCompatibilityConverterExtension   ConvertToInfo-   'DevExpress.Xpf.Core.XPFContentPresenter   
Foreground �� RelativeSource3  -DevExpress.Xpf.NavBar.ExplorerBarExpandButton  Name4   .DevExpress.Xpf.Core.Native.RoutedCommandHelper   CommandParameter/  )DevExpress.Xpf.NavBar.NavPaneExpandButton  Name  ChartItemDataTemplate �� Mode � Cursor �� 
TargetType  �� Triggers! P� Property" P� Value# �� Property$ �� Value% � RowDefinitions(  "DevExpress.Xpf.Charts.ChartControl&  Name' �� ElementName(   Diagram+  %DevExpress.Xpf.Charts.SimpleDiagram2D#  DevExpress.Xpf.Charts.Diagram)   Series'  !DevExpress.Xpf.Charts.PieSeries2D%  DevExpress.Xpf.Charts.PieSeries*   HoleRadiusPercent"  DevExpress.Xpf.Charts.Series+   ArgumentDataMember,   ValueDataMember-   Rotation.   
DataSource/   Label'  !DevExpress.Xpf.Charts.SeriesLabel0   Visible1   LabelPosition2   Model4  .DevExpress.Xpf.Charts.BorderlessFlatPie2DModel3 �� StringFormat  
stackPanel4 �� Orientation  CheckEditArrowStyle&    DevExpress.Xpf.Editors.CheckEdit5 �Name6 � Points7 J� RenderTransformOrigin8 �� Angle9 �� CenterY: �� Triggers; �� 
TargetName< �� CenterX  SQLTypeDataTemplate=  Name>   	IsChecked��%   &	        (       5      $ GroupHeaderTemplate=�)&	 �    &	 �    &	     &	 �    7  7   7  7  7     5   
   6-   �� 5   
   "  6`   .R�5      � $
 grid��6   $
��Auto��6!   $
��Auto��6.    5        5      ,(ViewAnimationProgressGroupPositionStates��. 5      	  ExplorerBarFirst��6&   	  5      ExplorerBarFirst0��.	 5      �� .��5   "   T� $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 3��6�   T� 5   "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 2��6�   T� 5   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 2��6�   5      5      	  5      ExplorerBarMiddle��6&   	  5      ExplorerBarMiddle0��.	 5      �� .��5   "   T� $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 3��6�   T� 5    "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 2��6�   T� 5!   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 2��6�   5"      5#      	  5$      ExplorerBarLast��6&   	  5%      ExplorerBarLast0��.	 5&      �� .��5'   "   T� $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 3��6�   T� 5(   "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 2��6�   T� 5)   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 2��6�   5*      5+      	  5,      ExplorerBarSingle��6&   	  5-      ExplorerBarSingle0��.	 5.      �� .��5/   "   T� $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 3��6�   T� 50   "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 2��6�   T� 51   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 2��6�   52      53      	  55      SideBarFirst��.	 56      �� .��57   "   T� $
 0D�6@   $ border1��6M   $ Padding�6m   $ 1,0,1,1q�6�   58      59      	  5:      SideBarFirst0��.	 5;      �� .��5<   "   T� $
 0D�6@   $ border1��6M   $ Padding�6m   $ 1,0,1,0q�6�   T� 5=   "   $
 0D�6@   $ grid1��6M   $ Margin�6k   $ 0,0,0,-1q�6�   5>      5?      	  5@      SideBarMiddle��.	 5A      �� .��5B   "   T� $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 0��6�   T� 5C   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 0��6�   T� 5D   "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 0��6�   5E      5F      	  5G      SideBarMiddle0��.	 5H      �� .��5I   "   T� $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 0��6�   T� 5J   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 0��6�   T� 5K   "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 0��6�   T� 5L   "   $
 0D�6@   $ border1��6M   $ Padding�6m   $ 1,1,1,0q�6�   T� 5M   "   $
 0D�6@   $ grid1��6M   $ Margin�6k   $ 0,0,0,-1q�6�   5N      5O      	  5P      SideBarLast��.	 5Q      �� .��5R   "   T� $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 0��6�   T� 5S   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 0��6�   T� 5T   "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 0��6�   5U      5V      	  5W      SideBarLast0��.	 5X      �� .��5Y   "   T� $
 0D�6@   $ border1��6M   $ Padding�6m   $ 1,1,1,0q�6�   T� 5Z   "   $
 0D�6@   $ border1��6M   $ CornerRadius�6m   $ 0,0,3,3��6�   T� 5[   "   $
 0D�6@   $ border3��6M   $ CornerRadius�6m   $ 0,0,2,2��6�   T� 5\   "   $
 0D�6@   $ border2��6M   $ CornerRadius�6m   $ 0,0,2,2��6�   5]      5^      	  5_      SideBarSingle��6&   5`      .+�5c      �� $ border1��6   $ 3,3,0,0��6*   $ 1,1,1,1q�6A   ���	#FFC4E7FF._�5d      �� $ border2��6   $
��Auto��6.   
������ $
��Auto��6U   $ 2,2,0,0��6c   $ 0,1,0,0q�6z   ._�5e      �� $ border3��6!   $
��Auto��62   $
��Auto��6?   $ 2,2,0,0��6M   
������ 6d   5f      5g      � 5h      $ grid1��6(   $��0,0,0,0q�6    5i      �� 5j      �� 5k      $
��Auto �6+   .+�5m        $ groupHeaderLabel��6N   $ 24Q�67   $��0��6�   ��6h   C� *  $ HeaderStyle=�+��6�   ��     .  60  �� *
Foreground+ �� *TemplatedParent+  5n      $ explorerBarExpandButton��6j   $��0,0,0,0q�62   $ 
Office2013 6C   $��Stretch=�6�   $��1��6�    6�   ��   5o      $ navPaneExpandButton��6g   $��0,0,0,0q�6.   $ 
Office2013 6@   $��Stretch=�6�   $��1��6�   $y�	Collapsed=�6�    6�   �� 5p      5q      5r      �� 5t   
   .R�5u      � .+�5v      �� ��6   �� *ViewChartDetailCommand+$ OneWay=���6Q   �� *DataContext+ �� *Self+��5w      �� 5x      .R�5y      �� $��3q�6%   $
 Hand��60   ��5z   "   �� 5{   &   " ��6,     5|   *   P� 5}   .   ! �@J�IsMouseOver" .  �5~   2   �� 5   6   # � ��$ �	#FFB3E1EC6S   5�   /   5�   '   ._�5�   "   � $
 grid��6'   % 5�   &   �� 5�   *   $��* �68   �� 5�   *   $
��auto �68   .+�5�   &     $& chart��6D   -   5        $��0��5�   7   $��0q�6S   $��0q�6�   $��65��6�   $��65��6�   ��6g   �� *
Background+$
' grid��$ OneWay=�.( 5�   *     .) 5�   .     $* 0Q�6>   $+ Argument��5�   *   $, 
Percentage��6H   $- 90Q�6f   . 5�   T   �� *PercentDisplay+/ 5�   2     5�   6   0 .  $1 Inside=�6V   2 5�   2     5�   6   5�   /   5�   +   5�   '   �� 5�   &   $��1��60   $��Center=�6=   $	��100��6Z   $��65��6f   $��WrapWithOverflow=�6r   �� 5�      �6   �� *	Percent+$3 {0:P0}�� �� 5�      �6   �� *Name+ �� 5�      $� (��6    �� 5�      �6   �� *
NumOfSQL+ �� 5�      $� SQL)��6   5�   '   5�   #   5�      5�      5�      5�      5�      �� 5�   
   .R�5�      �� $4 
Horizontal=�6   5�      �� 5�   
   "  6,   .�5�      �� # � ��$ 5�      �� 5�      "  6&   .R�5�      � .+�5�      � $5 triangle��6&   6 �   @@  	=  z 
�������$��1��6^   
�������$7 0.5,0.5&�6   z�5�   "   V� 5�   &   .~�5�   *   �� 	transform��$8 0Q�6M   $9 0Q�6W   5�   '   5�      5�      : 5�      P� 5�      ! �@ 	IsChecked$
" TrueY�6;   . �5�   "   �� $; triangle��6D   # � z�$ 5�   &   V� 5�   *   .~�5�   .   �� $8 45Q�6>   $9 -2Q�6I   $< -2Q�6V   5�   +   5�   #   �� 5�   "   $; triangle��6;   # � ��$ �	#FF4645456Q   �� 5�   "   $; triangle��6D   # � ��$	$ 0.8��6Z   �� 5�   "   $; triangle��69   # � ��$ �	#FF4645456O   5�      P� 5�      ! �@J�IsMouseOver" . . �5�   "   �� $; triangle��69   # � ��$ �	#FF82DFFB6O   �� 5�   "   $; triangle��6;   # � ��$ �	#FF1CC4F76Q   5�      5�      5�      5�      �� 5�   
   .R�5�      �� ��5�      �� 5�      " ��6   .�5�      �� # � ��$$ 1q�6<   �� 5�      # � ��
$ �����68   �� 5�      # � ��
$ �����67     5�      P� 5�      ! �@J�IsMouseOver" . . �5�   "   �� # � ��$ �	#FFD8F5FC6?   �� 5�   "   # � ��
$ �����6@   5�      5�      ._�5�      �  5�      �� 5�      $
��auto �6+   �� 5�      $��* �6+   �� 5�      $
��auto �6+   % 5�      �� 5�      $
��auto �6(   �� 5�      $��* �6(   .+�5�        $= checkEditExtand��6$   $��0��6=   $��0��6M   $
> TrueY�6Z   8��  $	��Top=�6�   $��6q�6�   �� 5�      $��1��6    $��0��60   
���   �$
��Bold"�6P   $��Center=�6�   $��WrapWithOverflow=�6�   ��6b   �� *DataContext.Title+6�   �� 5�      $��1��6    $��1��60   
���   �$��WrapWithOverflow=�6�   $	��Top=�6  y�6=   �� *	IsChecked+$' checkEditExtand��$ OneWay=�8  ��6�   �� *DataContext.Descript+6  �� 5�      $��2��6#   $��0��63   $��2��6@   
�������
������ $��0q�6�   8�� 8�� y�6Q   �� *	IsChecked+$' checkEditExtand��$ OneWay=�8  ��5�   >   �� *DataContext.GoalList+5�      5�      5�      5�      .��5�      � $��12q�6   
�������.+�5�   
   � $��12q�6   % 5�      �� 5�      $
��auto �6    �� 5�      $��* �6    .+�5�      � $��0��6   .+�5�      �� $��Search Result��6   ���	#FF005EB2$��21(�6H   $��0,0,0,12q�6V   $
��Bold"�6h   5�      )  #DevExpress.Xpf.NavBar.NavBarControl  5�      $��1��6    ?   View? 5�      +  %DevExpress.Xpf.NavBar.ExplorerBarView  5�      -  'DevExpress.Xpf.NavBar.ScrollingSettings@   
ScrollMode$@ 	ScrollBar=�6*   A   GroupsA 5�      '  !DevExpress.Xpf.NavBar.NavBarGroup  5�      B   DisplaySource$B Items=�6&   C   
IsExpandedC . D   ItemTemplate#D [ 6r   E   ItemsSourceE 6N   �� *SQLTypeList+F   HeaderF 5      �� 5     $��Resources Consumption��6(   $
��Bold"�6E   ���	#FF005EB26W   5     5     5     5     5	     