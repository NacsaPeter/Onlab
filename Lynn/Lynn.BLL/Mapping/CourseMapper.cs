using AutoMapper;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Mapping
{
    public class CourseMapper
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public CourseMapper(
            ILanguageRepository languageRepository,
            IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Course>> MapDbCourseCollection(ICollection<DbCourse> dbCourses)
        {
            var courses = new List<Course>();

            foreach (var dbCourse in dbCourses)
            {
                var teachingLanguage = await _languageRepository
                    .GetLanguageByCodeAsync(dbCourse.TeachingLanguage);
                var teachingLanguageTerritory = await _languageRepository
                    .GetTerritoryByCodeAsync(dbCourse.TeachingLanguage);
                var learnigLanguage = await _languageRepository
                    .GetLanguageByCodeAsync(dbCourse.LearningLanguage);
                var learnigLanguageTerritory = await _languageRepository
                    .GetTerritoryByCodeAsync(dbCourse.LearningLanguageTerritory);

                var course = _mapper.Map<Course>(dbCourse);
                course.LearningLanguage = new LanguageDto
                {
                    Language = new Language
                    {
                        Code = learnigLanguage.Code,
                        Name = learnigLanguage.Name
                    },
                    Territory = new Territory
                    {
                        Code = learnigLanguageTerritory.Code,
                        Name = learnigLanguageTerritory.Name
                    }
                };
                course.TeachingLanguage = new LanguageDto
                {
                    Language = new Language
                    {
                        Code = teachingLanguage.Code,
                        Name = teachingLanguage.Name
                    },
                    Territory = new Territory
                    {
                        Code = teachingLanguageTerritory.Code,
                        Name = teachingLanguageTerritory.Name
                    }
                };
                course.Level = _mapper.Map<CourseLevelDto>(dbCourse.Level);
                courses.Add(course);
            }

            return courses;
        }
    }
}
