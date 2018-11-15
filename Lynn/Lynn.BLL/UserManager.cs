using AutoMapper;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public UserManager(
            ILanguageRepository languageRepository, 
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Course>> GetMyCoursesAsync(string username)
        {
            var user = await _userRepository
                .GetUserByNameAsync(username);

            var dbCourses = await _userRepository
                .GetMyCoursesAsync(user);

            var courseMapper = new CourseMapper(_languageRepository, _mapper);
            return await courseMapper.MapDbCourseCollection(dbCourses);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return _mapper.Map<User>(
                    await _userRepository.GetUserByNameAsync(username)
                );
        }
    }
}
