using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynn.DTO;

namespace Lynn.Client.Models
{
    public class NewCoursePresenter : CoursePresenter
    {
        public new string CourseName { get { return "Új kurzus létrehozása"; } }
        public new string Flag { get { return "/Assets/new-course.png"; } }
        public new Course Course { get { return null; } }

        public NewCoursePresenter()
        {
        }
    }
}
