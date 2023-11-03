using Prog6212_POE_ST10150631.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
namespace Prog6212_POE_ST10150631.UserControls
{
    /// <summary>
    /// Interaction logic for UserCntrlSignUp.xaml
    /// </summary>
    public partial class UserCntrlSignUp : UserControl
    {
        public UserCntrlSignUp()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Executes when the Sign Up button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            //Ensures that no values are null
            if (TxtBxUsername.Text.Trim().Length > 0 && TxtBxName.Text.Trim().Length > 0 && TxtBxSurname.Text.Trim().Length > 0 && TxtBxPassword.Password.Length > 0)
            {
                if(MainViewModel.UserViewModel.TryRegister(TxtBxUsername.Text.Trim(), TxtBxName.Text.Trim(), TxtBxSurname.Text.Trim(), TxtBxPassword.Password))
                {                
                    MainView mainWindow = new MainView();
                    mainWindow.Show();
                    Window parentWindow = Window.GetWindow(this);
                    parentWindow.Close();

                }
                
            }
            MainViewModel.Validate.ErrorMessage("Fields cannot be left Blank.");
        }        
        //======================================================= End of Method ===================================================



    }

}
