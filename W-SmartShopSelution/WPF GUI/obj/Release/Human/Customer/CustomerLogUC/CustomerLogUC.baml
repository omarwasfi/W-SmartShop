   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPF_GUI.CustomerLogUCWPF_GUI.CustomerLogUC  )    #WPF_GUI.CustomerLogUC.CustomerLogUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:WPF_GUI.CustomerLogUC     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� $��10q�.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	10,10,0,0q�  J� RenderTransformOrigin$  0.596,0.438&�$��25(�$	��258��$��Customer full name : ���� -    ��Name$% CustomerNameValue_CustomerLogUC��$
��Left=�$��
273,18,0,0q�$	��Top=�$	��421��$��25��&   System.Windows.Controls.DataGrid  -     Name$ OrdersList_CustomerLogUC��   
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$	��545��$��	10,68,0,0q�$	��Top=�$
��1303��
�������   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Staff Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Staff.Person.FullName+  $ 
Store Name�� �� *
Store.Name+  $ Total Price�� �� *
TotalPrice+  $ Date and time�� �� *DateTimeOfTheOrder+   RowDetailsTemplate �� .R�  $$��OrderProdcutList_CustomerLogUC�� .  .  $
��Left=�$	��170��$��5q�$	��Top=�$
��1280��
����������� *
Products+   $ Prodcut Name�� �� *Product.Name+  $ Prodcut Serial Number�� �� *Product.SerialNumber+  $ Quantity�� �� *
Quantity+  $ Piece Price�� �� *	SalePrice+  $ Discount�� �� *
Discount+  $ Total�� �� *
TotalPrice+�� -   	 ��Name$	 PrintButton_CustomerLogUC��$��Print��$
��Left=�$��1152,618,0,0q�$	��Top=�$��81���� -   $	 CloseButton_CustomerLogUC��$��Close��$
��Left=�$��1238,618,0,0q�$	��Top=�$��75���� -   $$	 EditPersonButton_CustomerLogUC��$��1060,10,10,0q�$	��Top=�$��53��.��� $	��254��.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]
   Kind$
 Pencil=�$��50��$��46���� $��20(�$��Edit As a Person��$��50,10,10,10q�