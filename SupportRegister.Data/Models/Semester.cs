using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Semester
    {
        public int IdSemester { get; set; }
        public int IdRegisterScoreboard { get; set; }
        public string NameSemester { get; set; }
        public string Description { get; set; }

        public RegisterScoreboard IdRegisterScoreboardNavigation { get; set; }
    }
}
