using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace VKHashTag.Engine.InfoClass
{
    public class User : INotifyPropertyChanged
    {
        public static User Load()
        {
            User result = CryptoDB.Read<User>(FileDB.user);
            if (result == null)
                result = new User();

            result.UserName = "Unknown";
            result.photo_100 = null;
            result.BalanceAntigate = -1;

            //Интервал 
            if (result.Interval < 2)
                result.Interval = 2;

            //Подгружаем score
            if (result.scope == null || result.scope.Trim() == "")
                result.scope = "wall,photos,audio,video,docs,notes,groups,notifications,stats,ads,notify,friends,offline,notificat,messages,questions,pages,status,offers";

            //Загрузка приложения
            if (result.UserVK_APP != null && result.UserVK_APP.Trim() != "")
                result.idAPP = result.UserVK_APP;

            //Загрузка приложения
            if (result.idAPP == null || result.idAPP.Trim() == "")
                result.idAPP = "3087106";

            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        ////////////////////////////////////////////////////////////////////////////////

        private int _uid { get; set; }
        private string _photo_100 { get; set; }
        private string _idAPP { get; set; }
        private string _UserVK_APP { get; set; }
        private string _UserName { get; set; }
        private string Token { get; set; }
        private string Login { get; set; }
        private string Passwd { get; set; }
        private string Scope { get; set; }
        private bool _UsingAntigate { get; set; }
        private string _KeyAntigate { get; set; }
        private double _BalanceAntigate { get; set; }
        private int _Interval { get; set; }


        ////////////////////////////////////////////////////////////////////////////////

        public int uid
        {
            get { return _uid; }
            set
            {
                if (value != 0)
                {
                    _uid = value;
                    NotifyPropertyChanged();
                }
                else { _uid = 0; }
            }
        }


        public string photo_100
        {
            get { return _photo_100; }
            set
            {
                _photo_100 = value == null ? null : (value.Trim() == "" ? null : value.Trim());
                NotifyPropertyChanged();
            }
        }


        public string idAPP
        {
            get { return _idAPP; }
            set
            {
                if (value != null)
                {
                    _idAPP = value.Trim() == "" ? null : value.Trim();
                    NotifyPropertyChanged();
                }
                else { _idAPP = null; }
            }
        }


        public string UserVK_APP
        {
            get { return _UserVK_APP; }
            set
            {
                if (value != null)
                {
                    string res = Regex.Replace(value, @"[^0-9]", "").Trim();
                    if (res == "")
                        _UserVK_APP = null;
                    else
                        _UserVK_APP = res;

                    res = null;
                    NotifyPropertyChanged();
                }
                else { _UserVK_APP = null; }
            }
        }


        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (value != null)
                {
                    _UserName = value.Trim() == "" ? null : value.Trim();
                    NotifyPropertyChanged();
                }
                else { _UserName = null; }
            }
        }


        public string token
        {
            get { return Token; }
            set
            {
                if (value != null)
                {
                    string res = Regex.Replace(value, @"[^0-9a-zA-Z]", "").Trim();
                    if (res == "")
                        Token = null;
                    else
                        Token = res;

                    res = null;
                    NotifyPropertyChanged();
                }
                else { Token = null; }
            }
        }


        public string login
        {
            get { return Login; }
            set
            {
                if (value != null)
                {
                    string res = Regex.Replace(value, @"[^0-9a-zA-Z\@\+\.\-]", "").Trim();
                    if (res == "")
                        Login = null;
                    else
                        Login = res;

                    res = null;
                    NotifyPropertyChanged();
                }
                else { Login = null; }
            }
        }


        public string passwd
        {
            get { return Passwd; }
            set
            {
                if (value != null)
                {
                    string res = Regex.Replace(value, @" ", "").Trim();
                    if (res == "")
                        Passwd = null;
                    else
                        Passwd = res;

                    res = null;
                    NotifyPropertyChanged();
                }
                else { Passwd = null; }
            }
        }


        public string scope
        {
            get { return Scope; }
            set
            {
                if (value != null)
                {
                    string res = Regex.Replace(value, @"[^0-9a-z\,]", "").Trim();
                    if (res == "")
                        Scope = null;
                    else
                        Scope = res;

                    res = null;
                    NotifyPropertyChanged();
                }
                else { Scope = null; }
            }
        }


        public bool UsingAntigate
        {
            get { return _UsingAntigate; }
            set
            {
                _UsingAntigate = value;
                NotifyPropertyChanged();
            }
        }


        public string KeyAntigate
        {
            get { return _KeyAntigate; }
            set
            {
                if (value != null)
                {
                    string res = Regex.Replace(value, @"[^0-9a-zA-Z]", "").Trim();
                    if (res == "")
                        _KeyAntigate = null;
                    else
                        _KeyAntigate = res;

                    res = null;
                    NotifyPropertyChanged();
                }
                else { _KeyAntigate = null; }
            }
        }


        public double BalanceAntigate
        {
            get { return _BalanceAntigate; }
            set
            {
                _BalanceAntigate = value;
                NotifyPropertyChanged();
            }
        }


        public int Interval
        {
            get { return _Interval; }
            set
            {
                _Interval = value;
                NotifyPropertyChanged();
            }
        }
    }
}
