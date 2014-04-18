using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace vkAPI
{
    public class Browser : VKdata
    {
        public static string post(string url, string data, string Referer = "", bool SaveCookie = false)
        {
            try
            {
                //Типа разделитель и данные для работы 
                string captcha = ""; int attempt = 0;
                Refresh: string captcha_img = null;
                HttpWebRequest request = null;
                Stream stream = null, StreamHTML = null;
                StreamReader Reader = null;
                WebResponse response = null;
                string result = null;

                try
                {
                    //Создаем подключение с URL для загрузки картинок
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.CookieContainer = VKdata.Cookie == null ? (new CookieContainer()) : VKdata.Cookie;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Referer = Referer;
                    request.Method = "POST";
                    request.KeepAlive = true;
                    request.MaximumAutomaticRedirections = 3;
                    request.ReadWriteTimeout = 1000 * 30;
                    request.Timeout = 1000 * 30;

                    //параметры
                    byte[] info = Encoding.UTF8.GetBytes(data + captcha);

                    //Записываем в поток все данные
                    if (info != null)
                    {
                        //Записываем данные
                        stream = request.GetRequestStream();
                        stream.Write(info, 0, info.Length);
                        info = null;


                        //Возвращаем данные и записываем куки
                        response = request.GetResponse();
                        if (SaveCookie)
                            VKdata.Cookie = request.CookieContainer;
                        StreamHTML = response.GetResponseStream();
                        Reader = new StreamReader(StreamHTML);
                        result = Reader.ReadToEnd();
                        captcha_img = new Regex("captcha_img\":\"([^\"]+)\"").Match(result.Replace(" ", "").Replace(@"\", "").ToLower().Trim()).Groups[1].Value;
                    }
                }
                catch (Exception e)
                {
                    result = e.ToString();
                }
                finally
                {
                    //Чистим ресурсы
                    if (Reader != null)
                    {
                        Reader.Close(); Reader.Dispose(); Reader = null;
                    }
                    if (StreamHTML != null)
                    {
                        StreamHTML.Close(); StreamHTML.Dispose(); StreamHTML = null;
                    }
                    if (response != null)
                    {
                        response.Close(); response.Dispose(); response = null;
                    }
                    if (stream != null)
                    {
                        stream.Close(); stream.Dispose(); stream = null;
                    }
                    if (request != null)
                    {
                        request.Abort(); request = null;
                    }
                }

                //Капча
                if (captcha_img != null && captcha_img.Replace(" ", "").Trim() != "" && attempt < 3 && VKdata.KeyAntigate != null)
                {
                    attempt++;
                    captcha = new Antigate().get(captcha_img);
                    captcha_img = null;
                    goto Refresh;
                }

                //Возвращаем результат 
                url = null; data = null; captcha = null; captcha_img = null;
                return result.Trim();
            }
            catch (Exception e)
            {
                url = null; data = null;
                return e.ToString();
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                Обычные get запросы с куками контакта                               #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static GetBrowser Get(string url, bool Replase = false, CookieContainer Cookie = null)
        {
            HttpWebRequest request = null;
            WebResponse Response = null;
            Stream Stream = null;
            StreamReader Reader = null;
            GetBrowser result = new GetBrowser();

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Safari/5.05 (Windows; U; Windows NT 6.0; ru; rv:1.9.2.13) Net/02022012 Safari/5.05.112";
                request.CookieContainer = Cookie == null ? (VKdata.Cookie == null ? (new CookieContainer()) : VKdata.Cookie) : Cookie;
                request.KeepAlive = true;
                request.MaximumAutomaticRedirections = 3;
                request.ReadWriteTimeout = 1000 * 30;
                request.Timeout = 1000 * 30;

                //Получаем HTML страницу
                Response = request.GetResponse();
                result.url = Response.ResponseUri.AbsoluteUri;
                Stream = Response.GetResponseStream();
                Reader = new StreamReader(Stream, Encoding.Default);

                //Записываем рузультат
                if (Replase)
                    result.html = Reader.ReadToEnd().Replace("\n", "").Replace("\r", "").Replace(" ", "").Trim();
                else
                    result.html = Reader.ReadToEnd();

            }
            catch (Exception e)
            {
                result.html = e.ToString();
                e = null;
            }
            finally
            {
                //Чистим ресурсы
                url = null;
                if (Reader != null)
                {
                    Reader.Close(); Reader.Dispose(); Reader = null;
                }
                if (Stream != null)
                {
                    Stream.Close(); Stream.Dispose(); Stream = null;
                }
                if (Response != null)
                {
                    Response.Close(); Response.Dispose(); Response = null;
                }
                if (request != null)
                {
                    request.Abort(); request = null;
                }
            }

            //Возвращаем результат
            return result;
        }
    }

    public class GetBrowser
    {
        public string url { get; internal set; }
        public string html { get; internal set; }
    }
}
