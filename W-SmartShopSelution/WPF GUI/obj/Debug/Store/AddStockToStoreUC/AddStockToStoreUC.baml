   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI  5          WPF_GUI.AddStockToStoreUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WPF_GUI     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Gwpf9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5	      Hwpf19http://schemas.microsoft.com/netfx/2007/xaml/presentation    5
      .��5      � $��10q�6   .+�5   
   �� $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070  J� RenderTransformOrigin$  0.596,0.438&�6p   $��25(�6�   $��6,18,0,0q�6�   �� 6�   $�Category : ��6�   6�   �� 5   
   -   5         ��Name$% CategoryValue_AddStockToStoreUC��5      $
��Left=�6p   $��
130,23,0,0q�6�   $	��Top=�6�   $	��206��6�    �� IsTextSearchEnabled .  w� TextPath$
 Name��6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
342,23,0,0q�6p   $  0.596,0.438&�6�   $��25(�6�   $��82��6�   �� 6�   $�Brand : ��6�   6�   �� 5   
   -   5        $" BrandValue_AddStockToStoreUC��5      $
��Left=�6m   $��
430,23,0,0q�6�   $	��Top=�6�   $	��164��6�    . $
 Name��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$% FProductsList_AddStockToStoreUC��5         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6j   $	��542��6�   $��
10,108,0,0q�6�   $	��Top=�6�   $	��584��6�   
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6;   �� *Name+  5      $ Serial Number��6%   	 6<   �� *SerialNumber+  5      $ 
Sale Price��6%   	 69   �� *	SalePrice+  5      $ Income Price��6%   	 6;   �� *IncomePrice+5      �� 5   
   -   5        
 ��Name$*
 $ProductSearchValue_AddStockToStoreUC��5      $	��356��6@   $	��Top=�6L   $��
Search... ��6d    �� TextWrapping$
 Wrap=�6v   $��	10,70,0,0q�6�   $��28��6�   $
��Left=�6�   �� 5   
   -   5        $) #ProductSearchType_AddStockToStoreUC��5      $	��120��6@   $	��Top=�6L   $��
371,65,0,0q�6d   $��33��6x   $
��Left=�6�   �� 5    
   -   5         ��Name$+ %ProductSearchButton_AddStockToStoreUC��5       ���	#FFA2A2A2$��Center=�6�   $��496,70,729,552q�6�   $��38��6�   ��6u   Z� ��6�   Z� .��5!      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6&   $��25��64   $��25��6?   5"      �� 5$   
   -   5        $2 ,AddToTheCurrentStoreButton_AddStockToStoreUC��5$      $��624,128,381,0q�6�   $	��Top=�6�   $��70��6�   .��5%      � $	��375��6    � ColumnDefinitions 5&      �� 5'      $	��78* �6'   �� 5(      $��7* �6'   .+�5*        $ ArrowRightBold=�6*   $��50��6@   $��46��6K   �� 5+      $��20(�6   $��Add to The Current Store��6*   $��50,10,55,10q�6J   5,      5-      �� 5/   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
624,75,0,0q�6p   $  0.053,0.361&�6�   $��25(�6�   �� 6�   $�Quantity : ��6�   6�   �� 50   
   -   5        $%
 QuantityValue_AddStockToStoreUC��50      $
��Left=�6=   $��33��6X   $��
783,75,0,0q�6d   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $��76��6�   $  0.544,-0.652&�6�   �� 52   
   $��The New Stocks��6   $
��Left=�6+   $	��410��6F   $��624,203,0,0q�6S   $	��Top=�6h   $	��689��6�   .��53      � $��0,0,0,6q�6   $	��664��6$   .+�54        -	   5        $% NewStocksList_AddStockToStoreUC��54       .  .  $
��Left=�6r   $	��332��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��644��6�   
������� 55        56      $ Product Name��6-   	 6C   �� *Product.Name+  57      $ Serial Number��6-   	 6D   �� *Product.SerialNumber+  58      $ Quantity��6-   	 6?   �� *
Quantity+5:      5;      5<      �� 5?   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
783,18,0,0q�6p   $  0.596,0.438&�6�   $��25(�6�   $��82��6�   �� 6�   $�Store : ��6�   6�   �� 5@   
   -
   5        $" StoreValue_AddStockToStoreUC��5@      $
��Left=�6{   $��
865,23,0,0q�6�   $	��Top=�6�   $	��206��6�   �� 5C   
   -   5        $#��CloseButton_AddStockToStoreUC��5C   !   $��Close��6   $
��Left=�6r   $��1235,618,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5D   
   -   5        $#��ClearButton_AddStockToStoreUC��5D   !   $��Clear��6   $
��Left=�6r   $��1155,618,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5E   
   -   5        $% ConfirmButton_AddStockToStoreUC��5E      $��Confirm��6h   $
��Left=�6z   $��1057,618,0,0q�6�   $	��Top=�6�   $��93��6�   �� 5G   
   -   5        $1 +RemoveSelectedStockButton_AddStockToStoreUC��5G      
���  ��$��1055,133,13,0q�6�   $	��Top=�6�   $��60��6�   ��6�   Z� ��6�   Z� .��5H      � $	��229��6    � RowDefinitions 5I      �� 5J      �� 5K      $��5* �6$   �� 5L      $��2* �6$   .+�5N        $ RemoveCircle=�6*   $��50��6>   $��46��6I   $��3��6U   �� 5O      $��20(�6   $��Remove Selected��6*   $��50,5.468,10,9.132q�6A   $��1��6\   $��2��6i   5P      5Q      5S      5T      