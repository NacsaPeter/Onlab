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
        private Button _detailsButton;

        public ICommand Details_Click { get; set; }

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

        public CourseToEnrollInViewModel(Button button, Course course)
        {
            Course = course;
            _detailsButton = button;
            Details_Click = new RelayCommand(new Action(ShowDetails));
        }

        private void ShowDetails()
        {
            DetailedCourseToEnrollInView detailedCourse = new DetailedCourseToEnrollInView(Course);
            var result = detailedCourse.ShowAsync();
        }

    }
}
