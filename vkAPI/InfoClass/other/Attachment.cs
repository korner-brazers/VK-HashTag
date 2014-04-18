namespace vkAPI.InfoClass.other
{
    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
        public Link link { get; set; }
        public Doc doc { get; set; }
        public Video video { get; set; }
        public Audio audio { get; set; }
        public Poll poll { get; set; }
    }
}
