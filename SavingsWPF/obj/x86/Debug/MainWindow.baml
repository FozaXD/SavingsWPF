   M S B A M L   `   `   `  ����E  ASavingsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SavingsWPF
SavingsWPF  5   	       SavingsWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SavingsWPF     5   	   -   5          �Name$  Savings��5   	    � Title$ Savings��5   	      BackgroundCustom#���   6    J� Opacity$
 0.95Q�6I   $	��900��6X   $	��498��6g    � Icon$ dollar32.ico��6w   .��5	      � -   5         �Name$
 Main��5	      $
 0.95Q�6   #���   6(    � ColumnDefinitions 5
   
   �� 5      $	��98* �6   �� 5      $	��33* �6   �� 5      $
��315* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ yearlyDataGridView��5      $
��Left=�6/   $��
43,160,0,0q�6J   $	��Top=�6^   $��3��6v   $	��217��6�   $	��267��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6[   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   Z� 
   ClipboardContentBinding
 68   Z� 6[     5      $ Description��6[   	 6%   Z� 
 68   Z� 6[     5      $ Category��6[   	 6%   Z� 
 68   Z� 6[     5      $ Amount��6[   	 6%   Z� 
 68   Z� 6[   5      5      5      