   M S B A M L   `   `   `  ����  NavigationPanelSample#    NavigationPanelSample.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	     � Title$  Window1��5   	   $	��300��6   $	��300��6&    � 	Resources 5       	  arrow �� 
TargetType&   DevExpress.Xpf.Editors.CheckEdit �� Property �� Value �� 
TargetType �Name � Points J� RenderTransformOrigin	 �� Angle
 �� CenterY �� Triggers P� Property P� Value �� 
TargetName �� CenterX  ExpanderRightHeaderStyle �� Padding J� SnapsToDevicePixels � RowDefinitions � LayoutTransform A�Name F�Name  ExpanderUpHeaderStyle � ColumnDefinitions  ExpanderLeftHeaderStyle  ExpanderHeaderFocusVisual �� StrokeDashArray  ExpanderDownHeaderStyle  ExpanderStyle1 �� CornerRadius d�Name � FocusVisualStyle d� 	IsChecked �� Mode �� RelativeSource ��Name��%f  &	        &	 �    &	 �    &	 �    &	 �    &	     &	 �    7  7  7  7  7  �� 5   
   "  6   .�5	      ��  � �� 5
      �� 5      "  6&   .R�5      � .+�5      � $ triangle��6&    �   @@  	=  z 
���   �
���   �$ 0.5,0.5&�6l   z�5   "   V� 5   &   .~�5   *   �� 	transform��$	 0Q�6M   $
 0Q�6W   5   '   5      5       5      P� 5       �@ 	IsChecked$
 TrueY�6;   . �5   "   �� $ triangle��6D    � z� 5   &   V� 5   *   .~�5   .   �� $	 45Q�6>   $
 -2Q�6I   $ -2Q�6V   5   +   5   #   5      P� 5       �@J�IsMouseOver . . �5    "   �� $ triangle��69    � �� �	#FF82DFFB6O   �� 5!   "   $ triangle��6;    � �� �	#FF1CC4F76Q   5"      5$      5&      5'      �� 5*   
   " d�61   .�5+      ��  � �� 5,      �� 5-      " d�6&   .R�5.      �� # z��6!   ._�5/      � 
������  .   50   "   �� 51   &   $��19 �64   �� 52   &   $��* �64   .+�54   "   �  55   &   V� 56   *   ~�58   2   X� �� 59   6   $		 -90Q�6F   5:   3   5<   +   .+�5>   &   A� $ circle��6.   $��Center=�6>   $��19��6[   
�������$��Center=�6y   $��19��6�   F� 5?   &   $ arrow��6+   "����@B `� � �D @KL � z `� 	$��Center=�6Y    .  ���#666$��2��6�   $��Center=�6�   5@   #   �� 5A   "   $��Center=�63   $��0,4,0,0q�6P   $��1��6a   ��.  . $	��Top=�6�   5B      5C       5D      P� 5E       �@d�	IsChecked$
 trueY�6;   . �5F   "   �� $ arrow��69    � ��" ��@B  �D � �D @B � z  �D 	6L   5G      P� 5H       �@J�IsMouseOver . . �5I   "   �� $ circle��6;    � �� �	#FF3C7FB16O   �� 5J   "   $ arrow��6;    � �� �#2226N   5K      P� 5L       � �� . . �5M   "   �� $ circle��6;    � �� �	#FF526C7B6O   �� 5N   "   $ circle��6D    � ��$	 1.5��6X   �� 5O   "   $ arrow��6;    � �� �	#FF0033666N   5P      5R      5T      5U      �� 5V   
   " d�6.   .�5W      ��  � �� 5X      �� 5Y      " d�6&   .R�5Z      �� # z��6!   ._�5[      � 
������  .   5\   "   �� 5]   &   $��* �67   �� 5^   &   $��19 �67   .+�5`   "   �� $��0��63   $
��Left=�6C   $��4,0,0,0q�6^   ��.  . $��Center=�6�   � 5a   "   $��1��6'    5b   &   V� 5c   *   ~�5e   2   X� �� 5f   6   $		 180Q�6F   5g   3   5i   +   .+�5k   &   A� $ circle��6.   $��Center=�6>   $��19��6[   
�������$��Center=�6y   $��19��6�   F� 5l   &   $ arrow��6+   "����@B `� � �D @KL � z `� 	$��Center=�6Y    .  ���#666$��2��6�   $��Center=�6�   5m   #   5n      5o       5p      P� 5q       �@d�	IsChecked$
 trueY�6;   . �5r   "   �� $ arrow��69    � ��" ��@B  �D � �D @B � z  �D 	6L   5s      P� 5t       �@J�IsMouseOver . . �5u   "   �� $ circle��6;    � �� �	#FF3C7FB16O   �� 5v   "   $ arrow��6;    � �� �#2226N   5w      P� 5x       � �� . . �5y   "   �� $ circle��6;    � �� �	#FF526C7B6O   �� 5z   "   $ circle��6D    � ��$	 1.5��6X   �� 5{   "   $ arrow��6;    � �� �	#FF0033666N   5|      5~      5�      5�      �� 5�   
   " d�60   .�5�      ��  � �� 5�      �� 5�      " d�6&   .R�5�      �� # z��6!   ._�5�      � 
������  .   5�   "   �� 5�   &   $��19 �64   �� 5�   &   $��* �64   .+�5�   "   �  5�   &   V� 5�   *   ~�5�   2   X� �� 5�   6   $	 90Q�6F   5�   3   5�   +   .+�5�   &   A� $ circle��6.   $��Center=�6>   $��19��6[   
�������$��Center=�6y   $��19��6�   F� 5�   &   $ arrow��6+   "����@B `� � �D @KL � z `� 	$��Center=�6Y    .  ���#666$��2��6�   $��Center=�6�   5�   #   �� 5�   "   $��Center=�63   $��0,4,0,0q�6P   $��1��6a   ��.  . $	��Top=�6�   5�      5�       5�      P� 5�       �@d�	IsChecked$
 trueY�6;   . �5�   "   �� $ arrow��69    � ��" ��@B  �D � �D @B � z  �D 	6L   5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ circle��6;    � �� �	#FF3C7FB16O   �� 5�   "   $ arrow��6;    � �� �#2226N   5�      P� 5�       � �� . . �5�   "   �� $ circle��6;    � �� �	#FF526C7B6O   �� 5�   "   $ circle��6D    � ��$	 1.5��6X   �� 5�   "   $ arrow��6;    � �� �	#FF0033666N   5�      5�      5�      5�      �� 5�   
   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� ._�5�      �� $��0q�6(    . 
���   �$��1��6]   $	 1 2R�6q   5�      5�      5�      5�      �� 5�   
   " d�60   .�5�      ��  � �� 5�      �� 5�      " d�6&   .R�5�      �� # z��6!   ._�5�      � 
������  .   5�   "   �� 5�   &   $��19 �67   �� 5�   &   $��* �67   .+�5�   "   A� $ circle��6*   $��Center=�6:   $��19��6W   
�������$��Center=�6u   $��19��6�   F� 5�   "   $ arrow��6'   "����@B `� � �D @KL � z `� 	$��Center=�6U    .  ���#666$��2��6�   $��Center=�6�   �� 5�   "   $��1��63   $
��Left=�6C   $��4,0,0,0q�6^   ��.  . $��Center=�6�   5�      5�       5�      P� 5�       �@d�	IsChecked$
 trueY�6;   . �5�   "   �� $ arrow��69    � ��" ��@B  �D � �D @B � z  �D 	6L   5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ circle��6;    � �� �	#FF3C7FB16O   �� 5�   "   $ arrow��6;    � �� �#2226N   5�      P� 5�       � �� . . �5�   "   �� $ circle��6;    � �� �	#FF526C7B6O   �� 5�   "   $ circle��6D    � ��$	 1.5��6X   �� 5�   "   $ arrow��6;    � �� �	#FF0033666N   5�      5�      5�      5�      �� 5�   
   " 9�6'   .�5�      ��  � ��# � ��6+   �� 5�       � ��
 ���� 6+   �� 5�       � ��$ Stretch=�6;   �� 5�       � ��$ Stretch=�69   �� 5�       � ��
 ���� 6,   �� 5�       � ��$ 1q�60   �� 5�       � �� 5�      �� 5�      " 9�6&   .R�5�      �� #��z��6!   #��z��6M   #��z��6�   $ 3��6�    . ._�5�      ]� .+�5�   "   d� $ 
HeaderSite��6/   #��z��6C   #��z��6v   #��z��6�   $	��Top=�6�   #��z��6�   #��z��6  8   #��z��6�  #��z��6�  #��z��6�  #��z��6�  #��z��6'  $��1q�6�  $��0��6�  $��0��6�  #��z��6�  8�� #��z��6K   6q  �� *
IsExpanded+$ TwoWay=� �� *TemplatedParent+6K  �� 5�   "   $ 
ExpandSite��63   $��Bottom=�6G   |�.  #��z��6q   #��z��6�   $y�	Collapsed=�6�   #��z��6�   5�      5�       5�      P� 5�       �@9�
IsExpanded . . �5�   "   �� $ 
ExpandSite��6?    � y�$ Visible=�6W   5�      P� 5�       �@9�ExpandDirection$ Right=�6A   . �5�   "   �� $ 
ExpandSite��6C    � ��$ Right=�6[   �� 5�   "   $ 
HeaderSite��6C    � ��$
 Left=�6[   �� 5�   "   $ 
HeaderSite��6:   8   � ��6R   5�      P� 5�       �@9�ExpandDirection$ Up=�6A   . �5�   "   �� $ 
ExpandSite��6C    � ��$	 Top=�6[   �� 5�   "   $ 
HeaderSite��6C    � ��$ Bottom=�6[   �� 5�   "   $ 
HeaderSite��6:   8   � ��6R   5�      P� 5�       �@9�ExpandDirection$
 Left=�6A   . �5�   "   �� $ 
ExpandSite��6C    � ��$
 Left=�6[   �� 5�   "   $ 
HeaderSite��6C    � ��$ Right=�6[   �� 5�   "   $ 
HeaderSite��6:   8   � ��6R   5�      P� 5�       � {� .  . �5�   "   �� # � ��6?    � ��5      5     5     5     5     .��5     � .+�5
  
   9� $��Expander��6   #��[ 6%   .��5     � ���	#FFE5E5E5 5     �� 5     $
��147* �6'   �� 5     $
��143* �6'   5     5     5     5     