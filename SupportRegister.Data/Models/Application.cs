using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Application
    {
        public Application()
        {
            RegisterApplications = new HashSet<RegisterApplication>();
        }

        public int IdApplication { get; set; }
        public string NameApplication { get; set; }
        public string Description { get; set; }

        public ICollection<RegisterApplication> RegisterApplications { get; set; }
    }
}
