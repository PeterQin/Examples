   M S B A M L   `   `   `  ����  HiClock.Presentation+   %HiClock.Presentation.HiClockImageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��0q�5   7   $��0q�6C     � 	Resources  5	       �� MergedDictionaries �� Source   ImageItemTemplate �� Mode  StrToImageConver �� 	Converter  ImageItemSelectedTemplate d� 	IsChecked  ImageItemMouseOverTemplate �� 
TargetType  SelectImageItemStyle �� Property �� Value	 �� Triggers
 P� Property P� Value�� 5
   
    5      �� 5      $C =/Common.Presentation;Component/Resources/CommonResources.xaml?�6%   %  &	        7  &	 �     7  &	 �    7  &	 �    7   7  7  �� 5      .R�5      �� 
�������$��1q�62   $��6q�6F   ._�5      � ���	#FFF7F3F3.+�5      �� $	��126��6v   $	��110��6�   ��6    �� *
FullName+$ OneWay=�8   6�   5      5      5      �� 5      .R�5      �� 
�������$��1q�62   $��6q�6F   ._�5      � ���	#FFF7F3F3.+�5      �� $
 TrueY�6#   �� 5      $	��126��6v   $	��110��6�   ��6    �� *
FullName+$ OneWay=�8   6�   5      5      5      �� 5      .R�5      �� 
�������$��1q�62   $��6q�6F   ._�5      � ���	#FFF7F3F3.+�5       �� $ FalseY�6#   �� 5!      $	��126��6v   $	��110��6�   ��6    �� *
FullName+$ OneWay=�8   6�   5"      5#      5$      �� 5%      " ��6   .�5&      ��  � ��8   64   	 5'      P� 5(      
 �@J�IsMouseOver . . �5)      ��  � ��8  6<   5*      P� 5+      
 �@��
IsSelected . . �5,      ��  � ��8  6<   5-      5/      50      .��52      � .+�53   
   �� -   5         ��Name$ 	listImage��53       �� SelectionMode$ Extended=�6T   $��0q�6m   $��0q�6�   $��Disabled=�54      #��[ 55       � IsSharedSizeScope . ��53   %   �� *	ImageList+$ OneWay=���56      �� 57      .R�58      �  K� IsItemsHost . 6    59       � ContextMenu 5;      �� 5<      .@�5=      m� $��Remove Selected Image��6    m� Command 6>   �� *RemoveImageCommand+$ OneWay=�5>      5@      5A      5B      