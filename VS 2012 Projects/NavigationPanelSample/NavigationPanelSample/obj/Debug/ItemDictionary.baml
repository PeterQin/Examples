   M S B A M L   `   `   `  ����a  ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ajKclr-namespace:DevExpress.Xpf.Core.Native;assembly=DevExpress.Xpf.Core.v12.2DevExpress.Xpf.Core.Native  5      P LNavigationPanelSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NavigationPanelSampleNavigationPanelSample 5	      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089c _DevExpress.Xpf.NavBar.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ac _DevExpress.Xpf.Charts.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a  �� MergedDictionaries �� Source8   2NavigationPanelSample.BooleanToVisibilityConverter   	bolConver �� 
TargetType-  'DevExpress.Xpf.NavBar.NavBarGroupHeaderB  <DevExpress.Xpf.NavBar.Themes.CommonElementsThemeKeyExtension�   �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.NavBar.Themes.CommonElementsThemeKeys, DevExpress.Xpf.NavBar.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   ResourceKey �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration	 �� 
TargetName
 �� TargetProperty,   &DevExpress.Xpf.Core.Native.ValueSetter   CornerRadius   	Thickness ��Name �� CornerRadius �� Padding � ColumnDefinitions8  2DevExpress.Xpf.NavBar.ImageAndTextContentPresenter  Name   ImageFallbackSizeF	  @DevExpress.Xpf.NavBar.Themes.NavBarGroupControlThemeKeyExtension�
   �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.NavBar.Themes.NavBarGroupControlThemeKeys, DevExpress.Xpf.NavBar.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]] 
  ResourceKey �� 	ConverterQ  KDevExpress.Xpf.NavBar.FrameworkElementInfoSLCompatibilityConverterExtension   ConvertToInfo-   'DevExpress.Xpf.Core.XPFContentPresenter   
Foreground �� RelativeSource3  -DevExpress.Xpf.NavBar.ExplorerBarExpandButton  Name&    DevExpress.Xpf.Core.ThemeManager   	ThemeName0   *DevExpress.Xpf.Core.ThemeNameTypeConverter4   .DevExpress.Xpf.Core.Native.RoutedCommandHelper   CommandParameter/  )DevExpress.Xpf.NavBar.NavPaneExpandButton  Name  ChartItemTemplate � Cursor6  0NavigationPanelSample.MouseOverCapturedExtansion   IsMouseOverCapture   IsMouseOver �� Mode  �� UpdateSourceTrigger! �� 
TargetType" �� Triggers# P� Property$ P� Value% �� Property& �� Value' � RowDefinitions(  "DevExpress.Xpf.Charts.ChartControl(  Name) �� ElementName*   Diagram+  %DevExpress.Xpf.Charts.SimpleDiagram2D#  DevExpress.Xpf.Charts.Diagram+   Series'  !DevExpress.Xpf.Charts.PieSeries2D%  DevExpress.Xpf.Charts.PieSeries,   HoleRadiusPercent"  DevExpress.Xpf.Charts.Series-   ArgumentDataMember.   ValueDataMember/   Rotation0   
DataSource1   Label'  !DevExpress.Xpf.Charts.SeriesLabel2   Visible3   LabelPosition4   Model4  .DevExpress.Xpf.Charts.BorderlessFlatPie2DModel5 �� StringFormat  TextItemTemplate  MyFocusVisual6 �� StrokeDashArray7 J� SnapsToDevicePixels  ChartItemDataTemplate8 ��Name9 �� Triggers: �� Value; �� Binding< �� 
TargetName  NoDataAvailableTemplate  
stackPanel= A� Rows  CellItemsControlStyle  SQLTypeDataTemplate> 9�Name? 9� 
IsExpanded@ 9� ExpandDirection 	 ExpanderStyleA ��Name�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core   5      >dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors   5      Idxnt>http://schemas.devexpress.com/winfx/2008/xaml/navbar/themekeys  5      TdxcnKclr-namespace:DevExpress.Xpf.Core.Native;assembly=DevExpress.Xpf.Core.v12.2  5      >dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5      -local#clr-namespace:NavigationPanelSample  5	        5
      �� 5   
   $ DictionaryExpander.xaml?�6   %�"  &	        (       5      $ GroupHeaderTemplate=�)&	 �    &	 P    &	     &	 �    7  7  &	 �    &	     &	 ;    7  7  7  7  &	 �    7 	 7     5      6)   �� 5      "  6\   .R�5   
   � $
 grid��6   $
��Auto��6   $
��Auto��6*    5        5      ,(ViewAnimationProgressGroupPositionStates��. 5        ExplorerBarFirst��6"     5      ExplorerBarFirst0��. 5      �� .��5      T� $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 3��6�   T� 5      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 2��6�   T� 5      $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 2��6�   5      5        5      ExplorerBarMiddle��6"     5      ExplorerBarMiddle0��. 5      �� .��5      T� $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 3��6�   T� 5      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 2��6�   T� 5       $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 2��6�   5!      5"        5#      ExplorerBarLast��6"     5$      ExplorerBarLast0��. 5%      �� .��5&      T� $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 3��6�   T� 5'      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 2��6�   T� 5(      $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 2��6�   5)      5*        5+      ExplorerBarSingle��6"     5,      ExplorerBarSingle0��. 5-      �� .��5.      T� $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 3��6�   T� 5/      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 2��6�   T� 50      $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 2��6�   51      52        54      SideBarFirst��. 55      �� .��56      T� $ 0D�6<   $	 border1��6I   $
 Padding�6i   $ 1,0,1,1q�6�   57      58        59      SideBarFirst0��. 5:      �� .��5;      T� $ 0D�6<   $	 border1��6I   $
 Padding�6i   $ 1,0,1,0q�6�   T� 5<      $ 0D�6<   $	 grid1��6I   $
 Margin�6g   $ 0,0,0,-1q�6�   5=      5>        5?      SideBarMiddle��. 5@      �� .��5A      T� $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 0��6�   T� 5B      $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 0��6�   T� 5C      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 0��6�   5D      5E        5F      SideBarMiddle0��. 5G      �� .��5H      T� $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 0��6�   T� 5I      $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 0��6�   T� 5J      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 0��6�   T� 5K      $ 0D�6<   $	 border1��6I   $
 Padding�6i   $ 1,1,1,0q�6�   T� 5L      $ 0D�6<   $	 grid1��6I   $
 Margin�6g   $ 0,0,0,-1q�6�   5M      5N        5O      SideBarLast��. 5P      �� .��5Q      T� $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 0��6�   T� 5R      $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 0��6�   T� 5S      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 0��6�   5T      5U        5V      SideBarLast0��. 5W      �� .��5X      T� $ 0D�6<   $	 border1��6I   $
 Padding�6i   $ 1,1,1,0q�6�   T� 5Y      $ 0D�6<   $	 border1��6I   $
 CornerRadius�6i   $ 0,0,3,3��6�   T� 5Z      $ 0D�6<   $	 border3��6I   $
 CornerRadius�6i   $ 0,0,2,2��6�   T� 5[      $ 0D�6<   $	 border2��6I   $
 CornerRadius�6i   $ 0,0,2,2��6�   5\      5]        5^      SideBarSingle��6"   5_      .+�5b      �� $ border1��6   $ 3,3,0,0��6&   $ 1,1,1,1q�6=   ���	#FFC4E7FF._�5c      �� $ border2��6   $
��Auto��6*   
������ $
��Auto��6Q   $ 2,2,0,0��6_   $ 0,1,0,0q�6v   ._�5d      �� $ border3��6   $
��Auto��6.   $
��Auto��6;   $ 2,2,0,0��6I   
������ 6`   5e      5f      � 5g      $ grid1��6$   $��0,0,0,0q�6    5h      �� 5i      �� 5j      $
��Auto �6'   .+�5l        $ groupHeaderLabel��6J   $ 24Q�63   $��0��6�   ��6d   C� *	  $ HeaderStyle=�+��6�   ��     .  6,  �� *
Foreground+ �� *TemplatedParent+  5m      $ explorerBarExpandButton��6f   $��0,0,0,0q�6.   $ 
Office2013 6?   $��Stretch=�6�   $��1��6�    6�   ��   5n      $ navPaneExpandButton��6c   $��0,0,0,0q�6*   $ 
Office2013 6<   $��Stretch=�6�   $��1��6�   $y�	Collapsed=�6�    6�   �� 5o      5p      5q      �� 5s      " ��60   .R�5t   
   �� $��3q�6   $
 Hand��6    .  6e   �� *IsMouseOver+$ OneWayToSource=�$  PropertyChanged=���5u      �� 5v      "! ��6   " 5w      P� 5x      # �@J�IsMouseOver$ .  �5y      �� 5z   "   % � ��& �	#FFB3E1EC6?   5|      5~      ._�5�      � $
 grid��6   ' 5�      �� 5�      $��* �6$   �� 5�      $
��auto �6$   .+�5�        $( chart��6B   ��.  $��0��65   $��0q�6Q   $��0q�6�   $	��100��6�   $	��100��6�   ��6e   �� *
Background+$
) grid��$ OneWay=�.* 5�        .+ 5�        $, 0Q�6*   $- Argument��5�   *   $. 
Percentage��6H   $/ 90Q�6f   0 5�   @   �� *PercentDisplay+1 5�        5�   "   2 .  $3 Inside=�6B   4 5�        5�   "   5�      5�      5�      �� 5�      $��1��6   $��Center=�6)   $��WrapWithOverflow=�6F   �� 5�      �6   �� *	Percent+$5 {0:P0}�� �� 5�      �6   �� *Name+ �� 5�      $� (��6    �� 5�      �6   �� *
NumOfSQL+ �� 5�      $� SQL)��6   5�      5�      5�      5�      �� 5�      " ��6/   .R�5�   
   �� $��3q�6   $
 Hand��6   ��5�      �� 5�      "! ��6   " 5�      P� 5�      # �@J�IsMouseOver$ .  �5�      �� 5�   "   % � ��& �	#FFB3E1EC6?   5�      5�      ._�5�      � $
 grid��6   ' 5�      �� 5�      $��* �6$   �� 5�      $
��auto �6$   .+�5�      �� $��1��6   $��Center=�6)   $	��200��6F   $��65��6R   $��WrapWithOverflow=�6^   $
��Bold"�6~   �� 5�      �6   �� *	Percent+$5 {0:P0}�� �� 5�      �6   �� *Name+ �� 5�      $� (��6    �� 5�      �6   �� *
NumOfSQL+ �� 5�      $� SQL)��6   5�      5�      5�      5�      �� 5�      .�5�   
   �� % � ��& 5�      �� 5�      .R�5�      �� $��1��6    $��2q�64   
���   �$	6 1 2R�5�      7 . 5�      5�      5�      5�      �� 5�      .R�5�   
   � .+�5�      �� $8 CellItem��67   |�. ��. ��6I   �� *ViewChartDetailCommand+$ OneWay=���6�   �� *DataContext+ �� *Self+5�      5�      9 5�   
   �� 5�      $: Chart��6:   ; 6   �� *DisplayType+a�5�      �� 5�      $< CellItem��6   8&   % � ��6G   5�      �� 5�      $
: Text��6:   ; 6   �� *DisplayType+a�5�      �� 5�      $< CellItem��6   8&  % � ��6G   5�      5�      �� 5�      .R�5�   
   �� $��No data available��6   
�������6-   5�      �� 5�      .R�5�   
   A� $= 1��6   5�      �� 5�      "! ��6*   .�5�   
   �� % � ��8&   6'   �� 5�   
   % � ��8&  6)   " 5�   
   �� 5�      ; 6   �� *
GoalList+: 67   Z� a�5�      �� 5�      % � ��8&  61   5�      �� 5�      ; 6   �� *GoalList.Count+: 06=   a�5�      �� 5�      % � ��8&  61   5�      5�      �� 5�      .R�5�   
   �� ��5�      �� 5�      "! ��6   .�5�      �� % � ��$& 1q�68   �� 5�      % � ��
& �����64   �� 5�      % � ��
& �����63   " 5�      P� 5�      # �@J�IsMouseOver$ . . �5      �� % � ��& �	#FFD8F5FC6;   �� 5     % � ��
& �����6<   5     5     ._�5     � .+�5     9� $> expander��6   $��0��6-   ? . $
@ Down=�6L   8��  $��3q�6�   $��0q�6�   ���	#FFC4E7FF��5     �� 5	     
���   �$
��Bold"�6N   $��Center=�6`   $��WrapWithOverflow=�6{   ��6$   �� *Title+6{   .��5     �  5     �� 5     $��* �6/   �� 5     $
��auto �6/   .+�5     � $��0��6   ' 5     �� 5  "   $
��auto �60   �� 5  "   $��* �60   .+�5     �� $��0��6(   
���   �$
��Wrap=�6b   $	��Top=�6v   ��6H   �� *
Descript+6v   �� 5     $A 	txtDetail��6(   5     �� 5     ��. $��1��68   $��2��6H   
�������
������ $��0q�6�   8�� ��5     �� *
GoalList+6)   5     5     52     53     54     55     