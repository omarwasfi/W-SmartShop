   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WPF_GUI.Staff.StaffsManagerUCWPF_GUI.Staff.StaffsManagerUC  3    -WPF_GUI.Staff.StaffsManagerUC.StaffsManagerUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:WPF_GUI.Staff.StaffsManagerUC     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+��� -     ��Name$&   StaffSearchValue_StaffsManagerUC��$
��Left=�$��28��$��
606,28,0,0q� �� TextWrapping$
 Wrap=�$��
Search... ��$	��Top=�$	��396���� -    ��Name$% StaffSearchType_StaffsManagerUC��$
��Left=�$��1006,23,0,0q�$	��Top=�$	��120��$��33���� -    ��Name$' !StaffSearchButton_StaffsManagerUC�����	#FFA2A2A2$��Center=�$��1132,23,113,619q�$��38����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�$��25��$��25���� -   $. (ResetStaffsResultsButton_StaffsManagerUC��
���  ��$	��Top=�$��52��$��1252,10,10,0q���Z� ��Z� .��  $ Clear=�$��50��$��46���� $
��Left=�$	��Top=�$
��Wrap=����#707070 J� RenderTransformOrigin$ 0.596,0.438&�$��25(�$��6,18,0,0q��� $�Store : ���� -   $  StoreValue_StaffsManagerUC��$
��Left=�$��	87,23,0,0q�$	��Top=�$	��206�� �� IsTextSearchEnabled . &   System.Windows.Controls.DataGrid  -     Name$  StaffsList_StaffsManagerUC��   
IsReadOnly . 	   AutoGenerateColumns	 .  $
��Left=�$	��491��$��	10,66,0,0q�$	��Top=�$
��1323��
�������
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Staff Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Person.FullName+  $ UserName�� �� *
Username+  -   PasswordDataGrid��   
Visibility$ 	Collapsed=�$ Password�� �� *
Password+  $ Stores�� �� *	AllStores+  $ Permissions�� �� *AllTruePermissions+�� -   $*��$ShowPasswordCheckBox_StaffsManagerUC��$��Show Passwords��$
��Left=�$��
320,36,0,0q�$	��Top=��� -	   $!��CloseButton_StaffsManagerUC��$��Close��$
��Left=�$��1235,618,0,0q�$	��Top=�$��75���� $��Print��$
��Left=�$��1149,618,0,0q�$	��Top=�$��81���� -
   $* $ModifySelectedButton_StaffsManagerUC��$��20,580,1050,0q�$	��Top=�$��70��.��� $	��254��.+�  $ Pencil=�$��50��$��46���� $��20(�$��Modify selected��$��50,10,10,10q�