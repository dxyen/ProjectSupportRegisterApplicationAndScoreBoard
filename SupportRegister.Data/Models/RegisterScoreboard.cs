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
            Semesters = new HashSet<Semester>();
            Years = new HashSet<Year>();
        }

        public int IdRegisterScoreboard { get; set; }
        public int StudentId { get; set; }
        public int StaffId { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateReceived { get; set; }

        public Status IdStatusNavigation { get; set; }
        public Staff Staff { get; set; }
        public Student Student { get; set; }
        public ICollection<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
        public ICollection<Semester> Semesters { get; set; }
        public ICollection<Year> Years { get; set; }
    }
}
