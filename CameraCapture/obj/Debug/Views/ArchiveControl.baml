   M S B A M L   `   `   `  ����H  DCameraCapture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CameraCapture.ViewsCameraCapture.Views  5      (    "CameraCapture.Views.ArchiveControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CameraCapture.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $	��120 �6   �� 5      .+�5   
   �� $��Filter patient��6   $��0,0,0,10q�6+   
�������.��5      �   5      �� 5      $��40 �6$   �� 5      $��40 �6$   .+�5      �  � ColumnDefinitions 5      �� 5      $	��150 �6+   �� 5      .+�5      �� $��Patient information��6   $��Center=�6:   
�������6U   �� 5      -   5         ��Name$ txtValue��5      $��1��60   5      � 5      $��1��6    5      �� 5       $	��150 �6+   �� 5!      �� 5"      $	��150 �6+   �� 5#      �� 5$      $��80 �6+   �� 5%      $��80 �6+   .+�5'      �� $��	From Date��6   $��0��60   $��Center=�6@   
�������$��Right=�6n   (  "System.Windows.Controls.DatePicker  5(      -   5          Name$ 
dtFromDate��5(   !   $��1��65   $��Center=�6E   �� 5)      $��To Date��6   $��2��6.   $��Center=�6>   
�������$��Right=�6l     5*      -   5        $ dtToDate��5*   !   $��3��63   $��Center=�6C   �� 5+      -   5        $��	btnFilter��5+      $��Filter��6.   $��4��6?      Button_Rounded#���   6O   $��5q�6{   6�   �� 5,      -   5        $��	btnDetail��5,      $��Detail��6.   $��5��6?   #���   6O   $��5q�6{   6�   5-      5.      5/      �� 50   
   $��Archive Patient Table��6   $��2��63   $��0,0,0,10q�6@   
�������.��51      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��51         AutoGenerateColumns .     
IsReadOnly .    RowHeaderWidth$ 0Q�6�   ��6E   Z� ��6�   Z�    Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 2* 6)   
   Header$
 Title��64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Title+  54      $	 2* 6)   $
 
First name��64    6H   �� *	FirstName+  55      $	 2* 6)   $
 	Last name��64    6G   �� *
LastName+  56      $	 * 6)   $
 
Patient ID��63    6G   �� *	PatientId+58      59      5:      5;      