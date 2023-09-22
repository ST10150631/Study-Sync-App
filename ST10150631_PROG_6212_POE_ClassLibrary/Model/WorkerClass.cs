using ST10150631_PROG_6212_POE_ClassLibrary.Model;
using System;
using System.Collections.Generic;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    public class WorkerClass
    {
        /// <summary>
        /// Holds SemesterClass objects 
        /// </summary>
        public List<SemesterClass> SemesterList = new List<SemesterClass>();
        /// <summary>
        /// Holds module class objects as a List
        /// </summary>
        public List<ModuleClass> ModuleList = new List<ModuleClass>();
        /// <summary>
        /// Holds notification Class objects as a List
        /// </summary>
        public List <NotificationClass> NotificationList = new List<NotificationClass>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public WorkerClass()
        {


        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Adds SemesterClass to the SemesterList
        /// <param name="semester"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void AddSemester(SemesterClass semester)
        {

            SemesterList.Add(semester); 
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Deletes a semester from the semesterList
        /// </summary>
        /// <param name="name"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void RemoveSemester(string name)
        {
            if (SearchSemester(name)!=null)
            {
                SemesterList.Remove(SearchSemester(name));
            }
        }
            //======================================================= End of Method ===================================================



        /// <summary>
        /// Searches for a Semeseter in the semsterList
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public SemesterClass SearchSemester(string searchName)
        {

            SemesterClass foundSemester = SemesterList.Find(semester => semester.Name == searchName);


            // Check if a recipe was found and print out its description
            if (foundSemester != null)
            {
                return foundSemester;
            }
            else
            {
                return null;
            }
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Searches for a module in the moduleList using a moduleName
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ModuleClass SearchModules(string searchName)
        {

            ModuleClass foundModule = ModuleList.Find(module => module.ModuleName == searchName);


            // Check if a recipe was found and print out its description
            if (foundModule != null)
            {
                return foundModule;
            }
            else
            {
                return null;
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
            double SelfStudyHrs =0;
            SelfStudyHrs = (credits * 10) / weeks - ClassHrs;
            if (SelfStudyHrs < 0)
            {
                SelfStudyHrs = 0;
            }
            SelfStudyHrs = Math.Round(SelfStudyHrs, 2);
            return SelfStudyHrs;

        }
        //======================================================= End of Method ===================================================


        //public double AddHrsStudied(string ModuleName,double completedHrs)
        //{
        //    ModuleClass Mod = SearchModules(ModuleName);
        //    if(Mod != null)
        //    {
        //        Mod.CompletedSelfHrs = completedHrs;
        //    }
            

        //}



    }
}
//############################################################### END OF FILE ########################################################
