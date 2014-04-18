using System;
using vkAPI.api;
using System.Threading;
using vkAPI.InfoClass.wall;
using vkAPI.InfoClass.other;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VKHashTag.Engine.Class.TaskWork
{
    class HashTag
    {
        private static Random random = new Random();

        public Task get(Engine.InfoClass.job.Main Main, Engine.InfoClass.job.hashTag Job, CancellationToken Token)
        {
            return new Task(async() =>
            {
                Main.Work = true;
                ulong ProgressValue = 0, Position = 0;
                Main.ProgressBarMaxValue = await GetMaxCount(Main, Job, Token);

                //Начинаем проход по группам
                foreach (var group in Job.Group)
                {
                    //Плюсуем позицию группы
                    Position++;

                    //Экстренное завершение задания
                    if (Token.IsCancellationRequested) { break; }

                    //Если offset 0, то проходим мимо
                    if (group.offset == 0)
                        continue;


                    //Проходим все новости в группе
                    while (group.offset != 0)
                    {
                        //Получаем данные
                        if (Token.IsCancellationRequested) { break; }
                        Get get = await wall.get(group.gid, group.offset);

                        //Достаем все теги и отправляем на обработку
                        if (get.wall != null)
                        {
                            foreach (var news in get.wall)
                            {
                                //Текст со стены
                                AddTag(Job, news.text);

                                //Смотрим есть ли что-то в атачмане
                                if (news.attachments == null)
                                    continue;

                                //Берем данные с фото, видео и аудио
                                foreach (var attachments in news.attachments)
                                {
                                    switch (attachments.type.ToLower().Trim())
                                    {
                                        case "photo": AddTag(Job, ((Photo)attachments.photo).text); break;
                                        case "video": AddTag(Job, ((Video)attachments.video).description); break;
                                        case "audio": AddTag(Job, ((Audio)attachments.audio).title); break;
                                    }
                                }
                            }
                        }

                        //Обновляем данные
                        get = null;
                        group.offset -= 100;
                        group.SearchCountPost += 100;
                        CryptoDB.Write(FileDB.job, db.job);
                        Main.ProgressBarValue = (ProgressValue += 100);
                        Main.InformationJob = string.Format("Группа {0}/{1}, осталось проверить {2} новост{3}", Position, Job.Group.Count, group.offset, FinText.get("ь", "и", "ей", group.offset));
                        await Task.Delay(random.Next(db.conf.SleepMin, db.conf.SleepMax)); //Ожидаем между запросами
                    }

                    //Двигаем ПрогрессБар
                    Main.ProgressBarValue = ++ProgressValue;
                    await Task.Delay(random.Next(db.conf.SleepMin, db.conf.SleepMax)); //Ожидаем между запросами
                }

                //Завершаем задание
                Main.ProgressBarValue = 100;
                Main.LastData = DateTime.Now;
                CryptoDB.Write(FileDB.job, db.job); //Записываем данные в базу
                Main.ProgressBarValue = 0;
                Main.InformationJob = "";
                Main.Work = false; 
                
                //Чистим ресурсы
                Main = null; Job = null;

            }, Token);
        }



        private void AddTag(Engine.InfoClass.job.hashTag job, string tag)
        {
            if (tag == null)
                return;

            List<string> tmp = new List<string> { };
            Match matc = new Regex(@"#[\w0-9_]+").Match(tag);
            while (matc.Success)
            {
                //Если тег не дубликат и в нем больше 2х символов
                if (matc.Value.Length > 3 && !job.HashTag.Exists(x => x.ToLower().Trim() == matc.Value.ToLower().Trim()))
                {
                    tmp.Add(matc.Value);
                }
                matc = matc.NextMatch();
            }

            //Добовляем теги
            if (tmp.Count != 0) { job.HashTag.AddRange(tmp); }

            //Чистим ресурсы
            tag = null; tmp = null; matc = null; job = null;
        }


        private async Task<ulong> GetMaxCount(Engine.InfoClass.job.Main Main, Engine.InfoClass.job.hashTag Job, CancellationToken Token)
        {
            //Наш результат
            ulong res = 0, Position = 0;

            //Начинаем проход по группам
            foreach (var group in Job.Group)
            {
                //Экстренное завершение задания
                if (Token.IsCancellationRequested) { break; }

                //Задаем offset если он пустой
                if (group.offset == 0)
                {
                    Get get = await wall.get(group.gid);
                    long tmpOffset = (get.count - group.SearchCountPost);
                    group.offset = (Job.CheckNewsCount != 0 && Job.CheckNewsCount < tmpOffset ? (Job.CheckNewsCount - group.SearchCountPost) : tmpOffset);
                    await Task.Delay(random.Next(db.conf.SleepMin, db.conf.SleepMax)); //Ожидаем между запросами

                    //Записываем данные в базу если что-то изменилось
                    if (group.offset != 0)
                        CryptoDB.Write(FileDB.job, db.job);

                    get = null;
                }

                //Прибовляем данные к максимальному числу
                if (group.offset != 0)
                    res += (ulong)(group.offset + 1);  //offset + одна группа


                //Считаем в процентах сколько групп мы уже проверили и сколько осталось проверить на offset
                Main.InformationJob = "Анализ групп: " + (int)(((double)Position++ / (double)Job.Group.Count) * 100) + "%";
            }

            Main = null; Job = null;
            return res;
        }
    }
}
