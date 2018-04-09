using Lynn.Client.Helpers;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class CourseToEnrollInViewModel: ViewModelBase
    {
        private Button enrollInButton;

        public ICommand EnrollIn_Click { get; set; }

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

        public CourseToEnrollInViewModel(Button button)
        {
            Course = new Course { CourseName = "Angol kezdő", LearningLanguage = "Angol" };
            enrollInButton = button;
            EnrollIn_Click = new RelayCommand(new Action(EnrollInCourse));
        }

        private void EnrollInCourse()
        {
            //query
        }
    }
}
