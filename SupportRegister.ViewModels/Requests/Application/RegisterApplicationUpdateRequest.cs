using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.Application
{
    public class RegisterApplicationUpdateRequest
    {
        public int IdRegisterApplication { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateReceived { get; set; }
        public int ApplicationId { get; set; }
        public int StudentId { get; set; }
        public int RegisId { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
