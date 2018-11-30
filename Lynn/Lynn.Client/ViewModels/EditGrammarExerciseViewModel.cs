using Lynn.Client.Helpers;
using Lynn.Client.Models;
using Lynn.Client.Services;
using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Lynn.Client.ViewModels
{
    public class EditGrammarExerciseViewModel : Observable
    {
        public User LoggedInUser { get; set; }
        public ICommand SaveExercise_Click { get; set; }
        public ICommand DeleteExercise_Click { get; set; }

        private bool _saving = false;
        public bool Saving
        {
            get { return _saving; }
            set { Set(ref _saving, value, nameof(Saving)); }
        }

        private bool _saved = false;
        public bool Saved
        {
            get { return _saved; }
            set { Set(ref _saved, value, nameof(Saved)); }
        }

        private bool _notSaved = false;
        public bool NotSaved
        {
            get { return _notSaved; }
            set { Set(ref _notSaved, value, nameof(NotSaved)); }
        }

        private GrammarExercise _exercise;
        public GrammarExercise Exercise
        {
            get { return _exercise; }
            set { Set(ref _exercise, value, nameof(Exercise)); }
        }

        private ObservableCollection<RulePresenter> _rules;
        public ObservableCollection<RulePresenter> Rules
        {
            get { return _rules; }
            set { Set(ref _rules, value, nameof(Rules)); }
        }

        public EditGrammarExerciseViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
            SaveExercise_Click = new RelayCommand(SaveExercise);
            DeleteExercise_Click = new RelayCommand(DeleteExerciseContentDialog);
        }

        public async Task SetRules()
        {
            var service = new ExerciseService();
            var result = await service.GetGrammarRules(Exercise.TestId);
            Rules = new ObservableCollection<RulePresenter>();
            foreach (var item in result)
            {
                Rules.Add(new RulePresenter(item));
            }
            Rules.Add(new NewRule());
            var current = Rules
                .Where(r => r.Rule.Id == Exercise.RuleId)
                .SingleOrDefault();
            current.isCurrent = true;
        }

        private async void SaveExercise()
        {
            var service = new ExerciseService();
            if (Exercise.Id == 0)
            {
                Saving = true;
                var exercise = await service.PostGrammarExerciseAsync(Exercise);
                Saving = false;
                if (exercise == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Exercise = exercise;
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
            else
            {
                Saving = true;
                var exercise = await service.PutGrammarExerciseAsync(Exercise);
                Saving = false;
                if (exercise == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Exercise = exercise;
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
        }

        private async void DeleteExercise()
        {
            var service = new ExerciseService();
            bool result = await service.DeleteGrammarExerciseAsync(Exercise);
            if (result)
            {
                NavigationService.GoBack();
            }
        }

        public async Task EditRule(RuleDto rule)
        {
            if (rule.Id == 0)
            {
                rule.Name = "";
                rule.TestId = Exercise.TestId;
            }
            var contentDialog = new EditRuleView(rule);
            var result = await contentDialog.ShowAsync();
            if (result == Windows.UI.Xaml.Controls.ContentDialogResult.Primary)
            {
                await SetRules();
            }
        }

        private async void DeleteExerciseContentDialog()
        {
            var contentDialog = new ContentDialog
            {
                Content = new TextBlock
                {
                    Text = $"Biztosan törli a feladatot?",
                    TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                    FontSize = 18,
                    Margin = new Windows.UI.Xaml.Thickness(20)
                },
                Background = new SolidColorBrush(Colors.LemonChiffon),
                CloseButtonText = "Mégse",
                PrimaryButtonText = "Törlés",
                PrimaryButtonCommand = new RelayCommand(DeleteExercise)
            };
            await contentDialog.ShowAsync();
        }
    }
}
