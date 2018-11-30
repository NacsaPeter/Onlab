using Lynn.Client.Helpers;
using Lynn.Client.Services;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Lynn.Client.ViewModels
{
    public class EditVocabularyExerciseViewModel : Observable
    {
        public User LoggedInUser { get; set; }
        public ICommand SaveExercise_Click { get; set; }
        public ICommand DeleteExercise_Click { get; set; }
        public ICommand SelectPicture_Click { get; set; }

        private bool _saving = false;
        public bool Saving
        {
            get { return _saving; }
            set { Set(ref _saving, value, nameof(Saving)); }
        }

        private bool _saved = false;
        public bool Saved
        {
            get { return _saved; }
            set { Set(ref _saved, value, nameof(Saved)); }
        }

        private bool _notSaved = false;
        public bool NotSaved
        {
            get { return _notSaved; }
            set { Set(ref _notSaved, value, nameof(NotSaved)); }
        }

        private VocabularyExercise _exercise;
        public VocabularyExercise Exercise
        {
            get { return _exercise; }
            set { Set(ref _exercise, value, nameof(Exercise)); }
        }

        private string _learnigLanguage;
        public string LearningLanguage
        {
            get { return _learnigLanguage; }
            set { Set(ref _learnigLanguage, value, nameof(LearningLanguage)); }
        }

        private string _teachingLanguage;
        public string TeachingLanguage
        {
            get { return _teachingLanguage; }
            set { Set(ref _teachingLanguage, value, nameof(TeachingLanguage)); }
        }

        public EditVocabularyExerciseViewModel()
        {
            LoggedInUser = MainViewModel.LoggedInUser;
            SaveExercise_Click = new RelayCommand(SaveExercise);
            DeleteExercise_Click = new RelayCommand(DeleteExerciseContentDialog);
            SelectPicture_Click = new RelayCommand(SelectPicture);
        }

        private async void SaveExercise()
        {
            var service = new ExerciseService();
            if (Exercise.ID == 0)
            {
                Saving = true;
                var exercise = await service.PostVocabularyExerciseAsync(Exercise);
                Saving = false;
                if (exercise == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Exercise = exercise;
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
            else
            {
                Saving = true;
                var exercise = await service.PutVocabularyExerciseAsync(Exercise);
                Saving = false;
                if (exercise == null)
                {
                    NotSaved = true;
                    await Task.Delay(2000);
                    NotSaved = false;
                }
                else
                {
                    Exercise = exercise;
                    Saved = true;
                    await Task.Delay(2000);
                    Saved = false;
                }
            }
        }

        private async void DeleteExercise()
        {
            var service = new ExerciseService();
            bool result = await service.DeleteVocabularyExerciseAsync(Exercise);
            if (result)
            {
                NavigationService.GoBack();
            }
        }

        private async void SelectPicture()
        {
            FileOpenPicker open = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                ViewMode = PickerViewMode.Thumbnail
            };

            open.FileTypeFilter.Clear();
            open.FileTypeFilter.Add(".bmp");
            open.FileTypeFilter.Add(".png");
            open.FileTypeFilter.Add(".jpeg");
            open.FileTypeFilter.Add(".jpg");

            //StorageFolder folder = await StorageFolder.GetFolderFromPathAsync("\\Assets");
            //await file.CopyAsync(folder);

            try
            {
                //create file in public folder
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                //StorageFile sampleFile = await storageFolder.CreateFileAsync("test.txt", CreationCollisionOption.ReplaceExisting);
                StorageFile file = await open.PickSingleFileAsync();

                //get asets folder
                StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFolder assetsFolder = await appInstalledFolder.GetFolderAsync("Assets");

                //move file from public folder to assets
                await file.MoveAsync(assetsFolder, $"test{Exercise.TestID}{file.Name}", NameCollisionOption.ReplaceExisting);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: " + ex);
            }

            //string fName = $"test{Exercise.TestID}{file.Name}";
            //Exercise.Picture = fName;

            //string sourceDir = file.Path.Substring(0, file.Path.Length - file.Name.Length - 1);
            //string destDir = "C:\\Users\\Public\\Pictures";

            //File.Copy(Path.Combine(sourceDir, file.Name), Path.Combine(destDir, fName), true);
        }

        public async Task SetLanguages()
        {
            var service = new CourseService();
            var course = await service.GetCourseByTestIdAsync(Exercise.TestID);
            LearningLanguage = course.LearningLanguage.Language.Name;
            TeachingLanguage = course.TeachingLanguage.Language.Name;
        }

        private async void DeleteExerciseContentDialog()
        {
            var contentDialog = new ContentDialog
            {
                Content = new TextBlock
                {
                    Text = $"Biztosan törli a feladatot?",
                    TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                    FontSize = 18,
                    Margin = new Windows.UI.Xaml.Thickness(20)
                },
                Background = new SolidColorBrush(Colors.LemonChiffon),
                CloseButtonText = "Mégse",
                PrimaryButtonText = "Törlés",
                PrimaryButtonCommand = new RelayCommand(DeleteExercise)
            };
            await contentDialog.ShowAsync();
        }
    }
}
