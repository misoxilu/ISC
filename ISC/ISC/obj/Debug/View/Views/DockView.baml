   M S B A M L   `   `   `  ����>  :ISC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ISC.View.ViewsISC.View.Views  5      C&clr-namespace:ISC.ViewModel.ViewModelsISC.ViewModel.ViewModels  5	          ISC.View.Views.DockView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ISC.View.Views     5      5vm&clr-namespace:ISC.ViewModel.ViewModels     5	      m iXceed.Wpf.AvalonDock.Themes.Expression, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4g cXceed.Wpf.AvalonDock.Themes.Aero, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4i eXceed.Wpf.AvalonDock.Themes.VS2010, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4h dXceed.Wpf.AvalonDock.Themes.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4[	 WXceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4?dock,http://schemas.xceed.com/wpf/xaml/avalondock     	 5
        � DataContext  5      ,  &ISC.ViewModel.ViewModels.DockViewmodel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      $��2 �6   6*   �� 5      6   .+�5   
   ) 	 #Xceed.Wpf.AvalonDock.DockingManager  -   5          Name$ docking_In_Sight��5   /   $��0��6      Layout. 5      , 	 &Xceed.Wpf.AvalonDock.Layout.LayoutRoot     	RootPanel. 5      - 	 'Xceed.Wpf.AvalonDock.Layout.LayoutPanel     Orientation$ 
Horizontal=�6#   � 	 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5      ; 	 5Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePaneGroup     Orientation$ 
Horizontal=�65   � 	 �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   	DockWidth$ 1* �6N   	   
DockHeight$	 * �6]   � 	 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]
   Children.
 5      6	 	 0Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePane	  �
 	 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]] 
  Children. 5      2 	 ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable  -   5        File��   CanAutoHide .  / 	 )Xceed.Wpf.AvalonDock.Layout.LayoutContent   CanFloat .     Content. 5   "   �� $	��150��6)   $	��150��65   
���  ��6B   5      5      5        5       $ 
Horizontal=�65   $ 1* �6N   $	 * �6]   .
 5!      	  . 5"        -   5        Network��. 5$   "       ISC.View.Views.NetworkView  5&      5'      5(        5*      $ 
Horizontal=�66   $ 1* �6O   $	 * �6^   .
 5+      	  . 5,        -   5        Step�� .   .     CanClose .     CanHide .  . 5-   "      ISC.View.Views.StepView  5.      5/      50        53      $ 
Horizontal=�65   $ 4* �6N   $	 * �6]   .
 54      	  . 55         .   .   .   .  . 56   "   �� $	��150��6)   $	��150��65   
����  �6B   58      59      5:        5<      $ 
Horizontal=�65   $ 2* �6N   $	 * �6]   .
 5=      	  . 5>        -   5        Palette��. 5?   "   �� $��60��6)   $	��150��64   
����  �6A   5A      5B      5C      5E      5F      5G      �� 5H   
   $��1��6   
���   �$��2��68   $��Center=�6C   $��Stretch=�6^   �� 5I   
   ��6   �� *StepContent+5J      5K      