using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// <summary>
        /// Holds the App style resource dictionary to be used to change textbox styles for incorrect input
        /// </summary>
        ResourceDictionary appStyles = new ResourceDictionary() { Source = new Uri("MVVM/View/Styles/AppStyle.xaml", UriKind.Relative) };
        /// <summary>
        /// Default Consytructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public SemesterPg()
        {
            InitializeComponent();

            DatePickSartDate.SelectedDate = DateTime.Today;
            DataContext = MainViewModel.SemestersViewModel;
            
            
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Will call populate a new semesterClass object when Add semester button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnAddSemester_Click(object sender, RoutedEventArgs e)
        {
            //To exclude the time from the date
            DateTime selectedDate = (DateTime)DatePickSartDate.SelectedDate.Value.Date;
            if (MainViewModel.Validate.CheckIsNewSemester(TxtBxName.Text))
            {
                if(MainViewModel.Validate.IsPositiveDouble(TxtBxWeeks.Text))
                {
                    //Converts weeks to double
                    double weeks = Double.Parse(TxtBxWeeks.Text);
                    MainViewModel.SemestersViewModel.AddSemester(TxtBxName.Text, weeks, selectedDate);

                    //Resets the textbox styles back to normal
                    TxtBxWeeks.Style = (Style)appStyles["TxtBxPrimary"];
                    TxtBxName.Style = (Style)appStyles["TxtBxPrimary"];
                }
                else
                {
                    MainViewModel.Validate.ErrorMessage("Invalid input for Number of Weeks. Weeks must be a positive number.");
                    TxtBxWeeks.Style = (Style)appStyles["TxtBxInvalid"];
                }

            }
            else
            {
                MainViewModel.Validate.ErrorMessage("Invalid input for Semester name. Name must be unique and cannot be blank.");
                
                TxtBxName.Style = (Style)appStyles["TxtBxInvalid"];
            }
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Sends Module name to the Delete Semester method if btnDeleteClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            MainViewModel.SemestersViewModel.DeleteSemester( CmoboBxSemesters.Text);
            DataContext = MainViewModel.SemestersViewModel;
            
        }
        //======================================================= End of Method ===================================================


    }
}
