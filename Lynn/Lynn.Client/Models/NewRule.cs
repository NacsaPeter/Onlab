using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class NewRule : RulePresenter
    {
        public NewRule()
        {
            Rule = new RuleDto
            {
                Name = "+ Új szabály hozzáadása"
            };
        }
    }
}
