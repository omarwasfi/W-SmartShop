   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_GUIWPF_GUI  5   	       WPF_GUI.LoginForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WPF_GUI     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��400��6   $	��600��6$    � 
ResizeMode$ NoResize=�60    � WindowStyle$
 None=�6F    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�6�    � Icon$1 +/WPF GUI;component/MainForm/Assets/Icon.png��6�   .��5
      � .+�5   
   ��  �� RadiusY$ 8��6    �� RadiusX$ 8��6    
�������6,   �� 5   
   $��Assets/welcome.jpeg��6   $��	310,0,0,0q�6-   $��UniformToFill=�6@   �� 5   
   $��	310,0,0,0q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 	#CC935E12��6#    � Offset$ 1Q�65   � 5      $
 	#CCEA4646��6#   � 5      $
 	#CCB89128��6#   $ 0.566Q�65   5      5      �� 5   
   $��20,10,290,10q�6   .+�5      �� $��Login��6   $��Segoe UI Black)�6$   $��24(�6@   $
��0,10q�6N   $	��Top=�6\   $
��Left=�6t   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Left=�6   $	��Top=�67   $
��Wrap=�6O   ���#707070�� 6y   $�Welcome to Linked Ashes��6}   6�   �� 5      $
��Left=�6   $	��Top=�67   $
��Wrap=�6O   ���	#FF2468AC�� 6{   $� Presented By,��6   6�   5      �� 5      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070�� 6u   $�Ashes Stadio.��6y   6�   �� 5      $
��0,15q�6   $ 
Horizontal=�6'   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6*   $��Center=�69   ���#7070706T   �� 5       -   5         ��Name$ UsernameValue��5       )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��61   $	��250��6[   $��5q�6g   6r   5!      �� 5"      $ 
Horizontal=�6   .+�5#        $	 Key=�6*   $��Center=�65   ���#7070706P   G� 5$      -   5         G�Name$ PasswordValue��5$      $ Password��65   $	��250��6_   $��5q�6k   6v   5%      �� 5,      $ 
Horizontal=�6   $��10,35q�62   .+�5-      �� -   5         ��Name$ LoginButton��5-      $��Center=�6.   $��LOGIN��6K   $��Impact)�6[   $��18(�6o   $	��100��6}   ���	#FF307CD6���	#FF307CD6$��50,0,0,0q�6�   6�   �� 5.      -   5        $ CancelButton��5.      $��Center=�6/   $��Cancel��6L   $��Impact)�6]   $��18(�6q   $	��100��6   ���	#FF307CD6���	#FF307CD6$��10,0,0,0q�6�   6�   5/      �� 50      $ 
Horizontal=�6   $��10,35q�62   .+�51      �� $��	Follow us��6   ���#707070$��Center=�6A   �� 52      $��Center=�6   $��Impact)�66   $��18(�6J   ���	#FF3D56AC���	#FF3D56AC.��53        $ Facebook=�6.   $��Center=�6>   
�������6Y   54      �� 55      $��Center=�6   $��Impact)�66   $��18(�6J   $
��15,0q�6X   ���	#FF01BAFF���	#FF01BAFF.��56        $ Twitter=�6.   $��Center=�6=   
�������6X   57      �� 58      $��Center=�6   $��Impact)�66   $��18(�6J   ���	#FFE05959���	#FFE05959.��59        $ Youtube=�6.   $��Center=�6=   
�������6X   5:      5;      5<      �� 5=   
   $��310,50,0,50q�6   .+�5>      �� $��Ashes Stodio��6   
�������$��Center=�6?   $��40(�6\   $��Champagne & Limousines)�6j   $
��Bold"�6�   �� 5?      $��Presents��6   
�������$��Center=�6;   $��40(�6X   $��Champagne & Limousines)�6f   $
��Bold"�6�   �� 5@      $��Linked Ashes for E.M.G��6   
�������$��Center=�6I   $	��280��6f   $��24(�6r   $��Champagne & Limousines)�6�   $
��Wrap=�6�    �� TextAlignment$ Center=�6�   $��0,50,0,0q�6�   �� 5A      $��Developed by,��6   
�������$��18(�6@   $��Champagne & Limousines)�6N   $
��Wrap=�6v   $ Right=�6�   $��10q�6�   �� 5B      $��
Omar Wasfi��6   
�������$��18(�6=   $��Champagne & Limousines)�6K   $
��Wrap=�6s   $ Right=�6�   $��10q�6�   5D      5E      5F      