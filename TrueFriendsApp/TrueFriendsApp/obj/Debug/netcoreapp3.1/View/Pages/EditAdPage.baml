   M S B A M L   `   `   `  ����  TrueFriendsApp$    TrueFriendsApp.View.EditAdPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Z	 VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/ 	 5      $	��620��5      $
��1200��6   .��5	      � 
�������.+�5
   
   �� $��10q�6     �� Orientation$  Vertical=�6!   .+�5      �� $  
Horizontal=�6   $��60��62   $	��Top=�6>   $
��Left=�6V   .+�5      �� $��
0 10 80 10q�6   $  
Horizontal=�61   .+�5      �� -   5         ��Name$ AdNameLabel��5         m_EditAdPage_Name#���   61   $��20(�6_   $	��180��6m   $��40��6y   6�   �� 5      -   5         ��Name$ AdNameTextBox��5   G   $��	10 0 20 0q�64   
���   �$	��300��6q   $��40��6}   $��20(�6�   ��6   �� *Name+6�   " 	 FontAwesome.WPF.ImageAwesome  5      -   5          Name$ NameValidationImage��5   y   $	��Top=�6�   $��40��6  $��40��6     Icon 6&   ��  �� Path$ NameValidationIcon� �� Mode$ TwoWay=� �� TargetNullValue$ MinusCircle��y�6�   �� $" NameValidationIconVisibility�$ TwoWay=�$ Hidden��6%  5      5      �� 5      $  
Horizontal=�6   $��60��62   $	��Top=�6>   $
��Left=�6V   .+�5      �� $��
0 10 80 10q�6   $  
Horizontal=�61   .+�5      �� -   5        $ AdRaitingLabel��5        m_EditAdPage_AnimalWeight#���  64   $��20(�6j   $	��180��6x   $��40��6�   6�   �� 5      -   5        $ AdRaitingTextBox��5   O   $��	10 0 20 0q�6<   
���   �$	��300��6|   $��40��6�   $��20(�6�   ��6   �� *AnimalWeight+6�     5      -   5        $! AnimalWeightValidationImage��5   �   $	��Top=�6  $��40��6$  $��40��6/   6&   �� $  AnimalWeightValidationIcon�$ TwoWay=�$ MinusCircle��y�6�   �� $* $AnimalWeightValidationIconVisibility�$ TwoWay=�$ Hidden��6=  5      �� 5      $
��0 10q�6   $  
Horizontal=�6+   .+�5      �� -   5        $ AdCostLabel��5        m_EditAdPage_AnimalAge#���  61   $��20(�6d   $	��180��6r   $��40��6~   6�   �� 5      -   5        $ AdCostTextBox��5   L   $��	10 0 20 0q�69   
���   �$	��300��6v   $��40��6�   $��20(�6�   ��6   �� *	AnimalAge+6�     5      -	   5        $ AnimalAgeValidationImage��5   ~   $	��Top=�6  $��40��6  $��40��6&   6&   �� $ AnimalAgeValidationIcon�$ TwoWay=�$ MinusCircle��y�6�   �� $' !AnimalAgeValidationIconVisibility�$ TwoWay=�$ Hidden��64  5      5      �� 5      $  
Horizontal=�6   $��80��62   $	��Top=�6>   $
��Left=�6V   .+�5      �� $��
0 10 80 10q�6   $  
Horizontal=�61   .+�5       �� -
   5        $ AdCategoryLabel��5         m_EditAdPage_KindOfAnimal#���  65   $��20(�6k   $	��180��6y   $��40��6�   6�   �� 5!      -   5         ��Name$ AdCategoryTextBox��5!   c   
���   �$��	10 0 20 0q�6P   $	��300��6~   $��40��6�   $	��Top=�6�   $��16(�6�   	 �� Text	 6   �� *KindOfAnimal+.@�5"      �� Собака6,   �� 5#      Кот6)   5$        5%      -   5        $! KindOfAnimalValidationImage��5%   �   $	��Top=�6  $��40��6$  $��40��6/   6&   �� $  KindOfAnimalValidationIcon�$ TwoWay=�$ MinusCircle��y�6�   �� $* $KindOfAnimalValidationIconVisibility�$ TwoWay=�$ Hidden��6=  5&      �� 5'      $��	0 10 0 10q�6   $  
Horizontal=�60   .+�5(      �� -   5        $ AdAmountLabel��5(        m_EditAdPage_Description#���  63   $��20(�6h   $	��180��6v   $��40��6�   6�   �� 5)      -   5        $ AdAmountTextBox��5)   N   $��	10 0 20 0q�6;   
���   �$	��300��6z   $��40��6�   $��20(�6�   
 � Cursor$
 IBeam��6�   ��6   �� *Description+6�     5*      -   5        $  DescriptionValidationImage��5*   �   $��40��6	  $��40��6   6&   �� $ DescriptionValidationIcon�$ TwoWay=�$ MinusCircle��y�6�   �� $) #DescriptionValidationIconVisibility�$ TwoWay=�$ Hidden��6"  5+      5,      �� 5-      $  Vertical=�6   $	��400��60   $	��Top=�6=   $
��Left=�6U   .+�5.      ��   m_EditAdPage_Images#���  6   $��20(�6H   $	��180��6V   $��40��6b   $	��Top=�6n   $
��Left=�6�   6�   �� 5/      $  
Horizontal=�6   .+�50      �� $  Vertical=�6!   $��0 0 50 0q�68   .+�51      �� $
��0 10q�6%   $  
Horizontal=�63   .+�52      � -   5         �Name$ AdMainImageWrapper��52   #   ���#C0C0C0.+�53   "   �� -   5         ��Name$ AdMainImage��53   G   $
  ��6\   $	��580��6f   $	��320��6r   ��6(   �� *ImageSource+6�   �� 54   "   -   5         ��Name$ AdMainImageButtonClose��54   )   $y�	Collapsed=�6n    K� ZIndex$	 100��6�   $��60��6�   $��60��6�   ���#5AA9B0$	��Top=�6�   $��Right=�6�   $

 Hand��6  ��6I   �� *imageButtonClose+��6�   Z� .��55   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6>   
�������$��35��6^   $��35��6i   $��Center=�6u   6�   56   #   57      58      59      �� 5:      $  Vertical=�6!   $	��Top=�68   $
��Left=�6P   .+�5;      �� -   5        $ AddPhotoButton��5;   !   $��Center=�6\   $��Center=�6y     m_EditAdPage_AdPhotoButton#���  6�   $��	0 10 0 10q�6�   $	��470��6�   $��50��6�   $��20(�6�   
���   �
���   ���69   �� *addPhotoButton+��6  Z� 6C  �� 5<      -   5        $ CreateAdButton��5<   !   $��Center=�6\   $��Center=�6y     m_EditAdPage_EditAdButton#���  6�   $��0 20 0 0q�6�   $	��470��6�   $��50��6�   $��20(�6�   ���#5AA9B0���#5AA9B0
���������69   �� *createAdButton+6B  5=      5>      5?      5@      5A      5B      