   M S B A M L   `   `   `  ����H  DCameraCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CameraCapture.ViewsCameraCapture.Views  5   	   '    !CameraCapture.Views.SettingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CameraCapture.Views     5   	     � Title$  SettingWindow��5	   	   $	��450��6   $	��800��6,      windowStyle#��[  69    � WindowStartupLocation$ CenterScreen=�6^    � WindowStyle$
 None=�6�    � WindowState$ 	Maximized=�6�   .��5
      � $��5q�6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��70 �6   �� 5      �� 5      $��50 �6   .+�5   
   �� $��0,0,0,2q�6   
�������$��0,0,0,10q�6?   ._�5      �� $��Page Setting��6   $
��Left=�6,   $��16(�6G   $
��Bold"�6U   
�������6g   5      �� 5   
   $��Patient Storage��6   $��1��6,   
�������.��5      /   )CameraCapture.Views.GallerySettingControl  5      � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $	��250��6#   �� 5      $	��250��6#   �� 5      $	��200��6#   �� 5      $	��200��6#   .+�5"      �� $��0��6   $��Camera Setting��6'   
�������$��0,0,5,0q�6R   .��5#      +   %CameraCapture.Views.DvrSettingControl  $	��Top=�6+   5$      �� 5&      $��1��6   $��Control Setting��6'   
�������$��0,0,5,0q�6S   .��5'      -   'CameraCapture.Views.PedalSettingControl  $	��Top=�6,   5(      �� 5)      $��2��6   $��Serial Port Setting��6'   
�������$��0,0,5,0q�6W   .��5*      +   %CameraCapture.Views.SerialPortControl  $	��Top=�6,   5+      �� 5,      $��3��6   $��Capture setting��6'   
�������$��0,0,5,0q�6S   .��5-      (   "CameraCapture.Views.CaptureSetting  $	��Top=�6)   5.      5/      � 51   
   $��3��6    52      �� 53      $��50 �6#   �� 54      .+�57      �� -   5        $0��*/CameraCapture;component/Resource/back.png��57      6H   59      5D      5E      