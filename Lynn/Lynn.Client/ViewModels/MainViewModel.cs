using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.Client.Views;
using Lynn.DTO;

namespace Lynn.Client.ViewModels
{
    public class MainViewModel : Observable
    {
        public static string AccessToken { get; private set; }

        public ICommand LogIn_Click { get; set; }

        public MainViewModel()
        {
            LogIn_Click = new RelayCommand(new Action(LoggingIn));
        }

        private void LoggingIn()
        {
            User user = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", Password = "TestPassword123.", Points = 24 };
            LoggingInAsync(user);
        }

        private async Task LoggingInAsync(User user)
        {
            AccessToken = await LogInService.LogIn(user);
            NavigationService.Navigate(typeof(LoggedInPage), user);
        }
    }
}
