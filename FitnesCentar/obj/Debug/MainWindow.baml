   M S B A M L   `   `   `  ����L  HSR41-2020-POP2021, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SR41_2020_POP2021SR41_2020_POP2021  5   	   "    SR41_2020_POP2021.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SR41_2020_POP2021     5   	   -   5          � Title$  
MainWindow��5   	   $	��550��6   $	��800��6)    � WindowStyle$
 None=�65    � 
ResizeMode$ CanMinimize=�6H   .��5
      �� ._�5   
   �� $��
-5,0,0,0.4q�6    J� RenderTransformOrigin$ 0.501,0.484&�6*   ��5      �� 5       �� ImageSource$v pC:/Users/petar/source/repos/Treci semestar/Projekat C#/SR41-2020-POP2021/SR41-2020-POP2021/Resources/fitnes.jfif��6    j� Stretch$ UniformToFill=�6�   .+�5      �� $��Login��6    $
��Bold"�6-   $��35(�6?   $��Times New Roman)�6M   
���  ��$��Italic$�6{   $��100,180,0,0q�6�   �� 5      -   5         ��Name$ username��5   K   $	��250��6   $��25��6#   $
��Left=�60   $��Center=�6]   $��	30,80,0,0q�6   �� 5       J� IsHitTestVisible .  $��username��61   $
��Left=�6B   $��100,-20,0,0q�6]   
���������5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�67    �� Triggers 5      �� 5       �� Binding 6*   �� *Text+ �� ElementName$ username�� �� Value  6Y   .a�5   "   �� 	 � y�$
 Visible=�6?   5      5      5      G� 5!      -   5         G�Name$ password��5!       G� PasswordChar$ *��6,   $
��Left=�6=   $	��250��6Y    G� 	MaxLength$ 25��6e   $��25��6t   $��	30,15,0,0q�6�   $��Center=�6�   �� 5#      -   5        $��LoginButton��5#   ?      RoundButtonLogin#��[  6   $��Login��6R   $
��Left=�6b   $��
100,20,0,0q�6�   �� 5%      -   5         ��Name$ RegisterButton��5%   C     RoundButtonRegister#��[ 6   $��Register��6[   $
��Left=�6�   $��
100,20,0,0q�6�   �� 5&      -   5        $��	cancelBtn��5&   ?     RoundButtonExit#��[ 6   $
��Exit��6P   $
��Left=�6w   $��
100,20,0,0q�6�   �� 5(      -   5        $��	fitnesBtn��5(   X   #��[  6   $	��110��6@   $��45��6L   $��FitnesCentar��6i   $��Right=�6�   $��0,-330,200,0q�6�   5*      5+      5,      