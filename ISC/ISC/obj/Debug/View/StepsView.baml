   M S B A M L   `   `   `  ����  ISC    ISC.View.StepsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      .��5
      �� -   5          ��Name$  
StackPanel��5
       �� Orientation$ Vertical=�6%   .+�5   
   �� $��1.开始��6   $��5q�6    �� 5   
   $��0��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��5      �� $ 
Horizontal=�6   .+�5      �� $
��Fill=�6    
  I_Blob#��[  6'   �� 5      $��	已连接��6   $��5q�6'   y�62   �� *
Visibility+5      5      �� 5   
   {�.  $��1��6C   $��30��6X   $��5q�6d   ��6   �� *SwitchSteps+��6o   �� *HorizontalAlignment+.��5      �� $ 
Horizontal=�6   .+�5      �� $
��Fill=�6   #��[  6'   {�.  6H   �� 5      $��设置图象��6   $��5q�6(   y�63   �� *
Visibility+5      5      �� 5   
   $��2.设置工具��6   $��5q�6"   �� 5   
   $��2��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��5      �� $ 
Horizontal=�6   .+�5      �� $
��Fill=�6   #��[  6'   �� 5      $��定位部件��6   $��5q�6(   y�63   �� *
Visibility+5      5       �� 5"   
   $��3��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��5#      �� $ 
Horizontal=�6   .+�5$      �� $
��Fill=�6   #��[  6'   �� 5%      $��检查部件��6   $��5q�6(   y�63   �� *
Visibility+5&      5'      �� 5)   
   $��3.配置结果��6   $��5q�6"   �� 5*   
   $��4��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��5+      �� $ 
Horizontal=�6   .+�5,      �� $
��Fill=�6   #��[  6'   �� 5-      $��输入��6   $��5q�6&   y�61   �� *
Visibility+5.      5/      �� 51   
   $��5��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��52      �� $ 
Horizontal=�6   .+�53      �� $
��Fill=�6   #��[  6'   �� 54      $��输出��6   $��5q�6&   y�61   �� *
Visibility+55      56      �� 58   
   $��6��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��59      �� $ 
Horizontal=�6   .+�5:      �� $
��Fill=�6   #��[  6'   �� 5;      $��通信��6   $��5q�6&   y�61   �� *
Visibility+5<      5=      �� 5?   
   $��4.完成��6   $��5q�6    �� 5@   
   $��7��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��5A      �� $ 
Horizontal=�6   .+�5B      �� $
��Fill=�6   #��[  6'   �� 5C      $��胶片��6   $��5q�6&   y�61   �� *
Visibility+5D      5E      �� 5G   
   $��8��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��5H      �� $ 
Horizontal=�6   .+�5I      �� $
��Fill=�6   #��[  6'   �� 5J      $��保存作业��6   $��5q�6(   y�63   �� *
Visibility+5K      5L      �� 5N   
   $��9��61   $��30��6F   $��5q�6R   ��6   �� *SwitchSteps+��6]   �� *HorizontalAlignment+.��5O      �� $ 
Horizontal=�6   .+�5P      �� $
��Fill=�6   #��[  6'   �� 5Q      $��运行作业��6   $��5q�6(   y�63   �� *
Visibility+5R      5S      .  (System.Windows.Interactivity.Interaction   Triggers 5U   
   /  )System.Windows.Interactivity.EventTrigger  5V         	EventName$ SizeChanged��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5W      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6(   �� *StackPanelSizeChanged+   CommandParameter 6R   ��  �� ElementName$ 
StackPanel��5X      5Z      5[      