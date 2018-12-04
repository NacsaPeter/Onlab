using Lynn.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Lynn.Client.Converters
{
    public class ExerciseStateToBoolConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((ExerciseState)value == ExerciseState.NotAnswered)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
