using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog6212_POE_ST10150631.MVVM.Model
{
    
    public class ModuleClass
    {
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public double Credits { get; set; }
        public double ClassHrs { get; set; }
        public double SelfStudyHrs { get; set; }
        public double CompletedSelfHrs { get; set; }
        public string Semester {  get; set; }   
        public ModuleClass()
        {
            
        }
    }
}
