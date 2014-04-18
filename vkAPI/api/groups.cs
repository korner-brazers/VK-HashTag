using vkAPI.Enum;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using vkAPI.InfoClass.groups;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace vkAPI.api
{
    public class groups
    {
        public static Task<Search> Search(string access_token, string q, string fields = "members_count", int country_id = 0, int city_id = 0, byte sort = 0, short count = 1000, short offset = 0, GroupType type = GroupType.all, int future = 0)
        {
            return Task.Run<Search>(() =>
            {
                try
                {
                    //Собираем параметры
                    StringBuilder data = new StringBuilder();
                    data.Append("&sort=" + (sort == 6 ? 0 : sort));
                    data.Append("&offset=" + offset);
                    data.Append("&count=" + count);
                    data.Append("&future=" + future);

                    if (type != GroupType.all)
                        data.Append("&type=" + type.ToString());

                    if (country_id != 0)
                        data.Append("&country_id=" + country_id);

                    if (city_id != 0 && country_id != 0)
                        data.Append("&city_id=" + city_id);

                    if (q != null)
                        data.Append("&q=" + q);

                    if (fields != null)
                        data.Append("&fields=" + fields);

                    if (access_token != null)
                        data.Append("&access_token=" + access_token);
                    else if (VKdata.token != null)
                        data.Append("&access_token=" + VKdata.token);


                    //Получаем json данные
                    string json = Regex.Replace(result.get("groups.search", data.ToString(), true), "^{\"response\":\\[[0-9]+,{\"", "{\"response\":[{\"");

                    //Чистим ресурсы и возвращаем результаты
                    access_token = null; q = null; fields = null; data = null;
                    return JsonConvert.DeserializeObject<Search>(json);
                }
                catch (Newtonsoft.Json.JsonReaderException) { }
                catch { }

                //Ошибка
                access_token = null; q = null; fields = null;
                return new Search();
            });
        }


        public static Task<getById> GetById(string group_ids, string fields = "members_count", bool invert = true)
        {
            return Task.Run<getById>(() =>
            {
                try
                {
                    getById get = new getById();
                    string[] mass = group_ids.Split(',');
                    StringBuilder group_id = new StringBuilder();

                    //Если в списке всего одна группа
                    if (mass.Length <= 1 && group_ids != null)
                        mass = new string[] { group_ids, group_ids };

                    //Собираем список групп
                    for (int i = 0; i < mass.Length; i++)
                    {
                        group_id.Append("," + mass[i]);

                        //Максимальное число групп в одном запросе равно "500", это ограничение API
                        if (i != 0 && (((double)i % 500) == 0 || i == (mass.Length - 1)))
                        {
                            StringBuilder data = new StringBuilder();
                            if (group_ids != null)
                                data.Append("&group_ids=" + group_id.Remove(0, 1));

                            if (fields != null)
                                data.Append("&fields=" + fields);

                            //Получаем json данные и добовляем в список полученный массив
                            string json = result.get("groups.getById", data.ToString(), true);
                            get.response.AddRange(JsonConvert.DeserializeObject<getById>(json).response);

                            //Чистим ресурсы
                            group_id = new StringBuilder(); json = null; data = null;
                        }
                    }

                    //Инвертируем ID групп с положительного числа в отрицательное
                    if (invert)
                    {
                        foreach (var group in get.response)
                        {
                            group.gid = (0 - group.gid);
                        }
                    }

                    //Чистим ресурсы и возвращаем результаты
                    group_ids = null; fields = null; mass = null; group_id = null;
                    return get;
                }
                catch (Newtonsoft.Json.JsonReaderException) { }
                catch { }

                //Ошибка
                group_ids = null; fields = null;
                return new getById();
            });
        }
    }
}
