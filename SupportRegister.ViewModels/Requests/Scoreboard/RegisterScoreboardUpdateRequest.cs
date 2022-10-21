using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.Scoreboard
{
    public class RegisterScoreboardUpdateRequest
    {
        public int IdRegisterScoreboard { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateReceived { get; set; }
        public int RegisId { get; set; }
        public int SemesterId { get; set; }
        public int Price { get; set; }
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public int Amount { get; set; }
    }
}
