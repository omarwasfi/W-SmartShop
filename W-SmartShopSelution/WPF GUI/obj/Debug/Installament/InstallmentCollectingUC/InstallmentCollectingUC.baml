   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI  5      %    WPF_GUI.InstallmentCollectingUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WPF_GUI     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � $��1117,0,0,651q�6   .+�5      �� -   5          ��Name$  CloseTabButton_SellUC��5      $y�	Collapsed=�64   
���  ��$	��Top=�6�   $��	3,0,170,0q�6�   $��25��6�   ��6K   Z� ��6a   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6*   $��20��67   $��20��6B   5      �� 5      -   5        $  ReloadTabButton_SellUC��5      
�������$	��Top=�6w   $��	171,0,0,0q�6�   $��25��6�   ��66   Z� ��6L   Z� .��5        $ Reload=�6*   $��20��68   $��20��6C   5      �� 5      -   5        $  PrintButton_SellUC��5      
�������$	��Top=�6r   $��
115,0,55,0q�6�   $��25��6�   ��61   Z� ��6G   Z� .��5        $ Printer=�6*   $��20��69   $��20��6D   5      �� 5      -   5        $  ConfitmButton_SellUC��5      $y�	Collapsed=�63   
��� � �$	��Top=�6�   $��
56,0,111,0q�6�   $��25��6�   ��6J   Z� ��6`   Z� .��5        $
 Done=�6*   $��20��66   $��20��6A   5      5      &   System.Windows.Controls.Calendar  5   
   $
��Left=�6   $��0,85,0,0q�6.   $	��Top=�6@   $	��355��6X   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ChoosenProductList_Sell��5         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6b   $	��208��6}   $��293,462,0,0q�6�   $	��Top=�6�   $
��1040��6�   
�������   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   Z�   5"      $ Products��6%    67   �� *
Quantity+  5#      $	 EMI��6%    62   �� *	SalePrice+5%        5&   
   -   5        $" ChoosenProductList_Sell_Copy��5&       .  .  $
��Left=�6g   $	��298��6�   $��293,118,0,0q�6�   $	��Top=�6�   $
��1040��6�   
������� 5'        5(      $ Customer Name��6%    6<   Z�   5)      $ Products��6%    67   �� *
Quantity+  5*      $	 EMI��6%    62   �� *	SalePrice+5-      �� 5.   
   -   5        $&   RemoveSelectedProductButton_Sell��5.      
��� � �$��1171,53,10,0q�6|   $	��Top=�6�   $��60��6�   ��6;   Z� ��6Q   Z� .��5/      � $	��140��6    � RowDefinitions 50      �� 51      $��5* �6$   �� 52      $	��42* �6$   .+�54        $ Payment=�6*   $��50��69   $��46��6D   $��2��6P   �� 55      $��20(�6   $��Pay Now��6*   $��
50,5,10,10q�69   $��1��6M   56      57      �� 58   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��293,424,0,0q�6p   	 J� RenderTransformOrigin$	 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Payed : ��6�   6�   �� 59   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
293,85,0,0q�6p   $	 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Not Payed : ��6�   6�   �� 5:   
   -   5        $+  %RemoveSelectedProductButton_Sell_Copy��5:      
��� � �$��1004,53,177,0q�6�   $	��Top=�6�   $��60��6�   ��6A   Z� ��6W   Z� .��5;      � $	��140��6    5<      �� 5=      $��5* �6$   �� 5>      $	��42* �6$   .+�5@        $
 Edit=�6*   $��50��66   $��46��6A   $��2��6M   �� 5A      $��20(�6   $��Modify��6*   $��
50,5,10,10q�68   $��1��6L   5B      5C      5E      5F      