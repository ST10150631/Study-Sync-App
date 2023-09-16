using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Prog6212_POE_ST10150631.MVVM.Model;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Prog6212_POE_ST10150631.Pages
{
    /// <summary>
    /// Interaction logic for SemesterPg.xaml
    /// </summary>
    public partial class SemesterPg : Page
    {
        ResourceDictionary appStyles = new ResourceDictionary() { Source = new Uri("MVVM/View/Styles/AppStyle.xaml", UriKind.Relative) };
        public SemesterPg()
        {
            InitializeComponent();

            DatePickSartDate.SelectedDate = DateTime.Today;
            DataContext = MainViewModel.SemestersViewModel;
            
        }

        
        /// <summary>
        /// Will call populate a new semesterClass object when Add semester button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddSemester_Click(object sender, RoutedEventArgs e)
        {
            //To exclude the time from the date
            DateTime selectedDate = (DateTime)DatePickSartDate.SelectedDate.Value.Date;
            if (MainViewModel.ValidationClassHere.IsNewSemester(TxtBxName))
            {
                if(MainViewModel.ValidationClassHere.IsPositiveDouble(TxtBxWeeks))
                {
                    double weeks = Double.Parse(TxtBxWeeks.Text);
                    MainViewModel.SemestersViewModel.PopulateSemesterList(TxtBxName.Text, selectedDate, weeks);

                    TxtBxWeeks.Style = (Style)appStyles["TxtBxPrimary"];


                    TxtBxName.Style = (Style)appStyles["TxtBxPrimary"];

                }
                else
                {
                    MainViewModel.ValidationClassHere.ErrorMessage("Invalid input for Number of Weeks. Weeks must be a positive number.");
                    TxtBxWeeks.Style = (Style)appStyles["TxtBxInvalid"];
                }

            }
            else
            {
                MainViewModel.ValidationClassHere.ErrorMessage("Invalid input for Semester name. Name must be unique and cannot be blank.");
                
                TxtBxName.Style = (Style)appStyles["TxtBxInvalid"];
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            MainViewModel.SemestersViewModel.DeleteSemester( CmoboBxSemesters.Text);
        }
    }
}
