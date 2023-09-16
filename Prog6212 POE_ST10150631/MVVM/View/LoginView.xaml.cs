using Prog6212_POE_ST10150631.UserControls;
using System.Windows;
using System.Windows.Input;

namespace Prog6212_POE_ST10150631.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void RbtnLogin_Checked(object sender, RoutedEventArgs e)
        {
            UserCntrlLogin login = new UserCntrlLogin();
            ContentPane.Children.Clear();
            login.MinHeight = 500;
            ContentPane.Children.Add(login);
        }

        private void RbtnSignUp_Checked(object sender, RoutedEventArgs e)
        {
            UserCntrlSignUp SignUp = new UserCntrlSignUp();
            ContentPane.Children.Clear();
            SignUp.MinHeight = 500;
            ContentPane.Children.Add(SignUp);
        }

        /// <summary>
        /// Ensures that the user can use the mouse to drag the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        /// <summary>
        /// Minimizes The Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
