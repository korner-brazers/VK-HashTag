using System;
using System.Threading;
using System.Windows.Data;
using System.Windows.Markup;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace VKHashTag.Engine.Converters
{
    class DownloadImageTaskAsyncConv : MarkupExtension, IValueConverter
    {
        public DownloadImageTaskAsyncConv() { }
        private static bool ClearWork = false;
        private static DateTime time = DateTime.Now;
        private static List<db> TempDB = new List<db> { };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var task = Task.Run(async () =>
            {
                BitmapImage result = null;
                await Task.Run(() =>
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
            });
            return new TaskCompletionNotifier<BitmapImage>(task);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            value = null; targetType = null; parameter = null; culture = null;
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
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
                while (true)
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


    public class TaskCompletionNotifier<TResult> : INotifyPropertyChanged
    {
        public TaskCompletionNotifier(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var scheduler = (SynchronizationContext.Current == null) ? TaskScheduler.Current : TaskScheduler.FromCurrentSynchronizationContext();
                task.ContinueWith(t =>
                {
                    try
                    {
                        var propertyChanged = PropertyChanged;
                        if (propertyChanged != null)
                        {
                            propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
                            if (t.IsCanceled)
                            {
                                propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
                            }
                            else if (t.IsFaulted)
                            {
                                propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
                                propertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                            }
                            else
                            {
                                propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                                propertyChanged(this, new PropertyChangedEventArgs("Result"));
                            }
                        }
                    }
                    catch { };
                },
                CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, scheduler);
            }
        }

        // Gets the task being watched. This property never changes and is never <c>null</c>.
        public Task<TResult> Task { get; private set; }


        // Gets the result of the task. Returns the default value of TResult if the task has not completed successfully.
        public TResult Result { get { return (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult); } }

        // Gets whether the task has completed.
        public bool IsCompleted { get { return Task.IsCompleted; } }

        // Gets whether the task has completed successfully.
        public bool IsSuccessfullyCompleted { get { return Task.Status == TaskStatus.RanToCompletion; } }

        // Gets whether the task has been canceled.
        public bool IsCanceled { get { return Task.IsCanceled; } }

        // Gets whether the task has faulted.
        public bool IsFaulted { get { return Task.IsFaulted; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
