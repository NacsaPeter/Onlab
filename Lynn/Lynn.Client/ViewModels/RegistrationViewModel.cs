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

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { Set(ref _errorMessage, value, nameof(ErrorMessage)); }
        }

        private bool _registrationSuccess;
        public bool RegistrationSuccess
        {
            get { return _registrationSuccess; }
            set { Set(ref _registrationSuccess, value, nameof(RegistrationSuccess)); }
        }

        public ICommand Register_Click { get; set; }

        public RegistrationViewModel()
        {
            Register_Click = new RelayCommand(new Action(SendRegistration));
            RegistrationSuccess = false;
        }

        public async void SendRegistration()
        {
            if (string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(ConfirmPassword))
            {
                ErrorMessage = "Minden mező kitöltése kötelező";
            }
            else if (!Email.Contains("@") && !Email.Contains("."))
            {
                ErrorMessage = "Az e-mail cím nem megfelelő.";
            }
            else if (Password == ConfirmPassword)
            {
                var service = new RegistrationService();
                var result = await service.Register(UserName, Email, Password);

                switch (result)
                {
                    case "DuplicateUserName": ErrorMessage = "Ez a felhasználónév már foglalt.";
                        break;

                    case "PasswordTooShort": ErrorMessage = "A jelszó legalább 6 karakter hosszú kell legyen.";
                        break;

                    case "PasswordRequiresNonAlphanumeric":
                        ErrorMessage = "A jelszónak tartalmaznia kell nem alfanumerikus karaktert is.";
                        break;

                    case "PasswordRequiresDigit":
                        ErrorMessage = "A jelszónak tartalmaznia kell számot is.";
                        break;

                    case "PasswordRequiresLower":
                        ErrorMessage = "A jelszónak tartalmaznia kell kisbetűt is.";
                        break;

                    case "PasswordRequiresUpper":
                        ErrorMessage = "A jelszónak tartalmaznia kell nagybetűt is.";
                        break;

                    case "Success":
                        ErrorMessage = "";
                        RegistrationSuccess = true;
                        await Task.Delay(3000);
                        NavigationService.GoBack();
                        break;

                    default: ErrorMessage = result;
                        break;
                }
                
            }
            else
            {
                ErrorMessage = "A két jelszó nem egyezik meg.";
            }

            Password = "";
            ConfirmPassword = "";

            return;
        }
    }
}
