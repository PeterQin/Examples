   M S B A M L   `   `   `  ����J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication3WpfApplication3  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089a ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a/    )WpfApplication3.BoolToVisibilityConverter 
  conver  �� 
TargetType  AddSessionButtonStyle �� Property �� Value �� 
TargetType F�Name E� IsClosed E� 
StartPoint �� Point �� Point1	 �� Point2
 �� Point3 � LayoutTransform �� ScaleY �� Triggers P� Property P� Value �� 
TargetName&   DevExpress.Xpf.Core.DXTabControl?  9DevExpress.Xpf.Utils.Themes.DXTabControlThemeKeyExtension�  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.Utils.Themes.DXTabControlThemeKeys, DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   ResourceKey-  'System.Windows.Input.KeyboardNavigation   TabNavigation � RowDefinitions �Name   TabIndex   DirectionalNavigation K� ZIndex � ColumnDefinitions*  $DevExpress.Xpf.Core.ClippedContainer � UseLayoutRoundingG  ADevExpress.Xpf.Utils.Themes.DXTabControlInternalThemeKeyExtension�  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.Utils.Themes.DXTabControlInternalThemeKeys, DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   ResourceKey+  %DevExpress.Xpf.Core.TabPanelContainer  Name � 	Resources0	  *DevExpress.Xpf.Core.TabControlScrollButton 	 Name$
  DevExpress.Xpf.Core.HeaderMenu 
 Name,  &DevExpress.Xpf.Core.DXContentPresenter   ContentTemplate   Name!   SelectedItemContent"   Content"#   SelectedItemContentTemplate3  -DevExpress.Xpf.Core.TabControlFastRenderPanel$  Name  Key% �� 
TargetName& �� TargetProperty' g� Duration	( W� To) W� EasingFunction4  .System.Windows.Media.Animation.ExponentialEase7  1System.Windows.Media.Animation.EasingFunctionBase*   
EasingMode+   Exponent, �� CenterX- �� CenterY. �� Angle  TabControlDefaultStyle"  DevExpress.Xpf.Core.TabPanel�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      Fdxt<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5      Hdxdst<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5      'localclr-namespace:WpfApplication3  5      %�'  &	        &	      (  �    55      $ TopLayoutTemplate=�)7  (  �    5|      $ BottomLayoutTemplate=�)(  �    5�      $ LeftLayoutTemplate=�)(  �    5     $ RightLayoutTemplate=�)&	 X$       5      6&   �� 5	      "  ��6   .�5
   
   ��  � �� .  6&   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � $��0,3,0,0q�6   .+�5      F� $ PathAdd��6   ���	#FF3E73C5$��1��6C   ���	#FFA4BFE6��5      B� 5   "   .��5   &   E� 
figure�� .  $	 1,0&�6R   ��5   .   �� $ 1, 16.1&�6:   �� 5   .   $ 1, 20.7&�6<   $	 2.3, 23&�6M   $
 6.9, 23&�6^   �� 5   .   $ 20, 23&�6:   �� 5   .   $ 24.6, 23&�6<   $	 29.2, 0&�6N   $
 33.8, 0&�6_   5   '   5   #    5      �� 5   "   $ -1Q�61   5      �� 5       $��Center=�6+   $
��Left=�6F   $��9,0,0,0q�6a   5!       5"      P� 5#       �@J�IsMouseOver .  . �5$      �� $ PathAdd��65    � �� �	#FFA4BFE66J   �� 5%      $ PathAdd��67    � �� �	#FF3E73C56L   5&      P� 5'       �@J�IsMouseOver . . �5(      �� $ PathAdd��65    � �� �	#FFC4CBDC6J   �� 5)      $ PathAdd��67    � �� �	#FF3E73C56L   5*      P� 5+       � �� . . �5,      �� $ PathAdd��65    � �� �	#FFD0DFF26J   �� 5-      $ PathAdd��67    � �� �	#FFD0DFF26L   5.      50      52      53      �� 55      "  6W   .R�56   
   � $ Local=�58   W    5:      �� 5;      $
��Auto �6    �� 5<      $��0 �6    .+�5>      � $ tabHeadersPanel��61   $��0��6   $��0,2,0,0q�6    ���	#FF7EA3DA$ 1��5@   M   $ Cycle=�5A   k   $
 Once=�5B   Z   $ 1��5C   /    5F      �� 5G      $��* �6'   �� 5H      $
��Auto �6'   �� 5I      $
��Auto �6'   �� 5J      $
��Auto �6'   �� 5K      $
��Auto �6'   .+�5M        $��0��6&   # z 66   ��6n   C� *  $$ ClippedContainerTopLayoutStyle=�+.+�5N        $ panelContainer��6+   ��6C   C� *  $" PanelContainerTopLayoutStyle=�+ 5O      ��5W      .+�5X      �� z�5Y      T� 5Z   "   ItemsPanelTranslate��65   5\      5]      5^      	  5_      $ 
PrevButton��6,   $��1��6@   ��6P   C� *  $ PrevButtonStyle=�+��6�   C� *  $) #ComponentsSpaceForHorizontalLayouts=�+	  5`      $ 
NextButton��6,   $��2��6@   ��6P   C� *  $ NextButtonStyle=�+��6�   C� *  $) #ComponentsSpaceForHorizontalLayouts=�+
  5a      $ 
HeaderMenu��60   $��3��6    ��.  ��6V   C� *  $ HeaderMenuStyle=�+��6�   C� *  $) #ComponentsSpaceForHorizontalLayouts=�+�� 5b      $��4��6   $��+��6)   8��  65   5c      � 5d      $��PART_ContentHost��6    $��1��6   .+�5e        ��.   6(   C� *  $ TopBackgroundTemplate=�+5g      � 5h      #��z��6   .+�5i        $  contentPresenter��6,   # z 6F   #" z! 6~   # z# 6�   $ Local=�5k   c   $ 	Contained=�5l   w   $ 2��5m   U   5p        5q      $$ fastRenderPanel��63   # z 6L   $y�	Collapsed=�6�   $ Local=�5s   c   $ 	Contained=�5t   w   $ 2��5u   U   5w      5x      5y      5z      5{      �� 5|      "  6Z   .R�5}   
   � $ Local=�5   W    5�      �� 5�      $��* �6    �� 5�      $
��Auto �6    .+�5�      � $ tabHeadersPanel��61   $��1��6   $��0,0,0,2q�6    $ 1��5�   M   $ Cycle=�5�   k   $
 Once=�5�   Z   $ 1��5�   /    5�      �� 5�      $��* �6'   �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'   .+�5�        $��0��6&   # z 66   ��6n   C� *  $' !ClippedContainerBottomLayoutStyle=�+.+�5�        $ panelContainer��6+   ��6C   C� *  $% PanelContainerBottomLayoutStyle=�+ 5�      ���� 5�      ScrollStoryboard .��5�   "   W� $% ItemsPanelTranslate��62   $& X�6^   $' 0:0:0.4D�6|   $( 0X�6�   ) 5�   &     5�   *   $* EaseOut=�6:   $+ 0Q�6O   5�   #   5�      5�      .+�5�      �� z�5�      T� 5�   "   ItemsPanelTranslate��65   5�      5�      5�      	  5�      $ 
PrevButton��6,   $��1��6@   ��6P   C� *  $ PrevButtonStyle=�+��6�   C� *  $) #ComponentsSpaceForHorizontalLayouts=�+	  5�      $ 
NextButton��6,   $��2��6@   ��6P   C� *  $ NextButtonStyle=�+��6�   C� *  $) #ComponentsSpaceForHorizontalLayouts=�+
  5�      $ 
HeaderMenu��60   $��3��6    ��.  ��6V   C� *  $ HeaderMenuStyle=�+��6�   C� *  $) #ComponentsSpaceForHorizontalLayouts=�+5�      � 5�      $��PART_ContentHost��6    $��0��6   .+�5�        ��.   6(   C� *  $ BottomBackgroundTemplate=�+5�      � 5�      #��z��6   .+�5�        $  contentPresenter��6,   # z 6F   #" z! 6~   # z# 6�   $ Local=�5�   c   $ 	Contained=�5�   w   $ 2��5�   U   5�        5�      $$ fastRenderPanel��63   # z 6L   $y�	Collapsed=�6�   $ Local=�5�   c   $ 	Contained=�5�   w   $ 2��5�   U   5�      5�      5�      5�      5�      �� 5�      "  6X   .R�5�   
   � $ Local=�5�   W    5�      �� 5�      $
��Auto �6#   �� 5�      $��* �6#   .+�5�      � $ tabHeadersPanel��64   $��0��6   $��2,0,0,0q�6#   $ 1��5�   M   $ Cycle=�5�   k   $
 Once=�5�   Z   $ 1��5�   /    5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�        $��3��6&   # z 63   ��6k   C� *  $% ClippedContainerLeftLayoutStyle=�+.+�5�        $ panelContainer��6+   ��6C   C� *  $# PanelContainerLeftLayoutStyle=�+ 5�      ���� 5�      ScrollStoryboard .��5�   "   W� $% ItemsPanelTranslate��62   $& Y�6^   $' 0:0:0.4D�6|   $( 0X�6�   ) 5�   &     5�   *   $* EaseOut=�6:   $+ 0Q�6O   5�   #   5�      5�      .+�5�      �� z�5�      T� 5�   "   ItemsPanelTranslate��65   5�      5�      5�      	  5�      $ 
PrevButton��6,   $��1��6@   ��6M   C� *  $ PrevButtonStyle=�+��6�   C� *  $' !ComponentsSpaceForVerticalLayouts=�+z�5�      �� 5�      $, 8Q�6*   $- 8Q�66   $. 90Q�6B   5�      	  5�      $ 
NextButton��6,   $��2��6@   ��6M   C� *  $ NextButtonStyle=�+��6�   C� *  $' !ComponentsSpaceForVerticalLayouts=�+z�5�      �� 5�      $, 8Q�6*   $- 8Q�66   $. 90Q�6B   5�      
  5�      $ 
HeaderMenu��6-   $��0��6    ��.  ��6S   C� *  $ HeaderMenuStyle=�+��6�   C� *  $' !ComponentsSpaceForVerticalLayouts=�+z�5�      �� 5�      $, 8Q�6*   $- 8Q�66   $	. -90Q�6B   5�      5�      � 5�      $��PART_ContentHost��6#   $��1��6   .+�5�        ��.   6(   C� *  $ LeftBackgroundTemplate=�+5�      � 5�      #��z��6   .+�5�        $  contentPresenter��6,   # z 6F   #" z! 6~   # z# 6�   $ Local=�5  c   $ 	Contained=�5  w   $ 2��5  U   5       5     $$ fastRenderPanel��63   # z 6L   $y�	Collapsed=�6�   $ Local=�5	  c   $ 	Contained=�5
  w   $ 2��5  U   5     5     5     5     5     �� 5     "  6Y   .R�5  
   � $ Local=�5  W    5     �� 5     $��* �6#   �� 5     $
��Auto �6#   .+�5     � $ tabHeadersPanel��64   $��1��6   $��0,0,2,0q�6#   $ 1��5  M   $ Cycle=�5  k   $
 Once=�5  Z   $ 1��5   /    5#     �� 5$     $
��Auto �6$   �� 5%     $
��Auto �6$   �� 5&     $
��Auto �6$   �� 5'     $��* �6$   .+�5)       $��3��6&   # z 63   ��6k   C� *  $&  ClippedContainerRightLayoutStyle=�+.+�5*       $ panelContainer��6+   ��6C   C� *  $$ PanelContainerRightLayoutStyle=�+ 5+     ���� 5,     ScrollStoryboard .��5-  "   W� $% ItemsPanelTranslate��62   $& Y�6^   $' 0:0:0.4D�6|   $( 0X�6�   ) 5.  &     5/  *   $* EaseOut=�6:   $+ 0Q�6O   51  #   52     53     .+�54     �� z�55     T� 56  "   ItemsPanelTranslate��65   58     59     5:     	  5;     $ 
PrevButton��6,   $��1��6@   ��6M   C� *  $ PrevButtonStyle=�+��6�   C� *  $' !ComponentsSpaceForVerticalLayouts=�+z�5<     �� 5=     $, 8Q�6*   $- 8Q�66   $. 90Q�6B   5?     	  5@     $ 
NextButton��6,   $��2��6@   ��6M   C� *  $ NextButtonStyle=�+��6�   C� *  $' !ComponentsSpaceForVerticalLayouts=�+z�5A     �� 5B     $, 8Q�6*   $- 8Q�66   $. 90Q�6B   5D     
  5E     $ 
HeaderMenu��6-   $��0��6    ��.  ��6S   C� *  $ HeaderMenuStyle=�+��6�   C� *  $' !ComponentsSpaceForVerticalLayouts=�+z�5F     �� 5G     $, 8Q�6*   $- 8Q�66   $	. -90Q�6B   5I     5J     � 5K     $��PART_ContentHost��6#   $��0��6   .+�5L       ��.   6(   C� *  $ RightBackgroundTemplate=�+5N     � 5O     #��z��6   .+�5P       $  contentPresenter��6,   # z 6F   #" z! 6~   # z# 6�   $ Local=�5R  c   $ 	Contained=�5S  w   $ 2��5T  U   5W       5X     $$ fastRenderPanel��63   # z 6L   $y�	Collapsed=�6�   $ Local=�5Z  c   $ 	Contained=�5[  w   $ 2��5\  U   5^     5_     5`     5a     5b     �� 5c     "   6+   .�5d  
   ��  � �� 6'   C� *  $ ForegroundBrush=�+�� 5e  
    �@ LayoutTopTemplate 6.   C� *  $ TopLayoutTemplate=�+�� 5f  
    �@ LayoutBottomTemplate 61   C� *  $ BottomLayoutTemplate=�+�� 5g  
    �@ LayoutLeftTemplate 6/   C� *  $ LeftLayoutTemplate=�+�� 5h  
    �@ LayoutRightTemplate 60   C� *  $ RightLayoutTemplate=�+�� 5i  
    � �� 6%   C� *  $ TopLayoutTemplate=�+�� 5j  
    � �� 5k     �� 5l     .R�5m       5n     5p     �� 5q  
    � �� 6$   C� *  $ Padding=�+�� 5s  
    � �� .  6&   5t     5u     