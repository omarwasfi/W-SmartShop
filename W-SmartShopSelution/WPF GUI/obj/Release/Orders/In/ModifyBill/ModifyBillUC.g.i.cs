﻿#pragma checksum "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "68FA8C0AAFCA73EC74E6D79E83B36568DD87891B8D0074833F40F5B13394D834"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPF_GUI.Orders.In.ModifyBill;


namespace WPF_GUI.Orders.In.ModifyBill {
    
    
    /// <summary>
    /// ModifyBillUC
    /// </summary>
    public partial class ModifyBillUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BillDetailsValue_ModifyBillUC;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotalPriceValue_ModifyBillUC;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateValue_ModifyBillUC;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteButton_ModifyBillUC;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshButton_ModifyBillUC;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrintButton_ModifyBillUC;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmButton_ModifyBillUC;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StaffNameValue_ModifyBillUC;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF GUI;component/orders/in/modifybill/modifybilluc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BillDetailsValue_ModifyBillUC = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TotalPriceValue_ModifyBillUC = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
            this.TotalPriceValue_ModifyBillUC.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.MoneyValidation);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DateValue_ModifyBillUC = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.DeleteButton_ModifyBillUC = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
            this.DeleteButton_ModifyBillUC.Click += new System.Windows.RoutedEventHandler(this.DeleteButton_ModifyBillUC_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RefreshButton_ModifyBillUC = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.PrintButton_ModifyBillUC = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.ConfirmButton_ModifyBillUC = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\..\Orders\In\ModifyBill\ModifyBillUC.xaml"
            this.ConfirmButton_ModifyBillUC.Click += new System.Windows.RoutedEventHandler(this.ConfirmButton_ModifyBillUC_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StaffNameValue_ModifyBillUC = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

