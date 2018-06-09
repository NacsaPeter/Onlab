using AutoMapper;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<VocabularyExercise> GetVocabularyExercises(int testId)
        {
            return _mapper.Map<IEnumerable<VocabularyExercise>>(_repo.GetVocabularyExercisesByTestId(testId));
        }
    }
}
