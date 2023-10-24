using Prog6212_POE_ST10150631.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class ValidationViewModel
    {
        /// <summary>
        /// Checks if textbox input is a positive double
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool IsPositiveDouble( TextBox textBox)
        {
            if (TxtBxNotBlank(textBox))
            {
                if (double.TryParse(textBox.Text, out double result))
                {
                    if (result > 0)
                    {
                        return true;

                    }
                    else return false;

                }else return false;
            } else return false;
            
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Checks if a textbox is blank
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool TxtBxNotBlank(TextBox textBox)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                return true;
            }
            return false;
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Checks if a semester of that name already exsists
        /// </summary>
        /// <param name="TextBox"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool IsNewSemester(TextBox TextBox)
        {
           if(TxtBxNotBlank(TextBox))
            {
                var sem = MainViewModel.WorkerClassHere.SearchSemester(TextBox.Text);
               if (sem == null)
                {
                    return true;
                }
               return false;
            } 
           return false;
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Checks if the name and code are unique
        /// </summary>
        /// <param name="TextBox"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool IsNewModule(TextBox TextBox,TextBox code)
        {
            if (TxtBxNotBlank(TextBox))
            {
                var sem = MainViewModel.WorkerClassHere.SearchModules (TextBox.Text);
                ModuleClass FoundModule = MainViewModel.WorkerClassHere.ModuleList.Find(module => module.ModuleCode == code.Text);
                if (sem == null && FoundModule == null)
                {
                    return true;
                }
                return false;
            }
            return false;
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

    }
}
//############################################################### END OF FILE ########################################################
