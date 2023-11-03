using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    public class UserModel
    {
        /// <summary>
        /// Holds the Connection string
        /// </summary>
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Prog6212_POE_ST10150631.Properties.Settings.StudySyncDBConnectionString"].ConnectionString;
        private StudySyncDBEntities Entity;

        private User UserEntity;
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserModel()
        {

        }

        /// <summary>
        /// Takes User Input for sign Up and adds user to database if all data valid
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="FistName"></param>
        /// <param name="Surname"></param>
        /// <param name="Password"></param>
        public bool RegisterUser(string Username, string FirstName, string Surname, string Password)
        {
            //Hashing the password 
            var HashedPassword = HashPassword(Password);
            //Query for inserting data into the database 
            string NewUserQuery = "INSERT INTO dbo.[User] (Username, FirstName, Surname,PasswordHash ) VALUES (@Username,@FirstName,@Surname,@PasswordHash);";
            if (GetUserDetails(Username) == null)
            {


                using (SqlConnection SQLconnect = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(NewUserQuery, SQLconnect);

                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@Surname", Surname);
                    command.Parameters.AddWithValue("@PasswordHash", HashedPassword);
                    //Opens the SQL connection 
                    SQLconnect.Open();

                    //Execute the connection
                    command.ExecuteNonQuery();

                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Logs the user in and verifies password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginUser(string username, string password)
        {
            UserEntity = new User();
            UserEntity = GetUserDetails(username);
            if (UserEntity != null)
            {
                if (VerifyPassword(password, UserEntity.PasswordHash) == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Gets the user using the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUserDetails(string username)
        {
            UserEntity = new User();
            try
            {
                using (this.Entity = new StudySyncDBEntities())
                {
                    UserEntity = Entity.Users.Find(username);
                    if (UserEntity != null)
                    {
                        return UserEntity;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Hashes and salts the password to be saved to database 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Create a new instance of the Rfc2898DeriveBytes class to perform the hash
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 bytes is a common choice for the hash size
                byte[] combinedBytes = new byte[salt.Length + hash.Length];

                // Combine the salt and hash bytes into a single byte array
                Array.Copy(salt, 0, combinedBytes, 0, salt.Length);
                Array.Copy(hash, 0, combinedBytes, salt.Length, hash.Length);

                // Convert the combined salt+hash bytes to a Base64-encoded string
                string base64Hash = Convert.ToBase64String(combinedBytes);

                return base64Hash;
            }
        }

        /// <summary>
        /// Verifies that the username and password match
        /// </summary>
        /// <param name="enteredPassword"></param>
        /// <param name="storedPasswordHash"></param>
        /// <returns></returns>
        private static bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            // Convert the stored password hash back to bytes
            byte[] hashBytes = Convert.FromBase64String(storedPasswordHash);

            // Extract the salt from the hash bytes
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute a new hash of the entered password using the stored salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
            {
                byte[] testHash = pbkdf2.GetBytes(32); // 32 bytes is a common choice for the hash size

                // Compare the computed hash with the stored hash
                for (int i = 0; i < 32; i++)
                {
                    if (testHash[i] != hashBytes[i + 16])
                    {
                        return false; // Passwords don't match
                    }
                }

                return true; // Passwords match
            }
        }
    }
}
