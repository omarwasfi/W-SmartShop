   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI  5          WPF_GUI.ModifyStockUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WPF_GUI     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   (   $��299.227��6�   .��5	      � $��0,0,0,10q�6   .+�5
   
   �� $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
10,141,0,0q�6p     J� RenderTransformOrigin$  0.053,0.361&�6�   $��25(�6�   �� 6�   $�Quantity : ��6�   6�   �� 5   
   -   5         ��Name$! QuantityValue_ModifyStockUC��5      $
��Left=�69   $��33��6T   $��212,141,0,0q�6`    �� TextWrapping$
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $��76��6�   $  0.544,-0.652&�6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��	10,61,0,0q�6p   $  0.053,0.361&�6�   $��25(�6�   �� 6�   $�Product Name : ��6�   6�   �� 5   
   -   5        $$ ProductNameValue_ModifyStockUC��5       �� 
IsReadOnly . $
��Left=�6N   $��33��6i   $��
212,61,0,0q�6u   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��578��6�   $  0.544,-0.652&�6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��	10,23,0,0q�6p   $  0.053,0.361&�6�   $��25(�6�   �� 6�   $�	Store :  ��6�   6�   �� 5   
   -   5        $" StoreNameValue_ModifyStockUC��5       . $
��Left=�6K   $��33��6f   $��
212,23,0,0q�6r   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��222��6�   $  0.544,-0.652&�6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��	10,99,0,0q�6p   $  0.053,0.361&�6�   $��25(�6�   �� 6�   $�Serial Number : ��6�   6�   �� 5   
   -   5        $% SerialNumberValue_ModifyStockUC��5       . $
��Left=�6N   $��33��6i   $��
212,99,0,0q�6u   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��578��6�   $  0.544,-0.652&�6�   �� 5   
   -   5         ��Name$) #RemoveFromStoreButton_ModifyStockUC��5      
���  ��$��10,202,407,0q�6�   $	��Top=�6�   $��60��6�   ��6p   Z� ��6�   Z� .��5      � $	��229��6    � RowDefinitions 5      �� 5      �� 5      $��5* �6$   �� 5      $��2* �6$   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Rubbish=�6*   $��50��69   $��46��6D   $��3��6P   �� 5      $��20(�6   $��Remove From the store��6*   $��
50,5,-83,9q�6G   $��1��6[   $��2��6h   5       5!      �� 5#   
   -   5        $! ConfirmButton_ModifyStockUC��5#      $��Confirm��6`   $
��Left=�6r   $��537,230,0,0q�6�   $	��Top=�6�   $��93��6�   �� 5$   
   -   5        $ CloseButton_ModifyStockUC��5$   I   $��Close��6   $
��Left=�6m   $��715,230,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5%   
   -   5        $ ResetButton_ModifyStockUC��5%   I   $��Reset��6   $
��Left=�6m   $��635,230,0,0q�6�   $	��Top=�6�   $��75��6�   5'      5(      