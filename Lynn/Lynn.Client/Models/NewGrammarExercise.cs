using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class NewGrammarExercise : GrammarExercise
    {
        public new string Question { get { return "+ Új feladat hozzáadása"; } }
    }
}
