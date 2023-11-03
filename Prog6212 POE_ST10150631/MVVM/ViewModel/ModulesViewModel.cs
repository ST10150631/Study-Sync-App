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
        /// <summary>
        /// Instance of Mudule Model
        /// </summary>
        private ModuleModel model = new ModuleModel();
        /// <summary>
        /// Holds Moduleclasses as an observable collection to bu used for binding
        /// </summary>
        private ObservableCollection<Module> _moduleData;

        /// <summary>
        /// Holds Moduleclasses as an observable collection to bu used for binding
        /// </summary>
        public ObservableCollection<Module> ModuleData
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
            _moduleData = new ObservableCollection<Module>();
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
        /// Adds a new Module to the ModuleData Obesrvable Collection
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Code"></param>
        /// <param name="WeeklyClassHrs"></param>
        /// <param name="Credits"></param>
        /// <param name="SemesterID"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void AddModule(string Name, string Code, double WeeklyClassHrs, double Credits, string SemesterName)
        {
            var user = MainViewModel.UserViewModel.LoggedInUser;
            var NewMod = model.AddNewModule(Name, Code, WeeklyClassHrs, Credits, SemesterName, user);
            ModuleData.Add(NewMod);
            OnPropertyChanged(nameof(ModuleData));
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Clears module Data for user
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void ClearModuleData()
        {
            _moduleData.Clear();
            ModuleData.Clear();
            OnPropertyChanged(nameof(ModuleData));  
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Searches for a Module in the ModuleData using ModuleName
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public Module SearchModules(string Name)
        {
            var foundModule = ModuleData.FirstOrDefault(Mod => Mod.ModuleName == Name);
            return foundModule;
        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Gets the data to be displayed in the datagrid and comboboxes
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void GetModuleData()
        {
            var user = MainViewModel.UserViewModel.LoggedInUser;
            List<Module> tempData = new List<Module>();
            tempData = model.GetAllModules(user);
            _moduleData.Clear();
            foreach (var module in tempData)
            {
                _moduleData.Add(module);
            }
            ModuleData = _moduleData;
            OnPropertyChanged(nameof(ModuleData));
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Checks if There is a module with that name or code already
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public bool IsNewModule(string name, string code) 
        {
            string username = MainViewModel.UserViewModel.LoggedInUser;
            var foundName = ModuleData.FirstOrDefault(module => module.ModuleName == name);
            var foundCode = ModuleData.FirstOrDefault(module => module.ModuleCode == code);
            if (ModuleData.Contains(foundName))
            {
                return false;
            }
            else if (ModuleData.Contains(foundCode)) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //======================================================= End of Method ===================================================




        /// <summary>
        /// Updates the modules Completed Self Study Hrs for moduleData
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="hrsStudied"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void UpdateCompletedSelfHrs(string moduleName, double hrsStudied, int CurrentWeek)
        {
            Module moduleToUpdate = ModuleData.FirstOrDefault(module => module.ModuleName == moduleName);
            hrsStudied = Math.Round(hrsStudied,2);
            if (moduleToUpdate != null)
            {
                model.AddHrsStudied(moduleName, hrsStudied, CurrentWeek);
                ModuleData.FirstOrDefault(module => module.ModuleName == moduleName).CompletedSelfHrs += hrsStudied;
                ModuleData.FirstOrDefault(module => module.ModuleName == moduleName).WeekWhenAdded = CurrentWeek;

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
            var SelectedMod = ModuleData.FirstOrDefault(mod => mod.ModuleName == ModuleName);
            model.DeleteModule(ModuleName);
            ModuleData.Remove(SelectedMod);
            OnPropertyChanged(nameof(ModuleData));
        }        
        //======================================================= End of Method ===================================================


    }
}
//############################################################### END OF FILE ########################################################
