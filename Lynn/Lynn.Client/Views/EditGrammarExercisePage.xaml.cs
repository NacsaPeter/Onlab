﻿using Lynn.Client.Models;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lynn.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditGrammarExercisePage : Page
    {
        public EditGrammarExercisePage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Exercise = (GrammarExercise)e.Parameter;
            await ViewModel.SetRules();
        }

        private async void RulesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            await ViewModel.EditRule(((RulePresenter)e.ClickedItem).Rule);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.Exercise.RuleId = ((RulePresenter)((RadioButton)e.OriginalSource).DataContext).Rule.Id;
        }

        private void DeleteRuleButton_Clicked(object sender, RoutedEventArgs e)
        {
            var rule = ((RulePresenter)((Button)e.OriginalSource).DataContext).Rule;
            ViewModel.DeleteRuleContentDialog(rule);
        }
    }
}
