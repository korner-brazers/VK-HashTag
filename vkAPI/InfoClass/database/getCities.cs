using System.Collections.Generic;

namespace vkAPI.InfoClass.database
{
    public class getCities
    {
        //https://vk.com/dev/database.getCities

        public getCities()
        {
            StringMass = new List<string> { };
        }

        public List<string> StringMass { get; set; }  //Массив "title"
        public List<getCitiesResponse> response { get; set; }  //Результат vk.com
    }

    public class getCitiesResponse
    {
        public int cid { get; set; }
        public string title { get; set; }
    }
}
