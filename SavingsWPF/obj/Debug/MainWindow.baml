   M S B A M L   `   `   `  ����E  ASavingsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SavingsWPF
SavingsWPF  5   	       SavingsWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SavingsWPF     5   	   -   5          �Name$  Savings��5   	    � Title$ Savings��5   	      BackgroundCustom#���   6    J� Opacity$
 0.95Q�6I   $	��900��6X   $	��498��6g    � Icon$ dollar32.ico��6w   $��20q�6�   .��5	      � -   5         �Name$
 Main��5	      $
 0.95Q�6   #���   6(    � ColumnDefinitions 5
   
   �� 5      $��253.333333333* �6   �� 5      $��253.333333333* �6   �� 5      $��253.333333* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ yearlyDataGridView��5      $��20,250,20,20q�6/      
IsReadOnly .  J� RenderTransformOrigin$ 0.5,0.5&�6W   #��� ��6w   
���   �	   HorizontalGridLinesBrush
	 �����
   VerticalGridLinesBrush

 �����   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6U     ColumnHeaderHeight$ 20Q�6�   � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � �� �	#FF63636363   �� 5       � ��$
 Bold"�64   5      5      z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.076Q�6&   T� 5      5      5      � 5   
   $��2��6   $
��Left=�6   $	��100��6:   $��277,189,-88,0q�6G   $	��Top=�6^   $	��100��6v     5    
   -   5        $ monthlyDataGridView��5       $��20,250,21,20q�60    . $ 0.5,0.5&�6X   #��� ��6x   
���   �
	 �����

 �����$
 Auto 6  $ 20Q�6U  $��1��6m   5!      ��%�   '        �� 5"      "  6   .�5#      ��  � �� �	#FF63636363   �� 5$       � ��$
 Bold"�64   5%      5&      z�5'      V� 5(      .~�5)      �� �� 5*      �� 5+      $ -0.076Q�6&   T� 5,      5-      5/        50   
   -   5        $ wantedDataGridView��50      $��20,250,20,20q�6/    . $ 0.5,0.5&�6W   #��� ��6w   
���   �
	 �����

 �����$
 Auto 6  $ 20Q�6T  $��2��6l   51      ��%�   '        �� 52      "  6   .�53      ��  � �� �	#FF63636363   �� 54       � ��$
 Bold"�64   55      56      z�57      V� 58      .~�59      �� �� 5:      �� 5;      $ -0.076Q�6&   T� 5<      5=      5?      �� 5@   
   -   5         ��Name$ yearlyTotal��5@      $��Label��6%   $
��Left=�65   $��
76,220,0,0q�6P   $	��Top=�6d   $��42��6|   
�������6�   �� 5A   
   -   5        $ yearlyTotalLabel��5A      $��Yearly:��6*   $
��Left=�6<   $��
24,220,0,0q�6W   $	��Top=�6k   $��47��6�   
�������$
��Bold"�6�   5C      5D      