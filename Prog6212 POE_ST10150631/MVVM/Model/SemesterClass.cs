using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    public class SemesterClass
    {
        public double Weeks { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<ModuleClass> SemesterModuleList = new List<ModuleClass>();

        public int NumModules {get;set;}

        public SemesterClass()
        {
            
        }
        /// <summary>
        /// Adds a module to the semesterModuleList
        /// </summary>
        /// <param name="module"></param>
        public void AddModuleToSemester(ModuleClass module)
        {
            SemesterModuleList.Add(module);
        }

    }
}
