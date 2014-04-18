using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using VKHashTag.Engine.Class.MessageDialog;

namespace VKHashTag
{
    class JobDB
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                   Удаление из баззы данных нужное задние со всеми его зависимостями                #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Delete(object ID)
        {
            int id = GetNumber(ID); //Получаем ID базы данных
            if (id != -1)
            {
                //Находим индеск ячейки в MAIN
                int index = new List<Engine.InfoClass.job.Main>(db.job.main).FindIndex(item => (item.id == id));

                //Определяем тип задания и удаляем все зависимости
                switch (db.job.main[index].Type)
                {
                    case Engine.InfoClass.job.EnumType.HashTag:
                        {
                            //Находим индекс HashTag задания
                            int TagIndex = new List<Engine.InfoClass.job.hashTag>(db.job.HashTag).FindIndex(item => (item.id == id));
                            if (TagIndex != -1) { db.job.HashTag.RemoveAt(TagIndex); }
                            break;
                        }
                }

                //Удаляем данные MAIN и сохраняем базу
                db.job.main.RemoveAt(index);
                CryptoDB.Write(FileDB.job, db.job);
            }
            else
            {
                MessageBOX.Show("Не удалось найти и удалить ячейку в JobDB");
            }

            //Чистим ресурсы
            ID = null;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                           Поиск заданий по ID номеру со всеми его зависимостями                    #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IndexALL FindIndex(object ID)
        {
            try
            {
                int id = GetNumber(ID); //Получаем ID базы данных
                if (id != -1)
                {
                    IndexALL all = new IndexALL();

                    //Находим индеск ячейки в MAIN и Task задания
                    all.MainIndex = new List<Engine.InfoClass.job.Main>(db.job.main).FindIndex(item => (item.id == id));
                    all.JobTaskIndex = db.JobTask.FindIndex(item => (item.id == id));

                    //Определяем тип задания и удаляем все зависимости
                    all.Type = db.job.main[all.MainIndex].Type;

                    //Находим индекс задания
                    switch (all.Type)
                    {
                        case Engine.InfoClass.job.EnumType.HashTag:
                            {
                                //Находим индекс HashTag задания
                                all.JobIndex = new List<Engine.InfoClass.job.hashTag>(db.job.HashTag).FindIndex(item => (item.id == id));
                                break;
                            }
                    }

                    //Возвращаем результат
                    ID = null; return all;
                }
            }
            catch (Exception e) { MessageBOX.Show(e.Message.ToString(), e.StackTrace.ToString()); }

            //Чистим ресурсы и возвращаем результаты
            ID = null; return new IndexALL();
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                       Запуск задания по ID                                         #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void StartJob(IndexALL indexALL)
        {
            var work = db.JobTask[indexALL.JobTaskIndex];
            if (work.job.IsCompleted || work.job.IsCanceled || work.job.IsFaulted)
            {
                //Удаляем старое задание
                db.JobTask.Remove(work);

                //Добовляем новое задание
                CancellationTokenSource _cts = new CancellationTokenSource();
                db.JobTask.Add(new Work()
                {
                    id = db.job.main[indexALL.MainIndex].id,
                    cts = _cts,
                    job = new Engine.Class.TaskWork.HashTag().get(db.job.main[indexALL.MainIndex], db.job.HashTag[indexALL.JobIndex], _cts.Token)
                });

                _cts = null; 
                db.JobTask[db.JobTask.Count - 1].job.Start();
            }
            else
            {
                work.job.Start();
            }
            work = null; indexALL = null;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                           Остальной мусор                                          #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static int GetNumber(object ob)
        {
            switch (ob.GetType().ToString().ToLower().Trim())
            {
                case "system.int64": return (int)((long)ob);
                case "system.uint64": return (int)((ulong)ob);
                case "system.int32": return ((int)ob);
                case "system.int16": return ((short)ob);
                case "system.double": return (int)((double)ob);
                case "system.byte": return ((byte)ob);
                case "system.string": return int.Parse(((string)ob));
            }

            ob = null; return -1;
        }
    }


    public class IndexALL
    {
        public IndexALL()
        {
            MainIndex = JobIndex = JobTaskIndex = - 1;
        }

        public int MainIndex { get; set; }
        public int JobIndex { get; set; }
        public int JobTaskIndex { get; set; }
        public Engine.InfoClass.job.EnumType Type { get; set; }
    }


    public class Work
    {
        public static List<Work> Load()
        {
            List<Work> result = new List<Work> { };

            foreach(var main in db.job.main)
            {
                //Находим индекс задания
                switch (main.Type)
                {
                    case Engine.InfoClass.job.EnumType.HashTag:
                        {
                            //Находим индекс HashTag задания
                            int JobIndex = new List<Engine.InfoClass.job.hashTag>(db.job.HashTag).FindIndex(item => (item.id == main.id));
                            if (JobIndex != -1)
                            {
                                CancellationTokenSource _cts = new CancellationTokenSource();
                                result.Add(new Work()
                                    {
                                        id = main.id,
                                        cts = _cts,
                                        job = new Engine.Class.TaskWork.HashTag().get(main, db.job.HashTag[JobIndex], _cts.Token)
                                    });
                                _cts = null;
                            }
                            break;
                        }
                }
            }

            return result;
        }

        public int id { get; set; }
        public CancellationTokenSource cts { get; set; }
        public Task job { get; set; }
    }
}
