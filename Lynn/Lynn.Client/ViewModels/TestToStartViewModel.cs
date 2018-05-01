using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lynn.Client.ViewModels
{
    public class TestToStartViewModel : ViewModelBase
    {
        public ICommand Start_Click { get; set; }

        public TestToStartViewModel(Test test)
        {
            Test = test;

            Start_Click = new RelayCommand(new Action(Start));
        }

        private void Start()
        {
            NavigationService.Navigate(typeof(DoExercisesPage), Test);
        }

        private Test _test;
        public Test Test
        {
            get { return _test; }
            set
            {
                if (_test != value)
                {
                    _test = value;
                    RaisePropertyChanged(nameof(Test));
                }
            }
        }

    }
}
