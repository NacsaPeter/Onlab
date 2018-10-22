﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL
{
    public interface ICourseRepository
    {
        Task<ICollection<DbTest>> GetTestsByCourseIdAsync(int id);
        Task<ICollection<DbVocabularyExercise>> GetVocabularyExercisesByTestIdAsync(int id);
        Task<DbCategory> GetCategoryByTestIdAsync(int testId);
    }
}