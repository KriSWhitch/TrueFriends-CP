   M S B A M L   `   `   `  ����  TrueFriendsApp4    .TrueFriendsApp.View.Pages.UserRegistrationPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� 
Background
  ����� N� Title$ UserRegistrationPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $	��300 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $	��420 �6   �� 5      .+�5   
   �� $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $	��Top=�6h   .+�5      �� -   5         ��Name$ ButtonBackToHomePage��5      $��60��6n   $��35��6y   $��Center=�6�   $
��Left=�6�    � Cursor$
 Hand��6�   ��63   �� *LoadAuthorizationCommand+ �� Mode$ OneTime=���6�   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   
���   �$��30��6N   $��25��6Y   6g   5      5      �� 5   
   $��1��6   $��1��6"   .+�5      �� $��0, 40, 0, 0q�6   .+�5      �� $'��!Введите ваш логин:��6   �� 5      -   5        	 ��Name$	 EmailTextBox��5      $��15(�5!      
���   �$��5q�5#      $��5q�5$      ��5       �� *Login+5$      5%      �� 5&      $��0, 40, 0, 100q�6   .+�5'      �� $)��#Введите ваш пароль:��6   G� 5(      -   5        
 G�Name$
 PasswordBox��5(       G� PasswordChar$ *��63   $��1��6D   $��15(�6Q   $��1��6_   $��5q�6o   $��5q�6z      MaterialDesignPasswordBox#���   6�   $ IBeam��6�   5)      �� 5*      $��15(�5+      $��40��6   $��0, 15, 0, 0q�5,      
����������#5AA9B0���#5AA9B0$
 Hand��52      ��5-      ��  �� ElementName$ PasswordBox����5.      �� *signUp+.��53      ��  �� TextAlignment$ Center=�6   &$Зарегистрироваться6G   54      55      56      57      