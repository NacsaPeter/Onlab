using Lynn.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Lynn.Client.Converters
{
    public class ExerciseStateToColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var state = (ExerciseState)value;
            if (state == ExerciseState.NotAnswered)
            {
                return new SolidColorBrush(Colors.LightCyan);
            }
            else if (state == ExerciseState.Success)
            {
                return new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                return new SolidColorBrush(Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
