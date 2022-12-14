using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.System.Users
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
