   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WPF_GUI.Staff.StaffsManagerUCWPF_GUI.Staff.StaffsManagerUC  5      3    -WPF_GUI.Staff.StaffsManagerUC.StaffsManagerUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:WPF_GUI.Staff.StaffsManagerUC     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� -   5          ��Name$&   StaffSearchValue_StaffsManagerUC��5      $
��Left=�6=   $��28��6X   $��
606,28,0,0q�6d    �� TextWrapping$
 Wrap=�6x   $��
Search... ��6�   $	��Top=�6�   $	��396��6�   �� 5   
   -   5         ��Name$% StaffSearchType_StaffsManagerUC��5      $
��Left=�6<   $��1006,23,0,0q�6W   $	��Top=�6l   $	��120��6�   $��33��6�   �� 5   
   -   5         ��Name$' !StaffSearchButton_StaffsManagerUC��5      ���	#FFA2A2A2$��Center=�6�   $��1132,23,113,619q�6�   $��38��6�   ��6l   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6&   $��25��64   $��25��6?   5      �� 5   
   -   5        $. (ResetStaffsResultsButton_StaffsManagerUC��5      
���  ��$	��Top=�6�   $��52��6�   $��1252,10,10,0q�6�   ��6z   Z� ��6�   Z� .��5        $ Clear=�6&   $��50��63   $��46��6>   5      �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070 J� RenderTransformOrigin$ 0.596,0.438&�6p   $��25(�6�   $��6,18,0,0q�6�   �� 6�   $�Store : ��6�   6�   �� 5   
   -   5        $  StoreValue_StaffsManagerUC��5      $
��Left=�6v   $��	87,23,0,0q�6�   $	��Top=�6�   $	��206��6�    �� IsTextSearchEnabled . 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$  StaffsList_StaffsManagerUC��5         
IsReadOnly . 	   AutoGenerateColumns	 .  $
��Left=�6e   $	��491��6�   $��	10,66,0,0q�6�   $	��Top=�6�   $
��1323��6�   
�������
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Staff Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Person.FullName+  5      $ UserName��6%    67   �� *
Username+  5      -   5        PasswordDataGrid��   
Visibility$ 	Collapsed=�5   ?   $ Password��6V    6h   �� *
Password+  5      $ Stores��6%    65   �� *	AllStores+  5      $ Permissions��6%    6:   �� *AllTruePermissions+5$      �� 5&   
   -   5        $*��$ShowPasswordCheckBox_StaffsManagerUC��5&      $��Show Passwords��6r   $
��Left=�6�   $��
320,36,0,0q�6�   $	��Top=�6�   �� 5'   
   -	   5        $!��CloseButton_StaffsManagerUC��5'      $��Close��64   $
��Left=�6D   $��1235,618,0,0q�6_   $	��Top=�6u   $��75��6�   �� 5(   
   $��Print��6   $
��Left=�6!   $��1149,618,0,0q�6<   $	��Top=�6R   $��81��6j   �� 5*   
   -
   5        $* $ModifySelectedButton_StaffsManagerUC��5*      $��20,580,1050,0q�6s   $	��Top=�6�   $��70��6�   .��5+      � $	��254��6   .+�5,        $ Pencil=�6*   $��50��69   $��46��6D   �� 5-      $��20(�6   $��Modify selected��6*   $��50,10,10,10q�6A   5.      5/      52      53      