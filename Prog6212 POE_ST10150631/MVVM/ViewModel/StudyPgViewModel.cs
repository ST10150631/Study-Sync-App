using System;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    public class StudyPgViewModel
    {

        public StudyPgViewModel()
        {

        }

        public string CalculateCurrentWeek(string semesterName)
        {
            var semester = MainViewModel.WorkerClassHere.SearchSemester(semesterName);
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

    }
}
