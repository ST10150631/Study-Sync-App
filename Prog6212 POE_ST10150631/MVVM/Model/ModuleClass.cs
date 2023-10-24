using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    
    public class ModuleClass
    {
        /// <summary>
        /// Holds the module name
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Holds the module code 
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// Holds the number of credits
        /// </summary>
        public double Credits { get; set; }

        /// <summary>
        /// Holds the number of class hours
        /// </summary>
        public double ClassHrs { get; set; }

        /// <summary>
        /// Holds the number of self study hours per week for a module
        /// </summary>
        public double SelfStudyHrs { get; set; }

        /// <summary>
        /// Holds the number of weekly self study hours completed
        /// </summary>
        public double CompletedSelfHrs { get; set; }

        /// <summary>
        /// Holds the name of the semester this module belongs to 
        /// </summary>
        public string Semester {  get; set; }   

        /// <summary>
        /// default constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ModuleClass()
        {
                    


        }
        //======================================================= End of Method ===================================================
    }
}
//############################################################### END OF FILE ########################################################
