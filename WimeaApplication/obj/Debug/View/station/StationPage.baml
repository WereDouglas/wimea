   M S B A M L   `   `   `  ����  WimeaApplication"    WimeaApplication.StationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Stations��5       N� 
Background
 �����$	��800��6&   $	��600��65   .��5	      � .+�5
   
   �� -   5        $��StationGrid��5
      $��	-1,30,1,0q�6&    �� SelectedItem 6<   �� *CurrentStation+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF007ACC��6#      
BlurRadius$ 8Q�65    �� View 5      �� 5      -   5        grdTest��.P�5      ��  �� CellTemplate 5      �� 5      .R�5   "   ��  ��Name$ cbSelectRow��6,   	 d� 	IsChecked	 6A   �� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType" �� �� Path$ 
IsSelected�5      .��5      �� -   5        $ chkSelectAll��5   .   $��0q�6#   6D   5      �� 5      $
��Name��6%    �� DisplayMemberBinding 63   �� *Name+�� 5      $	��No.��6%    62   �� *Number+�� 5      $��
Block Code��6%    69   �� *Code+�� 5      $��Latitude��6%    67   �� *
Latitude+�� 5      $��	Longitude��6%    68   �� *	Longitude+�� 5      $��Altitude��6%    67   �� *
Altitude+�� 5       $
��Type��6%    63   �� *Type+�� 5!      $��Location��6%    67   �� *
Location+�� 5"      $��Status��6%    65   �� *Status+�� 5#      $��Commissioned��6%    6;   �� *Commissioned+�� 5$       5%      �� 5&      .R�5'   "   �� -   5        $��30��5'   *   $��60��66   $
��Edit��6A   ��5(   &   �� 5)   *   .R�5*   .   � 
������ .+�5+   2   �� �� 6=   $
�Edit��6A   6P   �� 5,   2   $��Right=�69   $
��None=�6U   $1��+/WimeaApplication;component/image/Edits.png��6d   5-   /   5.   +   50   #   51      53      �� 54       55      �� 56      .R�57   "   �� -   5        $��36��57   *   $��60��66   $��X��6A   ��58   &   �� 59   *   .R�5:   .   � 
������ .+�5;   2   �� �� 6=   $�Delete��6A   6R   �� 5<   2   $��Right=�69   $
��None=�6U   $3��-/WimeaApplication;component/image/Deletes.png��6d   5=   /   5>   +   5@   #   5A      5C      5E      5G      �� 5H   
   -   5         ��Name$ btnAdd��5H   t   $��Add new��6   $
��Left=�6#   $��10,3,0,0q�6b   $	��Top=�6�   $��74��6�   $��21��6�   ��6>   �� $ 
AddCommand���5I      �� 5J      .R�5K      � 
������ .+�5L      �� 	Add new6-   �� 5M      $��Uniform=�6!   $/��)/WimeaApplication;component/image/Add.png��63   $��Right=�6f   5N      5O      5Q      �� 5R   
   -   5        $ btnAdd_Copy��5R   w   $��Delete selected��6   $
��Left=�6+   $��94,5,0,0q�6e   $	��Top=�6�   $	��105��6�   $��21��6�   ��6F   �� *
AddCommand+��5S      �� 5T      .R�5U      � 
������ .+�5V      �� Delete selected65   �� 5W      $��Uniform=�6!   $3��-/WimeaApplication;component/image/Deletes.png��63   $��Right=�6j   5X      5Y      5[      �� 5\   
   -   5        $��alert��5\      $��26��6   $
��Left=�6)   $4��./WimeaApplication;component/image/redalert.png��6D   $��	297,5,0,0q�6|   $��19��6�   $	��Top=�6�   �� 5]   
   -	   5         ��Name$ lblName��5]      $��	346,5,0,0q�6%    �� TextAlignment$ Center=�68   $
��Bold"�6O    J� RenderTransformOrigin$ 0.5,0.5&�6a   ���	#FF0A518F$��19��6�   $	��Top=�6�   $
��Left=�6�   $	��214��6�   �� 6�   5_      6    �� 5`   
   -
   5        $��	txtFilter��5`      $��24��6G   $	��Top=�6S   $��Right=�6k   $	��142��6�   $��0,3,5,0q�6�   �� 5a   
   $��Search by name��6   $��Right=�6)   $��	0,6,142,0q�6E   $	��Top=�6X   $	��105��6p   �� 5b   
   -   5        $ print��5b   n   $��Print��6   $
��Left=�6!   $��	204,4,0,0q�6[   $	��Top=�6~   $��56��6�   $��21��6�   ��6<   �� *
AddCommand+��5c      �� 5d      .R�5e      � 
������ .+�5f      �� �� 6%   $�Print��6)   69   �� 5g      $��Uniform=�6!   $1��+/WimeaApplication;component/image/Print.png��63   $��Right=�6h   5h      5i      5k      5o      5p      