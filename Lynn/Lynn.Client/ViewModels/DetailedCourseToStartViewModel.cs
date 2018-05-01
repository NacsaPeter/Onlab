using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lynn.Client.ViewModels
{
    public class DetailedCourseToStartViewModel : ViewModelBase
    {
        public ICommand Start_Click { get; set; }
        public ICommand Cancel_Click { get; set; }

        public DetailedCourseToStartViewModel(Course course)
        {
            Course = course;

            Start_Click = new RelayCommand(new Action(Start));
            Cancel_Click = new RelayCommand(new Action(Cancel));
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
            set
            {
                if (_course != value)
                {
                    _course = value;
                    RaisePropertyChanged(nameof(Course));
                }
            }
        }

        private void Cancel()
        {
        }

        private void Start()
        {
            NavigationService.Navigate(typeof(TestsPage), Course);
        }
    }
}
