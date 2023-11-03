using Prog6212_POE_ST10150631.MVVM.View;
using Prog6212_POE_ST10150631.MVVM.View.Pages;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
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
            noteItemsControl.DataContext = MainViewModel.NoteViewModel;
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
                System.Windows.MessageBox.Show("Error Loading image.", "Error", MessageBoxButton.OK);
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


        /// <summary>
        /// Ensures that the input is a Time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void TimeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Get the current text in the TextBox
            string currentText = ((System.Windows.Controls.TextBox)sender).Text;

            // Allow digits, colon (:) and backspace
            if (!string.IsNullOrEmpty(e.Text) && !char.IsDigit(e.Text[0]) && e.Text[0] != ':' && e.Text[0] != '\b')
            {
                e.Handled = true;
                return;
            }

            // Limit the length to 5 characters (HH:mm)
            if (currentText.Length >= 5 && e.Text[0] != '\b')
            {
                e.Handled = true;
                return;
            }
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Ensures that the Time is in a valid format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void TimeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = ((System.Windows.Controls.TextBox)sender).Text;

            // Automatically insert a colon if the user types two digits without a colon
            if (currentText.Length == 2 && !currentText.Contains(":"))
            {
                ((System.Windows.Controls.TextBox)sender).Text = currentText.Insert(2, ":");
                ((System.Windows.Controls.TextBox)sender).CaretIndex = 3;
            }
            // Validate hours and minutes
            if (currentText.Length == 5)
            {
                string[] parts = currentText.Split(':');
                if (parts.Length == 2)
                {
                    if (!int.TryParse(parts[0], out int hours) || hours > 24)
                    {
                        // Invalid hours
                        ((System.Windows.Controls.TextBox)sender).Text = "00:00";
                    }
                    if (!int.TryParse(parts[1], out int minutes) || minutes > 59)
                    {
                        // Invalid minutes
                        ((System.Windows.Controls.TextBox)sender).Text = "00:00";
                    }
                }
            }
    // Reattach the event handler
    ((System.Windows.Controls.TextBox)sender).TextChanged += TimeTextBox_TextChanged;
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Checks and Adds a notification 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private void BtnAddNote_Click(object sender, RoutedEventArgs e)
        {

            if(DateTime.TryParseExact(TxtBxTime.Text, "HH:mm", null, DateTimeStyles.None, out DateTime parsedTime))
            {
                TimeSpan time = parsedTime.TimeOfDay;
                DateTime.TryParse(DatePick.Text,out DateTime Date);
                Date = Date.Add(time);
                if(MainViewModel.Validate.TxtBxNotBlank(TxtBxNoteName.Text) )
                {
                    //Gets the Text Calue fromn the DateTime
                    TextRange textRange = new TextRange(TxtBxDetails.Document.ContentStart, TxtBxDetails.Document.ContentEnd);
                    string details = textRange.Text;
                    string SelectedMod = CmboBxSelectModule.Text;
                    if (SelectedMod.Equals(string.Empty))
                    {
                        SelectedMod = "None";
                    }

                    MainViewModel.NoteViewModel.AddNote(TxtBxNoteName.Text, Date,details,SelectedMod);
                }

            }
        }
        //======================================================= End of Method ===================================================




    }
}
//############################################################### END OF FILE ########################################################
