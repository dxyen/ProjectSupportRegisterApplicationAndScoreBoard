using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class DetailRegisterScoreboard
    {
        public int RegisId { get; set; }
        public int Price { get; set; }
        public int StudentId { get; set; }
        public int Amount { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
#nullable enable
        public string? SemesterStart { get; set; }
        public string? SemesterEnd { get; set; }
#nullable disable
        public int YearSemesterIdStart { get; set; }
        public int YearSemesterIdEnd { get; set; }
        public RegisterScoreboard Regis { get; set; }
        public Student Student { get; set; }
        public YearSemester YearSemesterIdEndNavigation { get; set; }
        public YearSemester YearSemesterIdStartNavigation { get; set; }
    }
}
