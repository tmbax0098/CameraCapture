   M S B A M L   `   `   `  ����H  DCameraCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CameraCapture.ViewsCameraCapture.Views  5   	   (    "CameraCapture.Views.MessageControl   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CameraCapture.Views     5   	     � Title$  MessageControl��5   	   $	��150��6    $	��400��6-    � WindowStyle$
 None=�69    � WindowStartupLocation$ CenterScreen=�6L   $��2q�6q   
�������
���   � � ShowInTaskbar .  .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      .+�5   
   �� $��0,0,0,2q�6   
�������._�5      �  � ColumnDefinitions 5      �� 5      $��50 �6'   �� 5      �� 5      $��50 �6'   .+�5      �� $��0��6   $3��-/CameraCapture;component/Resource/warning.png��6(   �� 5      -   5         ��Name$ lblTitle��5      $��1��6*   $��Message Title��6:   
�������$��Center=�6e   $��18(�6�   $
��Bold"�6�   �� 5      -   5        $��2��5      $0��*/CameraCapture;component/Resource/exit.png��6(   $��5q�6\   6g   5      5      � 5   
   $��1��6   $��0,5,0,0q�6    5      �� 5      $��50 �6#   �� 5       .+�5#      �� -   5         ��Name$ 
lblMessage��5#      $��1��6,   $��Message content is here��6<   $
��Left=�6[   $	��Top=�6v   
�������$��16(�6�   5%      5'      5(      