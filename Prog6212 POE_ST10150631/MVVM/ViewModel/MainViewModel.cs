using Prog6212_POE_ST10150631.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public static class MainViewModel
    {

        public static WorkerClass WorkerClassHere { get; } = new WorkerClass();
        public static SemesterViewModel SemestersViewModel { get; } = new SemesterViewModel();

        public static ValidationViewModel ValidationClassHere { get; } = new ValidationViewModel();

        public static ModulesViewModel ModulesViewModel { get; } = new ModulesViewModel();  
    }
}
