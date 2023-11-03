using System;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class StudyPgViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public StudyPgViewModel()
        {

        }
        //======================================================= End of Method ===================================================


        /// <summary>
        /// Calculates a semsters current week if not when it starts or ends
        /// if the semester is not currently happening
        /// </summary>
        /// <param name="semesterName"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public string CalculateCurrentWeek(string semesterName)
        {
            var semester = MainViewModel.SemestersViewModel.SearchSemester(semesterName);
            var currentDate = DateTime.Now;

            if (currentDate >= semester.StartDate && currentDate <= semester.EndDate)
            {
                var Start = semester.StartDate;
                int dayCount = 0;

                while (Start.Date < currentDate.Date)
                {
                    dayCount++;
                    Start = Start.AddDays(1); // Reassign the updated date
                }

                int currentWeek = (dayCount / 7) + 1;
                return $"Week {currentWeek}";
            }
            else if (currentDate < semester.StartDate)
            {
                return $"Starts on: {semester.StartDate.ToShortDateString()}";
            }
            else
            {
                return $"Completed on: {semester.EndDate.ToShortDateString()}";
            }
        }
        //======================================================= End of Method ===================================================

        /// <summary>
        /// Gets the Current week as an Int
        /// </summary>
        /// <param name="semesterName"></param>
        /// <returns></returns>
        /// ----------------------------------------------------- Start of Method ------------------------------------------------
        public int GetCurrentWeek(string moduleName)
        {
            var mod = MainViewModel.ModulesViewModel.SearchModules(moduleName);
            var semester = MainViewModel.SemestersViewModel.SearchSemester(mod.SemesterName);
            var currentDate = DateTime.Now;

            if (currentDate >= semester.StartDate && currentDate <= semester.EndDate)
            {
                var Start = semester.StartDate;
                int dayCount = 0;

                while (Start.Date < currentDate.Date)
                {
                    dayCount++;
                    Start = Start.AddDays(1); // Reassign the updated date
                }

                int currentWeek = (dayCount / 7) + 1;
                return currentWeek;
            }
            else
            {
                return 0;
            }
        }
        //======================================================= End of Method ===================================================



    }
}
//############################################################### END OF FILE ########################################################
