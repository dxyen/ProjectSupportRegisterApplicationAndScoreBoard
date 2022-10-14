using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class DetailRegisterScoreboard
    {
        public int RegisId { get; set; }
        public int SemesterId { get; set; }
        public int Price { get; set; }
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public int Amount { get; set; }

        public RegisterScoreboard Regis { get; set; }
        public Semester Semester { get; set; }
        public Student Student { get; set; }
        public Year Year { get; set; }
    }
}
