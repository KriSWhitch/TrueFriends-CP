   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	    TrueFriendsApp$   TrueFriendsApp.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   aintrPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af	 bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5   	     � Title$  TrueFriends��5	   	   $	��720��6   $	��720��6-   $
��1280��6:   $
��1280��6J    � Icon$ ../../images/icon.ico��6W   
������� � 
ResizeMode$ CanMinimize=�5
   	   .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6'   �� *windowLoaded+5       � 	Resources 5         MenuOpen �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value  	MenuClose  MouseCursor � Cursor��%�  &	        &	 �     &	 �    �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $	 GridMenu��6a   .\�5        $
 0��6'   $ 60Q�63     5      $
 0:0:0.5��6'   $	 300Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $	 GridMenu��6a   .\�5        $
 0��6'   $	 300Q�63     5      $
 0:0:0.5��6'   $ 60Q�69   5      5      � 5   
   $! ../../images/arrow_bold.cur��6/   5       � Triggers 5      :� 5    
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5!      �� #��[  6   5"      :� 5#   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5$      �� #��[ 6   5%      .��5(      � .+�5)   
   � $��60��6   $	��Top=�6   ���#5AA9B0.+�5*      �� $��Center=�6    �� Orientation$ 
Horizontal=�64   $��Right=�6M   .+�5+      '  !MaterialDesignThemes.Wpf.PopupBox  $��10q�6*      PlacementMode$ BottomAndAlignRightEdges=�66      	StaysOpen$ False��6_      PopupContent. 5,      �� $	��150��6!   .+�5-      �� -   5         ��Name$ 	ButtonFAQ��5-   !   $	��FAQ��64   ��6B   �� *	buttonFAQ+�� 5.      �� 5/      -   5        $ ButtonPopUpRefresh��5/   !    # m_MainWindow_ButtonPopUpRefresh#���  6=   ��6y   �� *buttonPopUpRefresh+�� 50      -   5        $ ButtonPopUpLogout��50   !    " m_MainWindow_ButtonPopUpLogout#���  6<   ��6w   �� *buttonPopUpLogout+51      52      53      �� 54      $��0 0 60 0q�6   $��Center=�6+   $ 
Horizontal=�6F   $��Right=�6_   55      � 56   
   -   5         �Name$ GridMenu��56      $��60��6!   $
��Left=�6,   ���	#FF3E7585 K� ZIndex$	 100��6^   .+�57      �� -   5         ��Name$ MenuControlPanel��57      .+�58      � $��60��6   ���	#FF3E7585.+�59      �� -   5        $ ButtonCloseMenu��59      $��60��6�   $��60��6�   $	��Top=�6�   $��Right=�6  $
 Hand��6+  ��66   �� *buttonCloseMenu+y�6Z   �� *ButtonCloseMenuVisibility+ �� Mode$ TwoWay=� �� TargetNullValue$ 	Collapsed����6�   Z� ��6�   Z� .��5:      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�62   
�������$��25��6V   $��25��6a   6o   5;      �� 5<      -   5        $ ButtonOpenMenu��5<      $��60��6�   $��60��6�   $	��Top=�6�   $��Right=�6
  ��65   �� *buttonOpenMenu+y�6X   �� *ButtonOpenMenuVisibility+$ TwoWay=�$ Visible����6�   Z� ��6�   Z� .��5=        $
 Menu=�62   
�������$��25��6Q   $��25��6\   6j   5>      5?      �� 5@      -   5        $ MenuButtons��5@      $	��0 0q�62   $��Disabled=�6?   $ Vertical=�6u   .+�5A      �� -	   5        $ 
HomeButton��5A      $��60��6c   $
��Left=�6�   $
 Hand��6�   ��61   �� *LoadMainCommand+$ OneTime=���6o   Z� ��6�   Z� .��5B      �� $ 
Horizontal=�6%   .+�5C        $ ViewDashboard=�66   $��25��6K   $��25��6V   $��Center=�6b   $��0 0 10 0q�6}   6�   �� 5D        m_MainWindow_Home#���  6(   $��Center=�6S   $��20 10q�6n   $��20(�6}   6�   5E      5F      �� 5G      -
   5        $ BrowseAdvertsButton��5G      $��60��6u   $
��Left=�6�   $
 Hand��6�   ��6:   �� *LoadBrowseAdvertsCommand+$ OneTime=���6�   Z� ��6�   Z� .��5H      �� $ 
Horizontal=�6%   .+�5I        $ ViewList=�66   $��25��6F   $��25��6Q   $��Center=�6]   $��0 0 10 0q�6x   6�   �� 5J        m_MainWindow_BrowseAdverts#���  6(   $��Center=�6\   $��20 10q�6w   $��20(�6�   6�   5K      5L      �� 5M      -   5        $ FavoriteButton��5M      $��60��6�   $
��Left=�6�   $
 Hand��6�   y�65   �� *FavoriteButtonVisibility+��6e   �� *LoadFavoriteCommand+$ OneTime=���6�   Z� ��6�   Z� .��5N      �� $ 
Horizontal=�6%   .+�5O        $ Favorite=�66   $��25��6F   $��25��6Q   $��Center=�6]   $��0 0 10 0q�6x   6�   �� 5P        m_MainWindow_Favorite#���  6(   $��Center=�6W   $��20 10q�6r   $��20(�6�   6�   5Q      5R      �� 5S      -   5        $ CreateAdButton��5S   )   $��60��6   $
��Left=�6�   $
 Hand��6�   y�6A   �� *CreateAdButtonVisibility+��6q   �� *LoadCreateAdPageCommand+$ OneTime=���6�   Z� ��6�   Z� .��5T      �� $ 
Horizontal=�6%   .+�5U        $ Pencil=�66   $��25��6D   $��25��6O   $��Center=�6[   $��0 0 10 0q�6v   6�   �� 5V        m_MainWindow_CreateAd#���  6(   $��Center=�6W   $��20 10q�6r   $��20(�6�   6�   5W      5X      5Y      5Z      5[      �� 5\   
   -   5         ��Name$ 
OutputView��5\   I   $��1��69   $��	60,60,0,0q�6]   ��6   �� *
OutputView+6]   5]      5^      