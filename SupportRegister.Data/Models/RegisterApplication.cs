using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class RegisterApplication
    {
        public RegisterApplication()
        {
            DetailRegisterApplications = new HashSet<DetailRegisterApplication>();
        }

        public int IdRegisterApplication { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateReceived { get; set; }
        public int ApplicationId { get; set; }

        public Application Application { get; set; }
        public Status IdStatusNavigation { get; set; }
        public ICollection<DetailRegisterApplication> DetailRegisterApplications { get; set; }
    }
}
