using Prog6212_POE_ST10150631.MVVM.View.UserControls;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Prog6212_POE_ST10150631.MVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for StudyPg.xaml
    /// </summary>
    public partial class StudyPg : Page
    {
        /// <summary>
        /// Creating a new Thread for the Timer
        /// </summary>
        private System.Threading.Timer timer;
        /// <summary>
        /// readonly object used for thread safety (read about it online)
        /// </summary>
        private readonly object lockObject = new object();
        /// <summary>
        /// Custome Date Time holds the Time Studied 
        /// </summary>
        private double SecondsStudied; // Store the custom time
        /// <summary>
        /// Holds the Number of Munites Studied
        /// </summary>
        private double MinutesStudied;
        /// <summary>
        /// Holds weather the timer is active or  not
        /// </summary>
        private bool isTimerRunning = false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public StudyPg()
        {
            InitializeComponent();
            CmboBxSelectSemester.DataContext = MainViewModel.SemestersViewModel;
            moduleItemsControl.DataContext = MainViewModel.ModulesViewModel;
            moduleItemsControl.ItemsSource = MainViewModel.ModulesViewModel.ModuleData;

            CmboBxCustomAddHrs.DataContext = MainViewModel.ModulesViewModel;
            CmboBxSelectMod.DataContext = MainViewModel.ModulesViewModel;


        }

        private void btnStopTimer_Click(object sender, RoutedEventArgs e)
        {
            ClockTimer.Stop();
            if (isTimerRunning)
            {
                // Stop the timer
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                isTimerRunning = false;
                ClockTimer.Stop(); // Pause the animation if needed
            }
        }

        private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRunning)
            {
                ClockTimer.Play();


                timer = new System.Threading.Timer(TimerCallback, null, 0, 1000);
                isTimerRunning = true; // Start the timer
            }
        }

        private void TimerCallback(object state)
        {
            // This code will be executed in a separate thread

            // Update the UI using the Dispatcher to ensure thread safety
            lock (lockObject)
            {
                if (isTimerRunning)
                {
                    Dispatcher.Invoke(() =>
                    {
                        
                        SecondsStudied ++;
                        if (SecondsStudied == 60)
                        {
                            SecondsStudied = 0;
                            MinutesStudied++;
                            LblTime.Content = MinutesStudied+"   Minutes Studied";


                        }
                    });
                }
            }
        }
        /// <summary>
        /// Will Add the Timers Value to Hours Studied 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddTimerHrs_Click(object sender, RoutedEventArgs e)
        {
            if (CmboBxSelectMod.Text.Equals(string.Empty))
            {

            }
            else if(MinutesStudied ==0)
            {
                
            }
            else
            {
                MainViewModel.ModulesViewModel.UpdateCompletedSelfHrs(CmboBxSelectMod.Text, MinutesStudied / 60);
            }
            moduleItemsControl.DataContext = MainViewModel.WorkerClassHere;
            moduleItemsControl.ItemsSource = MainViewModel.WorkerClassHere.ModuleList;
            moduleItemsControl.DataContext = MainViewModel.ModulesViewModel;
            moduleItemsControl.ItemsSource = MainViewModel.ModulesViewModel.ModuleData;
        }

        /// <summary>
        /// Adds User Entered Value To hours Studied
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddCustomHrs_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(HrsToAdd.Text, out double Hours))
            {
                MainViewModel.ModulesViewModel.UpdateCompletedSelfHrs(CmboBxCustomAddHrs.Text, Hours);
            }
            moduleItemsControl.DataContext = MainViewModel.WorkerClassHere;
            moduleItemsControl.ItemsSource = MainViewModel.WorkerClassHere.ModuleList;
            moduleItemsControl.DataContext = MainViewModel.ModulesViewModel;
            moduleItemsControl.ItemsSource = MainViewModel.ModulesViewModel.ModuleData;
        }




        private void BtnSelectSemester_Click(object sender, RoutedEventArgs e)
        {
            if(CmboBxSelectSemester.Text != string.Empty)
            {
                TxtShowWeek.Text =  MainViewModel.StudyPgViewModel.CalculateCurrentWeek(CmboBxSelectSemester.Text);

            }
            
        }



        //======================================================= End of Method ===================================================



    }
}
