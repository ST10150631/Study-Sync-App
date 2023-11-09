
using Prog6212_POE_ST10150631.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Prog6212_POE_ST10150631.MVVM.ViewModel
{
    
    public static class MainViewModel
    {
        public static NoteViewModel NoteViewModel = new NoteViewModel();    

        public static ValidationModel Validate { get; } = new ValidationModel();

        public static SemesterViewModel SemestersViewModel { get; } = new SemesterViewModel();

        public static ModulesViewModel ModulesViewModel { get; } = new ModulesViewModel();

        public static StudyPgViewModel StudyPgViewModel { get; } = new StudyPgViewModel();

        public static UserViewModel UserViewModel { get; } = new UserViewModel();   

        public static MediaPlayer MusicPlayer { get; } = new MediaPlayer();
    }
}
