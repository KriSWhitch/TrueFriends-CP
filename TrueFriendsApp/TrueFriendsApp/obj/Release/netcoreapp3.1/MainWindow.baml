   M S B A M L   `   `   `  ����   TrueFriendsApp    TrueFriendsApp.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   -     � Title$  TrueFriends��$	��720��$	��720��$
��1280��$
��1280�� � Icon$ images/icon.ico��
������� � 
ResizeMode$ CanMinimize=� � 	Resources    MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose  MouseCursor � Cursor��%!  &	        &	 q     &	 �     �� .��U� $ (FrameworkElement.Width)�$ GridMenu��.\�  $ 0��$ 60Q�  $ 0:0:0.5��$	 300Q��� .��U� $ (FrameworkElement.Width)�$ GridMenu��.\�  $ 0��$	 300Q�  $ 0:0:0.5��$ 60Q�� $ images/arrow_bold.cur��	 � Triggers	 :� 
 :� RoutedEvent$
 ButtonBase.Click�� :� 
SourceName$ ButtonOpenMenu��.[��� #��[  :� $
 ButtonBase.Click��$ ButtonCloseMenu��.[��� #��[ .��� .+�� $��60��$	��Top=����#5AA9B0.+��� $��Center=� �� Orientation$ 
Horizontal=�$��Right=�.+�'  !MaterialDesignThemes.Wpf.PopupBox  $��10q�   PlacementMode$ BottomAndAlignRightEdges=�   	StaysOpen$ False��   PopupContent. �� $	��150��.+��� -    ��Name$ 	ButtonFAQ��$	��FAQ���� �� -   $ ButtonPopUpLogout�� " m_MainWindow_ButtonPopUpLogout#���  �� $��0 0 60 0q�$��Center=�$ 
Horizontal=�$��Right=�.+��� -    ��Name$ ComboBoxLanguages��$��Center=�$��Center=�$��15(�$	��5 0q�$��30��$	��200��
���   ����#5AA9B0
�������� -    �Name$ GridMenu��$��60��$
��Left=����	#FF3E7585 K� ZIndex$	 100��.+��� -    ��Name$ MenuControlPanel��.+�� $��60�����	#FF3E7585.+��� -   $ ButtonCloseMenu��$y�	Collapsed=�$��60��$��60��$	��Top=�$��Right=���Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�
�������$��25��$��25���� -   $ ButtonOpenMenu��$��60��$��60��$	��Top=�$��Right=���Z� ��Z� .��  $
 Menu=�
�������$��25��$��25���� -	   $ MenuButtons��$	��0 0q�$��Disabled=�$ Vertical=�.+��� -
   $ 
HomeButton��$��60��$
��Left=���Z� ��Z� .���� $ 
Horizontal=�.+�  $ ViewDashboard=�$��25��$��25��$��Center=�$��0 0 10 0q���   m_MainWindow_Home#���  $��Center=�$��20 10q�$��20(��� -   $ CreateAdButton��$��60��$
��Left=���Z� ��Z� .���� $ 
Horizontal=�.+�  $ Pencil=�$��25��$��25��$��Center=�$��0 0 10 0q���   m_MainWindow_CreateAd#���  $��Center=�$��20 10q�$��20(��� -   $ GitHubButton��$��60��$
��Left=���Z� ��Z� .���� $ 
Horizontal=�.+�  $ Github=�$��25��$��25��$��Center=�$��0 0 10 0q���   m_MainWindow_GitHub#���  $��Center=�$��20 10q�$��20(�� -   $ GridMain�����#C1C0C0$��	60,60,0,0q�