   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   MetroProgressBar �� Property  HighlightBrush �� Value  BorderColorBrush  TextBoxBorderBrush �� 
TargetType �Name'    !System.Windows.VisualStateManager    VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard g� RepeatBehavior	 g� Duration
 �� TargetProperty �� 
TargetName R� KeyTime R� Value  System.Windows.Visibility O� KeyTime O� Value ��Name ��Name J� Opacity J� RenderTransformOrigin  ProgressBrush �� EndPoint � MappingMode � SpreadMethod �� 
StartPoint �� 	Transform T� X �� AngleX  ProgressIndeterminateColor1 � Color � Offset  ProgressIndeterminateColor2  ProgressIndeterminateColor3  ProgressIndeterminateColor4 �� Triggers P� Property P� Value  �� 
TargetName! �� Angle 	 GrenColorBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        �� 5      "  �6   .�5   
   ��  � ��# �  6'   �� 5   
    � ��# �  6'   �� 5   
    �@�Maximum$	 100Q�6$   �� 5   
    � ��$ 10��6$   �� 5	   
    � �� .  6&   �� 5
   
    � ��$ 0q�6,   �� 5   
    � ��# �  6(   �� 5   
    � �� 5      �� 5      " �6"   .R�5      � $
 Root��6    5        5      CommonStates��. 5   "     Determinate��6.     5   "   Indeterminate��. 5   &   �� $ Forever��61   .��5   *   T� $	 00:00:00D�6H   $
 (UIElement.Visibility)�5   H   $ IndeterminateRoot��5   H   ..�5   .   i� $ 00:00:00��6E    5   2    5   6   Visible=�6J   5   /   5   +   T� 5   *   $	 00:00:00D�6H   $
 (UIElement.Visibility)�5   H   $ DeterminateRoot��5    H   ..�5!   .   i� $ 00:00:00��6E    5"   2    5#   6   	Collapsed=�6L   5%   /   5&   +   U� 5'   *   $
 X�6H   $ 
xTransform��5(   H   .\�5)   .   �� $ 0��6C   $ 0Q�5*   C   �� 5+   .   $ 	00:00:.35��6C   $ 20Q�5,   C   5-   +   5.   '   5/   #   50      .+�52      �� $ 
PART_Track��6!   #��z��53   !   #��z��54   !   #��z��55   !   � 56      $ ProgressBarRootGrid��6   .+�57      � $ IndeterminateRoot��6#   $y�	Collapsed=�58   #   .+�59   "   �� $ IndeterminateSolidFill��6,   #��z��5:   ,   $ 1Q�5;   ,   $ 0.5,0.5&�5<   ,   $��0��5=   ,   #���  5>   ,   �� 5?   "   $ IndeterminateGradientFill��6,   #��z��5@   ,   $	 0.7Q�5A   ,   $��1��5B   ,   ��5C   &   �� 5D   *   $	 0,1&�6>   $ Absolute=�5E   >   $ Repeat=�5F   >   $
 20,1&�5G   >    5H   .   V� 5I   2   .~�5J   6   T� $ 0Q�6I   
xTransform��5K   I   �� 5L   6   $	 -30Q�6D   5M   3   .��5O   .   � # �  6;   $ 0Q�5P   ;   � 5Q   .   # �  6;   $ 0.651Q�5R   ;   � 5S   .   # �  6;   $ 0.093Q�5T   ;   � 5U   .   # �  6;   $ 0.548Q�5V   ;   5W   +   5Y   #   5Z      � 5[      $ DeterminateRoot��6#   $��1q�5\   #   .+�5]   "   �� $ PART_Indicator��6)   #���  5^   )   $
��Left=�5_   )   $��-1q�5`   )   ._�5a   &   �� $ GradientFill��60   $	 0.7Q�5b   0   $y�	Collapsed=�5c   0   ��5d   *   �� 5e   .   $	 0,1&�6B   $ Absolute=�5f   B   $ Repeat=�5g   B   $
 20,1&�5h   B    5i   2   V� 5j   6   .~�5k   :   T� $ 0Q�6M   �� 5l   :   $	 -30Q�6H   5m   7   .��5o   2   � # �  6?   $ 0Q�5p   ?   � 5q   2   # �  6?   $ 0.651Q�5r   ?   � 5s   2   # �  6?   $ 0.093Q�5t   ?   � 5u   2   # �  6?   $ 0.548Q�5v   ?   5w   /   5y   '   5z   #   5{      5|      5}       5      P� 5�       �@�Orientation$ Vertical=�69   . �5�      �� $
  Root��6@    �@�LayoutTransform 5�   "   �� 5�   &   $	! -90Q�66   5�      5�      P� 5�       �@�IsIndeterminate . . �5�      �� $  IndeterminateRoot��6;    � y�$ Visible=�6[   �� 5�      $  DeterminateRoot��6;    � y�$ 	Collapsed=�6Y   5�      P� 5�       �@�Value$	 100Q�63   . �5�      �� $  PART_Indicator��6%   # � 	 6W    � ��5�      5�      5�      5�      5�      