using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace VKHashTag.Engine.InfoClass.job
{
    public class Main : INotifyPropertyChanged
    {
        public int id { get; set; }
        private bool _Activ { get; set; }
        private string _Name { get; set; }
        private string _InformationJob { get; set; }
        public EnumType Type { get; set; }
        public DateTime LastData { get; set; }
        private bool _Reply { get; set; } //Отчеты, база и т.д
        private bool _Work { get; set; } //Работает ли задание в потоке или нет 
        private ulong _ProgressBarValue { get; set; }
        public ulong ProgressBarMaxValue { get; set; } //Используеться исключительно для конвертации %



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                         Автоматическое сохранение базы и обновление триггеров                      #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool Activ
        {
            get { return _Activ; }
            set
            {
                _Activ = value;
                if (!VKHashTag.db.IsLoad)
                {
                    NotifyPropertyChanged();
                    CryptoDB.Write(FileDB.job, VKHashTag.db.job);
                }
            }
        }


        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyPropertyChanged();
            }
        }


        public string InformationJob
        {
            get { return _InformationJob; }
            set
            {
                if (!VKHashTag.db.IsLoad)
                {
                    _InformationJob = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public bool Reply
        {
            get { return _Reply; }
            set
            {
                _Reply = value;
                NotifyPropertyChanged();
            }
        }


        public bool Work
        {
            get { return _Work; }
            set
            {
                if (!VKHashTag.db.IsLoad)
                {
                    _Work = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public ulong ProgressBarValue
        {
            get { return _ProgressBarValue; }
            set
            {
                //Если база загружаеться
                if (VKHashTag.db.IsLoad)
                    return;

                if (ProgressBarMaxValue == 0 && value >= 0 && value <= 100 && _ProgressBarValue != value)
                {
                    //Если максимальное число в "ProgressBarMaxValue" не указанно и при этом число от 0 до 100
                    _ProgressBarValue = value;
                    NotifyPropertyChanged();
                }
                else if (ProgressBarMaxValue != 0 && value >= 0 && value <= ProgressBarMaxValue)
                {
                    //Если указанно максимальное число в "ProgressBarMaxValue", при этом число от 0 до (максимальное число ProgressBarMaxValue)
                    ulong result = (ulong)(((double)value / (double)ProgressBarMaxValue) * 100);
                    if (_ProgressBarValue != result)
                    {
                        _ProgressBarValue = result;
                        NotifyPropertyChanged();
                    }
                }
                else if (ProgressBarMaxValue != 0 && value > ProgressBarMaxValue && _ProgressBarValue != 100)
                {
                    //Если указанно максимальное число "ProgressBarMaxValue", но число "value" больше числа "ProgressBarMaxValue" и "_ProgressBarValue" не равно 100
                    _ProgressBarValue = 100;
                    NotifyPropertyChanged();
                }
                else if (value < 0 && _ProgressBarValue != 0)
                {
                    //Если value меньше нуля и "_ProgressBarValue" не равен нулю
                    _ProgressBarValue = 0;
                    NotifyPropertyChanged();
                }
            }
        }


        public string StringType
        {
            get
            {
                switch (Type)
                {
                    case EnumType.HashTag:
                        {
                            return "HashTag";
                        }
                    default: return "error";
                }
            }
        }
    }
}
