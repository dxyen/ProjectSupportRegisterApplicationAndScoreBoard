using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class DetailRegisterScoreboard
    {
        public int IdRegisterScoreboard { get; set; }
        public int IdScore { get; set; }
        public int? Amount { get; set; }
        public int? Price { get; set; }

        public RegisterScoreboard IdRegisterScoreboardNavigation { get; set; }
        public Scoreboard IdScoreNavigation { get; set; }
    }
}
