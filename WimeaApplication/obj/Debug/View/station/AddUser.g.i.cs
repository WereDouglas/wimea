﻿#pragma checksum "..\..\..\..\View\station\AddUser.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DC63C97DDF8C7583798AA2915B0EE581"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace WimeaApplication.View {
    
    
    /// <summary>
    /// AddUser
    /// </summary>
    public partial class AddUser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\View\station\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblQuestion;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\View\station\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDialogOk;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\View\station\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTxtBx;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\View\station\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTxtBx;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\View\station\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox stationTxtCbx;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\station\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox roleTxtBx;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\station\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox contactTxtBx;
        
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
            System.Uri resourceLocater = new System.Uri("/WimeaApplication;component/view/station/adduser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\station\AddUser.xaml"
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
            
            #line 6 "..\..\..\..\View\station\AddUser.xaml"
            ((WimeaApplication.View.AddUser)(target)).ContentRendered += new System.EventHandler(this.Window_ContentRendered);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblQuestion = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnDialogOk = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\View\station\AddUser.xaml"
            this.btnDialogOk.Click += new System.Windows.RoutedEventHandler(this.btnDialogOk_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.nameTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.emailTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.stationTxtCbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.roleTxtBx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.contactTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

