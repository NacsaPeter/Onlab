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

namespace Lynn.Client.ViewModels
{
    public class LearnExpressionsViewModel : Observable
    {
        private Test _test;
        public Test Test
        {
            get { return _test; }
            set { Set(ref _test, value, nameof(Test)); }
        }

        private User _loggedInUser;
        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set { Set(ref _loggedInUser, value, nameof(LoggedInUser)); }
        }

        private ObservableCollection<VocabularyExercise> _vocabularyExercises;
        public ObservableCollection<VocabularyExercise> VocabularyExercises
        {
            get { return _vocabularyExercises; }
            set { Set(ref _vocabularyExercises, value, nameof(VocabularyExercises)); }
        }

        private VocabularyExercise _currentExercise;
        public VocabularyExercise CurrentExercise
        {
            get { return _currentExercise; }
            set { Set(ref _currentExercise, value, nameof(CurrentExercise)); }
        }

        public LearnExpressionsViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
        }

        public async Task ProcessExercisesAsync()
        {
            var service = new ExerciseService();
            VocabularyExercises = await service.GetVocabularyExercises(Test);
            if (VocabularyExercises.Count != 0)
            {
                CurrentExercise = VocabularyExercises[0];
            }
        }
    }
}
