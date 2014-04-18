using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Threading;
using System.Windows.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace VKHashTag.Engine.Converters
{
    public class DownloadImageAsyncConv : IValueConverter
    {
        private static bool ClearWork = false;
        private static DateTime time = DateTime.Now;
        private static List<db> TempDB = new List<db> { };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Качает по одному как асинхронный но не мешает самой программе так как идет во внутренем потоке
            object result = null;
            DoAsync(() =>
            {
                string url = (string)value;
                db temp = TempDB.Find(item => (item.url == url)); //Поиск такого URL в списке

                //Отдаем картинку
                if (temp != null && temp.image != null)
                {
                    result = temp.image;
                }
                else
                {
                    BitmapImage TempIMG = new Class.DownloadImage().BitmapImage((string)value);
                    TempDB.Add(new db()
                        {
                            url = url,
                            image = TempIMG
                        });
                    result = TempIMG; TempIMG = null;
                }
            });


            time = DateTime.Now; ClearDB(); value = null; targetType = null; parameter = null; culture = null;
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

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            throw new NotSupportedException();
        }


        private class db
        {
            public string url { get; set; }
            public BitmapImage image { get; set; }
        }

        private async void ClearDB()
        {
            if (!ClearWork)
            {
                ClearWork = true;
                while(true)
                {
                    await Task.Delay(1000 * 60 * 10);
                    if ((DateTime.Now - time).TotalMinutes > 10)
                    {
                        TempDB.Clear(); 
                        TempDB = new List<db> { };
                        ClearWork = false;
                        break;
                    }
                }
            }
        }
    }
}
