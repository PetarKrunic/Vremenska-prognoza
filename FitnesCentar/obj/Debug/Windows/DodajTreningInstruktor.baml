   M S B A M L   `   `   `  ����L  HSR41-2020-POP2021, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SR41_2020_POP2021.WindowsSR41_2020_POP2021.Windows  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   6    0SR41_2020_POP2021.Windows.DodajTreningInstruktor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SR41_2020_POP2021.Windows     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  DodajTreningInstruktor��5	   	   $	��450��6(   $	��800��65   .��5
      � ��5   
   �� 5       �� ImageSource$u oC:\Users\petar\source\repos\Treci semestar\Projekat C#\SR41-2020-POP2021\SR41-2020-POP2021\Resources/back3.jfif��6    j� Stretch$ UniformToFill=�6�   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5        $��DatumTreninga��5   F    �� Today   DisplayDateStart# Z 6   $
��Left=�6[   $��	10,61,0,0q�6v   $	��Top=�6�    J� RenderTransformOrigin$ 0.506,2.283&�6�   �� 5   
   -   5        $��ComboTrening��5      $
��Left=�6L   $��
189,61,0,0q�6g   $	��Top=�6{   $	��120��6�    �� SelectedItem 6'   ��  �� Path$ Status�6�   �� 5   
   -   5        $��VremeTreninga��5      $
��Left=�6'   $��23��6B   $��
369,60,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��120��6�   �� 5   
   -   5        $��TrajanjeTreninga��5      $
��Left=�6*   $��23��6E   $��
542,60,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $��Ok��5      $
��Left=�63   $��325,359,0,0q�6N   $	��Top=�6c   $��75��6{   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DGInstruktoriZaTrening��5      	   CanUserAddRows	 .  $
��Left=�6�   $	��100��6�   $��0,89,0,0q�6�   $	��Top=�6�   $	��774��6�   �� 5   
   -   5        $��OtkaziTrening��5   "   $��Otkazi��6   $
��Left=�6S   $��480,359,0,0q�6n   $	��Top=�6�   $��75��6�   �� 5   
   $
��Left=�6   $��
400,42,0,0q�6/   $
��Wrap=�6C   $��Vreme��6W   $	��Top=�6d   �� 5   
   $
��Left=�6   $��
573,39,0,0q�6/   $
��Wrap=�6C   $��Trajanje��6W   $	��Top=�6g   5      5      