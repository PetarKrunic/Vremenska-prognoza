   M S B A M L   `   `   `  ����   Prognoza    Prognoza.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Vremenska Prognoza��$	��730��$	��600��$	��745��$	��600��.����  �� Padding$ 0q�._��� ����  �� ImageSource$? 9C:/Users/petar/Desktop/Prevodioci/Prezentacije/slika2.jpg��.+��� $��Location��$
��Bold"�$��	10 7 0 10q�$��20(�� .+��� -   $	��cmb�� �� 
IsEditable . $��	0,0,167,0q�$��2q�
���   �$��3q��� -   $��refresh��$��Refresh��$��Right=�$	��107��$��
0,0,27,-18q�$��20(��� -   $
��town��$��	10 0 0 45q�$��20(�$
��Left=�$��
ExtraBlack"�$	��121������  �� Path$
 Town� �� UpdateSourceTrigger$ PropertyChanged=�z���  �� ScaleX$	 1.3Q� �� ScaleY$ 3Q��� -   $��country��$��	10 0 0 20q�$��20(�$
��Bold"����� $ Country�$ PropertyChanged=�� $	��347�� � RowDefinitions �� .+��� -   $
��Pic1��$��0,28,291,174q��� $
��Left=�$	��266��$��51,203,0,104q��� -   $��temperature��$��0,0,149,235q�$��80(�$��Right=����� $ Temperature�$ PropertyChanged=��� -   $	��cel��$��
0,0,50,250q�$��80(�$��Right=����� $ VrijednostIzKoda�$ PropertyChanged=��� -   $��	condition��$��0,110,109,197q�$��30(�$��Right=����� $ 	Condition�$ PropertyChanged=��� $��0,160,180,150q�$��20(�$��Right=�$��Humidity���� -	   $��humidity��$��0,187,144,133q�$��20(�$��Right=�	 J� RenderTransformOrigin$	 0.416,0.809&�$	��111������ $ Humidity�$ PropertyChanged=��� $��0,160,10,160q�$��20(�$��Right=�$��
Wind Speed��$	��110���� -
   $��wndSpd��$��0,187,0,133q�$��20(�$��Right=�$	��110������ $ 	Windspeed�$ PropertyChanged=��� $��	0,270,0,0q�$
��Left=��� $��83,270,0,48q�$��20(�$
��Left=�$��
Ponedeljak��$	��102��$��SemiBold"��� -   $��cond1��$��90,295,0,25q�$��17(�$
��Left=�$��98������ $ VrijednostIzKoda�$ PropertyChanged=��� -   $��temp1��$��106,315,0,0q�$��16(�$
��Left=�$��48��$��Italic$����� $ VrijednostIzKoda�$ PropertyChanged=��� $��193,270,0,0q�$
��Left=�$>��8C:/Users/petar/Desktop/Prevodioci/Prezentacije/sunce.png��$��81���� $��279,270,0,55q�$��20(�$
��Left=�$��Utorak��$	��104��$��SemiBold"��� -   $��cond2��$��288,295,0,30q�$��17(�$
��Left=�$��95������ $ VrijednostIzKoda�$ PropertyChanged=��� -   $��temp2��$��300,318,0,0q�$��16(�$
��Left=�$��60��$��Italic$����� $ VrijednostIzKoda�$ PropertyChanged=��� $��0,270,130,0q�$��Right=�$>��8C:/Users/petar/Desktop/Prevodioci/Prezentacije/sunce.png��$��86���� $��467,270,0,48q�$��20(�$��Srijeda��$��SemiBold"��� -   $��cond3��$��0,295,10,25q�$��17(�$��Right=�$	��100������ $ VrijednostIzKoda�$ PropertyChanged=��� -   $��temp3��$��	0,315,0,0q�$��16(�$��Right=�$��96��$��Italic$����� $ VrijednostIzKoda�$ PropertyChanged=�� $	��216��$	 0.467,0.482&�.+��� $
��Left=�$>��8C:/Users/petar/Desktop/Prevodioci/Prezentacije/sunce.png��$��80��$��
0,10,0,106q��� $��85,24,0,170q�$��20(�$
��Left=�$��Cetvrtak��$��94��$��SemiBold"��� -   $��cond4��$��92,51,0,146q�$��17(�$
��Left=�$��81������ $ VrijednostIzKoda�$ PropertyChanged=��� -   $��temp4��$��108,70,0,125q�$��16(�$
��Left=�$��65��$��Italic$����� $ VrijednostIzKoda�$ PropertyChanged=��� $
��Left=�$>��8C:/Users/petar/Desktop/Prevodioci/Prezentacije/sunce.png��$��80��$��191,0,0,106q��� $��276,24,0,165q�$��20(�$
��Left=�$��Petak��$��98��$��SemiBold"��� -   $��cond5��$��288,51,0,146q�$��17(�$
��Left=�$��93������ $ VrijednostIzKoda�$ PropertyChanged=��� -   $��temp5��$��302,70,0,125q�$��16(�$
��Left=�$��61��$��Italic$����� $ VrijednostIzKoda�$ PropertyChanged=�