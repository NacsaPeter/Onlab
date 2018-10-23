using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.Client.Views;
using Lynn.DTO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace Lynn.Client.ViewModels
{
    public class MainViewModel : Observable
    {
        public static string AccessToken { get; private set; }
        public static User LoggedInUser { get; set; }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { Set(ref _userName, value, nameof(UserName)); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value, nameof(Password)); }
        }

        public ICommand LogIn_Click { get; set; }

        public MainViewModel()
        {
            LogIn_Click = new RelayCommand(new Action(LoggingIn));
        }

        private async void LoggingIn()
        {
            LoggedInUser = new User
            {
                Username = UserName,
                Password = Password
            };
            await LoggingInAsync(LoggedInUser);
        }

        private async Task LoggingInAsync(User user)
        {
            AccessToken = await LogInService.LogIn(user);
            if (AccessToken == "")
            {
                ContentDialog contentDialog = new ContentDialog
                {
                    Content = "A bejelentkezés sikertelen volt",
                    CloseButtonText = "Ok"
                };
                await contentDialog.ShowAsync();
                return;
            }

            var userService = new UserService();
            LoggedInUser = await userService.GetUserByName(user.Username);

            NavigationService.Navigate(typeof(LoggedInPage), LoggedInUser);
        }

        public void NavigateToRegistrationPage(Hyperlink hyperlink, HyperlinkClickEventArgs args)
        {
            NavigationService.Navigate(typeof(RegistrationPage));
        }
    }
}
