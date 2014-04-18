using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace vkAPI
{
    public class aut : VKdata
    {
        public static void PutToken(string token)
        {
            //Ручное указание токена
            VKdata.token = token; token = null;
        }


        public static Task<bool> Sign(string appID, string Scope, string login, string passwd)
        {
            //Чистим куки
            VKdata.Cookie = new System.Net.CookieContainer();
            return Task.Run(() =>
                {
                    try
                    {
                        byte attempt = 0;
                        Refresh: if (attempt > 3) //Убиваем запрос
                        {
                            appID = null; Scope = null; login = null; passwd = null;
                            return false;
                        }

                        //Запрашиваем страницу
                        GetBrowser get = Browser.Get("https://oauth.vk.com/authorize?client_id=" + appID + "&scope=" + Scope + "&redirect_uri=https://oauth.vk.com/blank.html&response_type=token", true);


                        //Если контакт требует от нас авторизации, то авторизуемся и пробуем загрузить контент снова
                        if (get.url == "/login.php" || get.html.Contains("//vk.com/restore"))
                        {
                            //Парсим хеш и другие данные для авторизации
                            string to = new Regex("<inputtype=\"hidden\"name=\"to\"id=\"to\"value=\"([a-zA-Z0-9]+)\"").Match(get.html).Groups[1].Value;
                            string ip_h = new Regex("<inputtype=\"hidden\"name=\"ip_h\"value=\"([a-zA-Z0-9]+)\"").Match(get.html).Groups[1].Value;
                            string data = "act=login&success_url=&fail_url=&try_to_login=1&to=" + to
                                        + "&al_test=3&from_host=vk.com&from_protocol=http&ip_h=" + ip_h
                                        + "&email=" + login + "&pass=" + passwd;

                            Browser.post("https://login.vk.com/", data, "http://vk.com/login.php", true);
                            to = null; ip_h = null; data = null; get = null; attempt++;
                            goto Refresh; //Возврашаемся для повторной авторизации
                        }

                        //Смотрим нужно ли разрешение приложению для получения токена
                        GroupCollection g = new Regex("location.href=\"([^\"]+)cancel=").Match(get.html).Groups;
                        if (g[1].Value != "")
                        {
                            //Потверждаем доступ для к аккаунта для приложения
                            VKdata.token = new Regex("access_token=([a-zA-Z0-9]+)&").Match(((GetBrowser)Browser.Get(g[1].Value + "notify=1")).url).Groups[1].Value;
                        }
                        else
                        {
                            //Просто получаем токен если контак не запросил потверждение доступа
                            VKdata.token = new Regex("access_token=([a-zA-Z0-9]+)&").Match(get.url).Groups[1].Value;
                        }


                        //Чистим ресурсы и возвращаем ответ
                        appID = null; Scope = null; login = null; passwd = null; g = null; get = null;
                        return true;
                    }
                    catch
                    {
                        //Авторизация не удалась
                        appID = null; Scope = null; login = null; passwd = null;
                        return false;
                    }
                });
        }
    }
}
