using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace VKHashTag.Engine.InfoClass.job
{
    public class db
    {
        public db()
        {
            main = new ObservableCollection<Main> { };
            HashTag = new ObservableCollection<hashTag> { };
        }

        public static db Load()
        {
            db result = CryptoDB.Read<db>(FileDB.job);
            if (result == null) { result = new db(); }

            return result;
        }


        ////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<Main> main { get; set; }
        public ObservableCollection<hashTag> HashTag { get; set; }

        private int _LastIndexID { get; set; }
        public int LastIndexID 
        {
            get { return _LastIndexID; }
            set
            {
                if (value > _LastIndexID)
                    _LastIndexID = value;
            }
        }
    }
}
