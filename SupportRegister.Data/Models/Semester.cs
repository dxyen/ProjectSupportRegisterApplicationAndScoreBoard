using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Semester
    {
        public Semester()
        {
            RegisterScoreboards = new HashSet<RegisterScoreboard>();
        }

        public int IdSemester { get; set; }
        public string NameSemester { get; set; }

        public virtual ICollection<RegisterScoreboard> RegisterScoreboards { get; set; }
    }
}
