   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI       WPF_GUI.InstallmentOrderUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WPF_GUI     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� $��10q�.+�� $��1101,0,0,635q�.+��� -     ��Name$'  !CloseTabButton_InstallmentOrderUC��$y�	Collapsed=�
���  ��$	��Top=�$��	0,0,172,0q�$��25����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�$��20��$��20���� -   $(  "ReloadTabButton_InstallmentOrderUC��
�������$	��Top=�$��	171,0,0,0q�$��25����Z� ��Z� .��  $ Reload=�$��20��$��20���� -   $$  PrintButton_InstallmentOrderUC��
�������$	��Top=�$��
114,0,56,0q�$��25����Z� ��Z� .��  $ Printer=�$��20��$��20���� -   $&   ConfitmButton_InstallmentOrderUC��
��� � �$	��Top=�$��
54,0,113,0q�$��25����Z� ��Z� .��  $
 Done=�$��20��$��20���� $��Choose Product��$
��Left=�$	��299��$��	10,30,0,0q�$	��Top=�$	��635��.��� $	��614��$��0,0,0,-2q�.+��� $
��Left=�$	��Top=�$
��Wrap=����#707070 J� RenderTransformOrigin$ 0.596,0.438&�$��25(��� $�Category : ���� -    ��Name$&  CategoryValue_InstallmentOrderUC��$
��Left=�$��	124,5,0,0q�$	��Top=�$	��207���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	336,5,0,0q�$ 0.596,0.438&�$��25(�$��82���� $�Brand : ���� -   $# BrandValue_InstallmentOrderUC��$
��Left=�$��
423,10,0,0q�$	��Top=�$	��163���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��0,38,0,0q��� $�
Product : ���� -   $% ProductValue_InstallmentOrderUC��$
��Left=�$	��Top=�$	��476��$��
110,43,0,0q��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��0,76,0,0q�$ 0.596,0.438&�$��25(��� $�Serial Number : ���� -    ��Name$* $SerialNumberValue_InstallmentOrderUC��$
��Left=�$��23��$��
183,86,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��422���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	0,161,0,0q�$ 0.596,0.438&�$��25(��� $�Quantity : ���� -	   $&  QuantityValue_InstallmentOrderUC��$
��Left=�$��23��$��124,171,0,0q�$
 Wrap=�$�� ��$	��Top=�$��58��$ 0.544,-0.652&��� -
   $' !SalePriceValue_InstallmentOrderUC��$
��Left=�$��24��$��369,132,0,0q�$
 Wrap=�$�� ��$	��Top=�$��58��$ 0.544,-0.652&��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��244,123,0,0q�$ 0.596,0.438&�$��25(�$	��120���� $�Sale Price : ���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��432,123,0,0q�$ 0.596,0.438&�$��25(��� $�
Discount :���� -   $&  DiscountValue_InstallmentOrderUC��$
��Left=�$��24��$��546,132,0,0q�$
 Wrap=�$�� ��$	��Top=�$��58��$ 0.544,-0.652&��� -   $)  #AddProductButton_InstallmentOrderUC��$	��ADD��$
��Left=�$��365,169,0,0q�$	��Top=�$	��155��$��70��$��36(�$
��Bold"��� -   $+  %ClearProductButton_InstallmentOrderUC��
���  ��$	��Top=�$��52��$��525,187,10,0q���Z� ��Z� .��  $ Clear=�$��50��$��46���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	5,212,0,0q�$ 0.596,0.438&�$��25(��� $�Total Price : ���� -   $/ )TotalProductPriceValue_InstallmentOrderUC�� �� 
IsReadOnly . $
��Left=�$��23��$��137,222,0,0q�$
 Wrap=�$�� ��$	��Top=�$��58��$ 0.544,-0.652&��� -   $% InStockValue_InstallmentOrderUC��$
��Left=�$��24��$��111,132,0,0q�$
 Wrap=�$�� ��$	��Top=�$��58��$ 0.544,-0.652&�{�.  . �� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	0,123,0,0q�$ 0.596,0.438&�$��25(��� $�In Stock : ���� $��Customer��$
��Left=�$	��299��$��
650,30,0,0q�$	��Top=�$	��663��.��� .+��� -   $*  $NewCustomerButton_InstallmentOrderUC��$��New Customer��$
��Left=�$��482,197,0,0q�$	��Top=�$	��143��$��40��$��15(�$
��Bold"��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	10,10,0,0q�$ 0.596,0.438&�$��25(�$	��133��$��Full Name : ���� -   $* $CustomerNameValue_InstallmentOrderUC��$
��Left=�$��
224,18,0,0q�$	��Top=�$	��401���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	10,48,0,0q�$ 0.596,0.438&�$��25(�$	��193��$��Phone Number : ���� -   $) #PhoneNumberValue_InstallmentOrderUC��$
��Left=�$��23��$��
224,58,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��401���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��	10,86,0,0q�$ 0.596,0.438&�$��25(�$	��209��$��National Number : ���� -   $, &NationalNumberValue_InstallmentOrderUC��$
��Left=�$��
224,94,0,0q�$	��Top=�$	��401���� -   $2  ,SelectedCustomerLogButton_InstallmentOrderUC��$��Selected Customer log��$
��Left=�$��
10,148,0,0q�$	��Top=�$	��193��$��40��$��15(�$
��Bold"��� -   $,  &ClearCustomerButton_InstallmentOrderUC��
���  ��$	��Top=�$��50��$��550,138,10,0q���Z� ��Z� .��  $ Clear=�$��50��$��46��&   System.Windows.Controls.DataGrid  -     Name$+ %ChoosenProductList_InstallmentOrderUC��   
IsReadOnly . 	   AutoGenerateColumns	 .  $
��Left=�$	��171��$��
10,334,0,0q�$	��Top=�$
��1293��
�������
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Product.Name+  $ Quantity�� �� *
Quantity+  $ 
Sale Price�� �� *Product.SalePrice+  $ Discount�� �� *
Discount+  $ Total Price�� �� *GetTotalInstallmentPrice+�� -   $4  .RemoveSelectedProductButton_InstallmentOrderUC��
���  ��$��10,510,1058,0q�$	��Top=�$��60����Z� ��Z� .��� $	��229�� � RowDefinitions �� $��5* ��� $	��42* �.+�  $ RemoveCircle=�$��50��$��46��$��2���� $��20(�$��Remove Selected��$��
50,5,10,10q�$��1���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
10,570,0,0q�$ 0.596,0.438&�$��25(�$'��!Total Price Before installment : ���� -   $9 3TotalPriceBeforeInstallmentValue_InstallmentOrderUC�� . $
��Left=�$��33��$��349,575,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��191��$ 0.544,-0.652&��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��
10,613,0,0q�$ 0.596,0.438&�$��25(�$&�� Total Price After installment : ���� -   $8 2TotalPriceAfterInstallmentValue_InstallmentOrderUC�� . $
��Left=�$��33��$��349,613,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��191��$ 0.544,-0.652&��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��443,522,0,0q�$ 0.596,0.438&�$��25(�$��
Diposit : ��$��97���� -   $% DipositValue_InstallmentOrderUC��$
��Left=�$��33��$��545,522,0,0q�$
 Wrap=�$�� ��$	��Top=�$��94��$ 0.544,-0.652&��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��644,522,0,0q�$ 0.596,0.438&�$��25(�$��Number of months : ���� -   $, &NumberOfMonthsValue_InstallmentOrderUC��$
��Left=�$��33��$��879,522,0,0q�$
 Wrap=�$�� ��$	��Top=�$��39��$ 0.544,-0.652&��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��928,575,0,0q�$ 0.596,0.438&�$��25(�$
��EMI:���� -   $! EMIValue_InstallmentOrderUC�� . $
��Left=�$��33��$��985,575,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��186��$ 0.544,-0.652&��� -   $, &RateOfInterestValue_InstallmentOrderUC��$
��Left=�$��33��$��1114,522,0,0q�$
 Wrap=�$�� ��$	��Top=�$��37��$ 0.544,-0.652&��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��923,522,0,0q�$ 0.596,0.438&�$��25(�$��Rate of Interest  :��$	��191���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��1156,522,0,0q�$ 0.596,0.438&�$��25(�$��%��$��25���� $
��Left=�$	��Top=�$
��Wrap=����#707070$��618,570,0,0q�$ 0.596,0.438&�$��25(�$��Loan Amount : ���� -   $( "LoanAmountValue_InstallmentOrderUC�� . $
��Left=�$��33��$��791,570,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��127��$ 0.544,-0.652&��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��618,613,0,0q�$ 0.596,0.438&�$��25(�$��payments starting from :��(  "System.Windows.Controls.DatePicker  -   $*��$PaymentsStartDate_InstallmentOrderUC��   SelectedDateFormat$
 Long=�$
��Left=�$��893,621,0,0q�$	��Top=�   FirstDayOfWeek$ Monday=��� $
��Left=�$	��Top=�$
��Wrap=����#707070$��1186,522,-54,0q�$ 0.596,0.438&�$��25(�$��	per annum��$	��191��