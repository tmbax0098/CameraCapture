   M S B A M L   `   `   `  ����H  DCameraCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CameraCapture.ViewsCameraCapture.Views  5   	   -    'CameraCapture.Views.ArchiveDetailWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CameraCapture.Views     5   	   -   5          � Title$  ArchiveDetailWindow��5   	   $	��450��6%   $	��800��62   
���   � � WindowStartupLocation$ CenterScreen=�6Q    � WindowState$ 	Maximized=�6v    � 
ResizeMode$ NoResize=�6�    � ShowInTaskbar .   � Topmost .  � WindowStyle$
 None=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $	��120 �6   �� 5      $��50 �6   .+�5   
   � $��0,10,0,0q�6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��
Left Image��6'   
�������$��0,0,3,0q�6N   .��5      �  5      �� 5      �� 5      $��50 �6(   .+�5      �� -   5        	 ��Name$	 	imageLeft��5      $
��Fill=�6/   �� 5      -   5        
 ��Name$
 
btnSetLeft��5      $��Set Left��61   $��1��6D      Button_Rounded#���   6Q   $��5q�6}   6�   5      5      �� 5       $��1��6   $��Right Image��6(   
�������$��3,0,0,0q�6P   .��5!      �  5"      �� 5#      �� 5$      $��50 �6(   .+�5&      �� -   5        $	 
imageRight��5&      $
��Fill=�60   �� 5'      -   5        $
 btnSetRight��5'      $��	Set Right��62   $��1��6F   #���   6S   $��5q�6   6�   5(      5)      5*      �� 5+   
   $��1��6   $��Gallery��6    
�������.��5,   
   (   "CameraCapture.Views.GalleryControl  -   5          Name$ gallery��5,      5-      �� 5.   
   $��2��6   $��0,0,0,0q�6   ���	#FFCDCDCD._�5/      � $��5q�6    50      �� 51      $��40 �6'   �� 52      �� 53      $��40 �6'   .+�55      �� -   5        $��50��55      $0��*/CameraCapture;component/Resource/back.png��6#   6W   56      57      58      59      