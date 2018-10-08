using Lynn.Client.Interfaces;
using Lynn.Client.ViewModels;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Lynn.Client.Views
{
    public sealed partial class TranslationExerciseView : UserControl, IExerciseView
    {
        public TranslationExerciseViewModel ViewModel { get; }

        public TranslationExerciseView(VocabularyExercise vocabularyExercise)
        {
            this.InitializeComponent();
            ViewModel = new TranslationExerciseViewModel(vocabularyExercise);
            DataContext = ViewModel;
        }

        private void EnterKeyDownEventHandler(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                ViewModel.CheckAnswer();
            }
        }

        public bool CheckIsCorrect()
        {
            return ViewModel.IsCorrect;
        }

        public ContentDialog GetResultContentDialog()
        {
            return ViewModel.ResultContentDialog;
        }

        public UIElement GetUIElement()
        {
            return this;
        }
    }
}
