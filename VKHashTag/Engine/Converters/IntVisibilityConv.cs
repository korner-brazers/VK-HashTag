using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace VKHashTag.Engine.Converters
{
    class IntVisibilityConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((parameter as string)[0])
            {
                case '+': return ((((int)value)) >= int.Parse((parameter as string).Remove(0, 1))) ? Visibility.Visible : Visibility.Collapsed;
                case '-': return ((((int)value)) <= int.Parse((parameter as string).Remove(0, 1))) ? Visibility.Visible : Visibility.Collapsed;
                case '=': return ((((int)value)) == int.Parse((parameter as string).Remove(0, 1))) ? Visibility.Visible : Visibility.Collapsed;
                case '!':
                    {
                        if (((parameter as string)[0].ToString() + (parameter as string)[1].ToString()).Trim() == "!=")
                            return ((((int)value)) != int.Parse((parameter as string).Remove(0, 2))) ? Visibility.Visible : Visibility.Collapsed;
                        else
                            return ((((int)value)) != int.Parse((parameter as string).Remove(0, 1))) ? Visibility.Visible : Visibility.Collapsed;
                    }
                default: return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            throw new NotImplementedException();
        }
    }
}
