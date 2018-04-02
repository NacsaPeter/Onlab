﻿using System;

using Lynn.Client.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void EnrolledCoursesViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            EnrolledCoursesViewControl.DataContext = new EnrolledCoursesViewModel();
        }

        private void EnrollInCourseViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            EnrollInCourseViewControl.DataContext = new EnrollInCourseViewModel();
        }
    }
}