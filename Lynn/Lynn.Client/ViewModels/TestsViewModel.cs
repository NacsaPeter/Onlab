using Lynn.Client.Views;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Lynn.Client.ViewModels
{
    public class TestsViewModel : ViewModelBase
    {
        private readonly HttpClient client = new HttpClient();

        private VariableSizedWrapGrid _testsVariableSizedWrapGrid;

        public TestsViewModel(VariableSizedWrapGrid testsVariableSizedWrapGrid)
        {
            _testsVariableSizedWrapGrid = testsVariableSizedWrapGrid;

            client.BaseAddress = new Uri("http://localhost:56750/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/tests"));
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

        public void RefreshTests()
        {
            _testsVariableSizedWrapGrid.Children.Clear();
            var result = ProcessTestsByCourseID(Course.ID);
        }

        private async Task<ObservableCollection<Test>> ProcessTestsByCourseID(int courseID)
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Test>));

            var streamTask = client.GetStreamAsync($"http://localhost:56750/api/tests/{courseID}");
            var searchedTests = serializer.ReadObject(await streamTask) as ObservableCollection<Test>;
            
            foreach (var test in searchedTests)
            {
                _testsVariableSizedWrapGrid.Children.Add(new TestToStartView(test));
            }
            return searchedTests;
        }
    }
}
