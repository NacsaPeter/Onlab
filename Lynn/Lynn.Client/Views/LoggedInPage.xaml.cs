using System;

using Lynn.Client.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Lynn.Client.Views
{
    public sealed partial class LoggedInPage : Page
    {
        public LoggedInViewModel ViewModel { get; } = new LoggedInViewModel();

        public LoggedInPage()
        {
            InitializeComponent();
        }
    }
}
