using Lynn.Client.Helpers;
using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class LearningViewModel : Observable
    {
        private Pivot _coursesPivot;
        public User LoggedInUser { get; set; }

        public LearningViewModel(Pivot coursesPivot)
        {
            LoggedInUser = MainViewModel.LoggedInUser;

            _coursesPivot = coursesPivot;
            PivotItem enrollInCoursePivotItem = new PivotItem
            {
                Header = "Kurzus felvétel",
                Content = new EnrollInCourse()
            };
            _coursesPivot.Items.Add(enrollInCoursePivotItem);
            PivotItem enrolledCoursesPivotItem = new PivotItem
            {
                Header = "Felvett kurzusok"
            };
            EnrolledCourses enrolledCoursesPage = new EnrolledCourses();
            _coursesPivot.SelectionChanged += enrolledCoursesPage.RefreshEnrolledCourses;
            enrolledCoursesPivotItem.Content = enrolledCoursesPage;
            _coursesPivot.Items.Add(enrolledCoursesPivotItem);
        }
    }
}
