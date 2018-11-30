using Lynn.Client.Helpers;
using Lynn.Client.Models;
using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lynn.Client.ViewModels
{
    public class EditTestViewModel : Observable
    {
        public User LoggedInUser { get; set; }
        public ICommand SaveTest_Click { get; set; }
        public ICommand DeleteTest_Click { get; set; }

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

        private Test _test;
        public Test Test
        {
            get { return _test; }
            set { Set(ref _test, value, nameof(Test)); }
        }

        private ObservableCollection<VocabularyExercise> _vocabularyExercises;
        public ObservableCollection<VocabularyExercise> VocabularyExercises
        {
            get { return _vocabularyExercises; }
            set { Set(ref _vocabularyExercises, value, nameof(VocabularyExercises)); }
        }

        private ObservableCollection<GrammarExercise> _grammarExercises;
        public ObservableCollection<GrammarExercise> GrammarExercises
        {
            get { return _grammarExercises; }
            set { Set(ref _grammarExercises, value, nameof(GrammarExercises)); }
        }

        private ObservableCollection<string> _categories;
        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set { Set(ref _categories, value, nameof(Categories)); }
        }

        public EditTestViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
            SaveTest_Click = new RelayCommand(SaveTest);
            DeleteTest_Click = new RelayCommand(DeleteTest);
        }

        public async Task SetCategories()
        {
            var service = new TestService();
            Categories = await service.GetTestCategories();
        }

        public async Task ProcessExercises()
        {
            var service = new ExerciseService();
            if (Test.CategoryName == "Nyelvtan")
            {
                GrammarExercises = await service.GetGrammarExercises(Test);
                GrammarExercises.Add(new NewGrammarExercise());
            }
            else
            {
                VocabularyExercises = await service.GetVocabularyExercises(Test);
                VocabularyExercises.Add(new NewVocabularyExercise());
            }
        }

        private async void SaveTest()
        {
            var service = new TestService();
            if (Test.ID == 0)
            {
                Saving = true;
                var test = await service.PostTestAsync(Test);
                Saving = false;
                if (test == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Test = test;
                    VocabularyExercises = new ObservableCollection<VocabularyExercise>
                    {
                        new NewVocabularyExercise()
                    };
                    GrammarExercises = new ObservableCollection<GrammarExercise>
                    {
                        new NewGrammarExercise()
                    };
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
            else
            {
                Saving = true;
                var test = await service.PutTestAsync(Test);
                Saving = false;
                if (test == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Test = test;
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
        }

        private async void DeleteTest()
        {
            var service = new TestService();
            bool result = await service.DeleteTestAsync(Test);
            if (result)
            {
                NavigationService.GoBack();
            }
        }
    }
}
