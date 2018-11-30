using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lynn.Client.ViewModels
{
    public class EditRuleViewModel : Observable
    {
        public ICommand SaveRule_Click { get; set; }

        private RuleDto _rule;
        public RuleDto Rule
        {
            get { return _rule; }
            set { Set(ref _rule, value, nameof(Rule)); }
        }

        public EditRuleViewModel()
        {
            SaveRule_Click = new RelayCommand(SaveRule);
        }

        public async void SaveRule()
        {
            var service = new ExerciseService();
            if (Rule.Id == 0)
            {
                await service.PostRuleAsync(Rule);
            }
            else
            {
                await service.PutRuleAsync(Rule);
            }
        }
    }
}
