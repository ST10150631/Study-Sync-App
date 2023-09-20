using Prog6212_POE_ST10150631.MVVM.View;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Prog6212_POE_ST10150631.Pages
{
    /// <summary>
    /// Interaction logic for HomePg.xaml
    /// </summary>
    public partial class HomePg : Page
    {
        /// <summary>
        /// Keeps track of the image index displayed 
        /// </summary>
        private int ImageCount = 0;


        /// <summary>
        /// Holds the list of images 
        /// </summary>
        private List<Image> ImageList = new List<Image>();



        public HomePg()
        {
            InitializeComponent();
        }

        private void BtnSemester_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            SemesterPg semesterPg = new SemesterPg();
            parentWindow.ContentPane.Content = semesterPg;
        }

        private void BtnModules_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            ModulesPg modulesPg = new ModulesPg();
            parentWindow.ContentPane.Content = modulesPg;
        }

        private void BtnMusic_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            MusicPg musicPg = new MusicPg();
            parentWindow.ContentPane.Content = musicPg;
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            SettingsPg settingsPg = new SettingsPg();
            parentWindow.ContentPane.Content = settingsPg;
        }

       
    }
}
