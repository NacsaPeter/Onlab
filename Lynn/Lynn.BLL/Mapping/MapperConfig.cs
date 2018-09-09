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

                cfg.CreateMap<DbCourse, Course>();
                cfg.CreateMap<Course, DbCourse>();

                cfg.CreateMap<DbLanguage, Language>();
                cfg.CreateMap<Language, DbLanguage>();
            });

            return config.CreateMapper();
        }
    }
}
