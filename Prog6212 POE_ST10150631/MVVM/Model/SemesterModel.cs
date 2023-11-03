using Microsoft.SqlServer.Server;
using Prog6212_POE_ST10150631.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    public class SemesterModel
    {
        /// <summary>
        /// Holds the database Connection String
        /// </summary>
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Prog6212_POE_ST10150631.Properties.Settings.StudySyncDBConnectionString"].ConnectionString;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public SemesterModel()
        {

        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Gets all the semesters from the databas based on the user
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public List<Semester> GetAllSemesters(string username)
        {
            // Assuming you have your DbContext set up
            using (var dbContext = new StudySyncDBEntities())
            {
                // 'semestersForUsername' will have all Semesters associated with the username
                List<Semester> semestersForUsername = dbContext.Semesters
                    .Where(semester => semester.Username == username)
                    .ToList();
                return semestersForUsername;

            }
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Adds a new semester to the database
        /// </summary>
        /// <param name="SemName"></param>
        /// <param name="Weeks"></param>
        /// <param name="StartDate"></param>
        /// <param name="username"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public Semester AddNewSemester(string SemName, double Weeks, DateTime StartDate, string username)
        {
            //Query for inserting data into the database 
            string Query = "INSERT INTO dbo.[Semester] (SemesterName, Weeks, StartDate, EndDate, Username ) VALUES (@SemesterName,@Weeks,@StartDate,@EndDate,@Username);";

            DateTime EndDate = CalculateEndDate(StartDate, Weeks);

            //Opens and closses the SQL connection
            using (SqlConnection SQLconnect = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(Query, SQLconnect);
                command.Parameters.AddWithValue("@SemesterName", SemName);
                command.Parameters.AddWithValue("@Weeks", Weeks);
                command.Parameters.AddWithValue("@StartDate", StartDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);
                command.Parameters.AddWithValue("@Username", username);

                SQLconnect.Open();
                //Execute the connection
                command.ExecuteNonQuery();

                SQLconnect.Close(); 


            }
            
            
            var newSem = new Semester();
            newSem.SemesterName = SemName;
            newSem.StartDate = StartDate;
            newSem.EndDate = EndDate;
            newSem.Username = username;
            newSem.Weeks = ((int)Weeks);
            // Assuming you have your DbContext set up
            using (var dbContext = new StudySyncDBEntities())
            {
                dbContext.Semesters.Add(newSem);
                dbContext.SaveChangesAsync();
            }
            
            return newSem;

        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Checks if a semster is in the database based on username and semstername
        /// </summary>
        /// <param name="SemName"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool IsNewSemester(string SemName)
        {
            // Assuming you have your DbContext set up
            using (var dbContext = new StudySyncDBEntities())
            {
                string username = MainViewModel.UserViewModel.LoggedInUser;

                var CheckSemName = dbContext.Semesters
                    .SingleOrDefault(Semester => Semester.Username == username && Semester.SemesterName == SemName);

                if (CheckSemName == null)
                {
                    return true;
                }
                return false;
            }
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Calculates the end date of a semester
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="Weeks"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        private DateTime CalculateEndDate(DateTime StartDate, double Weeks)
        {
            DateTime EndDate;
            double SemDays = Weeks * 7;
            StartDate = StartDate.Date;
            EndDate = StartDate.Date;
            EndDate = EndDate.AddDays(SemDays).Date;
            return EndDate;
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Deletes a semsester from the database
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void DeleteSemester(string SemName)
        {

            string username = MainViewModel.UserViewModel.LoggedInUser;
            //Query to delete semester from database using username and semesterName
            string query = $"DELETE FROM dbo.[Semester] WHERE Username = '{username}' AND SemesterName = '{SemName}';";
            using (SqlConnection SQLconnect = new SqlConnection(ConnectionString))
            {
                SQLconnect.Open();
                SqlCommand cmnd = new SqlCommand(query, SQLconnect);
                cmnd.ExecuteNonQuery();
            }

        }
        //======================================================= End of Method ===================================================



    }
}
