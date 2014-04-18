using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VKHashTag.Engine.UserControls
{
    public partial class MainVK : UserControl
    {
        VKHashTag.Engine.InfoClass.User user = db.user;

        public MainVK()
        {
            InitializeComponent();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                            Отправляем по клику на профиль пользователя                             #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PutUserIDhttp_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            sender = null; e = null;
            System.Diagnostics.Process.Start("https://vk.com/id" + user.uid);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                      Смена аккаунта и обновление баланса в Antigate                                #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ChangeUser_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (MainWindow.main.Flyouts.Items[0] as Flyout).IsOpen = true;
            sender = null; e = null;
        }

        private async void UpdateBalanceAntigate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            user.BalanceAntigate = -1;
            await Task.Delay(500);
            user.BalanceAntigate = await vkAPI.Antigate.GetBalance;
            sender = null; e = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                       Изменение интервала                                          #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ChangeIntervalMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (user.Interval - 1 >= 2)
            {
                user.Interval--;
                CryptoDB.Write(FileDB.user, db.user);
            }
            sender = null; e = null;
        }

        private void ChangeIntervalMAx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (user.Interval + 1 <= 720)
            {
                user.Interval++;
                CryptoDB.Write(FileDB.user, db.user);
            }
            sender = null; e = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                      Добовляем задание                                             #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void JobADD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sender = null; e = null;
            MainWindow.main.AnimatedTabControlIndex(1);
        }
    }
}
