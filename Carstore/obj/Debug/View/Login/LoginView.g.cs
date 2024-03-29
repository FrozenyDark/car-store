﻿#pragma checksum "..\..\..\..\View\Login\LoginView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7DCC9C192798E77B8BA71EC8899C61AD54CC3B71CCB490A3F8A768079E7C1203"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Carstore.Properties;
using Carstore.View;
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


namespace Carstore.View.Login {
    
    
    /// <summary>
    /// LoginView
    /// </summary>
    public partial class LoginView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// MessageBlock Name Field
        /// </summary>
        
        #line 45 "..\..\..\..\View\Login\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock MessageBlock;
        
        #line default
        #line hidden
        
        /// <summary>
        /// EmailBox Name Field
        /// </summary>
        
        #line 55 "..\..\..\..\View\Login\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox EmailBox;
        
        #line default
        #line hidden
        
        /// <summary>
        /// PasswordBox Name Field
        /// </summary>
        
        #line 75 "..\..\..\..\View\Login\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        /// <summary>
        /// SavePasswordBox Name Field
        /// </summary>
        
        #line 92 "..\..\..\..\View\Login\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.CheckBox SavePasswordBox;
        
        #line default
        #line hidden
        
        /// <summary>
        /// ExitButton Name Field
        /// </summary>
        
        #line 98 "..\..\..\..\View\Login\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        /// <summary>
        /// LoginButton Name Field
        /// </summary>
        
        #line 103 "..\..\..\..\View\Login\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button LoginButton;
        
        #line default
        #line hidden
        
        /// <summary>
        /// RegisterButton Name Field
        /// </summary>
        
        #line 114 "..\..\..\..\View\Login\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button RegisterButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Carstore;component/view/login/loginview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Login\LoginView.xaml"
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
            this.MessageBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.EmailBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 80 "..\..\..\..\View\Login\LoginView.xaml"
            this.PasswordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SavePasswordBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.LoginButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

