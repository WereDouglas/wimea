   M S B A M L   `   `   `  ����  WimeaApplication$    WimeaApplication.SynopticsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  	MetarPage��5       N� 
Background
 �����$	��800��6'   $	��500��66   $��763.836��6F   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��73* �6   �� 5      $
��691* �6   .+�5   
   �� $��Station��6   $
��Left=�6"   $��
329,-2,0,0q�6=   $	��Top=�6Q   $��48��6i   �� 5   
   -   5        $��stationTxtCbx��5   A   $
��Left=�6   $��	400,2,0,0q�6.   $	��Top=�6V   $	��123��6n    J� RenderTransformOrigin$ 0.302,-0.056&�6z   �� 5   
   $��Select date��6   $
��Left=�6&   $��87,2,0,0q�6A   $	��Top=�6S   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6   $��	160,5,0,0q�60   $	��Top=�6C   $	��160��6[   �� 5   
   -   5        $��stationNumber��5       $��Label��6   $
��Left=�65   $��	528,2,0,0q�6P   $	��Top=�6c   $ 
2.745,0.44&�6{   $��90��6�   �� 5   
   $	��557��6   $��	0,65,20,0q�6$   $	��Top=�67   $��Visible=�6O   $��2��6w   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ SynopticGrid��5         AutoGenerateColumns .     CanUserAddRows .     RowBackground
 �����   AlternatingRowBackground
 ��ح����	#FFC5C5C5$��1q�5   H   	   SelectionMode$	 Extended=�5      $
��auto��6$   $	��Top=�62   $
��auto��6J   
   HorizontalGridLinesBrush
 �	#FFC5C5C5   VerticalGridLinesBrush �	#FFC5C5C5��5   "   Z�  � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%T   '        �� 5      "  6   .�5      ��  � ��
 �����67   5      5         Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6-   -   5        cbSelectRow��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   N   �� *Id+0  *System.Windows.Controls.DataGridTextColumn  5       $ 
Time [GGG]��6)    6=   �� *Time+  5!      $0 *Inclusion or omission of precipitation[ir]��6)    6^   �� *Ir+  5"      $2 ,Type of station/present and past weather[ix]��6)    6a   �� *Ix+  5#      $&  Height of lowest cloud cover[h] ��6)    6T   �� *H+  5$      $ Horizontal visibility[VV]��6)    6M   �� *Vv+  5%      $ Total cloud cover[N]��6)    6I   �� *N+  5&      $ Wind speed(KT) [dd]��6)    6G   �� *Dd+  5'      $ Wind direction [ff]��6)    6G   �� *Ff+  5(      $ Air temperature[TTT]��6)    6I   �� *T+  5)      $ Dew point temperature��6)    6J   �� *Td+  5*      $ Pressure at station level��6)    6N   �� *Po+  5+      $/ )Group Indicator Standard isobaric surface��6)    6\   �� *Gisis+  5,      $0 *Geopotential of standard Isobaric surface ��6)    6^   �� *Hhh+  5-      $ Amount of precipitation��6)    6L   �� *Rr+  5.      $&  Duration period of precipitation��6)    6T   �� *Tr+  5/      $ Present weather��6)    6B   �� *	Present+  50      $ Past weather��6)    6@   �� *Past+  51      $ Amount of clouds(Cl)��6)    6H   �� *Nh+  52      $ Clouds (Sc,St,Cu,Cb)��6)    6H   �� *Cl+  53      $ Clouds (Ac,As,Ns)��6)    6F   �� *Cm+  54      $ Clouds (C,Cc,Cs)��6)    6D   �� *Ch+  55      $ Grass minimum temperature��6)    6N   �� *Tq+  56      $. (Character and intensity of precipitation��6)    6]   �� *Ro+  57      $' !Beginning or end of precipitation��6)    6U   �� *R1+  58      $ Maximum temperature��6)    6H   �� *Tx+  59      $ Minimum temperature��6)    6H   �� *Tm+  5:      $ Amount of evaporation��6)    6J   �� *Ee+  5;      $% Indicator of type of instrument��6)    6S   �� *E+  5<      $ Duration of sunshine��6)    6H   �� *Sss+  5=      $ Sign of pressure change��6)    6L   �� *	Pchange+  5>      $! Pressure change in 24 hours��6)    6P   �� *P24+  5?      $ Amount of precipitation��6)    6L   �� *Rr+  5@      $&  Duration period of precipitation��6)    6T   �� *Tr1+  5A      $* $Amount of individual cloud layer[Ns]��6)    6X   �� *Ns+  5B      $ Genus of cloud[C]��6)    6F   �� *C+  5C      $/ )Height of base cloud layer or mass [hshs]��6)    6]   �� *Hs+  5D      $* $Amount of individual cloud layer[Ns]��6)    6Y   �� *Ns1+  5E      $ Genus of cloud[C]��6)    6F   �� *C1+  5F      $/ )Height of base cloud layer or mass [hshs]��6)    6]   �� *Hs1+  5G      $* $Amount of individual cloud layer[Ns]��6)    6Y   �� *Ns2+  5H      $ Genus of cloud[C]��6)    6F   �� *C2+  5I      $/ )Height of base cloud layer or mass [hshs]��6)    6]   �� *Hs2+  5J      $ Supplementary information��6)    6M   �� *Supplementary+  5K      $ Wet bulb Temperature��6)    6H   �� *Wb+  5L      $ Relative Humidity(RH)%��6)    6J   �� *Rh+  5M      $ Vapour Pressure(VAP)��6)    6H   �� *Vap+4  .System.Windows.Controls.DataGridTemplateColumn  5P         CellTemplate 5Q      �� 5R      .R�5S   "   � .+�5T   &   �� -   5        $��Delete��5T   -   $��3q�6>   $��50��6J   6U   5U   #   5V      5X      5[      5\      �� 5]   
   -   5         ��Name$ btnAdd_Copy��5]   y   $��Delete selected��6   $
��Left=�6+   $��
182,36,0,0q�6e   $	��Top=�6�   $	��138��6�   $��21��6�   ��6F   �� *
AddCommand+��5^      �� 5_      .R�5`      � 
������ .+�5a      �� �� 6%   $�Delete selected��6)   6C   �� 5b      $��Uniform=�6!   $3��-/WimeaApplication;component/image/Deletes.png��63   $��Right=�6j   5c      5d      5f      �� 5g   
   -   5         ��Name$ chkSelectAll��5g   &   $��	87,38,0,0q�6   $
��Left=�6W   $��95��6r   $��19��6}   $	��Top=�6�   $��
Select all��6�   $ 
0.93,0.311&�6�   �� 5h   
   $��
Select day��6   $
��Left=�6%   $��
329,38,0,0q�6@   $	��Top=�6T   $��26��6l   �� 5i   
   -   5         ��Name$ stationNumber_Copy��5i      $
��Info��6   $
��Left=�6;   $��
749,33,0,0q�6V   $	��Top=�6j   $��43��6�   $ 2.081,0.728&�6�   $��26��6�   �� 5j   
   -	   5        $��Generate��5j      $
��Left=�6$   $��
792,33,0,0q�6?   $	��Top=�6S   $��75��6k   $ -0.032,0.741&�6v   $��26��6�   6�   �� 5k   
   $��Month��6   $
��Left=�6    $��
473,33,0,0q�6;   $	��Top=�6O   $��26��6g   �� 5l   
   $
��Year��6   $
��Left=�6   $��
623,33,0,0q�6:   $	��Top=�6N   $��26��6f   �� 5m   
   -
   5         ��Name$ 	dayTxtCbx��5m   B   $
��Left=�6   $��
400,36,0,0q�6.   $	��Top=�6U   $��64��6m   $ 0.302,-0.056&�6x   $��26��6�   �� 5n   
   -   5        $ monthTxtCbx��5n   B   $
��Left=�6   $��
523,33,0,0q�6.   $	��Top=�6W   $��95��6o   $ 0.302,-0.056&�6z   $��26��6�   �� 5o   
   -   5         ��Name$ 	yearTxtBx��5o   -   $
��Left=�6   $��26��6@   $��
661,33,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��83��6�   �� 5p   
   -   5        $ 	btnExport��5p   ^   $��Delete selected��6   $��
925,38,0,0q�6J   $	��Top=�6r   $��21��6�   $
��Left=�6�   $	��106��6�   ��6+   �� *
AddCommand+��5q      �� 5r      .R�5s      � 
������ .+�5t      �� �� 6%   $�Export excel��6)   6@   �� 5u      $��Uniform=�6!   $1��+/WimeaApplication;component/image/excel.png��63   $��Right=�6h   5v      5w      5y      5|      5}      