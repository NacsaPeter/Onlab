using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Client.Models
{
    public class TestPresenter
    {
        private Test _test;
        public string CategoryName { get { return _test.CategoryName; } }
        public int Level { get { return _test.Level; } }
        public string Picture { get { return $"/Assets/categories/{CategoryName}.png"; } }
        public Test Test { get { return _test; } }

        public TestPresenter(Test test)
        {
            _test = test;
        }

        public static ObservableCollection<TestPresenter> GetTestPresenters(ObservableCollection<Test> tests)
        {
            var testPresenters = new ObservableCollection<TestPresenter>();
            foreach (var item in tests)
            {
                testPresenters.Add(new TestPresenter(item));
            }
            return testPresenters;
        }
    }
}
