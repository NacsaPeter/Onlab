using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class NewVocabularyExercise : VocabularyExercise
    {
        public new string CorrectAnswer { get { return "Új feladat hozzáadása"; } }
        public new string Picture { get { return "new-exercise.png"; } }
    }
}
