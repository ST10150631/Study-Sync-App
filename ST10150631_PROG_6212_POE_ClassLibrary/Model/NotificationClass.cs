using Prog6212_POE_ST10150631.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10150631_PROG_6212_POE_ClassLibrary.Model
{
    public class NotificationClass
    {
        /// <summary>
        /// Holds the note name
        /// </summary>
        public string NoteName { get; set; }
        /// <summary>
        /// Holds the module the note is related to
        /// </summary>
        public string module { get; set; }
        /// <summary>
        /// Holds the date and time of the notification 
        /// </summary>
        public DateTime NoteDate { get; set; }
        /// <summary>
        /// Holds the notification description
        /// </summary>
        public string NoteDescription { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public NotificationClass()
        {
        }
        //======================================================= End of Method ===================================================


    }
}
//############################################################### END OF FILE ########################################################
