   M S B A M L   `   `   `  ����H  DCameraCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CameraCapture.ViewsCameraCapture.Views  5   	   %    CameraCapture.Views.CloseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CameraCapture.Views     5   	     � Title$  CloseWindow��5   	   $	��120��6   $	��350��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � WindowStyle$
 None=�6q   
���   �$��2q�6�   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      �� 5      $��50 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��50��6#   �� 5      .+�5      �� $4��./CameraCapture;component/Resource/question.png��6   �� 5      $��1��6   $#��Are you leaving the program ?��6(   $
��Left=�6M   $
��Bold"�6h   
�������$��16(�6�   5      � 5   
   $��2��6    5      �� 5      �� 5      .+�5      �� -   5         ��Name$ btnYes��5      $��0��6%   $��5q�65      Button_Rounded#���   6@   $	��Yes��6l   6z   �� 5      -   5        $ btnNo��5      $��1��6$   $��5q�64   #���   6?   $��No��6k   6x   5      5      5       