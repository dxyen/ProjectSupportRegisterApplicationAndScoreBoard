using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Application
    {
        public Application()
        {
            DetailRegisterApplications = new HashSet<DetailRegisterApplication>();
        }

        public int IdApplication { get; set; }
        public string NameApplication { get; set; }    
        public string Description { get; set; }
        public string Content { get; set; }
        public int? Price { get; set; }

        public ICollection<DetailRegisterApplication> DetailRegisterApplications { get; set; }
    }
}
