using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    public class NoteModel
    {
        /// <summary>
        /// Holds the connection string
        /// </summary>
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Prog6212_POE_ST10150631.Properties.Settings.StudySyncDBConnectionString"].ConnectionString;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public NoteModel()
        {

        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Gets All notes for a user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public List<Note> GetAllNotes(string username)
        {
            // Assuming you have your DbContext set up
            using (var dbContext = new StudySyncDBEntities())
            {
                // 'semestersForUsername' will have all Semesters associated with the username
                List<Note> NotesForUser = dbContext.Notes
                    .Where(Note => Note.Username == username)
                    .ToList();
                return NotesForUser;

            }
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Adds new note to the database and returns a Note object to the NoteViewModel
        /// </summary>
        /// <param name="NoteName"></param>
        /// <param name="date"></param>
        /// <param name="Description"></param>
        /// <param name="moduleName"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public Note AddNewNote(string NoteName, DateTime date, string Description, string moduleName, string username)
        {

            // Query for inserting data into the database
            string Query = "INSERT INTO dbo.[Notes] (NoteName, NoteContent, Module, NoteDate, Username) VALUES (@NoteName, @Description, @moduleName,@date, @username)";

            using (SqlConnection SQLconnect = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(Query, SQLconnect);
                command.Parameters.AddWithValue("@NoteName", NoteName);
                command.Parameters.AddWithValue("@Description", Description);
                command.Parameters.AddWithValue("@moduleName", moduleName);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@date", date);

                // Opens the SQL connection
                SQLconnect.Open();

                // Execute the connection
                command.ExecuteNonQuery();
            }

            // Create a new Semester object (you may need to adjust this part to match your entity)
            var newNote = new Note();
            newNote.NoteName = NoteName;
            newNote.NoteContent = Description;
            newNote.NoteDate = date;
            newNote.Username = username;
            newNote.Module = moduleName;


            return newNote;

        }
        //======================================================= End of Method ===================================================


    }
}
