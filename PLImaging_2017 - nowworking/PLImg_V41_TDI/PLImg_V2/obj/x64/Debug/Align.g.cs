﻿#pragma checksum "..\..\..\Align.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A9412DCE967D87FE8198E153145B7AF6AEFDF267"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Emgu.CV.UI;
using PLImg_V2;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace PLImg_V2 {
    
    
    /// <summary>
    /// Align
    /// </summary>
    public partial class Align : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAngle;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnView;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnROrigin;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnZOrigin;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudThres;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudmove;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUp;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDw;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudmoveY;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpY;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDwY;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAlign;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStart;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudCannyThres;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudCannyLiking;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudHoughThres;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudLineWidth;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DoubleUpDown nudGap;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowArea;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Align.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxArea;
        
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
            System.Uri resourceLocater = new System.Uri("/PLImg_V2;component/align.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Align.xaml"
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
            
            #line 10 "..\..\..\Align.xaml"
            ((PLImg_V2.Align)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblAngle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnView = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Align.xaml"
            this.btnView.Click += new System.Windows.RoutedEventHandler(this.btnView_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnROrigin = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Align.xaml"
            this.btnROrigin.Click += new System.Windows.RoutedEventHandler(this.btnROrigin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnZOrigin = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Align.xaml"
            this.btnZOrigin.Click += new System.Windows.RoutedEventHandler(this.btnZOrigin_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nudThres = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 7:
            this.nudmove = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 8:
            this.btnUp = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Align.xaml"
            this.btnUp.Click += new System.Windows.RoutedEventHandler(this.btnUp_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnDw = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Align.xaml"
            this.btnDw.Click += new System.Windows.RoutedEventHandler(this.btnDw_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.nudmoveY = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 11:
            this.btnUpY = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Align.xaml"
            this.btnUpY.Click += new System.Windows.RoutedEventHandler(this.btnUpY_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnDwY = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Align.xaml"
            this.btnDwY.Click += new System.Windows.RoutedEventHandler(this.btnDwY_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnAlign = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Align.xaml"
            this.btnAlign.Click += new System.Windows.RoutedEventHandler(this.btnAlign_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnStart = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Align.xaml"
            this.btnStart.Click += new System.Windows.RoutedEventHandler(this.btnStart_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.nudCannyThres = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 16:
            this.nudCannyLiking = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 17:
            this.nudHoughThres = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 18:
            this.nudLineWidth = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 19:
            this.nudGap = ((Xceed.Wpf.Toolkit.DoubleUpDown)(target));
            return;
            case 20:
            this.windowArea = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 21:
            this.imgboxArea = ((Emgu.CV.UI.ImageBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

