   M S B A M L   `   `   `  ����I  ETrueFriendsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:TrueFriendsApp.View.PagesTrueFriendsApp.View.Pages  5	      ,    &TrueFriendsApp.View.Pages.FavoritePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b	 ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af
 bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 
 5      5local'clr-namespace:TrueFriendsApp.View.Pages 	 
 5	      $	��620��5      $
��1200��6   .��5      � 
�������.+�5   
   �� .+�5      ]� $��40��6   $��Center=�6$   .+�5      ��   �� Orientation$  
Horizontal=�6   $
��Left=�66   $
��20 0q�6Q   .+�5      �� $��16(�6   $��Center=�6*   $��Сортировка:��6E   $��0 0 20 0q�6[   6o   �� 5      -   5         ��Name$ ComboBoxSort��5       �� DisplayMemberPath$ SortType��5   C    �� SelectedValuePath$ SortType��5      $��Center=�5      $��Center=�6=   $��16(�6_   $	��5 0q�6m   $��30��5      $	��200��6%   
���   ����#5AA9B0
���������5   /   �� *Sorts+ �� SelectedItem 5      �� *CurrentSelection+ �� SelectedValue 5   6   �� *CurrentSelection.SortType+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5   "   /  )GalaSoft.MvvmLight.Command.EventToCommand  	   Command	 65   �� *sortChangedClick+
   CommandParameter
 5   !   ��  �� ElementName$ ComboBoxSort��5      5      5      �� 5       $  
Horizontal=�6   $��Right=�66   $
��20 0q�6R   .+�5!      �� $��16(�6   $��Center=�6*   $'��!Поиск по названию:��6E   $��0 0 20 0q�6b   6v   �� 5"      -   5         ��Name$ TextBlockSearch��5#      $��16(�62   $	��5 0q�6@   $��0 0 20 0q�6N   $��30��5$      $	��200��6%   
���   �
���������5%      �� *
SearchText+�� 5'      -   5         ��Name$ ButtonSearchAdvert��5'      $��60��6`   $��35��6k   $��Center=�6�   $��Center=�6�   ��69   �� *buttonSearchAdvert+��6w   Z� ��6�   Z� .��5(      ' 	 !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�62   
���   �$��30��6S   $��25��6^   6l   5)      �� 5*      -   5        $ ButtonClearSearch��5*      $��60��6^   $��35��6i   $��Center=�6�   $��Center=�6�   ��68   �� *buttonClearSearch+��6u   Z� ��6�   Z� .��5+        $ Remove=�62   
���   �$��30��6S   $��25��6^   6l   5,      5-      5.      �� 5/      -   5         ��Name$ MainGrid��5/   &   $��2��6   
���   �$	��580��6�   ��68   �� *	TmpList+ 6X   �� *SelectedItem+ �� Mode$ TwoWay=� 50        51      $ MouseDoubleClick��6%   . 52        	 6-   �� *rowDoubleClick+
 53   !   �� $ MainGrid�� �� Path$ SelectedItem�54      ��56      �� 57      .R�58      �  � Orientation$ 
Horizontal=�6$   59      ��5;      �� 5<      .R�5=      �� $��5q�6%   $  Vertical=�60   .+�5>      �� $��Center=�6$   $	��350��6l   $	��210��6x   ��6A   �� $ Advert_ImageSource�6x   �� 5?      $  Vertical=�6)   $	��330��6@   .+�5@   "   �� .+�5A   &   �� $
��Bold"�60   $��18(�6B   $��5 5 0 10q�6r   ��6P   �� $ Advert_Name�6r   5B   #   �� 5C   "   $  Vertical=�6-   .+�5D   &   �� $
��Left=�61   $  
Horizontal=�6L   .+�5E   *   �� $��Center=�60   $��Center=�6K   $��Возраст:��6m   $��14(�6�   6�   �� 5F   *   $��Center=�64   $��14(�6O   ��6]   �� $ Advert_AnimalAge�5G   '   �� 5H   &   $
��Left=�61   $  
Horizontal=�6L   .+�5I   *   �� $��Center=�60   $��Center=�6K   $��Вес:��6m   $��14(�6|   6�   �� 5J   *   $��Center=�64   $��14(�6O   ��6]   �� $ Advert_AnimalWeight�5K   '   5L   #   5M      5N      5O      5Q      5R      5S      5T      