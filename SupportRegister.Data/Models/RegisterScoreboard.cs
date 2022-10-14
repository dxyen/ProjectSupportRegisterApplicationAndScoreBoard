using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class RegisterScoreboard
    {
        public RegisterScoreboard()
        {
            DetailRegisterScoreboards = new HashSet<DetailRegisterScoreboard>();
        }

        public int IdRegisterScoreboard { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateReceived { get; set; }

        public Status IdStatusNavigation { get; set; }
        public ICollection<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
    }
}
