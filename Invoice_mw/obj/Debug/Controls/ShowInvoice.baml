   M S B A M L   `   `   `  ����E  AInvoice_mw, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Invoice_mw.ControlsInvoice_mw.Controls  5      %    Invoice_mw.Controls.ShowInvoice   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Invoice_mw.Controls     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6!   �� 5      $��3* �6   6,    � RowDefinitions 5   
   �� 5      6   �� 5      $��2* �6   6*   �� 5      $��3* �6   6*   �� 5      6   .+�5   
   (�  (� StretchDirection$
 Both=�6   $��0��6*   $��0��6:   $��5��6I   .��5      �� $��26(�6   $��Center=�6'   	Faktura6O   5      (� 5   
   $
��5000��6   $
 Both=�6"   $��0��6:   $��1��6J   $��3��6Y   .��5      �� -   5        $��subjectFrom��5      $��20q�6-   $��25(�69   5       (� 5"   
   $
��5000��6   $
 Both=�6"   $��3��6:   $��1��6J   $��3��6X   .��5#      �� -   5        $��
subjectFor��5#      $��20q�6+   $��25(�67   5$      (� 5&   
   $
��5000��6   $
 Both=�6"   $��6��6:   $��1��6J   .��5'      �� -   5        $��invoiceInfo��5'      $��20q�6,   $��25(�68   5(      �� 5+   
   $��0��6   $��2��6'   $��7��64   $��10q�6H   $	��Top=�6T   .��5,      (� $
 Both=�6   .��5-      &   System.Windows.Controls.DataGrid  -   5        $��items_grid_view��5-         SelectionMode$ Single=�60   5.      5/      50      (� 52   
   $
 Both=�6   $��5��6+   $��3��6;   $��2��6H   $��0,0,20,0q�6\   .��53      �� -   5        $	��sum��53      $��20(�6#   54      �� 56   
   -   5        $��toInvoiceList��56      $��Wróć��6B   $��0��6Q   $��3��6a   $��2��6n   $
��10,0q�6�   �� 58   
   -   5        $
��Edit��58   #   $��Edytuj��6   $��3��6B   $��2��6O   $
��10,0q�6_   $��2��6m   59      5=      