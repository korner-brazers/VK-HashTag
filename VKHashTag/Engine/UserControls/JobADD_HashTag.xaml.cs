using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using VKHashTag.Engine.Class.MessageDialog;


namespace VKHashTag.Engine.UserControls
{
    public partial class JobADD_HashTag : UserControl
    {
        public static JobDB job = new JobDB();
 
        public JobADD_HashTag()
        {
            InitializeComponent();
            DataContext = job;
            StartAPP();
        }

        private async void StartAPP()
        {
            job.Countries = await vkAPI.api.database.getCountries();
        }

        private void Clear()
        {
            job.StopWord.Clear(); job.StopWord = null;
            job.LastSearchResult = null;
            job.SearchResult = null;
            job.SearchWord = "";
            job.NameJob = "";
            job.EditIndex = new IndexALL();
            LabelSelectedALL.Content = "Выделить все";
            LB_Select = false;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                       Минимальный размер окна                                      #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool activ = false;
        private async void UserControl_ActualSize(object sender, DependencyPropertyChangedEventArgs e)
        {
            await System.Threading.Tasks.Task.Delay(50);
            if (activ = !activ)
            {
                MainWindow.main.MinHeight = 690;
                MainWindow.main.MinWidth = 1070;
            }
            else
            {
                MainWindow.main.MinHeight = db.ActualMainHeight;
                MainWindow.main.MinWidth = db.ActualMainWidth;

                //Изменение основного окна если его размер был выставлен вручную отсюда
                if (MainWindow.main.ActualHeight == 690 && MainWindow.main.ActualWidth == 1070)
                {
                    MainWindow.main.Height = db.ActualMainHeight;
                    MainWindow.main.Width = db.ActualMainWidth;
                }
            }
            sender = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                    Сохранение и отмена задания                                     #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CancelJob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sender = null; e = null;
            Clear();
            MainWindow.main.AnimatedTabControlIndex(0);
        }


        private void SaveJob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Достаем список групп
            List<Engine.InfoClass.job.hashTag.GroupInfo> _group = new List<Engine.InfoClass.job.hashTag.GroupInfo> { };
            foreach (var v in LB_Job.SelectedItems)
            {
                _group.Add(new Engine.InfoClass.job.hashTag.GroupInfo()
                    {
                        gid = (v as vkAPI.InfoClass.other.Group).gid
                    });
            }

            //Смотрим есть ли днные в задание
            if (_group.Count != 0)
            {
                if (job.EditIndex.MainIndex != -1 && job.EditIndex.JobIndex != -1)
                {
                    //Редактируем заадние
                    db.job.main[job.EditIndex.MainIndex].Name = job.NameJob;
                    db.job.HashTag[job.EditIndex.JobIndex].CheckNewsCount = job.CheckNewsCount;
                    db.job.HashTag[job.EditIndex.JobIndex].Group = _group;

                    job.EditIndex.JobIndex = -1; 
                    job.EditIndex.MainIndex = -1;
                }
                else
                {
                    //Добовляем в задание для main
                    VKHashTag.db.job.main.Add(new Engine.InfoClass.job.Main()
                    {
                        Activ = true,
                        Name = job.NameJob,
                        id = ++db.job.LastIndexID,
                        Reply = true,
                        Type = InfoClass.job.EnumType.HashTag
                    });

                    //Добовляем в задание тегов
                    VKHashTag.db.job.HashTag.Add(new Engine.InfoClass.job.hashTag()
                    {
                        CheckNewsCount = job.CheckNewsCount,
                        id = db.job.LastIndexID,
                        Group = _group
                    });
                    _group = null;

                    //Добовляем новое задание в List Task
                    CancellationTokenSource _cts = new CancellationTokenSource();
                    db.JobTask.Add(new Work()
                    {
                        id = db.job.main[db.job.main.Count - 1].id,
                        cts = _cts,
                        job = new Engine.Class.TaskWork.HashTag().get(db.job.main[db.job.main.Count - 1], db.job.HashTag[db.job.HashTag.Count - 1], _cts.Token)
                    });
                    _cts = null;
                }

                //Записываем в базу и выводим главное окно
                CryptoDB.Write(FileDB.job, VKHashTag.db.job); 
                Clear();
                MainWindow.main.AnimatedTabControlIndex(0);
            }
            else
            {
                MessageBOX.Show("Нету выделенных групп для добавления в список граббинга..");
            }

            //Чистим ресурсы
            sender = null; e = null; _group = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                   Загрузка своего списка групп                                     #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async void LoadListGroup_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Выберите файл";
            op.Filter = "TXT|*.txt;";

            if ((bool)op.ShowDialog() == true)
            {
                //Собираем список групп пользователя
                job.IsSearch = true;
                StringBuilder group_ids = new StringBuilder();
                foreach (string s in File.ReadAllLines(op.FileName))
                {
                    group_ids.Append("," + Regex.Replace(s.Replace("-", ""), "https?://vk.com/(public)?(group)?(event)?", ""));
                }

                //Загружаем данные по списку групп
                if (group_ids.Length != 0)
                {
                    vkAPI.InfoClass.groups.getById get = await vkAPI.api.groups.GetById(group_ids.ToString().Remove(0, 1));
                    job.SearchResult = new ObservableCollection<vkAPI.InfoClass.other.Group>(get.response);
                    get = null;
                }
                group_ids = null; job.IsSearch = false;
            }
            op = null; sender = null; e = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                        Выбор региона, загрузка области для региона и выбор задания                 #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async void CB_CountriesID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sender = null; e = null;
            if (job.CountriesIndexID != 0)
            {
                job.Cities.StringMass = new List<string> { "Загрузка.." };
                job.CitiesIndexID = 0;
                job.Cities = await vkAPI.api.database.getCities(job.CountriesIndexID, null, 1000, 0, 0);
                job.CitiesIndexID = 0;
            }
        }

        private void CB_TypeCommunity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (sender as ComboBox);
            if (cb != null && MainWindow.main != null && cb.SelectedIndex != 0)
            {
                MainWindow.main.AnimatedTabControlIndex(cb.SelectedIndex + 1);
            }

            sender = null; e = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                  Поиск, очистка и выделение всех заданий                           #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async void LB_Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sender = null; e = null; job.IsSearch = true;
            job.LastSearchResult = new ObservableCollection<vkAPI.InfoClass.other.Group>(job.SearchResult.ToList());
            vkAPI.InfoClass.groups.Search Search = new vkAPI.InfoClass.groups.Search();

            //Выбираем тип групп для поиска
            vkAPI.Enum.GroupType type = vkAPI.Enum.GroupType.all;
            switch (job.TypeCommunity)
            {
                case 1: type = vkAPI.Enum.GroupType.group; break;
                case 2: type = vkAPI.Enum.GroupType.page; break;
                case 3: type = vkAPI.Enum.GroupType.events; break;
            }

            //Получаем результаты
            vkAPI.InfoClass.groups.Search SearchTMP = await vkAPI.api.groups.Search(
                                                            db.user.token, 
                                                            job.SearchWord,
                                                            "members_count",
                                                            job.Countries.response[job.CountriesIndexID].cid,
                                                            ((job.Cities == null || job.Cities.response == null) ? 0 : job.Cities.response[job.CitiesIndexID].cid),
                                                            job.GroupSort,
                                                            job.GroupCount, 0, type);

            //Добовляем в список еще данные
            Search.response.AddRange(job.SearchResult.ToList());
            Search.response.AddRange(SearchTMP.response);
            SearchTMP = null;


            //Сортируем данные и убираем все лишнее
            if (Search.response.Count != 0)
            {
                List<vkAPI.InfoClass.other.Group> SearchTmp = (Search.response.GroupBy(cust => cust.gid).Select(grp => grp.First())).ToList(); //Удаление дубликатов

                //Удаляем все закрытые группы и все темы с стоп словами + все группы у которых участников меньше чем у меня в программе
                Search.response = SearchTmp.FindAll(item => (item.is_closed == 0)).FindAll(item => !FindTextStopWord(item.name)).FindAll(item => (item.members_count > job.MinSubscribers)); 
                if (job.GroupSort == 6) { Search.response.Sort((x, y) => y.members_count.CompareTo(x.members_count)); }    //Сортировка по количиству подписчиков
                SearchTmp = null;
            }


            //Обновляем список
            job.SearchResult = new ObservableCollection<vkAPI.InfoClass.other.Group>(Search.response);
            job.IsSearch = false;
        }


        private void LB_Clear_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sender = null; e = null; job.SearchResult = null; job.LastSearchResult = null;
            LabelSelectedALL.Content = "Выделить все";
            LB_Select = false;
        }


        bool LB_Select = false;
        private void LB_SelectedALL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LB_Job != null && LB_Job.Items.Count != 0)
            {
                if (LB_Select)
                {
                    LabelSelectedALL.Content = "Выделить все";
                    LB_Job.UnselectAll();
                    LB_Select = !LB_Select;
                }
                else
                {
                    LabelSelectedALL.Content = "Снять выделенное";
                    LB_Job.SelectAll();
                    LB_Select = !LB_Select;
                }
            }

            sender = null; e = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                       Функция для проверки стоп ключей + сама загрузка стоп ключей                 #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LoadStopWord_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Выберите файл";
            op.Filter = "TXT|*.txt;";

            if ((bool)op.ShowDialog() == true)
            {
                job.StopWord = new ObservableCollection<string> { };
                foreach (string s in File.ReadAllLines(op.FileName))
                {
                    job.StopWord.Add(s.ToLower().Replace(" ", "").Trim());
                }
            }
            op = null; sender = null; e = null;
        }

        private void RectangleDeleteStopWord_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sender = null; e = null; job.StopWord.Clear(); job.StopWord = null;
        }

        private bool FindTextStopWord(string text)
        {
            foreach (string s in job.StopWord)
            {
                if (Regex.IsMatch(text.ToLower().Replace(" ", "").Trim(), s))
                {
                    text = null;
                    return true;
                }
            }

            text = null;
            return false;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                  Возврат преведущих результатов поиска                             #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RectangleSearchBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sender = null; e = null;
            job.SearchResult = new ObservableCollection<vkAPI.InfoClass.other.Group>(job.LastSearchResult.ToList());
            job.LastSearchResult = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                   Временная база для билдинга и т.д                                #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public class JobDB : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            ////////////////////////////////////////////////////////////////////////////////

            public JobDB()
            {
                GroupSort = 6;
                GroupCount = 1000;
                MinSubscribers = 2000;
                EditIndex = new IndexALL();
                Cities = new vkAPI.InfoClass.database.getCities();
                NameJob = "Задание " + VKHashTag.db.job.LastIndexID;
                SearchResult = new ObservableCollection<vkAPI.InfoClass.other.Group> { };
                LastSearchResult = new ObservableCollection<vkAPI.InfoClass.other.Group> { };
            }


            private bool _IsSearch { get; set; }
            private IndexALL _EditIndex { get; set; }
            private string _NameJob { get; set; }
            private string _SearchWord { get; set; }
            private long _CheckNewsCount { get; set; }
            private ObservableCollection<string> _StopWord { get; set; }

            private int _CitiesIndexID { get; set; }
            private int _CountriesIndexID { get; set; }
            private vkAPI.InfoClass.database.getCities _Cities { get; set; }
            private vkAPI.InfoClass.database.getCountries _Countries { get; set; }
            private ObservableCollection<vkAPI.InfoClass.other.Group> _SearchResult { get; set; }
            private ObservableCollection<vkAPI.InfoClass.other.Group> _LastSearchResult { get; set; }

            public byte GroupSort { get; set; }
            public short GroupCount { get; set; }
            public byte TypeCommunity { get; set; }
            public int MinSubscribers { get; set; }


            public bool IsSearch
            {
                get { return _IsSearch; }
                set
                {
                    _IsSearch = value;
                    NotifyPropertyChanged();
                }
            }


            public IndexALL EditIndex
            {
                get { return _EditIndex; }
                set
                {
                    _EditIndex = value;
                    NotifyPropertyChanged();
                }
            }
            

            public string NameJob
            {
                get { return _NameJob; }
                set
                {
                    string res = Regex.Replace(Regex.Replace(value, @"[^0-9\w ]", ""), @"  +", "  ");
                    if (res.Trim() == "")
                        _NameJob = "Задание " + VKHashTag.db.job.LastIndexID;
                    else
                        _NameJob = res;

                    res = null;
                    NotifyPropertyChanged();
                }
            }


            public string SearchWord
            {
                get { return _SearchWord; }
                set
                {
                    _SearchWord = Regex.Replace(Regex.Replace(value, @"[^0-9\w,\.-_ ]", ""), @"  +", "  ");
                    NotifyPropertyChanged();
                }
            }


            public long CheckNewsCount
            {
                get { return _CheckNewsCount; }
                set
                {
                    _CheckNewsCount = value;
                    NotifyPropertyChanged();
                }
            }


            public ObservableCollection<string> StopWord
            {
                get { return (_StopWord == null ? (new ObservableCollection<string> { }) : _StopWord); }
                set
                {
                    _StopWord = value;
                    NotifyPropertyChanged();
                }
            }


            public vkAPI.InfoClass.database.getCountries Countries
            {
                get { return _Countries; }
                set
                {
                    _Countries = value;
                    NotifyPropertyChanged();
                }
            }

            public int CountriesIndexID
            {
                get { return _CountriesIndexID; }
                set
                {
                    _CountriesIndexID = value;
                    NotifyPropertyChanged();
                }
            }

            public vkAPI.InfoClass.database.getCities Cities
            {
                get { return _Cities; }
                set
                {
                    _Cities = value;
                    NotifyPropertyChanged();
                }
            }

            public int CitiesIndexID
            {
                get { return _CitiesIndexID; }
                set
                {
                    _CitiesIndexID = value;
                    NotifyPropertyChanged();
                }
            }


            public ObservableCollection<vkAPI.InfoClass.other.Group> SearchResult
            {
                get { return _SearchResult; }
                set
                {
                    _SearchResult = (value == null ? (new ObservableCollection<vkAPI.InfoClass.other.Group> { }) : value);
                    NotifyPropertyChanged();
                }
            }

            public ObservableCollection<vkAPI.InfoClass.other.Group> LastSearchResult
            {
                get { return _LastSearchResult; }
                set
                {
                    _LastSearchResult = (value == null ? (new ObservableCollection<vkAPI.InfoClass.other.Group> { }) : value);
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
