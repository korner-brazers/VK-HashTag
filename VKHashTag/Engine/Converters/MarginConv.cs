using System;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace VKHashTag.Engine.Converters
{
    public class MarginConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness tk = ((Thickness)value);
            string param = (parameter as string);
            StringBuilder result = new StringBuilder();

            if (param != null)
            {
                try
                {
                    string[] mass = param.Split(',');
                    result.Append(conv(tk.Left, mass[0]) + ",");
                    result.Append(conv(tk.Top, mass[1]) + ",");
                    result.Append(conv(tk.Right, mass[2]) + ",");
                    result.Append(conv(tk.Bottom, mass[3]));
                    mass = null;
                }
                catch { result.Clear(); result.Append(tk.ToString()); }
            }

            return result.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            throw new NotImplementedException();
        }


        private int conv(double result, string s)
        {
            switch (s[0])
            {
                case '-': result -= int.Parse(s.Remove(0, 1)); break;
                case '+': result += int.Parse(s.Remove(0, 1)); break;
                case '*': result *= int.Parse(s.Remove(0, 1)); break;
                case '/': result /= int.Parse(s.Remove(0, 1)); break;
                default: result += int.Parse(s); break;
            }

            return (int)result;
        }
    }
}
