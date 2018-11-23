using AutoMapper;
using Lynn.BLL.Interfaces;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lynn.BLL.Managers
{
    public class EnrollmentManager: IEnrollmentManager
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EnrollmentManager(
            IEnrollmentRepository enrollmentRepository,
            ILanguageRepository languageRepository,
            ICourseRepository courseRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _languageRepository = languageRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Enrollment> EnrollCourseAsync(Enrollment enrollment)
        {
            DbEnrollment dbEnrollment = _mapper.Map<DbEnrollment>(enrollment);

            return _mapper.Map<Enrollment>(
                    await _enrollmentRepository.EnrollCourseAsync(dbEnrollment)
                );
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return _mapper.Map<Enrollment>(
                    await _enrollmentRepository.GetEnrollmentByIdAsync(enrollmentId)
                );
        }

        public async Task<Enrollment> GetEnrollmentAsync(int userId, int couseId)
        {
            return _mapper.Map<Enrollment>(
                    await _enrollmentRepository.GetEnrollmentAsync(userId, couseId)
                );
        }

    }
}
