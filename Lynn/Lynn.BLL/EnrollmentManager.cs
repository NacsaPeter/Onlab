using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;

namespace Lynn.BLL
{
    public class EnrollmentManager
    {
        private readonly IEnrollmentRepository _repo;

        public EnrollmentManager(IEnrollmentRepository repo)
        {
            _repo = repo;
        }

        public EnrollmentManager() : this(new EnrollmentRepository()) {}

        public int EnrollCourse(Enrollment enrollment)
        {
            return _repo.EnrollCourse(enrollment);
        }

        public IEnumerable<Course> GetCoursesByName(string coursename)
        {
            return _repo.GetCoursesByName(coursename);
        }
    }
}
