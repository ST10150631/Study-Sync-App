using Prog6212_POE_ST10150631.MVVM.Model;
using ST10150631_PROG_6212_POE_ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class HomeViewModel
    {
        /// <summary>
        /// Holds the notification data as an observable collection
        /// </summary>
        private ObservableCollection<NotificationClass> _noteData;


        /// <summary>
        /// Gets and sets the noteData when NoteList is changed
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ObservableCollection<NotificationClass> NoteData
        {
            get { return _noteData; }
            set
            {
                _noteData = value;
                OnPropertyChanged();
            }
        }
        //======================================================= End of Method ===================================================




        /// <summary>
        /// Default Constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public HomeViewModel()
        {
            _noteData = new ObservableCollection<NotificationClass>();
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// An event for when the noteData is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Invokes the event if notedata is changed
        /// </summary>
        /// <param name="propertyName"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Creates adds user input to notesData and noteList
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="StartDate"></param>
        /// <param name="Weeks"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void PopulateNoteList(string NoteName, DateTime date, string Description ,string moduleName)
        {
            NotificationClass newNote = new NotificationClass();
            newNote.NoteName = NoteName;
            newNote.NoteDate = date;
            newNote.NoteDescription = Description;
            newNote.module = moduleName;
            MainViewModel.WorkerClassHere.NotificationList.Add(newNote);
            NoteData.Add(newNote);
           



            OnPropertyChanged(nameof(NoteData));


        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Deletes Semesters from both the SemesterList and SemesterData
        /// </summary>
        /// <param name="SemesterName"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void DeleteNote(string NoteName)
        {

            OnPropertyChanged(nameof(NoteData));
        }        
        //======================================================= End of Method ===================================================


    }
//############################################################### END OF FILE ########################################################

}
