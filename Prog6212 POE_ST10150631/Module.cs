//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog6212_POE_ST10150631
{
    using System;
    using System.Collections.Generic;
    
    public partial class Module
    {
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public double WeeklyClassHrs { get; set; }
        public double WeeklySelfHrs { get; set; }
        public Nullable<double> CompletedSelfHrs { get; set; }
        public Nullable<int> WeekWhenAdded { get; set; }
        public double Credits { get; set; }
        public int SemesterID { get; set; }
        public string SemesterName { get; set; }
        public string Username { get; set; }
    
        public virtual Semester Semester { get; set; }
        public virtual User User { get; set; }
    }
}
