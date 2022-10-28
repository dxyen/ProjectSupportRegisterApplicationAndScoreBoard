using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class RegisterApplication
    {

        public int StudentId { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateReceived { get; set; }
        public int ApplicationId { get; set; }
        public string Content { get; set; }
        public string Dear { get; set; }

        public Application Application { get; set; }
        public Status IdStatusNavigation { get; set; }
        public Student Student { get; set; }
    }
}
