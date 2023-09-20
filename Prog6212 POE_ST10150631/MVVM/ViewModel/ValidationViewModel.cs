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

        public bool TxtBxNotBlank(TextBox textBox)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a semester of that name already exsists
        /// </summary>
        /// <param name="TextBox"></param>
        /// <returns></returns>
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

        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Input error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
