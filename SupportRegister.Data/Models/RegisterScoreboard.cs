using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class RegisterScoreboard
    {
        public RegisterScoreboard()
        {
            DetailRegisterScoreboards = new HashSet<DetailRegisterScoreboard>();
        }

        public int IdRegisterScoreboard { get; set; }
        public int StudentId { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateReceived { get; set; }
        public int YearId { get; set; }
        public int SemesterId { get; set; }

        public Status IdStatusNavigation { get; set; }
        public Semester Semester { get; set; }
        public Student Student { get; set; }
        public Year Year { get; set; }
        public ICollection<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
    }
}
