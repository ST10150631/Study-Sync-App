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
        public List<ModuleClass> ModuleList = new List<ModuleClass>();
        public WorkerClass()
        {


        }
        /// <summary>
        /// Adds SemesterClass to the SemesterList
        /// <param name="semester"></param>
        public void AddSemester(SemesterClass semester)
        {

            SemesterList.Add(semester); 
        }


        /// <summary>
        /// Deletes a semester from the semesterList
        /// </summary>
        /// <param name="name"></param>
        public void RemoveSemester(string name)
        {
            if (SearchSemester(name)!=null)
            {
                SemesterList.Remove(SearchSemester(name));
            }
        }
    

        /// <summary>
        /// Searches for a Semeseter in the semsterList
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Searches for a module in the moduleList using a moduleName
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        /// 
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

        public double CalculateSelfStudyHrs(double ClassHrs, double credits, double weeks)
        {
            double SelfStudyHrs =0;
            SelfStudyHrs = (credits * 10) / weeks - ClassHrs;
            if (SelfStudyHrs < 0)
            {
                SelfStudyHrs = 0;
            }
            return SelfStudyHrs;

        }



    }
}
