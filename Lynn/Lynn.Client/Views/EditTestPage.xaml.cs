using Lynn.Client.Models;
using Lynn.Client.Services;
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
    public sealed partial class EditTestPage : Page
    {
        public EditTestPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.SetCategories();
            ViewModel.Test = (Test)e.Parameter;
            if (ViewModel.Test.ID != 0)
            {
                await ViewModel.ProcessExercises();
            }
        }

        private void GrammarGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GrammarExercise parameter;
            if (e.ClickedItem.GetType() == typeof(NewGrammarExercise))
            {
                parameter = new GrammarExercise
                {
                    TestId = ViewModel.Test.ID
                };
            }
            else
            {
                parameter = (GrammarExercise)e.ClickedItem;
            }
            NavigationService.Navigate(typeof(EditGrammarExercisePage), parameter);
        }

        private void VocabularyGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            VocabularyExercise parameter;
            if (e.ClickedItem.GetType() == typeof(NewVocabularyExercise))
            {
                parameter = new VocabularyExercise
                {
                    TestID = ViewModel.Test.ID
                };
            }
            else
            {
                parameter = (VocabularyExercise)e.ClickedItem;
            }
            NavigationService.Navigate(typeof(EditVocabularyExercisePage), parameter);
        }
    }
}
