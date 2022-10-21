using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Semester
    {
        public Semester()
        {
            YearSemesters = new HashSet<YearSemester>();
        }

        public int IdSemester { get; set; }
        public string NameSemester { get; set; }
        public int Price { get; set; }

        public ICollection<YearSemester> YearSemesters { get; set; }
    }
}
