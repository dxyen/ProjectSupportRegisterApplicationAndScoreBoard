using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Staff
    {
        public Staff()
        {
            RegisterApplications = new HashSet<RegisterApplication>();
            RegisterScoreboards = new HashSet<RegisterScoreboard>();
        }

        public int StaffId { get; set; }
        public Guid UserId { get; set; }

        public AppUser User { get; set; }
        public ICollection<RegisterApplication> RegisterApplications { get; set; }
        public ICollection<RegisterScoreboard> RegisterScoreboards { get; set; }
    }
}
