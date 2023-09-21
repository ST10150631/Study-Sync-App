using Prog6212_POE_ST10150631.MVVM.View;
using Prog6212_POE_ST10150631.MVVM.View.Pages;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Prog6212_POE_ST10150631.Pages
{
    /// <summary>
    /// Interaction logic for HomePg.xaml
    /// </summary>
    public partial class HomePg : Page
    {
        /// <summary>
        /// Keeps track of the image index displayed 
        /// </summary>
        private int ImageCount = 0;


        /// <summary>
        /// Holds the list of images 
        /// </summary>
        private List<BitmapImage> ImageList = new List<BitmapImage>();


        /// <summary>
        /// Default Constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public HomePg()
        {
            InitializeComponent();
            DateNow.Text = DateTime.Now.ToString();
            CmboBxSelectModule.DataContext = MainViewModel.ModulesViewModel;
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Will set the current Page to SemesterPg if Semester Button Clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnSemester_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            SemesterPg semesterPg = new SemesterPg();
            parentWindow.ContentPane.Content = semesterPg;
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Will set the current Page to ModulesPg if Module Button Clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnModules_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            ModulesPg modulesPg = new ModulesPg();
            parentWindow.ContentPane.Content = modulesPg;
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Will set the current Page to MusicPg if Music Button Clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnMusic_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            MusicPg musicPg = new MusicPg();
            parentWindow.ContentPane.Content = musicPg;
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Will set the current Page to SettingsPg if Settings Button Clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            SettingsPg settingsPg = new SettingsPg();
            parentWindow.ContentPane.Content = settingsPg;
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Will allow the user to open an Image File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnAddTimeTable_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png) | *.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                Uri fileUri = new Uri(openFileDialog.FileName);
                var tempImg = new BitmapImage(fileUri);
                ImageList.Add(tempImg);
                ImgTimeTable.Source = tempImg;
            }
            else
            {
                System.Windows.MessageBox.Show("Error Loading image.","Error",MessageBoxButton.OK);
            }
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Clears the Timetable Images from list and the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
                this.ImgTimeTable.Source = null;
                this.ImageList.Clear();
            
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Will display the next image if clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnNextImg_Click(object sender, RoutedEventArgs e)
        {
            if (ImageList.Count > 0)
            {
                ImageCount++;
                if (ImageCount >= ImageList.Count)
                {
                    ImageCount = 0;
                }
                this.ImgTimeTable.Source = ImageList[ImageCount];
            }
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Will display the previous image if clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
            private void BtnPreviousImg_Click(object sender, RoutedEventArgs e)
        {
            if (ImageList.Count > 0)
            {
                ImageCount--;
                if (ImageCount < 0)
                {
                    ImageCount = ImageList.Count - 1;
                }
                this.ImgTimeTable.Source = ImageList[ImageCount];
            }
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnStudy_Click(object sender, RoutedEventArgs e)
        {
            MainView parentWindow = Window.GetWindow(this) as MainView;
            StudyPg study = new StudyPg();
            parentWindow.ContentPane.Content = study;
        }
        //======================================================= End of Method ===================================================


    }
}
//############################################################### END OF FILE ########################################################
