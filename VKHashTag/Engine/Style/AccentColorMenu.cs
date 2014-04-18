using System;
using System.Linq;
using MahApps.Metro;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.Generic;

namespace VKHashTag.Engine.Style
{
    class AccentColorMenu
    {
        public List<AccentColorMenuData> AccentColors { get; set; }

        public AccentColorMenu()
        {
            this.AccentColors = ThemeManager.DefaultAccents.Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush }).ToList();
        }


        public class AccentColorMenuData
        {
            public string Name { get; set; }
            public Brush ColorBrush { get; set; }

            private ICommand changeAccentCommand;

            public ICommand ChangeAccentCommand
            {
                get { return this.changeAccentCommand ?? (changeAccentCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => ChangeAccent(x) }); }
            }

            private void ChangeAccent(object sender)
            {
                if (db.conf.theme.Accent != this.Name)
                {
                    db.conf.theme.Accent = this.Name;
                    ThemeManager.ChangeTheme(Application.Current, ThemeManager.DefaultAccents.First(x => x.Name == this.Name), ThemeManager.DetectTheme(Application.Current).Item1);
                    CryptoDB.Write(FileDB.conf, db.conf);
                }

                sender = null; 
            }
        }


        class SimpleCommand : ICommand
        {
            public Predicate<object> CanExecuteDelegate { get; set; }
            public Action<object> ExecuteDelegate { get; set; }

            public bool CanExecute(object parameter)
            {
                if (CanExecuteDelegate != null)
                    return CanExecuteDelegate(parameter);
                return true; // if there is no can execute default to true
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameter)
            {
                if (ExecuteDelegate != null)
                    ExecuteDelegate(parameter);
            }
        }
    }
}
