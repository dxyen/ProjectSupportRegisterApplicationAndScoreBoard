using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class TypeApplication
    {
        public TypeApplication()
        {
            Applications = new HashSet<Application>();
        }

        public int IdTypeApplication { get; set; }
        public string NameTypeApplication { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
