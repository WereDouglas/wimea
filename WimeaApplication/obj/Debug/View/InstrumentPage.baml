   M S B A M L   `   `   `  ����  WimeaApplication%    WimeaApplication.InstrumentPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Daily weather records��5      $	��800��6    $	��600��6/    N� 
Background
 �����$	��417��6R    � 	Resources 5      ��%    5      .��5      � $��0,0,0,10q�6   .+�5   
   � $	��590��6   $	��Top=�6   $
��Left=�64   $	��155��6O   $��2,0,0,0q�6[   .+�5      �� $	��No.��6   $
��Left=�6"   $��	26,79,0,0q�6=   $	��Top=�6P    J� RenderTransformOrigin$ 1.251,0.334&�6h   �� 5      $��Station��6   $
��Left=�6&   $��	26,20,0,0q�6A   $	��Top=�6T   �� 5      $��Element��6   $
��Left=�6&   $��
26,159,0,0q�6A   $	��Top=�6U   $ 0.515,-3.228&�6m   �� 5      $��registration��6   $
��Left=�6+   $��
26,207,0,0q�6F   $	��Top=�6Z   $��77��6r   �� 5      $��Description��6   $
��Left=�6*   $��
26,427,0,0q�6E   $	��Top=�6Y   �� 5      $
��Name��6   $
��Left=�6#   $��
26,105,0,0q�6>   $	��Top=�6R   �� 5      $��Expire��6   $
��Left=�6%   $��
26,262,0,0q�6@   $	��Top=�6T   $ 0.409,-2.475&�6l   �� 5      $
��Code��6   $
��Left=�6#   $��
26,322,0,0q�6>   $	��Top=�6R   $��44��6j   $ 1.011,0.596&�6u   �� 5      $��Manufacturer��6   $
��Left=�6+   $��
26,373,0,0q�6F   $	��Top=�6Z   $ 0.692,0.351&�6r   $��77��6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��
dateExpire��5      $
��Left=�6+   $��
26,293,0,0q�6F   $	��Top=�6Z   $	��124��6r   �� 5      -   5        $
��name��5   =   $
��Left=�6   $��23��61   $��
26,136,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��124��6�   $ 
-0.602,0.5&�6�   �� 5      -   5        $��description��5   1   $
��Left=�6   $��23��6D   $��
26,458,0,0q�6P   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��124��6�   �� 5      -   5        $��Submit��5      $
��Left=�6&   $��
26,504,0,0q�6A   $	��120��6U   $��26��6v   $	��Top=�6�   �� 5      -   5        $��manufacturer��5   1   $
��Left=�6   $��23��6E   $��
26,399,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��124��6�   �� 5      -   5        $
��code��5   1   $
��Left=�6   $��23��6=   $��
26,345,0,0q�6I   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��124��6�   �� 5      -   5        $��element��5   2   $
��Left=�6   $��
26,185,0,0q�6A   $	��Top=�6U   $	��124��6m   �� 5      -   5         ��Name$ stationTxtCbx��5   1   $
��Left=�6   $��23��6H   $��	26,51,0,0q�6T   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��124��6�     5       -	   5          Name$ datesRegister��5       $
��Left=�60   $��
26,233,0,0q�6K   $	��Top=�6_   $	��124��6w   5!      �� 5"   
   $��170,53,10,10q�6   $��Visible=�6.   .��5#      &   System.Windows.Controls.DataGrid  -
   5          Name$ 	MetarGrid��5$         AutoGenerateColumns .  	   CanUserAddRows	 .  
   RowBackground

 �����   AlternatingRowBackground
 ��ح����	#FFC5C5C5$��1q�5%   H      SelectionMode$ Extended=�5&      $
��auto��6$   $	��Top=�62   $
��auto��6J      HorizontalGridLinesBrush �	#FFC5C5C5   VerticalGridLinesBrush �	#FFC5C5C5��5$      Z�  5'      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%T   '        �� 5(      "  6   .�5)      ��  � ��
 �����67   5+      5,         Columns 5-      4  .System.Windows.Controls.DataGridCheckBoxColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6-   -   5        cbSelectRow��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5.   N   �� *Id+0  *System.Windows.Controls.DataGridTextColumn  5/      $
 Name��6)    67   �� *Name+  50      $ Station��6)    6:   �� *	Station+  51      $ Element��6)    6<   �� *	Element+  52      $ Registration date��6)    6F   �� *DateRegister+  53      $ Expiry date��6)    6@   �� *
DateExpire+  54      $
 Code��6)    69   �� *Code+  55      $ Manufacturer��6)    6A   �� *Manufacturer+  56      $ Description��6)    6?   �� *Description+  57      $ 	Submitted��6)    6<   �� *	Submitted+4  .System.Windows.Controls.DataGridTemplateColumn  59         CellTemplate 5:      �� 5;      .R�5<   "   � .+�5=   &   �� -   5        $��Delete��5=   -   $��3q�6>   $��50��6J   6U   5>   #   5?      5A      5C      5D      �� 5E   
   -   5         ��Name$ chkSelectAll��5E   '   $��
231,32,0,0q�6   $��Select all ��6X   $��18��6n   $	��Top=�6z   $
��Left=�6�   $��76��6�   �� 5F   
   -   5         ��Name$ btnAdd_Copy��5F   ^   $��Delete selected��6   $��
312,32,0,0q�6J   $	��Top=�6t   $��21��6�   $
��Left=�6�   $	��106��6�   ��6+   �� *
AddCommand+��5G      �� 5H      .R�5I      � 
������ .+�5J      �� �� 6%   $�Delete selected��6)   6C   �� 5K      $��Uniform=�6!   $3��-/WimeaApplication;component/image/Deletes.png��63   $��Right=�6j   5L      5M      5O      �� 5P   
   -   5         ��Name$ 
tbProgress��5P       $
��Sync��6   $
��Left=�64   $��	231,0,0,0q�6O   $	��Top=�6b   $	��227��6z   $��27��6�   ���	#FF00B4FF6�   �� 5Q   
   -   5        $ internet��5Q      $�� ��6   $
��Left=�6-   $��	463,1,0,0q�6H   $	��Top=�6[   $	��327��6s   5R      5S      