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

namespace Prog6212_POE_ST10150631.MVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for StudyPg.xaml
    /// </summary>
    public partial class StudyPg : Page
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public StudyPg()
        {
            InitializeComponent();
            SelectSemester.DataContext = MainViewModel.SemestersViewModel;
            moduleItemsControl.DataContext = MainViewModel.ModulesViewModel;
            
        }
        //======================================================= End of Method ===================================================



    }
}
