using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Lynn.Client.Converters
{
    public class LanguageToFlagPicturePathConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var lang = (LanguageDto)value;
            if (lang.Territory == null)
            {
                return $"/Assets/flags/{lang.Language.Code}.png";
            }
            else
            {
                return $"/Assets/flags/{lang.Language.Code}/{lang.Territory.Code}.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
