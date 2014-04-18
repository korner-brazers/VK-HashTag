using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VKHashTag.Engine.Converters
{
    class StringFormatConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string param = (parameter as string), RegexTemplate = @"(\w+)\((\w+,\w+,\w+)\)";

            if (Regex.IsMatch(param, RegexTemplate))
            {
                //Окончание предложения в тексте, value обязательно должен быть числом
                double x = GetValueNumber(value);

                Match matc = new Regex(RegexTemplate).Match(param);
                while (matc.Success)
                {
                    GroupCollection g = new Regex(RegexTemplate).Match(matc.Value).Groups;
                    string FinText = g[1] + Engine.Class.FinText.get((g[2].Value.Split(',')[0]), (g[2].Value.Split(',')[1]), (g[2].Value.Split(',')[2]), (long)x);
                    string tmp = Regex.Replace(param, (g[1] + @"\((\w+,\w+,\w+)\)"), FinText);
                    param = tmp; tmp = null; FinText = null; matc = matc.NextMatch();
                }

                //Проверка, нужно ли возвращать все данные или вернуть "{0:N0}" для стринг формата
                if (Regex.IsMatch(param, "ValueNull"))
                {
                    return Regex.Replace(param, "ValueNull", "{0:N0}");
                }
                else
                {
                    return Regex.Replace(param, "value", string.Format("{0:N0}", x).Replace(((char)160), ','));
                }
            }
            else
            {
                //Простая замена строки, value может быть как string так и число, но возвращаеться всегда string 
                if (Regex.IsMatch(param, "ValueNull"))
                {
                    return Regex.Replace(param, "ValueNull", "{0:N0}");
                }
                else
                {
                    return "Не реализованно";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            throw new NotImplementedException();
        }



        private double GetValueNumber(object ob)
        {
            switch (ob.GetType().ToString().ToLower().Trim())
            {
                case "system.int64": return ((long)ob);
                case "system.uint64": return ((ulong)ob);
                case "system.int32": return ((int)ob);
                case "system.int16": return ((short)ob);
                case "system.double": return ((double)ob);
                case "system.byte": return ((byte)ob);
            }

            ob = null;
            return 0;
        }
    }
}
