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
            LoggedInUser = new User { ID = 6, Username = "TestUser15", Email = "testuser@lynn.com", PasswordHash = "lukztthrgh34hb", Points = 24 };

            _coursesPivot = coursesPivot;
            PivotItem enrollInCoursePivotItem = new PivotItem();
            enrollInCoursePivotItem.Header = "Kurzus felvétel";
            enrollInCoursePivotItem.Content = new EnrollInCourse();
            _coursesPivot.Items.Add(enrollInCoursePivotItem);
            PivotItem enrolledCoursesPivotItem = new PivotItem();
            enrolledCoursesPivotItem.Header = "Felvett kurzusok";
            EnrolledCourses enrolledCoursesPage = new EnrolledCourses();
            _coursesPivot.SelectionChanged += enrolledCoursesPage.RefreshEnrolledCourses;
            enrolledCoursesPivotItem.Content = enrolledCoursesPage;
            _coursesPivot.Items.Add(enrolledCoursesPivotItem);
        }
    }
}
