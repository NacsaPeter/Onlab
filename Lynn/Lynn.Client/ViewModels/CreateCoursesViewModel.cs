using Lynn.Client.Helpers;
using Lynn.Client.Models;
using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.ViewModels
{
    public class CreateCoursesViewModel : Observable
    {
        public User LoggedInUser { get; set; }

        private ObservableCollection<CoursePresenter> _courses;
        public ObservableCollection<CoursePresenter> Courses
        {
            get { return _courses; }
            set { Set(ref _courses, value, nameof(Courses)); }
        }

        public CreateCoursesViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
            ProcessMyCourses(LoggedInUser);
        }

        private async Task ProcessMyCourses(User user)
        {
            var service = new UserService();
            var results = await service.GetMyCoursesAsync(user);
            Courses = CoursePresenter.GetCoursePresenters(results);
            Courses.Add(new NewCoursePresenter());
        }
    }
}
