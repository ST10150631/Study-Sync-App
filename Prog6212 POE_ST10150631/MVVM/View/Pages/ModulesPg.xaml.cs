using Prog6212_POE_ST10150631.MVVM.Model;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
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

namespace Prog6212_POE_ST10150631.Pages
{
    /// <summary>
    /// Interaction logic for ModulesPg.xaml
    /// </summary>
    public partial class ModulesPg : Page
    {
        ResourceDictionary appStyles = new ResourceDictionary() { Source = new Uri("MVVM/View/Styles/AppStyle.xaml", UriKind.Relative) };
        public ModulesPg()
        {
            InitializeComponent();
            DtaGrdModules.DataContext = MainViewModel.ModulesViewModel;
            CmboBxFilterSemester.DataContext = MainViewModel.SemestersViewModel;
            CmboBxFilterSemester.ItemsSource = MainViewModel.SemestersViewModel.SemesterData;

            CmboBxSelectSemester.DataContext = MainViewModel.SemestersViewModel;
            CmboBxSelectSemester.ItemsSource = MainViewModel.SemestersViewModel.SemesterData;

            CmoboBxModules.DataContext = MainViewModel.ModulesViewModel;
            CmoboBxModules.ItemsSource = MainViewModel.ModulesViewModel.ModuleData;
        }

        private void BtnAddModule_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
