   M S B A M L   `   `   `  ����  ChartPerformanceTest*    $ChartPerformanceTest.StopwatchWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _DevExpress.Xpf.Gauges.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxga4http://schemas.devexpress.com/winfx/2008/xaml/gauges  5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	     � Title$  My Stopwatch��5   	   $	��185��6   $	��320��6+    � WindowStartupLocation$ CenterScreen=�67    � Topmost .  � WindowStyle$ 
ToolWindow=�6k   
�������&   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 
Office2013 5   	   .��5      � $��12q�6    � ColumnDefinitions 5	   
   �� 5
      $��2* �6   �� 5      $��3* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� -   5         ��Name$ btnReset��5   !   $��Reset��6   $��1��63   $��0��6@   $��6q�6P   6[   �� 5   
   -   5        $ btnStartStop��5   &   $��
Start/Stop��6   $��1��6<   $��1��6I   $��6q�6Z   6e   �� 5   
   -   5        $ btnExit��5       $
��Exit��6   $��1��61   $��2��6>   $��6q�6O   6Z   /  )DevExpress.Xpf.Gauges.DigitalGaugeControl  5   
   -   5          Name$ digitalControl��5   #   	   Text$	 11:11:11.222222��6;   
   SymbolCount$
 15��6R   $��0q�6c   $��0��6o   $��3��6|      Model 5      2  ,DevExpress.Xpf.Gauges.DigitalMagicLightModel  5         Layers 5      -  'DevExpress.Xpf.Gauges.DigitalGaugeLayer  5         
SymbolView 5      )  #DevExpress.Xpf.Gauges.MatrixView5x8  5      5       5!      5"      