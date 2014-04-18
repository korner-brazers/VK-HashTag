using System;
using System.Threading.Tasks;

namespace VKHashTag.Engine.Class.TaskWork
{
    class AutoRun
    {
        private static Random random = new Random();

        public async static void Start()
        {
            while (true)
            {
                //Если заадний нету то просто ждем
                if (db.JobTask.Count == 0)
                {
                    await Task.Delay(1000 * 60);
                    continue;
                }

                //Запускаем заадние
                foreach (var job in db.JobTask.ToArray())
                {
                    //Ждем перед запуском каждого задания
                    await Task.Delay(1000 * 60 * random.Next(1, 3));
                    await Task.Run(() =>
                        {
                            //Получаем индекс задания и проверяем его статус
                            IndexALL indexALL = JobDB.FindIndex(job.id);
                            if (indexALL.JobIndex != -1 && indexALL.JobTaskIndex != -1 && indexALL.MainIndex != -1)
                            {
                                //распаковываем ссылку
                                var Main = db.job.main[indexALL.MainIndex];

                                //Проверяем его интервал проверку
                                if (Main.Activ && !Main.Work && ((int)Math.Abs((Main.LastData - DateTime.Now).TotalMinutes) >= db.user.Interval))
                                {
                                    JobDB.StartJob(indexALL); //Запускаем задание
                                }
                                Main = null; indexALL = null;
                            }
                        });
                }
            }
        }
    }
}
