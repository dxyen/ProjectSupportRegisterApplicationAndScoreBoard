using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class DetailRegisterScoreboard
    {
        public int IdRegisterScoreboard { get; set; }
        public int IdScore { get; set; }
        public int? Amount { get; set; }
        public decimal? Price { get; set; }

        public virtual RegisterScoreboard IdRegisterScoreboardNavigation { get; set; }
        public virtual Scoreboard IdScoreNavigation { get; set; }
    }
}
