﻿#pragma checksum "..\..\Clients.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6FF76E9CDEF7C227C527C8FFC34329A26BB2E8F5DE5E1AB4881E61332459008C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using hntshd;


namespace hntshd {
    
    
    /// <summary>
    /// Clients
    /// </summary>
    public partial class Clients : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_ClientID;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Name;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Email;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Phone;
        
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
            System.Uri resourceLocater = new System.Uri("/hntshd;component/clients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Clients.xaml"
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
            
            #line 11 "..\..\Clients.xaml"
            ((hntshd.Clients)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Window_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 16 "..\..\Clients.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ESelect_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 17 "..\..\Clients.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.EInsert_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 18 "..\..\Clients.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.EUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 19 "..\..\Clients.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.EDelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tb_ClientID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tb_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 60 "..\..\Clients.xaml"
            this.dg.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.dg_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tb_Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tb_Phone = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

