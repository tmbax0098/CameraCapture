   M S B A M L   `   `   `  ����H  DCameraCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CameraCapture.ViewsCameraCapture.Views  5      +    %CameraCapture.Views.SerialPortControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CameraCapture.Views     5      -   5        $	��150��5   7   $	��200��6G   .��5	      �   � RowDefinitions  5
   
   �� 5      �� 5      �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��70 �6#   �� 5      .+�5      �� $��	Port name��6   $��0��6(   $
��Left=�65   $��Center=�6P   
�������6k   �� 5      -   5        $��txtPortName��5      $��1��6)   5      � 5   
   $��1��6    5      �� 5       $��70 �6#   �� 5!      .+�5$      �� $��BaudRate��6   $��0��6'   $
��Left=�64   $��Center=�6O   
�������6j   �� 5%      -   5        $��txtBaudRate��5%      $��1��6)   5'      �� 5(   
   -   5        $��btnSave��5(      $
��Save��6    $��2��6/   $��2q�6<      Button_Rounded#���   6G   6s   5*      5+      