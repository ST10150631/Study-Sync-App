using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    public class ValidationModel
    {
        /// <summary>
        /// Instance of module model
        /// </summary>
        private ModuleModel ModuleClass = new ModuleModel();

        /// <summary>
        /// Instance of semester model
        /// </summary>
        private SemesterModel SemesterClass = new SemesterModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ValidationModel()
        {
            
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Sends an Error Message
        /// </summary>
        /// <param name="message"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Input error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Returns result from is new semester 
        /// </summary>
        /// <param name="semestername"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool CheckIsNewSemester(string semestername)
        {
            return SemesterClass.IsNewSemester(semestername);
        }        
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Checks if textbox input is a positive double
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool IsPositiveDouble(string text)
        {
            if (TxtBxNotBlank(text))
            {
                if (double.TryParse(text, out double result))
                {
                    if (result > 0)
                    {
                        return true;

                    }
                    else return false;

                }
                else return false;
            }
            else return false;

        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Checks if a textbox is blank
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool TxtBxNotBlank(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return true;
            }
            return false;
        }
        //======================================================= End of Method ===================================================

    }
}
