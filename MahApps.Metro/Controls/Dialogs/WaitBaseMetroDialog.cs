using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls.Dialogs
{
    [System.Windows.Markup.ContentProperty("DialogBody")]
    public abstract class WaitBaseMetroDialog : Control
    {
        private const string PART_DialogBody_ContentPresenter = "PART_DialogBody_ContentPresenter";
        private ContentPresenter DialogBody_ContentPresenter = null;

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(WaitBaseMetroDialog), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty DialogBodyProperty = DependencyProperty.Register("DialogBody", typeof(object), typeof(WaitBaseMetroDialog), new PropertyMetadata(null, (o, e) =>
        {
            WaitBaseMetroDialog dialog = (o as WaitBaseMetroDialog);
            if (dialog != null)
            {
                if (e.OldValue != null)
                {
                    dialog.RemoveLogicalChild(e.OldValue);
                }
                if (e.NewValue != null)
                {
                    dialog.AddLogicalChild(e.NewValue);
                }
            }
        }));
        public static readonly DependencyProperty DialogTopProperty = DependencyProperty.Register("DialogTop", typeof(object), typeof(WaitBaseMetroDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty DialogBottomProperty = DependencyProperty.Register("DialogBottom", typeof(object), typeof(WaitBaseMetroDialog), new PropertyMetadata(null));

        protected MetroDialogSettings DialogSettings { get; private set; }

        /// <summary>
        /// Gets/sets the dialog's title.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Gets/sets arbitrary content in the "message" area in the dialog. 
        /// </summary>
        public object DialogBody
        {
            get { return GetValue(DialogBodyProperty); }
            set { SetValue(DialogBodyProperty, value); }
        }

        /// <summary>
        /// Gets/sets arbitrary content on top of the dialog.
        /// </summary>
        public object DialogTop
        {
            get { return GetValue(DialogTopProperty); }
            set { SetValue(DialogTopProperty, value); }
        }

        /// <summary>
        /// Gets/sets arbitrary content below the dialog.
        /// </summary>
        public object DialogBottom
        {
            get { return GetValue(DialogBottomProperty); }
            set { SetValue(DialogBottomProperty, value); }
        }

        internal SizeChangedEventHandler SizeChangedHandler { get; set; }


        static WaitBaseMetroDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WaitBaseMetroDialog), new FrameworkPropertyMetadata(typeof(WaitBaseMetroDialog)));
        }

        public override void OnApplyTemplate()
        {
            DialogBody_ContentPresenter = GetTemplateChild(PART_DialogBody_ContentPresenter) as ContentPresenter;

            base.OnApplyTemplate();
        }

        /// <summary>
        /// Initializes a new MahApps.Metro.Controls.BaseMetroDialog.
        /// </summary>
        /// <param name="owningWindow">The window that is the parent of the dialog.</param>
        protected WaitBaseMetroDialog(MetroWindow owningWindow, MetroDialogSettings settings)
        {
            DialogSettings = settings == null ? owningWindow.MetroDialogOptions : settings;

            Initialize();

            OwningWindow = owningWindow;
        }


        /// <summary>
        /// Initializes a new MahApps.Metro.Controls.BaseMetroDialog.
        /// </summary>
        protected WaitBaseMetroDialog()
        {
            DialogSettings = new MetroDialogSettings();

            Initialize();
        }

        private void Initialize()
        {
            this.SetResourceReference(ForegroundProperty, "BlackColorBrush");
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("pack://application:,,,/MahApps.Metro;component/Themes/Dialogs/WaitBaseMetroDialog.xaml") });

        }

        /// <summary>
        /// Waits for the dialog to become ready for interaction.
        /// </summary>
        /// <returns>A task that represents the operation and it's status.</returns>
        public Task WaitForLoadAsync()
        {
            Dispatcher.VerifyAccess();

            if (this.IsLoaded) return new Task(() => { });

            if (!DialogSettings.UseAnimations)
                this.Opacity = 1.0; //skip the animation

            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            RoutedEventHandler handler = null;
            handler = new RoutedEventHandler((sender, args) =>
                {
                    this.Loaded -= handler;

                    tcs.TrySetResult(null);
                });

            this.Loaded += handler;

            return tcs.Task;
        }


        internal protected virtual void OnShown() { }
        internal protected virtual void OnClose()
        {
            if (ParentDialogWindow != null) //this is only set when a dialog is shown (externally) in it's OWN window.
                ParentDialogWindow.Close();
        }

        /// <summary>
        /// A last chance virtual method for stopping an external dialog from closing.
        /// </summary>
        /// <returns></returns>
        internal protected virtual bool OnRequestClose()
        {
            return true; //allow the dialog to close.
        }

        /// <summary>
        /// Gets the window that owns the current Dialog IF AND ONLY IF the dialog is shown externally.
        /// </summary>
        protected internal Window ParentDialogWindow { get; internal set; }
        /// <summary>
        /// Gets the window that owns the current Dialog IF AND ONLY IF the dialog is shown inside of a window.
        /// </summary>
        protected internal MetroWindow OwningWindow { get; internal set; }

        public Task _WaitForCloseAsync()
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            if (DialogSettings.UseAnimations)
            {
                Storyboard closingStoryboard = this.Resources["DialogCloseStoryboard"] as Storyboard;

                if (closingStoryboard == null)
                    throw new InvalidOperationException("Unable to find the dialog closing storyboard. Did you forget to add BaseMetroDialog.xaml to your merged dictionaries?");

                EventHandler handler = null;
                handler = new EventHandler((sender, args) =>
                {
                    closingStoryboard.Completed -= handler;

                    tcs.TrySetResult(null);
                });

                closingStoryboard = closingStoryboard.Clone();

                closingStoryboard.Completed += handler;

                closingStoryboard.Begin(this);
            }
            else
            {
                this.Opacity = 0.0;
                tcs.TrySetResult(null); //skip the animation
            }

            return tcs.Task;
        }
    }
}
