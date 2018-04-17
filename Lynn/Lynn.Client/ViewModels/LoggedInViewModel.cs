using System;

using Lynn.Client.Helpers;
using Lynn.DTO;

namespace Lynn.Client.ViewModels
{
    public class LoggedInViewModel : ViewModelBase
    {
        private User _loggedInUser;
        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set
            {
                if (_loggedInUser != value)
                {
                    _loggedInUser = value;
                    RaisePropertyChanged(nameof(LoggedInUser));
                }
            }
        }
    }
}
