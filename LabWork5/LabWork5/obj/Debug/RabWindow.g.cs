﻿#pragma checksum "..\..\RabWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3A78682F3D50E95505C784FEB6AD30BA4635341FEC1054E2580A6EAF78AD2422"
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
    /// RabWindow
    /// </summary>
    public partial class RabWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\RabWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxRab;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\RabWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame PageFrameRab;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RabWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Backupik;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\RabWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Comeback;
        
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
            System.Uri resourceLocater = new System.Uri("/LabWork5;component/rabwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RabWindow.xaml"
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
            this.cbxRab = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\RabWindow.xaml"
            this.cbxRab.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbxRab_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PageFrameRab = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.Backupik = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\RabWindow.xaml"
            this.Backupik.Click += new System.Windows.RoutedEventHandler(this.Backupik_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Comeback = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\RabWindow.xaml"
            this.Comeback.Click += new System.Windows.RoutedEventHandler(this.Comeback_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

