   M S B A M L   `   `   `  ����   TrueFriendsApp'    !TrueFriendsApp.pages.CreateAdPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   $	��620��$
��1220��.��� 
�������.+��� $��10q�  �� Orientation$  Vertical=�.+��� $  
Horizontal=�$��60��$	��Top=�$
��Left=�.+��� $��
0 10 80 10q�$  
Horizontal=�.+��� -    ��Name$ AdFullNameLabel��   m_CreateAdPage_FullName#���   $��20(�$	��180��$��40���� -    ��Name$ AdFullNameTextBox��$��	10 0 20 0q�
���   �$	��300��$��40��$��20(��� -    ��Name$ FullNameValidationImage��$y�Hidden=�$	��Top=�$��40��$��40��$��../images/unchecked.png���� $
��0 10q�$  
Horizontal=�.+��� -   $ AdShortNameLabel��  m_CreateAdPage_ShortName#���  $��20(�$	��180��$��40���� -   $ AdShortNameTextBox��$��	10 0 20 0q�
���   �$	��300��$��40��$��20(��� -   $ ShortNameValidationImage��$y�Hidden=�$	��Top=�$��40��$��40��$��../images/unchecked.png���� $  
Horizontal=�$��60��$	��Top=�$
��Left=�.+��� $��
0 10 80 10q�$  
Horizontal=�.+��� -   $ AdRaitingLabel��  m_CreateAdPage_Raiting#���  $��20(�$	��180��$��40���� -   $ AdRaitingTextBox��$��	10 0 20 0q�
���   �$	��300��$��40��$��20(��� -	   $ RaitingValidationImage��$y�Hidden=�$	��Top=�$��40��$��40��$��../images/unchecked.png���� $
��0 10q�$  
Horizontal=�.+��� -
   $ AdCostLabel��  m_CreateAdPage_Cost#���  $��20(�$	��180��$��40���� -   $ AdCostTextBox��$��	10 0 20 0q�
���   �$	��300��$��40��$��20(��� -   $ CostValidationImage��$y�Hidden=�$	��Top=�$��40��$��40��$��../images/unchecked.png���� $  
Horizontal=�$��80��$	��Top=�$
��Left=�.+��� $��
0 10 80 10q�$  
Horizontal=�.+��� -   $ AdCategoryLabel��  m_CreateAdPage_Category#���  $��20(�$	��180��$��40���� -    ��Name$ AdCategoryTextBox��$��	10 0 20 0q�$	��300��$��40��$	��Top=�$��16(�.@��� Одежда�� 
Обувь�� Аксессуары�� Прочее�� -   $ CategoryValidationImage��$y�Hidden=�$	��Top=�$��40��$��40��$��../images/unchecked.png���� $��	0 10 0 10q�$  
Horizontal=�.+��� -   $ AdAmountLabel��  m_CreateAdPage_Amount#���  $��20(�$	��180��$��40���� -   $ AdAmountTextBox��$��	10 0 20 0q�
���   �$	��300��$��40��$��20(��� -   $ AmountValidationImage��$y�Hidden=�$��Center=�$��40��$��40��$��../images/unchecked.png���� $  Vertical=�$	��400��$	��Top=�$
��Left=�.+���   m_CreateAdPage_Images#���  $��20(�$	��180��$��40��$	��Top=�$
��Left=��� $  
Horizontal=�.+��� $  Vertical=�$��0 0 50 0q�.+��� $
��0 10q�$  
Horizontal=�.+�� -    �Name$ AdMainImageWrapper�����#C0C0C0.+��� -   $ AdMainImage�� � Cursor$  ��$	��450��$	��320���� -    ��Name$ AdMainImageButtonClose��$y�	Collapsed=� K� ZIndex$	 100��$��60��$��60�����#5AA9B0$	��Top=�$��Right=���Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Close=�
�������$��35��$��35��$��Center=��� $  Vertical=�$	��Top=�$
��Left=�$��0 0 50 0q�.+�� -   $ AdSubImage1Wrapper��$��Center=�$��Center=�$��	0 10 0 25q�$��90��$��90�����#C0C0C0.+��� -   $ AdSubImage1��$  ��$��90��$��90���� -   $ AdSubImage1ButtonClose��$y�	Collapsed=�$	 100��$��45��$��45�����#5AA9B0$	��Top=�$��Right=���Z� .��  $	 Close=�
�������$��25��$��25��$��Center=�� -   $ AdSubImage2Wrapper��$��Center=�$��Center=�$��0 0 0 25q�$��90��$��90�����#C0C0C0.+��� -   $ AdSubImage2��$  ��$��90��$��90���� -   $ AdSubImage2ButtonClose��$y�	Collapsed=�$	 100��$��45��$��45�����#5AA9B0$	��Top=�$��Right=���Z� .��  $	 Close=�
�������$��25��$��25��$��Center=�� -   $ AdSubImage3Wrapper��$��Center=�$��Center=�$��0 0 0 25q�$��90��$��90�����#C0C0C0.+��� -   $ AdSubImage3��$  ��$��90��$��90���� -   $ AdSubImage3ButtonClose��$y�	Collapsed=�$	 100��$��45��$��45�����#5AA9B0$	��Top=�$��Right=���Z� .��  $	 Close=�
�������$��25��$��25��$��Center=��� $  Vertical=�$	��Top=�$
��Left=�.+��� -   $ AddPhotoButton��$��Center=�$��Center=�   m_CreateAdPage_AdPhotoButton#���  $��	0 10 0 10q�$	��470��$��50��$��20(�
���   �
���   ���Z� �� $��20(�  m_CreateAdPage_Text1#���  $��0 5 0 5q�$ 10��
���   ��� $��20(� 	 m_CreateAdPage_Text2#��� 	 $��0 15 0 5q�$ 10��
���   ��� -    $ CreateAdButton��$��Center=�$��Center=� !
 m_CreateAdPage_CreateAdButton#��� 
 $��
0 130 0 25q�$	��470��$��50��$��20(����#5AA9B0���#5AA9B0
�������