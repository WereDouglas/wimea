﻿#pragma checksum "..\..\..\..\View\station\StationPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "03953ABEBF269148DDF88A51301DDA52"
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


namespace WimeaApplication {
    
    
    /// <summary>
    /// StationPage
    /// </summary>
    public partial class StationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView StationGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView grdTest;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkSelectAll;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd_Copy;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image alert;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblName;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilter;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\View\station\StationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button print;
        
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
            System.Uri resourceLocater = new System.Uri("/WimeaApplication;component/view/station/stationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\station\StationPage.xaml"
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
            this.StationGrid = ((System.Windows.Controls.ListView)(target));
            
            #line 10 "..\..\..\..\View\station\StationPage.xaml"
            this.StationGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StationGrid_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grdTest = ((System.Windows.Controls.GridView)(target));
            return;
            case 3:
            this.chkSelectAll = ((System.Windows.Controls.CheckBox)(target));
            
            #line 22 "..\..\..\..\View\station\StationPage.xaml"
            this.chkSelectAll.Click += new System.Windows.RoutedEventHandler(this.chkSelectAll_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\View\station\StationPage.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAdd_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\View\station\StationPage.xaml"
            this.btnAdd_Copy.Click += new System.Windows.RoutedEventHandler(this.btnDeleteAll_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.alert = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.lblName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.txtFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\..\..\View\station\StationPage.xaml"
            this.txtFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtFilter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.print = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\..\View\station\StationPage.xaml"
            this.print.Click += new System.Windows.RoutedEventHandler(this.print_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 39 "..\..\..\..\View\station\StationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 55 "..\..\..\..\View\station\StationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

