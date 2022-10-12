using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Status
    {
        public Status()
        {
            RegisterApplications = new HashSet<RegisterApplication>();
            RegisterScoreboards = new HashSet<RegisterScoreboard>();
        }

        public int IdStatus { get; set; }
        public string NameStatus { get; set; }

        public virtual ICollection<RegisterApplication> RegisterApplications { get; set; }
        public virtual ICollection<RegisterScoreboard> RegisterScoreboards { get; set; }
    }
}
