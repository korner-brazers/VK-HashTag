using System.Linq;
using MahApps.Metro;
using System.Windows;


namespace VKHashTag.Engine.InfoClass
{
    public class Conf
    {
        public Conf()
        {
            theme = new Theme();
        }

        public Theme theme {get; set;} //Выбор темы и т.д
        public int SleepMin { get; set; }
        public int SleepMax { get; set; }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                  Загрузка и сохранение конфигурации                                #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Conf Load()
        {
            Conf result = CryptoDB.Read<Conf>(FileDB.conf);
            if (result == null)
                result = new Conf();

            //Время ожидания 
            if (result.SleepMin == 0)
                result.SleepMin = 250;

            //Время ожидания 
            if (result.SleepMax == 0)
                result.SleepMax = 500;

            //Время ожидания 
            if (result.SleepMin >= result.SleepMax)
                result.SleepMin = (result.SleepMax - 50);


            ThemeManager.ChangeTheme(Application.Current, ThemeManager.DetectTheme(Application.Current).Item2, (result.theme.them == "Light" ? MahApps.Metro.Theme.Light : MahApps.Metro.Theme.Dark));
            ThemeManager.ChangeTheme(Application.Current, ThemeManager.DefaultAccents.First(x => x.Name == result.theme.Accent), ThemeManager.DetectTheme(Application.Current).Item1);


            //Возвращаем конфиги
            return result;
        }
    }
}
