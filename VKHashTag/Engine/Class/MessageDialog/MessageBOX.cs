using System;
using System.Windows;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace VKHashTag.Engine.Class.MessageDialog
{
    class MessageBOX
    {
        public static async void Show(string text, string StackTrace = null)
        {
            MessageDialogResult result = await ShowFix(text, (StackTrace != null ? "Error :(" : "Information :)"),
                                                      (StackTrace != null ? MessageDialogStyle.AffirmativeAndNegative : MessageDialogStyle.Affirmative),
                                                      (StackTrace != null ? "   копировать в буфер   " : "ok"));

            //Если это ошибка и нажата кнопка "копировать в буфер", то копируем в буфер все данные
            if (result != MessageDialogResult.Negative && StackTrace != null)
                Clipboard.SetText(text + Environment.NewLine + StackTrace);

            text = null; StackTrace = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                Ожидаем пока пользователь нажмет кнопку                             #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Task<MessageDialogResult> ShowFix(string text, string title = "Error :(", MessageDialogStyle DialogStyle = MessageDialogStyle.Affirmative, string Affirmative = "ok", string Negative = "close", string FirstAuxiliary = null, string SecondAuxiliary = null)
        {
            //Настройки
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = Affirmative,
                NegativeButtonText = Negative,
                FirstAuxiliaryButtonText = FirstAuxiliary,
                SecondAuxiliaryButtonText = SecondAuxiliary,
                ColorScheme = (db.conf.theme.FlyoutsControl == "Accent" ? MetroDialogColorScheme.Accented : (db.conf.theme.FlyoutsControl == "Dark" ? MetroDialogColorScheme.Dark : MetroDialogColorScheme.Light)),
                UsingDark = db.conf.theme.them == "Light" ? false : true,
                UseAnimations = true
            };

            //Возвращаем результат
            Affirmative = null; Negative = null; FirstAuxiliary = null; SecondAuxiliary = null;
            return DialogManager.ShowMessageAsync(MainWindow.main, title, (text == null ? "null" : text), DialogStyle, mySettings);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////#############                                Смс Бокс с инпутом, в который вводяться данные                      #############/////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Task<string> ShowInput(string title, string text, string Affirmative = "ok", string Negative = "close", string FirstAuxiliary = null, string SecondAuxiliary = null)
        {
            //Настройки
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = Affirmative,
                NegativeButtonText = Negative,
                FirstAuxiliaryButtonText = FirstAuxiliary,
                SecondAuxiliaryButtonText = SecondAuxiliary,
                ColorScheme = (db.conf.theme.FlyoutsControl == "Accent" ? MetroDialogColorScheme.Accented : (db.conf.theme.FlyoutsControl == "Dark" ? MetroDialogColorScheme.Dark : MetroDialogColorScheme.Light)),
                UsingDark = db.conf.theme.them == "Light" ? false : true,
                UseAnimations = true
            };

            Affirmative = null; Negative = null; FirstAuxiliary = null; SecondAuxiliary = null;
            return DialogManager.ShowInputAsync(MainWindow.main, title, text, mySettings);
        }
    }
}
