﻿using Prog6212_POE_ST10150631.MVVM.Model;
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
        /// <summary>
        /// Holds Moduleclasses as an observable collection to bu used for binding
        /// </summary>
        private ObservableCollection<ModuleClass> _moduleData;

        /// <summary>
        /// Holds Moduleclasses as an observable collection to bu used for binding
        /// </summary>
        public ObservableCollection<ModuleClass> ModuleData
        {
            get { return _moduleData; }
            set
            {
                _moduleData = value;

                OnPropertyChanged(nameof(ModuleData));
            }
        }

        /// <summary>
        /// Default constructor 
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public ModulesViewModel()
        {
            _moduleData = new ObservableCollection<ModuleClass>();
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// An event for when the semesterData is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes the onpropertyChanged event
        /// </summary>
        /// <param name="propertyName"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Creates a new semester object and adds it to the SemesterList & SemesterData
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="StartDate"></param>
        /// <param name="Weeks"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
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

            MainViewModel.WorkerClassHere.AddmoduleToList(newModule);
            ModuleData.Add(newModule);

            OnPropertyChanged(nameof(ModuleData));


        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Updates the modules Completed Self Study Hrs for moduleData
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="hrsStudied"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
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
        //======================================================= End of Method ===================================================




        /// <summary>
        /// Deletes Modules from both the ModuleList and ModuleData
        /// </summary>
        /// <param name="SemesterName"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void DeleteModule(string ModuleName)
        {
            ModuleClass SelectedMod = ModuleData.FirstOrDefault(Mod => Mod.ModuleName == ModuleName);
            ModuleData.Remove(SelectedMod);
            MainViewModel.WorkerClassHere.RemoveModule(ModuleName);
            OnPropertyChanged(nameof(ModuleData));
        }        
        //======================================================= End of Method ===================================================


    }
}
//############################################################### END OF FILE ########################################################
