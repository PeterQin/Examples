   M S B A M L   `   `   `  ����  	GoWPFTest    GoWPFTest.PathWindow   5   	   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   -   5          �Name$	  win��5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � 
ResizeMode$ CanResizeWithGrip=�66    � Title$ Select Path��5   	   $	��161��6   $	��393��6*   
�������$	��100��6M   $	��200��6]   .��5      � $��35,35,35,21q�6    � ColumnDefinitions 5   
   �� 5	      $
��auto �6   �� 5
      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��Path: ��6   $��0��6"   $��Center=�62   $��20(�6M   �� 5   
   -   5         ��Name$ txtPath��5      
�������$��1��6;   $��Center=�6K   $��15(�6m   ��6{   �� 	 �� Path$
	 Path�
 �� ElementName$	
 win�� �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ White��6#   $ 1Q�61   5      .��5   "   5      � 5   
   $��1��6   $��1��6   $��0,28,0,0q�6,    5      �� 5      $��* �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� -   5         ��Name$ btnOk��5      $��1��6$   $��Ok��64    �� 	IsDefault . $��75��6�   $��30��6�   {�6A   �� $	 IsValidPath�$	
 win��$ OneWay=�$ PropertyChanged=�6�   �� 5       -   5        $ 	btnCancel��5       $��2��6(   $��Cancel��68    �� IsCancel . $��6,0,0,0q�6Y   $��75��6j   $��30��6u   6�   5!      5"      5#      