   M S B A M L   `   `   `  ����  WimeaApplication"    WimeaApplication.DailyReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Daily weather records��5      $	��800��6    $	��600��6/    N� 
Background
 �����$	��417��6R    � 	Resources 5      ��%    5      .��5      � $��0,0,0,10q�6   .+�5   
   � $��42��6   $	��Top=�6   .+�5      �� $��Station��6   $
��Left=�6&   $��	171,8,0,0q�6A   $	��Top=�6T   $��48��6l   �� 5      -   5         ��Name$ stationTxtCbx��5   E   $
��Left=�6   $��	224,8,0,0q�62   $	��Top=�6\   $	��107��6t    J� RenderTransformOrigin$ 0.302,-0.056&�6�   $��26��6�   �� 5      -   5         ��Name$ stationNumber��5   #   $
��Info��6   $
��Left=�6:   $��
605,10,0,0q�6U   $	��Top=�6i   $��43��6�   $ 2.081,0.728&�6�   $��26��6�   �� 5      -   5        $��Generate��5      $
��Left=�6(   $��	653,8,0,0q�6C   $	��Top=�6V   $��75��6n   $ -0.032,0.741&�6y   $��26��6�   6�   �� 5      $��Month��6   $
��Left=�6$   $��	336,9,0,0q�6?   $	��Top=�6R   $��26��6j   �� 5      $
��Year��6   $
��Left=�6#   $��	484,8,0,0q�6>   $	��Top=�6Q   $��26��6i   �� 5      -   5        $ monthTxtCbx��5   E   $
��Left=�6   $��	386,8,0,0q�62   $	��Top=�6Z   $��93��6r   $ 0.302,-0.056&�6}   $��26��6�   �� 5      -   5         ��Name$ 	yearTxtBx��5   1   $
��Left=�6   $��26��6D   $��	522,8,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $��83��6�   �� 5      $��Daily weather records��6   $��10,6,0,0q�64   $	��Top=�6F   $
��Bold"�6^   $��14(�6p   ���	#FF424242$
��Left=�6�   $	��156��6�   �� 5      -   5         ��Name$ 	btnExport��5   b   $��Delete selected��6   $��
745,11,0,0q�6N   $	��Top=�6v   $��21��6�   $
��Left=�6�   $	��106��6�   ��6/   �� *
AddCommand+��5      �� 5      .R�5      � 
������ .+�5      �� �� 6)   $�Export excel��6-   6D   �� 5      $��Uniform=�6%   $1��+/WimeaApplication;component/image/excel.png��67   $��Right=�6l   5      5      5!      5"      �� 5#   
   $	��533��6   $��0,47,0,0q�6$   $	��Top=�66   $��Visible=�6O   .��5$      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 	MetarGrid��5%      
   AutoGenerateColumns
 .     CanUserAddRows .     RowBackground
 �����   AlternatingRowBackground
 ��ح����	#FFC5C5C5$��1q�5&   H      SelectionMode$ Extended=�5'      $
��auto��6$   $	��Top=�62   $
��auto��6J      HorizontalGridLinesBrush �	#FFC5C5C5   VerticalGridLinesBrush �	#FFC5C5C5��5%      Z�  5(      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%T   '        �� 5)      "  6   .�5*      ��  � ��
 �����67   5,      5-         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Dates+  51      $ Max.temp��6)    6;   �� *Maxs+  52      $ Min.temp��6)    6=   �� *Mins+  53      $ Rainfall(mm)��6)    6A   �� *Actual+  54      $ Anemometer height��6)    6F   �� *
Anemometer+  55      $ Wind run��6)    6=   �� *Wind+  56      $
 Rain��6)    69   �� *
Rainfall+  57      $ Thunder��6)    6;   �� *	Thunder+  58      $	 Fog��6)    66   �� *Fog+  59      $
 Haze��6)    68   �� *Haze+  5:      $ 
Hail storm��6)    6>   �� *Storm+  5;      $ Earth Quake��6)    6@   �� *Quake+  5<      $ Rain duration��6)    6B   �� *
Duration+  5=      $ Sunshine(Hrs)��6)    6B   �� *
Sunshine+  5>      $ Radiation type��6)    6C   �� *Radiationtype+  5?      $ 	Radiation��6)    6<   �� *	Radiation+  5@      $ Evaporation type 1��6)    6G   �� *	Evaptype1+  5A      $ Evaporation��6)    6@   �� *Evap1+  5B      $ Evaporation type 2��6)    6G   �� *	Evaptype2+  5C      $ Evaporation 2��6)    6A   �� *Evap2+  5D      $
 User��6)    69   �� *Users+5H      5I      5J      5K      