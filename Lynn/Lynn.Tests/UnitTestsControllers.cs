using AutoMapper;
using Lynn.BLL;
using Lynn.DAL;
using Lynn.DTO;
using Lynn.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace Lynn.Tests
{
    public class UnitTestsControllers
    {
        [Fact]
        public void TestGetEnrollmentById()
        {
            DbEnrollment dbEnrollment = new DbEnrollment { ID = 93 };
            Enrollment enrollment = new Enrollment { ID = 93 };

            var mockRepository = new Mock<IEnrollmentRepository>();
            mockRepository.Setup(x => x.GetEnrollmentById(93)).Returns(dbEnrollment);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Enrollment>(dbEnrollment)).Returns(enrollment);

            var manager = new EnrollmentManager(mockRepository.Object, mockMapper.Object);
            var controller = new EnrollmentController(manager);

            var result = controller.GetEnrollmentById(93) as ObjectResult;

            Assert.Equal(enrollment, result.Value);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public void TestGetExercisesByTestId()
        {
            var dbExercises = new ObservableCollection<DbVocabularyExercise>
            {
                new DbVocabularyExercise { ID = 95 },
                new DbVocabularyExercise { ID = 96 }
            };

            var exercises = new ObservableCollection<VocabularyExercise>
            {
                new VocabularyExercise { ID = 95 },
                new VocabularyExercise { ID = 96 }
            };

            var mockRepository = new Mock<ICourseRepository>();
            mockRepository.Setup(x => x.GetVocabularyExercisesByTestId(94)).Returns(dbExercises);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<ICollection<VocabularyExercise>>(dbExercises)).Returns(exercises);

            var manager = new ExercisesManager(mockRepository.Object, mockMapper.Object);
            var controller = new ExercisesController(manager);

            var result = controller.GetExercisesByTestId(94) as ObjectResult;

            Assert.Equal(exercises, result.Value);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
