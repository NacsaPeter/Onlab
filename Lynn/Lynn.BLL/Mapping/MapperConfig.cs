using AutoMapper;
using Lynn.DAL;
using Lynn.DAL.Identity;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.BLL.Mapping
{
    public class MapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, User>();
                cfg.CreateMap<User, ApplicationUser>();

                cfg.CreateMap<DbEnrollment, Enrollment>();
                cfg.CreateMap<Enrollment, DbEnrollment>();

                cfg.CreateMap<DbVocabularyExercise, VocabularyExercise>();
                cfg.CreateMap<VocabularyExercise, DbVocabularyExercise>();

                cfg.CreateMap<DbTest, Test>();
                cfg.CreateMap<Test, DbTest>();

                cfg.CreateMap<DbCourse, Course>()
                    .ForMember(c => c.LearningLanguage, opt => opt.Ignore())
                    .ForMember(c => c.TeachingLanguage, opt => opt.Ignore())
                    .ForMember(c => c.Level, opt => opt.Ignore());
                cfg.CreateMap<Course, DbCourse>()
                    .ForMember(c => c.LearningLanguage, opt => opt.Ignore())
                    .ForMember(c => c.TeachingLanguage, opt => opt.Ignore())
                    .ForMember(c => c.Level, opt => opt.Ignore());

                cfg.CreateMap<DbLanguage, Language>();
                cfg.CreateMap<Language, DbLanguage>();

                cfg.CreateMap<DbTerritory, Territory>();
                cfg.CreateMap<Territory, DbTerritory>();

                cfg.CreateMap<DbCourseLevel, CourseLevelDto>();
                cfg.CreateMap<CourseLevelDto, DbCourseLevel>();

                cfg.CreateMap<DbTestResult, TestResultDto>();
                cfg.CreateMap<TestResultDto, DbTestResult>();

                cfg.CreateMap<DbTestUser, TestTrying>()
                    .ForMember(t => t.LastResult, opt => opt.Ignore())
                    .ForMember(t => t.BestResult, opt => opt.Ignore());

                cfg.CreateMap<TestTrying, DbTestUser>()
                    .ForMember(t => t.LastResult, opt => opt.Ignore())
                    .ForMember(t => t.BestResult, opt => opt.Ignore());
            });

            return config.CreateMapper();
        }
    }
}
