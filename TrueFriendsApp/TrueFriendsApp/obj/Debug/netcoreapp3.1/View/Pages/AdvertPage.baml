   M S B A M L   `   `   `  ����  TrueFriendsApp$    TrueFriendsApp.View.AdvertPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      $	��620��5      $
��1200��6   .��5	      � 
�������.+�5
   
   �� $��10q�6     �� Orientation$  Vertical=�6!   .+�5      ]� $��40��6   $	��Top=�6$   .+�5      �� $  
Horizontal=�6   $
��Left=�66   .+�5      �� -   5         ��Name$ ButtonBackToPrevPage��5      $��70��6d   $��35��6o   $��Center=�6�   $
��Left=�6�    � Cursor$
 Hand��6�   ��6;   �� *buttonBackToPrevPage+��6{   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�62   
���   �$��30��6V   $��25��6a   6o   5      5      �� 5      $  
Horizontal=�6   $��Right=�66   .+�5      �� $��70��6r   $��35��6}   $��Center=�6�   $��Center=�6�   $
 Hand��6�   ��6   �� *addToFavorite+y�6?   �� *AddFavoriteButtonVisibility+��6�   Z� ��6�   Z� .��5        $ Favorite=�62   
���  ��$��30��6S   $��25��6^   6l   5      �� 5      -   5        $ ButtonEditAdvert��5      $��70��6�   $��35��6�   $��Center=�6�   $��Right=�6�   $
 Hand��6	  ��67   �� *buttonEditAdvert+y�6\   �� *EditAdvertButtonVisibility+��6�   Z� ��6�   Z� .��5        $
 Edit=�62   
���   �$��30��6Q   $��25��6\   6j   5      �� 5      -   5        $ ButtonDeleteAdvert��5      $��70��6�   $��35��6�   $��Center=�6�   $��Right=�6�   ��69   �� *buttonDeleteAdvert+y�6`   �� *DeleteAdvertButtonVisibility+��6�   Z� ��6�   Z� .��5        $ Delete=�62   
���   �$��30��6S   $��25��6^   6l   5      5      5      �� 5      $  
Horizontal=�6   $��60��62   $	��Top=�6>   $
��Left=�6V   .+�5      �� $��
0 10 80 10q�6   $  
Horizontal=�61   .+�5      �� -   5         ��Name$ AdNameLabel��5         m_AdvertPage_Name#���   61   $��20(�6_   $	��180��6m   $��40��6y   6�   �� 5       -   5         ��Name$ AdNameTextBox��5    Y    �� 
IsReadOnly$
 True��64   $��	10 0 20 0q�6F   
���   �$	��300��6�   $��40��6�   $��20(�6�   $ IBeam��6�   ��6   �� *Name+6�   5!      �� 5"      $��
0 10 80 10q�6   $  
Horizontal=�61   .+�5#      �� -   5        $ AdCategoryLabel��5#        m_AdvertPage_KindOfAnimal#���  65   $��20(�6k   $	��180��6y   $��40��6�   6�   �� 5$      -   5        $ AdCategoryTextBox��5$   t   
���   �$
 True��6O   $��	10 0 20 0q�6a   $	��300��6�   $��40��6�   $	��Top=�6�   $��20(�6�   $ IBeam��6�   ��6   �� *KindOfAnimal+6�   5%      5&      �� 5'      $  
Horizontal=�6   $��60��62   $	��Top=�6>   $
��Left=�6V   .+�5(      �� $��
0 10 80 10q�6   $  
Horizontal=�61   .+�5)      �� -   5        $ AdRaitingLabel��5)        m_AdvertPage_AnimalWeight#���  64   $��20(�6j   $	��180��6x   $��40��6�   6�   �� 5*      -	   5        $ AdRaitingTextBox��5*   a   $
 True��6<   $��	10 0 20 0q�6N   
���   �$	��300��6�   $��40��6�   $��20(�6�   ��6   �� *AnimalWeight+6�   5+      �� 5,      $
��0 10q�6   $  
Horizontal=�6+   .+�5-      �� -
   5        $ AdCostLabel��5-        m_AdvertPage_AnimalAge#���  61   $��20(�6d   $	��180��6r   $��40��6~   6�   �� 5.      -   5        $ AdCostTextBox��5.   ^   $
 True��69   $��	10 0 20 0q�6K   
���   �$	��300��6�   $��40��6�   $��20(�6�   ��6   �� *	AnimalAge+6�   5/      50      �� 51      $  
Horizontal=�6   $��0 60 0 0q�62   .+�52      �� $  Vertical=�6   $	��300��64   $	��Top=�6A   $
��Left=�6Y   $��0 0 50 0q�6t   .+�53      ��   m_AdvertPage_Images#���  6   $��20(�6L   $	��180��6Z   $��40��6f   $	��Top=�6r   $
��Left=�6�   6�   �� 54      $  
Horizontal=�6!   .+�55      �� $  Vertical=�6%   .+�56      �� $
��0 10q�6)   $  
Horizontal=�67   .+�57   "   � -   5         �Name$ AdMainImageWrapper��57   '   ���#C0C0C0.+�58   &   �� -   5         ��Name$ AdMainImage��58   K   $  ��6`   $	��400��6j   $	��300��6v   ��6,   �� *ImageSource+6�   59   #   5:      5;      5<      5=      �� 5>      $  Vertical=�6   $	��300��64   $	��Top=�6A   $
��Left=�6Y   .+�5?      �� -   5        $ AdAmountLabel��5?        m_AdvertPage_Description#���  63   $
��Left=�6h   $��20(�6�   $	��180��6�   $��40��6�   6�   �� 5@      $  Vertical=�6!   .+�5A      �� $
��Auto=�6'   .��5B      �� -   5        $ AdAmountTextBox��5B   C   $
 True��6\   
���   �$	��620��6�   $	��260��6�   $��20(�6�   	 �� TextWrapping$
	 Wrap=�6�   $ IBeam��6�   ��6&   �� *Description+6�   5C      5D      5E      5F      5G      5H      5I      