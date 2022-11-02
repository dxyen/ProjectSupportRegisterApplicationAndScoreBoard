using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.ViewModels
{
    public class RegisterScoreboardViewModel
    {
        public int IdRegis { get; set; }
        public string Student { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateReceived { get; set; }
        public int? YearStart { get; set; }
#nullable enable
        public string? SemesterStart { get; set; }
        public string? SemesterEnd { get; set; }
        public string? YearSemesterStart { get; set; }
        public string? YearSemesterEnd { get; set; }
#nullable disable
        public int? YearEnd { get; set; }
        public int PriceTotal { get; set; }
        public int Amount { get; set; }
    }
}
