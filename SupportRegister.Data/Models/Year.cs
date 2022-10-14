using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Year
    {
        public Year()
        {
            DetailRegisterScoreboards = new HashSet<DetailRegisterScoreboard>();
        }

        public int IdYear { get; set; }
        public int Year1 { get; set; }

        public ICollection<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
    }
}
