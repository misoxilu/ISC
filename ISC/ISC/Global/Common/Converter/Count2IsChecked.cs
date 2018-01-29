using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ISC.Global.Common.Converter
{
    public class Count2IsChecked : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var input = Convert.ToInt32(value);
            return (input % 2) == 0 ? true : false;
            //throw new NotImplementedException();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert.ToBoolean(value) ? 0 : 1;
            //throw new NotImplementedException();
        }
    }
}
