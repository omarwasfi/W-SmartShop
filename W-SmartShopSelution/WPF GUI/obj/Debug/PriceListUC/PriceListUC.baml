   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF_GUI.PriceListUCWPF_GUI.PriceListUC  5      %    WPF_GUI.PriceListUC.PriceListUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPF_GUI.PriceListUC     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   � -   5        $��UserGrid_PriceListUC��5      $y�Visible=�6+   .+�5      &   System.Windows.Controls.DataGrid  -   5           Name$  StockList_PriceListUC��5         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6d   $	��567��6   $��
10,103,0,0q�6�   $	��Top=�6�   $	��668��6�   
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Product.Name+  5      $ Barcode��6)    6:   �� *Product.BarCode+  5      $ Quantity��6)    6;   �� *
Quantity+  5      $ Income Price��6)    6?   �� *	SalePrice+  5      $ 
Sale Price��6)    6=   �� *
Discount+  5      $ Category��6)    6;   �� *
Discount+  5      $ Brand��6)    68   �� *
Discount+  5      $ Serial Number��6)    6@   �� *
Discount+  5      $ Serial Number 2��6)    6B   �� *
Discount+5      �� 5      $	��Top=�6   $
��Wrap=�60    J� RenderTransformOrigin$ 0.596,0.438&�6D   $��6,18,0,0q�6h   $
��Left=�6z   $��25(�6�   ���#707070�� 6�   $�Category : ��6�   6�   �� 5      -   5         ��Name$ CategoryValue_PriceListUC��5      $	��206��6:   $	��Top=�6F    w� TextPath$
 Name��6^   $��
130,23,0,0q�6y   	 �� IsTextSearchEnabled	 . $
��Left=�6�   �� 5       $��82��6   $	��Top=�6#   $
��Wrap=�6;   $ 0.596,0.438&�6O   $��
342,23,0,0q�6s   $
��Left=�6�   $��25(�6�   ���#707070�� 6�   $�Brand : ��6�   6�   �� 5!      -   5        $ BrandValue_PriceListUC��5!      $	��164��67   $	��Top=�6C   $
 Name��6[   $��
430,23,0,0q�6w   	 . $
��Left=�6�   �� 5#      -   5        
 ��Name$"
 StockSearchValue_PriceListUC��5#      $	��356��6<   $	��Top=�6H   $��
Search... ��6`    �� TextWrapping$
 Wrap=�6r   $��	10,70,0,0q�6�   $��28��6�   $
��Left=�6�   �� 5$      -   5        $! StockSearchType_PriceListUC��5$      $	��120��6<   $	��Top=�6H   $��
371,65,0,0q�6`   $��33��6t   $
��Left=�6�   �� 5%      -   5         ��Name$# StockSearchButton_PriceListUC��5%      ���	#FFA2A2A2$��Center=�6�   $��496,70,749,572q�6�   $��38��6�   ��6>   Z� ��6T   Z� .��5&      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6*   $��25��68   $��25��6C   5'      �� 5)      -   5        $. (RemoveStockFromTheListButton_PriceListUC��5)      $��683,323,601,0q�6H   $	��Top=�6_   $��41��6w   .��5*      � $��39��6    � ColumnDefinitions 5+      �� 5,      $	��78* �6+   �� 5-      $��7* �6+   .+�5/        $ 	ArrowLeft=�6.   $��40��6?   $��40��6J   $��
-8,-3,0,-4q�6V   50      51      �� 53      -	   5        $) #AddStockToTheListButton_PriceListUC��53      $��683,277,601,0q�6C   $	��Top=�6Z   $��41��6r   .��54      � $��39��6    55      �� 56      $	��78* �6+   �� 57      $��7* �6+   .+�59        $ 
ArrowRight=�6.   $��40��6@   $��40��6K   $��
-8,-3,0,-4q�6W   5:      5;      �� 5=      -
   5        $- 'AddAllStocksToTheListButton_PriceListUC��5=      $��683,397,601,0q�6G   $	��Top=�6^   $��41��6v   .��5>      � $��39��6    5?      �� 5@      $	��78* �6+   �� 5A      $��7* �6+   .+�5C        $ ArrowRightBold=�6.   $��40��6D   $��40��6O   $��
-8,-3,0,-4q�6[   5D      5E      �� 5G      -   5        $$ ClearTheListButton_PriceListUC��5G      $��683,443,601,0q�6>   $	��Top=�6U   $��41��6m   .��5H      � $��39��6    5I      �� 5J      $	��78* �6+   �� 5K      $��7* �6+   .+�5M        $ Clear=�6.   
���  ��$��40��6L   $��40��6W   $��
-8,-3,0,-4q�6c   5N      5O        5Q      -   5        $#  ChoosenStocksList_PriceListUC��5Q       .  .  $
��Left=�6l   $	��567��6�   $��747,103,0,0q�6�   $	��Top=�6�   $	��586��6�   
������� 5R        5S      $ Product Name��6)    6?   �� *Product.Name+  5T      $ Barcode��6)    6:   �� *Product.BarCode+  5U      $ Quantity��6)    6;   �� *
Quantity+  5V      $ Income Price��6)    6?   �� *	SalePrice+  5W      $ 
Sale Price��6)    6=   �� *
Discount+  5X      $ Category��6)    6;   �� *
Discount+  5Y      $ Brand��6)    68   �� *
Discount+  5Z      $ Serial Number��6)    6@   �� *
Discount+  5[      $ Serial Number 2��6)    6B   �� *
Discount+5^      �� 5`      -   5        $��BarCodeCB_PriceListUC��5`      $��Barcode��64   $
��Left=�6F   $��
747,18,0,0q�6a   $	��Top=�6u   �� 5a      -   5        $ ��SerialNumberCB_PriceListUC��5a      $��Serial Number ��69   $
��Left=�6R   $��
747,41,0,0q�6m   $	��Top=�6�   �� 5b      -   5        $!��SerialNumber2CB_PriceListUC��5b      $��Serial Number 2��6:   $
��Left=�6T   $��
747,64,0,0q�6o   $	��Top=�6�   �� 5d      -   5        $��CategoryCB_PriceListUC��5d      $��Category��65   $
��Left=�6H   $��
886,41,0,0q�6c   $	��Top=�6w   �� 5e      -   5        $��BrandCB_PriceListUC��5e      $��Brand��62   $
��Left=�6B   $��
886,18,0,0q�6]   $	��Top=�6q   �� 5g      -   5        $��SalePriceCB_PriceListUC��5g      $��
Sale Price��66   $
��Left=�6K   $��1001,18,0,0q�6f   $	��Top=�6{   �� 5h      -   5        $��IncomePriceCB_PriceListUC��5h      $��Income Price��68   $
��Left=�6O   $��1001,41,0,0q�6j   $	��Top=�6   �� 5j      -   5        $��QuantityCB_PriceListUC��5j      $��Quantity��65   $
��Left=�6H   $��1118,18,0,0q�6c   $	��Top=�6x   �� 5m      -   5        $ PrintButton_PriceListUC��5m      
�������$	��Top=�6x   $��1252,18,10,0q�6�   $��61��6�   ��67   Z� ��6M   Z� .��5n        $ Printer=�6*   $��50��69   $��50��6D   5o      5q      � 5s   
   -   5        $��PrintGrid_PriceListUC��5s      $y�	Collapsed=�6,   5u      5x      5y      