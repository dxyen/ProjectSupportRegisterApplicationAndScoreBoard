using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class RegisterScoreboard
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

        public virtual Status IdStatusNavigation { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; }
        public virtual ICollection<Year> Years { get; set; }
    }
}
