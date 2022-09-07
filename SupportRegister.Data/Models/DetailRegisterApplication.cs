using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public partial class DetailRegisterApplication
    {
        public int IdApplication { get; set; }
        public int IdRegisterApplication { get; set; }
        public int? Amount { get; set; }
        public decimal? Price { get; set; }

        public virtual Application IdApplicationNavigation { get; set; }
        public virtual RegisterApplication IdRegisterApplicationNavigation { get; set; }
    }
}
