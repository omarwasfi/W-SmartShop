   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WPF_GUI.Orders.In.ModifyBillWPF_GUI.Orders.In.ModifyBill  5      /    )WPF_GUI.Orders.In.ModifyBill.ModifyBillUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:WPF_GUI.Orders.In.ModifyBill     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   �� $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
10,135,0,0q�6p     J� RenderTransformOrigin$  0.596,0.438&�6�   $��25(�6�   �� 6�   $�
Details : ��6�   6�   �� 5   
   -   5         ��Name$# BillDetailsValue_ModifyBillUC��5      $
��Left=�69   $��32��6T   $��147,136,0,0q�6`   $�� ��6u   $	��Top=�6}   $
��1169��6�    �� 	MaxLength$	 500��6�    �� MaxLines$ 1��6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��	10,97,0,0q�6p   $  0.596,0.438&�6�   $��25(�6�   �� 6�   $�Total Price : ��6�   6�   �� 5   
   -   5        $" TotalPriceValue_ModifyBillUC��5      $
��Left=�6]   $��22��6x   $��147,108,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��58��6�   $  0.544,-0.652&�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DateValue_ModifyBillUC��5      $
��Left=�65   $��
147,67,0,0q�6P   $	��Top=�6d   $	��129��6|      SelectedDateFormat$ Short=�6�   �� 5   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��	10,59,0,0q�6p   $  0.596,0.438&�6�   $��25(�6�   �� 6�   $�Date : ��6�   6�   � 5   
   $��1107,10,10,162q�6   .+�5      �� -   5         ��Name$ DeleteButton_ModifyBillUC��5      $y�Visible=�6`   
���  ��$	��Top=�6�   $��	3,0,170,0q�6�   $��25��6�   ��6u   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Garbage=�6*   $��20��69   $��20��6D   5      �� 5      -   5        $  RefreshButton_ModifyBillUC��5      
�������$	��Top=�6|   $��	171,0,0,0q�6�   $��25��6�   ��6;   Z� ��6Q   Z� .��5        $ Reload=�6*   $��20��68   $��20��6C   5      �� 5      -   5        $ PrintButton_ModifyBillUC��5      
�������$	��Top=�6x   $��
115,0,55,0q�6�   $��25��6�   ��67   Z� ��6M   Z� .��5        $ Printer=�6*   $��20��69   $��20��6D   5      �� 5       -   5        $  ConfirmButton_ModifyBillUC��5       
��� � �$	��Top=�6�   $��
56,0,111,0q�6�   $��25��6�   ��6b   Z� ��6x   Z� .��5!        $
 Done=�6*   $��20��66   $��20��6A   5"      5$      �� 5&   
   $
��Left=�6   $	��Top=�6/   $
��Wrap=�6G   ���#707070$��
694,59,0,0q�6p   $  0.596,0.438&�6�   $��25(�6�   �� 6�   $�Staff member : ��6�   6�   �� 5'   
   -   5        $! StaffNameValue_ModifyBillUC��5'      	 �� 
IsReadOnly	 . $
��Left=�6I   $��33��6d   $��
866,59,0,0q�6p   $�� ��6�   $	��Top=�6�   $	��142��6�   $	 500��6�   $ 1��6�   5+      5,      