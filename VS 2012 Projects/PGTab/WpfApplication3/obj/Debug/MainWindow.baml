   M S B A M L   `   `   `  ����J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication3WpfApplication3  5   	        WpfApplication3.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   Fdxt<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5   	   Hdxdst<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5   	   )localclr-namespace:WpfApplication3  5   	     � Title$  
MainWindow��5
   	   $	��426��6   $��921.8��6)    � 	Resources 5       �� 
TargetType   NewButtonStyle �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property	 P� Value
 �� 
TargetName�� 5   
   %�  &	        �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      �� $ borderNewPG��6%   $��24��6:   $��24��6E   $��1q�6Q   ._�5   "   �� 5       5      P� 5   "    �@J�IsMouseOver	 .  . �5   &   �� $
 borderNewPG��6-    � ��
 ���� 6\   5   #   P� 5   "    �@J�IsMouseOver	 . . �5   &   �� $
 borderNewPG��6-    � �� �	#FFC2E0FF6\   �� 5   &   $
 borderNewPG��6-    � �� �	#FF3399FF6]   5   #   P� 5   "    � ��	 . . �5   &   �� $
 borderNewPG��6-    � �� �	#FF9DCAF76\   �� 5    &   $
 borderNewPG��6-    � �� �	#FF3383D36]   5!   #   5#      5%      �� 5&       � ��$ 12,0,6,1q�6+   5'      5+      .��5-      �  � RowDefinitions 5.   
   �� 5/      $
��auto �6   �� 50      $��* �6   .+�52   
   � $��0��6   $��30��6   $��0,12,0,0q�6(   $	��Top=�6:   ���	#FF7EA3DA � ColumnDefinitions 53      �� 54      $
��auto �6#   �� 55      $��* �6#   �� 56      $
��auto �6#   .+�58      �� -   5         ��Name$
 conn��58      $
��Conn��6#   $��0��62   $��Bottom=�6B   #��[  6]   59      )   #WpfApplication3.DXSessionTabControl  5:      -   5          Name$	 tab��5:   (   $��1��65   $��Bottom=�6E   $��0q�6`   $
��Left=�6�   ��6l   �� *
MySource+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�&   DevExpress.Xpf.Core.DXTabControl   View 5E      .  (DevExpress.Xpf.Core.TabControlScrollView  5F      ,  &DevExpress.Xpf.Core.TabControlViewBase   RemoveTabItemsOnHiding .     AllowHideTabItems . 6M   5H      � 5I      $��2��6    5J      �� 5K      $
��auto �6'   �� 5L      $	��100 �6'   .+�5N      �� $��
Database: ��6   $��0��6.   $��Bottom=�6>   $��0,0,0,3q�6Y   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5O      $��1��6#   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ Seven 63   $��Bottom=�6U   %  DevExpress.Xpf.Editors.BaseEdit   
ShowBorder . 
�������
�������6�   5P      5R      � 5T   
   $��1��6   ���	#FFD0DFF2.+�5U      �� -   5        $ border1��5U      
���   �$��1q�6:   $
��Left=�6N   $��47��6i   $��191,172,0,0q�6u   $	��Top=�6�   $	��121��6�   ._�5V      F� 
���  ��$��3��6$   ���	#FF005EA7��5W      B� 5X      .��5Y      E� -   5        
figure�� E� IsClosed .   E� 
StartPoint$	 1,0&�5Y   J   ��5[   &   ��  �� Point$ 1, 16.1&�62   �� 5\   &    �� Point1$ 1, 20.7&�64    �� Point2$ 2.3, 23&�6E    �� Point3$ 6.9, 23&�6V   �� 5]   &   $ 20, 23&�62   �� 5^   &   $ 24.6, 23&�64   $ 29.2, 0&�6F   $ 33.8, 0&�6W   5`      5a       � LayoutTransform 5c      �� 5d       �� ScaleY$ -1Q�6)   5f      5g      �� 5h      -   5        $��Button��5h      $
��Left=�6&   $��572,198,0,0q�6A   $	��Top=�6V   $��75��6n   6y   5j      5k      5l      