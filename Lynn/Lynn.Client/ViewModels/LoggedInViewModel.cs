using System;

using Lynn.Client.Helpers;
using Lynn.DTO;

namespace Lynn.Client.ViewModels
{
    public class LoggedInViewModel : ViewModelBase
    {
        private User loggedInUser;
        public User LoggedInUser
        {
            get { return loggedInUser; }
            set
            {
                if (loggedInUser != value)
                {
                    loggedInUser = value;
                    RaisePropertyChanged(nameof(LoggedInUser));
                }
            }
        }

        public LoggedInViewModel()
        {
            //query
            LoggedInUser = new User { Username = "TestUser15", Points = 521 };
        }
    }
}
