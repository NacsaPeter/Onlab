using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class DetailedCourseToEnrollInViewModel : Observable
    {
        public ICommand EnrollIn_Click { get; set; }
        public ICommand Cancel_Click { get; set; }

        public DetailedCourseToEnrollInViewModel(Course course)
        {
            Course = course;
            EnrollIn_Click = new RelayCommand(new Action(EnrollInAsync));
            Cancel_Click = new RelayCommand(new Action(Cancel));
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
            set { Set(ref _course, value, nameof(Course)); }
        }

        private void Cancel() {}

        private async void EnrollInAsync()
        {
            User loggedInUser = MainViewModel.LoggedInUser;
            var service = new EnrollmentService();
            var result = await service.EnrollInAsync(loggedInUser, Course);
            var contentDialog = new ContentDialog();
            if (result)
            {
                contentDialog.Content = "A jelentkezés sikeres volt";
            }
            else
            {
                contentDialog.Content = "A jelentkezés sikertelen volt";
            }
            contentDialog.CloseButtonText = "Ok";
            await contentDialog.ShowAsync();
        }

    }
}
