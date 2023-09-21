using Prog6212_POE_ST10150631.MVVM.View.Pages;
using Prog6212_POE_ST10150631.Pages;
using System.Windows;
using System.Windows.Input;

namespace Prog6212_POE_ST10150631.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public MainView()
        {
            InitializeComponent();
            HomePg homePg = new HomePg();
            ContentPane.Content = homePg;
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------




        /// <summary>
        /// Ensures that the user can use the mouse to drag the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------





        /// <summary>
        /// When minimized button is clicked the window will minimize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------






        /// <summary>
        /// Shuts down the app when close button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnResize_Click(object sender, RoutedEventArgs e)
        {

            if (WindowState != WindowState.Maximized)
            {

                WindowState = WindowState.Maximized;

            }
            else  WindowState = WindowState.Normal;

            
            
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------




        /// <summary>
        /// Shows semester page in contentpane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void RbtnSemester_Checked(object sender, RoutedEventArgs e)
        {

            SemesterPg semesterPg = new SemesterPg();
            ContentPane.Content = semesterPg;
            Grd.Style = (Style)FindResource("BackgroundSemester");

        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------




        /// <summary>
        /// Shows Modules page in contentpane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void RbtnModules_Checked(object sender, RoutedEventArgs e)
        {
            ModulesPg modulesPg = new ModulesPg();
            ContentPane.Content= modulesPg;

            Grd.Style = (Style)FindResource("BackgroundModules");
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------




        /// <summary>
        /// Shows Music page in contentpane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void RbtnMusic_Checked(object sender, RoutedEventArgs e)
        {
            MusicPg musicPg = new MusicPg();
            ContentPane.Content= musicPg;

            Grd.Style = (Style)FindResource("BackgroundHome");
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------




        /// <summary>
        /// Shows settings page in contentpane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void RbtnSettings_Checked(object sender, RoutedEventArgs e)
        {
            SettingsPg settingsPg = new SettingsPg();
            ContentPane.Content= settingsPg;

            Grd.Style = (Style)FindResource("BackgroundSettings");
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------






        /// <summary>
        /// Shows Home page in contentpane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void RbtnHome_Checked(object sender, RoutedEventArgs e)
        {
            HomePg HomePg = new HomePg();
            ContentPane.Content = HomePg;

            Grd.Style = (Style)FindResource("BackgroundHome");
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------




        /// <summary>
        /// Logs the user out if the logout button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start of Method >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbtnStudy_Checked(object sender, RoutedEventArgs e)
        {
            StudyPg studyPg = new StudyPg();
            ContentPane.Content = studyPg;

            Grd.Style = (Style)FindResource("BackgroundSemester");
        }
        //------------------------------------------------------------------------ End of Method ------------------------------------------------------------------------------------------





    }
}
//=============================================================================== End of File =============================================================================