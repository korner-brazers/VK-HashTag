using vkAPI.InfoClass.other;
using System.Collections.Generic;

namespace vkAPI.InfoClass.wall
{
    public class Get
    {
        public long count { get; set; }
        public List<Wall> wall { get; set; }
        public List<Profile> profiles { get; set; }
        public List<Group> groups { get; set; }
    }
}
