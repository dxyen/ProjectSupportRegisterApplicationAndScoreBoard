using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class Year
    {
        public int IdYear { get; set; }
        public int IdRegisterScoreboard { get; set; }
        public int Yearr { get; set; }
        public string Description { get; set; }

        public virtual RegisterScoreboard IdRegisterScoreboardNavigation { get; set; }
    }
}
