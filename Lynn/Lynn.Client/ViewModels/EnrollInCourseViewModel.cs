using Lynn.Client.Helpers;
using Lynn.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class EnrollInCourseViewModel : ViewModelBase
    {
        public ICommand SearchCourseByName_Click { get; set; }
        private VariableSizedWrapGrid coursesContainer;

        public EnrollInCourseViewModel(VariableSizedWrapGrid coursesContainer)
        {
            this.coursesContainer = coursesContainer;
            SearchCourseByName_Click = new RelayCommand(new Action(SearchCourseByName));
        }

        private void SearchCourseByName()
        {
            coursesContainer.Children.Add(new CourseToEnrollInView());
        }
    }
}
