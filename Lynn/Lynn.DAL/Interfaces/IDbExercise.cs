using System;
using System.Collections.Generic;
using System.Text;

namespace Lynn.DAL.Interfaces
{
    public interface IDbExercise : IDbEntry
    {
        string CorrectAnswer { get; set; }
        string WrongAnswer1 { get; set; }
        string WrongAnswer2 { get; set; }
        string WrongAnswer3 { get; set; }
        int TestId { get; set; }
    }
}
