using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.Scoreboard
{
    public class RegisterScoreboardCancelRequest
    {
        public int IdRegisterScoreboard { get; set; }
        public int StudentId { get; set; }
        public int IdStatus { get; set; }
    }
}
