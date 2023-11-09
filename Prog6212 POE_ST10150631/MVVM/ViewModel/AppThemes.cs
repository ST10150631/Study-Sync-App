using System;
using System.Windows;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    internal class AppThemes
    {
        /// <summary>
        /// Changes Styles based on user Input
        /// </summary>
        /// <param name="themeUri"></param>
        public static void ChangeTheme(Uri themeUri)
        {
            ResourceDictionary Theme = new ResourceDictionary() { Source = themeUri };
            ResourceDictionary AppStyle = new ResourceDictionary() { Source = new Uri("MVVM/View/Styles/AppStyle.xaml", UriKind.Relative) };


            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(Theme);
            App.Current.Resources.MergedDictionaries.Add(AppStyle);

        }
    }
}
