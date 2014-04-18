using vkAPI.Enum;
using System.Text;
using Newtonsoft.Json;
using vkAPI.InfoClass.wall;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace vkAPI.api
{
    public class wall
    {
        public static Task<Get> get(int owner_id, long offset = 0, byte count = 100, Filter filter = Filter.owner)
        {
            return Task.Run<Get>(() =>
            {
                try
                {
                    //Собираем параметры
                    StringBuilder data = new StringBuilder();
                    data.Append("&owner_id=" + owner_id);
                    data.Append("&offset=" + offset);
                    data.Append("&filter=" + filter.ToString());
                    data.Append("&extended=1");

                    if (count > 0 && count <= 100)
                        data.Append("&count=" + count);


                    //Получаем и возвращаем результаты
                    string json = Regex.Replace(result.get("wall.get", data.ToString(), true), "^{\"response\":{\"wall\":\\[([0-9]+),{\"(.*)}$", "{\"count\":$1,\"wall\":[{\"$2");
                    return JsonConvert.DeserializeObject<Get>(json);
                }
                catch (Newtonsoft.Json.JsonReaderException) { }
                catch { }

                //Ошибка
                return new Get();
            });
        }
    }
}
