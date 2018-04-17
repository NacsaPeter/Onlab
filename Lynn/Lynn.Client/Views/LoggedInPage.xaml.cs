using System;

using Lynn.Client.ViewModels;
using Lynn.DTO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Lynn.Client.Views
{
    public sealed partial class LoggedInPage : Page
    {
        public LoggedInViewModel ViewModel { get; }

        public LoggedInPage()
        {
            InitializeComponent();
            ViewModel = new LoggedInViewModel();
            DataContext = ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e); 
            ViewModel.LoggedInUser = (User)e.Parameter;
        }
    }
}

