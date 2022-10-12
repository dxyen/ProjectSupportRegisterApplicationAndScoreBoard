using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.ViewModels
{
    public class RegisterScoreboardViewModel
    {
        public string Student { get; set; }
        public string Status { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateReceived { get; set; }
        public string Year { get; set; }
        public string Semester { get; set; }
        public int PriceTotal { get; set; }
    }
}
