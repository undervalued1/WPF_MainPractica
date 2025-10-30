using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFpractica3.Styles.Colors.Themes
{
    static class ThemeHelper
    {
        private static readonly string[] _themePath = {
            "/Styles/Colors/Themes/LightTheme/LightTheme.xaml",
            "/Styles/Colors/Themes/DarkTheme/DarkTheme.xaml"
        };

        public static string Current
        {
            get => string.IsNullOrEmpty(Properties.Settings.Default.ThemePath)
                   ? _themePath[0]
                   : Properties.Settings.Default.ThemePath;
            set
            {
                Properties.Settings.Default.ThemePath = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool IsDarkTheme => Current == _themePath[1];

        public static void Apply(string themePath)
        {
            try
            {
                var newTheme = new ResourceDictionary
                {
                    Source = new Uri(themePath, UriKind.RelativeOrAbsolute)
                };

                // Удаляем старые темы
                var themesToRemove = Application.Current.Resources.MergedDictionaries
                    .Where(d => d.Source != null &&
                           _themePath.Any(path => d.Source.OriginalString.Contains(path)))
                    .ToList();

                foreach (var theme in themesToRemove)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(theme);
                }

                // Добавляем новую тему
                Application.Current.Resources.MergedDictionaries.Add(newTheme);
                Current = themePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки темы: {ex.Message}");
            }
        }

        public static void ApplySave()
        {
            Apply(Current);
        }

        public static void Toggle()
        {
            var newTheme = IsDarkTheme ? _themePath[0] : _themePath[1];
            Apply(newTheme);
        }

        public static void SetLightTheme()
        {
            Apply(_themePath[0]);
        }

        public static void SetDarkTheme()
        {
            Apply(_themePath[1]);
        }
    }
}
    

