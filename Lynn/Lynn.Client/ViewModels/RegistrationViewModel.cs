using Lynn.Client.Helpers;
using Lynn.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class RegistrationViewModel : Observable
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { Set(ref _userName, value, nameof(UserName)); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value, nameof(Email)); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value, nameof(Password)); }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { Set(ref _confirmPassword, value, nameof(ConfirmPassword)); }
        }

        public ICommand Register_Click { get; set; }

        public RegistrationViewModel()
        {
            Register_Click = new RelayCommand(new Action(SendRegistration));
        }

        public async void SendRegistration()
        {
            ContentDialog contentDialog = new ContentDialog();

            if (string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(ConfirmPassword))
            {
                contentDialog.Content = "Minden mező kitöltése kötelező";
            }
            else if (Password == ConfirmPassword)
            {
                var service = new RegistrationService();
                var result = await service.Register(UserName, Email, Password);

                if (result)
                {
                    contentDialog.Content = "A regisztráció sikeres volt";
                }
                else
                {
                    contentDialog.Content = "A regisztráció sikertelen volt";
                }
            }
            else
            {
                contentDialog.Content = "A jelszó nem egyezik";
            }

            contentDialog.CloseButtonText = "Ok";
            await contentDialog.ShowAsync();
            return;
        }
    }
}
