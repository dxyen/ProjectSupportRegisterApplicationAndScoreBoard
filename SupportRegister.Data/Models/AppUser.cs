using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Students = new HashSet<Student>();
            Staff = new HashSet<Staff>();
        }
        public string Address { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Avatar { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Staff> Staff { get; set; }
    }
}
