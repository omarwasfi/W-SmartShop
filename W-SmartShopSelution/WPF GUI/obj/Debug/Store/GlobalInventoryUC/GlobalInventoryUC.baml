   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI  5          WPF_GUI.GlobalInventoryUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WPF_GUI     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   �� $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070  J� RenderTransformOrigin$  0.596,0.438&�6p   $��25(�6�   $��6,35,0,0q�6�   �� 6�   $�Category : ��6�   6�   �� 5   
   -   5         ��Name$% CategoryValue_GlobalInventoryUC��5      $
��Left=�6<   $��
130,40,0,0q�6W   $	��Top=�6k   $	��142��6�    �� IsTextSearchEnabled .  w� TextPath$
 Name��6�   6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
277,35,0,0q�6p   $  0.596,0.438&�6�   $��25(�6�   $��82��6�   �� 6�   $�Brand : ��6�   6�   �� 5   
   -   5        $" BrandValue_GlobalInventoryUC��5      $
��Left=�69   $��
364,40,0,0q�6T   $	��Top=�6h   $	��152��6�    . $
 Name��6�   6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
521,35,0,0q�6p   $  0.596,0.438&�6�   $��25(�6�   $��82��6�   �� 6�   $�Store : ��6�   6�   �� 5   
   -   5        $" StoreValue_GlobalInventoryUC��5      $
��Left=�6z   $��
608,40,0,0q�6�   $	��Top=�6�   $	��129��6�   �� 5   
   -   5         ��Name$* $ProductSearchValue_GlobalInventoryUC��5      $
��Left=�6A   $��28��6\   $��
742,40,0,0q�6h    �� TextWrapping$
 Wrap=�6|   $��
Search... ��6�   $	��Top=�6�   $	��312��6�   �� 5   
   -   5        $) #ProductSearchType_GlobalInventoryUC��5      $
��Left=�6@   $��1059,35,0,0q�6[   $	��Top=�6p   $	��110��6�   $��33��6�   �� 5   
   -   5         ��Name$+ %ProductSearchButton_GlobalInventoryUC��5      ���	#FFA2A2A2$��Center=�6�   $��1174,30,71,612q�6�   $��38��6�   ��6t   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6&   $��25��64   $��25��6?   5      �� 5   
   -   5        $/ )ResetStockResultsButton_GlobalInventoryUC��5      
���  ��$	��Top=�6�   $��34��6�   $��1277,34,10,0q�6�   ��6|   Z� ��6�   Z� .��5        $ Clear=�6&   $��30��63   $��30��6>   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$" StocksList_GlobalInventoryUC��5       	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $
��Left=�6g   $	��522��6�   $��	10,73,0,0q�6�   $	��Top=�6�   $
��1323��6�   
�������   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Product.Name+  5#      $ 
Store Name��6%    69   �� *
Store.Name+  5$      $ In Stock��6%    67   �� *
Quantity+  5%      $ Serial Number��6%    6<   �� *Product.SerialNumber+  5&      $ 
Sale Price��6%    69   �� *Product.SalePrice+  5'      $ Category��6%    67   �� *Product.Category.Name+  5(      $ Brand��6%    64   �� *Product.Brand.Name+5-      �� 5/   
   -	   5        $, &ModifySelectedButton_GlobalInventoryUC��5/      $��428,600,643,0q�6w   $	��Top=�6�   $��70��6�   .��50      � $	��254��6    � ColumnDefinitions 51      �� 52      $
��111* �6'   �� 53      $	��16* �6'   .+�55        $ Pencil=�6*   $��50��69   $��46��6D   �� 56      $��20(�6   $��Modify selected��6*   $��50,10,10,10q�6A   $��2��6V   57      58      �� 5:   
   -
   5        $: 4AddProductToTheSelectedStoreButton_GlobalInventoryUC��5:      $��10,600,920,0q�6�   $	��Top=�6�   $��70��6�   .��5;      � $	��372��6    5<      �� 5=      $	��78* �6'   �� 5>      $��7* �6'   .+�5@        $ PlusBox=�6*   $��50��69   $��46��6D   �� 5A      $��20(�6   $'��!Add Product to the Selected Store��6*   $��50,10,10,10q�6S   $��2��6h   5B      5C      � 5F   
   $��1117,0,0,651q�6   .+�5G      �� -   5        $&  CloseTabButton_GlobalInventoryUC��5G      $y�	Collapsed=�6?   
���  ��$	��Top=�6�   $��	3,0,170,0q�6�   $��25��6�   ��6V   Z� ��6l   Z� .��5H        $ Close=�6*   $��20��67   $��20��6B   5I      �� 5K      -   5        $% RefreshButton_GlobalInventoryUC��5K      
�������$	��Top=�6�   $��	171,0,0,0q�6�   $��25��6�   ��6l   Z� ��6�   Z� .��5L        $ Reload=�6*   $��20��68   $��20��6C   5M      �� 5O      -   5        $# PrintButton_GlobalInventoryUC��5O      
�������$	��Top=�6}   $��
115,0,55,0q�6�   $��25��6�   ��6<   Z� ��6R   Z� .��5P        $ Printer=�6*   $��20��69   $��20��6D   5Q      �� 5S      -   5        $% ConfitmButton_GlobalInventoryUC��5S      $y�	Collapsed=�6>   
��� � �$	��Top=�6�   $��
56,0,111,0q�6�   $��25��6�   ��6U   Z� ��6k   Z� .��5T        $
 Done=�6*   $��20��66   $��20��6A   5U      5W      5Z      5[      