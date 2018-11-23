using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Lynn.Client.Converters
{
    public class CategoryToTestPicturePathConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return $"/Assets/categories/{(string)value}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
