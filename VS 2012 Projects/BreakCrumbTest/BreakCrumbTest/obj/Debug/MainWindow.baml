   M S B A M L   `   `   `  ����I  EBreakCrumbTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BreakCrumbTestBreakCrumbTest  5   	       BreakCrumbTest.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .localclr-namespace:BreakCrumbTest     5   	   a ]DevExpress.Xpf.Grid.v12.2, Version=12.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v12.2.Core, Version=12.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dc2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ Seven 65   .��5	      � $��6q�6    � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ tstack��5       �� Orientation$ 
Horizontal=�6%   $��1��6>   $
��Left=�6K   $	��100��6f   $��
71,118,0,0q�6s   $	��Top=�6�   $	��405��6�   .+�5      �� -   5        $��test add��5      6(   �� 5      -   5        $��test remove��5      6+   �� 5      -   5        $��test Parent ChildList��5      $	��120��65   6A   �� 5      -   5        $��test rename��5      $	��120��6+   67   5         BreakCrumbTest.BreadCrumb  5   
   -   5          Name$ bread��5      
���   �$��0q�6h   ���	#FFEDEEF0$��0��6�      
ItemSource 6*   �� *Items+ �� Mode$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��
194,38,0,0q�60   $��1��6D   $
��Wrap=�6Q   $	��Top=�6�   $��28��6�   $	��169��6�   ��6e   ��  �� ElementName$ bread��	 �� Path$	 ActivedItem�$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��33��6/   $��	10,38,0,0q�6;   $��1��6N   $
��Wrap=�6[   $#��Trace by Dependency property:��6o   $	��Top=�6�   $	��170��6�   5      5      