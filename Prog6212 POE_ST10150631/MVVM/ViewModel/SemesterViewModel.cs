using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
   using Prog6212_POE_ST10150631.MVVM.Model;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Runtime.CompilerServices;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class SemesterViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SemesterClass> _semesterData;

        public ObservableCollection<SemesterClass> SemesterData
        {
            get { return _semesterData; }
            set
            {
                _semesterData = value;
                OnPropertyChanged();
            }
        }

        public SemesterViewModel()
        {
            _semesterData = new ObservableCollection<SemesterClass>();
        }
        /// <summary>
        /// An event for when the semesterData is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes the event if the SemesterData is changed
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
        public void PopulateSemesterList(string Name, DateTime StartDate,double Weeks )
        {
            SemesterClass NewSemester = new SemesterClass();
            double temps = Weeks*7;
            NewSemester.Name = Name;
            NewSemester.Weeks = Weeks;
            NewSemester.StartDate = StartDate.Date;
            NewSemester.EndDate = StartDate.Date;
            NewSemester.EndDate = NewSemester.EndDate.AddDays(temps).Date;
            NewSemester.NumModules = 0;
           

            SemesterData.Add( NewSemester );
            MainViewModel.WorkerClassHere.AddSemester( NewSemester );
            OnPropertyChanged(nameof(SemesterData));

        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Deletes Semesters from both the SemesterList and SemesterData
        /// </summary>
        /// <param name="SemesterName"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void DeleteSemester(string SemesterName)
        {
            MainViewModel.WorkerClassHere.RemoveSemester(SemesterName);
            SemesterClass SelectedSem = SemesterData.FirstOrDefault(semester => semester.Name == SemesterName);
            SemesterData.Remove(SelectedSem);
            OnPropertyChanged(nameof(SemesterData));
        }
        //======================================================= End of Method ===================================================


    }

}
