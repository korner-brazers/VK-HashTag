﻿#pragma checksum "..\..\..\..\Engine\UserControls\JobADD.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "11A99D1C21E5A2B67BBE55136AD090EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34003
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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
using VKHashTag.Engine.Converters;
using VKHashTag.Engine.Style.JobADD.Generic;


namespace VKHashTag.Engine.UserControls {
    
    
    /// <summary>
    /// JobADD
    /// </summary>
    public partial class JobADD : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Engine\UserControls\JobADD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition RowGridMainTop;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Engine\UserControls\JobADD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition RowGridMainButton;
        
        #line default
        #line hidden
        
        
        #line 302 "..\..\..\..\Engine\UserControls\JobADD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelSelectedALL;
        
        #line default
        #line hidden
        
        
        #line 310 "..\..\..\..\Engine\UserControls\JobADD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridSearchResult;
        
        #line default
        #line hidden
        
        
        #line 402 "..\..\..\..\Engine\UserControls\JobADD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LB_Job;
        
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
            System.Uri resourceLocater = new System.Uri("/VKHashTag;component/engine/usercontrols/jobadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Engine\UserControls\JobADD.xaml"
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
            
            #line 11 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((VKHashTag.Engine.UserControls.JobADD)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.UserControl_ActualSize);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RowGridMainTop = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.RowGridMainButton = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            
            #line 118 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CB_TypeCommunity_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 181 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CB_CountriesID_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 230 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadStopWord_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 239 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RectangleDeleteStopWord_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 265 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadListGroup_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 298 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LB_Search_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 299 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LB_Clear_MouseDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.LabelSelectedALL = ((System.Windows.Controls.Label)(target));
            
            #line 305 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            this.LabelSelectedALL.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LB_SelectedALL_MouseDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.GridSearchResult = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.LB_Job = ((System.Windows.Controls.ListBox)(target));
            return;
            case 14:
            
            #line 458 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SaveJob_MouseDown);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 459 "..\..\..\..\Engine\UserControls\JobADD.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CancelJob_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

