using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.Application
{
    public class RegisterApplicationCancelRequest
    {
        public int IdRegisterApplication { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
