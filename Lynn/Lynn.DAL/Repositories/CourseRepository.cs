using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynn.DAL.Identity;
using Lynn.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Lynn.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LynnDb _context;

        public CourseRepository(LynnDb context)
        {
            _context = context;
        }

        public async Task<DbCourse> CreateCourseAsync(DbCourse course)
        {
            if (course == null || course.Id != 0)
            {
                return null;
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<DbCourse> EditCourseAsync(DbCourse course)
        {
            var oldCourse = await _context.Courses
                .Where(c => c.Id == course.Id)
                .SingleOrDefaultAsync();

            if (oldCourse == null)
            {
                return null;
            }

            if (oldCourse.CourseName != course.CourseName)
            {
                oldCourse.CourseName = course.CourseName;
            }
            if (oldCourse.Details != course.Details)
            {
                oldCourse.Details = course.Details;
            }
            if (oldCourse.LearningLanguage != course.LearningLanguage)
            {
                oldCourse.LearningLanguage = course.LearningLanguage;
            }
            if (oldCourse.LearningLanguageTerritory != course.LearningLanguageTerritory)
            {
                oldCourse.LearningLanguageTerritory = course.LearningLanguageTerritory;
            }
            if (oldCourse.TeachingLanguage != course.TeachingLanguage)
            {
                oldCourse.TeachingLanguage = course.TeachingLanguage;
            }
            if (oldCourse.TeachingLanguageTerritory != course.TeachingLanguageTerritory)
            {
                oldCourse.TeachingLanguageTerritory = course.TeachingLanguageTerritory;
            }
            if (oldCourse.Level != course.Level)
            {
                oldCourse.Level = course.Level;
            }

            _context.Courses.Update(oldCourse);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<ICollection<DbCourse>> GetCoursesByLanguageCodeAsync(string known, string learning)
        {
            if (known == "" && learning != "")
            {
                return await _context.Courses
                    .Include(c => c.Level)
                    .Include(c => c.Editor)
                    .Where(c => c.TeachingLanguage == known)
                    .ToListAsync();
            }
            else if (known != "" && learning == "")
            {
                return await _context.Courses
                    .Include(c => c.Level)
                    .Include(c => c.Editor)
                    .Where(c => c.LearningLanguage == learning)
                    .ToListAsync();
            }
            else
            {
                return await _context.Courses
                    .Include(c => c.Level)
                    .Include(c => c.Editor)
                    .Where(l => l.TeachingLanguage == known
                        && l.LearningLanguage == learning)
                    .ToListAsync();
            }
        }

        public async Task<ICollection<DbCourse>> GetCoursesByNameAsync(string coursename)
        {
            return await _context.Courses
                .Include(c => c.Editor)
                .Include(c => c.Level)
                .Where(t => t.CourseName.Contains(coursename))
                .ToListAsync();
        }

        public async Task<ICollection<DbCourse>> GetEnrolledCoursesAsync(ApplicationUser user)
        {
            return await _context.Enrollments
                .Include(e => e.User)
                .Where(e => e.User.Id == user.Id)
                .Select(e => e.Course)
                .Include(c => c.Level)
                .Include(c => c.Editor)
                .ToListAsync();
        }

        public async Task<ICollection<DbCourse>> GetCoursesByEditorAsync(ApplicationUser user)
        {
            return await _context.Courses
                .Include(c => c.Level)
                .Include(c => c.Editor)
                .Where(c => c.Editor == user)
                .ToListAsync();
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (course == null)
            {
                return false;
            }

            var tests = await _context.Tests
                .Include(t => t.Rules)
                .Include(t => t.GrammarExercises)
                .Include(t => t.VocabularyExercises)
                .Where(t => t.CourseId == course.Id)
                .ToListAsync();

            try
            {
                foreach (var test in tests)
                {
                    _context.Rules.RemoveRange(test.Rules);
                    _context.GrammarExercises.RemoveRange(test.GrammarExercises);
                    _context.VocabularyExercises.RemoveRange(test.VocabularyExercises);
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<DbCourse> GetCourseByTestIdAsync(int testId)
        {
            return await _context.Tests
                .Include(t => t.Course)
                .Where(t => t.Id == testId)
                .Select(t => t.Course)
                .SingleOrDefaultAsync();
        }
    }
}
