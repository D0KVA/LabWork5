   M S B A M L   `   `   `  ����C  ?LabWork5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LabWork5LabWork5  5          LabWork5.PageOrders   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:LabWork5     5        N� Title$  
PageOrders��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.1* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dg_or��5         
IsReadOnly . $��6��65   $��2��6I   6V   �� 5   
   -   5         ��Name$ 	AddButton��5      $��2��6$   $��0��68   $��Добавить��6E   $��36(�6X   6f   �� 5   
   -   5        $ DeleteButton��5      $��2��6'   $��Удалить��67   $��36(�6I   $��2��6W   6k   �� 5   
   -   5        $ ChangeButton��5      $��4��6'   $��Изменить��67   $��36(�6J   $��2��6X   6l   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ tbxDateO��5      $��1��6'   $��0��64   6D   �� 5   
   -   5         ��Name$ tbxclID��5      $��1��6$   $��1��61   �� 5   
   -   5        $ tbxchID��5      $��1��6$   $��2��61   �� 5    
   -   5        $ tbxstID��5       $��1��6$   $��3��61   �� 5!   
   -	   5        $ tbxrbID��5!      $��1��6$   $��4��61   �� 5"   
   -
   5        $ tbxsgs��5"      $��1��6#   $��5��60   5#      5$      