using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface IExerciseRepository
    {
        Task<ICollection<DbVocabularyExercise>> GetVocabularyExercisesByTestIdAsync(int id);
    }
}
