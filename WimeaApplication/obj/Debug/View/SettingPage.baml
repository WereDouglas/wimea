   M S B A M L   `   `   `  ����  WimeaApplication'    !WimeaApplication.View.SettingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��800��5      $	��600��6+     N� Title$  RainCardPage��5      .��5	      � $��0,0,0,10q�6   .+�5
   
   � $��68��6   $	��Top=�6   ���	#FFEEEEF2.+�5      �� $��Station��6   $
��Left=�6&   $��19,0,0,0q�6A   $	��Top=�6S   $��56��6k   �� 5      -   5        $��stationTxtCbx��5      $
��Left=�6,   $��86,5,0,0q�6G   $	��Top=�6Y   $	��120��6q   $��26��6�   �� 5      $2��,Synchronise remote data for selected station��6   $
��Left=�6K   $��	263,7,0,0q�6f   $	��Top=�6y   $	��274��6�   �� 5      -   5         ��Name$ metarChk��5   (   $��metars��6   $
��Left=�6:   $��
313,41,0,0q�6U   $	��Top=�6i   $��26��6�   �� 5      -   5        $ synopticChk��5   *   $��synoptic��6   $
��Left=�6?   $��
390,42,0,0q�6Z   $	��Top=�6n   $��26��6�   $��73��6�   �� 5      -   5        $ rainChk��5   &   $
��rain��6   $
��Left=�67   $��
485,42,0,0q�6R   $	��Top=�6f   $��26��6~    J� RenderTransformOrigin$ 0.472,-0.183&�6�   �� 5      -   5        $ dailyChk��5   /   $��daily records��6   $
��Left=�6A   $��
209,41,0,0q�6\   $	��Top=�6p   $��26��6�   �� 5      -   5        $�� ��5      $
��Left=�6    $��
641,40,0,0q�6;   $	��108��6O   $��18��6q   $	��Top=�6}   $ -1.052,0.188&�6�   ��5      �� 5      .R�5      � 
������ .+�5      �� 
���   ��� 6<   $�sync contents��6@   6X   �� 5      $��Uniform=�6%   $8��2/WimeaApplication;component/image/synchronizes.png��67   $��Right=�6s   5      5      5      �� 5      -   5        $ 
stationChk��5   *   $��stations��6   $
��Left=�6>   $��
544,42,0,0q�6Y   $	��Top=�6m   $��26��6�   $ 0.472,-0.183&�6�   �� 5      -   5         ��Name$ btnAdd_Copy��5   |   $��Delete selected��6   $
��Left=�6/   $��	10,42,0,0q�6i   $	��Top=�6�   $	��105��6�   $��21��6�   ��6J   �� *
AddCommand+��5      �� 5      .R�5       � 
������ .+�5!      �� �� 6)   $�Delete selected��6-   6G   �� 5"      $��Uniform=�6%   $3��-/WimeaApplication;component/image/Deletes.png��67   $��Right=�6n   5#      5$      5&      �� 5'      -	   5        $��internet��5'      $�� ��6   $
��Left=�6/   $��	544,7,0,0q�6J   $	��Top=�6]   $	��173��6u   5(      �� 5)   
   -
   5        $��SyncGrid��5)      $��	-1,73,1,0q�6#    �� SelectedItem 69   �� *CurrentStation+ J� Effect 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+         Color$ 	#FF007ACC��6#      
BlurRadius$ 8Q�65    �� View 5-      �� 5.      -   5        grdTest��.P�5/      �� 	 �� CellTemplate	 50      �� 51      .R�52   "   �� $ cbSelectRow��6,   
 d� 	IsChecked
 6A   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� Path$ 
IsSelected�53      .��55      �� -   5        $ chkSelectAll��55   .   $��0q�6#   6D   57      �� 5:      $��Content name��6%    �� DisplayMemberBinding 6;   �� *	Objects+�� 5;      $��Last updated��6%    6;   �� *Dates+�� 5<      $
��User��6%    63   �� *Users+�� 5>      	 5?      �� 5@      .R�5A   "   �� -   5        $��36��5A   *   $��60��66   $��X��6A   ��5B   &   �� 5C   *   .R�5D   .   � 
������ .+�5E   2   �� �� 6=   $�Delete��6A   6R   �� 5F   2   $��Right=�69   $
��None=�6U   $3��-/WimeaApplication;component/image/Deletes.png��6d   5G   /   5H   +   5J   #   5K      5M      5O      5Q      5S      5T      