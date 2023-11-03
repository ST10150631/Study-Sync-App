using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prog6212_POE_ST10150631.MVVM.Model;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class NoteViewModel
    {
        /// <summary>
        /// Holds the notification data as an observable collection
        /// </summary>
        private ObservableCollection<Note> _noteData;

        private NoteModel model = new NoteModel();

        /// <summary>
        /// Gets and sets the noteData when NoteList is changed
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ObservableCollection<Note> NoteData
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
        /// An event for when the noteData is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// default constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public NoteViewModel()
        {
            _noteData = new ObservableCollection<Note>();
        }
        //======================================================= End of Method ===================================================



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
        /// Adds new note to observable collection and database
        /// </summary>
        /// <param name="NoteName"></param>
        /// <param name="date"></param>
        /// <param name="Description"></param>
        /// <param name="moduleName"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void AddNote(string NoteName, DateTime date, string Description, string moduleName)
        {
            var user = MainViewModel.UserViewModel.LoggedInUser;
            var NewNote = model.AddNewNote(NoteName,date,Description,moduleName, user);
            NoteData.Add(NewNote);
            OnPropertyChanged(nameof(NoteData));
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Gets the data to be displayed in the datagrid and comboboxes
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void GetNoteData()
        {
            List<Note> notes = new List<Note>();
            notes = model.GetAllNotes(MainViewModel.UserViewModel.LoggedInUser);
            foreach (var note in notes)
            {
                NoteData.Add(note);
            }
            OnPropertyChanged(nameof(NoteData));
        }
        //======================================================= End of Method ===================================================



    }
}
