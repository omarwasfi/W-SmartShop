   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WPF_GUI.Orders.In.ModifyBillWPF_GUI.Orders.In.ModifyBill  /    )WPF_GUI.Orders.In.ModifyBill.ModifyBillUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:WPF_GUI.Orders.In.ModifyBill     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
10,135,0,0q�  J� RenderTransformOrigin$  0.596,0.438&�$��25(��� $�
Details : ���� -    ��Name$# BillDetailsValue_ModifyBillUC��$
��Left=�$��32��$��147,136,0,0q�$�� ��$	��Top=�$
��1169�� �� 	MaxLength$	 500�� �� MaxLines$ 1���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	10,97,0,0q�$  0.596,0.438&�$��25(��� $�Total Price : ���� -   $" TotalPriceValue_ModifyBillUC��$
��Left=�$��22��$��147,108,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$��58��$  0.544,-0.652&�(  "System.Windows.Controls.DatePicker  -     Name$ DateValue_ModifyBillUC��$
��Left=�$��
147,67,0,0q�$	��Top=�$	��129��   SelectedDateFormat$ Short=��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	10,59,0,0q�$  0.596,0.438&�$��25(��� $�Date : ��� $��1107,10,10,162q�.+��� -    ��Name$ DeleteButton_ModifyBillUC��$y�Visible=�
���  ��$	��Top=�$��	3,0,170,0q�$��25����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Garbage=�$��20��$��20���� -   $  RefreshButton_ModifyBillUC��
�������$	��Top=�$��	171,0,0,0q�$��25����Z� ��Z� .��  $ Reload=�$��20��$��20���� -   $ PrintButton_ModifyBillUC��
�������$	��Top=�$��
115,0,55,0q�$��25����Z� ��Z� .��  $ Printer=�$��20��$��20���� -   $  ConfirmButton_ModifyBillUC��
��� � �$	��Top=�$��
56,0,111,0q�$��25����Z� ��Z� .��  $
 Done=�$��20��$��20���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
694,59,0,0q�$  0.596,0.438&�$��25(��� $�Staff member : ���� -   $! StaffNameValue_ModifyBillUC��	 �� 
IsReadOnly	 . $
��Left=�$��33��$��
866,59,0,0q�$�� ��$	��Top=�$	��142��$	 500��$ 1��