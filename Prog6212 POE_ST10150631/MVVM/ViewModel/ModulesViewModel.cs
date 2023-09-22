using Prog6212_POE_ST10150631.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class ModulesViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<ModuleClass> _moduleData;

        public ObservableCollection<ModuleClass> ModuleData
        {
            get { return _moduleData; }
            set
            {
                _moduleData = value;

                OnPropertyChanged(nameof(ModuleData));
            }
        }

        public ModulesViewModel()
        {
            _moduleData = new ObservableCollection<ModuleClass>();
        }
        /// <summary>
        /// An event for when the semesterData is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Creates a new semester object and adds it to the SemesterList & SemesterData
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="StartDate"></param>
        /// <param name="Weeks"></param>
        public void PopulateModuleList(string Name, string code, double ClassWeeklyHrs ,double credits, string SemesterName)
        {
            ModuleClass newModule = new ModuleClass();
            newModule.ModuleCode = code;
            newModule.ModuleName = Name;
            newModule.ClassHrs = ClassWeeklyHrs;
            newModule.Credits = credits;
            
            SemesterClass tempSemester = MainViewModel.WorkerClassHere.SearchSemester(SemesterName);
            newModule.Semester = tempSemester.Name;
            newModule.SelfStudyHrs = MainViewModel.WorkerClassHere.CalculateSelfStudyHrs(ClassWeeklyHrs,credits,tempSemester.Weeks);
            tempSemester.AddModuleToSemester(newModule);
            MainViewModel.WorkerClassHere.ModuleList.Add(newModule);
            ModuleData.Add(newModule);

            OnPropertyChanged(nameof(ModuleData));


        }
        public void UpdateCompletedSelfHrs(string moduleName, double hrsStudied)
        {
            ModuleClass moduleToUpdate = ModuleData.FirstOrDefault(module => module.ModuleName == moduleName);
            hrsStudied = Math.Round(hrsStudied,2);
            if (moduleToUpdate != null)
            {
                moduleToUpdate.CompletedSelfHrs += hrsStudied;
                OnPropertyChanged(nameof(ModuleData));
            }
            
        }



        /// <summary>
        /// Deletes Semesters from both the SemesterList and SemesterData
        /// </summary>
        /// <param name="SemesterName"></param>
        public void DeleteModule(string ModuleName)
        {
            OnPropertyChanged(nameof(ModuleData));
        }
    }
}
