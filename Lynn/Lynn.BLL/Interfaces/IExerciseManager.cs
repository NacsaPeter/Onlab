using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Interfaces
{
    public interface IExerciseManager
    {
        Task<ICollection<VocabularyExercise>> GetVocabularyExercisesAsync(int testId);
    }
}
