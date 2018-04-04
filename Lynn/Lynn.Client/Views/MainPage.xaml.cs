using System;

using Lynn.Client.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void LogInViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            LogInViewControl.DataContext = new LogInViewModel();
        }
    }
}
