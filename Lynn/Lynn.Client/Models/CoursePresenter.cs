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
        public int ID { get { return _course.ID; } }
        public string CourseName { get { return _course.CourseName; } }
        public string KnownLanguage { get { return _course.KnownLanguage; } }
        public string KnownLanguageTerritory { get { return _course.KnownLanguageTerritory; } }
        public string LearningLanguage { get { return _course.LearningLanguage; } }
        public string LearningLanguageTerritory { get { return _course.LearningLanguageTerritory; } }
        public string Level { get { return _course.Level; } }
        public string Editor { get { return _course.Editor; } }
        public string Details { get { return _course.Details; } }
        public string Flag { get { return $"/Assets/flags/{_course.LearningLanguage}.png"; } }
        public Course Course { get { return _course; } }
        public string KnownLanguageName { get { return _course.KnownLanguageName; } }
        public string LearningLanguageName { get { return _course.LearningLanguageName; } }

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
