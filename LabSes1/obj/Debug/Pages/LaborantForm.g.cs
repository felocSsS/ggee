#pragma checksum "..\..\..\Pages\LaborantForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AB7DB767FA5E3A76D95C6182C2A3A5BAC6D4E8699DE247672D69E8EDD2185942"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LabSes1.Pages;
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


namespace LabSes1.Pages {
    
    
    /// <summary>
    /// LaborantForm
    /// </summary>
    public partial class LaborantForm : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Pages\LaborantForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TbName;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\LaborantForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\LaborantForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMakeOrder;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Pages\LaborantForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUseAnalyzer;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Pages\LaborantForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnFindPatient;
        
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
            System.Uri resourceLocater = new System.Uri("/LabSes1;component/pages/laborantform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\LaborantForm.xaml"
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
            this.TbName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Pages\LaborantForm.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnMakeOrder = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Pages\LaborantForm.xaml"
            this.BtnMakeOrder.Click += new System.Windows.RoutedEventHandler(this.BtnMakeOrder_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnUseAnalyzer = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Pages\LaborantForm.xaml"
            this.BtnUseAnalyzer.Click += new System.Windows.RoutedEventHandler(this.BtnUseAnalyzer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnFindPatient = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Pages\LaborantForm.xaml"
            this.BtnFindPatient.Click += new System.Windows.RoutedEventHandler(this.BtnFindPatient_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

