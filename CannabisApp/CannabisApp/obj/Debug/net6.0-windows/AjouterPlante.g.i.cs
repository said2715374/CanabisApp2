﻿#pragma checksum "..\..\..\AjouterPlante.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ECA7AB4812B26D8CE95ED3602D7A231CA21FA60B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using CannabisApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CannabisApp {
    
    
    /// <summary>
    /// AjouterPlante
    /// </summary>
    public partial class AjouterPlante : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StadeComboBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Identification;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProvenanceComboBox;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quantite;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateExpiration;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EtatSanteComboBox;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EmplacementComboBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\AjouterPlante.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NoteTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CannabisApp;component/ajouterplante.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AjouterPlante.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 23 "..\..\..\AjouterPlante.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 31 "..\..\..\AjouterPlante.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.StadeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Identification = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ProvenanceComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Quantite = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DateExpiration = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.EtatSanteComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.EmplacementComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 94 "..\..\..\AjouterPlante.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterEmplacement_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.NoteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            
            #line 101 "..\..\..\AjouterPlante.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Ajouter_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

