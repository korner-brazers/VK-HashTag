namespace vkAPI.InfoClass.other
{
    public class Audio
    {
        //https://vk.com/dev/audio_object

        public int aid { get; set; }
        public int owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string url { get; set; }
        public string performer { get; set; }
        public int? genre { get; set; }
        public string lyrics_id { get; set; }
    }
}
