   M S B A M L   `   `   `  ����I  ETrueFriendsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TrueFriendsApp.ViewTrueFriendsApp.View  5	      "    TrueFriendsApp.View.HomePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b	 ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962af
 bMaterialDesignThemes.MahApps, Version=0.1.6.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 
 5      /local!clr-namespace:TrueFriendsApp.View 	 
 5	      $	��620��5      $
��1200��6   .��5      � 
�������.+�5   
   �� .+�5      ��   �� Orientation$  
Horizontal=�6   .+�5      �� .+�5      ��  !  m_HomePage_Description_Header#���   6    
���   �$��24(�6j   $
��Wrap=�6x   $	��550��6�   $
��Left=�6�   $��
20 20 20 0q�6�   �� 5        m_HomePage_Description#���  6    
���   �$��16(�6c   $
��Wrap=�6q   $	��550��6�   $
��Left=�6�   $��20 20q�6�   5      �� 5      .+�5      ��   m_HomePage_Help_Header#���  6    
���   �$��24(�6c   $
��Wrap=�6q   $	��550��6�   $
��Left=�6�   $��
20 20 20 0q�6�   �� 5        m_HomePage_Help#���  6    
���   �$��16(�6\   $
��Wrap=�6j   $	��550��6~   $
��Left=�6�   $��20 20q�6�   5      5      �� 5      .+�5      �� 
���   � # m_HomePage_LatestArivals_Header#���  6/   $��24(�6h   $
��Wrap=�6v   $	��550��6�   $
��Left=�6�   $��20 20q�6�   �� 5      $  
Horizontal=�6   .+�5      �� -   5         ��Name$ MainGrid��5   .   $��2��6   
���   �$	��270��6�   ��6@   �� *AdList+ �� SelectedItem 6_   �� *SelectedItem+ �� Mode$ TwoWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ MouseDoubleClick��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5   "   /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 65   �� *rowDoubleClick+   CommandParameter 5   !   �� 	 �� ElementName$	 MainGrid��
 �� Path$
 SelectedItem�5       ��5"      �� 5#      .R�5$   "   �  � Orientation$ 
Horizontal=�6,   5%      ��5'      �� 5(      .R�5)   "   �� $��5q�6-   $  Vertical=�68   .+�5*   &   �� $��Center=�6,   $	��350��6t   $	��210��6�   ��6I   �� $
 Advert_ImageSource�6�   �� 5+   &   $  Vertical=�61   $	��330��6H   .+�5,   *   �� .+�5-   .   �� $
��Bold"�68   $��18(�6J   $��5 5 0 10q�6z   ��6X   �� $
 Advert_Name�6z   5.   +   �� 5/   *   $  Vertical=�65   .+�50   .   �� $
��Left=�69   $  
Horizontal=�6T   .+�51   2   �� $��Center=�68   $��Center=�6S   $��Возраст:��6u   $��14(�6�   6�   �� 52   2   $��Center=�6<   $��14(�6W   ��6e   �� $
 Advert_AnimalAge�53   /   �� 54   .   $
��Left=�69   $  
Horizontal=�6T   .+�55   2   �� $��Center=�68   $��Center=�6S   $��Вес:��6u   $��14(�6�   6�   �� 56   2   $��Center=�6<   $��14(�6W   ��6e   �� $
 Advert_AnimalWeight�57   /   58   +   59   '   5:   #   5;      5=      5>      5?      �� 5@      $  
Horizontal=�6   $��35��62   $��Center=�6>   .+�5A      ��   m_HomePage_Contacts_Header#���  6   
���   �$��Center=�6c   $��16(�6   $
��Wrap=�6�   $��Right=�6�   $
��20 0q�6�   �� 5B        m_HomePage_Contacts_Phone#���  6   
���   �$��Center=�6b   $��16(�6~   $
��Wrap=�6�   $��Right=�6�   $
��20 0q�6�   �� 5C        m_HomePage_Contacts_Email#���  6   
���   �$��Center=�6b   $��16(�6~   $
��Wrap=�6�   $��Right=�6�   $
��20 0q�6�   �� 5D         m_HomePage_Requisites_Header#���  6   
���   �$��Center=�6e   $��16(�6�   $
��Wrap=�6�   $��Right=�6�   $
��20 0q�6�   �� 5E       	 m_HomePage_Requisites_BBBY#��� 	 6   
���   �$��Center=�6c   $��16(�6   $
��Wrap=�6�   $��Right=�6�   $
��20 0q�6�   5F      5G      5H      5I      