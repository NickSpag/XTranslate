using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XTranslate
{
    public static partial class Help
    {
        public static class Settings
        {
            private static ISettings AppSettings => CrossSettings.Current;

            public static string SelectedLanguage
            {
                get => AppSettings.GetValueOrDefault(nameof(SelectedLanguage), string.Empty);
                set => AppSettings.AddOrUpdateValue(nameof(SelectedLanguage), value);
            }

        }
    }
}
