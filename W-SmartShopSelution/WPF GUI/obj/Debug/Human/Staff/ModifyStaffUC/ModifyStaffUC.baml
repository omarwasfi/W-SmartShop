   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPF_GUI.Staff.ModifyStaffUCWPF_GUI.Staff.ModifyStaffUC  5      /    )WPF_GUI.Staff.ModifyStaffUC.ModifyStaffUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:WPF_GUI.Staff.ModifyStaffUC     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � $��10q�6   .+�5   
   �� $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070  J� RenderTransformOrigin$  0.596,0.438&�6p   $��25(�6�   $��	13,87,0,0q�6�   �� 6�   $�Username : ��6�   6�   �� 5   
   -   5         ��Name$! UsernameValue_ModifyStaffUC��5      $
��Left=�67   $��33��6R   $��
148,87,0,0q�6^    �� TextWrapping$
 Wrap=�6r   $	��Top=�6�   $	��335��6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$  0.596,0.438&�6p   $��25(�6�   $��
13,125,0,0q�6�   �� 6�   $�Password : ��6�   6�   �� 5   
   -   5        $! PasswordValue_ModifyStaffUC��5      $
��Left=�68   $��33��6S   $��148,125,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $	��335��6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$  0.596,0.438&�6p   $��25(�6�   $��
13,185,0,0q�6�   �� 6�   $�Permissions : ��6�   6�   �� 5   
   -   5        $ ��SellCheckBox_ModifyStaffUC��5      $
��Sell��6^   $
��Left=�6m   $��148,256,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $%��InventoryCheckBox_ModifyStaffUC��5      $��	Inventory��6h   $
��Left=�6|   $��148,330,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $*��$ProductManagerCheckBox_ModifyStaffUC��5      $��Product Manager��6r   $
��Left=�6�   $��148,408,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $)��#StaffsManagerCheckBox_ModifyStaffUC��5      $��Staffs Manager��6p   $
��Left=�6�   $��148,500,0,0q�6�   $	��Top=�6�   � 5   
   $
��Left=�6   $��64��6*   $��235,256,0,0q�66   $	��Top=�6K   $	��480��6c   .+�5      �� $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   �� 6�   $�
- Selling ��6�   6�   �� 5      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��	204,0,0,0q�6�   �� 6�   $�- See customers Logs ��6�   6�   �� 5      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��0,24,0,0q�6�   �� 6�   $�- Add Customers ��6�   6�   5      � 5   
   $
��Left=�6   $��64��6*   $��255,330,0,0q�66   $	��Top=�6K   $	��480��6c   .+�5      �� $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   �� 6�   $ �- Manage the store Stocks ��6�   6�   �� 5       $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��0,24,0,0q�6�   �� 6�   $7�1- Add Stocks or Remove stocks from the inventory ��6�   6�   5"      � 5#   
   $
��Left=�6   $��64��6*   $��267,408,0,0q�66   $	��Top=�6K   $
��1026��6c   .+�5$      �� $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   �� 6�   $!�- Manage all stores stocks ��6�   6�   �� 5%      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��0,24,0,0q�6�   �� 6�   $X�R- Edit the Prodcuts , can change Name , Serial Number , sale price , income Price ��6�   6  �� 5&      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��	666,0,0,0q�6�   �� 6�   $�- Create new Prodcuts  ��6�   6�   �� 5'      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��
666,29,0,0q�6�   �� 6�   $)�#- Create new Categories Or Brands  ��6�   6�   5)      � 5*   
   $
��Left=�6   $��64��6*   $��267,500,0,0q�66   $	��Top=�6K   $
��1026��6c   .+�5+      �� $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   �� 6�   $/�)- Manage all staff members in all stores ��6�   6�   �� 5,      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��0,24,0,0q�6�   �� 6�   $=�7- Edit the staff Info , can change username , password ��6�   6   �� 5-      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��	666,0,0,0q�6�   �� 6�   $&� - Edit staff member as a Person ��6�   6�   �� 5.      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$  0.596,0.438&�6t   $��18(�6�   $��
666,29,0,0q�6�   �� 6�   $ �- Edit staff permissions  ��6�   6�   50      �� 51   
   -   5         ��Name$$ EditPersonButton_ModifyStaffUC��51      $��1060,10,10,0q�6h   $	��Top=�6~   $��70��6�   .��52      � $	��254��6   .+�53      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Pencil=�6*   $��50��69   $��46��6D   �� 54      $��20(�6   $��Edit As a Person��6*   $��50,10,10,10q�6B   55      56      �� 57   
   -   5        $ CloseButton_ModifyStaffUC��57      $��Close��6\   $
��Left=�6l   $	��Top=�6�   $��75��6�   $��1208,618,0,0q�6�   �� 58   
   -	   5        $ ResetButton_ModifyStaffUC��58      $��Reset��6]   $
��Left=�6m   $	��Top=�6�   $��75��6�   $��1128,618,0,0q�6�   �� 59   
   -
   5        $! ConfirmButton_ModifyStaffUC��59      $��Confirm��6`   $
��Left=�6r   $	��Top=�6�   $	��103��6�   $��1020,618,0,0q�6�   �� 5;   
   $
��Left=�6   $y�	Collapsed=�6/   $	��Top=�6F   $
��Wrap=�6^   ���#707070$  0.596,0.438&�6�   $��25(�6�   $��
510,47,0,0q�6�   �� 6�   $�	Stores : ��6�   6�   �� 5=   
   -   5         ��Name$&  FayedStoreCheckBox_ModifyStaffUC��5=      $y�	Collapsed=�6=   $��Fayed Store��6T   $
��Left=�6j   $��
606,99,0,0q�6�   $	��Top=�6�   �� 5>   
   -   5        $&  CairoStoreCheckBox_ModifyStaffUC��5>      $y�	Collapsed=�6=   $��Cairo Store��6T   $
��Left=�6j   $��606,137,0,0q�6�   $	��Top=�6�   �� 5?   
   -   5        $' !Ma3adiStoreCheckBox_ModifyStaffUC��5?      $y�	Collapsed=�6>   $��Ma3adi Store��6U   $
��Left=�6l   $��
795,99,0,0q�6�   $	��Top=�6�   	� 5A   
   -   5        $&�� ManagerRadioButton_ModifyStaffUC��5A      $��Manager��6x   $
��Left=�6�   $��212,200,0,0q�6�   $	��Top=�6�   	� 5B   
   -   5        $'��!SellOnlyRadioButton_ModifyStaffUC��5B      $��Selling Only��6y   $
��Left=�6�   $��395,200,0,0q�6�   $	��Top=�6�   	� 5C   
   -   5        $/��)SellAndInventoryRadioButton_ModifyStaffUC��5C      $��Sell And Inventory��6�   $
��Left=�6�   $��598,197,0,0q�6�   $	��Top=�6�   	� 5D   
   -   5        $:��4SellInventoryProdcutManagerRadioButton_ModifyStaffUC��5D      $*��$Sell, Inventory and Prodcut manager ��6�   $
��Left=�6�   $��795,200,0,0q�6�   $	��Top=�6�   5H      5I      