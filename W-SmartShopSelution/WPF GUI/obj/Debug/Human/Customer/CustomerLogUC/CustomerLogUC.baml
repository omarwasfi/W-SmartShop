   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPF_GUI.CustomerLogUCWPF_GUI.CustomerLogUC  5      )    #WPF_GUI.CustomerLogUC.CustomerLogUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WPF_GUI.CustomerLogUC     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � $��10q�6   .+�5   
   �� $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��	10,10,0,0q�6p     J� RenderTransformOrigin$  0.596,0.438&�6�   $��25(�6�   $	��258��6�   $��Customer full name : ��6�   �� 5   
   -   5         ��Name$% CustomerNameValue_CustomerLogUC��5      $
��Left=�6?   $��
273,18,0,0q�6Z   $	��Top=�6n   $	��421��6�   $��25��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ OrdersList_CustomerLogUC��5         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6c   $	��545��6~   $��	10,68,0,0q�6�   $	��Top=�6�   $
��1303��6�   
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Staff Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Staff.Person.FullName+  5      $ 
Store Name��6%    69   �� *
Store.Name+  5      $ Total Price��6%    6:   �� *
TotalPrice+  5      $ Date and time��6%    6<   �� *DateTimeOfTheOrder+   RowDetailsTemplate 5      �� 5      .R�5        $$��OrderProdcutList_CustomerLogUC��6    .  .  $
��Left=�6�   $	��170��6�   $��5q�6�   $	��Top=�6�   $
��1280��6�   
���������6F   �� *
Products+ 5        5      $ Prodcut Name��61    6G   �� *Product.Name+  5      $ Prodcut Serial Number��61    6P   �� *Product.SerialNumber+  5      $ Quantity��61    6C   �� *
Quantity+  5      $ Piece Price��61    6F   �� *	SalePrice+  5      $ Discount��61    6C   �� *
Discount+  5      $ Total��61    6@   �� *
TotalPrice+5"      5#      5%      �� 5(   
   -   5        	 ��Name$	 PrintButton_CustomerLogUC��5(      $��Print��64   $
��Left=�6D   $��1152,618,0,0q�6_   $	��Top=�6u   $��81��6�   �� 5)   
   -   5        $	 CloseButton_CustomerLogUC��5)      $��Close��6]   $
��Left=�6m   $��1238,618,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5+   
   -   5        $$	 EditPersonButton_CustomerLogUC��5+      $��1060,10,10,0q�6h   $	��Top=�6~   $��53��6�   .��5,      � $	��254��6   .+�5-      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]
   Kind$
 Pencil=�6*   $��50��69   $��46��6D   �� 5.      $��20(�6   $��Edit As a Person��6*   $��50,10,10,10q�6B   5/      50      52      53      