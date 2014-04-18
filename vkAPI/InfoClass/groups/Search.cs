using vkAPI.InfoClass.other;
using System.Collections.Generic;

namespace vkAPI.InfoClass.groups
{
    public class Search
    {
        //https://vk.com/dev/groups.search

        public Search()
        {
            response = new List<Group> { };
        }

        public List<Group> response { get; set; }  //Результат vk.com
    }
}
