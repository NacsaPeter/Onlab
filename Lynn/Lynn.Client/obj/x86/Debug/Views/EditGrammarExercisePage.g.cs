﻿#pragma checksum "C:\Users\nacsa\OneDrive\Dokumentumok\git\Onlab\Lynn\Lynn.Client\Views\EditGrammarExercisePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D09328159D2E7183ADDFF72888CC611E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lynn.Client.Views
{
    partial class EditGrammarExercisePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\EditGrammarExercisePage.xaml line 14
                {
                    this.ViewModel = (global::Lynn.Client.ViewModels.EditGrammarExerciseViewModel)(target);
                }
                break;
            case 2: // Views\EditGrammarExercisePage.xaml line 126
                {
                    global::Windows.UI.Xaml.Controls.GridView element2 = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    ((global::Windows.UI.Xaml.Controls.GridView)element2).ItemClick += this.RulesGridView_ItemClick;
                }
                break;
            case 3: // Views\EditGrammarExercisePage.xaml line 140
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element3 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element3).Checked += this.RadioButton_Checked;
                }
                break;
            case 4: // Views\EditGrammarExercisePage.xaml line 143
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.DeleteRuleButton_Clicked;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

