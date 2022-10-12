using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Year
    {
        public Year()
        {
            RegisterScoreboards = new HashSet<RegisterScoreboard>();
        }

        public int IdYear { get; set; }
        public string Year1 { get; set; }

        public ICollection<RegisterScoreboard> RegisterScoreboards { get; set; }
    }
}
