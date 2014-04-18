using vkAPI;
using System;
using vkAPI.api;
using vkAPI.InfoClass.user;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using System.Windows.Media.Imaging;
using VKHashTag.Engine.UserControls;
using VKHashTag.Engine.Class.MessageDialog;

namespace VKHashTag.Engine.Class
{
    class UpdateSettings
    {
        private static bool read = false;
        public static async void get()
        {
            if (read)
                return;

            read = true;
            bool Settings = false;
            DateTime timer = DateTime.Now;
            ReSettings: if (Settings || ((db.user.login == null || db.user.passwd == null || db.user.idAPP == null || db.user.scope == null) && db.user.token == null))
            {
                //Если нету логина и пароля и токена
                await db.wait.Close();
                var flyout = MainWindow.main.Flyouts.Items[0] as Flyout;
                flyout.IsOpen = true;

                while (flyout.IsOpen)
                    await Task.Delay(50);

                flyout = null; Settings = false;
                goto ReSettings;
            }
            else if (db.user.token == null || db.user.token.Trim() == "")
            {
                //Если данные логина пароля и т.д заполнены но token отсутсвует
                await db.wait.Show();
                if (await aut.Sign(db.user.idAPP, db.user.scope, db.user.login, db.user.passwd))
                {
                    db.user.token = VKdata.token.Trim();
                    goto ReSettings;
                }
                else
                {
                    await db.wait.Close();
                    await MessageBOX.ShowFix("Не удалось авторизоваться и получить token..");
                    Settings = true;
                    goto ReSettings;
                }
            }
            else if (db.user.token != null && db.user.token.Trim() != "")
            {
                //Если токен уже получен то просто проверяем его работоспособность и заполняем данные
                await db.wait.Show();
                Get get = await users.get(null, db.user.token, "photo_100");
                if (get != null && get.uid != 0 && get.first_name != null && get.last_name != null)
                {
                    aut.PutToken(db.user.token);
                    db.user.uid = get.uid;
                    db.user.UserName = get.first_name + " " + get.last_name;
                    db.user.photo_100 = get.photo_100 == null ? null : (get.photo_100.ToLower().Trim() != "http://vk.com/images/camera_b.gif" ? get.photo_100 : null);
                    get = null;
                }
                else
                {
                    get = null; db.user.token = null;
                    goto ReSettings;
                }
            }
            else
            {
                await db.wait.Close();
                await MessageBOX.ShowFix("Что-то пошло не так..");
                MainWindow.main.Close();
            }

            //Закрываем окно ожидания, обновляем ключ и баланс Antigate
            CryptoDB.Write(FileDB.user, db.user);
            VKdata.KeyAntigate = db.user.KeyAntigate;
            db.user.BalanceAntigate = await vkAPI.Antigate.GetBalance;

            //Если все проверки закончились меньше чем за 2 секунду, то ждем оставшиеся время
            int time = 3000 - (int)(DateTime.Now - timer).TotalMilliseconds;
            if (time > 0) { await Task.Delay(time); }

            //Закрываем окно ожидания
            await db.wait.Close();
            read = false;
        }
    }
}
