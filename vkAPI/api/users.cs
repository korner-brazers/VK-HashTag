using vkAPI.Enum;
using System.Text;
using Newtonsoft.Json;
using vkAPI.InfoClass.user;
using System.Threading.Tasks;

namespace vkAPI.api
{
    public class users
    {
        public static Task<Get> get(string user_ids, string access_token = null, string fields = null, Name_case name_case = Name_case.nom)
        {
            return Task.Run<Get>(() =>
                {
                    try
                    {
                        //Собираем параметры
                        StringBuilder data = new StringBuilder();
                        if (user_ids != null)
                            data.Append("&user_ids=" + user_ids.Trim());

                        if (access_token == null && VKdata.token != null)
                            data.Append("&access_token=" + VKdata.token.Trim());
                        else if (access_token != null)
                            data.Append("&access_token=" + access_token.Trim());

                        if (fields != null)
                            data.Append("&fields=" + fields.Trim());

                        if (name_case != Name_case.nom)
                            data.Append("&name_case=" + name_case.ToString().Trim());

                        //Чистим ресурсы и возврвшаем результат
                        user_ids = null; access_token = null; fields = null;
                        return JsonConvert.DeserializeObject<Get>(result.get("users.get", data.ToString()));
                    }
                    catch (Newtonsoft.Json.JsonReaderException) { }
                    catch { }

                    //Ошибка
                    user_ids = null; access_token = null; fields = null;
                    return new Get();
                });
        }
    }
}
