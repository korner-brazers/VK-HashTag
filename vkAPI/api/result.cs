using System.Text.RegularExpressions;

namespace vkAPI.api
{
    public class result
    {
        public static string get(string method, string argument, bool ResponseList = false)
        {
            string tmp = Browser.post("https://api.vk.com/method/" + method.Trim(), argument.Replace(" ", "").Trim()).Trim();
            string response = new Regex("^{\"response\":\\[(.+)\\]}$").Match(tmp).Groups[1].Value;

            //На случай ошибки, мы вернем данные об ошибке вместо нужных параметров
            if (response.Trim() != "")
                return (ResponseList ? tmp : response);
            else
                return tmp;
        }
    }
}
