   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF_GUI.PriceListUCWPF_GUI.PriceListUC  %    WPF_GUI.PriceListUC.PriceListUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:WPF_GUI.PriceListUC     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+�� -   $��UserGrid_PriceListUC��$y�Visible=�.+�&   System.Windows.Controls.DataGrid  -      Name$  StockList_PriceListUC��   
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$	��567��$��
10,103,0,0q�$	��Top=�$	��668��
�������   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Product.Name+  $ Barcode�� �� *Product.BarCode+  $ Quantity�� �� *
Quantity+  $ Income Price�� �� *	SalePrice+  $ 
Sale Price�� �� *
Discount+  $ Category�� �� *
Discount+  $ Brand�� �� *
Discount+  $ Serial Number�� �� *
Discount+  $ Serial Number 2�� �� *
Discount+�� $	��Top=�$
��Wrap=� J� RenderTransformOrigin$ 0.596,0.438&�$��6,18,0,0q�$
��Left=�$��25(����#707070�� $�Category : ���� -    ��Name$ CategoryValue_PriceListUC��$	��206��$	��Top=� w� TextPath$
 Name��$��
130,23,0,0q�	 �� IsTextSearchEnabled	 . $
��Left=��� $��82��$	��Top=�$
��Wrap=�$ 0.596,0.438&�$��
342,23,0,0q�$
��Left=�$��25(����#707070�� $�Brand : ���� -   $ BrandValue_PriceListUC��$	��164��$	��Top=�$
 Name��$��
430,23,0,0q�	 . $
��Left=��� -   
 ��Name$"
 StockSearchValue_PriceListUC��$	��356��$	��Top=�$��
Search... �� �� TextWrapping$
 Wrap=�$��	10,70,0,0q�$��28��$
��Left=��� -   $! StockSearchType_PriceListUC��$	��120��$	��Top=�$��
371,65,0,0q�$��33��$
��Left=��� -    ��Name$# StockSearchButton_PriceListUC�����	#FFA2A2A2$��Center=�$��496,70,749,572q�$��38����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�$��25��$��25���� -   $. (RemoveStockFromTheListButton_PriceListUC��$��683,323,601,0q�$	��Top=�$��41��.��� $��39�� � ColumnDefinitions �� $	��78* ��� $��7* �.+�  $ 	ArrowLeft=�$��40��$��40��$��
-8,-3,0,-4q��� -	   $) #AddStockToTheListButton_PriceListUC��$��683,277,601,0q�$	��Top=�$��41��.��� $��39�� �� $	��78* ��� $��7* �.+�  $ 
ArrowRight=�$��40��$��40��$��
-8,-3,0,-4q��� -
   $- 'AddAllStocksToTheListButton_PriceListUC��$��683,397,601,0q�$	��Top=�$��41��.��� $��39�� �� $	��78* ��� $��7* �.+�  $ ArrowRightBold=�$��40��$��40��$��
-8,-3,0,-4q��� -   $$ ClearTheListButton_PriceListUC��$��683,443,601,0q�$	��Top=�$��41��.��� $��39�� �� $	��78* ��� $��7* �.+�  $ Clear=�
���  ��$��40��$��40��$��
-8,-3,0,-4q�  -   $#  ChoosenStocksList_PriceListUC�� .  .  $
��Left=�$	��567��$��747,103,0,0q�$	��Top=�$	��586��
�������   $ Product Name�� �� *Product.Name+  $ Barcode�� �� *Product.BarCode+  $ Quantity�� �� *
Quantity+  $ Income Price�� �� *	SalePrice+  $ 
Sale Price�� �� *
Discount+  $ Category�� �� *
Discount+  $ Brand�� �� *
Discount+  $ Serial Number�� �� *
Discount+  $ Serial Number 2�� �� *
Discount+�� -   $��BarCodeCB_PriceListUC��$��Barcode��$
��Left=�$��
747,18,0,0q�$	��Top=��� -   $ ��SerialNumberCB_PriceListUC��$��Serial Number ��$
��Left=�$��
747,41,0,0q�$	��Top=��� -   $!��SerialNumber2CB_PriceListUC��$��Serial Number 2��$
��Left=�$��
747,64,0,0q�$	��Top=��� -   $��CategoryCB_PriceListUC��$��Category��$
��Left=�$��
886,41,0,0q�$	��Top=��� -   $��BrandCB_PriceListUC��$��Brand��$
��Left=�$��
886,18,0,0q�$	��Top=��� -   $��SalePriceCB_PriceListUC��$��
Sale Price��$
��Left=�$��1001,18,0,0q�$	��Top=��� -   $��IncomePriceCB_PriceListUC��$��Income Price��$
��Left=�$��1001,41,0,0q�$	��Top=��� -   $��QuantityCB_PriceListUC��$��Quantity��$
��Left=�$��1118,18,0,0q�$	��Top=��� -   $ PrintButton_PriceListUC��
�������$	��Top=�$��1252,18,10,0q�$��61����Z� ��Z� .��  $ Printer=�$��50��$��50��� -   $��PrintGrid_PriceListUC��$y�	Collapsed=�