using System;
using System.Windows.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VKHashTag.Engine.Converters
{
    class MatchConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int IntRes = -1;
            double _value = 0, DoubleRes = -1;
            string param = parameter as string;

            //Распаковываем значение value
            if (value is double)
            {
                _value = (double)value;
            }
            else if (value is int)
            {
                _value = (int)value;
            }
            else
            {
                return 0;
            }


            //Проверка на параметры уровнения
            if (param == null)
            {
                return _value;
            }


            //Решаем уровнение
            GroupCollection g = new Regex(@"^([intdouble]+):(.*)").Match(param.ToLower().Replace("value", _value.ToString())).Groups;
            switch (g[1].Value.Replace(" ", "").Trim())
            {
                case "int": IntRes = (int)Engine.Class.RPN.get(g[2].Value); break;
                case "double": DoubleRes = Engine.Class.RPN.get(g[2].Value); break;
                case "doubleint": DoubleRes = (int)Engine.Class.RPN.get(g[2].Value); break;
            }


            //Возвращаем результат
            if (DoubleRes == -1)
                return IntRes;
            else
                return DoubleRes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            throw new NotImplementedException();
        }
    }
}
