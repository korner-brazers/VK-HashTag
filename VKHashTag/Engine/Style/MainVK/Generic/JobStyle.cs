using System;
using ZLibNet;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using VKHashTag.Engine.InfoClass.job;
using VKHashTag.Engine.Class.MessageDialog;

namespace VKHashTag.Engine.Style.MainVK.Generic
{
    public partial class JobStyle
    {
        private void RectangleDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            JobDB.Delete(((Rectangle)sender).Tag.ToString());
            sender = null; e = null;
        }


        private async void RectangleEdit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IndexALL indexALL = JobDB.FindIndex(((Rectangle)sender).Tag.ToString());
            if (indexALL.MainIndex != -1 && indexALL.JobIndex != -1)
            {
                switch(indexALL.Type)
                {
                    case EnumType.HashTag:
                        {
                            DateTime time = DateTime.Now;

                            //Загружаем UserControl
                            MainWindow.main.AnimatedTabControlIndex(1);
                            Engine.UserControls.JobADD_HashTag.job.IsSearch = true;
                            Engine.UserControls.JobADD_HashTag.job.EditIndex = indexALL;

                            //Имя задания
                            Engine.UserControls.JobADD_HashTag.job.NameJob = db.job.main[indexALL.MainIndex].Name;

                            //Сколько грабить новостей из каждой группы
                            Engine.UserControls.JobADD_HashTag.job.CheckNewsCount = db.job.HashTag[indexALL.JobIndex].CheckNewsCount;

                            //Достаем список групп
                            StringBuilder group_ids = new StringBuilder();
                            foreach (var v in db.job.HashTag[indexALL.JobIndex].Group)
                            {
                                group_ids.Append("," + v.gid.ToString().Replace("-", ""));
                            }

                            //Загружаем список групп
                            vkAPI.InfoClass.groups.getById get = await vkAPI.api.groups.GetById(group_ids.ToString().Remove(0, 1));

                            //Если быстро все загрузили то просто слегка спим
                            if (Math.Abs((time - DateTime.Now).TotalSeconds) < 1) 
                            { 
                                await Task.Delay((int)Math.Abs((time - DateTime.Now).TotalMilliseconds)); 
                            }

                            //Загружаем список
                            Engine.UserControls.JobADD_HashTag.job.SearchResult = new ObservableCollection<vkAPI.InfoClass.other.Group>(get.response);
                            Engine.UserControls.JobADD_HashTag.job.IsSearch = false;

                            //Чистим ресурсы
                            group_ids = null; get = null;
                            break;
                        }
                }
            }

            sender = null; e = null; indexALL = null;
        }


        private void RectangleReport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IndexALL indexALL = JobDB.FindIndex(((Rectangle)sender).Tag.ToString());
            if (indexALL.JobIndex != -1)
            {
                switch (indexALL.Type)
                {
                    case EnumType.HashTag:
                        {
                            var job = db.job.HashTag[indexALL.JobIndex];
                            if (job.HashTag.Count == 0)
                            {
                                MessageBOX.Show("Нету данных, попробуйте позже..");
                            }
                            else
                            {
                                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                                sfd.Title = "Укажите путь, куда сохранить архив";
                                sfd.FileName = "archive";
                                sfd.DefaultExt = ".zip"; 
                                sfd.Filter = "archive|*.zip";

                                //Сохраняем архив
                                if ((bool)sfd.ShowDialog() == true)
                                {
                                    MessageBOX.Show("Данные успешно сохранены");
                                    Directory.CreateDirectory("tmp");

                                    //Сохраняем теги
                                    File.WriteAllLines(@"tmp\tag.txt", job.HashTag.ToArray());

                                    //Сохраняем список групп
                                    foreach (var g in job.Group.ToArray())
                                    {
                                        File.AppendAllText(@"tmp\group.txt", ("https://vk.com/public" + g.gid.ToString().Replace("-", "") + Environment.NewLine));
                                    }

                                    //Пакуем в архив
                                    Zipper zip = new Zipper();
                                    zip.ZipFile = sfd.FileName;
                                    zip.ItemList.Add(@"tmp\" + "*.*");
                                    zip.Recurse = true;
                                    zip.Comment = "VKHashTag - feedron.ru";
                                    zip.Zip();

                                    //Удаляем темп
                                    Directory.Delete("tmp", true);
                                    zip = null;
                                }
                                sfd = null;
                            }
                            job = null;
                            break;
                        }
                }
            }

            sender = null; e = null; indexALL = null;
        }


        private void RectangleStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IndexALL indexALL = JobDB.FindIndex(((Rectangle)sender).Tag.ToString());
            if (indexALL.MainIndex != -1 && indexALL.JobIndex != -1 && indexALL.JobTaskIndex != -1)
            {
                if (!db.job.main[indexALL.MainIndex].Work)
                {
                    JobDB.StartJob(indexALL); //Запускаем задание
                }
                else
                {
                    db.JobTask[indexALL.JobTaskIndex].cts.Cancel(); //Убиваем задание
                }
            }

            sender = null; e = null; indexALL = null;
        }
    }
}
