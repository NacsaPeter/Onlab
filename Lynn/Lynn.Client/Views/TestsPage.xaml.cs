using Lynn.Client.Models;
using Lynn.Client.ViewModels;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lynn.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestsPage : Page
    {
        public TestsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Course = new CoursePresenter((Course)e.Parameter);
            ViewModel.RefreshTests();
        }

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            TestPresenter test = (TestPresenter)e.ClickedItem;
            if (test.HigherThanEnrollmentLevel)
            {
                var dialog = new ContentDialog
                {
                    Content = "A feladatsor csak az alsóbb szintek\nelvégzése után lesz elérhető.",
                    CloseButtonText = "Ok"
                };
                await dialog.ShowAsync();
            }
            else
            {
                ViewModel.StartTest(test.Test);
            }
        }
    }
}
