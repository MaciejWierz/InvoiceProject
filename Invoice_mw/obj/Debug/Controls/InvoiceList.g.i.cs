﻿#pragma checksum "..\..\..\Controls\InvoiceList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ADB12E07603092CA6746039E755A316F6C97F9C0A7C47DAB007E4CDD33445094"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Invoice_mw.Controls;
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


namespace Invoice_mw.Controls {
    
    
    /// <summary>
    /// InvoiceList
    /// </summary>
    public partial class InvoiceList : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Controls\InvoiceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid invoice_grid_view;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Controls\InvoiceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddInvoice;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Controls\InvoiceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteInvoice;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Controls\InvoiceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToSubjects;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Controls\InvoiceList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToItems;
        
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
            System.Uri resourceLocater = new System.Uri("/Invoice_mw;component/controls/invoicelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\InvoiceList.xaml"
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
            this.invoice_grid_view = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\..\Controls\InvoiceList.xaml"
            this.invoice_grid_view.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Invoice_grid_view_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\Controls\InvoiceList.xaml"
            this.invoice_grid_view.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.Invoice_grid_view_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Controls\InvoiceList.xaml"
            this.AddInvoice.Click += new System.Windows.RoutedEventHandler(this.AddInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Controls\InvoiceList.xaml"
            this.DeleteInvoice.Click += new System.Windows.RoutedEventHandler(this.DeleteInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ToSubjects = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Controls\InvoiceList.xaml"
            this.ToSubjects.Click += new System.Windows.RoutedEventHandler(this.ToSubjects_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ToItems = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Controls\InvoiceList.xaml"
            this.ToItems.Click += new System.Windows.RoutedEventHandler(this.ToItems_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

