﻿#pragma checksum "..\..\ClientsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0B47AC047B8D41904AC1DAC5CFC678E234F67D812735BBBE3413AC9C3C0941AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using JewerlyShop;
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


namespace JewerlyShop {
    
    
    /// <summary>
    /// ClientsWindow
    /// </summary>
    public partial class ClientsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProductsBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProvidersBtn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SalesBtn;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchText;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddClientBtn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ClientsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditClientBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/JewerlyShop;component/clientswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ClientsWindow.xaml"
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
            this.MainBtn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\ClientsWindow.xaml"
            this.MainBtn.Click += new System.Windows.RoutedEventHandler(this.MainBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ProductsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\ClientsWindow.xaml"
            this.ProductsBtn.Click += new System.Windows.RoutedEventHandler(this.ProductsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ProvidersBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\ClientsWindow.xaml"
            this.ProvidersBtn.Click += new System.Windows.RoutedEventHandler(this.ProvidersBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SalesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\ClientsWindow.xaml"
            this.SalesBtn.Click += new System.Windows.RoutedEventHandler(this.SalesBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ClientsWindow.xaml"
            this.ExitBtn.Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SearchText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.AddClientBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\ClientsWindow.xaml"
            this.AddClientBtn.Click += new System.Windows.RoutedEventHandler(this.AddClientBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EditClientBtn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\ClientsWindow.xaml"
            this.EditClientBtn.Click += new System.Windows.RoutedEventHandler(this.EditClientBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
