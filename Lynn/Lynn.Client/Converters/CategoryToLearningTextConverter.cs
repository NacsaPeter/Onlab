using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Lynn.Client.Converters
{
    public class CategoryToLearningTextConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((string)value == "Nyelvtan")
            {
                return "Szabályok tanulása";
            }
            else
            {
                return "Kifejezések tanulása";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
