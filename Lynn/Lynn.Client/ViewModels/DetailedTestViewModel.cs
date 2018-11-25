using Lynn.Client.Helpers;
using Lynn.Client.Models;
using Lynn.Client.Services;
using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lynn.Client.ViewModels
{
    public class DetailedTestViewModel : Observable
    {
        private User _loggedInUser;
        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set { Set(ref _loggedInUser, value, nameof(LoggedInUser)); }
        }

        private Test _test;
        public Test Test
        {
            get { return _test; }
            set { Set(ref _test, value, nameof(Test)); }
        }

        private TestTrying _testTrying;
        public TestTrying TestTrying
        {
            get { return _testTrying; }
            set { Set(ref _testTrying, value, nameof(TestTrying)); }
        }

        public ICommand LearnExpressions_Click { get; set; }
        public ICommand DoTest_Click { get; set; }

        public DetailedTestViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
            LearnExpressions_Click = new RelayCommand(new Action(LearnExpressions));
            DoTest_Click = new RelayCommand(new Action(DoTest));
        }

        public async void ProcessTestTrying()
        {
            var service = new TestService();
            TestTrying = await service.GetTestTrying(LoggedInUser.ID, Test.ID);
        }

        private void LearnExpressions()
        {
            if (Test.CategoryName == "Nyelvtan")
            {
                NavigationService.Navigate(typeof(LearnRulesPage), Test);
            }
            else
            {
                NavigationService.Navigate(typeof(LearnExpressionsPage), Test);
            }
        }

        private void DoTest()
        {
            NavigationService.Navigate(typeof(DoExercisesPage), Test);
        }
    }
}
