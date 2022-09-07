using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class RegisterApplication
    {
        public RegisterApplication()
        {
            DetailRegisterApplications = new HashSet<DetailRegisterApplication>();
        }

        public int IdRegisterApplication { get; set; }
        public int StudentId { get; set; }
        public int IdStatus { get; set; }
        public int StaffId { get; set; }
        public DateTime? DateRegister { get; set; }
        public DateTime? DateReceived { get; set; }

        public virtual Status IdStatusNavigation { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<DetailRegisterApplication> DetailRegisterApplications { get; set; }
    }
}
