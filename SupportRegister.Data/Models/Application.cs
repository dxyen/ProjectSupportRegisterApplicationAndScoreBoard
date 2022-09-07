using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class Application
    {
        public Application()
        {
            DetailRegisterApplications = new HashSet<DetailRegisterApplication>();
        }

        public int IdApplication { get; set; }
        public int IdTypeApplication { get; set; }
        public string NameApplication { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public decimal? Price { get; set; }

        public virtual TypeApplication IdTypeApplicationNavigation { get; set; }
        public virtual ICollection<DetailRegisterApplication> DetailRegisterApplications { get; set; }
    }
}
