   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI  %    WPF_GUI.InstallmentCollectingUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WPF_GUI     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+�� $��1117,0,0,651q�.+��� -     ��Name$  CloseTabButton_SellUC��$y�	Collapsed=�
���  ��$	��Top=�$��	3,0,170,0q�$��25����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�$��20��$��20���� -   $  ReloadTabButton_SellUC��
�������$	��Top=�$��	171,0,0,0q�$��25����Z� ��Z� .��  $ Reload=�$��20��$��20���� -   $  PrintButton_SellUC��
�������$	��Top=�$��
115,0,55,0q�$��25����Z� ��Z� .��  $ Printer=�$��20��$��20���� -   $  ConfitmButton_SellUC��$y�	Collapsed=�
��� � �$	��Top=�$��
56,0,111,0q�$��25����Z� ��Z� .��  $
 Done=�$��20��$��20��&   System.Windows.Controls.Calendar  $
��Left=�$��0,85,0,0q�$	��Top=�$	��355��&   System.Windows.Controls.DataGrid  -     Name$ ChoosenProductList_Sell��   
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$	��208��$��293,462,0,0q�$	��Top=�$
��1040��
�������   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Customer Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding Z�   $ Products�� �� *
Quantity+  $	 EMI�� �� *	SalePrice+  -   $" ChoosenProductList_Sell_Copy�� .  .  $
��Left=�$	��298��$��293,118,0,0q�$	��Top=�$
��1040��
�������   $ Customer Name�� Z�   $ Products�� �� *
Quantity+  $	 EMI�� �� *	SalePrice+�� -   $&   RemoveSelectedProductButton_Sell��
��� � �$��1171,53,10,0q�$	��Top=�$��60����Z� ��Z� .��� $	��140�� � RowDefinitions �� $��5* ��� $	��42* �.+�  $ Payment=�$��50��$��46��$��2���� $��20(�$��Pay Now��$��
50,5,10,10q�$��1���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��293,424,0,0q�	 J� RenderTransformOrigin$	 0.596,0.438&�$��25(��� $�Payed : ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
293,85,0,0q�$	 0.596,0.438&�$��25(��� $�Not Payed : ���� -   $+  %RemoveSelectedProductButton_Sell_Copy��
��� � �$��1004,53,177,0q�$	��Top=�$��60����Z� ��Z� .��� $	��140�� �� $��5* ��� $	��42* �.+�  $
 Edit=�$��50��$��46��$��2���� $��20(�$��Modify��$��
50,5,10,10q�$��1��