using System.Collections.Generic;

namespace vkAPI.InfoClass.other
{
    public class Wall
    {
        //https://vk.com/dev/post

        public int id { get; set; }
        public int from_id { get; set; }
        public int to_id { get; set; }
        public int date { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public Attachment attachment { get; set; }
        public List<Attachment> attachments { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
        public int? copy_post_date { get; set; }
        public string copy_post_type { get; set; }
        public int? copy_owner_id { get; set; }
        public int? copy_post_id { get; set; }
        public int? signer_id { get; set; }
        public string copy_text { get; set; }
    }
}
