using Prog6212_POE_ST10150631.MVVM.View;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Prog6212_POE_ST10150631.UserControls
{
    /// <summary>
    /// Interaction logic for UserCntrlLogin.xaml
    /// </summary>
    public partial class UserCntrlLogin : UserControl
    {
        public UserCntrlLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBxUsername.Text.Trim().Length > 0 && TxtBxPW.Password.Length > 0)
            {
                if(MainViewModel.UserViewModel.TryLogin(TxtBxUsername.Text, TxtBxPW.Password))
                {
                    MainView mainWindow = new MainView();
                mainWindow.Show();
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Close();

                }
                else
                {                
                    MainViewModel.Validate.ErrorMessage("Incorrect Login values found. Try agian or create an account by signing up");
                }
            }

        }
    }
}
