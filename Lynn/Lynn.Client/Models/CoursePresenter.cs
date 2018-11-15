using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class CoursePresenter
    {
        private Course _course;
        public int Id { get { return _course.Id; } }
        public string CourseName { get { return _course.CourseName; } }
        public LanguageDto TeachingLanguage { get { return _course.TeachingLanguage; } }
        public LanguageDto LearningLanguage { get { return _course.LearningLanguage; } }
        public CourseLevelDto Level { get { return _course.Level; } }
        public string Editor { get { return _course.Editor; } }
        public string Details { get { return _course.Details; } }
        public Course Course { get { return _course; } set { _course = value; } }
        public string Flag
        {
            get
            {
                if (string.IsNullOrEmpty(_course.LearningLanguage.Territory.Code))
                {
                    return $"/Assets/flags/{_course.LearningLanguage.Language.Code}.png";
                }
                return $"/Assets/flags/{_course.LearningLanguage.Language.Code}/{_course.LearningLanguage.Territory.Code}.png";
            }
        }

        protected CoursePresenter() {}

        public CoursePresenter(Course course)
        {
            _course = course;
        }

        public static ObservableCollection<CoursePresenter> GetCoursePresenters(ObservableCollection<Course> courses)
        {
            var coursePresenters = new ObservableCollection<CoursePresenter>();
            foreach (var item in courses)
            {
                coursePresenters.Add(new CoursePresenter(item));
            }
            return coursePresenters;
        }
    }
}
