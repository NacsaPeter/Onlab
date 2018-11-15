using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class NewTestPresenter : TestPresenter
    {
        public new string Picture { get { return "/Assets/new-course.png"; } }
        public new Test Test { get { return null; } }
        public new string CategoryName { get { return "Új feladatsor hozzáadása"; } }
        public new int Level { get { return 0; } }
    }
}
