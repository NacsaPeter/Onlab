using Lynn.Client.ViewModels;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Lynn.Client.Views
{
    public sealed partial class CourseToEnrollInView : UserControl
    {
        public CourseToEnrollInViewModel ViewModel { get; } 

        public CourseToEnrollInView(Course course)
        {
            this.InitializeComponent();
            ViewModel = new CourseToEnrollInViewModel(DetailsButton, course);
            DataContext = ViewModel;
        }
    }
}
