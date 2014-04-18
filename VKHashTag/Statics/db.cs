using System.Collections.Generic;

namespace VKHashTag
{
    public partial class db
    {
        public static void Load()
        {
            IsLoad = true;
            conf = Engine.InfoClass.Conf.Load();
            user = Engine.InfoClass.User.Load();
            job = Engine.InfoClass.job.db.Load();
            JobTask = Work.Load();
            VKHashTag.Engine.Class.TaskWork.AutoRun.Start();
            IsLoad = false;
        }

        public static bool IsLoad { get; set; }
        public static Engine.InfoClass.Conf conf = null;
        public static Engine.InfoClass.User user = null;
        public static List<Work> JobTask = null;
        public static Engine.InfoClass.job.db job = new Engine.InfoClass.job.db();
        public static Engine.Class.MessageDialog.WaitProgress wait = new Engine.Class.MessageDialog.WaitProgress();
        public static double ActualMainHeight = 600, ActualMainWidth = 1000;
    }
}
