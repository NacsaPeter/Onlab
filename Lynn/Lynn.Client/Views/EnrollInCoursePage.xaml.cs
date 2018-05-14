﻿using Lynn.Client.Models;
using Lynn.Client.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lynn.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EnrollInCourse : Page
    {
        public EnrollInCourseViewModel ViewModel { get; }

        public EnrollInCourse()
        {
            this.InitializeComponent();
            ViewModel = new EnrollInCourseViewModel();
            DataContext = ViewModel;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var coursePresenter = (CoursePresenter)e.ClickedItem;
            ViewModel.ShowCourseDetails(coursePresenter.Course);
        }
    }
}
