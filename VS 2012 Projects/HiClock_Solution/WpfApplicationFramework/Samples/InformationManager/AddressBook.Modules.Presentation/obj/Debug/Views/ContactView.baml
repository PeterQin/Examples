   M S B A M L   `   `   `  ����t  pWaf.InformationManager.AddressBook.Modules.Presentation, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null�Pclr-namespace:Waf.InformationManager.AddressBook.Modules.Presentation.DesignDataBWaf.InformationManager.AddressBook.Modules.Presentation.DesignData  5      O    IWaf.InformationManager.AddressBook.Modules.Presentation.Views.ContactView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ddPclr-namespace:Waf.InformationManager.AddressBook.Modules.Presentation.DesignData     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5
      � $��	0,0,22,11q�6     � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��22 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��
_Firstname��6   $��0��6Q   $��0��6a    �� Target 6%   ��  �� ElementName$ firstnameBox��6a   �� 5   
   -   5         ��Name$ firstnameBox��5       �� 	MaxLength$	 100��5!      $��1��6"   $��Stretch=�62   ��5   (   �� *Contact.Firstname+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� ValidatesOnDataErrors . 	 �� NotifyOnValidationError	 . 5!   2   �� 5#   
   $��Lastname��6   $��0��6#   $��1��63   �� 5$   
   $	 100��5&      $��1��6"   $��1��62   $��Stretch=�6?   ��5$      �� *Contact.Lastname+$ PropertyChanged=� .  . 	 . 5&   ?   �� 5(   
   $��Company��6   $��0��6"   $��2��62   �� 5)   
   $	 100��5+      $��1��6"   $��2��62   $��Stretch=�6?   ��5)      �� *Contact.Company+$ PropertyChanged=� .  . 	 . 5+   ?   �� 5-   
   $��Email��6   $��0��6    $��3��60   �� 5.   
   $	 100��50      $��1��6"   $��3��62   $��Stretch=�6?   ��5.      �� *Contact.Email+$ PropertyChanged=� .  . 	 . 50   ?   �� 52   
   $��Phone��6   $��0��6    $��4��60   �� 53   
   $	 100��55      $��1��6"   $��4��62   $��Stretch=�6?   ��53      �� *Contact.Phone+$ PropertyChanged=� .  . 	 . 55   ?   �� 57   
   $��Street��6   $��0��6!   $��6��61   �� 58   
   $	 100��5:      $��1��6"   $��6��62   $��Stretch=�6?   ��58      �� *Contact.Address.Street+$ PropertyChanged=� .  . 	 . 5:   ?   �� 5<   
   $
��City��6   $��0��6   $��7��6/   �� 5=   
   $	 100��5?      $��1��6"   $��7��62   $��Stretch=�6?   ��5=      �� *Contact.Address.City+$ PropertyChanged=� .  . 	 . 5?   ?   �� 5A   
   $��State��6   $��0��6    $��8��60   �� 5B   
   $	 100��5D      $��1��6"   $��8��62   $��Stretch=�6?   ��5B      �� *Contact.Address.State+$ PropertyChanged=� .  . 	 . 5D   ?   �� 5F   
   $��Postal Code��6   $��0��6&   $��9��66   �� 5G   
   $	 100��5I      $��1��6"   $��9��62   $��Stretch=�6?   ��5G      �� *Contact.Address.PostalCode+$ PropertyChanged=� .  . 	 . 5I   ?   �� 5K   
   $��Country��6   $��0��6"   $��10��62   �� 5L   
   $	 100��5N      $��1��6"   $��10��62   $��Stretch=�6@   ��5L      �� *Contact.Address.Country+$ PropertyChanged=� .  . 	 . 5N   @   5O      5P      