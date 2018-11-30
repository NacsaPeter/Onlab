using Lynn.Client.Models;
using Lynn.Client.Services;
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
    public sealed partial class EditCoursePage : Page
    {
        public EditCoursePage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.SetLanguages();
            if (e.Parameter != null)
            {
                ViewModel.Course = (Course)e.Parameter;
                await ViewModel.ProcessTestsByCourseId(ViewModel.Course.Id);
            }
            else
            {
                ViewModel.Course = new Course
                {
                    LearningLanguage = new LanguageDto(),
                    TeachingLanguage = new LanguageDto()
                };
            }
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (TestPresenter)e.ClickedItem;
            Test parameter;
            if (clickedItem.Test == null)
            {
                parameter = new Test
                {
                    CourseID = ViewModel.Course.Id
                };
            }
            else
            {
                parameter = clickedItem.Test; 
            }
            NavigationService.Navigate(typeof(EditTestPage), parameter);
        }
    }
}
