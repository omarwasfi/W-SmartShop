   M S B A M L   `   `   `  ����B  >WPF GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPF_GUI.SellWPF_GUI.Sell  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M4clr-namespace:System.Globalization;assembly=mscorlibSystem.Globalization 5	   C   !clr-namespace:WPF_GUIWPF_GUI  6�       WPF_GUI.Sell.SellUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WPF_GUI.Sell     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Stimulsoft.Report.Wpf, Version=2020.1.1.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a1	wpfViewer!schemas-stimulsoft-com:wpf-viewer  5      ` \Syncfusion.Gantt.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89d	 `Syncfusion.SfTreeMap.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89i
 eSyncfusion.SfColorPalette.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfSpreadsheet.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89d `Syncfusion.OlapChart.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e aSyncfusion.GridCommon.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j fSyncfusion.SfBusyIndicator.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Gauge.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89d `Syncfusion.SfDiagram.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89c _Syncfusion.OlapGrid.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89i eSyncfusion.ReportDesigner.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfBulletGraph.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89c _Syncfusion.Schedule.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89d `Syncfusion.SfHubTile.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89f bSyncfusion.Shared.MVVM.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89` \Syncfusion.Linq.Base, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89k gSyncfusion.SfRichTextRibbon.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89i eSyncfusion.SfSpellChecker.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfChart.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89g cSyncfusion.SfRadialMenu.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfMaps.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89d `Syncfusion.OlapGauge.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89f bSyncfusion.SfAccordion.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89d `Syncfusion.OlapTools.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e  aSyncfusion.OlapShared.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a! ]Syncfusion.SfGrid.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89i" eSyncfusion.RichTextBoxAdv.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a# ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89d$ `Syncfusion.SfHeatMap.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b% ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_& [Syncfusion.Grid.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89j' fSyncfusion.SfTreeNavigator.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89k( gSyncfusion.SfRichTextBoxAdv.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89g) cSyncfusion.PropertyGrid.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e* aSyncfusion.OlapClient.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89_+ [Syncfusion.Edit.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`, \Syncfusion.Tools.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e- aSyncfusion.SfSchedule.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b. ^Syncfusion.SfGauge.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89e/ aSyncfusion.SfCellGrid.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h0 dSyncfusion.PivotAnalysis.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89g1 cSyncfusion.ReportViewer.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`2 \Syncfusion.Olap.Base, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89m3 iSyncfusion.SfNavigationDrawer.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`4 \Syncfusion.Chart.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89i5 eSyncfusion.PivotAnalysis.Base, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b6 ^Syncfusion.Diagram.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h7 dSyncfusion.SfProgressBar.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89�
syncfusion!http://schemas.syncfusion.com/wpf0  	 
                        ! " # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 5	      �Globalization4clr-namespace:System.Globalization;assembly=mscorlib0  	 
                        ! " # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 6C   �WPF_GUIclr-namespace:WPF_GUI0  	 
                        ! " # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 6�   .��5      � .+�5   
   � -   5          �Name$  UserGrid��5      $y�Visible=�6!   .+�5      � $��1117,0,0,651q�6   .+�5      �� -   5         ��Name$ CloseTabButton��5      $y�	Collapsed=�61   
���  ��$	��Top=�6�   $��	3,0,170,0q�6�   $��25��6�   ��6H   Z� ��6^   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   $��20��6;   $��20��6F   5      �� 5      -   5        $ ReloadTabButton��5      
�������$	��Top=�6�   $��	171,0,0,0q�6�   $��25��6�   ��6P   Z� ��6f   Z� .��5        $ Reload=�6.   $��20��6<   $��20��6G   5      �� 5      -   5        $ PrintButton��5      
�������$	��Top=�6�   $��
115,0,55,0q�6�   $��25��6�   ��6H   Z� ��6^   Z� .��5        $ Printer=�6.   $��20��6=   $��20��6H   5      �� 5      -   5        $ ConfitmButton��5      
��� � �$	��Top=�6�   $��
56,0,111,0q�6�   $��25��6�   ��6M   Z� ��6c   Z� .��5        $
 Done=�6.   $��20��6:   $��20��6E   5       5"      �� 5$      -   5         ��Name$ ChooseProductGB��5$      $��Choose Product��60   $
��Left=�6H   $	��206��6c   $��	10,29,0,0q�6p   $	��Top=�6�   $
��1323��6�   .��5%      � $
��1310��6   $	��163��6$   $	��Top=�61   $��0,0,0,-9q�6I   .+�5)      �� $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070 J� RenderTransformOrigin$ 0.596,0.438&�6|   $��25(�6�   $��0,1,0,0q�6�   �� 6�   $�Category : ��6�   6�   �� 5*      -   5         ��Name$ CategoryFilterValue��5*       �� IsTextSearchEnabled .  w� TextPath$
 Name��6�   $
��Left=�6�   $��	116,6,0,0q�6�   $	��Top=�6�   $	��155��6�   �� 5-      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��	276,1,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   $��82��6�   �� 6�   $�Brand : ��6�   6�   �� 5.      -   5        $ BrandFilterValue��5.       . $
 Name��6�   $
��Left=�6�   $��	363,6,0,0q�6�   $	��Top=�6�   $	��155��6�   �� 51      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$ 0.596,0.438&�6|   $��25(�6�   $��	523,1,0,0q�6�   �� 6�   $�
Product : ��6�   6�   �� 52      -	   5        $ ProductNameFilterValue��52       . $
 Name��6�   $
��Left=�6�   $	��Top=�6�   $��17��6�   $��
1080,6,0,0q�6�   : ! 4Syncfusion.UI.Xaml.Grid.SfMultiColumnDropDownControl  53      -
   5          Name$ ProductNameSearchValue��53   >   	   PopupBorderBrush
	 �����
   PopupBackground

 �����$��RightToLeft=�6�      AutoGenerateColumns .     AllowNullInput .    AllowAutoComplete .    AllowImmediatePopup . $
��Left=�6W  $��29��6r  $	��Top=�6  $	��454��6�  $��	626,5,0,0q�6�  
���   �
������� &  "SfMultiColumnDropDownControlStyle1#���   6�     Columns 55      , ! &Syncfusion.UI.Xaml.Grid.GridTextColumn  , ! &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ Product Name��68      MappingName$
 Name��6R     56      $
 Size��68   $
 Size��6J     57      $ Serial Number��68   $ SerialNumber��6S     58      $ Serial Number 2��68   $ SerialNumber2��6U   ��5:      �� 5;       �� EndPoint$
 0,20&�62    � MappingMode$ Absolute=�6B    �� 
StartPoint$	 0,0&�6Y   .��5<   "   �  � Color$ 	#FFABADB3��6/    � Offset$
 0.05Q�6A   � 5=   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5>   "   $
 Gray��6/   $ 1Q�6<   5?      5A      �� 5D      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��
1105,1,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   $	��106��6�   �� 6�   $�
Barcode : ��6�   6�   4 % .Syncfusion.Windows.Controls.Input.SfTextBoxExt  5E      -   5          Name$ ProductBarCodeSearchValue��5E   .   $��LeftToRight=�6�      HighlightedTextColor
 �  ��   TextHighlightMode$ MultipleOccurrence=�6�   $
��Left=�6�   $��29��6
  $	��Top=�6  $��89��6/  $��
1211,5,0,0q�6:  
���   �
������� �� MaxLines$ 1��6t  $��18(�6�  .��6�  ��5F      �� 5G      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5H   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5I   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5J   "   $
 Gray��6/   $ 1Q�6<   5K      .��5L   ?   5M      �� 5P      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��
672,39,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   $	��176��6�   �� 6�   $�Serial Number : ��6�   6�     5Q      -   5        $$ ProductSerialNumberSearchValue��5Q   .   $��LeftToRight=�6�   
 �  ��$ MultipleOccurrence=�6�   $
��Left=�6�   $��29��6  $	��Top=�6  $	��134��67  $��
848,43,0,0q�6C  $��18(�6W  
���   �
�������$ 1��6�  .��6�  ��5R      �� 5S      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5T   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5U   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5V   "   $
 Gray��6/   $ 1Q�6<   5W      .��5X   ?   5Y      �� 5\      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��
984,39,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   $	��186��6�   �� 6�   $�Serial Number2 : ��6�   6�     5]      -   5        $% ProductSerialNumber2SearchValue��5]   .   $��LeftToRight=�6�   
 �  ��$ MultipleOccurrence=�6�   $
��Left=�6�   $��29��6  $	��Top=�6"  $	��130��6:  $��1170,39,0,0q�6F  $��18(�6[  
���   �
�������$ 1��6�  .��6�  ��5^      �� 5_      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5`   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5a   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5b   "   $
 Gray��6/   $ 1Q�6<   5c      .��5d   ?   5e      �� 5h      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��0,39,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�
Details : ��6�   6�   �� 5i      -   5         ��Name$ ProductDetailsValue��5i       �� 
IsReadOnly . $
��Left=�6M   $��33��6h   $��	94,39,0,0q�6t   $�� ��6�   $	��Top=�6�   $	��424��6�    �� 	MaxLength$	 500��6�   $ 1��6�   �� 5l      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��
523,39,0,0q�6|   $ -0.048,0.481&�6�   $��25(�6�   $��58��6�   �� 6�   $�Size : ��6�   6�   �� 5m      -   5        $ ProductSizeValue��5m       . $
��Left=�6J   $��33��6e   $��
586,39,0,0q�6q   $�� ��6�   $	��Top=�6�   $��82��6�   $	 200��6�   $ 1��6�   �� 5r      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$ 0.596,0.438&�6|   $��25(�6�   $��0,77,0,0q�6�   �� 6�   $�SBarcode : ��6�   6�     5s      -   5        $ SBarCodeSearchValue��5s   .   $��RightToLeft=�6�   
 �  ��$ MultipleOccurrence=�6�   $
��Left=�6�   $��29��6�    �� TextWrapping$
 Wrap=�6  $	��Top=�6  $	��130��65  $��
117,81,0,0q�6A  $��18(�6U  
���   �
�������$ 1��6�  .��6�  ��5t      �� 5u      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5v   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5w   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5x   "   $
 Gray��6/   $ 1Q�6<   5y      .��5z   ?   5{      �� 5|      -   5        $ SBarCodeFilterValue��5|      $
��Left=�6t   $	��Top=�6�   $��17��6�   $��
247,82,0,0q�6�   �� 5      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��
269,77,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   $	��102��6�   �� 6�   $�In Stock : ��6�   6�   - # 'Syncfusion.Windows.Shared.DoubleTextBox  5�      -   5          Name$ InStockValue��5�   /    .     MinValue$  0Q�6W   $
��Left=�6d   $��28��6   $��
376,82,0,0q�6�   !   NumberGroupSeparator$! ,��6�   "   NumberDecimalDigits$" 2��6�   #   NumberDecimalSeparator$# .��6�   $��DoubleTextBox��6�   $   Value$$ 0X�6   $	��Top=�6
  $��60��6"  $��18(�6-  $ 1��6;  .��6H  ��5�      �� 5�      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5�   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5�   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5�   "   $
 Gray��6/   $ 1Q�6<   5�      .��5�   @   5�      �� 5�      -   5        $ InStockFilterValue��5�       . $
 Name��6�   $
��Left=�6�   $	��Top=�6�   $��17��6�   $��
436,82,0,0q�6�   �� 5�      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��
771,77,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Sale Price : ��6�   6�   / # )Syncfusion.Windows.Shared.CurrencyTextBox  5�      -   5        %  Name$% StockSalePriceValue��5�   1    .  &   Value$& 0X�6�   '   CurrencyNegativePattern$' 8��6�   (   CurrencyPositivePattern$( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��125��6  $��
900,83,0,0q�6  $��27��6'  $��18(�6I  ) �� SelectionBrush) �	#FF009688$ 
0.68,0.352&�6r  *   MinValue$* 0~�6�  $ 1��6�  ��63  Z� .��6�  *	 # $Syncfusion.Windows.Shared.EditorBase+ 	  NumberFormat+ 5�      +
  %System.Globalization.NumberFormatInfo
  5�      , 
  CurrencyGroupSeparator$,  ��6=   - 
  CurrencyDecimalDigits$- 2��6X   . 
  CurrencyDecimalSeparator$. .��6r   / 
  CurrencySymbol$	/ L.E��6�   .��5�   C   ��5�      �� 5�      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5�   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5�   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5�   "   $
 Gray��6/   $ 1Q�6<   5�      .��5�   B   5�      �� 5�      -   5        $ StockSalePriceFilterValue��5�       . $ 	SalePrice��6�   $
��Left=�6�   $	��Top=�6�   $��17��6�   $��1025,82,0,0q�6�   �� 5�      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��
465,77,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Income Price :��6�   6�     5�      -   5        $% StockIncomePriceValue��5�   1    . $& 0X�6c   $' 8��6n   $( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��125��6�   $��
624,83,0,0q�6�   $��27��6�   $��18(�6  ) �	#FF009688$ 
0.68,0.352&�6G  $* 0~�6j  $ 1��6w  ��6  Z� .��6�  + 5�      
  5�      $,  ��6=   $- 2��6X   $. .��6r   $	/ L.E��6�   .��5�   C   ��5�      �� 5�      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5�   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5�   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5�   "   $
 Gray��6/   $ 1Q�6<   5�      .��5�   B   5�      �� 5�      -   5        $  StockInomePriceFilterValue��5�       . $ IncomePrice��6�   $
��Left=�6�   $	��Top=�6�   $��17��6�   $��
749,82,0,0q�6�   �� 5�      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$ 0.596,0.438&�6|   $��25(�6�   $��1040,77,0,0q�6�   �� 6�   $�Expiration : ��6�   6�   �� 5�      -   5        $ ExpirationValue��5�       . $
��Left=�6I   $��33��6d   $��1170,77,0,0q�6p   $�� ��6�   $	��Top=�6�   $	��113��6�   $	 200��6�   $ 1��6�   �� 5�      -   5        $ ExpirationFilterValue��5�       . $ ExpirationState��6�   $
��Left=�6�   $	��Top=�6�   $��17��6�   $��1283,82,0,0q�6�   �� 5�      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��117,117,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�
Discount :��6�   6�     5�      -   5        $% DiscountValue��5�   1    .  $& 0X�6�   $' 8��6�   $( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��125��6�   $��233,123,0,0q�6
  $��27��6  $��18(�6A  ) �	#FF009688$ 
0.68,0.352&�6j  $* 0~�6�  $ 1��6�  ��6+  Z� .��6�  + 5�      
  5�      $,  ��6=   $- 2��6X   $. .��6r   $	/ L.E��6�   .��5�   C   ��5�      �� 5�      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5�   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5�   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5�   "   $
 Gray��6/   $ 1Q�6<   5�      .��5�   B   5�      �� 5�      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��364,117,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   $��Profit: ��6�     5�      -   5        $% ProfitValue��5�   1    . $& 0X�6Y   $' 8��6c   $( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��125��6�   $��436,123,0,0q�6�   $��27��6�   $��18(�6  ) �	#FF009688$ 
0.68,0.352&�6=  $ 1��6`  ��6�   Z� .��6m  + 5�      
  5�      $,  ��6=   $- 2��6X   $. .��6r   $	/ L.E��6�   .��5�   C   ��5�      �� 5�      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5�   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5�   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5�   "   $
 Gray��6/   $ 1Q�6<   5�      .��5�   B   5�      �� 5�      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��565,117,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Quantity : ��6�   6�     5�      -   5        $ OrderProductQuantityValue��5�   /   $  0Q�6�   $
��Left=�6�   $��27��6�   $��684,123,0,0q�6�   $! ,��6�   $" 2��6�   $# .��6  $��DoubleTextBox��6  $$ 0X�63  $	��Top=�6=  $��60��6U  $��18(�6`  $ 1��6n  .��6{  ��5�      �� 5�      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5�   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5�   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5�   "   $
 Gray��6/   $ 1Q�6<   5�      .��5�   @   5�      �� 5�      $
��Left=�6    $	��Top=�6;   $
��Wrap=�6S   ���#707070$��749,117,0,0q�6|   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Total Price : ��6�   6�     5�      -   5        $!% OrderProductTotalPriceValue��5�   1    . $& 0X�6h   $' 8��6r   $( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��130��6�   $��886,123,0,0q�6�   $��27��6  $��18(�6#  ) �	#FF009688$ 
0.68,0.352&�6L  $* 0~�6o  $ 1��6|  ��6  Z� .��6�  + 5�      
  5�      $,  ��6=   $- 2��6X   $. .��6r   $	/ L.E��6�   .��5�   C   ��5�      �� 5�      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5�   "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5�   "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5�   "   $
 Gray��6/   $ 1Q�6<   5�      .��5�   B   5�      �� 5�      -   5        $ AddOrderProductButton��5�      $	��ADD��6`   $
��Left=�6n   $��1176,126,0,0q�6�   $	��Top=�6�   $��73��6�   $��34��6�   $��17(�6�   $
��Bold"�6�   �� 5�      -   5        $ ClearOrderProductButton��5�      
���  ��$	��Top=�6�   $��35��6�   $��1254,125,0,0q�6�   ��6d   Z� ��6z   Z� .��5�        $ Clear=�62   $��30��6?   $��30��6J   5�      5�      5�      �� 5�      $��Customer��6   $
��Left=�6)   $��88��6D   $��
10,240,0,0q�6P   $	��Top=�6d   $
��1323��6|   .��5�      � .+�5�      �� -    5        $ CustomerSearchTypeValue��5�      $��17��6|   $	��Top=�6�   $
 Name��6�   $��
1220,5,0,0q�6�    . $
��Left=�6�     5�      -!   5        $ CustomerSearchValue��5�   >   
	 �����

 �����$��RightToLeft=�6�    .   .  .  . $
��Left=�6  $��29��65  $	��Top=�6B  $	��574��6Z  $��	646,4,0,0q�6f  
���   �
�������#���   6�   5�        $ Customer Name��68   $ Person.FullName��6S     5�      $ Phone Number��68   $ Person.PhoneNumber��6R     5�      $ National Number��68   $ Person.NationalNumber��6U   ��5�      �� 5      $
 0,20&�62   $ Absolute=�6B   $	 0,0&�6Y   .��5  "   � $ 	#FFABADB3��6/   $
 0.05Q�6A   � 5  "   $ 	#FFE2E3EA��6/   $
 0.07Q�6A   � 5  "   $
 Gray��6/   $ 1Q�6<   5     5     �� 5	     -"   5        $ SelectedCustomerButton��5	     $��0,-1,1068,0q�6?   $	��Top=�6T   $��33��6l   .��5
     � $	��215��6   $��33��6+   .+�5       $ FormatListBulletedSquare=�66   $��25��6V   $��25��6a   �� 5     $��17(�6(   $��Selected Customer log��66   $��	30,0,0,10q�6S   5     5     �� 5     -#   5        $ AddNewCustomerButton��5     $��242,0,882,0q�6_   $	��Top=�6t   $��33��6�   .��5     � $	��162��6   $��33��6+   .+�5       $ PlusBox=�66   $��25��6E   $��25��6P   �� 5     $��17(�6(   $��New Customer��66   $��
30,0,10,10q�6J   5     5     �� 5     -$   5        $ ClearCusomerButton��5     
���  ��$	��Top=�6�   $��35��6�   $��
1249,0,0,0q�6�   ��6Z   Z� ��6p   Z� .��5       $ Clear=�62   $��30��6?   $��30��6J   5     5     5     &   System.Windows.Controls.DataGrid  5     -%   5        0  Name$0 OrderProductRecordList��5     1   
IsReadOnly1 . 2   AutoGenerateColumns2 .  $
��Left=�6e   $	��241��6�   $��
10,333,0,0q�6�   $	��Top=�6�   $
��1323��6�   
�������3   Columns3 5     0  *System.Windows.Controls.DataGridTextColumn  5     ,  &System.Windows.Controls.DataGridColumn4   Header$4 Product Name��6)   1  +System.Windows.Controls.DataGridBoundColumn5   Binding5 6?   �� *OrderProduct.Product.Name+  5      $
4 Size��6)   5 67   �� *OrderProduct.Product.Size+  5!     $4 SBarcode��6)   5 6;   �� *Stock.SBarCode+  5"     $4 Quantity��6)   5 6;   �� *OrderProduct.Quantity+  5#     $4 Price��6)   5 68   �� *OrderProduct.SalePrice+  5$     $4 Discount��6)   5 6;   �� *OrderProduct.Discount+  5%     $4 Profit��6)   5 69   �� *OrderProduct.Profit+  5&     $4 Total Profit��6)   5 6?   �� *OrderProduct.GetTotalProfit+  5'     $4 Total Price��6)   5 6>   �� *OrderProduct.GetTotalPrice+5)     �� 5*     -&   5        $! RemoveSelectedProductButton��5*     
���  ��$��0,579,1088,0q�6�   $	��Top=�6�   $��60��6�   ��6d   Z� ��6z   Z� .��5+     � $	��229��6   6 � RowDefinitions6 5,     �� 5-     $��5* �6(   �� 5.     $	��42* �6(   .+�50       $ RemoveCircle=�6.   $��50��6B   $��46��6M   $��2��6Y   �� 51     $��20(�6    $��Remove Selected��6.   $��
50,5,10,10q�6E   $��1��6Y   52     53     �� 56     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��255,599,0,0q�6t   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Total Profit : ��6�   6�     57     -'   5        $% TotalProfitValue��57  )    . $& 0X�6U   $' 8��6_   $( 3��6|   $	��Top=�6�   $
��Left=�6�   $	��130��6�   $��393,605,0,0q�6�   $��27��6�   $��18(�6  ) �	#FF009688$ 
0.68,0.352&�69  ��6�   Z� .��6\  + 58     
  59     $,  ��65   $- 2��6P   $. .��6j   $	/ L.E��6�   .��5:  ;   ��5;     �� 5<     $
 0,20&�6*   $ Absolute=�6:   $	 0,0&�6Q   .��5=     � $ 	#FFABADB3��6'   $
 0.05Q�69   � 5>     $ 	#FFE2E3EA��6'   $
 0.07Q�69   � 5?     $
 Gray��6'   $ 1Q�64   5@     .��5A  :   5B     �� 5E     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��533,599,0,0q�6t   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Total Price : ��6�   6�     5F     -(   5        $% OrderTotalPriceValue��5F  )    . $& 0X�6Y   $' 8��6c   $( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��130��6�   $��665,605,0,0q�6�   $��27��6�   $��18(�6  ) �	#FF009688$ 
0.68,0.352&�6=  $* 0~�6`  ��6�   Z� .��6m  + 5G     
  5H     $,  ��65   $- 2��6P   $. .��6j   $	/ L.E��6�   .��5I  ;   ��5J     �� 5K     $
 0,20&�6*   $ Absolute=�6:   $	 0,0&�6Q   .��5L     � $ 	#FFABADB3��6'   $
 0.05Q�69   � 5M     $ 	#FFE2E3EA��6'   $
 0.07Q�69   � 5N     $
 Gray��6'   $ 1Q�64   5O     .��5P  :   5Q     �� 5T     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��
16,642,0,0q�6t   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�
Details : ��6�   6�   �� 5U     -)   5        $ OrderDetailsValue��5U     $
��Left=�61   $��32��6L   $��115,643,0,0q�6X   $�� ��6m   $	��Top=�6u   $	��715��6�   $	 500��6�   $ 1��6�   	� 5X     -*   5        7 	�Name$7 CashRadioButton��5X     $y�Visible=�6U   $
��Cash��6j   $
��Left=�6y   $��887,576,0,0q�6�   $	��Top=�6�   	� 5Y     -+   5        $ 7 SuspendPayementRadioButton��5Y     $y�Visible=�6k   $��Suspend payment for later��6�   $
��Left=�6�   $��994,576,0,0q�6�   $	��Top=�6�   �� 5[     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��887,599,0,0q�6t   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $�Customer will pay now : ��6�   6�     5\     -,   5        $% CustomerWillPayNowValue��5\  )    .  $& 0X�6�   $' 8��6�   $( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��115��6  $��1164,605,0,0q�6  $��27��6)  $��18(�6K  ) �	#FF009688$ 
0.68,0.352&�6t  $* 0~�6�  ��65  Z� .��6�  + 5]     
  5^     $,  ��65   $- 2��6P   $. .��6j   $	/ L.E��6�   .��5_  ;   ��5`     �� 5a     $
 0,20&�6*   $ Absolute=�6:   $	 0,0&�6Q   .��5b     � $ 	#FFABADB3��6'   $
 0.05Q�69   � 5c     $ 	#FFE2E3EA��6'   $
 0.07Q�69   � 5d     $
 Gray��6'   $ 1Q�64   5e     .��5f  :   5g     �� 5i     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��887,637,0,0q�6t   $ 0.596,0.438&�6�   $��25(�6�   �� 6�   $ �Customer will pay Later : ��6�   6�     5j     --   5        $% CustomerWillPayLaterValue��5j  )    .  $& 0X�6�   $' 8��6�   $( 3��6�   $	��Top=�6�   $
��Left=�6�   $	��115��6
  $��1164,643,0,0q�6  $��27��6-  $��18(�6O  ) �	#FF009688$ 
0.68,0.352&�6x  $* 0~�6�  ��69  Z� .��6�  + 5k     
  5l     $,  ��65   $- 2��6P   $. .��6j   $	/ L.E��6�   .��5m  ;   ��5n     �� 5o     $
 0,20&�6*   $ Absolute=�6:   $	 0,0&�6Q   .��5p     � $ 	#FFABADB3��6'   $
 0.05Q�69   � 5q     $ 	#FFE2E3EA��6'   $
 0.07Q�69   � 5r     $
 Gray��6'   $ 1Q�64   5s     .��5t  :   5u     5v     � 5x  
   -.   5        $  	PrintGrid��5x     $y�	Collapsed=�6"   .+�5z     �� -/   5        $ BackToNormalGridButton��5z     $y�Visible=�6[   
��� � �$	��Top=�6�   $��
0,0,1287,0q�6�   $��25��6�   ��6p   Z� ��6�   Z� .��5{       $ 	ArrowLeft=�6*   $��20��6;   $��20��6F   5|     2  ,Stimulsoft.Report.Viewer.StiWpfViewerControl  5~     -0   5        8  Name$8 SellOrderReportPrint��5~  ,   $
��Left=�6J   $	��655��6e   $��0,25,0,0q�6r   $	��Top=�6�   $
��1343��6�   �� 5�     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��61,0,0,0q�6t   $ 0.596,0.438&�6�   $��18(�6�   $��25��6�   �� 6�   $�Order number: ��6�   6�   �� 5�     -1   5        $" OrganizationOrdersCountValue��5�      . $
��Left=�6N   $��25��6i   $��	183,0,0,0q�6u   $�� ��6�   $	��Top=�6�   $��60��6�   $	 500��6�   $ 1��6�   �� 5�     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��	259,0,0,0q�6t   $ 0.596,0.438&�6�   $��18(�6�   $��25��6�   �� 6�   $&� Order number to this customer : ��6�   6�   �� 5�     -2   5        $&  SelectedCustomerOrdersCountValue��5�      . $
��Left=�6R   $��25��6m   $��	520,0,0,0q�6y   $�� ��6�   $	��Top=�6�   $��60��6�   $	 500��6�   $ 1��6�   �� 5�     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��	585,0,0,0q�6t   $ 0.596,0.438&�6�   $��18(�6�   $��25��6�   �� 6�   $�Order number Today :��6�   6�   �� 5�     -3   5        $ OrderCountTodayValue��5�      . $
��Left=�6F   $��25��6a   $��	764,0,0,0q�6m   $�� ��6�   $	��Top=�6�   $��60��6�   $	 500��6�   $ 1��6�   �� 5�     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��	830,0,0,0q�6t   $ 0.596,0.438&�6�   $��18(�6�   $��25��6�   �� 6�   $�Order number :��6�   6�   �� 5�     -4   5        $ StaffOrderCountTodayValue��5�      . $
��Left=�6K   $��25��6f   $��	957,0,0,0q�6r   $�� ��6�   $	��Top=�6�   $��60��6�   $	 500��6�   $ 1��6�   �� 5�     $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$��
1017,0,0,0q�6t   $ 0.596,0.438&�6�   $��18(�6�   $��25��6�   �� 6�   $	�To:��6�   6�   �� 5�     -5   5        9 ��Name$9 StaffNameValue��5�     $
��Left=�60   $	��Top=�6K   $
��Wrap=�6c   ���#707070$��
1044,0,0,0q�6�   $ 0.596,0.438&�6�   $��18(�6�   $��25��6�   �� 6�   $�
Staff Name��6�   6�   5�     � 5�  
   -6   5        $  CreateCustomerGrid��5�     $y�	Collapsed=�6+   .+�5�     �� -7   5        $4 .BackToUserGridButton_FromCreateNewCustomerGrid��5�     $y�Visible=�6�   
��� � �$	��Top=�6�   $��
0,0,1291,0q�6�   $��30��6  ��6�   Z� ��6�   Z� .��5�       $ 	ArrowLeft=�6*   $��20��6;   $��20��6F   5�        WPF_GUI.CreatePersonUC  5�     $
��Left=�6%   $��0,30,0,0q�6@   $	��Top=�6R   5�     � 5�  
   -8   5        $  SelectedCustomerLogGrid��5�     $y�	Collapsed=�60   5�     5�     