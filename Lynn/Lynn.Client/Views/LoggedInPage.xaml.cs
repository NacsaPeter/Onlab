using System;

using Lynn.Client.ViewModels;
using Lynn.DTO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Lynn.Client.Views
{
    public sealed partial class LoggedInPage : Page
    {
        public LoggedInPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);            
            ViewModel.OnNavigatedTo(e.Parameter);
        }

        private void HamburgerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            HamburgerMenuButton.IsPaneOpen = !HamburgerMenuButton.IsPaneOpen;
        }

        private void LearningButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            LearningPage.Visibility = Windows.UI.Xaml.Visibility.Visible;
            SettingsPage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void SettingsButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            LearningPage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            SettingsPage.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
    }
}

