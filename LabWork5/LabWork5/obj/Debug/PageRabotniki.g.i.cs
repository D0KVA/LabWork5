﻿#pragma checksum "..\..\PageRabotniki.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E43FC5A155778461951BFA07A9BFD35B5CE2016C290B283314878AC0BC138A56"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LabWork5;
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


namespace LabWork5 {
    
    
    /// <summary>
    /// PageRabotniki
    /// </summary>
    public partial class PageRabotniki : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_rb;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxSurname;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxMiddleName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxdID;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\PageRabotniki.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxdrID;
        
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
            System.Uri resourceLocater = new System.Uri("/LabWork5;component/pagerabotniki.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageRabotniki.xaml"
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
            this.dg_rb = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\PageRabotniki.xaml"
            this.dg_rb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg_rb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\PageRabotniki.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\PageRabotniki.xaml"
            this.DeleteButton.Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\PageRabotniki.xaml"
            this.ChangeButton.Click += new System.Windows.RoutedEventHandler(this.ChangeButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbxSurname = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\PageRabotniki.xaml"
            this.tbxSurname.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbxSurname_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbxName = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\PageRabotniki.xaml"
            this.tbxName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbxName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbxMiddleName = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\PageRabotniki.xaml"
            this.tbxMiddleName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbxMiddleName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cbxdID = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cbxdrID = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
