using Lynn.Client.Helpers;
using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class CourseToEnrollInViewModel: ViewModelBase
    {
        private Button detailsButton;

        public ICommand Details_Click { get; set; }

        private Course course;
        public Course Course
        {
            get { return course; }
            set
            {
                if (course != value)
                {
                    course = value;
                    RaisePropertyChanged(nameof(Course));
                }
            }
        }

        public CourseToEnrollInViewModel(Button button, Course course)
        {
            Course = course;
            detailsButton = button;
            Details_Click = new RelayCommand(new Action(ShowDetails));
        }

        private void ShowDetails()
        {
            DetailedCourseToEnrollInView detailedCourse = new DetailedCourseToEnrollInView(Course);
            var result = detailedCourse.ShowAsync();
        }
    }
}
