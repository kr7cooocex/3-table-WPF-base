   M S B A M L   `   `   `  ����A  =hntshd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:hntshdhntshd  5   	       hntshd.Bookings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:hntshd     5   	   -   5          � Title$  Bookings��5   	   $	��450��5	      $	��800��5
   	   .��5      � .+�5   
   o� $��25��6   $	��Top=�5      .@�5      m� $
��Base��6   .@�5      m� -   5        $��Select��5      6C   m� 5      -   5        $��Insert��5      6C   m� 5      -   5        $��Update��5      6C   m� 5      -   5        $��Delete��5      6C   �� 5      m� 5      $��Clear��6   6,   5      5      �� 5   
   -   5         ��Name$ tb_BookingID��5      $
��Left=�5      $��23��5      $��	24,40,0,0q�5       �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��120��5      5      �� 5   
   $��	BookingID��6   $
��Left=�5       $��
152,38,0,0q�5!      $	��Top=�5"      �� 5#   
   -   5        $ tb_ClientID��5)      $
��Left=�5#      $��23��5$      $��	24,80,0,0q�5%      $
 Wrap=�5&      $	��Top=�5'      $	��120��5(      5)      �� 5*   
   $��ClientID��6   $
��Left=�5+      $��
153,78,0,0q�5,      $	��Top=�5-      �� 5.   
   $��TourID��6   $
��Left=�5/      $��156,118,0,0q�50      $	��Top=�51      �� 52   
   $��BookingDate��6   $
��Left=�53      $��156,156,0,0q�54      $	��Top=�55      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ dg��5;      $
��Left=�56      $	��353��57      $��
251,44,0,0q�58      $	��Top=�59      $	��519��5:      5<      �� 5=   
   -	   5        $ 	tb_TourID��5C      $
��Left=�5=      $��23��5>      $��
24,118,0,0q�5?      $
 Wrap=�5@      $	��Top=�5A      $	��120��5B      5C      (  "System.Windows.Controls.DatePicker  5D   
   -
   5          Name$ DP_BookingDate��5D   h   $
��Left=�6   $��
24,158,0,0q�60   $	��Top=�6D   $	��127��6\   6h   5F      5G      