﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B0892E558B24004ED072C7CD17DFA0D64358F7DD"
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
using LiveCharts.Wpf;
using MahApps.Metro.Controls;
using PLImg_V2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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


namespace PLImg_V2 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbScatter;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbBackGoundRemove;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb1inch;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb2inch;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb4inch;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStartFixAreaScan;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveImg;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOrigin;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnROrigin;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnXMove;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnYMove;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnZMove;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRMove;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbXDisa;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbYDisa;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckbZDisa;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudlinerate;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudScanSpeed;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudGoXPos;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudGoYPos;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudGoZPos;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudGoRPos;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudPLBias;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown nudScBias;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLImg_V2.UC_CamComunication ucComunication;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblXpos;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblYpos;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblZpos;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblBuffNum;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowTrig0;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxTrig0;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowTrig1;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxTrig1;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowTrig2;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxTrig2;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowTrig3;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxTrig3;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowTrig4;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxTrig4;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowTrig5;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxTrig5;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowOri;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxOri;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel dpnlImgResult;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost winScterTrig0;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxScterTrig0;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost winScterTrig1;
        
        #line default
        #line hidden
        
        
        #line 253 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxScterTrig1;
        
        #line default
        #line hidden
        
        
        #line 255 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost winScterTrig2;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxScterTrig2;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost winScterTrig3;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxScterTrig3;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost winScterTrig4;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxScterTrig4;
        
        #line default
        #line hidden
        
        
        #line 264 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost winScterTrig5;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgboxScterTrig5;
        
        #line default
        #line hidden
        
        
        #line 280 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowScterOri;
        
        #line default
        #line hidden
        
        
        #line 281 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Emgu.CV.UI.ImageBox imgscterboxOri;
        
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
            System.Uri resourceLocater = new System.Uri("/PLImg_V2;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
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
            
            #line 15 "..\..\..\MainWindow.xaml"
            ((PLImg_V2.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MetroWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ckbScatter = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.ckbBackGoundRemove = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.rdb1inch = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rdb2inch = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rdb4inch = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.btnStartFixAreaScan = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\MainWindow.xaml"
            this.btnStartFixAreaScan.Click += new System.Windows.RoutedEventHandler(this.btnStartFixAreaScan_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSaveImg = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\MainWindow.xaml"
            this.btnSaveImg.Click += new System.Windows.RoutedEventHandler(this.btnSaveImg_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnOrigin = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\MainWindow.xaml"
            this.btnOrigin.Click += new System.Windows.RoutedEventHandler(this.btnOrigin_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnROrigin = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\MainWindow.xaml"
            this.btnROrigin.Click += new System.Windows.RoutedEventHandler(this.btnROrigin_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnXMove = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\MainWindow.xaml"
            this.btnXMove.Click += new System.Windows.RoutedEventHandler(this.btnXMove_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnYMove = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\MainWindow.xaml"
            this.btnYMove.Click += new System.Windows.RoutedEventHandler(this.btnYMove_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnZMove = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\MainWindow.xaml"
            this.btnZMove.Click += new System.Windows.RoutedEventHandler(this.btnZMove_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnRMove = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\MainWindow.xaml"
            this.btnRMove.Click += new System.Windows.RoutedEventHandler(this.btnRMove_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.ckbXDisa = ((System.Windows.Controls.CheckBox)(target));
            
            #line 122 "..\..\..\MainWindow.xaml"
            this.ckbXDisa.Checked += new System.Windows.RoutedEventHandler(this.ckbXDisa_Checked);
            
            #line default
            #line hidden
            
            #line 122 "..\..\..\MainWindow.xaml"
            this.ckbXDisa.Unchecked += new System.Windows.RoutedEventHandler(this.ckbXDisa_Unchecked);
            
            #line default
            #line hidden
            return;
            case 16:
            this.ckbYDisa = ((System.Windows.Controls.CheckBox)(target));
            
            #line 123 "..\..\..\MainWindow.xaml"
            this.ckbYDisa.Checked += new System.Windows.RoutedEventHandler(this.ckbYDisa_Checked);
            
            #line default
            #line hidden
            
            #line 123 "..\..\..\MainWindow.xaml"
            this.ckbYDisa.Unchecked += new System.Windows.RoutedEventHandler(this.ckbYDisa_Unchecked);
            
            #line default
            #line hidden
            return;
            case 17:
            this.ckbZDisa = ((System.Windows.Controls.CheckBox)(target));
            
            #line 124 "..\..\..\MainWindow.xaml"
            this.ckbZDisa.Checked += new System.Windows.RoutedEventHandler(this.ckbZDisa_Checked);
            
            #line default
            #line hidden
            
            #line 124 "..\..\..\MainWindow.xaml"
            this.ckbZDisa.Unchecked += new System.Windows.RoutedEventHandler(this.ckbZDisa_Unchecked);
            
            #line default
            #line hidden
            return;
            case 18:
            this.nudlinerate = ((MahApps.Metro.Controls.NumericUpDown)(target));
            
            #line 127 "..\..\..\MainWindow.xaml"
            this.nudlinerate.KeyUp += new System.Windows.Input.KeyEventHandler(this.nudlinerate_KeyUp);
            
            #line default
            #line hidden
            return;
            case 19:
            this.nudScanSpeed = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 20:
            this.nudGoXPos = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 21:
            this.nudGoYPos = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 22:
            this.nudGoZPos = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 23:
            this.nudGoRPos = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 24:
            this.nudPLBias = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 25:
            this.nudScBias = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 26:
            
            #line 143 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TabItem)(target)).AddHandler(System.Windows.Controls.Primitives.Selector.SelectedEvent, new System.Windows.RoutedEventHandler(this.TabItem_Selected));
            
            #line default
            #line hidden
            
            #line 143 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TabItem)(target)).AddHandler(System.Windows.Controls.Primitives.Selector.UnselectedEvent, new System.Windows.RoutedEventHandler(this.TabItem_Unselected));
            
            #line default
            #line hidden
            return;
            case 27:
            this.ucComunication = ((PLImg_V2.UC_CamComunication)(target));
            return;
            case 28:
            this.lblXpos = ((System.Windows.Controls.Label)(target));
            return;
            case 29:
            this.lblYpos = ((System.Windows.Controls.Label)(target));
            return;
            case 30:
            this.lblZpos = ((System.Windows.Controls.Label)(target));
            return;
            case 31:
            this.lblBuffNum = ((System.Windows.Controls.Label)(target));
            return;
            case 32:
            this.windowTrig0 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 33:
            this.imgboxTrig0 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 34:
            this.windowTrig1 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 35:
            this.imgboxTrig1 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 36:
            this.windowTrig2 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 37:
            this.imgboxTrig2 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 38:
            this.windowTrig3 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 39:
            this.imgboxTrig3 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 40:
            this.windowTrig4 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 41:
            this.imgboxTrig4 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 42:
            this.windowTrig5 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 43:
            this.imgboxTrig5 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 44:
            this.windowOri = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 45:
            this.imgboxOri = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 46:
            this.dpnlImgResult = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 47:
            this.winScterTrig0 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 48:
            this.imgboxScterTrig0 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 49:
            this.winScterTrig1 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 50:
            this.imgboxScterTrig1 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 51:
            this.winScterTrig2 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 52:
            this.imgboxScterTrig2 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 53:
            this.winScterTrig3 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 54:
            this.imgboxScterTrig3 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 55:
            this.winScterTrig4 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 56:
            this.imgboxScterTrig4 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 57:
            this.winScterTrig5 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 58:
            this.imgboxScterTrig5 = ((Emgu.CV.UI.ImageBox)(target));
            return;
            case 59:
            this.windowScterOri = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 60:
            this.imgscterboxOri = ((Emgu.CV.UI.ImageBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

