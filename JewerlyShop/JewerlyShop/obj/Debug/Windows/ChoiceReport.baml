   M S B A M L   `   `   `  ����F  BJewerlyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:JewerlyShopJewerlyShop  5   	       JewerlyShop.ChoiceReport   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:JewerlyShop     5   	     � Icon$  \Resources\icon.ico��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
Отчёт��5
   	   $��234.175��6   $��322.423��6(   $��Arial Black)�68   .��5      �  � RowDefinitions 5   
   �� 5      $
��160* �6   �� 5      $
��430* �6   .+�5   
   � ���#708090$��0��6$   �� 5   
   $��
Отчёт��6   $��20(�6!   $��Center=�6/   
�������$��0��6_   $��0 15 0 0q�6l   � 5   
   $��1��6    5      �� 5      $	��20* �6    .+�5      �� $!��Выберите отчёт��6   $��15(�6.   $��Center=�6<   $��0 35 0 0q�6Y   6m   �� 5      -   5         ��Name$ 	AddReport��5      $	��PDF��6(   $��1��66   $	��110��6C   $��30��6O   
�������$
��Left=�6n   $��14(�6�   $��	20 80 0 0q�6�   ��5      �� 5       �� 
TargetType" ��6&   .R�5      ��  �� CornerRadius$ 15��6!   #��z��5      ._�5      �� $��Center=�6/   $��Center=�5   +   5      5      5!      �� 5"      -   5        $ AddReportExcel��5"      $��Excel��6-   $��1��6=   $	��110��6J   $��30��6V   
�������$��Right=�6u   $��14(�6�   $��	0 80 20 0q�6�   ��5#      �� 5$      " ��6&   .R�5%      �� $ 15��6!   #��z��5&      ._�5'      �� $��Center=�6/   $��Center=�5(   +   5)      5*      5,      5-      5.      5/      