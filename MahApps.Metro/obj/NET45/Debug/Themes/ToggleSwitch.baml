   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MahApps.Metro.ControlsMahApps.Metro.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089/    )MahApps.Metro.Controls.ToggleSwitchButton  �� 
TargetType �� Property �� Value   AccentColorBrush �� 
TargetType ��Name J� Opacity �� Padding'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard
 �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible R� Value   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To   
Storyboard g� Duration	 W� To W� EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode4  .System.Windows.Media.Animation.ExponentialEase   Exponent9	  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value	 t� To �Name � UseLayoutRounding ��Name  
GrayBrush4    SwitchForeground  
BlackBrush  
WhiteBrush)
   #MahApps.Metro.Controls.ToggleSwitch �� Mode  � RowDefinitions! � ColumnDefinitions" ��Name# ��Name$ 
  Header% 
  HeaderTemplate&   Name' 
  SwitchForeground( �� Triggers) �� Binding* �� RelativeSource+ �� Path, �� Value- �� 
TargetName. P� Property/ P� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1Controls$clr-namespace:MahApps.Metro.Controls  5      %  '         '
  �    �� 5      "    6   .�5   
   ��  � �� .  5      �� 5   
    �@  SwitchForeground# �   5	      �� 5
   
    � �� 5      �� 5      "   6"   .R�5      �� $
 Root��6   #��z��5      #��z��5      # z 5      # z��5       5        5      CommonStates��. 5   "     
Normal��6.     5   "   Disabled��.	 5   &   �� .��5   *   T� $
 (UIElement.Visibility)�6H   $ disabled��5   H   ..�5   .   i� $ 0��6E   # Z 5   E   5   +   T� 5   *   $
 (UIElement.Visibility)�6H   $ disabledTumb��5   H   ..�5   .   i� $ 0��6E   # Z 5   E   5    +   5!   '   5"   #     5#   "   	MouseOver��.	 5$   &   �� .��5%   *   T� $
 (UIElement.Visibility)�6H   $ hover��5&   H   ..�5'   .   i� $ 0��6E   # Z 5(   E   5)   +   5*   '   5+   #     5,   "   Pressed��.	 5-   &   �� .��5.   *   T� $
 (UIElement.Visibility)�6H   $ pressed��5/   H   ..�50   .   i� $ 0��6E   # Z 51   E   52   +   53   '   54   #   55        56      CheckStates�� 57   "     58   &   $ 0:0:0.05D�67   $ 	Unchecked��59   7     5:   &   $ 0:0:0.05D�67   $ Checked��5;   7   . 5<   *   �� .��5=   .   W� $ 0:0:0.05D�6>   $ 47X�5>   >   $
 (TranslateTransform.X)�5?   >   $ SwitchThumbTranslate��5@   >    5A   2     5B   6   $ EaseIn=�6A   5D   /   5E   +   5F   '   . 5H   "     Checked��.	 5I   &   �� .��5J   *   W� $ BackgroundTranslation��6:   $
 (TranslateTransform.X)�5K   :   $ 0D�5L   :   $ 68X�5M   :    5N   .     5O   2   $ 15Q�6B   $ EaseOut=�5P   B   5R   +   U� 5S   *   $U
 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6H   $ SwitchThumb��5T   H   .\�5U   .   	  $ 0��6C   $ 47Q�5V   C   5W   +   5X   '   5Y   #     5Z   "   Dragging��6.     5[   "   	Unchecked��.	 5\   &   �� .��5]   *   W� $ BackgroundTranslation��6:   $
 (TranslateTransform.X)�5^   :   $ 0D�5_   :   $ 0X�5`   :   T� 5a   *   $
 (UIElement.Visibility)�6H   $ border��5b   H   ..�5c   .   i� $ 0��6E   # Z 5d   E   5e   +   t� 5f   *   $ 0D�6=   $ 1X�5g   =   $
 (Border.Margin)�5h   =   $ checked��5i   =   5j   '   5k   #   5l      ._�5n      � $ 
SwitchRoot��6   $
��Auto��5p      $
��Auto��5q       . ��5o      Z� .+�5s      � $ SwitchTrack��6#   $
��Auto��5t   #   .+�5u   "   � $ SwitchBottom��6'   $��25��5v   '   $��60��5w   '   .+�5x   &   �� $ SwitchBackground��60   $
��Auto��5y   0   $
��Auto��5z   0   $��Stretch=�5{   0   $��Stretch=�5|   0   z�5}   *   T� 5~   .   BackgroundTranslation��6A   5�   '   �� 5�   &   $��2q�6-   #���  5�   -   ._�5�   *   � $��2q�6/   .+�5�   .   �� $ checked��65   $��0q�5�   5   #��z 5�   5   $��0q�5�   5   �� 5�   .   $ border��65   $��0q�5�   5   #���  5�   5   $y�	Collapsed=�5�   5   $��0q�5�   5   �� 5�   .   $ pressed��65   $��0q�5�   5   #��� ��5�   5   $
 0.25Q�5�   5   $y�	Collapsed=�5�   5   $��0q�5�   5   �� 5�   .   $ hover��65   $��0q�5�   5   #��� ��5�   5   $
 0.15Q�5�   5   $y�	Collapsed=�5�   5   $��0q�5�   5   �� 5�   .   $ disabled��65   $��0q�5�   5   #��� ��5�   5   $	 0.5Q�5�   5   $y�	Collapsed=�5�   5   $��0q�5�   5   5�   +   5�   '   5�   #   �� 5�   "   $ SwitchThumb��6)   #��z��5�   )   $��0q�5�   )   $��0q�5�   )   $��13��5�   )   $
��Auto��5�   )   $
��Left=�5�   )   z�5�   &   V� 5�   *   .~�5�   .   �� �� 5�   .   �� 5�   .   T� 5�   .   SwitchThumbTranslate��6A   5�   +   ._�5�   &   � .+�5�   *   �� $ ThumbCenter��61   #��z��5�   1   $��0q�5�   1   #���  5�   1   �� 5�   *   $ disabledTumb��61   #��z��5�   1   $��0q�5�   1   #���  5�   1   $	 0.5Q�5�   1   $y�	Collapsed=�5�   1   5�   '   5�   #   5�      5�      5�      5�      5�      5�      �� 5�      "  
 6   .�5�   
   ��  � �� . 5�      �� 5�   
    �@
 SwitchForeground# �   5�      �� 5�   
    � ��$
 Left=�5�      �� 5�   
    � ��$ Center=�5�      �� 5�   
    � ��# �  5�      �� 5�   
    � ��$ Segoe UI Semibold)�5�      �� 5�   
    � ��$ 14.667(�5�      �� 5�   
    �@
 HeaderTemplate 5�      �� 5�      .R�5�      �� $��Normal"�5�       $
��Left=�5�       $	��Top=�5�       $��0,0,0,5q�5�       $
 0.65Q�5�       $��16(�5�       ��5�       �� $ OneWay=�5�       5�      5�      �� 5�   
    � �� 5�      �� 5�      " 
 6"   .R�5�      �� #��z��6   #��z��5�      # z��5�       5�        5�      CommonStates��. 5�   "     
Normal��6.     5�   "   Disabled��.	 5�   &   �� .��5�   *   W� $ Header��6:   $
 (UIElement.Opacity)�5�   :   $ 0D�5�   :   $	 0.3X�5�   :   W� 5�   *   $ Content��6:   $
 (UIElement.Opacity)�5�   :   $ 0D�5�   :   $	 0.3X�5�   :   W� 5�   *   $ Switch��6:   $
 (UIElement.Opacity)�5�   :   $ 0D�5�   :   $
 0.75X�5�   :   5�   '   5�   #   5�      ._�5�      �   5�      �� 5�   "   $
��Auto �60   �� 5   "   $
��Auto �60   ! 5     �� 5  "   $" firstCol��5  3   $��* �5  3   5  3   �� 5  "   $" secCol��5  3   $
��Auto �5  3   5  3   .+�5     �� $# Header��6-   $��2��5	  -   #��z$ 5
  -   #��z% 5  -   ��.  5  -   �� 5     $# Content��6-   $��1��5  -   #��z��5  -   #��z��5  -   ��.  #��z��5  -   #��z��5  -   #��z��5  -   #��z��5  -      5     $& Switch��6:   $��1��5  :   $��1��5  :   #��z��5  :   # z' 5  :   $��Center=�5  :   5     5     ( 5     �� 5     ) 6&   �� * �� *Self+$+ Header�, 5   &   Z� .a�5!     �� $- Header��6%    � y�$ 	Collapsed=�5#  %   5$     P� 5%     . �@
 ContentDirection$/ RightToLeft=�5&  "   . �5'     ��  � ��$ Right=�5(  %   �� 5)     $- firstCol��6%    � ��$
 Auto �5+  %   �� 5,     $- secCol��6%    � ��$ * �5.  %   �� 5/     $- Content��6%    � ��$ 1��51  %   �� 52     $- Switch��6%    � ��$ 0��54  %   55     57     59     5:     5;     