using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MahApps.Metro.Controls.Dialogs
{
    public partial class WaitProgressDialog : WaitBaseMetroDialog
    {
        internal WaitProgressDialog(MetroWindow parentWindow, MetroDialogSettings settings) : base(parentWindow, settings)
        {
            InitializeComponent();

            try
            {
                ProgressBarForeground = this.FindResource("AccentColorBrush") as Brush; //Выбо цвета для шариков
            }
            catch (Exception) { ProgressBarForeground = Brushes.White; }
        }
        internal WaitProgressDialog(MetroWindow parentWindow) : this(parentWindow, null)
        {

        }

        public static readonly DependencyProperty ProgressBarForegroundProperty = DependencyProperty.Register("ProgressBarForeground", typeof(Brush), typeof(WaitProgressDialog), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(WaitProgressDialog), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty NegativeButtonTextProperty = DependencyProperty.Register("NegativeButtonText", typeof(string), typeof(WaitProgressDialog), new PropertyMetadata("Cancel"));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public string NegativeButtonText
        {
            get { return (string)GetValue(NegativeButtonTextProperty); }
            set { SetValue(NegativeButtonTextProperty, value); }
        }

        public Brush ProgressBarForeground
        {
            get { return (Brush)GetValue(ProgressBarForegroundProperty); }
            set { SetValue(ProgressBarForegroundProperty, value); }
        }
    }

    /// <summary>
    /// A class for manipulating an open ProgressDialog.
    /// </summary>
    public class WaitProgressDialogController
    {
        public WaitProgressDialogController() { }
        //No spiritdead, you can't change this.
        private WaitProgressDialog WrappedDialog { get; set; }
        private Func<Task> CloseCallback { get; set; }

        /// <summary>
        /// Gets if the wrapped ProgressDialog is open.
        /// </summary>
        public bool IsOpen { get; private set; }

        internal WaitProgressDialogController(WaitProgressDialog dialog, Func<Task> closeCallBack)
        {
            WrappedDialog = dialog;
            CloseCallback = closeCallBack;

            IsOpen = dialog.IsVisible;

        }

        void PART_NegativeButton_Click(object sender, RoutedEventArgs e)
        {

            //Close();
        }

        /// <summary>
        /// Sets the ProgressBar's IsIndeterminate to true. To set it to false, call SetProgress.
        /// </summary>
        public void SetIndeterminate()
        {
            if (WrappedDialog.Dispatcher.CheckAccess())
                WrappedDialog.PART_ProgressBar.IsIndeterminate = true;
            else
            {
                WrappedDialog.Dispatcher.Invoke(new Action(() =>
                {
                    WrappedDialog.PART_ProgressBar.IsIndeterminate = true;
                }));
            }
        }


        /// <summary>
        /// Sets the dialog's progress bar value and sets IsIndeterminate to false.
        /// </summary>
        /// <param name="value">The percentage to set as the value.</param>
        public void SetProgress(double value)
        {
            if (value < 0.0 || value > 1.0) throw new ArgumentOutOfRangeException("value");

            Action action = () =>
            {
                WrappedDialog.PART_ProgressBar.IsIndeterminate = false;
                WrappedDialog.PART_ProgressBar.Value = value;
                WrappedDialog.PART_ProgressBar.Maximum = 1.0;
                WrappedDialog.PART_ProgressBar.ApplyTemplate();
            };

            if (WrappedDialog.Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                WrappedDialog.Dispatcher.Invoke(action);
            }


        }

        /// <summary>
        /// Sets the dialog's message content.
        /// </summary>
        /// <param name="message">The message to be set.</param>
        public void SetMessage(string message)
        {
            if (WrappedDialog.Dispatcher.CheckAccess())
            {
                WrappedDialog.Message = message;
            }
            else
            {
                WrappedDialog.Dispatcher.Invoke(new Action(() => { WrappedDialog.Message = message; }));
            }
        }


        public void SetTitle(string title)
        {
            if (WrappedDialog.Dispatcher.CheckAccess())
            {
                WrappedDialog.Title = title;
            }
            else
            {
                WrappedDialog.Dispatcher.Invoke(new Action(() => { WrappedDialog.Title = title; }));
            }
        }

        public Task CloseAsync()
        {
            try
            {
                Action action = () =>
                {
                    if (!IsOpen) throw new InvalidOperationException();
                    WrappedDialog.Dispatcher.VerifyAccess();
                };

                if (WrappedDialog.Dispatcher.CheckAccess())
                {
                    action();
                }
                else
                {
                    WrappedDialog.Dispatcher.Invoke(action);

                }

                return CloseCallback().ContinueWith(x => WrappedDialog.Dispatcher.Invoke(new Action(() =>
                {
                    IsOpen = false;
                })));
            }
            catch { return Task.Delay(0); }
        }
    }
}
