   M S B A M L   `   `   `  ���� B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_GUI.ModifyPersonUCWPF_GUI.ModifyPersonUC  +    %WPF_GUI.ModifyPersonUC.ModifyPersonUC   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:WPF_GUI.ModifyPersonUC     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $��620.68��$��1281.659��.��� .+�� $��1038,0,0,595q�.+��� -     ��Name$  CloseButton��$y�	Collapsed=�
���  ��$	��Top=�$��	3,0,170,0q�$��25����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�$��20��$��20���� -   $  RefreshButton��
�������$	��Top=�$��	171,0,0,0q�$��25����Z� ��Z� .��  $ Reload=�$��20��$��20���� -   $  PrintButton��$y�	Collapsed=�
�������$	��Top=�$��
115,0,55,0q�$��25����Z� ��Z� .��  $ Printer=�$��20��$��20���� -   $  ConfirmButton��
��� � �$	��Top=�$��
107,0,60,0q�$��25����Z� ��Z� .��  $
 Done=�$��20��$��20���� $
��Left=�$	��Top=�$
��Wrap=����#707070 J� RenderTransformOrigin$ 0.596,0.438&�$��25(�$��	12,18,0,0q�$	��192��$��30���� $�First Name : ���� -    ��Name$ FirstNameValue�� �� 	MaxLength$ 50�� �� MaxLines$ 1��$
��Left=�$��
303,23,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��	12,53,0,0q�$	��192��$��30���� $�Last Name : ���� -   $ LastNameValue��$ 50��$ 1��$
��Left=�$��
303,58,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��	12,88,0,0q�$	��286��$��30���� $�Phone Number/Numbers: ���� -   $ PhoneNumberValue��$	 200��$ 1��$
��Left=�$��
303,93,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
12,123,0,0q�$	��210��$��30���� $�National Number : ���� -   $ NationalNumberValue��$	 200��$ 1��$
��Left=�$��303,128,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
12,332,0,0q�$	��210��$��30���� $�Email : ���� -	   $ 
EmailValue��$	 200��$ 1��$
��Left=�$��303,337,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
12,367,0,0q�$	��210��$��30���� $�
Address : ���� -
   $ AddressValue��$	 200��$ 1��$
��Left=�$��303,372,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
10,402,0,0q�$	��210��$��30���� $�City : ���� -   $ 	CityValue��$	 100��$ 1��$
��Left=�$��303,407,0,0q�$	��Top=�$	��114���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
10,437,0,0q�$	��210��$��30���� $�
Country : ���� -   $ CountryValue��$	 100��$ 1��$
��Left=�$��303,442.04,0,0q�$	��Top=�$	��114���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
12,158,0,0q�$	��210��$��30���� $�Date Of Birth : ��(  "System.Windows.Controls.DatePicker  -     Name$ BirthDateValue��$
��Left=�$��303,163,0,0q�$	��Top=�$	��141���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
12,193,0,0q�$	��210��$��30���� $�Jop Title : ���� -   $ JopTitleValue��$	 200��$ 1��$
��Left=�$��303,193,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
10,228,0,0q�$	��210��$��30���� $�Jop Address : ���� -   $ JopAddressValue��$	 200��$ 1��$
��Left=�$��303,233.04,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
10,263,0,0q�$	��223��$��30���� $�Date Of Gradution : ��  -   $ GraduationDateValue��$
��Left=�$��303,268,0,0q�$	��Top=�$	��141���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
10,298,0,0q�$	��210��$��30���� $�Qualification : ���� -   $ QualificationValue��$	 200��$ 1��$
��Left=�$��303,303.04,0,0q�$	��Top=�$	��368���� $
��Left=�$	��Top=�$
��Wrap=����#707070$ 0.596,0.438&�$��25(�$��
10,472,0,0q�$	��210��$��30���� $�
Details : ���� -   $ DetailsValue��$	 500��$ 1��$
��Left=�$��303,477.04,0,0q�$	��Top=�$	��586��