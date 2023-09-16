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
    /// Interaction logic for UserCntrlSignUp.xaml
    /// </summary>
    public partial class UserCntrlSignUp : UserControl
    {
        public UserCntrlSignUp()
        {
            InitializeComponent();
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            MainView mainWindow = new MainView();
            mainWindow.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }

}
