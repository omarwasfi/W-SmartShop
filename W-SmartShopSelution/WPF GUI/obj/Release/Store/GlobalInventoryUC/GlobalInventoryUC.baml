   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI      WPF_GUI.GlobalInventoryUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WPF_GUI     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+��� $
��Left=�$	��Top=�$
��Wrap=����#707070  J� RenderTransformOrigin$  0.596,0.438&�$��25(�$��6,35,0,0q��� $�Category : ���� -    ��Name$% CategoryValue_GlobalInventoryUC��$
��Left=�$��
130,40,0,0q�$	��Top=�$	��142�� �� IsTextSearchEnabled .  w� TextPath$
 Name���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
277,35,0,0q�$  0.596,0.438&�$��25(�$��82���� $�Brand : ���� -   $" BrandValue_GlobalInventoryUC��$
��Left=�$��
364,40,0,0q�$	��Top=�$	��152�� . $
 Name���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
521,35,0,0q�$  0.596,0.438&�$��25(�$��82���� $�Store : ���� -   $" StoreValue_GlobalInventoryUC��$
��Left=�$��
608,40,0,0q�$	��Top=�$	��129���� -    ��Name$* $ProductSearchValue_GlobalInventoryUC��$
��Left=�$��28��$��
742,40,0,0q� �� TextWrapping$
 Wrap=�$��
Search... ��$	��Top=�$	��312���� -   $) #ProductSearchType_GlobalInventoryUC��$
��Left=�$��1059,35,0,0q�$	��Top=�$	��110��$��33���� -    ��Name$+ %ProductSearchButton_GlobalInventoryUC�����	#FFA2A2A2$��Center=�$��1174,30,71,612q�$��38����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�$��25��$��25���� -   $/ )ResetStockResultsButton_GlobalInventoryUC��
���  ��$	��Top=�$��34��$��1277,34,10,0q���Z� ��Z� .��  $ Clear=�$��30��$��30��&   System.Windows.Controls.DataGrid  -     Name$" StocksList_GlobalInventoryUC��	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $
��Left=�$	��522��$��	10,73,0,0q�$	��Top=�$
��1323��
�������   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Product.Name+  $ 
Store Name�� �� *
Store.Name+  $ In Stock�� �� *
Quantity+  $ Serial Number�� �� *Product.SerialNumber+  $ 
Sale Price�� �� *Product.SalePrice+  $ Category�� �� *Product.Category.Name+  $ Brand�� �� *Product.Brand.Name+�� -	   $, &ModifySelectedButton_GlobalInventoryUC��$��428,600,643,0q�$	��Top=�$��70��.��� $	��254�� � ColumnDefinitions �� $
��111* ��� $	��16* �.+�  $ Pencil=�$��50��$��46���� $��20(�$��Modify selected��$��50,10,10,10q�$��2���� -
   $: 4AddProductToTheSelectedStoreButton_GlobalInventoryUC��$��10,600,920,0q�$	��Top=�$��70��.��� $	��372�� �� $	��78* ��� $��7* �.+�  $ PlusBox=�$��50��$��46���� $��20(�$'��!Add Product to the Selected Store��$��50,10,10,10q�$��2��� $��1117,0,0,651q�.+��� -   $&  CloseTabButton_GlobalInventoryUC��$y�	Collapsed=�
���  ��$	��Top=�$��	3,0,170,0q�$��25����Z� ��Z� .��  $ Close=�$��20��$��20���� -   $% RefreshButton_GlobalInventoryUC��
�������$	��Top=�$��	171,0,0,0q�$��25����Z� ��Z� .��  $ Reload=�$��20��$��20���� -   $# PrintButton_GlobalInventoryUC��
�������$	��Top=�$��
115,0,55,0q�$��25����Z� ��Z� .��  $ Printer=�$��20��$��20���� -   $% ConfitmButton_GlobalInventoryUC��$y�	Collapsed=�
��� � �$	��Top=�$��
56,0,111,0q�$��25����Z� ��Z� .��  $
 Done=�$��20��$��20��