﻿#pragma checksum "..\..\..\Views\ArchiveDetailWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "87CC3077AD23B759EE4E01DE5F4F90C6EBC94F13228D3493CE46E37B14BE2B0D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CameraCapture.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace CameraCapture.Views {
    
    
    /// <summary>
    /// ArchiveDetailWindow
    /// </summary>
    public partial class ArchiveDetailWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Views\ArchiveDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageLeft;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\ArchiveDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSetLeft;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\ArchiveDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageRight;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\ArchiveDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSetRight;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\ArchiveDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CameraCapture.Views.GalleryControl gallery;
        
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
            System.Uri resourceLocater = new System.Uri("/CameraCapture;component/views/archivedetailwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ArchiveDetailWindow.xaml"
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
            this.imageLeft = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.btnSetLeft = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Views\ArchiveDetailWindow.xaml"
            this.btnSetLeft.Click += new System.Windows.RoutedEventHandler(this.SetImageToLeft);
            
            #line default
            #line hidden
            return;
            case 3:
            this.imageRight = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.btnSetRight = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Views\ArchiveDetailWindow.xaml"
            this.btnSetRight.Click += new System.Windows.RoutedEventHandler(this.SetImageToRight);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gallery = ((CameraCapture.Views.GalleryControl)(target));
            return;
            case 6:
            
            #line 53 "..\..\..\Views\ArchiveDetailWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseThisWindow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

