﻿#pragma checksum "..\..\..\Windows\registrovaniKorisnikProzor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C45B4008E0584A6ED76197B67826AFDAC048B4DEEA0E983E725E995151F51EC0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SR41_2020_POP2021.Windows;
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


namespace SR41_2020_POP2021.Windows {
    
    
    /// <summary>
    /// registrovaniKorisnikProzor
    /// </summary>
    public partial class registrovaniKorisnikProzor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGTreninzi;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dodajTrening;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izmenaBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGRegKorisnik;
        
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
            System.Uri resourceLocater = new System.Uri("/SR41-2020-POP2021;component/windows/registrovanikorisnikprozor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
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
            this.DGTreninzi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
            this.DGTreninzi.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.DGTreninzi_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dodajTrening = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
            this.dodajTrening.Click += new System.Windows.RoutedEventHandler(this.dodajTrening_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.izmenaBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
            this.izmenaBtn.Click += new System.Windows.RoutedEventHandler(this.izmenaBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DGRegKorisnik = ((System.Windows.Controls.DataGrid)(target));
            
            #line 22 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
            this.DGRegKorisnik.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.DGRegKorisnik_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\..\Windows\registrovaniKorisnikProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

