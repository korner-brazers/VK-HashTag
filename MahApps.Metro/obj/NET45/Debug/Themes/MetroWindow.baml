   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=0.12.1.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MahApps.Metro.ControlsMahApps.Metro.Controls  5      C&clr-namespace:MahApps.Metro.ConvertersMahApps.Metro.Converters  5      C&clr-namespace:MahApps.Metro.BehavioursMahApps.Metro.Behaviours  5      C&clr-namespace:MahApps.Metro.ConvertersMahApps.Metro.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source    BooleanToVisibilityConverter/    )MahApps.Metro.Converters.ToUpperConverter  ToUpperConverter  WindowTemplateKey �� 
TargetType(   "MahApps.Metro.Controls.MetroWindow'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� 	BeginTime �� TargetProperty �� 
TargetName	 O� KeyTime
 O� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode0   *MahApps.Metro.Controls.MetroContentControl   OnlyLoadTransition   WindowTransitionsEnabled   TransitionsEnabled � FocusVisualStyle � ColumnDefinitions � RowDefinitions ��Name  WindowTitleColorBrush �� RelativeSource �� Mode �� 	Converter ��Name K� ZIndex � Icon   IconTemplate ��Name  ControlBackgroundBrush J� Opacity � Title   TitleTemplate>	   8MahApps.Metro.Converters.BackgroundToForegroundConverter 	  Instance  `� 	Converter! �� ElementName" �� Path1
   +MahApps.Metro.Controls.WindowButtonCommands# 
 Name-  'System.Windows.Input.KeyboardNavigation$   TabNavigation% �Name& ��Name' ��Name( � 	Resources  Key) g� AccelerationRatio* g� 
SpeedRatio	+ W� To, �� Triggers- ]� 
Conditions. �� Value/ �� Property0 �� 
TargetName1 �� Property2 �� Value3 �� 
TargetType  ContentFontSize  
WhiteBrush  
BlackBrush 	 MetroWindowButtonStyle0   *MahApps.Metro.Behaviours.StylizedBehaviors9   3MahApps.Metro.Behaviours.StylizedBehaviorCollection7   1MahApps.Metro.Behaviours.BorderlessWindowBehavior6   0MahApps.Metro.Behaviours.WindowsSettingBehaviour1   +MahApps.Metro.Behaviours.GlowWindowBehavior 
 WindowTitleFontSize  HeaderFontFamily4 �� Triggers5 �� Binding6 �� 	Converter7 �� Value.   (MahApps.Metro.Converters.IsNullConverter8   Instance9 �� EdgeMode: �� BitmapScalingMode+   %MahApps.Metro.Controls.WindowCommands  TransparentWhiteBrush; J� SnapsToDevicePixels< J� IsHitTestVisible= P� Property> P� Value? �� AncestorType@ �� OrientationA ��NameB � ToolTipC F�Name�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1Controls$clr-namespace:MahApps.Metro.Controls  5      /conv&clr-namespace:MahApps.Metro.Converters  5      5
Behaviours&clr-namespace:MahApps.Metro.Behaviours  5      5
Converters&clr-namespace:MahApps.Metro.Converters  5        5      �� 5	   
   $S Mpack://application:,,,/MahApps.Metro;component/Styles/Controls.TextBlock.xaml?�6   %/0  &	        &	      &	 &     7   7   7   7   7   '  M    7  7  7  '  
    '
  &    7   7   7   �� 5      6#      5      6   �� 5      "  5      .R�5   
   �  5        5      LayoutStates��. 5        AfterLoaded��. 5      �� .��5      U� $ 00:00:00X�6<   $ (UIElement.Opacity)�5   <   $ PART_Border��5   <   .\�5   "   �� $	 00:00:00��67   $
 0Q�5   7     5   "   $	 00:00:00.600��67   $
 1Q�5   7    5   &     5   *   $ EaseIn=�64   5    #   5!      5"      5#        5$      BeforeLoaded��6"     5%      BeforeUnloaded��6"   5&      .+�5)      �� .u�5*        ��.   . # z 5-   /    5+   /   Z� .��5.      � #��z��6    5/      �� 51      $
��Auto �6/   �� 53      $
��Auto �6/   �� 55      $��* �6/   �� 57      $
��Auto �6/   �� 59      $
��Auto �6/    5;      �� 5<      $
��Auto �6,   �� 5=      $��* �6,   .+�5@      �� $  PART_WindowTitleBackground��6$   #���  5A   $   $��0��5D   $   $��5��5E   $   $��0��5F   $   ��5B   $   �� *TitlebarHeight+ �� *TemplatedParent+$ OneWay=�y�5C   $   �� *ShowTitleBar+8   5F   $   �� 5I      $ 	PART_Icon��6)   $��0��5J   )   $��0��5K   )   $ 1��5L   )   #��z 5M   )   #��z 5N   )   $��Stretch=�5O   )   $��Stretch=�5P   )   ��5Q   )   �� *TitlebarHeight+ �� *TemplatedParent+$ OneWay=���5R   )   �� *TitlebarHeight+ �� *TemplatedParent+$ OneWay=�y�5S   )   �� *ShowIconOnTitleBar+8  �� 5V      $ PART_LeftWindowCommands��6+   $ 1��5X   +   $��0��5Y   +   $��1��5Z   +   $��2��5[   +   $	��Top=�5\   +   ��5W   +   �� *LeftWindowCommands+ �� *TemplatedParent+$ OneWay=���5]   +   �� *TitlebarHeight+ �� *TemplatedParent+$ OneWay=�y�5^   +   �� *ShowTitleBar+8  �� 5a      $��1��6+   $��0��5b   +   $��5��5c   +   �� 5f      $��PART_FlyoutModal��5j   $   $��0��5f   $   $��2��5g   $   $��4��5h   $   $��0��5i   $   #���  5k   $   $	 0.5Q�5l   $   $y�Hidden=�5m   $   �� 5p      $ PART_TitleBar��6)   $��0��5q   )   $��2��5r   )   #��z 5s   )   #��z 5t   )   $��Stretch=�5u   )   $��Stretch=�5v   )   ��5w   )   �� *TitlebarHeight+ �� *TemplatedParent+$ OneWay=�y�5x   )   �� *ShowTitleBar+8  ��5y      `� 5z   "   #  Z 6/   .1�5{   &   �� $ ! PART_WindowTitleBackground��6.   $
" Fill�5|   .   $ OneWay=�5}   .   �� 5~   &   $" TitleForeground�5   .   $ OneWay=�5�   .    5~   .   �� *TemplatedParent+5�   .   5�   #   5�      �� 5�      $ PART_RightWindowCommands��6+   $ 1��5�   +   $��0��5�   +   $��3��5�   +   $��2��5�   +   $	��Top=�5�   +   ��5�   +   �� *RightWindowCommands+ �� *TemplatedParent+$ OneWay=���5�   +   �� *TitlebarHeight+ �� *TemplatedParent+$ OneWay=�y�5�   +   �� *ShowTitleBar+8  
  5�      $# PART_WindowButtonCommands��68   $ 1��5�   8   $��0��5�   8   $��4��5�   8   $��2��5�   8   $	��Top=�5�   8   ��5�   8   �� *TitlebarHeight+ �� *TemplatedParent+$ OneWay=��� 5�      $��0��6)   $��0��5�   )   $��5��5�   )   $��2��5�   )   $ 2��5�   )   |�.  $
$ None=�5�   )   $��Stretch=�5�   )   ��5�   )   �� *	Flyouts+ �� *TemplatedParent+$ OneWay=�5�   )   � 5�      $% PART_OverlayBox��5�      $��0��5�      $��0��5�      $��5��5�      $��2��5�      $ 3��5�      #���  5�      $ 0Q�5�      $y�Hidden=�5�       5�      Z� 5�      � 5�      $% PART_MetroDialogContainer��5�      $��0��5�      $��0��5�      $��5��5�      $��2��5�      $ 4��5�       5�      Z� 5�      5�      5�      5�      �� 5�      $& PART_Border��6   $ 0Q�5�      #��z��5�      #��z��5�      $��Stretch=�5�      $��Stretch=�5�      �� 5�      $' WindowResizeGrip��6   $��Right=�5�      ��.  $y�	Collapsed=�5�      $��Bottom=�5�      5�      ( 5�   
   ���� 5�      OverlayFastSemiFadeIn $ 0:0:0X�5�      $	) .97Q�5�      $ Opacity�5�      $	* 2.7Q�5�      .��5�      W� $+ .7X�6"   5�      �� 5�      OverlayFastSemiFadeOut $ 0:0:0X�5�      $	) .97Q�5�      $ Opacity�5�      $	* 2.7Q�5�      .��5�      W� $	+ 0.0X�6"   5�      5�      , 5�   
   ]� 5�      - 5�      �� 5�      . 5�       Z� / �@�Icon�� 5�      . 5�       Z� / �@ IconTemplate./�5�      �� $0 	PART_Icon��6   1 � y�$2 	Collapsed=�5�      �� 5�      $0 	PART_Icon��6   1 � ��$2 0��5�      5�      ]� 5�      - 5�      �� 5�      / �@�
ResizeMode$. CanResizeWithGrip=�5�       �� 5�      / �@�WindowState$. Normal=�5�       ./�5�      �� $0 WindowResizeGrip��5�      1 � y�$2 Visible=�5�      5�      5�      �� 5�      "3  6   .�5�   
   �� 1 � ��#2 �  5�      �� 5�   
   1 � ��#2 �  5�      �� 5�   
   1 � ��#2 �  5�      �� 5�   
   1 �@ WindowMinButtonStyle#2 � 	 5�      �� 5�   
   1 �@ WindowMaxButtonStyle#2 � 	 5�      �� 5   
   1 �@ WindowCloseButtonStyle#2 � 	 5     �� 5  
   1 �@ 	Behaviors2 5       5       5       5       5     5     5
     �� 5  
   1 �@ TitleForeground
2 �����5     �� 5  
   1 � ��82   5     �� 5  
   1 �@ TitleTemplate2 5     �� 5     .R�5     �� #��z��6    $��CharacterEllipsis=�5      $��Center=�5      $��8 -1 0 0q�5      #��� 
 5      #���  5      5     5     4 5  
   �� 5     5 6   ��  �� *Self+$" 	TitleCaps�$ OneWay=�86  7 True5     .a�5     �� 1 �@ TitleTemplate2 5     �� 5      .R�5!     �� $��CharacterEllipsis=�5"  (   $��Center=�5#  (   $��8 -1 0 0q�5$  (   #��� 
 5%  (   #���  5&  (   ��5!  (   ��  �� *TemplatedParent+$" Content�86  5&  (   5'     5)     5*     �� 5+     5 6   ��  �� *Self+$
" Icon�$ OneWay=�#6 Z8 	7 False5,     .a�5-     �� 1 �@ IconTemplate2 5.     �� 5/     .R�50     �� #��z��6$   #��z��51  $   #��z��52  $   $9 Aliased=�53  $   $: HighQuality=�54  $   55     57     58     5:     �� 5<     "3  6   .�5=  
   �� 1 � ��#2 �  5>     �� 5?  
   1 � ��2 .  5@     �� 5A  
   1 � ��$2 Center=�5B     �� 5C  
   1 �@�FocusVisualStyle2 5D     Z� �� 5E  
   1 � ��2 5F     �� 5G     "  6"   ( 5H     �� 5I     �� 5J     '��       "3 ��6$   .�5K  "   �� 1 � ��#2 �  5L  )   �� 5M  "   1 � ��$2 Center=�5N  )   �� 5O  "   1 � ��$2 Center=�5P  )   �� 5Q  "   1 � ��$2 1q�5R  )   �� 5S  "   1 �@�FocusVisualStyle2 5T  )   Z� �� 5U  "   1 � ��2 5V  &   �� 5W  *   " ��6:   .R�5X  .   � #��z��63   .+�5Y  2   �� $ contentPresenter��6C   #��z��5Z  C   #��z��5[  C   #; z; 5\  C   ��. $
 0.75Q�5^  C   $��9,1,9,1q�5_  C   �� 5a  2   $ border��6<   ; . < .  $
 0.25Q�5d  <   $��1��5e  <   $��15��5f  <   $��Stretch=�5g  <   $��Right=�5h  <   #��z��5i  <   $��8,0,0,0q�5j  <   5k  /   , 5l  .   P� 5m  2   = �@J�IsMouseOver> . . �5o  6   �� $0 contentPresenter��6=   1 �@J�Opacity$2 1Q�5q  =   5r  3   P� 5s  2   = �@J�IsMouseOver> .  . �5u  6   �� $0 contentPresenter��6=   1 �@J�Opacity$2 .5Q�5w  =   5x  3   P� 5y  2   = � {�> .  . �5{  6   �� 1 � ��2 �#ADADAD5|  =   5}  3   5  +   5�  #   4 5�  "   �� 5�  &   5 62   �� *ShowTitleBar+ �� *FindAncestor+"?  7 True5�  2   .a�5�  *   �� 1 � ��
2 �����5�  1   5�  '   5�     �� 5�     'd�       "3 d�6$   .�5�  "   �� 1 � ��#2 �  5�  )   �� 5�  "   1 � ��$2 Center=�5�  )   �� 5�  "   1 � ��$2 Center=�5�  )   �� 5�  "   1 � ��$2 1q�5�  )   �� 5�  "   1 �@�FocusVisualStyle2 5�  )   Z� �� 5�  "   1 � ��2 5�  &   �� 5�  *   " d�6:   .R�5�  .   � #��z��63   .+�5�  2   �� $ contentPresenter��6C   #��z��5�  C   #��z��5�  C   #; z; 5�  C   ��. $ .5Q�5�  C   $��9,1,9,1q�5�  C   �� 5�  2   $ border��6<   ; . < .  $ .2Q�5�  <   $��1��5�  <   $��15��5�  <   $��Stretch=�5�  <   $��Right=�5�  <   #��z��5�  <   $��8,0,0,0q�5�  <   5�  /   , 5�  .   P� 5�  2   = �@J�IsMouseOver> . . �5�  6   �� $0 contentPresenter��6=   1 �@J�Opacity$2 1Q�5�  =   5�  3   P� 5�  2   = �@d�	IsChecked$
> trueY�5�  :   . �5�  6   �� $0 contentPresenter��6=   1 �@J�Opacity$2 1Q�5�  =   5�  3   P� 5�  2   = � {�> .  . �5�  6   �� 1 � ��2 �#ADADAD5�  =   5�  3   �� 5�  2   $
7 True��5�  >   5 5�  >   �� *ShowTitleBar+ �� *FindAncestor+"?  .a�5�  6   �� 1 � ��
2 �����5�  =   5�  3   5�  +   5�  #   5�     5�     .R�5�     �� ��.  ��5�  #   �� *TitlebarHeight+ �� $? Controls:MetroWindowL���5�  #   �� *Items+ �� *FindAncestor+"?  ��5�     �� 5�     .R�5�  "   �� $@ 
Horizontal=�6-   5�     5�     5�     5�     4 5�  
   �� 5�     5 6   �� *ShowTitleBar+ �� *FindAncestor+"?  7 True5�     .a�5�     �� 1 � ��
2 �����5�     5�     �� 5�     5 6   �� *ShowTitleBar+ �� *FindAncestor+"?  	7 False5�     .a�5�     �� 1 � ��
2 ���� 5�     5�     5�     �� 5�     "3 
 6   .�5�  
   �� 1 � ��#2 �  5�     �� 5�  
   1 � ��2 .  5�     �� 5�  
   1 � ��$2 Center=�5�     �� 5�  
   1 �@�FocusVisualStyle2 5�     Z� �� 5�  
   1 � ��2 5�     �� 5�     " 
 6"   .R�5�     �� $@ 
Horizontal=�6!   .+�5�     �� $A PART_Min��6!   #��z��5�  !   ��5�  !   �� *TitlebarHeight+$ OneWay=� �� $? Controls:MetroWindowL���5�  !   �� *WindowMinButtonStyle+$ OneWay=� �� *FindAncestor+"?  B 5�  !   �� *
Minimize+ �� *FindAncestor+"? 
 y�5�  !   �� *ShowMinButton+ �� *FindAncestor+"?  86   .��5�     F� 4����    ��[ �    @T� �@T� @T� �@T� ��[ �    ��[ ; . #��z��5�  #   5�     �� 5�     $A PART_Max��6!   #��z��5  !   ��5   !   �� *TitlebarHeight+$ OneWay=� �� $? Controls:MetroWindowL���5  !   �� *WindowMaxButtonStyle+$ OneWay=� �� *FindAncestor+"?  B 5  !   �� *
Maximize+ �� *FindAncestor+"? 
 y�5  !   �� *ShowMaxRestoreButton+ �� *FindAncestor+"?  86  .��5     � .+�5  "   F� $C MaximisePath��6'   ; . a����        �    @T� �@T� @T� �@T�     �        �    ��- � z ��- � z  z �@B  z �@B ��- #��z��5	  '   F� 5
  "   $C RestorePath��6'   ; . �����    ��� �    ��- ���- ��- ���-     р��     р�� �� � 	= �� � 	= ��- ���j ��- ���j ��[ р�[ ��[ р�[ @KL �@B @KL �@B ��� �@B ��� ���j ��� ���j ��j р�� ��j р�� �� �@T� �� �@T� ��[ р�[ ��[ р�[ @T� �@B @T� #��z��5  '   5     5     �� 5     $A 
PART_Close��6!   #��z��5  !   ��5  !   �� *TitlebarHeight+$ OneWay=� �� $? Controls:MetroWindowL���5  !   �� *WindowCloseButtonStyle+$ OneWay=� �� *FindAncestor+"?  B 5  !   �� *Close+ �� *FindAncestor+"? 
 y�5  !   �� *ShowCloseButton+ �� *FindAncestor+"?  86  .��5     F� |����        р�     �@KL ��- � z     р��     р�[  	= р��  z � z  z �@KL @KL р�  z �     z � 	=  	= �        ; . #��z��5  #   5     5     5     5     4 5   
   �� 5!     5 6   �� *ShowTitleBar+ �� *FindAncestor+"?  7 True5"     .a�5#     �� 1 � ��
2 �����5$     5%     �� 5&     5 6   �� *ShowTitleBar+ �� *FindAncestor+"?  	7 False5'     .a�5(     �� 1 � ��
2 ���� 5)     5*     5,     5-     