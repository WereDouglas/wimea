   M S B A M L   `   `   `  ����  WimeaApplication    WimeaApplication.UserPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  UserPage��5       N� 
Background
 �����$	��800��6&   $	��600��65   .��5	      � .+�5
   
   �� -   5        $��UserGrid��5
      $��	-1,30,1,0q�6#    �� SelectedItem 69   �� *CurrentUser+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF007ACC��6#      
BlurRadius$ 8Q�65    �� View 5      �� 5      -   5        grdTest��.P�5      ��  �� CellTemplate 5      �� 5      .R�5   "   ��  ��Name$ cbSelectRow��6,   	 d� 	IsChecked	 6A   �� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType" �� �� Path$ 
IsSelected�5      .��5      �� -   5        $ chkSelectAll��5   .   $��0q�6#   6D   5      �� 5      $
��Name��6%    �� DisplayMemberBinding 63   �� *Name+�� 5      $��E-mail��6%    65   �� *Email+�� 5      $��Contact��6%    66   �� *	Contact+�� 5      $
��Role��6%    63   �� *Role+�� 5      $��Station��6%    66   �� *	Station+�� 5       5       �� 5!      .R�5"   "   �� -   5        $��30��5"   *   $��60��66   $
��Edit��6A   ��5#   &   �� 5$   *   .R�5%   .   � 
������ .+�5&   2   �� �� 6=   $
�Edit��6A   6P   �� 5'   2   $��Right=�69   $
��None=�6U   $1��+/WimeaApplication;component/image/Edits.png��6d   5(   /   5)   +   5+   #   5,      5.      �� 5/       50      �� 51      .R�52   "   �� -   5        $��36��52   *   $��60��66   $��X��6A   ��53   &   �� 54   *   .R�55   .   � 
������ .+�56   2   �� �� 6=   $�Delete��6A   6R   �� 57   2   $��Right=�69   $
��None=�6U   $3��-/WimeaApplication;component/image/Deletes.png��6d   58   /   59   +   5;   #   5<      5>      5@      5B      �� 5C   
   -   5         ��Name$ btnAdd��5C   t   $��Add new��6   $
��Left=�6#   $��10,3,0,0q�6b   $	��Top=�6�   $��74��6�   $��21��6�   ��6>   �� $ 
AddCommand���5D      �� 5E      .R�5F      � 
������ .+�5G      �� 	Add new6-   �� 5H      $��Uniform=�6!   $/��)/WimeaApplication;component/image/Add.png��63   $��Right=�6f   5I      5J      5L      �� 5M   
   -   5        $ btnAdd_Copy��5M   w   $��Delete selected��6   $
��Left=�6+   $��94,5,0,0q�6e   $	��Top=�6�   $	��105��6�   $��21��6�   ��6F   �� *
AddCommand+��5N      �� 5O      .R�5P      � 
������ .+�5Q      �� Delete selected65   �� 5R      $��Uniform=�6!   $3��-/WimeaApplication;component/image/Deletes.png��63   $��Right=�6j   5S      5T      5V      �� 5W   
   -   5        $��alert��5W      $��26��6   $
��Left=�6)   $4��./WimeaApplication;component/image/redalert.png��6D   $��	388,6,0,0q�6|   $��19��6�   $	��Top=�6�   �� 5X   
   -	   5         ��Name$ lblName��5X      $��	414,5,0,0q�6%    �� TextAlignment$ Center=�68   $
��Bold"�6O    J� RenderTransformOrigin$ 0.5,0.5&�6a   ���	#FF0A518F$��19��6�   $	��Top=�6�   $
��Left=�6�   $	��146��6�   �� 6�   5Z      6    �� 5[   
   -
   5        $��	txtFilter��5[      $��30��6G   $	��Top=�6S   $��Right=�6k   $	��146��6�   $��0,0,1,0q�6�   �� 5\   
   $��Search by name��6   $��Right=�6)   $��	0,0,152,0q�6E   $	��Top=�6X   $��95��6p   $��27��6{   �� 5]   
   -   5        $ print��5]   n   $��Print��6   $
��Left=�6!   $��	204,4,0,0q�6[   $	��Top=�6~   $��56��6�   $��21��6�   ��6<   �� *
AddCommand+��5^      �� 5_      .R�5`      � 
������ .+�5a      �� �� 6%   $�Print��6)   69   �� 5b      $��Uniform=�6!   $1��+/WimeaApplication;component/image/Print.png��63   $��Right=�6h   5c      5d      5f      �� 5g   
   -   5        $ btnAdd_Copy1��5g   x   $��Delete selected��6   $
��Left=�6+   $��	273,4,0,0q�6e   $	��Top=�6�   $	��105��6�   $��21��6�   ��6F   �� *
AddCommand+��5h      �� 5i      .R�5j      � 
������ .+�5k      �� �� 6%   $�sync user list��6)   6B   �� 5l      $��Uniform=�6!   $8��2/WimeaApplication;component/image/synchronizes.png��63   $��Right=�6o   5m      5n      5p      5t      5u      