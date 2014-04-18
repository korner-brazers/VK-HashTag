using System.Collections.Generic;

namespace vkAPI.InfoClass.database
{
    public class getCountries
    {
        //https://vk.com/dev/database.getCountries

        public getCountries()
        {
            StringMass = new List<string> { };
        }

        public List<string> StringMass { get; set; }  //Массив "title"
        public List<getCountriesResponse> response { get; set; }  //Результат vk.com
    }

    public class getCountriesResponse
    {
        public int cid { get; set; }
        public string title { get; set; }
    }
}
