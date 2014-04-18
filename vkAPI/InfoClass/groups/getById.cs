using vkAPI.InfoClass.other;
using System.Collections.Generic;

namespace vkAPI.InfoClass.groups
{
    public class getById
    {
        //https://vk.com/dev/groups.getById

        public getById()
        {
            response = new List<Group> { };
        }

        public List<Group> response { get; set; }  //Результат vk.com
    }
}
