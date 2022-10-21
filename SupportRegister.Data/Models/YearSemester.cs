using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Models
{
    public class YearSemester
    {
        public YearSemester()
        {
            DetailRegisterScoreboardYearSemesterIdEndNavigations = new HashSet<DetailRegisterScoreboard>();
            DetailRegisterScoreboardYearSemesterIdStartNavigations = new HashSet<DetailRegisterScoreboard>();
        }

        public int IdYear { get; set; }
        public int IdSemester { get; set; }
        public string YearSemester1 { get; set; }
        public int Id { get; set; }

        public Semester IdSemesterNavigation { get; set; }
        public Year IdYearNavigation { get; set; }
        public virtual ICollection<DetailRegisterScoreboard> DetailRegisterScoreboardYearSemesterIdEndNavigations { get; set; }
        public virtual ICollection<DetailRegisterScoreboard> DetailRegisterScoreboardYearSemesterIdStartNavigations { get; set; }
    }
}
