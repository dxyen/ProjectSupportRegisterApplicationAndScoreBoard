using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.Scoreboard
{
    public class RegisterScoreboardCreateRequest
    {
        public int StudentId { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateReceived { get; set; }
        public int YearId { get; set; }
        public int SemesterId { get; set; }
    }
}
