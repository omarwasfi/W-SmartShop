   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI      WPF_GUI.AddStockToStoreUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WPF_GUI     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Gwpf9http://schemas.microsoft.com/netfx/2009/xaml/presentation    Hwpf19http://schemas.microsoft.com/netfx/2007/xaml/presentation    .��� $��10q�.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070  J� RenderTransformOrigin$  0.596,0.438&�$��25(�$��6,18,0,0q��� $�Category : ���� -    ��Name$% CategoryValue_AddStockToStoreUC��$
��Left=�$��
130,23,0,0q�$	��Top=�$	��206�� �� IsTextSearchEnabled .  w� TextPath$
 Name���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
342,23,0,0q�$  0.596,0.438&�$��25(�$��82���� $�Brand : ���� -   $" BrandValue_AddStockToStoreUC��$
��Left=�$��
430,23,0,0q�$	��Top=�$	��164�� . $
 Name��&   System.Windows.Controls.DataGrid  -     Name$% FProductsList_AddStockToStoreUC��   
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$	��542��$��
10,108,0,0q�$	��Top=�$	��584��
�������   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *Name+  $ Serial Number��	 �� *SerialNumber+  $ 
Sale Price��	 �� *	SalePrice+  $ Income Price��	 �� *IncomePrice+�� -   
 ��Name$*
 $ProductSearchValue_AddStockToStoreUC��$	��356��$	��Top=�$��
Search... �� �� TextWrapping$
 Wrap=�$��	10,70,0,0q�$��28��$
��Left=��� -   $) #ProductSearchType_AddStockToStoreUC��$	��120��$	��Top=�$��
371,65,0,0q�$��33��$
��Left=��� -    ��Name$+ %ProductSearchButton_AddStockToStoreUC�����	#FFA2A2A2$��Center=�$��496,70,729,552q�$��38����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�$��25��$��25���� -   $2 ,AddToTheCurrentStoreButton_AddStockToStoreUC��$��624,128,381,0q�$	��Top=�$��70��.��� $	��375�� � ColumnDefinitions �� $	��78* ��� $��7* �.+�  $ ArrowRightBold=�$��50��$��46���� $��20(�$��Add to The Current Store��$��50,10,55,10q��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
624,75,0,0q�$  0.053,0.361&�$��25(��� $�Quantity : ���� -   $%
 QuantityValue_AddStockToStoreUC��$
��Left=�$��33��$��
783,75,0,0q�$
 Wrap=�$�� ��$	��Top=�$��76��$  0.544,-0.652&��� $��The New Stocks��$
��Left=�$	��410��$��624,203,0,0q�$	��Top=�$	��689��.��� $��0,0,0,6q�$	��664��.+�  -	   $% NewStocksList_AddStockToStoreUC�� .  .  $
��Left=�$	��332��$��	10,10,0,0q�$	��Top=�$	��644��
�������   $ Product Name��	 �� *Product.Name+  $ Serial Number��	 �� *Product.SerialNumber+  $ Quantity��	 �� *
Quantity+�� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
783,18,0,0q�$  0.596,0.438&�$��25(�$��82���� $�Store : ���� -
   $" StoreValue_AddStockToStoreUC��$
��Left=�$��
865,23,0,0q�$	��Top=�$	��206���� -   $#��CloseButton_AddStockToStoreUC��$��Close��$
��Left=�$��1235,618,0,0q�$	��Top=�$��75���� -   $#��ClearButton_AddStockToStoreUC��$��Clear��$
��Left=�$��1155,618,0,0q�$	��Top=�$��75���� -   $% ConfirmButton_AddStockToStoreUC��$��Confirm��$
��Left=�$��1057,618,0,0q�$	��Top=�$��93���� -   $1 +RemoveSelectedStockButton_AddStockToStoreUC��
���  ��$��1055,133,13,0q�$	��Top=�$��60����Z� ��Z� .��� $	��229�� � RowDefinitions �� �� $��5* ��� $��2* �.+�  $ RemoveCircle=�$��50��$��46��$��3���� $��20(�$��Remove Selected��$��50,5.468,10,9.132q�$��1��$��2��