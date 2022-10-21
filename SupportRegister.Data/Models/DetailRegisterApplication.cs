using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class DetailRegisterApplication
    {
        public int StudentId { get; set; }
        public int RegisId { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public RegisterApplication Regis { get; set; }
        public Student Student { get; set; }
    }
}
