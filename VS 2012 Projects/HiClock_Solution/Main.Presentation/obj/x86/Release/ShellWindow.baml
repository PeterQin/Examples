   M S B A M L   `   `   `  ����   Main.Presentation#    Main.Presentation.ShellWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  -     � Title$  HiClock��$	��500��$	��800��   
HiClockIco � Icon# [   � WindowStartupLocation$ CenterScreen=�$	��550��$	��730�� � 	Resources  �� MergedDictionaries �� Source��  �� $C =/Common.Presentation;Component/Resources/CommonResources.xaml?�%    .��� .+�3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -      
IconSource# [  $��3��   TrayToolTip �� ���	#FF04BDDA���	#FF77D8E8$��1q�._�� $��12q� � RowDefinitions �� $
��auto ��� $
��auto �.+��� 
�������$��15(�$
��Bold"�$��0��$��Next Alarm:���� 
�������$��15(�$��1������ *ShellService.NextAlarm+	 � ContextMenu	 �� .@�m� $��_HiClock��
 m� Command
 �� *ShowShellWindowCommand+ m� Icon ��   HiClock#��[ $��16��m� $��_Sleep��
 �� *ShowSleepScreenCommmand+ ��  
 TeaPng#��[ $��16��m� $��_Exit��
 �� *ExitAppCommand+ ��   PowerOffPng#��[ $��16���� ���� *ShellService.ShellContent+ �� Mode$ OneWay=�