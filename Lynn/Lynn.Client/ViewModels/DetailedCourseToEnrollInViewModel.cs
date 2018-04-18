using Lynn.Client.Helpers;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Lynn.Client.ViewModels
{
    public class DetailedCourseToEnrollInViewModel : ViewModelBase
    {
        private readonly HttpClient client = new HttpClient();

        public ICommand EnrollIn_Click { get; set; }
        public ICommand Cancel_Click { get; set; }

        //  public event EventHandler NewEnrollmentEventHandler;

        public DetailedCourseToEnrollInViewModel(Course course)
        {
            Course = course;

            client.BaseAddress = new Uri("http://localhost:56750/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

            EnrollIn_Click = new RelayCommand(new Action(EnrollIn));
            Cancel_Click = new RelayCommand(new Action(Cancel));
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
            set
            {
                if (_course != value)
                {
                    _course = value;
                    RaisePropertyChanged(nameof(Course));
                }
            }
        }

        private void Cancel()
        {
        }

        private void EnrollIn()
        {
            var result = EnrollInAsync();
            //if (result.IsCompletedSuccessfully)
            //{
                //NewEnrollmentEventHandler?.Invoke(this, new EventArgs());
                //Success();
            //}
        }

        private async Task<Uri> EnrollInAsync()
        {
            User loggedInUser = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", PasswordHash = "lukztthrgh34hb", Points = 0 };
            Enrollment enrollment = new Enrollment { CourseId = Course.ID, UserId = loggedInUser.ID, Points = 0, Level = 1 };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/enrollment", enrollment);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        private async Task Success()
        {
            MessageDialog dialog = new MessageDialog("Sikeresen jelentkezett a kurzusra!");
            dialog.Commands.Add(new UICommand("OK", null));
            var cmd = await dialog.ShowAsync();
        }
    }
}
