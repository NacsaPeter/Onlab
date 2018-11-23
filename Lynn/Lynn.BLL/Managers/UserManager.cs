using AutoMapper;
using Lynn.BLL.Interfaces;
using Lynn.BLL.Mapping;
using Lynn.DAL;
using Lynn.DAL.RepositoryInterfaces;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Managers
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public UserManager(
            ILanguageRepository languageRepository, 
            IUserRepository userRepository,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _languageRepository = languageRepository;
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return _mapper.Map<User>(
                    await _userRepository.GetUserByNameAsync(username)
                );
        }
    }
}
