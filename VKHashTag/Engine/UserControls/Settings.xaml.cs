using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using VKHashTag.Engine.Class;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using VKHashTag.Engine.Class.MessageDialog;

namespace VKHashTag.Engine.UserControls
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            NU_SleepMax.Value = db.conf.SleepMax;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                    Закрытие и сохранение задания                                   #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            var flyout =  MainWindow.main.Flyouts.Items[0] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
            flyout = null; sender = null; e = null;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            //Если логн или пароль изменился то удаляем старый токен
            if (db.user.login != login || db.user.passwd != passwd)
                db.user.token = null;

            //Загрузка приложения
            if (db.user.UserVK_APP != null && db.user.UserVK_APP.Trim() != "")
            {
                db.user.idAPP = db.user.UserVK_APP;
            }
            else
            {
                switch (CB_idAPP_VK.SelectedIndex)
                {
                    case 0: db.user.idAPP = "3682744"; break;
                    case 1: db.user.idAPP = "3087106"; break;
                    case 2: db.user.idAPP = "2890984"; break;
                    case 3: db.user.idAPP = "3502561"; break;
                    default: db.user.idAPP = "3087106"; break;
                }
            }

            //Сохраняем данные и получаем новые токен если нужно
            db.conf.SleepMax = (short)NU_SleepMax.Value;
            CryptoDB.Write(FileDB.conf, db.conf);
            UpdateSettings.get();
            sender = null; e = null;
            CloseClick(null, null);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                 Проверка на смену логина и пароля                                  #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private string passwd, login;

        private void Settings_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((MainWindow.main.Flyouts.Items[0] as Flyout).IsOpen && (sender as UserControl) != null)
            {
                MainWindow.main.BT_Theme.IsEnabled = false;
                passwd = db.user.passwd;
                login = db.user.login;
            }
            else
                MainWindow.main.BT_Theme.IsEnabled = true;

            sender = null;
        }
    }
}
