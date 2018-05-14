using System;

using Lynn.Client.Helpers;
using Lynn.Client.Views;
using Lynn.DTO;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class LoggedInViewModel : Observable
    {
        private User _loggedInUser;
        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set { Set(ref _loggedInUser, value, nameof(LoggedInUser)); }
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage;  }
            set { Set(ref _currentPage, value, nameof(CurrentPage)); }
        }

        public void OnNavigatedTo(object parameter)
        {
            LoggedInUser = (User)parameter;
            CurrentPage = new LearningPage();
        }
    }
}
