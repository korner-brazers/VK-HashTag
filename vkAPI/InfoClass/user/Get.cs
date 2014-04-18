using vkAPI.InfoClass.other;
using System.Collections.Generic;

namespace vkAPI.InfoClass.user
{
    public class Get
    {
        //https://vk.com/dev/fields

        public int uid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int sex { get; set; }
        public string domain { get; set; }
        public int city { get; set; }
        public int country { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_max { get; set; }
        public string photo_200_orig { get; set; }
        public string photo_max_orig { get; set; }
        public int has_mobile { get; set; }
        public int online { get; set; }
        public int can_post { get; set; }
        public int can_see_all_posts { get; set; }
        public int can_see_audio { get; set; }
        public int can_write_private_message { get; set; }
        public string mobile_phone { get; set; }
        public string home_phone { get; set; }
        public string site { get; set; }
        public string status { get; set; }
        public LastSeen last_seen { get; set; }
        public int common_count { get; set; }
        public Counters counters { get; set; }
        public int university { get; set; }
        public string university_name { get; set; }
        public int faculty { get; set; }
        public string faculty_name { get; set; }
        public int graduation { get; set; }
        public int relation { get; set; }
        public List<University> universities { get; set; }
        public List<School> schools { get; set; }
        public List<object> relatives { get; set; }
        public Error error { get; set; }
    }
}
