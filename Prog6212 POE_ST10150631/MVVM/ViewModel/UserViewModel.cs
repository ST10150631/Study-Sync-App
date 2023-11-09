using Prog6212_POE_ST10150631.MVVM.Model;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class UserViewModel
    {
        private UserModel model = new UserModel();

        public string LoggedInUser;

        public UserViewModel()
        {

        }

        /// <summary>
        /// Registers User
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool TryRegister(string username, string name, string surname, string password)
        {
            if (model.RegisterUser(username, name, surname, password))
            {
                LoggedInUser = username;

                return true;
            }
            return false;
        }
        //======================================================= End of Method ===================================================




        /// <summary>
        /// Logs user in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool TryLogin(string username, string password)
        {
            if (model.LoginUser(username, password) == true)
            {
                LoggedInUser = username;

                return true;
            }
            return false;
        }
        //======================================================= End of Method ===================================================



    }
}
