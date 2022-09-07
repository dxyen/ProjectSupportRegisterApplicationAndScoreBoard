using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class Staff
    {
        public Staff()
        {
            RegisterApplications = new HashSet<RegisterApplication>();
            RegisterScoreboards = new HashSet<RegisterScoreboard>();
        }

        public int StaffId { get; set; }
        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<RegisterApplication> RegisterApplications { get; set; }
        public virtual ICollection<RegisterScoreboard> RegisterScoreboards { get; set; }
    }
}
