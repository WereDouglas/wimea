   M S B A M L   `   `   `  ����  WimeaApplication"    WimeaApplication.MetarReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  	MetarPage��5       N� 
Background
 �����$	��800��6'   $	��500��66   $��532.836��6F   .��5	      � .+�5
   
   �� $��Station��6   $
��Left=�6"   $��
106,10,0,0q�6=   $	��Top=�6Q   $��48��6i   �� 5   
   -   5        $��stationTxtCbx��5   B   $
��Left=�6   $��
159,10,0,0q�6.   $	��Top=�6W   $��82��6o    J� RenderTransformOrigin$ 0.302,-0.056&�6z   $��26��6�   �� 5   
   $��
Select day��6   $
��Left=�6%   $��
246,10,0,0q�6@   $	��Top=�6T   $��26��6l   �� 5   
   -   5        $��stationNumber��5      $
��Info��6   $
��Left=�64   $��
648,10,0,0q�6O   $	��Top=�6c   $��35��6{   $ 2.081,0.728&�6�   $��26��6�   �� 5   
   $	��474��6   $��0,49,0,0q�6$   $	��Top=�66   $��Visible=�6N   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	MetarGrid��5         AutoGenerateColumns .     CanUserAddRows .     RowBackground
 �����   AlternatingRowBackground
 ��ح����	#FFC5C5C5$��1q�5   H      SelectionMode$ Extended=�5      $
��auto��6$   $	��Top=�62   $
��auto��6J   	   HorizontalGridLinesBrush	 �	#FFC5C5C5
   VerticalGridLinesBrush
 �	#FFC5C5C5��5      Z�  � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%T   '        �� 5      "  6   .�5      ��  � ��
 �����67   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      
Visibility$ Hidden=�6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Id+6K     5      $ METAR/SPECI��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6>    6J   �� *Types+  5      $
 CCCC��6)   $ 50 67    6C   �� *	Station+  5      $ YYGGggz��6)   $ 80 6:    6F   �� *	Datetimes+  5      $ Dddff/fm/fm��6)   $	 100 6>    6K   �� *	Direction+  5      $ WW or CAVOK��6)   $	 100 6>    6K   �� *
Visibility+  5       $
 W1W1��6)   $ 80 67    6C   �� *	Weather+  5!      $ N1CCh1h1NnCChhhNhCChhh��6)   $	 220 6I    6V   �� *Cloud+  5"      $ Air temperature��6)   $	 100 6B    6O   �� *Temperature+  5#      $ RH(%)��6)   $ 80 68    6D   �� *
Humidity+  5$      $ DP��6)   $ 60 65    6A   �� *Dew+  5%      $ WB��6)   $ 60 65    6A   �� *Wet+  5&      $ TT/TdTd��6)   $ 70 6:    6F   �� *Temperature+  5'      $ QNH(hpa)��6)   $ 70 6;    6G   �� *
Stationhpa+  5(      $ QNH(in)��6)   $ 70 6:    6F   �� *
Stationhpa+  5)      $ QFE(hpa)��6)   $ 70 6;    6G   �� *Seahpa+  5*      $ QFE(in)��6)   $ 70 6:    6F   �� *Seahpa+  5+      $ RE W1W1��6)   $ 70 6:    6F   �� *Recent+  5,      $
 Date��6)   $ 70 67    6C   �� *Days+5/      50      �� 51   
   -   5        $��Generate��51      $
��Left=�6$   $��
688,10,0,0q�6?   $	��Top=�6S   $��75��6k   $ -0.032,0.741&�6v   $��26��6�   6�   �� 52   
   $��Month��6   $
��Left=�6    $��
375,10,0,0q�6;   $	��Top=�6O   $��26��6g   �� 53   
   $
��Year��6   $
��Left=�6   $��
522,10,0,0q�6:   $	��Top=�6N   $��26��6f   �� 54   
   -   5         ��Name$ 	dayTxtCbx��54   B   $
��Left=�6   $��
315,10,0,0q�6.   $	��Top=�6U   $��55��6m   $ 0.302,-0.056&�6x   $��26��6�   �� 55   
   -   5        $ monthTxtCbx��55   B   $
��Left=�6   $��
425,10,0,0q�6.   $	��Top=�6W   $��92��6o   $ 0.302,-0.056&�6z   $��26��6�   �� 56   
   -   5        $��	yearTxtBx��56   -   $
��Left=�6   $��26��6>   $��
560,10,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $��83��6�   �� 57   
   $��
Metar Book��6   $��	10,10,0,0q�6%   $	��Top=�68   $
��Bold"�6P   $��14(�6b   ���	#FF424242$
��Left=�6�   $��92��6�   �� 58   
   -   5         ��Name$ 	btnExport��58   ^   $��Delete selected��6   $��
793,15,0,0q�6J   $	��Top=�6r   $��21��6�   $
��Left=�6�   $	��106��6�   ��6+   �� *
AddCommand+��59      �� 5:      .R�5;      � 
������ .+�5<      �� �� 6%   $�Export excel��6)   6@   �� 5=      $��Uniform=�6!   $1��+/WimeaApplication;component/image/excel.png��63   $��Right=�6h   5>      5?      5A      5D      5E      