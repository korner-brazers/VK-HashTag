using System;
using System.Windows;
using System.ComponentModel;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using System.Runtime.CompilerServices;

namespace VKHashTag.Engine.Class.MessageDialog
{
    public class WaitProgress : INotifyPropertyChanged
    {
        private Visibility _IsVisibility = Visibility.Hidden;
        private Task<WaitProgressDialogController> controller = null;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        ////////////////////////////////////////////////////////////////////////////////

        public Task<WaitProgressDialogController> Show(string text = "Please wait...")
        {
            if (controller == null || !controller.Result.IsOpen)
            {
                IsVisibility = Visibility.Hidden;
                return (controller = DialogManager.ShowWaitProgressAsync(MainWindow.main, text));
            }
            else
            {
                text = null;
                return Task.Run(() => new WaitProgressDialogController());
            }
        }


        public Task Close()
        {
            IsVisibility = Visibility.Visible;

            if (controller != null)
                return controller.Result.CloseAsync();
            else
                return Task.Delay(50);
        }


        public Visibility IsVisibility
        {
            get 
            {
                return _IsVisibility;
            }
            private set
            {
                _IsVisibility = value;
                NotifyPropertyChanged();
            }
        }
    }
}
