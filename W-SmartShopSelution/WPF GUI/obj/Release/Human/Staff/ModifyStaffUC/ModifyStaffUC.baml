   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPF_GUI.Staff.ModifyStaffUCWPF_GUI.Staff.ModifyStaffUC  /    )WPF_GUI.Staff.ModifyStaffUC.ModifyStaffUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:WPF_GUI.Staff.ModifyStaffUC     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� $��10q�.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070  J� RenderTransformOrigin$  0.596,0.438&�$��25(�$��	13,87,0,0q��� $�Username : ���� -    ��Name$! UsernameValue_ModifyStaffUC��$
��Left=�$��33��$��
148,87,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��335���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��25(�$��
13,125,0,0q��� $�Password : ���� -   $! PasswordValue_ModifyStaffUC��$
��Left=�$��33��$��148,125,0,0q�$
 Wrap=�$	��Top=�$	��335���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��25(�$��
13,185,0,0q��� $�Permissions : ���� -   $ ��SellCheckBox_ModifyStaffUC��$
��Sell��$
��Left=�$��148,256,0,0q�$	��Top=��� -   $%��InventoryCheckBox_ModifyStaffUC��$��	Inventory��$
��Left=�$��148,330,0,0q�$	��Top=��� -   $*��$ProductManagerCheckBox_ModifyStaffUC��$��Product Manager��$
��Left=�$��148,408,0,0q�$	��Top=��� -   $)��#StaffsManagerCheckBox_ModifyStaffUC��$��Staffs Manager��$
��Left=�$��148,500,0,0q�$	��Top=�� $
��Left=�$��64��$��235,256,0,0q�$	��Top=�$	��480��.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(��� $�
- Selling ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��	204,0,0,0q��� $�- See customers Logs ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��0,24,0,0q��� $�- Add Customers ��� $
��Left=�$��64��$��255,330,0,0q�$	��Top=�$	��480��.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(��� $ �- Manage the store Stocks ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��0,24,0,0q��� $7�1- Add Stocks or Remove stocks from the inventory ��� $
��Left=�$��64��$��267,408,0,0q�$	��Top=�$
��1026��.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(��� $!�- Manage all stores stocks ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��0,24,0,0q��� $X�R- Edit the Prodcuts , can change Name , Serial Number , sale price , income Price ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��	666,0,0,0q��� $�- Create new Prodcuts  ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��
666,29,0,0q��� $)�#- Create new Categories Or Brands  ��� $
��Left=�$��64��$��267,500,0,0q�$	��Top=�$
��1026��.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(��� $/�)- Manage all staff members in all stores ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��0,24,0,0q��� $=�7- Edit the staff Info , can change username , password ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��	666,0,0,0q��� $&� - Edit staff member as a Person ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��18(�$��
666,29,0,0q��� $ �- Edit staff permissions  ���� -    ��Name$$ EditPersonButton_ModifyStaffUC��$��1060,10,10,0q�$	��Top=�$��70��.��� $	��254��.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Pencil=�$��50��$��46���� $��20(�$��Edit As a Person��$��50,10,10,10q��� -   $ CloseButton_ModifyStaffUC��$��Close��$
��Left=�$	��Top=�$��75��$��1208,618,0,0q��� -	   $ ResetButton_ModifyStaffUC��$��Reset��$
��Left=�$	��Top=�$��75��$��1128,618,0,0q��� -
   $! ConfirmButton_ModifyStaffUC��$��Confirm��$
��Left=�$	��Top=�$	��103��$��1020,618,0,0q��� $
��Left=�$y�	Collapsed=�$	��Top=�$
��Wrap=����#707070$  0.596,0.438&�$��25(�$��
510,47,0,0q��� $�	Stores : ���� -    ��Name$&  FayedStoreCheckBox_ModifyStaffUC��$y�	Collapsed=�$��Fayed Store��$
��Left=�$��
606,99,0,0q�$	��Top=��� -   $&  CairoStoreCheckBox_ModifyStaffUC��$y�	Collapsed=�$��Cairo Store��$
��Left=�$��606,137,0,0q�$	��Top=��� -   $' !Ma3adiStoreCheckBox_ModifyStaffUC��$y�	Collapsed=�$��Ma3adi Store��$
��Left=�$��
795,99,0,0q�$	��Top=�	� -   $&�� ManagerRadioButton_ModifyStaffUC��$��Manager��$
��Left=�$��212,200,0,0q�$	��Top=�	� -   $'��!SellOnlyRadioButton_ModifyStaffUC��$��Selling Only��$
��Left=�$��395,200,0,0q�$	��Top=�	� -   $/��)SellAndInventoryRadioButton_ModifyStaffUC��$��Sell And Inventory��$
��Left=�$��598,197,0,0q�$	��Top=�	� -   $:��4SellInventoryProdcutManagerRadioButton_ModifyStaffUC��$*��$Sell, Inventory and Prodcut manager ��$
��Left=�$��795,200,0,0q�$	��Top=�