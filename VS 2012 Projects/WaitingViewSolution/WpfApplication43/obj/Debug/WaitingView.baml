   M S B A M L   `   `   `  ����  WpfApplication43"    WpfApplication43.WaitingView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _Microsoft.Expression.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      -   5          >�Name$  WaitingView1��5       � 	Resources 5
         Storyboard1 �� TargetProperty �� 
TargetName g� RepeatBehavior9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  Storyboard2  Storyboard3  Storyboard4��%\  &	        &	 �     &	 �    &	 f    �� 5   
   .��5      U� $ (ed:Arc.StartAngle)�6,   $
 arc1��6\   $ Forever��6y   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:2��6'   $ 90Q�67   5      5      �� 5   
   .��5      U� $ (ed:Arc.StartAngle)�6,   $
 arc2��6\   $ Forever��6y   .\�5        $ 0��6'   $ 90Q�63     5      $ 0:0:2��6'   $	 180Q�67   5      5      �� 5   
   .��5      U� $ (ed:Arc.StartAngle)�6,   $
 arc3��6\   $ Forever��6y   .\�5        $ 0��6'   $	 180Q�63     5      $ 0:0:2��6'   $	 270Q�67   5      5      �� 5   
   .��5      U� $ (ed:Arc.StartAngle)�6,   $
 arc4��6\   $ Forever��6y   .\�5        $ 0��6'   $	 270Q�63     5       $ 0:0:2��6'   $	 360Q�67   5!      5"      5#       � Triggers 5$      :� 5%   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5&      �� #��[  6   �� 5'      #��[ 6   �� 5(      #��[ 6   �� 5)      #��[ 6   5*      .��5,      � -   5        	 �Name$
	 grid��5,      .+�5.   
   %  Microsoft.Expression.Shapes.Arc  -   5        
  Name$

 arc1��5.         ArcThickness$ 6Q�6      
StartAngle$ 0Q�60      EndAngle$ 90Q�6?      ArcThicknessUnit$ Pixel=�6M   ���	#FF276D70$
��Left=�6w    �� Stretch$
 None=�6�   ���	#FF8EFBE7��6�   ��  �� Path$ Height� �� ElementName$ WaitingView1�� �� Mode$ OneWay=���6�   �� $ Width�$ WaitingView1��$ OneWay=�  5/   
   -   5        $

 arc2��5/      $ 6Q�6   $ 90Q�60   $	 180Q�6@   $ Pixel=�6P   ���	#FF00E9F3$
��Left=�6z   $
 None=�6�   ���	#FF8EFBE7��6�   �� $ Height�$ WaitingView1��$ OneWay=���6�   �� $ Width�$ WaitingView1��$ OneWay=�  50   
   -   5        $

 arc3��50      $ 6Q�6   $	 180Q�60   $	 270Q�6A   $ Pixel=�6Q   ���	#FFFF6C6C$
��Left=�6{   $
 None=�6�   ���	#FF8EFBE7��6�   �� $ Height�$ WaitingView1��$ OneWay=���6�   �� $ Width�$ WaitingView1��$ OneWay=�  51   
   -   5        $

 arc4��51      $ 6Q�6   $	 270Q�60   $	 360Q�6A   $ Pixel=�6Q   ���	#FF276D70$
��Left=�6{   $
 None=�6�   ���	#FF8EFBE7��6�   �� $ Height�$ WaitingView1��$ OneWay=���6�   �� $ Width�$ WaitingView1��$ OneWay=�52      53      