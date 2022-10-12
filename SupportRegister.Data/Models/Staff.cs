using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
