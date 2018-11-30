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

        public LoggedInViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
        }

    }
}
