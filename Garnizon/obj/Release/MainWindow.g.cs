﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6E9D0019EFCE851E13018C59186B83FCFC9CDEC5271DA61075249DB18518AC62"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Garnizon;
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


namespace Garnizon {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Garnizoni;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Ikonica1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Jedinice;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GarnizoniRaspored1;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GarnizoniRaspored2;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView JediniceRaspored1;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView JediniceRaspored2;
        
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
            System.Uri resourceLocater = new System.Uri("/Garnizon;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.Garnizoni = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.Garnizoni.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Garnizoni_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Ikonica1 = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Jedinice = ((System.Windows.Controls.ListBox)(target));
            
            #line 32 "..\..\MainWindow.xaml"
            this.Jedinice.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Jedinice_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GarnizoniRaspored1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 53 "..\..\MainWindow.xaml"
            this.GarnizoniRaspored1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.GarnizoniRaspored1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GarnizoniRaspored2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 60 "..\..\MainWindow.xaml"
            this.GarnizoniRaspored2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.GarnizoniRaspored2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.JediniceRaspored1 = ((System.Windows.Controls.ListView)(target));
            
            #line 67 "..\..\MainWindow.xaml"
            this.JediniceRaspored1.MouseMove += new System.Windows.Input.MouseEventHandler(this.JediniceRaspored1_MouseMove);
            
            #line default
            #line hidden
            
            #line 67 "..\..\MainWindow.xaml"
            this.JediniceRaspored1.DragEnter += new System.Windows.DragEventHandler(this.JediniceRaspored1_DragEnter);
            
            #line default
            #line hidden
            
            #line 67 "..\..\MainWindow.xaml"
            this.JediniceRaspored1.Drop += new System.Windows.DragEventHandler(this.JediniceRaspored1_Drop);
            
            #line default
            #line hidden
            return;
            case 7:
            this.JediniceRaspored2 = ((System.Windows.Controls.ListView)(target));
            
            #line 74 "..\..\MainWindow.xaml"
            this.JediniceRaspored2.MouseMove += new System.Windows.Input.MouseEventHandler(this.JediniceRaspored2_MouseMove);
            
            #line default
            #line hidden
            
            #line 74 "..\..\MainWindow.xaml"
            this.JediniceRaspored2.DragEnter += new System.Windows.DragEventHandler(this.JediniceRaspored2_DragEnter);
            
            #line default
            #line hidden
            
            #line 74 "..\..\MainWindow.xaml"
            this.JediniceRaspored2.Drop += new System.Windows.DragEventHandler(this.JediniceRaspored2_Drop);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

