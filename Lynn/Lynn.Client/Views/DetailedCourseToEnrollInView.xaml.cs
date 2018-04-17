﻿using Lynn.Client.ViewModels;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lynn.Client.Views
{
    public sealed partial class DetailedCourseToEnrollInView : ContentDialog
    {
        public DetailedCourseToEnrollInViewModel ViewModel { get; }

        public DetailedCourseToEnrollInView(Course course)
        {
            this.InitializeComponent();
            ViewModel = new DetailedCourseToEnrollInViewModel(course);
            DataContext = ViewModel;
        }

        private void EnrollIn_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var result = ViewModel.EnrollInAsync();
        }

        private void Cancel_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
