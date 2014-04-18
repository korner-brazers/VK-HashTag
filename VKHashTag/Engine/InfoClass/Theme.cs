namespace VKHashTag.Engine.InfoClass
{
    public class Theme
    {
        public string them { get; set; }
        public string Accent { get; set; }
        public string FlyoutsControl { get; set; }

        public Theme()
        {
            this.them = "Light"; //Для выбора темы
            this.Accent = "Blue"; //Само оформление
            this.FlyoutsControl = "Accent"; //Для меседжбокса и панелей
        }
    }
}
