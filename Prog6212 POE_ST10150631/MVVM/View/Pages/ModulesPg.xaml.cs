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
        /// <summary>
        /// Holds the resource dictionary and source for the app
        /// </summary>
        ResourceDictionary appStyles = new ResourceDictionary() { Source = new Uri("MVVM/View/Styles/AppStyle.xaml", UriKind.Relative) };
        /// <summary>
        /// Default constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ModulesPg()
        {
            InitializeComponent();
            
            //Assigning dataContexts
            DtaGrdModules.DataContext = MainViewModel.ModulesViewModel;


            CmboBxSelectSemester.DataContext = MainViewModel.SemestersViewModel;
            CmboBxSelectSemester.ItemsSource = MainViewModel.SemestersViewModel.SemesterData;

            DataContext = MainViewModel.ModulesViewModel;

        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Will ensure details are valid before adding Populating module data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        ///  ----------------------------------------------------- Start of Method ------------------------------------------------

        private void BtnAddModule_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.ValidationClassHere.IsNewModule(TxtBxName,TxtBxCode) == false) // If the module has already been added
            {
                MainViewModel.ValidationClassHere.ErrorMessage("Module Name must be unique and cannot be Empty.");
                TxtBxCode.Style = (Style)appStyles["TxtBxInvalid"];
                TxtBxName.Style = (Style)appStyles["TxtBxInvalid"];
            }
            else if (MainViewModel.ValidationClassHere.IsPositiveDouble(TxtBxCredits)==false) // If the input is not a double or is nagative
            {
                MainViewModel.ValidationClassHere.ErrorMessage("Module Credits must be a positive number.");
                TxtBxCredits.Style = (Style)appStyles["TxtBxInvalid"];
            }
            else if (MainViewModel.ValidationClassHere.IsPositiveDouble(TxtBxClassHrs)==false) // If the input is not a double or is nagative
            {
                MainViewModel.ValidationClassHere.ErrorMessage("Module Class Hours must be a positive number.");
                TxtBxClassHrs.Style = (Style)appStyles["TxtBxInvalid"];
            }
            else if (MainViewModel.ValidationClassHere.IsPositiveDouble(TxtBxClassHrs)==true && MainViewModel.ValidationClassHere.IsPositiveDouble(TxtBxCredits)==true && MainViewModel.ValidationClassHere.IsNewModule(TxtBxName, TxtBxCode)==true && string.IsNullOrEmpty(CmboBxSelectSemester.Text) == false)
            {
                //Resets textbx styles and sends details to the moduleViewModel
                MainViewModel.ModulesViewModel.PopulateModuleList(TxtBxName.Text, TxtBxCode.Text,double.Parse(TxtBxClassHrs.Text),double.Parse(TxtBxCredits.Text),CmboBxSelectSemester.Text);
                TxtBxCode.Style = (Style)appStyles["TxtBxPrimary"];
                TxtBxName.Style = (Style)appStyles["TxtBxPrimary"];
                TxtBxCredits.Style = (Style)appStyles["TxtBxPrimary"];
                TxtBxClassHrs.Style = (Style)appStyles["TxtBxPrimary"];
            }

        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Sends the module to be deleteds name to the ModulesViewModule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.ModulesViewModel.DeleteModule(CmoboBxModules.Text);
        }
        //======================================================= End of Method ===================================================


    }
}
//############################################################### END OF FILE ########################################################
