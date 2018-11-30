using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class RulePresenter
    {
        public RuleDto Rule { get; set; }
        public bool isCurrent { get; set; }

        public RulePresenter() { }

        public RulePresenter(RuleDto rule)
        {
            Rule = rule;
        }
    }
}
