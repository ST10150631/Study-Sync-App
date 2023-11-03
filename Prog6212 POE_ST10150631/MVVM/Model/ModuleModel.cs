using Prog6212_POE_ST10150631.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    public class ModuleModel
    {
        /// <summary>
        /// Holds the database Connection String
        /// </summary>
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Prog6212_POE_ST10150631.Properties.Settings.StudySyncDBConnectionString"].ConnectionString;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ModuleModel()
        {

        }
        //======================================================= End of Method ===================================================




        /// <summary>
        /// Gets all the modules from the databas based on the user
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public List<Module> GetAllModules(string username)
        {
            // Assuming you have your DbContext set up
            using (var dbContext = new StudySyncDBEntities())
            {
                // 'semestersForUsername' will have all Semesters associated with the username
                List<Module> ModulesForUser = dbContext.Modules
                    .Where(Module => Module.Username == username)
                    .ToList();
                return ModulesForUser;

            }
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Adds a new Module to the Database
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Code"></param>
        /// <param name="WeeklyClassHrs"></param>
        /// <param name="WeeklySelfHrs"></param>
        /// <param name="Credits"></param>
        /// <param name="SemesterID"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public Module AddNewModule(string Name, string Code, double WeeklyClassHrs, double Credits, string SemesterName, string username)
        {
            int SelfHrs = 0;
            Semester foundSemester = MainViewModel.SemestersViewModel.SearchSemester(SemesterName);
            // Query for inserting data into the database
            string Query = "INSERT INTO dbo.[Module] (ModuleName, ModuleCode, WeeklyClassHrs, WeeklySelfHrs,CompletedSelfHrs,WeekWhenAdded, Credits, SemesterName, Username) " +
                           "VALUES (@ModuleName, @ModuleCode, @WeeklyClassHrs, @WeeklySelfHrs,@CompletedSelfHrs,@WeekWhenAdded, @Credits, @SemesterName, @Username);";
             double WeeklySelfHrs = CalculateSelfStudyHrs(WeeklyClassHrs, Credits, foundSemester.Weeks);
            try
            {
                

                using (SqlConnection SQLconnect = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(Query, SQLconnect);
                    command.Parameters.AddWithValue("@ModuleName", Name);
                    command.Parameters.AddWithValue("@ModuleCode", Code);
                    command.Parameters.AddWithValue("@WeeklyClassHrs", WeeklyClassHrs);
                    command.Parameters.AddWithValue("@WeeklySelfHrs", WeeklySelfHrs);
                    command.Parameters.AddWithValue("@CompletedSelfHrs", SelfHrs);
                    command.Parameters.AddWithValue("@WeekWhenAdded", SelfHrs);
                    command.Parameters.AddWithValue("@Credits", Credits);
                    command.Parameters.AddWithValue("@SemesterName", SemesterName);
                    command.Parameters.AddWithValue("@Username", username);

                    // Opens the SQL connection
                    SQLconnect.Open();

                    // Execute the connection
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                MainViewModel.Validate.ErrorMessage("An error has occured please ensure the input is correct");
            }


            // Create a new Semester object (you may need to adjust this part to match your entity)
            var newModule = new Module();
            newModule.ModuleName = Name;
            newModule.ModuleCode = Code;
            newModule.WeeklyClassHrs = WeeklyClassHrs;
            newModule.WeeklySelfHrs = (int)WeeklySelfHrs;
            newModule.Credits = Credits;
            newModule.SemesterName  = SemesterName;
            newModule.Username = username;

            return newModule;

        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Deletes a Module from the database
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void DeleteModule(string ModuleName)
        {
            string username = MainViewModel.UserViewModel.LoggedInUser;
            //Query to delete semester from database using username and semesterName
            string query = $"DELETE FROM dbo.[Module] WHERE Username = '{username}' AND ModuleName = '{ModuleName}';";
            using (SqlConnection SQLconnect = new SqlConnection(ConnectionString))
            {
                SQLconnect.Open();
                SqlCommand cmnd = new SqlCommand(query, SQLconnect);
                cmnd.ExecuteNonQuery();
            }
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Adds Self study Hours completed and the week completed
        /// </summary>
        /// <param name="ModName"></param>
        /// <param name="HrsStudied"></param>
        /// <param name="Week"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void AddHrsStudied(string ModName, double HrsStudied, int Week)
        {
            string username = MainViewModel.UserViewModel.LoggedInUser;

            string query = "UPDATE dbo.[Module] SET CompletedSelfHrs = @HrsStudied, WeekWhenAdded = @Week WHERE Username = @Username AND ModuleName = @ModName";

            using (SqlConnection sqlConnect = new SqlConnection(ConnectionString))
            {
                sqlConnect.Open();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnect))
                {
                    cmd.Parameters.Add(new SqlParameter("@HrsStudied", SqlDbType.Float)).Value = HrsStudied;
                    cmd.Parameters.Add(new SqlParameter("@Week", SqlDbType.Int)).Value = Week;
                    cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar)).Value = username;
                    cmd.Parameters.Add(new SqlParameter("@ModName", SqlDbType.NVarChar)).Value = ModName;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Calculates the number of weekly self study hours required by a module
        /// </summary>
        /// <param name="ClassHrs"></param>
        /// <param name="credits"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public double CalculateSelfStudyHrs(double ClassHrs, double credits, double weeks)
        {
            double SelfStudyHrs = 0;
            SelfStudyHrs = (credits * 10) / weeks - ClassHrs;
            if (SelfStudyHrs < 0)
            {
                SelfStudyHrs = 0;
            }
            SelfStudyHrs = Math.Round(SelfStudyHrs, 2);
            return SelfStudyHrs;

        }
        //======================================================= End of Method ===================================================

    }
}
