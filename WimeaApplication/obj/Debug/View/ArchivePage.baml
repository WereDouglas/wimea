   M S B A M L   `   `   `  ����K  GWimeaApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WimeaApplication.ViewModelWimeaApplication.ViewModel  5      "    WimeaApplication.ArchivePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?
viewModels(clr-namespace:WimeaApplication.ViewModel     5        N� Title$  Archive page��5       N� 
Background
 �����$	��800��6*   $	��600��69   .��5
      � .+�5   
   � $
��Left=�6   $	��448��6*   $��9,7,0,0q�67   $	��Top=�6H   $	��195��6`   .+�5      �� $��Station��6   $
��Left=�6&   $��	10,65,0,0q�6A   $	��Top=�6T   $��24��6l    J� RenderTransformOrigin$ 0.153,1.592&�6x   �� 5      $
��Left=�6   $��20��61   $��
10,321,0,0q�6=    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��175��6�   $ -1.893,1.016&�6�   �� 5      $
��Left=�6   $��	10,94,0,0q�62   $	��Top=�6E   $	��175��6]   $��24��6i   �� 5      $
��Left=�6   $��20��61   $��
10,370,0,0q�6=   $
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��175��6�   $ -1.893,1.016&�6�   �� 5      $
��Name��6   $
��Left=�6#   $��
10,292,0,0q�6>   $	��Top=�6R   $��24��6j   �� 5      $
��Left=�6   $��
10,152,0,0q�62   $	��Top=�6F   $	��175��6^   $��24��6j   �� 5      $��Report/form type��6   $
��Left=�6/   $��
10,123,0,0q�6J   $	��Top=�6^   $��24��6v   $ 0.627,2.294&�6�   �� 5      $��
Start date��6   $
��Left=�6)   $��
10,181,0,0q�6D   $	��Top=�6X   $��24��6p   �� 5      $��End date��6   $
��Left=�6'   $��
10,234,0,0q�6B   $	��Top=�6V   $��24��6n   (  "System.Windows.Controls.DatePicker  5      $
��Left=�6   $��
10,210,0,0q�64   $	��Top=�6H   $	��175��6`     5      $
��Left=�6   $��
10,263,0,0q�64   $	��Top=�6H   $	��175��6`   �� 5      $��Description��6   $
��Left=�6*   $��
10,341,0,0q�6E   $	��Top=�6Y   $��24��6q   �� 5      $
��Scan��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   $	��175��6j   $��31��6v   ��6�   �� *ScanCommand+�� 5      $
��Save��6   $
��Left=�6$   $��
10,410,0,0q�6?   $	��Top=�6S   $	��181��6k   $��31��6w   5      �� 5   
   -   5         ��Name$ ScannerImage��5      $��Uniform=�5      $��	0,12,10,0q�5   0   $��Right=�6C   $	��586��6_   $	��443��6k   $	��Top=�6x   ��6   �� *ScannedImage+6x   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ dataGridEvaluation��5!   
      AutoGenerateColumns .  $��	0,460,0,0q�5    1      CanUserAddRows .     RowBackground
 �����	   AlternatingRowBackground
	 ��ح����	#FFC5C5C5$��1q�5"   G   "
   VerticalScrollBarVisibility$
 Visible=�5#   
      SelectionMode$ Extended=�60   $	��130��6I   $	��Top=�6V      HorizontalGridLinesBrush �	#FFC5C5C5   VerticalGridLinesBrush �	#FFC5C5C5��5!   '   Z�  � 	Resources 5$      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%T   '        �� 5%      "  6   .�5&      ��  � ��
 �����63   5(      5)         Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
Visibility$ Hidden=�6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *Id+6G     5,      $
 Form��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 63    6@   �� *Company_name+  5-      $
 Name��6%   $ 50 63    6?   �� *Application_name+  5.      $ station��6%   $ 80 66    6B   �� *Budget+ �� StringFormat$ {0:n0}��  5/      $ Start period��6%   $	 100 6;    6H   �� *
Hardware+$ {0:n0}��  50      $ 
End period��6%   $	 100 69    6F   �� *
Software+$ {0:n0}��  51      $ submitted on��6%   $ 80 6;    6G   �� *	Candidate+  52      $
 File��6%   $ 60 63    6?   �� *
Adoption+4  .System.Windows.Controls.DataGridTemplateColumn  55         CellTemplate 56      �� 57      .R�58      � .+�59   "   �� -   5        $��Delete��59   )   $��3q�6:   $��50��6F   ��6Q   �� *DataContext.DeleteCommand+ �� RelativeSource ��  �� AncestorType"  ��5:      �� 6-   5;      5<      5>      5@      5A      5B      