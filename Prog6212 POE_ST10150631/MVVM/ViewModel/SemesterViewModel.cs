﻿using System;
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
        private SemesterModel model = new SemesterModel();
        private ObservableCollection<Semester> _semesterData;

        public ObservableCollection<Semester> SemesterData
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
            _semesterData = new ObservableCollection<Semester>();
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
        /// Searches for a semester in the SemesterData using semesterName
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public Semester SearchSemester(string Name)
        {
                var foundSemester = SemesterData.FirstOrDefault(Sem => Sem.SemesterName == Name);
            return foundSemester;
        }
        //======================================================= End of Method ===================================================



        /// <summary>
        /// Adds a new semester to the database
        /// </summary>
        /// <param name="SemesterName"></param>
        /// <param name="Weeks"></param>
        /// <param name="StartDate"></param>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void AddSemester(string SemesterName, double Weeks, DateTime StartDate)
        {
            var user = MainViewModel.UserViewModel.LoggedInUser;
            var NewSem = model.AddNewSemester(SemesterName, Weeks, StartDate,user );
            SemesterData.Add(NewSem);   
            OnPropertyChanged(nameof(SemesterData));
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Gets the data for the users semesters to be displayed in the datagrid
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public void GetTableData()
        {
            List<Semester> tempData = new List<Semester>();
            tempData = model.GetAllSemesters(MainViewModel.UserViewModel.LoggedInUser);
            _semesterData.Clear();
            foreach(var semester in tempData)
            {
                _semesterData.Add(semester);
            }
            SemesterData = _semesterData;
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
            var SelectedSem = SemesterData.FirstOrDefault(Sem => Sem.SemesterName == SemesterName);
            model.DeleteSemester(SemesterName);
            SemesterData.Remove(SelectedSem) ;
            OnPropertyChanged(nameof(SemesterData));
        }
        //======================================================= End of Method ===================================================


    }

}
