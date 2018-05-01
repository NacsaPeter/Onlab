using Lynn.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class LearningViewModel : ViewModelBase
    {
        private Pivot _coursesPivot;

        public LearningViewModel(Pivot coursesPivot)
        {
            _coursesPivot = coursesPivot;
            PivotItem enrollInCoursePivotItem = new PivotItem();
            enrollInCoursePivotItem.Header = "Kurzus felvétel";
            enrollInCoursePivotItem.Content = new EnrollInCourse();
            _coursesPivot.Items.Add(enrollInCoursePivotItem);
            PivotItem enrolledCoursesPivotItem = new PivotItem();
            enrolledCoursesPivotItem.Header = "Felvett kurzusok";
            EnrolledCourses enrolledCoursesPage = new EnrolledCourses();
            _coursesPivot.SelectionChanged += enrolledCoursesPage.ViewModel.RefreshEnrolledCourses;
            enrolledCoursesPivotItem.Content = enrolledCoursesPage;
            _coursesPivot.Items.Add(enrolledCoursesPivotItem);
        }

        
    }
}
