   M S B A M L   `   `   `  ����>  :ISC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ISC.ViewModelISC.ViewModel  5      /clr-namespace:ISC.View.ViewsISC.View.Views  5           ISC.View.Views.NetworkView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *vmclr-namespace:ISC.ViewModel     5      .localclr-namespace:ISC.View.Views     5        � DataContext  5
      $   ISC.ViewModel.NetworkViewmodel  5   
    � 	Resources 5         TreeViewItem �� ItemsSource  
GreenColor �� ItemTemplate  
BlueColor2��%�  &	        7  7  �� 5   
    69   �� *SensorItems+.R�5      ]� ��. $��Center=�6-   $��5,0,0,0q�6H   .+�5      �� $��5,0,0,0q�6   $
��Left=�6-   $��Center=�6C   $
��Bold"�6^   8��  ��6�   �� *Name+5       5      �� 5      .R�5      ]� ��. $��Center=�65   $��10,0,0,0q�6P   .+�5      �� $
��Left=�6$   8�� $��Center=�6d   $��5,0,0,0q�6�   ��6   �� *Name+6�   5      5      5      5      .��5      � .+�5   
   R� #��[  68   $	��180��6e   $	��250��6q   
 �� Top$ 86��6~    �� Left$ 30��6�   ��6   �� *SensorGroups+6�   5      5      