using System.Collections.Generic;

namespace vkAPI.InfoClass.other
{
    public class Error
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public List<RequestParam> request_params { get; set; }
    }
}
