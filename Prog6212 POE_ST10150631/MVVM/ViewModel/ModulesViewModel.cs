using Prog6212_POE_ST10150631.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class ModulesViewModel
    {

        private ObservableCollection<ModuleClass> _moduleData;

        public ObservableCollection<ModuleClass> ModuleData
        {
            get { return _moduleData; }
            set
            {
                _moduleData = value;
                OnPropertyChanged();
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
        public void PopulateModuleList(string Name, string code, double ClassWeeklyHrs ,double credits, double CompletedHrs)
        {
            OnPropertyChanged(nameof(ModuleData));

        }
        /// <summary>
        /// Deletes Semesters from both the SemesterList and SemesterData
        /// </summary>
        /// <param name="SemesterName"></param>
        public void DeleteModule(string SemesterName)
        {

            OnPropertyChanged(nameof(ModuleData));
        }
    }
}
