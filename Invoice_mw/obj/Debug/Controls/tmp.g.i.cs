#pragma checksum "..\..\..\Controls\tmp.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72CE3D479DD3D25461909453F96BB03765736B8E27E5E288C403C9FE4C4B8890"
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


namespace Invoice_mw.Controls
{


    /// <summary>
    /// AddInvoice
    /// </summary>
    public partial class tmppp : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Invoice_mw;component/controls/tmp.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Controls\tmp.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.FA_number = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.Issue_date = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.Due_date = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.Payment_methode = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.SubjectFromComboBox = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 6:
                    this.SubjectForComboBox = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 7:
                    this.items_grid_view = ((System.Windows.Controls.DataGrid)(target));

#line 84 "..\..\..\Controls\tmp.xaml"
                    this.items_grid_view.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.Items_grid_view_AutoGeneratingColumn);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

