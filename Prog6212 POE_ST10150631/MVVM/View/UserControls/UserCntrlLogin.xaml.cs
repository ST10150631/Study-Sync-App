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
            MainView mainWindow = new MainView();
            mainWindow.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
