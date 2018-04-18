using Lynn.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.ViewModels
{
    public class LearningViewModel : ViewModelBase
    {
        EnrollInCourseViewModel _enrollInCourseViewModel;
        EnrolledCoursesViewModel _enrolledCoursesViewModel;

        public LearningViewModel(EnrollInCourseViewModel enrollInCourseViewModel, EnrolledCoursesViewModel enrolledCoursesViewModel)
        {
            _enrollInCourseViewModel = enrollInCourseViewModel;
            _enrolledCoursesViewModel = enrolledCoursesViewModel;
        }
    }
}
