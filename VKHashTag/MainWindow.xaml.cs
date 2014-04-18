using MahApps.Metro;
using System.Windows;
using VKHashTag.Engine.Class;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows.Controls;
using VKHashTag.Engine.Class.MessageDialog;

namespace VKHashTag
{
    public partial class MainWindow : MetroWindow
    {
        public static MainWindow main = null;

        public MainWindow()
        {
            db.Load(); //Загружаем статичиские данные
            InitializeComponent();
            TB_FlyoutsTheme.Tag = db.conf.theme.FlyoutsControl;  //Загрузка темя для окошек мендальных
            LB_AccentColors.DataContext = new Engine.Style.AccentColorMenu(); //Выбор цветовых схем
            main = this;
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(400);
            UpdateSettings.get();
            sender = null; e = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                Оформление программы (тема, цвета)                                  #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SelectionTheme(object sender, RoutedEventArgs e)
        {
            var MenuItem = (sender as MenuItem);
            if (MenuItem != null && db.conf.theme.them != MenuItem.Header.ToString())
            {
                db.conf.theme.them = MenuItem.Header.ToString();
                ThemeManager.ChangeTheme(Application.Current, ThemeManager.DetectTheme(Application.Current).Item2, (db.conf.theme.them == "Light" ? Theme.Light : Theme.Dark));
                CryptoDB.Write(FileDB.conf, db.conf);
            }
            sender = null; e = null; MenuItem = null;
        }


        private void SelectionFlyoutTheme(object sender, RoutedEventArgs e)
        {
            var MenuItem = (sender as MenuItem);
            if (MenuItem != null && db.conf.theme.FlyoutsControl != MenuItem.Header.ToString())
            {
                TB_FlyoutsTheme.Tag = db.conf.theme.FlyoutsControl = MenuItem.Header.ToString().Trim();
                CryptoDB.Write(FileDB.conf, db.conf);
            }
            sender = null; e = null; MenuItem = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                           Мендальные окна                                          #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ShowModal_Settings(object sender, RoutedEventArgs e)
        {

            this.ToggleFlyout(0);
            sender = null; e = null;
        }

        private void ShowModal_Theme(object sender, RoutedEventArgs e)
        {

            this.ToggleFlyout(1);
            sender = null; e = null;
        }

        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                             Ссылка на GitHub проект и выбор табКонтрола                            #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LaunchOnGitHub(object sender, RoutedEventArgs e)
        {
            sender = null; e = null;
            System.Diagnostics.Process.Start("https://github.com/korner-brazers/VK-HashTag");
        }

        public async void AnimatedTabControlIndex(int index)
        {
            await Task.Delay(100);
            AnimatedTabControl.SelectedIndex = index;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                             Останавливаем все потоки при закрытие программы                        #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
            int ReadTask = 0, attempt = 0;

            do
            {
                ReadTask = 0;
                foreach (var main in db.job.main)
                {
                    if (main.Work)
                    {
                        IndexALL indexALL = JobDB.FindIndex(main.id);
                        if (indexALL.JobIndex != -1 && indexALL.JobTaskIndex != -1 && indexALL.MainIndex != -1)
                        {
                            db.JobTask[indexALL.JobTaskIndex].cts.Cancel();
                            ReadTask++;
                        }
                    }
                }

                if (ReadTask != 0) { await Task.Delay(1000 * 3); }

            } while (ReadTask != 0 && attempt++ < 60); //До трех минут с проверкой каждые 3 секунды
        }
    }
}
