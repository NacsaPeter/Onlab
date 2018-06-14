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

namespace Lynn.Client.ViewModels
{
    public class DetailedCourseToEnrollInViewModel : Observable
    {
        public ICommand EnrollIn_Click { get; set; }
        public ICommand Cancel_Click { get; set; }

        public DetailedCourseToEnrollInViewModel(Course course)
        {
            Course = course;
            EnrollIn_Click = new RelayCommand(new Action(EnrollIn));
            Cancel_Click = new RelayCommand(new Action(Cancel));
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
            set { Set(ref _course, value, nameof(Course)); }
        }

        private void Cancel() {}

        private void EnrollIn() => EnrollInAsync();

        private async Task EnrollInAsync()
        {
            User loggedInUser = MainViewModel.LoggedInUser;
            var service = new EnrollmentService();
            await service.EnrollInAsync(loggedInUser, Course);
        }

    }
}
