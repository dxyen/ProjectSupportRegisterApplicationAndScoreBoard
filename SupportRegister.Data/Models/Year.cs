using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Year
    {
        public Year()
        {
            YearSemesters = new HashSet<YearSemester>();
        }

        public int IdYear { get; set; }
        public int Year1 { get; set; }

        public ICollection<YearSemester> YearSemesters { get; set; }
    }
}
