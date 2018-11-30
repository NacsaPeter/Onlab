using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.ViewModels
{
    public class LearnRulesViewModel: Observable
    {
        private Test _test;
        public Test Test
        {
            get { return _test; }
            set { Set(ref _test, value, nameof(Test)); }
        }

        private User _loggedInUser;
        public User LoggedInUser
        {
            get { return _loggedInUser; }
            set { Set(ref _loggedInUser, value, nameof(LoggedInUser)); }
        }

        private ObservableCollection<RuleDto> _rules;
        public ObservableCollection<RuleDto> Rules
        {
            get { return _rules; }
            set { Set(ref _rules, value, nameof(Rules)); }
        }

        private RuleDto _currentRule;
        public RuleDto CurrentRule
        {
            get { return _currentRule; }
            set { Set(ref _currentRule, value, nameof(CurrentRule)); }
        }

        public LearnRulesViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
        }

        public async Task ProcessRulesAsync()
        {
            var service = new ExerciseService();
            Rules = await service.GetGrammarRules(Test.ID);
            if (Rules.Count != 0)
            {
                CurrentRule = Rules[0];
            }
        }
    }
}
