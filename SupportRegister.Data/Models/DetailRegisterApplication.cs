using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class DetailRegisterApplication
    {
        public int IdApplication { get; set; }
        public int IdRegisterApplication { get; set; }
        public int? Amount { get; set; }
        public decimal? Price { get; set; }

        public Application IdApplicationNavigation { get; set; }
        public RegisterApplication IdRegisterApplicationNavigation { get; set; }
    }
}
