   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      I EMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MahApps.Metro.ControlsMahApps.Metro.Controls 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089    BooleanToVisibilityConverter  �� 
TargetType  MetroComboBox �� Property �� Value  	TextBrush  GrayBrush10  TextBoxBorderBrush  ContentFontFamily  ContentFontSize  MetroComboBoxItem  ValidationErrorTemplate �� 
TargetType � 	Resources 	 Key'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration   States   System.Windows.VisualState	   
Storyboard
 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime 
 
GrayNormal �� Value  
WhiteColor ��Name ��Name  
WhiteBrush J� IsHitTestVisible J� Opacity  AccentColorBrush4 �� 
StartPoint �� EndPoint  AccentColor4 � Color � Offset % !ComboBoxMouseOverInnerBorderBrush  HighlightBrush � ColumnDefinitions �� RelativeSource �� AncestorType �� Path �� Mode ��Name  ChromelessButtonStyle �� 	Converter F�Name  J� SnapsToDevicePixels! �� Stretch" �� Triggers# P� 
SourceName$ P� Property% P� Value& �� 
TargetName  GrayNormalBrush  
GrayBrush8  AccentColorBrush  
BlackBrush' g� Duration( R� KeyTime) R� Value  System.Windows.Visibility* d�Name  comboToggleStyle-  'System.Windows.Input.KeyboardNavigation+   	IsTabStop, d� 	IsChecked  ControlBackgroundBrush- ��Name*  $MahApps.Metro.Controls.TextboxHelper.   	Watermark/ �� 
IsReadOnly0 �� 
IsReadOnly1 �Name2 �� SelectionBoxItemTemplate3 �� SelectionBoxItem#4 �� SelectionBoxItemStringFormat5 �� ContentStringFormat  DisabledWhiteBrush6 �Name7 � AllowsTransparency  DropShadowBrush8 J� Effect  ComboBoxPopupBrush9 ��Name: ��Name;   DirectionalNavigation< �� Value= �� Binding  TransparentWhiteBrush> ��Name  AccentSelectedColorBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1System&clr-namespace:System;assembly=mscorlib  5      1Controls$clr-namespace:MahApps.Metro.Controls  5      %;'  &	        &	      7   &	 �    �� 5      6#   �� 5      "  ��6   .�5
   
   ��  � ��$ 26��5      �� 5   
    � ��# �  5      �� 5   
    � ��# �  5      �� 5   
    � ��$
 Left=�5      �� 5   
    � ��$ Center=�5      �� 5   
    � ��$ 1q�5      �� 5   
    � ��$ 0q�5      �� 5   
    � ��$
 Auto=�5      �� 5   
    � ��$
 Auto=�5      �� 5   
    � ��# �  5      �� 5   
    � ��# �  5      �� 5    
    � ��# �  5!      �� 5"   
    � ��# �  5#      �� 5%   
    �@J�SnapsToDevicePixels . 5&      �� 5'   
    �@=�ErrorTemplate# �  5(      �� 5)   
    � �� 5*      �� 5+      " ��6"   .R�5,      �  5-      ���� 5.      comboToggleStyle	 "  d�5/   $   .�50   "   ��  � ��# �  51   )   �� 52   "    � ��# �  53   )   �� 54   "    � ��# �  55   )   �� 56   "    � ��$ 1q�57   )   �� 58   "    � ��$ 3q�59   )   �� 5:   "    � �� 5;   &   �� 5<   *   " d�6:   .R�5=   .   �  5>   2     5?   6   CommonStates�� 5@   :     5A   >   $ 0:0:0.2D�6O   . 5C   :     
Normal��6F     5D   :   	MouseOver��.	 5E   >   �� .��5F   B   U� $
 (UIElement.Opacity)�6`   $ MouseOverBorder��6�   .\�5G   F     $ 0��6[   $ 1Q�6g   5H   C   �� 5J   B   $P
 J(Border.BorderBrush).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6_   $ MouseOverBorder��5K   G   .g�5L   F     $ 0��6Z   # � 
 6f   5M   C   �� 5O   B   $G
 A(Path.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6_   $ BtnArrow��5P   G   .g�5Q   F     $ 0��6Z   # �  6f   5R   C   5S   ?   5T   ;     5U   :   Pressed��.	 5V   >   �� .��5W   B   U� $
 (UIElement.Opacity)�6`   $ PressedBorder��5X   `   .\�5Y   F     $ 0��6[   $ 1Q�5Z   [   5[   C   5\   ?   5]   ;     5^   :   Disabled��6F   5_   7     5`   6   FocusStates��. 5a   :     Focused��.	 5b   >   �� .��5c   B   U� $
 (UIElement.Opacity)�6`   $ FocusRectangle��5d   `   .\�5e   F     $ 0��6[   $ 1Q�5f   [   5g   C   5h   ?   5i   ;     5j   :   	Unfocused��6F   5k   7   .+�5o   2   �� $ 
Background��69   #��z��5p   9   #��z��5q   9   #��z��5r   9   �� 5s   2   $ DisabledVisualElement��6<   #���  5t   <    .  $ 0Q�5v   <   �� 5w   2   $ MouseOverBorder��69   #���  5x   9   #��z��5y   9   $ 0Q�5z   9   ��5{   6   �� 5|   :   $	 0,9&�6N   $	 0,1&�6_   ��5~   B   � � 5   F   # �  6S   $	 0.0Q�6z   � 5�   F   # � 
 6S   $	 1.0Q�6x   5�   C   5�   ;   5�   3   �� 5�   2   $ PressedBorder��69   #���  5�   9   #��z��5�   9   $ 0Q�5�   9   �� 5�   2   $ FocusRectangle��6<   #���  5�   <   $ 0Q�5�   <   �� 5�   2   $ FocusVisualElement��6<    .  $��1q�5�   <   #���  5�   <   $��1��5�   <   $y�	Collapsed=�5�   <   � 5�   2   $��1q�67    5�   6   �� 5�   :   $��* �6K   �� 5�   :   ��6K   ��  �� *FindAncestor+" �$ ActualHeight�$ OneWay=��� 5�   :   ��6K   ��  �� *FindAncestor+" �$ ActualHeight�$ OneWay=�.+�5�   6   �� $ PART_ClearText��6=   $��1��5�   =   $��16(�5�   =   #���  5�   =   #��z��5�   =   $��Marlett)�5�   =   $��r��5�   =   ��.  y�5�   =   ��  �� " ��$. ((Controls:TextboxHelper.ClearTextButton)�8   5�   =   �� 5�   6   $ BtnArrowBackground��6@   $��2��5�   @   
������ $��0��5�   @   F� 5�   6   $ BtnArrow��6;   $��2��5�   ;    .  #  z  5�   ;   +���� ��v���P.��v���8�BІ�� ��v��$��Center=�5�   ;   $��4��5�   ;   $! Uniform=�5�   ;   $��8��5�   ;   ��5�   :   �� 5�   >   $	 0,9&�6R   $	 0,1&�6c   ��5�   F   � � 5�   J   # �  6W   $	 0.0Q�6~   � 5�   J   # � 
 6W   $	 1.0Q�6|   5�   G   5�   ?   5�   7   5�   3   5�   /   " 5�   .   P� 5�   2   $# BtnArrowBackground��6:   $ �@J�IsMouseOver% . . �5�   6   �� $& BtnArrowBackground��6=   # �  6m    � ��5�   3   P� 5�   2   $# PART_ClearText��6:   $ �@J�IsMouseOver% . . �5�   6   �� $& PART_ClearText��6=   # �  6o    � ���� 5�   6   $& PART_ClearText��6=   # �  6p    � ��5�   3   P� 5�   2   $# PART_ClearText��6:   $ � ��% . . �5�   6   �� $& PART_ClearText��6=   # �  6o    � ���� 5�   6   $& PART_ClearText��6=   # �  6o    � ��5�   3   5�   +   5�   #   5�      5�       5�        5�      CommonStates��. 5�   "     
Normal��6.     5�   "   	MouseOver��6.     5�   "   Disabled��.	 5�   &   �� .��5�   *   U� $
 (UIElement.Opacity)�6H   $ DisabledVisualElement��5�   H   .\�5�   .   �� $ 00:00:00��6C   $
 0.45Q�5�   C   5�   +   5�   '   5�   #   5�        5�      FocusStates��. 5�   "     Focused��.	 5�   &   �� .��5�   *   U� $
 (UIElement.Opacity)�6H   $ FocusRectangle��5�   H   .\�5�   .     $ 0��6C   $ 1Q�5�   C   5�   +   5�   '   5�   #     5�   "   	Unfocused��6.     5�   "   FocusedDropDown��.	 5�   &   �� .��5�   *   T� $' 00:00:00D�6H   $
 (UIElement.Visibility)�5�   H   $ PopupBorder��5�   H   ..�5�   .   i� $( 00:00:00��6E   ) 5�   2    5�   6   Visible=�6J   5�   /   5�   +   5�   '   5�   #   5�      .+�5�      �  5�      �� 5�   "   $��* �63   �� 5�   "   ��63   ��  �� *FindAncestor+" �$ ActualHeight�$ OneWay=��� 5�   "   ��63   ��  �� *FindAncestor+" �$ ActualHeight�$ OneWay=�.+�5�      d� $* PART_DropDownToggle��6+   $��3��5   +   #��z��5  +   #��z��5  +   #��z��5  +   $��0q�5  +   #���  5  +   $��Stretch=�5  +   + .  , 5  +   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+5  +   �� 5
     $ EditableTextBoxBorder��6%   $y�	Collapsed=�5  %   
������ $��1,1,0,1q�5  %   $��0,0,-2,0q�5  %   #���  5  %   ._�5  "   �� $- PART_EditableTextBox��6*   $��Stretch=�5  *   #  z  5  *   #��z��5  *   $��0q�5  *   $��0,0,0,-2q�5  *   #. z. 5  *   #��z��5  *   |�. #0 z/ 5  *   #��z��5  *   #��z��5  *   ��5  *   Z� 5  *   5     � 5     $1 ContentSite��6#   $��7 0 0 0q�5  #   .+�5   "   �� #��z2 63   #��z��5!  3   #��z3 5"  3   #5 z4 5#  3   #��z��5$  3    .  #��z��5&  3   #  z  5'  3   #��z��5(  3   5)     5*     �� 5+     $ FocusRectangle��6$   #���  5,  $   $ 0Q�5-  $   �� 5.     $ DisabledVisualElement��6$   #���  5/  $    .  $ 0Q�51  $   � 53     $6 
PART_Popup��6    7 . |�.  #��� .�57      $��Bottom=�5:      ��56      �� *IsDropDownOpen+ �� *TemplatedParent+��58      �� *ActualWidth+ �� *TemplatedParent+��59      �� *MaxDropDownHeight+ �� *TemplatedParent+.��5;     �� $ PopupBorder��6%   #8 �  5<  %   #��z��5=  %   $��Stretch=�5>  %   $
��Auto��5?  %   #���  5@  %   #���  5A  %   ._�5B  "   �� $9 DropDownScrollViewer��6/   $��0q�5C  /   $��2q�5D  /   $��1q�5E  /   .��5F  &   �� $: ItemsPresenter��65   $; 	Contained=�5G  5   5H  #   5I     5J     5K     " 5L     �� 5M     $< False��5N  &   = 5M  &   ��  �� *Self+$. ((Controls:TextboxHelper.ClearTextButton)�.a�5O     �� $& EditableTextBoxBorder��6%    � ��$ 2��5Q  %   �� 5R     $& ContentSite��6%    � ��$ 2��5T  %   5U     P� 5V     $ �@��
IsEditable% . . �5X     ��  � �� .  5Y  %   �� 5Z     $& EditableTextBoxBorder��6%    � y�$ Visible=�5\  %   �� 5]     $& ContentSite��6%    � y�$ Hidden=�5_  %   �� 5`     $& PART_DropDownToggle��6%    � |� .  5b  %   5g     P� 5i     $# PART_DropDownToggle��6"   $ �@d�	IsChecked$
% TrueY�6X   . �5j     �� # �  6<    � ���� 5k     # �  6;    � ��5l     5n     5p     5q     �� 5s     "  ��6   .�5u  
   ��  � ��# �  5v     �� 5w  
    � ��$ 2q�5x     �� 5y  
    � ��$
 Left=�5z     �� 5{  
    � ��$	 Top=�5|     �� 5}  
    � ��# �  5~     �� 5  
    � ��$ 1q�5�     �� 5�  
    � �� 5�     �� 5�     " ��6"   .R�5�     � #��z��6   $��0,0.5q�5�      5�       5�     CommonStates��. 5�  "     
Normal��6.     5�  "   	MouseOver��.	 5�  &   �� .��5�  *   U� $
 (UIElement.Opacity)�6H   $ MouseOverRectangle��5�  H   .\�5�  .     $ 0:0:0.1��6C   $	 .65Q�5�  C   5�  +   5�  '   5�  #     5�  "   Disabled��.	 5�  &   �� .��5�  *   U� $
 Opacity�6H   $ contentPresenter��5�  H   .\�5�  .   �� $ 0��6C   $	 .55Q�5�  C   5�  +   5�  '   5�  #   5�       5�     SelectionStates��. 5�  "     
Unselected��6.     5�  "   Selected��.	 5�  &   �� .��5�  *   U� $
 (UIElement.Opacity)�6H   $ SelectedRectangle��5�  H   .\�5�  .     $ 0:0:0.1��6C   $ 1Q�5�  C   5�  +   5�  '   5�  #   5�       5�     FocusStates��. 5�  "     Focused��.	 5�  &   �� 5�  #     5�  "   	Unfocused��6.   5�     .+�5�     �� $ SelectedRectangle��6$    .  $ 0Q�5�  $   #���  5�  $   �� 5�     $ MouseOverRectangle��6$    .  $ 0Q�5�  $   #���  5�  $   �� 5�     #��z��6)   .��5�     �� $> contentPresenter��6/   #��z��5�  /   #��z��5�  /   5�     �� 5�     $ FocusVisualElement��6$   #���  5�  $   $��1��5�  $   $y�	Collapsed=�5�  $   5�     " 5�     P� 5�     $ �@��
IsSelected% . . �5�     �� # �  6;    � ��5�     P� 5�     $ �@J�IsMouseOver% . . �5�     �� # �  6;    � ��5�     5�     5�     5�     5�     