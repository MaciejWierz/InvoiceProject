   M S B A M L   `   `   `  ����E  AInvoice_mw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Invoice_mw.ControlsInvoice_mw.Controls  5      %    Invoice_mw.Controls.InvoiceList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Invoice_mw.Controls     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      $��7* �6   6*   �� 5      6   .+�5   
   �� -   5        $��	Searchtxt��5      $��0��6#   $��0��63   $��4��6@   $��20,10q�5      6G   &   System.Windows.Controls.DataGrid  5   
   -   5        $��invoice_grid_view��5   )   $��20,20,20,10q�6      SelectionMode$ Single=�5      $��0��5      $��1��5      $��4��5       6)   �� 5"   
   -   5        $��
AddInvoice��5"   )   $��Dodaj fakturę��6   $��0��5#      $��2��6!   $��	20,0,0,10q�6.   6C   �� 5$   
   -   5        $��DeleteInvoice��5$   (   $��Usuń fakturę��6   $��1��5%      $��2��6!   $��0,0,0,10q�6.   6B   �� 5&   
   -   5        $��
ToSubjects��5&   )   $��Dodaj podmiot��6   $��2��5'      $��2��6!   $��0,0,0,10q�6.   6B   �� 5(   
   -   5        $��ToItems��5(   )   $��Dodaj produkt��6   $��3��5)      $��2��6!   $��	0,0,20,10q�6.   6C   5*      5+      