﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9644F3A6F4483D98F1CC4968B45FB24A0209E564"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CalculatorPers;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CalculatorPers {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ExpressionDisplay;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ResultDisplay;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid StandardCalculatorGrid;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AdditionalOperationsGrid;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ProgrammerGrid;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton HexRadioButton;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DecRadioButton;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton OctRadioButton;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton BinRadioButton;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel HexButtonsPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CalculatorPers;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\MainWindow.xaml"
            ((CalculatorPers.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Cut_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 39 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Copy_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 40 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Paste_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 42 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DigitGrouping_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 44 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 47 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Standard_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 48 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Programmer_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 51 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.About_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ExpressionDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.ResultDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.StandardCalculatorGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            
            #line 92 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Memory_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 93 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Memory_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 94 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Memory_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 95 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Memory_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 97 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Memory_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 98 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Memory_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 99 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 100 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 102 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Backspace_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 103 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 104 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 105 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 107 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 108 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 109 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 110 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 112 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 113 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 114 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 115 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 117 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 118 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 119 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 36:
            
            #line 120 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 37:
            
            #line 122 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 38:
            
            #line 123 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Decimal_Click);
            
            #line default
            #line hidden
            return;
            case 39:
            
            #line 124 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Equal_Click);
            
            #line default
            #line hidden
            return;
            case 40:
            
            #line 125 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 41:
            this.AdditionalOperationsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 42:
            
            #line 145 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 43:
            
            #line 146 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 44:
            
            #line 147 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 45:
            
            #line 148 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 46:
            this.ProgrammerGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 47:
            this.HexRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 158 "..\..\..\MainWindow.xaml"
            this.HexRadioButton.Checked += new System.Windows.RoutedEventHandler(this.BaseRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 48:
            this.DecRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 160 "..\..\..\MainWindow.xaml"
            this.DecRadioButton.Checked += new System.Windows.RoutedEventHandler(this.BaseRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 49:
            this.OctRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 162 "..\..\..\MainWindow.xaml"
            this.OctRadioButton.Checked += new System.Windows.RoutedEventHandler(this.BaseRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 50:
            this.BinRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 164 "..\..\..\MainWindow.xaml"
            this.BinRadioButton.Checked += new System.Windows.RoutedEventHandler(this.BaseRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 51:
            this.HexButtonsPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 52:
            
            #line 173 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HexDigit_Click);
            
            #line default
            #line hidden
            return;
            case 53:
            
            #line 174 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HexDigit_Click);
            
            #line default
            #line hidden
            return;
            case 54:
            
            #line 175 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HexDigit_Click);
            
            #line default
            #line hidden
            return;
            case 55:
            
            #line 176 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HexDigit_Click);
            
            #line default
            #line hidden
            return;
            case 56:
            
            #line 177 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HexDigit_Click);
            
            #line default
            #line hidden
            return;
            case 57:
            
            #line 178 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HexDigit_Click);
            
            #line default
            #line hidden
            return;
            case 58:
            
            #line 195 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 59:
            
            #line 196 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            case 60:
            
            #line 197 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Backspace_Click);
            
            #line default
            #line hidden
            return;
            case 61:
            
            #line 198 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 62:
            
            #line 200 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 63:
            
            #line 201 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 64:
            
            #line 202 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 65:
            
            #line 203 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 66:
            
            #line 205 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 67:
            
            #line 206 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 68:
            
            #line 207 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 69:
            
            #line 208 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 70:
            
            #line 210 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 71:
            
            #line 211 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 72:
            
            #line 212 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 73:
            
            #line 213 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Operator_Click);
            
            #line default
            #line hidden
            return;
            case 74:
            
            #line 215 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SpecialOperator_Click);
            
            #line default
            #line hidden
            return;
            case 75:
            
            #line 216 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Number_Click);
            
            #line default
            #line hidden
            return;
            case 76:
            
            #line 217 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Decimal_Click);
            
            #line default
            #line hidden
            return;
            case 77:
            
            #line 218 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Equal_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

