   M S B A M L   `   `   `  ����  WpfApplication4     WpfApplication4.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5         btnTemplate �� 
TargetType ��Name � Cursor%  DevExpress.Xpf.Editors.SpinEdit  Name)  #DevExpress.Xpf.Editors.TextEditBase   Text �� Triggers �� Value	 �� Binding
 �� RelativeSource �� 
TargetName �� Property �� Value P� Property P� Value��%|  &	        �� 5   
   " d�6.   .R�5	      � .+�5
      �� $
 link��6   $
��link��6*   $y�Visible=�66   
����  �$��	Underline{�6]   $
 Hand��6y     5      $
 edit��6+   $
 edit��6   $y�	Collapsed=�69   5       5      �� 5      $
 True��6b   	 6   �� *	IsChecked+
 �� *Self+.a�5      �� $
 link��6    � y�$ 	Collapsed=�6E   �� 5      $
 edit��6    � y�$ Visible=�6E   5      �� 5      $ False��6b   	 6   �� *	IsChecked+
 �� *Self+.a�5      �� $
 edit��6    � y�$ 	Collapsed=�6E   �� 5      $
 link��6    � y�$ Visible=�6E   5      P� 5       �@J�IsMouseOver .  . �5      �� $
 edit��6    � y�$ 	Collapsed=�6E   �� 5      $
 link��6    � y�$ Visible=�6E   �� 5       �@d�	IsChecked$ FalseY�62   5      5      5      .��5      �  � RowDefinitions 5    
   �� 5!      $
��auto �6   �� 5"      $
��131* �6   .+�5$   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5%      �� $��Please click on this ��6   d� 5&      -   5         d�Name$ toggle��5&      #��[  6+   �� 5'      $�� to show popup��6   5(      d� 5*   
   -   5        $	 btn��5*      $��
linkbutton��6$   $
��Left=�69   $��
305,29,0,0q�6T   $	��Top=�6h   $��75��6�   $��1��6�   ��5+      �� 5,       �� 
TargetType" d�6   .�5-      ��  � �� 5.      �� 5/      " d�6.   .R�50   "   �� #��z��6,   $��	Underline{�6M   $
 Hand��6i   
����  �6w   51      53      54      56        58   
   $
��Left=�6   $��239,225,0,0q�62   $��1��6G   $	��Top=�6T   $	��150��6l   � 5:   
   -   5         �Name$ Popup��5:       � 	StaysOpen .  $��Bottom=�6�    J� 	AllowDrop .  � PlacementTarget 6   ��  �� ElementName$	 btn����6K   �� $	 btn�� �� Path$ 	IsChecked�.��5;      �� 
�������$��1q�6(   
�������._�5<      �  .   � ColumnDefinitions 5=      �� 5>      $	��17* �6+   �� 5?      $	��63* �6+   .+�5A      n� -   5        $��Right=�5A      $��Bottom=�68   $��16��6S   $��16��6^   $��1��5B   s   � 5C      
�������$��30q�6.   $	��100��6:   $	��100��6J   $��2��6Y   .+�5D      (  "DevExpress.Xpf.Editors.ListBoxEdit     Items. 5E      ,  &DevExpress.Xpf.Editors.ListBoxEditItem  $��1��62     5F      $��2��62   5G      5H      5I      5J      5K        5L   
   $
��Left=�6   $	��150��65   $��	45,97,0,0q�6B   $��1��6U   $	��Top=�6b   $	��150��6z   5M      5N      