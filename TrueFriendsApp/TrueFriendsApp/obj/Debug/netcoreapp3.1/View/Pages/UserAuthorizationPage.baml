   M S B A M L   `   `   `  ����  TrueFriendsApp5    /TrueFriendsApp.View.Pages.UserAuthorizationPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5        N� 
Background
  ����� N� Title$ UserAuthorizationPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $	��300 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $	��420 �6   �� 5      .+�5   
   �� $��1��6   $��1��6"   .+�5      �� $��0, 40, 0, 0q�6   .+�5      �� $'��!Введите ваш логин:��6   �� 5      -   5         ��Name$ EmailTextBox��5      $��15(�5      
���   �$��5q�5      $��5q�5      ��5      �� *Login+5      5       �� 5!      $��0, 40, 0, 100q�6   .+�5"      �� $)��#Введите ваш пароль:��6   G� 5#      -   5         G�Name$ PasswordBox��5#       G� PasswordChar$ *��63   $��1��6D   $��15(�6Q   $��1��6_   $��5q�6o   $��5q�6z      MaterialDesignPasswordBox#���   6�    � Cursor$ IBeam��6�   5$      �� 5%      $��40��5&      $
 Hand��6   ���#5AA9B0���#5AA9B0��5'      �� *signIn+��5*      ��  �� ElementName$ PasswordBox��.��5+      � .+�5,      �� $��5q�5-      	 �� Padding$	 5q�5.      $&�� Авторизироваться��5/      $��15(�50      
�������
 �� TextAlignment$
 Center=�52      $��Center=�53      55      56      57      �� 58      $��15(�59      $��40��5:      $��0, 15, 0, 0q�5;      
����������#5AA9B0���#5AA9B0$
 Hand��5>   K   ��6   �� *LoadRegistrationCommand+ �� Mode$ OneTime=�.��5?      �� $
 Center=�6   &$Зарегистрироваться6G   5@      5A      5B      5C      