   M S B A M L   `   `   `  ����  WimeaApplication%    WimeaApplication.SynopticReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  	MetarPage��5       N� 
Background
 �����$	��800��6'   $	��500��66   $��763.836��6F   .��5	      � .+�5
   
   �� $	��583��6   $��	0,39,20,0q�6$   $	��Top=�67   $��Visible=�6O   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ SynopticGrid��5         AutoGenerateColumns .     CanUserAddRows .     RowBackground
 �����   AlternatingRowBackground
 ��ح����	#FFC5C5C5$��1q�5   H      SelectionMode$ Extended=�5      $
��auto��6$   $	��Top=�62   $
��auto��6J      HorizontalGridLinesBrush �	#FFC5C5C5	   VerticalGridLinesBrush	 �	#FFC5C5C5��5   "   Z� 
 � 	Resources
 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%T   '        �� 5      "  6   .�5      ��  � ��
 �����67   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Time [GGG]��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Time+  5      $0 *Inclusion or omission of precipitation[ir]��6)    6^   �� *Ir+  5      $2 ,Type of station/present and past weather[ix]��6)    6a   �� *Ix+  5      $&  Height of lowest cloud cover[h] ��6)    6T   �� *H+  5      $ Horizontal visibility[VV]��6)    6M   �� *Vv+  5      $ Total cloud cover[N]��6)    6I   �� *N+  5      $ Wind speed(KT) [dd]��6)    6G   �� *Dd+  5      $ Wind direction [ff]��6)    6G   �� *Ff+  5      $ Air temperature[TTT]��6)    6I   �� *T+  5      $ Dew point temperature��6)    6J   �� *Td+  5       $ Pressure at station level��6)    6N   �� *Po+  5!      $/ )Group Indicator Standard isobaric surface��6)    6\   �� *Gisis+  5"      $0 *Geopotential of standard Isobaric surface ��6)    6^   �� *Hhh+  5#      $ Amount of precipitation��6)    6L   �� *Rr+  5$      $&  Duration period of precipitation��6)    6T   �� *Tr+  5%      $ Present weather��6)    6B   �� *	Present+  5&      $ Past weather��6)    6@   �� *Past+  5'      $ Amount of clouds(Cl)��6)    6H   �� *Nh+  5(      $ Clouds (Sc,St,Cu,Cb)��6)    6H   �� *Cl+  5)      $ Clouds (Ac,As,Ns)��6)    6F   �� *Cm+  5*      $ Clouds (C,Cc,Cs)��6)    6D   �� *Ch+  5+      $ Grass minimum temperature��6)    6N   �� *Tq+  5,      $. (Character and intensity of precipitation��6)    6]   �� *Ro+  5-      $' !Beginning or end of precipitation��6)    6U   �� *R1+  5.      $ Maximum temperature��6)    6H   �� *Tx+  5/      $ Minimum temperature��6)    6H   �� *Tm+  50      $ Amount of evaporation��6)    6J   �� *Ee+  51      $% Indicator of type of instrument��6)    6S   �� *E+  52      $ Duration of sunshine��6)    6H   �� *Sss+  53      $ Sign of pressure change��6)    6L   �� *	Pchange+  54      $! Pressure change in 24 hours��6)    6P   �� *P24+  55      $ Amount of precipitation��6)    6L   �� *Rr+  56      $&  Duration period of precipitation��6)    6T   �� *Tr1+  57      $* $Amount of individual cloud layer[Ns]��6)    6X   �� *Ns+  58      $ Genus of cloud[C]��6)    6F   �� *C+  59      $/ )Height of base cloud layer or mass [hshs]��6)    6]   �� *Hs+  5:      $* $Amount of individual cloud layer[Ns]��6)    6Y   �� *Ns1+  5;      $ Genus of cloud[C]��6)    6F   �� *C1+  5<      $/ )Height of base cloud layer or mass [hshs]��6)    6]   �� *Hs1+  5=      $* $Amount of individual cloud layer[Ns]��6)    6Y   �� *Ns2+  5>      $ Genus of cloud[C]��6)    6F   �� *C2+  5?      $/ )Height of base cloud layer or mass [hshs]��6)    6]   �� *Hs2+  5@      $ Supplementary information��6)    6M   �� *Supplementary+  5A      $ Wet bulb Temperature��6)    6H   �� *Wb+  5B      $ Relative Humidity(RH)%��6)    6J   �� *Rh+  5C      $ Vapour Pressure(VAP)��6)    6H   �� *Vap+  5D      $
 User��6)    68   �� *Users+  5E      $ submitted on:��6)    6A   �� *	Submitted+5K      5L      �� 5M   
   $��Station��6   $
��Left=�6"   $��	179,8,0,0q�6=   $	��Top=�6P   $��48��6h   �� 5N   
   -   5         ��Name$ stationTxtCbx��5N   A   $
��Left=�6   $��	232,8,0,0q�6.   $	��Top=�6X   $��99��6p    J� RenderTransformOrigin$ 0.302,-0.056&�6{   $��26��6�   �� 5O   
   $��
Select day��6   $
��Left=�6%   $��	335,8,0,0q�6@   $	��Top=�6S   $��26��6k   �� 5P   
   -   5         ��Name$ stationNumber��5P      $
��Info��6   $
��Left=�66   $��	749,8,0,0q�6Q   $	��Top=�6d   $��43��6|   $ 2.081,0.728&�6�   $��26��6�   �� 5Q   
   -   5        $��Generate��5Q      $
��Left=�6$   $��	792,8,0,0q�6?   $	��Top=�6R   $��75��6j   $ -0.032,0.741&�6u   $��26��6�   6�   �� 5R   
   $��Month��6   $
��Left=�6    $��	473,8,0,0q�6;   $	��Top=�6N   $��26��6f   �� 5S   
   $
��Year��6   $
��Left=�6   $��	623,8,0,0q�6:   $	��Top=�6M   $��26��6e   �� 5T   
   -   5        $ 	dayTxtCbx��5T   A   $
��Left=�6   $��	404,8,0,0q�6.   $	��Top=�6T   $��64��6l   $ 0.302,-0.056&�6w   $��26��6�   �� 5U   
   -   5        $ monthTxtCbx��5U   A   $
��Left=�6   $��	523,8,0,0q�6.   $	��Top=�6V   $��95��6n   $ 0.302,-0.056&�6y   $��26��6�   �� 5V   
   -   5         ��Name$ 	yearTxtBx��5V   -   $
��Left=�6   $��26��6@   $��	661,8,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $��83��6�   �� 5W   
   $��AAXX SYNOPTIC REGISTER ��6   $��10,8,0,0q�62   $	��Top=�6D   $
��Bold"�6\   $��12(�6n   ���	#FF424242$
��Left=�6�   $	��170��6�   $��26��6�   �� 5X   
   -   5         ��Name$ 	btnExport��5X   ]   $��Delete selected��6   $��	891,8,0,0q�6J   $	��Top=�6q   $��21��6�   $
��Left=�6�   $	��106��6�   ��6+   �� *
AddCommand+��5Y      �� 5Z      .R�5[      � 
������ .+�5\      �� �� 6%   $�Export excel��6)   6@   �� 5]      $��Uniform=�6!   $1��+/WimeaApplication;component/image/excel.png��63   $��Right=�6h   5^      5_      5a      5d      5e      