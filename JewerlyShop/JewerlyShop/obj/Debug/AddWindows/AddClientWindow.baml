   M S B A M L   `   `   `  ����F  BJewerlyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:JewerlyShopJewerlyShop  5   	   !    JewerlyShop.AddClientWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:JewerlyShop     5   	     � Icon$  \Resources\icon.ico��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$) #Добавление клиента��5
   	   $	��300��6$   $	��450��61   $��Arial Black)�6=   .��5      �  � RowDefinitions 5   
   �� 5      $
��130* �6   �� 5      $
��430* �6   .+�5   
   � ���#708090$��0��6$   �� 5   
   $��Клиенты��6   $��20(�6#   $��Center=�61   
�������$��0��6a   $��0 20 0 0q�6n   � 5   
   $��1��6    5      �� 5      $	��30* �6    �� 5      $	��30* �6    �� 5      $	��30* �6     � ColumnDefinitions 5      �� 5      $
��161* �6#   �� 5      $
��281* �6#   .+�5      �� $��ФИО��6   $��Center=�6"   $��Center=�6F   $��14(�6h   $��0��6v   $��0��6�   �� 5      -   5         ��Name$ AddName��5      $��28,18q�6'   
 � Tag$ fname��66   $��0��6B   $��1��6O   $
��Left=�6_   $��Center=�6�   �� 5      $��Телефон��6   $��Center=�6&   $��Center=�6J   $��14(�6l   $��1��6z   $��0��6�   �� 5      -   5        $ AddPhone��5      $��28,18q�6(   $ fname��67   $��1��6C   $��1��6P   $
��Left=�6`   $��Center=�6�   �� 5       -   5         ��Name$ 
SaveButton��5       $��Сохранить��6)   $��4��6=   $��1��6J   $	��130��6Z   
�������$
��Left=�6y   $
��0,14q�6�   ��5!      �� 5"       �� 
TargetType" ��6&   .R�5#      �� 	 �� CornerRadius$	 15��6!   #��z��5$      ._�5%      �� $��Center=�6/   $��Center=�5&   +   5'      5(      5*      5+      5,      5-      