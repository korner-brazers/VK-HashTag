using System;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace VKHashTag.Engine.Converters
{
    class NullBoolConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            if (value == null) { result = true; }

            value = null; targetType = null; parameter = null; culture = null;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            throw new NotImplementedException();
        }
    }
}
