   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MahApps.Metro.ControlsMahApps.Metro.Controls  5      C&clr-namespace:MahApps.Metro.ConvertersMahApps.Metro.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source9    3MahApps.Metro.Converters.ThicknessToDoubleConverter   ThicknessToDoubleConverter*   $MahApps.Metro.Controls.NumericUpDown �� 
TargetType �� Property �� Value  	TextBrush  TextBoxBorderBrush*   $MahApps.Metro.Controls.TextboxHelper  TextBoxFocusBorderBrush  TextBoxMouseOverBorderBrush  ContentFontFamily  ContentFontSize  ControlBackgroundBrush  ValidationErrorTemplate �� 
TargetType ��Name �� 	Converter � ColumnDefinitions	 ��Name
 J� SnapsToDevicePixels   
IsReadOnly �� 
IsReadOnly   ClearTextButton   	Watermark ��Name   Delay �� Delay 	 ChromelessButtonStyle F�Name �� Stretch 
 
GrayBrush1 �� Triggers P� Property P� Value �� 
TargetName P� 
SourceName  
GrayBrush8  AccentColorBrush  
BlackBrush  
WhiteBrush �� RelativeSource �� Path�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1Controls$clr-namespace:MahApps.Metro.Controls  5      5
converters&clr-namespace:MahApps.Metro.Converters  5        5      �� 5   
   $J Dpack://application:,,,/MahApps.Metro;component/Styles/VS/Colors.xaml?�6   %�  &	        '       7   7      5
      6,   �� 5      "  6   .�5   
   ��  � ��$ 1q�5      �� 5   
    � ��# �  5      �� 5   
    � ��# �  5      �� 5   
    �@ FocusBorderBrush# �  5      �� 5   
    �@ MouseOverBorderBrush# �  5      �� 5   
    � ��$ Center=�5      �� 5   
    � ��# �  5      �� 5   
    � ��# �  5      �� 5   
    �@ IsMonitoring . 5      �� 5   
    � ��$ 26��5       �� 5!   
    � ��$ 62��5"      �� 5#   
    � ��# �  5$      �� 5%   
    �@=�ErrorTemplate# �  5&      �� 5'   
    � �� 5(      �� 5)      "  6"   .R�5*      � #��z��6   #��z��5+      #��z��5,      #��z��5-      #��z��5.      .+�5/      �� $
 Base��6$   #��z��50   $   #��z��52   $   ��51   $   �� *BorderThickness+8   52   $   �� 53      $ FocusRectangle��6$   $y�	Collapsed=�54   $   ��55   $   �� *BorderThickness+8  � 56       57      �� 58   "   �� 59   "   $��20 �63   �� 5:   "   $��20 �63   .+�5=      �� $��0��6+   $��Hidden=�5>   +   ��.  .��5@   "   �� $	 PART_TextBox��6*   $��20��5A   *   $��Stretch=�5B   *   $��Right=�5C   *   #��z��5D   *   #
 z
 5E   *   $��0q�5F   *   |�. # z 5I   *   #��z��5J   *   #��z��5K   *   # z 5L   *   # z 5M   *   ��5G   *   Z� 5M   *   5N      �� 5O      $ PART_NumericUp��6+   $��1��5P   +   $��2,2,0,2q�5Q   +   # z 5R   +   #��z��5S   +   #��� 	 5T   +   ��.  .��5V   "   F� $ 	PolygonUp��6'   $��14��5W   '   $��14��5X   '   $
 Fill=�5Y   '   #��� 
 5Z   '   |�������!�@�q��!�@�q��@�e��@�e@�q�@�q@�q�@�q@�e��@�e��@�q���!@�q���!��������!5[   '   5\      �� 5]      $ PART_NumericDown��6+   $��2��5^   +   $��0,2,2,2q�5_   +   $��Center=�5`   +   # z 5a   +   #��� 	 5b   +   #��z��5c   +   ��.  .��5e   "   F� $ PolygonDown��6'   $��14��5f   '   $��3��5g   '   $
 Fill=�5h   '   #��� 
 5i   '   4������!��C�@�e��C�@�e c����! c����!��C5j   '   5k      5l      5m       5n      P� 5o       �@ 
IsReadOnly . . �5q      �� $ PART_TextBox��6%    �@J�IsHitTestVisible .  5s   %   5t      P� 5u      $ PART_NumericUp��5w   "    �@J�IsMouseOver . . �5x      �� $ PART_NumericUp��6%   # �  5z   %    � ���� 5{      $ 	PolygonUp��6%   # �  5}   %    � ��5~      P� 5      $ PART_NumericUp��5�   "    � �� . . �5�      �� $ PART_NumericUp��6%   # �  5�   %    � ���� 5�      $ 	PolygonUp��6%   # �  5�   %    � ��5�      P� 5�      $ PART_NumericDown��5�   "    �@J�IsMouseOver . . �5�      �� $ PART_NumericDown��6%   # �  5�   %    � ���� 5�      $ PolygonDown��6%   # �  5�   %    � ��5�      P� 5�      $ PART_NumericDown��5�   "    � �� . . �5�      �� $ PART_NumericDown��6%   # �  5�   %    � ���� 5�      $ PolygonDown��6%   # �  5�   %    � ��5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ FocusRectangle��6%    � y�$ Visible=�5�   %   �� 5�      $ FocusRectangle��6%    5�   %   ��  �� *TemplatedParent+$3 -(Controls:TextboxHelper.MouseOverBorderBrush)� � ��5�      P� 5�      $ PART_TextBox��5�   "    �@J�	IsFocused . . �5�      �� $ FocusRectangle��6%    � y�$ Visible=�5�   %   �� 5�      $ FocusRectangle��6%    5�   %   ��  �� *TemplatedParent+$/ )(Controls:TextboxHelper.FocusBorderBrush)� � ��5�      5�      5�      5�      5�      