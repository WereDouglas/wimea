   M S B A M L   `   `   `  ����  WimeaApplication#    WimeaApplication.View.AddUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � Title$ Add user��5   	   $��373.09��6   $��461.677��6*    � Icon$3 -/WimeaApplication;component/image/logo.fw.png��6;    � WindowStyle$
 None=�6p   .��5	      �  J� IsHitTestVisible . $��0,0,2,0q�6#   .+�5
   
   �� $��E-mail��6   $
��Left=�6!   $	��Top=�6<   $��
115,53,0,0q�6T   �� 5   
   -   5         ��Name$ lblQuestion��5      $��68,9,432,391q�6%   5      � 5   
   $��2��6   $��2��6!   $��Right=�65   $��0,15,0,0q�6Q   �� 5   
   -   5         ��Name$ btnDialogOk��5   "    �� 	IsDefault . $��60��6Q   $��172,230,0,0q�6_   $
��Save��6t   $��30��6�   $	��Top=�6�   $
��Left=�6�   $��83��6�   �� 5   
   	 �� IsCancel	 . $��60��6!   $��_Cancel��6/   $��262,231,0,0q�6A   $��29��6V   $	��Top=�6b   $
��Left=�6z   $��76��6�   �� 5   
   -   5        
 ��Name$
 	nameTxtBx��5   9   $
��Left=�6   $��23��6-   $��
174,79,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6�   $	��124��6�    J� RenderTransformOrigin$ -1.893,1.016&�6�   ��6t   �� *CurrentUser.Name+6�   �� 5   
   $
��Name��6   $
��Left=�6   $��
116,79,0,0q�6:   $	��Top=�6N   $ 1.214,0.731&�6f   �� 5   
   -   5        $
 
emailTxtBx��5   -   $
��Left=�6   $��23��6A   $��
174,48,0,0q�6M   $
 Wrap=�6a   $	��Top=�6�   $	��124��6�   $ -1.893,1.016&�6�   ��6u   �� *CurrentUser.Email+6�   �� 5   
   $��Station��6   $
��Left=�6"   $��119,141,0,0q�6=   $	��Top=�6R   $��48��6j   �� 5   
   -   5         ��Name$ stationTxtCbx��5   /   $
��Left=�6    �� SelectedValuePath$ Content��6u   $��172,145,0,0q�6�   $	��Top=�6�   $	��126��6�   $ 0.302,-0.056&�6�    �� SelectedValue 6G   �� *CurrentUser.Station+��6�   �� *
Stations+5      �� 5   
   -   5        $ 	roleTxtBx��5   2   $ Content��6q   $
��Left=�6�   $��172,180,0,0q�6�   $	��Top=�6�   $	��126��6�   $ 0.302,-0.056&�6�   ��6   �� *Roles+ 6F   �� *CurrentUser.Role+.@�5      �� $	��O/C��6   �� 5      $��Observer��6   5      �� 5   
   $
��Role��6   $
��Left=�6   $��125,176,0,0q�6:   $	��Top=�6O   �� 5   
   -   5        $
 contactTxtBx��5   -   $
��Left=�6   $��23��6C   $��174,112,0,0q�6O   $
 Wrap=�6d   $	��Top=�6�   $	��124��6�   $ -1.893,1.016&�6�   ��6x   �� *CurrentUser.Contact+6�   �� 5   
   $��Contact��6   $
��Left=�6"   $��116,110,0,0q�6=   $	��Top=�6R   5       5"      