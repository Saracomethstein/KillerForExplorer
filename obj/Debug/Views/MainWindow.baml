   M S B A M L   `   `   `  ����L  HKillerForExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:KillerForExplorer.ViewModelsKillerForExplorer.ViewModels  5   	   "    KillerForExplorer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:KillerForExplorer.ViewModels     5   	      MainWindowStyle#���   5   	     � Title$  Killer��5	   	   $��30��5
   	   $	��200��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . 
������  � DataContext 5      6  0KillerForExplorer.ViewModels.MainWindowViewModel  5   
    J� InputBindings 5      �� 5   
    �� 	Modifiers$
 Ctrlf�5   9    �� Command 5      �� 	 �� Path$#	 KillerAndStartExplorerCommand�

 �� Key
 5      �� $	 ShortcutSymbol�69   .��5      ��  �� CornerRadius$ 10��6   
�������$��4q�5      ._�5   
   � .+�5!      �� -   5          MainLabelStyle#���  5!      $��0,0,0,0q�5"      5#      �� 5%        ExitButtonStyle#���  6   $��	170,0,0,0q�5&      $
��🗙��5'      $	��Top=�5(      $��Center=�5)      $��Center=�5*       � ToolTip$
 Exit��5,      ��5+      �� $	 ExitAppCommand�5,      �� 5.        MainButtonStyle#���  6   $��
140,0,30,0q�5/      $	��Top=�50      $
��🗕��51      $��Center=�52      $��Center=�53      $ Minimize��55      ��54      �� $	 MiniAppCommand�55      �� 57      #���  6   $��
110,0,60,0q�58      $	��Top=�59      $	��▽��5:      $��14(�5;      $��Center=�5<      $��Center=�5=      $ Minimize to tray��5?      ��5>      �� $	 MiniToTrayCommand�5?      �� 5A      #���  6   $��
30,0,140,0q�5B      $	��Top=�5C      $��	Helvetica)�5D      $��14(�5E      $��Center=�5G      $��Center=�5H      $ 
Start/Stop��5K      ��5F      �� $	 ForegroundForStartStop���5I      �� $	 StartStopButtonText���5J      �� $#	 KillerAndStartExplorerCommand�5K      �� 5M      #���  6   $��	0,0,170,0q�5N      $	��Top=�5O      $��Center=�5Q      $��Center=�5R      $ Settings��5T      ��5P      �� $	 SettingsButtonText���5S      �� $	 SettingsCommand���5U      �� $	 ForegroundForSettings�5W      5X      5Y      