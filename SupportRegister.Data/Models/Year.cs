using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Year
    {
        public int IdYear { get; set; }
        public int IdRegisterScoreboard { get; set; }
        public int Yearr { get; set; }
        public string Description { get; set; }

        public RegisterScoreboard IdRegisterScoreboardNavigation { get; set; }
    }
}
