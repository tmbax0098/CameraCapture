   M S B A M L   `   `   `  ����H  DCameraCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CameraCapture.ViewsCameraCapture.Views  5   	   &     CameraCapture.Views.SigninWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CameraCapture.Views     5   	     � Title$  SigninWindow��5   	   $	��200��6   $	��300��6+   $��2q�67   
������� � WindowStartupLocation$ CenterScreen=�6_    � WindowStyle$
 None=�6�   ���	#FF1D1D1D.��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��Username��6-   $
��Left=�6@   $��Center=�6[   
���������6v   Z� 6�   �� 5   
   $��1��6   $��0��6   $��Password��6-   $
��Left=�6@   $��Center=�6[   
�������6v   �� 5   
   -   5        $��2��5      $��0��6   $��Cancel��6.   $��4q�6?      Button_Rounded#���   6J   6v   �� 5   
   -   5         ��Name$ txtUsername��5      $��0��6'   $��1��64   G� 5   
   -   5         G�Name$ txtPassword��5      $��1��6+   $��1��68   �� 5   
   -   5         ��Name$ btnLogin��5      $��2��6#   $��1��60   $��Login��6@   $��4q�6P   #���   6[   6�   �� 5   
   -   5         ��Name$ 	lblResult��5      $��3��6#   $��1��60   $�� ��6@   
�������6K   5       5!      