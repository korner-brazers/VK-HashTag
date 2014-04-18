using System.Collections.Generic;

namespace vkAPI.InfoClass.database
{
    public class getRegions
    {
        //https://vk.com/dev/database.getRegions

        public getRegions()
        {
            StringMass = new List<string> { };
        }

        public List<string> StringMass = new List<string> { }; //Массив "title"
        public List<getRegionsResponse> response { get; set; } //Результат vk.com
    }

    public class getRegionsResponse
    {
        public int region_id { get; set; }
        public string title { get; set; }
    }
}
