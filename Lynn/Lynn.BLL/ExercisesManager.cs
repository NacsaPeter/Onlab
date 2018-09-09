using AutoMapper;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class ExercisesManager
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public ExercisesManager(ICourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ICollection<VocabularyExercise>> GetVocabularyExercisesAsync(int testId)
        {
            return _mapper.Map<ICollection<VocabularyExercise>>(await _repo.GetVocabularyExercisesByTestIdAsync(testId));
        }
    }
}
