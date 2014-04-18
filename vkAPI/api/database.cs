using vkAPI.Enum;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using vkAPI.InfoClass.database;
using System.Collections.Generic;

namespace vkAPI.api
{
    public class database
    {
        public static Task<getCountries> getCountries(short count = 1000, short offset = 0, byte need_all = 1)
        {
            return Task.Run<getCountries>(() =>
                {
                    try
                    {
                        //Получаем json формат
                        string json = result.get("database.getCountries", "&need_all=" + need_all + "&offset" + offset + "&count=" + (count == 0 ? 1 : count), true);
                        getCountries get = JsonConvert.DeserializeObject<getCountries>(json);

                        //Добовляем нулевое значение
                        get.response.Add(new getCountriesResponse()
                            {
                                cid = 0,
                                title = "Любой"
                            });

                        //Сортировка по cid
                        get.response.Sort((x, y) => x.cid.CompareTo(y.cid));

                        //Создаем обычный список Регионов
                        foreach (getCountriesResponse response in get.response)
                            get.StringMass.Add(response.title.Trim());

                        //Возвращаем результат
                        return get;
                    }
                    catch (Newtonsoft.Json.JsonReaderException) { }
                    catch { }

                    //Ошибка
                    return new getCountries();
                });
        }



        public static Task<getRegions> getRegions(int country_id, string q = null, short count = 1000, short offset = 0)
        {
            return Task.Run<getRegions>(() =>
            {
                try
                {
                    //Собираем параметры
                    StringBuilder data = new StringBuilder();
                    data.Append("&country_id=" + (country_id == 0 ? 1 : country_id));
                    data.Append("&count=" + (count == 0 ? 1 : count));
                    data.Append("&offset=" + offset);
                    if (q != null)
                        data.Append("&q=" + q);


                    //Получаем json данные
                    string json = result.get("database.getRegions", data.ToString(), true);
                    getRegions get = JsonConvert.DeserializeObject<getRegions>(json);

                    //Добовляем нулевое значение
                    get.response.Add(new getRegionsResponse()
                        {
                            region_id = 0,
                            title = "Не выбрана"
                        });

                    //Сортировка по cid
                    get.response.Sort((x, y) => x.region_id.CompareTo(y.region_id)); 

                    //Создаем обычный список Областей
                    foreach (getRegionsResponse response in get.response)
                        get.StringMass.Add(response.title.Trim());

                    //Чистим ресурсы
                    q = null; data = null; json = null;
                    return get;
                }
                catch (Newtonsoft.Json.JsonReaderException) { }
                catch { }

                //Ошибка
                q = null; return new getRegions();
            });
        }



        public static Task<getCities> getCities(int country_id, string q = null, short count = 1000, short offset = 0, short need_all = 1, short region_id = 0)
        {
            return Task.Run<getCities>(() =>
            {
                try
                {
                    //Собираем параметры
                    StringBuilder data = new StringBuilder();
                    data.Append("&country_id=" + (country_id == 0 ? 1 : country_id));
                    data.Append("&count=" + (count == 0 ? 1 : count));
                    data.Append("&offset=" + offset);
                    data.Append("&need_all=" + need_all);
                    data.Append("&region_id=" + region_id);
                    if (q != null)
                        data.Append("&q=" + q);


                    //Получаем json данные
                    string json = result.get("database.getCities", data.ToString(), true);
                    getCities get = JsonConvert.DeserializeObject<getCities>(json);

                    //Добовляем нулевое значение
                    get.response.Add(new getCitiesResponse()
                        {
                            cid = 0,
                            title = "Не выбран"
                        });

                    //Сортировка по cid
                    get.response.Sort((x, y) => x.cid.CompareTo(y.cid));

                    //Создаем обычный список Городов
                    foreach (getCitiesResponse response in get.response)
                        get.StringMass.Add(response.title.Trim());

                    //Чистим ресурсы
                    q = null; data = null; json = null;
                    return get;
                }
                catch (Newtonsoft.Json.JsonReaderException) { }
                catch { }

                //Ошибка
                q = null; return new getCities();
            });
        }
    }
}
