using System;
using System.Threading;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Threading;

namespace VKHashTag.Engine.Style.MainVK.Generic
{
    public class HeightListBoxMain : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;
            DoAsync(() =>
            {
                double x = (double)value;
                result = (x - (x % 85));
            });

            value = null; targetType = null; parameter = null; culture = null;
            return result;
        }

        private void DoAsync(Action action)
        {
            var frame = new DispatcherFrame();
            new Thread((ThreadStart)(() =>
            {
                action();
                frame.Continue = false;
            })).Start();
            Dispatcher.PushFrame(frame);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            throw new NotImplementedException();
        }
    }
}
