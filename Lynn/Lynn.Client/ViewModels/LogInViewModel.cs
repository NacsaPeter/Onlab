using Lynn.Client.Helpers;
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
    public class LogInViewModel : ViewModelBase
    {
        public ICommand LogIn_Click { get; set; }

        public LogInViewModel()
        {
            LogIn_Click = new RelayCommand(new Action(LoggingIn));
        }

        private void LoggingIn()
        {
            User user = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", PasswordHash = "lukztthrgh34hb", Points = 24 };
            NavigationService.Navigate(typeof(LoggedInPage), user);
        }
    }
}
