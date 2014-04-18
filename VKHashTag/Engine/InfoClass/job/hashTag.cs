using System.Collections.Generic;

namespace VKHashTag.Engine.InfoClass.job
{
    public class hashTag
    {
        public hashTag() 
        {
            Group = new List<GroupInfo> { };
            HashTag = new List<string> { };
        }

        public class GroupInfo
        {
            public int gid { get; set; } //ID группы
            private long _offset { get; set; } //Ставить максимум и отнимать по -100 пока значение не будет 0
            public long SearchCountPost { get; set; } //Всегда +1 и потом когда в offset будет идти новое значение, то просто отнимать это от offset

            public long offset
            {
                get { return (_offset < 0 ? 0 : _offset); }
                set
                {
                    _offset = value;
                }
            }
        }



        public int id { get; set; }
        public long CheckNewsCount { get; set; }
        public List<GroupInfo> Group { get; set; }
        public List<string> HashTag { get; set; }
    }
}
